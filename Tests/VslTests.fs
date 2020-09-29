module VslTests

open System
open MKLNET
open CsCheck

let rng =
    test "rng" {
        let rngRegressionTest name gen brng seed hash =
            let rngName = Enum.GetName(typeof<VslBrng>, brng)
            test rngName {
                let stream = Vsl.NewStream(brng, seed)
                let r = Array.zeroCreate<double> 100
                gen stream r |> Check.equal 0
                Vsl.DeleteStream stream |> Check.equal 0
                Array.sumBy abs r |> Check.notDefaultValue
                Check.Hash(hash, (fun h -> h.AddSF(r,6)), name + "_" + rngName)
            }

        test "guassian" {
            let rng s r = Vsl.RngGaussian(VslMethodGaussian.ICDF, s, Array.length r, r, 0.0, 1.0)
            let rngRegTest brng seed expected = rngRegressionTest "gaussian" rng brng seed expected
            rngRegTest VslBrng.MCG31         01009u 3363136412936974698L
            rngRegTest VslBrng.R250          01019u 483467208952316763L
            rngRegTest VslBrng.MRG32K3A      01029u 3880012137407158688L
            rngRegTest VslBrng.MCG59         01039u 1276390173367644893L
            rngRegTest VslBrng.WH            01049u 2864157389607528761L
            rngRegTest VslBrng.SOBOL         01059u 913519797090351680L
            rngRegTest VslBrng.NIEDERR       01069u 913519797090351680L
            rngRegTest VslBrng.MT19937       01079u 389138710951945826L
            rngRegTest VslBrng.MT2203        01089u 381462857834239212L
            rngRegTest VslBrng.SFMT19937     01099u 3998455859954030143L
            rngRegTest VslBrng.ARS5          01109u 902664128560390946L
            rngRegTest VslBrng.PHILOX4X32X10 01119u 1007062462772002442L
        }

        test "beta" {
            let rng s r = Vsl.RngBeta(VslMethodBeta.CJA_ACCURATE, s, Array.length r, r, 2.0, 5.0, 0.0, 1.0)
            let rngRegTest brng seed expected = rngRegressionTest "beta" rng brng seed expected
            rngRegTest VslBrng.MCG31         02009u 3007063038128847251L
            rngRegTest VslBrng.R250          02019u 3374066972319628839L
            rngRegTest VslBrng.MRG32K3A      02029u 583529081042380527L
            rngRegTest VslBrng.MCG59         02039u 3144430971418710325L
            rngRegTest VslBrng.WH            02049u 2256846998793774208L
            rngRegTest VslBrng.SOBOL         02059u 1748779858862532953L
            rngRegTest VslBrng.NIEDERR       02069u 1748779858862532953L
            rngRegTest VslBrng.MT19937       02079u 3507473686075455500L
            rngRegTest VslBrng.MT2203        02089u 2384599116436423822L
            rngRegTest VslBrng.SFMT19937     02099u 4252245473101236979L
            rngRegTest VslBrng.ARS5          02109u 737431650934642902L
            rngRegTest VslBrng.PHILOX4X32X10 02119u 3760308599493149230L
        }

        test "cauchy" {
            let rng s r = Vsl.RngCauchy(VslMethodCauchy.ICDF, s, Array.length r, r, 0.0, 1.0)
            let rngRegTest brng seed expected = rngRegressionTest "cauchy" rng brng seed expected
            rngRegTest VslBrng.MCG31         03009u 2554372213837656950L
            rngRegTest VslBrng.R250          03019u 605032273881860902L
            rngRegTest VslBrng.MRG32K3A      03029u 3199080429053811877L
            rngRegTest VslBrng.MCG59         03039u 983679901418487041L
            rngRegTest VslBrng.WH            03049u 2368885861067961391L
            rngRegTest VslBrng.SOBOL         03059u 462579700310600779L
            rngRegTest VslBrng.NIEDERR       03069u 462579700310600779L
            rngRegTest VslBrng.MT19937       03079u 218873978465295057L
            rngRegTest VslBrng.MT2203        03089u 1027738328642721635L
            rngRegTest VslBrng.SFMT19937     03099u 559936188835746029L
            rngRegTest VslBrng.ARS5          03109u 3117495654345613975L
            rngRegTest VslBrng.PHILOX4X32X10 03119u 1011914356974091933L
        }

        test "chisquared" {
            let rng s (r:double[]) = Vsl.RngChiSquare(VslMethodChiSquare.CHI2GAMMA, s, Array.length r, r, 5)
            let rngRegTest brng seed expected = rngRegressionTest "chisquare" rng brng seed expected
            rngRegTest VslBrng.MCG31         04009u 3013428300987316150L
            rngRegTest VslBrng.R250          04019u 3049171035733612682L
            rngRegTest VslBrng.MRG32K3A      04029u 3250615175508194000L
            rngRegTest VslBrng.MCG59         04039u 330405616378413966L
            rngRegTest VslBrng.WH            04049u 3665759929813133342L
            rngRegTest VslBrng.SOBOL         04059u 2972904373591817001L
            rngRegTest VslBrng.NIEDERR       04069u 2972904373591817001L
            rngRegTest VslBrng.MT19937       04079u 58059448151894752L
            rngRegTest VslBrng.MT2203        04089u 3883114048211896142L
            rngRegTest VslBrng.SFMT19937     04099u 2364233384765564780L
            rngRegTest VslBrng.ARS5          04109u 899812096393549599L
            rngRegTest VslBrng.PHILOX4X32X10 04119u 1671627428179700175L
        }

        test "exponential" {
            let rng s r = Vsl.RngExponential(VslMethodExponential.ICDF_ACCURATE, s, Array.length r, r, 0.0, 1.0)
            let rngRegTest brng seed expected = rngRegressionTest "exponential" rng brng seed expected
            rngRegTest VslBrng.MCG31         05009u 3261385093996348613L
            rngRegTest VslBrng.R250          05019u 3436253156799410631L
            rngRegTest VslBrng.MRG32K3A      05029u 3405657987443383710L
            rngRegTest VslBrng.MCG59         05039u 1400168581003877311L
            rngRegTest VslBrng.WH            05049u 2699859788165464138L
            rngRegTest VslBrng.SOBOL         05059u 233432783296214338L
            rngRegTest VslBrng.NIEDERR       05069u 233432783296214338L
            rngRegTest VslBrng.MT19937       05079u 3937998186082149097L
            rngRegTest VslBrng.MT2203        05089u 2924778465710312898L
            rngRegTest VslBrng.SFMT19937     05099u 3070607586425730182L
            rngRegTest VslBrng.ARS5          05109u 1053199769922906029L
            rngRegTest VslBrng.PHILOX4X32X10 05119u 1581063928291000028L
        }

        test "gamma" {
            let rng s r = Vsl.RngGamma(VslMethodGamma.ICDF_ACCURATE, s, Array.length r, r, 1.0, 0.0, 0.5)
            let rngRegTest brng seed expected = rngRegressionTest "gamma" rng brng seed expected
            rngRegTest VslBrng.MCG31         06009u 3221525151326641826L
            rngRegTest VslBrng.R250          06019u 343399800394395439L
            rngRegTest VslBrng.MRG32K3A      06029u 1286969307799861790L
            rngRegTest VslBrng.MCG59         06039u 3631106508509849642L
            rngRegTest VslBrng.WH            06049u 3585728331391662728L
            rngRegTest VslBrng.SOBOL         06059u 1872404584182394487L
            rngRegTest VslBrng.NIEDERR       06069u 1872404584182394487L
            rngRegTest VslBrng.MT19937       06079u 1303128071495044873L
            rngRegTest VslBrng.MT2203        06089u 3060060161638742674L
            rngRegTest VslBrng.SFMT19937     06099u 2306122516516863296L
            rngRegTest VslBrng.ARS5          06109u 4281826517942208154L
            rngRegTest VslBrng.PHILOX4X32X10 06119u 474843401138002659L
        }

        test "gumbel" {
            let rng s r = Vsl.RngGumbel(VslMethodGumbel.ICDF, s, Array.length r, r, 0.5, 2.0)
            let rngRegTest brng seed expected = rngRegressionTest "gumbel" rng brng seed expected
            rngRegTest VslBrng.MCG31         07009u 3300544060627090267L
            rngRegTest VslBrng.R250          07019u 4114064451697481658L
            rngRegTest VslBrng.MRG32K3A      07029u 1177729866325512386L
            rngRegTest VslBrng.MCG59         07039u 3706039768270341890L
            rngRegTest VslBrng.WH            07049u 2257971336688863443L
            rngRegTest VslBrng.SOBOL         07059u 3513286207145613069L
            rngRegTest VslBrng.NIEDERR       07069u 3513286207145613069L
            rngRegTest VslBrng.MT19937       07079u 2582637860176808793L
            rngRegTest VslBrng.MT2203        07089u 4246392918120398555L
            rngRegTest VslBrng.SFMT19937     07099u 3939743512012141312L
            rngRegTest VslBrng.ARS5          07109u 2753394047754074098L
            rngRegTest VslBrng.PHILOX4X32X10 07119u 1304002842379000905L
        }

        test "laplace" {
            let rng s r = Vsl.RngLaplace(VslMethodLaplace.ICDF, s, Array.length r, r, 0.0, 1.0)
            let rngRegTest brng seed expected = rngRegressionTest "laplace" rng brng seed expected
            rngRegTest VslBrng.MCG31         08009u 127748501191170537L
            rngRegTest VslBrng.R250          08019u 436650264522189027L
            rngRegTest VslBrng.MRG32K3A      08029u 1526954499164287748L
            rngRegTest VslBrng.MCG59         08039u 4214423277934514873L
            rngRegTest VslBrng.WH            08049u 3696695690838000233L
            rngRegTest VslBrng.SOBOL         08059u 1050981607047449263L
            rngRegTest VslBrng.NIEDERR       08069u 1050981607047449263L
            rngRegTest VslBrng.MT19937       08079u 766678133025143641L
            rngRegTest VslBrng.MT2203        08089u 3678915850979584093L
            rngRegTest VslBrng.SFMT19937     08099u 657751388014926858L
            rngRegTest VslBrng.ARS5          08109u 3665386738318567755L
            rngRegTest VslBrng.PHILOX4X32X10 08119u 4072809202657423803L
        }

        test "lognormal" {
            let rng s r = Vsl.RngLognormal(VslMethodLognormal.ICDF_ACCURATE, s, Array.length r, r, 0.0, 1.0, 0.0, 1.0)
            let rngRegTest brng seed expected = rngRegressionTest "lognormal" rng brng seed expected
            rngRegTest VslBrng.MCG31         09009u 1669334537677192586L
            rngRegTest VslBrng.R250          09019u 539977220852619346L
            rngRegTest VslBrng.MRG32K3A      09029u 2889550609694062035L
            rngRegTest VslBrng.MCG59         09039u 901955343147341430L
            rngRegTest VslBrng.WH            09049u 4154655793453721144L
            rngRegTest VslBrng.SOBOL         09059u 921064004050560148L
            rngRegTest VslBrng.NIEDERR       09069u 921064004050560148L
            rngRegTest VslBrng.MT19937       09079u 1494212883049119338L
            rngRegTest VslBrng.MT2203        09089u 3660936971908707139L
            rngRegTest VslBrng.SFMT19937     09099u 715882456263113034L
            rngRegTest VslBrng.ARS5          09109u 3179611504649199062L
            rngRegTest VslBrng.PHILOX4X32X10 09119u 232250651324441870L
        }

        test "rayleigh" {
            let rng s r = Vsl.RngRayleigh(VslMethodRayleigh.ICDF_ACCURATE, s, Array.length r, r, 0.0, 1.0)
            let rngRegTest brng seed expected = rngRegressionTest "rayleigh" rng brng seed expected
            rngRegTest VslBrng.MCG31         10009u 248151335908087344L
            rngRegTest VslBrng.R250          10019u 4096261162901598699L
            rngRegTest VslBrng.MRG32K3A      10029u 2208189781176820066L
            rngRegTest VslBrng.MCG59         10039u 1545249829637417102L
            rngRegTest VslBrng.WH            10049u 2584857348570083994L
            rngRegTest VslBrng.SOBOL         10059u 3727992917007792022L
            rngRegTest VslBrng.NIEDERR       10069u 3727992917007792022L
            rngRegTest VslBrng.MT19937       10079u 1722507413135612583L
            rngRegTest VslBrng.MT2203        10089u 2556412943616885499L
            rngRegTest VslBrng.SFMT19937     10099u 1827556356311453483L
            rngRegTest VslBrng.ARS5          10109u 4272098222522881481L
            rngRegTest VslBrng.PHILOX4X32X10 10119u 2538632074952912975L
        }

        test "uniform" {
            let rng s r = Vsl.RngUniform(VslMethodUniform.STD_ACCURATE, s, Array.length r, r, 1.0, 2.0)
            let rngRegTest brng seed expected = rngRegressionTest "uniform" rng brng seed expected
            rngRegTest VslBrng.MCG31         11009u 2531303813583796990L
            rngRegTest VslBrng.R250          11019u 4246682371978450839L
            rngRegTest VslBrng.MRG32K3A      11029u 1891616263748256638L
            rngRegTest VslBrng.MCG59         11039u 2829083621853501269L
            rngRegTest VslBrng.WH            11049u 2440399153861225896L
            rngRegTest VslBrng.SOBOL         11059u 536870913998004659L
            rngRegTest VslBrng.NIEDERR       11069u 536870913998004659L
            rngRegTest VslBrng.MT19937       11079u 958384326897628158L
            rngRegTest VslBrng.MT2203        11089u 2247511991039200712L
            rngRegTest VslBrng.SFMT19937     11099u 1612917012790411576L
            rngRegTest VslBrng.ARS5          11109u 870447570130511209L
            rngRegTest VslBrng.PHILOX4X32X10 11119u 4220763061341488726L
        }

        test "weibull" {
            let rng s r = Vsl.RngWeibull(VslMethodWeibull.ICDF_ACCURATE, s, Array.length r, r, 5.0, 0.0, 1.0)
            let rngRegTest brng seed expected = rngRegressionTest "weibull" rng brng seed expected
            rngRegTest VslBrng.MCG31         12009u 1909196161986762957L
            rngRegTest VslBrng.R250          12019u 1929192170498483979L
            rngRegTest VslBrng.MRG32K3A      12029u 4226497204719176751L
            rngRegTest VslBrng.MCG59         12039u 3860001738512494955L
            rngRegTest VslBrng.WH            12049u 1804190258271942196L
            rngRegTest VslBrng.SOBOL         12059u 2071273229479253645L
            rngRegTest VslBrng.NIEDERR       12069u 2071273229479253645L
            rngRegTest VslBrng.MT19937       12079u 2390190648383988119L
            rngRegTest VslBrng.MT2203        12089u 3508863914976693645L
            rngRegTest VslBrng.SFMT19937     12099u 4273896375288095006L
            rngRegTest VslBrng.ARS5          12109u 349769761845940744L
            rngRegTest VslBrng.PHILOX4X32X10 12119u 4223214046999312888L
        }
    }

let stats =
    test "SS" {
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
    }

let conv_corr =
    test "conv_corr" {

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

let all =
    test "Vsl" {
        rng
        stats
        conv_corr
    }