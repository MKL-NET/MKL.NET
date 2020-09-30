module VslTests

open System
open MKLNET
open CsCheck

let rng =
    test "rng" {
        let rngRegressionTest name gen brng seed hash sf =
            let rngName = Enum.GetName(typeof<VslBrng>, brng)
            test rngName {
                let stream = Vsl.NewStream(brng, seed)
                let r = Array.zeroCreate<double> 100
                gen stream r |> Check.equal 0
                Vsl.DeleteStream stream |> Check.equal 0
                Array.sumBy abs r |> Check.notDefaultValue
                Check.Hash(hash, (fun h -> h.AddSF(r,sf)), name + "_" + rngName)
            }

        test "guassian" {
            let rng s r = Vsl.RngGaussian(VslMethodGaussian.ICDF, s, Array.length r, r, 0.0, 1.0)
            let rngRegTest brng seed expected = rngRegressionTest "gaussian" rng brng seed expected 9
            rngRegTest VslBrng.MCG31         01009u 1911341158842335953L
            rngRegTest VslBrng.R250          01019u 3994273478527443358L
            rngRegTest VslBrng.MRG32K3A      01029u 1389230277140062278L
            rngRegTest VslBrng.MCG59         01039u 3422457414081294826L
            rngRegTest VslBrng.WH            01049u 2338065572581055589L
            rngRegTest VslBrng.SOBOL         01059u 826570339289502849L
            rngRegTest VslBrng.NIEDERR       01069u 826570339289502849L
            rngRegTest VslBrng.MT19937       01079u 555686340622176877L
            rngRegTest VslBrng.MT2203        01089u 3913245892126679893L
            rngRegTest VslBrng.SFMT19937     01099u 3237366725275470658L
            rngRegTest VslBrng.ARS5          01109u 4145482568469106148L
            rngRegTest VslBrng.PHILOX4X32X10 01119u 3249662980239763615L
        }

        test "beta" {
            let rng s r = Vsl.RngBeta(VslMethodBeta.CJA_ACCURATE, s, Array.length r, r, 2.0, 5.0, 0.0, 1.0)
            let rngRegTest brng seed expected = rngRegressionTest "beta" rng brng seed expected 6
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
            let rngRegTest brng seed expected = rngRegressionTest "cauchy" rng brng seed expected 9
            rngRegTest VslBrng.MCG31         03009u 1536844418116649342L
            rngRegTest VslBrng.R250          03019u 4065022148595115832L
            rngRegTest VslBrng.MRG32K3A      03029u 3698962693303893356L
            rngRegTest VslBrng.MCG59         03039u 1635257988573670616L
            rngRegTest VslBrng.WH            03049u 1635220870895470791L
            rngRegTest VslBrng.SOBOL         03059u 2106758661961020882L
            rngRegTest VslBrng.NIEDERR       03069u 2106758661961020882L
            rngRegTest VslBrng.MT19937       03079u 3259938627951040523L
            rngRegTest VslBrng.MT2203        03089u 1715371140188491192L
            rngRegTest VslBrng.SFMT19937     03099u 924252037723481492L
            rngRegTest VslBrng.ARS5          03109u 1147133188844564931L
            rngRegTest VslBrng.PHILOX4X32X10 03119u 2705016579988597742L
        }

        test "chisquared" {
            let rng s (r:double[]) = Vsl.RngChiSquare(VslMethodChiSquare.CHI2GAMMA, s, Array.length r, r, 5)
            let rngRegTest brng seed expected = rngRegressionTest "chisquare" rng brng seed expected 7
            rngRegTest VslBrng.MCG31         04009u 539315333656350459L
            rngRegTest VslBrng.R250          04019u 3910824024035377653L
            rngRegTest VslBrng.MRG32K3A      04029u 1979757107746254397L
            rngRegTest VslBrng.MCG59         04039u 1420266228006331801L
            rngRegTest VslBrng.WH            04049u 3176992245813076140L
            rngRegTest VslBrng.SOBOL         04059u 4179879441891706643L
            rngRegTest VslBrng.NIEDERR       04069u 4179879441891706643L
            rngRegTest VslBrng.MT19937       04079u 3301548718608294463L
            rngRegTest VslBrng.MT2203        04089u 440050440959787474L
            rngRegTest VslBrng.SFMT19937     04099u 2978881773883934621L
            rngRegTest VslBrng.ARS5          04109u 410251824618030670L
            rngRegTest VslBrng.PHILOX4X32X10 04119u 3431598467032944564L
        }

        test "exponential" {
            let rng s r = Vsl.RngExponential(VslMethodExponential.ICDF_ACCURATE, s, Array.length r, r, 0.0, 1.0)
            let rngRegTest brng seed expected = rngRegressionTest "exponential" rng brng seed expected 8
            rngRegTest VslBrng.MCG31         05009u 1876598643949321447L
            rngRegTest VslBrng.R250          05019u 1894422350314349580L
            rngRegTest VslBrng.MRG32K3A      05029u 1479752114899118224L
            rngRegTest VslBrng.MCG59         05039u 631443879865912194L
            rngRegTest VslBrng.WH            05049u 2318174422560204349L
            rngRegTest VslBrng.SOBOL         05059u 3087081434810331030L
            rngRegTest VslBrng.NIEDERR       05069u 3087081434810331030L
            rngRegTest VslBrng.MT19937       05079u 3194929317136721909L
            rngRegTest VslBrng.MT2203        05089u 2096046522499382704L
            rngRegTest VslBrng.SFMT19937     05099u 2288554758557509203L
            rngRegTest VslBrng.ARS5          05109u 2769435967479740447L
            rngRegTest VslBrng.PHILOX4X32X10 05119u 1995066677713208341L
        }

        test "gamma" {
            let rng s r = Vsl.RngGamma(VslMethodGamma.ICDF_ACCURATE, s, Array.length r, r, 1.0, 0.0, 0.5)
            let rngRegTest brng seed expected = rngRegressionTest "gamma" rng brng seed expected 8
            rngRegTest VslBrng.MCG31         06009u 2859135049090748018L
            rngRegTest VslBrng.R250          06019u 474555932477048858L
            rngRegTest VslBrng.MRG32K3A      06029u 224000773314261916L
            rngRegTest VslBrng.MCG59         06039u 3446748771051426139L
            rngRegTest VslBrng.WH            06049u 605715142852804885L
            rngRegTest VslBrng.SOBOL         06059u 2407146445314349325L
            rngRegTest VslBrng.NIEDERR       06069u 2407146445314349325L
            rngRegTest VslBrng.MT19937       06079u 3538467527685586063L
            rngRegTest VslBrng.MT2203        06089u 3745052661837799177L
            rngRegTest VslBrng.SFMT19937     06099u 4137519475759470931L
            rngRegTest VslBrng.ARS5          06109u 85413052889569948L
            rngRegTest VslBrng.PHILOX4X32X10 06119u 1885824021754026975L
        }

        test "gumbel" {
            let rng s r = Vsl.RngGumbel(VslMethodGumbel.ICDF, s, Array.length r, r, 0.5, 2.0)
            let rngRegTest brng seed expected = rngRegressionTest "gumbel" rng brng seed expected 7
            rngRegTest VslBrng.MCG31         07009u 1981526122685294638L
            rngRegTest VslBrng.R250          07019u 1039427499869899686L
            rngRegTest VslBrng.MRG32K3A      07029u 3488174692686588112L
            rngRegTest VslBrng.MCG59         07039u 403323637025427661L
            rngRegTest VslBrng.WH            07049u 552177712692017448L
            rngRegTest VslBrng.SOBOL         07059u 1643598727617077209L
            rngRegTest VslBrng.NIEDERR       07069u 1643598727617077209L
            rngRegTest VslBrng.MT19937       07079u 3061424955007639703L
            rngRegTest VslBrng.MT2203        07089u 3788665415560028636L
            rngRegTest VslBrng.SFMT19937     07099u 2714411536626500691L
            rngRegTest VslBrng.ARS5          07109u 1000784033763477586L
            rngRegTest VslBrng.PHILOX4X32X10 07119u 1623895670103995484L
        }

        test "laplace" {
            let rng s r = Vsl.RngLaplace(VslMethodLaplace.ICDF, s, Array.length r, r, 0.0, 1.0)
            let rngRegTest brng seed expected = rngRegressionTest "laplace" rng brng seed expected 8
            rngRegTest VslBrng.MCG31         08009u 736039180367304089L
            rngRegTest VslBrng.R250          08019u 3367807453832093274L
            rngRegTest VslBrng.MRG32K3A      08029u 3242438069610152568L
            rngRegTest VslBrng.MCG59         08039u 2233674693929720290L
            rngRegTest VslBrng.WH            08049u 3622441923082997518L
            rngRegTest VslBrng.SOBOL         08059u 1006596217566525055L
            rngRegTest VslBrng.NIEDERR       08069u 1006596217566525055L
            rngRegTest VslBrng.MT19937       08079u 1134470357172108975L
            rngRegTest VslBrng.MT2203        08089u 3285912954342392830L
            rngRegTest VslBrng.SFMT19937     08099u 1396591813804186912L
            rngRegTest VslBrng.ARS5          08109u 3944655448020334099L
            rngRegTest VslBrng.PHILOX4X32X10 08119u 936691349820514362L
        }

        test "lognormal" {
            let rng s r = Vsl.RngLognormal(VslMethodLognormal.ICDF_ACCURATE, s, Array.length r, r, 0.0, 1.0, 0.0, 1.0)
            let rngRegTest brng seed expected = rngRegressionTest "lognormal" rng brng seed expected 6
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
            let rngRegTest brng seed expected = rngRegressionTest "rayleigh" rng brng seed expected 7
            rngRegTest VslBrng.MCG31         10009u 3125232699675808217L
            rngRegTest VslBrng.R250          10019u 3562635161432642439L
            rngRegTest VslBrng.MRG32K3A      10029u 1100014260048813088L
            rngRegTest VslBrng.MCG59         10039u 647675130294056401L
            rngRegTest VslBrng.WH            10049u 1252714401755077944L
            rngRegTest VslBrng.SOBOL         10059u 2299849621052343710L
            rngRegTest VslBrng.NIEDERR       10069u 2299849621052343710L
            rngRegTest VslBrng.MT19937       10079u 3943050705370672847L
            rngRegTest VslBrng.MT2203        10089u 521902156421199848L
            rngRegTest VslBrng.SFMT19937     10099u 2414414856309441964L
            rngRegTest VslBrng.ARS5          10109u 437615861254840285L
            rngRegTest VslBrng.PHILOX4X32X10 10119u 4015965762128648493L
        }

        test "uniform" {
            let rng s r = Vsl.RngUniform(VslMethodUniform.STD_ACCURATE, s, Array.length r, r, 1.0, 2.0)
            let rngRegTest brng seed expected = rngRegressionTest "uniform" rng brng seed expected 9
            rngRegTest VslBrng.MCG31         11009u 4090925605172589169L
            rngRegTest VslBrng.R250          11019u 554882053856108635L
            rngRegTest VslBrng.MRG32K3A      11029u 1829241347878041450L
            rngRegTest VslBrng.MCG59         11039u 177049864097891675L
            rngRegTest VslBrng.WH            11049u 1191874181362486529L
            rngRegTest VslBrng.SOBOL         11059u 2147483648179681715L
            rngRegTest VslBrng.NIEDERR       11069u 2147483648179681715L
            rngRegTest VslBrng.MT19937       11079u 3360788739640435814L
            rngRegTest VslBrng.MT2203        11089u 3630805894947458479L
            rngRegTest VslBrng.SFMT19937     11099u 4201146246093554038L
            rngRegTest VslBrng.ARS5          11109u 309307524893232031L
            rngRegTest VslBrng.PHILOX4X32X10 11119u 2720740487792199442L
        }

        test "weibull" {
            let rng s r = Vsl.RngWeibull(VslMethodWeibull.ICDF_ACCURATE, s, Array.length r, r, 5.0, 0.0, 1.0)
            let rngRegTest brng seed expected = rngRegressionTest "weibull" rng brng seed expected 6
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