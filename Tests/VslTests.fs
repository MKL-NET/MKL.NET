module VslTests

open System
open MKLNET
open CsCheck

let all =
    test "Vsl" {

        let rngRegressionTest name gen brng seed hash =
            let name = name + "_" + Enum.GetName(typeof<VslBrng>, brng)
            test ("rng_"+name) {
                let stream = Vsl.NewStream(brng, seed)
                let r = Array.zeroCreate<double> 100
                gen stream r |> Check.equal 0
                Vsl.DeleteStream stream |> Check.equal 0
                Array.sumBy abs r |> Check.notDefaultValue
                use hash = Hash.Expected(Nullable hash,callerMemberName=name)
                hash.Add(r, 10)
            }

        let rng s r = Vsl.RngGaussian(VslMethodGaussian.ICDF, s, Array.length r, r, 0.0, 1.0)
        let rngRegTest brng seed expected = rngRegressionTest "gaussian" rng brng seed expected
        rngRegTest VslBrng.MCG31         1009u 3798170
        rngRegTest VslBrng.R250          1019u 1318477131
        rngRegTest VslBrng.MRG32K3A      1029u -1770215917
        rngRegTest VslBrng.MCG59         1039u -609587276
        rngRegTest VslBrng.WH            1049u 988954032
        rngRegTest VslBrng.SOBOL         1059u 64673350
        rngRegTest VslBrng.NIEDERR       1069u 64673350
        rngRegTest VslBrng.MT19937       1079u 2108214711
        rngRegTest VslBrng.MT2203        1089u -1757665964
        rngRegTest VslBrng.SFMT19937     1099u -1731241801
        rngRegTest VslBrng.ARS5          1109u 860073583
        rngRegTest VslBrng.PHILOX4X32X10 1119u 787349297

        let rng s r = Vsl.RngBeta(VslMethodBeta.CJA, s, Array.length r, r, 2.0, 5.0, 0.0, 1.0)
        let rngRegTest brng seed expected = rngRegressionTest "beta" rng brng seed expected
        rngRegTest VslBrng.MCG31         2009u -2015148747
        rngRegTest VslBrng.R250          2019u 858936869
        rngRegTest VslBrng.MRG32K3A      2029u -1049523575
        rngRegTest VslBrng.MCG59         2039u 1073825603
        rngRegTest VslBrng.WH            2049u 929283647
        rngRegTest VslBrng.SOBOL         2059u -820544284
        rngRegTest VslBrng.NIEDERR       2069u -820544284
        rngRegTest VslBrng.MT19937       2079u -279215963
        rngRegTest VslBrng.MT2203        2089u 1859750150
        rngRegTest VslBrng.SFMT19937     2099u 825207367
        rngRegTest VslBrng.ARS5          2109u 1759601342
        rngRegTest VslBrng.PHILOX4X32X10 2119u 176703846

        let rng s r = Vsl.RngCauchy(VslMethodCauchy.ICDF, s, Array.length r, r, 0.0, 1.0)
        let rngRegTest brng seed expected = rngRegressionTest "cauchy" rng brng seed expected
        rngRegTest VslBrng.MCG31         1009u 1875509389
        rngRegTest VslBrng.R250          1019u 794383798
        rngRegTest VslBrng.MRG32K3A      1029u 181047374
        rngRegTest VslBrng.MCG59         1039u -2142079512
        rngRegTest VslBrng.WH            1049u -86618128
        rngRegTest VslBrng.SOBOL         1059u 331600171
        rngRegTest VslBrng.NIEDERR       1069u 331600171
        rngRegTest VslBrng.MT19937       1079u -621241490
        rngRegTest VslBrng.MT2203        1089u -1913958000
        rngRegTest VslBrng.SFMT19937     1099u -1570723122
        rngRegTest VslBrng.ARS5          1109u 761492270
        rngRegTest VslBrng.PHILOX4X32X10 1119u 17555386

        let rng s (r:double[]) = Vsl.RngChiSquare(VslMethodChiSquare.CHI2GAMMA, s, Array.length r, r, 5)
        let rngRegTest brng seed expected = rngRegressionTest "chisquare" rng brng seed expected
        rngRegTest VslBrng.MCG31         1009u 2012264470
        rngRegTest VslBrng.R250          1019u -1880633538
        rngRegTest VslBrng.MRG32K3A      1029u 645848553
        rngRegTest VslBrng.MCG59         1039u -1304033450
        rngRegTest VslBrng.WH            1049u -1944734309
        rngRegTest VslBrng.SOBOL         1059u -1456066750
        rngRegTest VslBrng.NIEDERR       1069u -1456066750
        rngRegTest VslBrng.MT19937       1079u 92636278
        rngRegTest VslBrng.MT2203        1089u 1053279542
        rngRegTest VslBrng.SFMT19937     1099u 432958341
        rngRegTest VslBrng.ARS5          1109u -525086944
        rngRegTest VslBrng.PHILOX4X32X10 1119u -64858375

        test "mean_double" {
            let! obvs = Gen.Int.[1,100]
            let! vars = Gen.Int.[1,100]
            let! x = Gen.Double.[1.0,2.0].Array.[obvs*vars]
            let mean = Array.zeroCreate<double> vars
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x)
            Vsl.SSEditTask(task, VslEdit.MEAN, mean) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.MEAN, VslMethod.FAST) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            let expected = Array.init vars (fun i ->
                let mutable total = 0.0
                for j = 0 to obvs - 1 do
                    total <- total + x.[i * obvs + j]
                total / double obvs
            )
            Check.close VeryHigh expected mean
        }

        test "mean_single" {
            let! obvs = Gen.Int.[1,100]
            let! vars = Gen.Int.[1,100]
            let! x = Gen.Single.[1.0f,2.0f].Array.[obvs*vars]
            let mean = Array.zeroCreate<single> vars
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x)
            Vsl.SSEditTask(task, VslEdit.MEAN, mean) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.MEAN, VslMethod.FAST) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            let expected = Array.init vars (fun i ->
                let mutable total = 0.0f
                for j = 0 to obvs - 1 do
                    total <- total + x.[i * obvs + j]
                total / single obvs
            )
            Check.close High expected mean
        }

        test "mean_weight" {
            let! obvs = Gen.Int.[1,100]
            let! vars = Gen.Int.[1,100]
            let! x = Gen.Double.[1.0,2.0].Array.[obvs*vars]
            let mean = Array.zeroCreate<double> vars
            let weight = Array.init obvs (fun i -> double(i+1))
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x, weight)
            Vsl.SSEditTask(task, VslEdit.MEAN, mean) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.MEAN, VslMethod.FAST) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            let expected = Array.init vars (fun i ->
                let mutable total = 0.0
                let mutable totalWeight = 0.0
                for j = 0 to obvs - 1 do
                    let w = weight.[j]
                    totalWeight <- totalWeight + w
                    total <- total + x.[i * obvs + j] * w
                total / totalWeight
            )
            Check.close VeryHigh expected mean
        }

        test "corr_double" {
            let! x = Gen.Double.[0.0,100.0].Array.[1,100]
            let! y = Gen.Double.[0.0,100.0].Array.[1,100]
            let! lz = Gen.Int.[1,min x.Length y.Length]
            let z = Array.zeroCreate lz
            let mutable task = Unchecked.defaultof<VsldCorrTask>
            Vsl.CorrNewTask1D(&task, VslMode.DIRECT, x.Length, y.Length, lz) |> Check.equal 0
            Vsl.CorrSetStart(task, [|0|]) |> Check.equal 0
            Vsl.CorrExec1D(task, x, 1, y, 1, z, 1) |> Check.equal 0
            Array.sum z |> Check.greaterThan 0.0
        }

        test "corr_single" {
            let! x = Gen.Single.[0.0f,100.0f].Array.[1,100]
            let! y = Gen.Single.[0.0f,100.0f].Array.[1,100]
            let! lz = Gen.Int.[1,min x.Length y.Length]
            let z = Array.zeroCreate lz
            let mutable task = Unchecked.defaultof<VslsCorrTask>
            Vsl.CorrNewTask1D(&task, VslMode.DIRECT, x.Length, y.Length, lz) |> Check.equal 0
            Vsl.CorrSetStart(task, [|0|]) |> Check.equal 0
            Vsl.CorrExec1D(task, x, 1, y, 1, z, 1) |> Check.equal 0
            Array.sum z |> Check.greaterThan 0.0f
        }

        test "conv_single" {
            let! x = Gen.Single.[0.0f,100.0f].Array.[1,100]
            let! y = Gen.Single.[0.0f,100.0f].Array.[1,100]
            let! lz = Gen.Int.[1,min x.Length y.Length]
            let z = Array.zeroCreate lz
            let mutable task = Unchecked.defaultof<VslsConvTask>
            Vsl.ConvNewTask1D(&task, VslMode.DIRECT, x.Length, y.Length, lz) |> Check.equal 0
            Vsl.ConvSetStart(task, [|0|]) |> Check.equal 0
            Vsl.ConvExec1D(task, x, 1, y, 1, z, 1) |> Check.equal 0
            Array.sum z |> Check.greaterThan 0.0f
        }
    }