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
                Check.Hash(hash, (fun h -> h.AddSF(r,6)), name)
            }

        let rng s r = Vsl.RngGaussian(VslMethodGaussian.ICDF, s, Array.length r, r, 0.0, 1.0)
        let rngRegTest brng seed expected = rngRegressionTest "gaussian" rng brng seed expected
        rngRegTest VslBrng.MCG31         1009u 3363136412936974698L
        rngRegTest VslBrng.R250          1019u 483467208952316763L
        rngRegTest VslBrng.MRG32K3A      1029u 3880012137407158688L
        rngRegTest VslBrng.MCG59         1039u 1276390173367644893L
        rngRegTest VslBrng.WH            1049u 2864157389607528761L
        rngRegTest VslBrng.SOBOL         1059u 913519797090351680L
        rngRegTest VslBrng.NIEDERR       1069u 913519797090351680L
        rngRegTest VslBrng.MT19937       1079u 389138710951945826L
        rngRegTest VslBrng.MT2203        1089u 381462857834239212L
        rngRegTest VslBrng.SFMT19937     1099u 3998455859954030143L
        rngRegTest VslBrng.ARS5          1109u 902664128560390946L
        rngRegTest VslBrng.PHILOX4X32X10 1119u 1007062462772002442L

        let rng s r = Vsl.RngBeta(VslMethodBeta.CJA, s, Array.length r, r, 2.0, 5.0, 0.0, 1.0)
        let rngRegTest brng seed expected = rngRegressionTest "beta" rng brng seed expected
        rngRegTest VslBrng.MCG31         2009u 3007063038128847251L
        rngRegTest VslBrng.R250          2019u 3374066972319628839L
        rngRegTest VslBrng.MRG32K3A      2029u 583529081042380527L
        rngRegTest VslBrng.MCG59         2039u 3144430971418710325L
        rngRegTest VslBrng.WH            2049u 2256846998793774208L
        rngRegTest VslBrng.SOBOL         2059u 1748779858862532953L
        rngRegTest VslBrng.NIEDERR       2069u 1748779858862532953L
        rngRegTest VslBrng.MT19937       2079u 3507473686075455500L
        rngRegTest VslBrng.MT2203        2089u 2384599116436423822L
        rngRegTest VslBrng.SFMT19937     2099u 4252245473101236979L
        rngRegTest VslBrng.ARS5          2109u 737431650934642902L
        rngRegTest VslBrng.PHILOX4X32X10 2119u 3760308599493149230L

        let rng s r = Vsl.RngCauchy(VslMethodCauchy.ICDF, s, Array.length r, r, 0.0, 1.0)
        let rngRegTest brng seed expected = rngRegressionTest "cauchy" rng brng seed expected
        rngRegTest VslBrng.MCG31         3009u 2554372213837656950L
        rngRegTest VslBrng.R250          3019u 605032273881860902L
        rngRegTest VslBrng.MRG32K3A      3029u 3199080429053811877L
        rngRegTest VslBrng.MCG59         3039u 983679901418487041L
        rngRegTest VslBrng.WH            3049u 2368885861067961391L
        rngRegTest VslBrng.SOBOL         3059u 462579700310600779L
        rngRegTest VslBrng.NIEDERR       3069u 462579700310600779L
        rngRegTest VslBrng.MT19937       3079u 218873978465295057L
        rngRegTest VslBrng.MT2203        3089u 1027738328642721635L
        rngRegTest VslBrng.SFMT19937     3099u 559936188835746029L
        rngRegTest VslBrng.ARS5          3109u 3117495654345613975L
        rngRegTest VslBrng.PHILOX4X32X10 3119u 1011914356974091933L

        let rng s (r:double[]) = Vsl.RngChiSquare(VslMethodChiSquare.CHI2GAMMA, s, Array.length r, r, 5)
        let rngRegTest brng seed expected = rngRegressionTest "chisquare" rng brng seed expected
        rngRegTest VslBrng.MCG31         4009u 3013428300987316150L
        rngRegTest VslBrng.R250          4019u 3049171035733612682L
        rngRegTest VslBrng.MRG32K3A      4029u 3250615175508194000L
        rngRegTest VslBrng.MCG59         4039u 330405616378413966L
        rngRegTest VslBrng.WH            4049u 3665759929813133342L
        rngRegTest VslBrng.SOBOL         4059u 2972904373591817001L
        rngRegTest VslBrng.NIEDERR       4069u 2972904373591817001L
        rngRegTest VslBrng.MT19937       4079u 58059448151894752L
        rngRegTest VslBrng.MT2203        4089u 3883114048211896142L
        rngRegTest VslBrng.SFMT19937     4099u 2364233384765564780L
        rngRegTest VslBrng.ARS5          4109u 899812096393549599L
        rngRegTest VslBrng.PHILOX4X32X10 4119u 1671627428179700175L

        test "mean_double" {
            let! obvs = Gen.Int.[1,100]
            let! vars = Gen.Int.[1,100]
            let! x = Gen.Double.OneTwo.Array.[obvs*vars]
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
            let! x = Gen.Single.OneTwo.Array.[obvs*vars]
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
            let! x = Gen.Double.OneTwo.Array.[obvs*vars]
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