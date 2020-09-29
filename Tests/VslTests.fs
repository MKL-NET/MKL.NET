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
                Check.Hash(hash, (fun h -> h.AddSF(r,8)), name)
            }

        let rng s r = Vsl.RngGaussian(VslMethodGaussian.ICDF, s, Array.length r, r, 0.0, 1.0)
        let rngRegTest brng seed expected = rngRegressionTest "gaussian" rng brng seed expected
        rngRegTest VslBrng.MCG31         1009u 2325608533013385789L
        rngRegTest VslBrng.R250          1019u 1308213821115550773L
        rngRegTest VslBrng.MRG32K3A      1029u 20839649574655504L
        rngRegTest VslBrng.MCG59         1039u 2280690433890457517L
        rngRegTest VslBrng.WH            1049u 3199050185652827242L
        rngRegTest VslBrng.SOBOL         1059u 733982610324499391L
        rngRegTest VslBrng.NIEDERR       1069u 733982610324499391L
        rngRegTest VslBrng.MT19937       1079u 606343009279169856L
        rngRegTest VslBrng.MT2203        1089u 4038124246613207867L
        rngRegTest VslBrng.SFMT19937     1099u 3667592239992959976L
        rngRegTest VslBrng.ARS5          1109u 3840361580042748657L
        rngRegTest VslBrng.PHILOX4X32X10 1119u 3833227396692966900L

        let rng s r = Vsl.RngBeta(VslMethodBeta.CJA, s, Array.length r, r, 2.0, 5.0, 0.0, 1.0)
        let rngRegTest brng seed expected = rngRegressionTest "beta" rng brng seed expected
        rngRegTest VslBrng.MCG31         2009u 668123831151367569L
        rngRegTest VslBrng.R250          2019u 2694267132659165550L
        rngRegTest VslBrng.MRG32K3A      2029u 4030862350079524329L
        rngRegTest VslBrng.MCG59         2039u 2458365341119490795L
        rngRegTest VslBrng.WH            2049u 2449240157068043923L
        rngRegTest VslBrng.SOBOL         2059u 3982238621122909824L
        rngRegTest VslBrng.NIEDERR       2069u 3982238621122909824L
        rngRegTest VslBrng.MT19937       2079u 50877399811606908L
        rngRegTest VslBrng.MT2203        2089u 1443036476763881945L
        rngRegTest VslBrng.SFMT19937     2099u 3475646355979763546L
        rngRegTest VslBrng.ARS5          2109u 1605806262128146715L
        rngRegTest VslBrng.PHILOX4X32X10 2119u 2543094676414249274L

        //let rng s r = Vsl.RngCauchy(VslMethodCauchy.ICDF, s, Array.length r, r, 0.0, 1.0)
        //let rngRegTest brng seed expected = rngRegressionTest "cauchy" rng brng seed expected
        //rngRegTest VslBrng.MCG31         3009u 1487154284
        //rngRegTest VslBrng.R250          3019u 1093008071
        //rngRegTest VslBrng.MRG32K3A      3029u 1832786184
        //rngRegTest VslBrng.MCG59         3039u 1979245813
        //rngRegTest VslBrng.WH            3049u 330003878
        //rngRegTest VslBrng.SOBOL         3059u 740692057
        //rngRegTest VslBrng.NIEDERR       3069u 740692057
        //rngRegTest VslBrng.MT19937       3079u 1857274234
        //rngRegTest VslBrng.MT2203        3089u -853301411
        //rngRegTest VslBrng.SFMT19937     3099u 1279953302
        //rngRegTest VslBrng.ARS5          3109u 588225730
        //rngRegTest VslBrng.PHILOX4X32X10 3119u 1201934039

        //let rng s (r:double[]) = Vsl.RngChiSquare(VslMethodChiSquare.CHI2GAMMA, s, Array.length r, r, 5)
        //let rngRegTest brng seed expected = rngRegressionTest "chisquare" rng brng seed expected
        //rngRegTest VslBrng.MCG31         1009u -477742185
        //rngRegTest VslBrng.R250          1019u 34019462
        //rngRegTest VslBrng.MRG32K3A      1029u 531787785
        //rngRegTest VslBrng.MCG59         1039u 305228422
        //rngRegTest VslBrng.WH            1049u -910026792
        //rngRegTest VslBrng.SOBOL         1059u 397983813
        //rngRegTest VslBrng.NIEDERR       1069u 397983813
        //rngRegTest VslBrng.MT19937       1079u -10815693
        //rngRegTest VslBrng.MT2203        1089u 322220006
        //rngRegTest VslBrng.SFMT19937     1099u -541654099
        //rngRegTest VslBrng.ARS5          1109u 1424906080
        //rngRegTest VslBrng.PHILOX4X32X10 1119u -313251387

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