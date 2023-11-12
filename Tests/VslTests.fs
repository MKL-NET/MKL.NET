﻿module VslTests

open System
open MKLNET
open CsCheck

let rng =
    test "rng" {
        let rngRegressionTest name gen brng seed hash (sf:int) =
            let rngName = Enum.GetName(typeof<VslBrng>, brng)
            test rngName {
                let stream = Vsl.NewStream(brng, seed)
                let r = Array.zeroCreate<double> 100
                gen stream r |> Check.equal 0
                Vsl.DeleteStream stream |> Check.equal 0
                Array.sumBy abs r |> Check.notDefaultValue
                Check.Hash((fun h -> h.Add(r)), hash, significantFigures = sf, memberName = name + "_" + rngName)
            }

        test "guassian" {
            let rng s r = Vsl.RngGaussian(VslMethodGaussian.ICDF, s, Array.length r, r, 0.0, 1.0)
            let rngRegTest brng seed expected = rngRegressionTest "gaussian" rng brng seed expected 9
            rngRegTest VslBrng.MCG31         01009u 6523027177269723857L
            rngRegTest VslBrng.R250          01019u 8605959496954831262L
            rngRegTest VslBrng.MRG32K3A      01029u 6000916299862417478L
            rngRegTest VslBrng.MCG59         01039u 8034143432508682730L
            rngRegTest VslBrng.WH            01049u 6949751591008443493L
            rngRegTest VslBrng.SOBOL         01059u 5438256357716890753L
            rngRegTest VslBrng.NIEDERR       01069u 5438256357716890753L
            rngRegTest VslBrng.MT19937       01079u 5167372359049564781L
            rngRegTest VslBrng.MT2203        01089u 8524931914849035093L
            rngRegTest VslBrng.SFMT19937     01099u 7849052743702858562L
            rngRegTest VslBrng.ARS5          01109u 8757168586896494052L
            rngRegTest VslBrng.PHILOX4X32X10 01119u 7861349002962118815L
        }

        test "beta" {
            let rng s r = Vsl.RngBeta(VslMethodBeta.CJA_ACCURATE, s, Array.length r, r, 2.0, 5.0, 0.0, 1.0)
            let rngRegTest brng seed expected = rngRegressionTest "beta" rng brng seed expected 6
            rngRegTest VslBrng.MCG31         02009u 7618749056556235155L
            rngRegTest VslBrng.R250          02019u 7985752990747016743L
            rngRegTest VslBrng.MRG32K3A      02029u 5195215103764735727L
            rngRegTest VslBrng.MCG59         02039u 7756116994141065525L
            rngRegTest VslBrng.WH            02049u 6868533021516129408L
            rngRegTest VslBrng.SOBOL         02059u 6360465877289920857L
            rngRegTest VslBrng.NIEDERR       02069u 6360465877289920857L
            rngRegTest VslBrng.MT19937       02079u 8119159708797810700L
            rngRegTest VslBrng.MT2203        02089u 6996285139158779022L
            rngRegTest VslBrng.SFMT19937     02099u 8863931491528624883L
            rngRegTest VslBrng.ARS5          02109u 5349117673656998102L
            rngRegTest VslBrng.PHILOX4X32X10 02119u 8371994622215504430L
        }

        test "cauchy" {
            let rng s r = Vsl.RngCauchy(VslMethodCauchy.ICDF, s, Array.length r, r, 0.0, 1.0)
            let rngRegTest brng seed expected = rngRegressionTest "cauchy" rng brng seed expected 9
            rngRegTest VslBrng.MCG31         03009u 6148530440839004542L
            rngRegTest VslBrng.R250          03019u 8676708171317471032L
            rngRegTest VslBrng.MRG32K3A      03029u 8310648711731281260L
            rngRegTest VslBrng.MCG59         03039u 6246944007001058520L
            rngRegTest VslBrng.WH            03049u 6246906893617825991L
            rngRegTest VslBrng.SOBOL         03059u 6718444684683376082L
            rngRegTest VslBrng.NIEDERR       03069u 6718444684683376082L
            rngRegTest VslBrng.MT19937       03079u 7871624650673395723L
            rngRegTest VslBrng.MT2203        03089u 6327057158615879096L
            rngRegTest VslBrng.SFMT19937     03099u 5535938056150869396L
            rngRegTest VslBrng.ARS5          03109u 5758819207271952835L
            rngRegTest VslBrng.PHILOX4X32X10 03119u 7316702602710952942L
        }

        test "chisquared" {
            let rng s (r:double[]) = Vsl.RngChiSquare(VslMethodChiSquare.CHI2GAMMA, s, Array.length r, r, 5)
            let rngRegTest brng seed expected = rngRegressionTest "chisquare" rng brng seed expected 7
            rngRegTest VslBrng.MCG31         04009u 5151001352083738363L
            rngRegTest VslBrng.R250          04019u 8522510042462765557L
            rngRegTest VslBrng.MRG32K3A      04029u 4747345413448497899L
            rngRegTest VslBrng.MCG59         04039u 6031952255023654297L
            rngRegTest VslBrng.WH            04049u 7784115990135968904L
            rngRegTest VslBrng.SOBOL         04059u 8791565460319094547L
            rngRegTest VslBrng.NIEDERR       04069u 8791565460319094547L
            rngRegTest VslBrng.MT19937       04079u 7913234741330649663L
            rngRegTest VslBrng.MT2203        04089u 5051736463682142674L
            rngRegTest VslBrng.SFMT19937     04099u 7590567792311322525L
            rngRegTest VslBrng.ARS5          04109u 5020686254541416581L
            rngRegTest VslBrng.PHILOX4X32X10 04119u 8043284489755299764L
        }

        test "exponential" {
            let rng s r = Vsl.RngExponential(VslMethodExponential.ICDF_ACCURATE, s, Array.length r, r, 0.0, 1.0)
            let rngRegTest brng seed expected = rngRegressionTest "exponential" rng brng seed expected 8
            rngRegTest VslBrng.MCG31         05009u 6488284662376709351L
            rngRegTest VslBrng.R250          05019u 6506108373036704780L
            rngRegTest VslBrng.MRG32K3A      05029u 6091438137621473424L
            rngRegTest VslBrng.MCG59         05039u 5243129898293300098L
            rngRegTest VslBrng.WH            05049u 6929860440987592253L
            rngRegTest VslBrng.SOBOL         05059u 7698767457532686230L
            rngRegTest VslBrng.NIEDERR       05069u 7698767457532686230L
            rngRegTest VslBrng.MT19937       05079u 7806615339859077109L
            rngRegTest VslBrng.MT2203        05089u 6707732540926770608L
            rngRegTest VslBrng.SFMT19937     05099u 6900240781279864403L
            rngRegTest VslBrng.ARS5          05109u 7381121985907128351L
            rngRegTest VslBrng.PHILOX4X32X10 05119u 6606752704730530837L
        }

        test "gamma" {
            let rng s r = Vsl.RngGamma(VslMethodGamma.ICDF_ACCURATE, s, Array.length r, r, 1.0, 0.0, 0.5)
            let rngRegTest brng seed expected = rngRegressionTest "gamma" rng brng seed expected 8
            rngRegTest VslBrng.MCG31         06009u 7470821071813103218L
            rngRegTest VslBrng.R250          06019u 5086241955199404058L
            rngRegTest VslBrng.MRG32K3A      06029u 4835686791741649820L
            rngRegTest VslBrng.MCG59         06039u 8058434789478814043L
            rngRegTest VslBrng.WH            06049u 5217401161280192789L
            rngRegTest VslBrng.SOBOL         06059u 7018832463741737229L
            rngRegTest VslBrng.NIEDERR       06069u 7018832463741737229L
            rngRegTest VslBrng.MT19937       06079u 8150153554702908559L
            rngRegTest VslBrng.MT2203        06089u 8356738684560154377L
            rngRegTest VslBrng.SFMT19937     06099u 8749205494186858835L
            rngRegTest VslBrng.ARS5          06109u 4697099071316957852L
            rngRegTest VslBrng.PHILOX4X32X10 06119u 6497510040181414879L
        }

        test "gumbel" {
            let rng s r = Vsl.RngGumbel(VslMethodGumbel.ICDF, s, Array.length r, r, 0.5, 2.0)
            let rngRegTest brng seed expected = rngRegressionTest "gumbel" rng brng seed expected 7
            rngRegTest VslBrng.MCG31         07009u 6593212141112682542L
            rngRegTest VslBrng.R250          07019u 5651113522592254886L
            rngRegTest VslBrng.MRG32K3A      07029u 8099860719703910608L
            rngRegTest VslBrng.MCG59         07039u 5015009664042750157L
            rngRegTest VslBrng.WH            07049u 5163863731119405352L
            rngRegTest VslBrng.SOBOL         07059u 6255284750339432409L
            rngRegTest VslBrng.NIEDERR       07069u 6255284750339432409L
            rngRegTest VslBrng.MT19937       07079u 7673110982024962199L
            rngRegTest VslBrng.MT2203        07089u 8400351438282383836L
            rngRegTest VslBrng.SFMT19937     07099u 7326097559348855891L
            rngRegTest VslBrng.ARS5          07109u 5612470060780800082L
            rngRegTest VslBrng.PHILOX4X32X10 07119u 6235581688531383388L
        }

        test "laplace" {
            let rng s r = Vsl.RngLaplace(VslMethodLaplace.ICDF, s, Array.length r, r, 0.0, 1.0)
            let rngRegTest brng seed expected = rngRegressionTest "laplace" rng brng seed expected 8
            rngRegTest VslBrng.MCG31         08009u 5347725198794691993L
            rngRegTest VslBrng.R250          08019u 7979493476554448474L
            rngRegTest VslBrng.MRG32K3A      08029u 7854124088037540472L
            rngRegTest VslBrng.MCG59         08039u 6845360720947042786L
            rngRegTest VslBrng.WH            08049u 8234127941510385422L
            rngRegTest VslBrng.SOBOL         08059u 5618282240288880255L
            rngRegTest VslBrng.NIEDERR       08069u 5618282240288880255L
            rngRegTest VslBrng.MT19937       08079u 5746156379894464175L
            rngRegTest VslBrng.MT2203        08089u 7897598972769780734L
            rngRegTest VslBrng.SFMT19937     08099u 6008277832231574816L
            rngRegTest VslBrng.ARS5          08109u 8556341466447722003L
            rngRegTest VslBrng.PHILOX4X32X10 08119u 5548377372542869562L
        }

        test "lognormal" {
            let rng s r = Vsl.RngLognormal(VslMethodLognormal.ICDF_ACCURATE, s, Array.length r, r, 0.0, 1.0, 0.0, 1.0)
            let rngRegTest brng seed expected = rngRegressionTest "lognormal" rng brng seed expected 6
            rngRegTest VslBrng.MCG31         09009u 6281020556104580490L
            rngRegTest VslBrng.R250          09019u 5151663243574974546L
            rngRegTest VslBrng.MRG32K3A      09029u 7501236628121449939L
            rngRegTest VslBrng.MCG59         09039u 5513641365869696630L
            rngRegTest VslBrng.WH            09049u 8766341811881109048L
            rngRegTest VslBrng.SOBOL         09059u 5532750022477948052L
            rngRegTest VslBrng.NIEDERR       09069u 5532750022477948052L
            rngRegTest VslBrng.MT19937       09079u 6105898905771474538L
            rngRegTest VslBrng.MT2203        09089u 8272622994631062339L
            rngRegTest VslBrng.SFMT19937     09099u 5327568478985468234L
            rngRegTest VslBrng.ARS5          09109u 7791297527371554262L
            rngRegTest VslBrng.PHILOX4X32X10 09119u 4843936669751829774L
        }

        test "rayleigh" {
            let rng s r = Vsl.RngRayleigh(VslMethodRayleigh.ICDF_ACCURATE, s, Array.length r, r, 0.0, 1.0)
            let rngRegTest brng seed expected = rngRegressionTest "rayleigh" rng brng seed expected 7
            rngRegTest VslBrng.MCG31         10009u 7736918722398163417L
            rngRegTest VslBrng.R250          10019u 8174321184154997639L
            rngRegTest VslBrng.MRG32K3A      10029u 5711700278476200992L
            rngRegTest VslBrng.MCG59         10039u 5259361153016411601L
            rngRegTest VslBrng.WH            10049u 5864400420182465848L
            rngRegTest VslBrng.SOBOL         10059u 6911535643774698910L
            rngRegTest VslBrng.NIEDERR       10069u 6911535643774698910L
            rngRegTest VslBrng.MT19937       10079u 8554736728093028047L
            rngRegTest VslBrng.MT2203        10089u 5133588179143555048L
            rngRegTest VslBrng.SFMT19937     10099u 7026100879031797164L
            rngRegTest VslBrng.ARS5          10109u 5049301879682228189L
            rngRegTest VslBrng.PHILOX4X32X10 10119u 8627651784851003693L
        }

        test "uniform" {
            let rng s r = Vsl.RngUniform(VslMethodUniform.STD_ACCURATE, s, Array.length r, r, 1.0, 2.0)
            let rngRegTest brng seed expected = rngRegressionTest "uniform" rng brng seed expected 9
            rngRegTest VslBrng.MCG31         11009u 8702611627894944369L
            rngRegTest VslBrng.R250          11019u 5166568076578463835L
            rngRegTest VslBrng.MRG32K3A      11029u 6440927374895363946L
            rngRegTest VslBrng.MCG59         11039u 4788735886820246875L
            rngRegTest VslBrng.WH            11049u 5803560199789874433L
            rngRegTest VslBrng.SOBOL         11059u 6759169666607069619L
            rngRegTest VslBrng.NIEDERR       11069u 6759169666607069619L
            rngRegTest VslBrng.MT19937       11079u 7972474762362791014L
            rngRegTest VslBrng.MT2203        11089u 8242491917669813679L
            rngRegTest VslBrng.SFMT19937     11099u 8812832264520941942L
            rngRegTest VslBrng.ARS5          11109u 4920993543320619935L
            rngRegTest VslBrng.PHILOX4X32X10 11119u 7332426506219587346L
        }

        test "weibull" {
            let rng s r = Vsl.RngWeibull(VslMethodWeibull.ICDF_ACCURATE, s, Array.length r, r, 5.0, 0.0, 1.0)
            let rngRegTest brng seed expected = rngRegressionTest "weibull" rng brng seed expected 9
            rngRegTest VslBrng.MCG31         12009u 5583524006204832070L
            rngRegTest VslBrng.R250          12019u 8641138058614301688L
            rngRegTest VslBrng.MRG32K3A      12029u 6712152334841241950L
            rngRegTest VslBrng.MCG59         12039u 5840337831930009946L
            rngRegTest VslBrng.WH            12049u 5546266575878086438L
            rngRegTest VslBrng.SOBOL         12059u 5370215950063673913L
            rngRegTest VslBrng.NIEDERR       12069u 5370215950063673913L
            rngRegTest VslBrng.MT19937       12079u 8164563533382538754L
            rngRegTest VslBrng.MT2203        12089u 5588215149728585203L
            rngRegTest VslBrng.SFMT19937     12099u 6446622405875987207L
            rngRegTest VslBrng.ARS5          12109u 6530747305188603089L
            rngRegTest VslBrng.PHILOX4X32X10 12119u 7003849293018612861L
        }

        let rngRegressionTest name gen brng seed hash =
            let rngName = Enum.GetName(typeof<VslBrng>, brng)
            test rngName {
                let stream = Vsl.NewStream(brng, seed)
                let r = Array.zeroCreate<int> 100
                gen stream r |> Check.equal 0
                Vsl.DeleteStream stream |> Check.equal 0
                Array.sumBy abs r |> Check.notDefaultValue
                Check.Hash((fun h -> h.Add(r)), hash, memberName = name + "_" + rngName)
            }

        test "binomial" {
            let rng s r = Vsl.RngBinomial(VslMethodBinomial.BTPE, s, Array.length r, r, 100, 0.5)
            let rngRegTest brng seed expected = rngRegressionTest "binomial" rng brng seed expected
            rngRegTest VslBrng.MCG31         13009u 6240522559L
            rngRegTest VslBrng.R250          13019u 7050278465L
            rngRegTest VslBrng.MRG32K3A      13029u 6109948953L
            rngRegTest VslBrng.MCG59         13039u 6841759985L
            rngRegTest VslBrng.WH            13049u 8165182080L
            rngRegTest VslBrng.SOBOL         13059u 5117760223L
            rngRegTest VslBrng.NIEDERR       13069u 5117760223L
            rngRegTest VslBrng.MT19937       13079u 7178684205L
            rngRegTest VslBrng.MT2203        13089u 7677957377L
            rngRegTest VslBrng.SFMT19937     13099u 6061350505L
            rngRegTest VslBrng.ARS5          13109u 6409955936L
            rngRegTest VslBrng.PHILOX4X32X10 13119u 7199238395L
        }

        test "poisson" {
            let rng s r = Vsl.RngPoisson(VslMethodPoisson.POISNORM, s, Array.length r, r, 0.5)
            let rngRegTest brng seed expected = rngRegressionTest "poisson" rng brng seed expected
            rngRegTest VslBrng.MCG31         14009u 6358586656L
            rngRegTest VslBrng.R250          14019u 6889946766L
            rngRegTest VslBrng.MRG32K3A      14029u 5942771438L
            rngRegTest VslBrng.MCG59         14039u 7783087904L
            rngRegTest VslBrng.WH            14049u 6607728973L
            rngRegTest VslBrng.SOBOL         14059u 6759364722L
            rngRegTest VslBrng.NIEDERR       14069u 6759364722L
            rngRegTest VslBrng.MT19937       14079u 6087785052L
            rngRegTest VslBrng.MT2203        14089u 7550249421L
            rngRegTest VslBrng.SFMT19937     14099u 5875956040L
            rngRegTest VslBrng.ARS5          14109u 7878416031L
            rngRegTest VslBrng.PHILOX4X32X10 14119u 6896942208L
        }

        test "bernoulli" {
            let rng s r = Vsl.RngBernoulli(VslMethodBernoulli.ICDF, s, Array.length r, r, 0.5)
            let rngRegTest brng seed expected = rngRegressionTest "bernoulli" rng brng seed expected
            rngRegTest VslBrng.MCG31         15009u 7303646217L
            rngRegTest VslBrng.R250          15019u 7297447362L
            rngRegTest VslBrng.MRG32K3A      15029u 7582379231L
            rngRegTest VslBrng.MCG59         15039u 5856905215L
            rngRegTest VslBrng.WH            15049u 4550236763L
            rngRegTest VslBrng.SOBOL         15059u 7795513064L
            rngRegTest VslBrng.NIEDERR       15069u 7795513064L
            rngRegTest VslBrng.MT19937       15079u 5606584243L
            rngRegTest VslBrng.MT2203        15089u 6987426969L
            rngRegTest VslBrng.SFMT19937     15099u 8376551972L
            rngRegTest VslBrng.ARS5          15109u 5797953654L
            rngRegTest VslBrng.PHILOX4X32X10 15119u 7697572742L
        }

        test "geometric" {
            let rng s r = Vsl.RngGeometric(VslMethodGeometric.ICDF, s, Array.length r, r, 0.5)
            let rngRegTest brng seed expected = rngRegressionTest "geometric" rng brng seed expected
            rngRegTest VslBrng.MCG31         16009u 7187529131L
            rngRegTest VslBrng.R250          16019u 7333520739L
            rngRegTest VslBrng.MRG32K3A      16029u 6934066442L
            rngRegTest VslBrng.MCG59         16039u 5579532180L
            rngRegTest VslBrng.WH            16049u 4742140113L
            rngRegTest VslBrng.SOBOL         16059u 4320261512L
            rngRegTest VslBrng.NIEDERR       16069u 4320261512L
            rngRegTest VslBrng.MT19937       16079u 4743893745L
            rngRegTest VslBrng.MT2203        16089u 6459072570L
            rngRegTest VslBrng.SFMT19937     16099u 5978903766L
            rngRegTest VslBrng.ARS5          16109u 5087069969L
            rngRegTest VslBrng.PHILOX4X32X10 16119u 6537149811L
        }

        test "hypergeometric" {
            let rng s r = Vsl.RngHypergeometric(VslMethodHypergeometric.H2PE, s, Array.length r, r, 20, 5, 3)
            let rngRegTest brng seed expected = rngRegressionTest "hypergeometric" rng brng seed expected
            rngRegTest VslBrng.MCG31         17009u 7505590888L
            rngRegTest VslBrng.R250          17019u 8157654408L
            rngRegTest VslBrng.MRG32K3A      17029u 5363226153L
            rngRegTest VslBrng.MCG59         17039u 7104405131L
            rngRegTest VslBrng.WH            17049u 5145681514L
            rngRegTest VslBrng.SOBOL         17059u 8326552959L
            rngRegTest VslBrng.NIEDERR       17069u 8326552959L
            rngRegTest VslBrng.MT19937       17079u 7154893751L
            rngRegTest VslBrng.MT2203        17089u 4580678279L
            rngRegTest VslBrng.SFMT19937     17099u 4878929170L
            rngRegTest VslBrng.ARS5          17109u 5105348163L
            rngRegTest VslBrng.PHILOX4X32X10 17119u 8564078007L
        }

        test "negbinomial" {
            let rng s r = Vsl.RngNegBinomial(VslMethodNegBinomial.NBAR, s, Array.length r, r, 2.0, 0.5)
            let rngRegTest brng seed expected = rngRegressionTest "negbinomial" rng brng seed expected
            rngRegTest VslBrng.MCG31         18009u 7409462528L
            rngRegTest VslBrng.R250          18019u 8008578028L
            rngRegTest VslBrng.MRG32K3A      18029u 5246085272L
            rngRegTest VslBrng.MCG59         18039u 5834778244L
            rngRegTest VslBrng.WH            18049u 6288389517L
            rngRegTest VslBrng.SOBOL         18059u 5754271288L
            rngRegTest VslBrng.NIEDERR       18069u 5754271288L
            rngRegTest VslBrng.MT19937       18079u 6711064904L
            rngRegTest VslBrng.MT2203        18089u 5254286412L
            rngRegTest VslBrng.SFMT19937     18099u 6771967726L
            rngRegTest VslBrng.ARS5          18109u 8015312150L
            rngRegTest VslBrng.PHILOX4X32X10 18119u 6202436026L
        }

        test "uniform_int" {
            let rng s r = Vsl.RngUniform(VslMethodUniform.STD, s, Array.length r, r, 0, 100)
            let rngRegTest brng seed expected = rngRegressionTest "uniform_int" rng brng seed expected
            rngRegTest VslBrng.MCG31         19009u 7585907347L
            rngRegTest VslBrng.R250          19019u 6073158271L
            rngRegTest VslBrng.MRG32K3A      19029u 5157146967L
            rngRegTest VslBrng.MCG59         19039u 5828360466L
            rngRegTest VslBrng.WH            19049u 5735168773L
            rngRegTest VslBrng.SOBOL         19059u 4756780048L
            rngRegTest VslBrng.NIEDERR       19069u 4756780048L
            rngRegTest VslBrng.MT19937       19079u 5791777437L
            rngRegTest VslBrng.MT2203        19089u 4431969085L
            rngRegTest VslBrng.SFMT19937     19099u 5902660199L
            rngRegTest VslBrng.ARS5          19109u 5650408163L
            rngRegTest VslBrng.PHILOX4X32X10 19119u 7331028865L
        }

        test "multinomial" {
            let rng s r = Vsl.RngMultinomial(VslMethodMultinomial.MULTPOISSON, s, Array.length r/4, r, 100, 4, [|0.1;0.2;0.3;0.4|])
            let rngRegTest brng seed expected = rngRegressionTest "multinomial" rng brng seed expected
            rngRegTest VslBrng.MCG31         20009u 5952224110L
            rngRegTest VslBrng.R250          20019u 5939022544L
            rngRegTest VslBrng.MRG32K3A      20029u 5817341231L
            rngRegTest VslBrng.MCG59         20039u 7496623569L
            rngRegTest VslBrng.WH            20049u 7498202221L
            rngRegTest VslBrng.SOBOL         20059u 7299760709L
            rngRegTest VslBrng.NIEDERR       20069u 7299760709L
            rngRegTest VslBrng.MT19937       20079u 7371599876L
            rngRegTest VslBrng.MT2203        20089u 5078083004L
            rngRegTest VslBrng.SFMT19937     20099u 7316507363L
            rngRegTest VslBrng.ARS5          20109u 8464270715L
            rngRegTest VslBrng.PHILOX4X32X10 20119u 6906149872L
        }
    }

let stats =
    test "SS" {

        test "sum_double" {
            let! obvs = Gen.Int[1,10]
            and! vars = Gen.Int[1,5]
            let! x = Gen.Double.OneTwo.Array[obvs*vars]
            let sum = Array.zeroCreate<double> vars
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x)
            Vsl.SSEditTask(task, VslEdit.SUM, sum) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.SUM, VslMethod.FAST) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            let expected = Array.init vars (fun i ->
                let mutable total = 0.0
                for j = 0 to obvs - 1 do
                    total <- total + x[i * obvs + j]
                total
            )
            Check.close VeryHigh expected sum
        }

        test "sum_single" {
            let! obvs = Gen.Int[1,10]
            and! vars = Gen.Int[1,5]
            let! x = Gen.Single.OneTwo.Array[obvs*vars]
            let sum = Array.zeroCreate<single> vars
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x)
            Vsl.SSEditTask(task, VslEdit.SUM, sum) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.SUM, VslMethod.FAST) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            let expected = Array.init vars (fun i ->
                let mutable total = 0.0f
                for j = 0 to obvs - 1 do
                    total <- total + x[i * obvs + j]
                total
            )
            Check.close High expected sum
        }

        test "mean_double" {
            let! obvs = Gen.Int[1,10]
            and! vars = Gen.Int[1,5]
            let! x = Gen.Double.OneTwo.Array[obvs*vars]
            let mean = Array.zeroCreate<double> vars
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x)
            Vsl.SSEditTask(task, VslEdit.MEAN, mean) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.MEAN, VslMethod.FAST) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            let expected = Array.init vars (fun i ->
                let mutable total = 0.0
                for j = 0 to obvs - 1 do
                    total <- total + x[i * obvs + j]
                total / double obvs
            )
            Check.close VeryHigh expected mean
        }

        test "mean_single" {
            let! obvs = Gen.Int[1,10]
            and! vars = Gen.Int[1,5]
            let! x = Gen.Single.OneTwo.Array[obvs*vars]
            let mean = Array.zeroCreate<single> vars
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x)
            Vsl.SSEditTask(task, VslEdit.MEAN, mean) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.MEAN, VslMethod.FAST) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            let expected = Array.init vars (fun i ->
                let mutable total = 0.0f
                for j = 0 to obvs - 1 do
                    total <- total + x[i * obvs + j]
                total / single obvs
            )
            Check.close High expected mean
        }

        test "mean_weight_double" {
            let! obvs = Gen.Int[1,10]
            and! vars = Gen.Int[1,5]
            let! x = Gen.Double.OneTwo.Array[obvs*vars]
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
                    let w = weight[j]
                    totalWeight <- totalWeight + w
                    total <- total + x[i * obvs + j] * w
                total / totalWeight
            )
            Check.close High expected mean
        }

        test "mean_weight_single" {
            let! obvs = Gen.Int[1,10]
            and! vars = Gen.Int[1,5]
            let! x = Gen.Single.OneTwo.Array[obvs*vars]
            let mean = Array.zeroCreate<single> vars
            let weight = Array.init obvs (fun i -> single(i+1))
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x, weight)
            Vsl.SSEditTask(task, VslEdit.MEAN, mean) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.MEAN, VslMethod.FAST) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            let expected = Array.init vars (fun i ->
                let mutable total = 0.0f
                let mutable totalWeight = 0.0f
                for j = 0 to obvs - 1 do
                    let w = weight[j]
                    totalWeight <- totalWeight + w
                    total <- total + x[i * obvs + j] * w
                total / totalWeight
            )
            Check.close High expected mean
        }

        test "median_abs_dev_double" {
            let! obvs = Gen.Int[5,10]
            and! vars = Gen.Int[1,4]
            let! x = Gen.Double.OneTwo.Array[obvs*vars]
            let mad = Array.zeroCreate<double> vars
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x)
            Vsl.SSEditTask(task, VslEdit.MDAD, mad) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.MDAD, VslMethod.FAST) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            let expected = Array.init vars (fun i ->
                Array.Sort(x, i*obvs, obvs)
                let median =
                    if obvs % 2 = 1 then x[i*obvs+obvs/2]
                    else (x[i*obvs+obvs/2] + x[i*obvs+obvs/2-1]) * 0.5
                for j = i*obvs to (i+1)*obvs-1 do
                    x[j] <- abs(x[j] - median)
                Array.Sort(x, i*obvs, obvs)
                if obvs % 2 = 1 then x[i*obvs+obvs/2]
                else (x[i*obvs+obvs/2] + x[i*obvs+obvs/2-1]) * 0.5
            )
            Check.close VeryHigh expected mad
        }

        test "median_abs_dev_single" {
            let! obvs = Gen.Int[5,10]
            and! vars = Gen.Int[1,4]
            let! x = Gen.Single.OneTwo.Array[obvs*vars]
            let mad = Array.zeroCreate<single> vars
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x)
            Vsl.SSEditTask(task, VslEdit.MDAD, mad) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.MDAD, VslMethod.FAST) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            let expected = Array.init vars (fun i ->
                Array.Sort(x, i*obvs, obvs)
                let median =
                    if obvs % 2 = 1 then x[i*obvs+obvs/2]
                    else (x[i*obvs+obvs/2] + x[i*obvs+obvs/2-1]) * 0.5f
                for j = i*obvs to (i+1)*obvs-1 do
                    x[j] <- abs(x[j] - median)
                Array.Sort(x, i*obvs, obvs)
                if obvs % 2 = 1 then x[i*obvs+obvs/2]
                else (x[i*obvs+obvs/2] + x[i*obvs+obvs/2-1]) * 0.5f
            )
            Check.close Medium expected mad
        }

        test "mean_abs_dev_double" {
            let! obvs = Gen.Int[5,10]
            and! vars = Gen.Int[1,4]
            let! x = Gen.Double.OneTwo.Array[obvs*vars]
            let mad = Array.zeroCreate<double> vars
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x)
            Vsl.SSEditTask(task, VslEdit.MNAD, mad) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.MNAD, VslMethod.FAST) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            let expected = Array.init vars (fun i ->
                let mutable m = 0.0
                for j = i*obvs to (i+1)*obvs-1 do
                    m <- m + x[j]
                m <- m / double obvs
                let mutable t = 0.0
                for j = i*obvs to (i+1)*obvs-1 do
                    t <- t + abs(x[j] - m)
                t / double obvs
            )
            Check.close VeryHigh expected mad
        }

        test "mean_abs_dev_single" {
            let! obvs = Gen.Int[5,10]
            and! vars = Gen.Int[1,4]
            let! x = Gen.Single.OneTwo.Array[obvs*vars]
            let mad = Array.zeroCreate<single> vars
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x)
            Vsl.SSEditTask(task, VslEdit.MNAD, mad) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.MNAD, VslMethod.FAST) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            let expected = Array.init vars (fun i ->
                let mutable m = 0.0f
                for j = i*obvs to (i+1)*obvs-1 do
                    m <- m + x[j]
                m <- m / single obvs
                let mutable t = 0.0f
                for j = i*obvs to (i+1)*obvs-1 do
                    t <- t + abs(x[j] - m)
                t / single obvs
            )
            Check.close Medium expected mad
        }

        test "max_min_double" {
            let! obvs = Gen.Int[1,10]
            and! vars = Gen.Int[1,5]
            let! x = Gen.Double.OneTwo.Array[obvs*vars]
            let max = Array.zeroCreate<double> vars
            let min = Array.zeroCreate<double> vars
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x)
            Vsl.SSEditTask(task, VslEdit.MAX, max) |> Check.equal 0
            Vsl.SSEditTask(task, VslEdit.MIN, min) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.MAX ||| VslEstimate.MIN, VslMethod.FAST) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            let expectedMax = Array.init vars (fun i ->
                let mutable max = -infinity
                for j = i*obvs to (i+1)*obvs-1 do
                    let xj = x[j]
                    if xj > max then max <- xj
                max
            )
            Check.close VeryHigh expectedMax max
            let expectedMin = Array.init vars (fun i ->
                let mutable min = infinity
                for j = i*obvs to (i+1)*obvs-1 do
                    let xj = x[j]
                    if xj > min then min <- xj
                min
            )
            Check.close VeryHigh expectedMin min
        }

        test "max_min_single" {
            let! obvs = Gen.Int[5,10]
            and! vars = Gen.Int[1,5]
            let! x = Gen.Single.OneTwo.Array[obvs*vars]
            let max = Array.zeroCreate<single> vars
            let min = Array.zeroCreate<single> vars
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x)
            Vsl.SSEditTask(task, VslEdit.MAX, max) |> Check.equal 0
            Vsl.SSEditTask(task, VslEdit.MIN, min) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.MAX ||| VslEstimate.MIN, VslMethod.FAST) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            let expectedMax = Array.init vars (fun i ->
                let mutable max = -infinityf
                for j = i*obvs to (i+1)*obvs-1 do
                    let xj = x[j]
                    if xj > max then max <- xj
                max
            )
            Check.close VeryHigh expectedMax max
            let expectedMin = Array.init vars (fun i ->
                let mutable min = infinityf
                for j = i*obvs to (i+1)*obvs-1 do
                    let xj = x[j]
                    if xj > min then min <- xj
                min
            )
            Check.close VeryHigh expectedMin min
        }

        test "skewness_double" {
            let! obvs = Gen.Int[10,15]
            and! vars = Gen.Int[1,5]
            let! x = Gen.Double.OneTwo.Array[obvs*vars]
            let mean = Array.zeroCreate vars
            let mom2r = Array.zeroCreate vars
            let mom3r = Array.zeroCreate vars
            let mom2c = Array.zeroCreate vars
            let mom3c = Array.zeroCreate vars
            let skewness = Array.zeroCreate<double> vars
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x)
            Vsl.SSEditMoments(task, mean, mom2r, mom3r, null, mom2c, mom3c, null) |> Check.equal 0
            Vsl.SSEditTask(task, VslEdit.SKEWNESS, skewness) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.SKEWNESS, VslMethod.FAST) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            let mean = Array.init vars (fun i ->
                let mutable total = 0.0
                for j = 0 to obvs - 1 do
                    total <- total + x[i * obvs + j]
                total / double obvs
            )
            let expected = Array.init vars (fun i ->
                let m = mean[i]
                let mutable total2 = 0.0
                let mutable total3 = 0.0
                for j = 0 to obvs - 1 do
                    let xm = x[i * obvs + j] - m
                    total2 <- total2 + xm * xm
                    total3 <- total3 + xm * xm * xm
                total3 / double obvs / Math.Pow(total2 / double(obvs-1), 1.5)
            )
            Check.close High expected skewness
        }

        test "quantiles_double" {
            let! obvs = Gen.Int[5,10]
            and! vars = Gen.Int[1,4]
            let! x = Gen.Double.OneTwo.Array[obvs*vars]
            let quantiles = [| 0.9; 0.95; 0.99 |]
            let quants = Array.zeroCreate (vars*quantiles.Length)
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x)
            Vsl.SSEditQuantiles(task, quantiles.Length, quantiles, quants, null, VslStorage.ROWS) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.QUANTS, VslMethod.FAST) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            let percentile s ss se p =
                let inline linear2 (x1,y1) (x2,y2) x = y1 + (x - x1) * (y2 - y1) / (x2 - x1)
                let si = double ss + double(se-ss-1)*p
                if si <= double ss then Array.get s ss
                elif si >= double(se-1) then Array.get s (se-1)
                else linear2 (floor si,s[int si]) (floor si + 1.0,s[int si + 1]) si
            let expected = Array.init (vars*quantiles.Length) (fun i ->
                let var, qi = Math.DivRem(i,quantiles.Length)
                Array.Sort(x, var*obvs, obvs)
                percentile x (var*obvs) (var*obvs+obvs) quantiles[qi]
            )
            Check.close High expected quants
        }

        test "quantiles_single" {
            let! obvs = Gen.Int[1,10]
            and! vars = Gen.Int[1,4]
            let! x = Gen.Single.OneTwo.Array[obvs*vars]
            let quantiles = [| 0.9f; 0.95f; 0.99f |]
            let quants = Array.zeroCreate (vars*quantiles.Length)
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x)
            Vsl.SSEditQuantiles(task, quantiles.Length, quantiles, quants, null, VslStorage.ROWS) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.QUANTS, VslMethod.FAST) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            let percentile s ss se p =
                let inline linear2 (x1,y1) (x2,y2) x = y1 + (x - x1) * (y2 - y1) / (x2 - x1)
                let si = single ss + single(se-ss-1)*p
                if si <= single ss then Array.get s ss
                elif si >= single(se-1) then Array.get s (se-1)
                else linear2 (floor si,s[int si]) (floor si + 1.0f,s[int si + 1]) si
            let expected = Array.init (vars*quantiles.Length) (fun i ->
                let var, qi = Math.DivRem(i,quantiles.Length)
                Array.Sort(x, var*obvs, obvs)
                percentile x (var*obvs) (var*obvs+obvs) quantiles[qi]
            )
            Check.close Medium expected quants
        }

        test "cov_double" {
            let! obvs = Gen.Int[5,10]
            and! vars = Gen.Int[2,5]
            let! x = Gen.Double.OneTwo.Array[obvs*vars]
            let mean = Array.zeroCreate<double> vars
            let cov = Array.zeroCreate<double> (vars*vars)
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x)
            Vsl.SSEditCovCor(task, mean, cov, VslFormat.FULL, null, VslFormat.FULL) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.COV, VslMethod.FAST) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            let expectedMean = Array.init vars (fun i ->
                let mutable total = 0.0
                for j = 0 to obvs - 1 do
                    total <- total + x[i * obvs + j]
                total / double obvs
            )
            let expectedCov = Array.init (vars*vars) (fun ij ->
                let i,j = Math.DivRem(ij,vars)
                let mutable total = 0.0
                for k = 0 to obvs - 1 do
                    total <- total + (x[k + obvs * i]-mean[i]) * (x[k + obvs * j]-mean[j])
                total / double(obvs-1)
            )
            Check.close High expectedMean mean
            Check.close High expectedCov cov
        }

        test "cov_single" {
            let! obvs = Gen.Int[5,10]
            and! vars = Gen.Int[2,5]
            let! x = Gen.Single.OneTwo.Array[obvs*vars]
            let mean = Array.zeroCreate<single> vars
            let cov = Array.zeroCreate<single> (vars*vars)
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x)
            Vsl.SSEditCovCor(task, mean, cov, VslFormat.FULL, null, VslFormat.FULL) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.COV, VslMethod.FAST) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            let expectedMean = Array.init vars (fun i ->
                let mutable total = 0.0f
                for j = 0 to obvs - 1 do
                    total <- total + x[i * obvs + j]
                total / single obvs
            )
            let expectedCov = Array.init (vars*vars) (fun ij ->
                let i,j = Math.DivRem(ij,vars)
                let mutable total = 0.0f
                for k = 0 to obvs - 1 do
                    total <- total + (x[k + obvs * i]-mean[i]) * (x[k + obvs * j]-mean[j])
                total / single(obvs-1)
            )
            Check.close High expectedMean mean
            Check.close Low expectedCov cov
        }

        test "cor_double" {
            let! obvs = Gen.Int[5,10]
            and! vars = Gen.Int[2,5]
            let! x = Gen.Double.OneTwo.Array[obvs*vars]
            let mean = Array.zeroCreate<double> vars
            let cor = Array.zeroCreate<double> (vars*vars)
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x)
            Vsl.SSEditCovCor(task, mean, null, VslFormat.FULL, cor, VslFormat.FULL) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.COR, VslMethod.FAST) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            let expectedMean = Array.init vars (fun i ->
                let mutable total = 0.0
                for j = 0 to obvs - 1 do
                    total <- total + x[i * obvs + j]
                total / double obvs
            )
            let cov = Array.init (vars*vars) (fun ij ->
                let i,j = Math.DivRem(ij,vars)
                let mutable total = 0.0
                for k = 0 to obvs - 1 do
                    total <- total + (x[k + obvs * i]-mean[i]) * (x[k + obvs * j]-mean[j])
                total / double(obvs-1)
            )
            let expectedCor = Array.init (vars*vars) (fun ij ->
                let i,j = Math.DivRem(ij,vars)
                if i=j then cov[ij]
                else cov[ij] / sqrt(cov[i + i * vars] * cov[j + j *vars])
            )
            Check.close High expectedMean mean
            Check.close High expectedCor cor
        }

        test "cor_single" {
            let! obvs = Gen.Int[5,10]
            and! vars = Gen.Int[2,5]
            let! x = Gen.Single.OneTwo.Array[obvs*vars]
            let mean = Array.zeroCreate<single> vars
            let cor = Array.zeroCreate<single> (vars*vars)
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x)
            Vsl.SSEditCovCor(task, mean, null, VslFormat.FULL, cor, VslFormat.FULL) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.COR, VslMethod.FAST) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            let expectedMean = Array.init vars (fun i ->
                let mutable total = 0.0f
                for j = 0 to obvs - 1 do
                    total <- total + x[i * obvs + j]
                total / single obvs
            )
            let cov = Array.init (vars*vars) (fun ij ->
                let i,j = Math.DivRem(ij,vars)
                let mutable total = 0.0f
                for k = 0 to obvs - 1 do
                    total <- total + (x[k + obvs * i]-mean[i]) * (x[k + obvs * j]-mean[j])
                total / single(obvs-1)
            )
            let expectedCor = Array.init (vars*vars) (fun ij ->
                let i,j = Math.DivRem(ij,vars)
                if i=j then cov[ij]
                else cov[ij] / sqrt(cov[i + i * vars]) / sqrt(cov[j + j *vars])
            )
            Check.close High expectedMean mean
            Check.close Low expectedCor cor
        }

        test "missing_data_double" {
            let! obvs = Gen.Int[8,10]
            and! vars = Gen.Int[3,4]
            let! x = Gen.Double.OneTwo.Array[obvs*vars]
            let em_iter_num       = 3
            let da_iter_num       = 2
            let em_accuracy       = 0.001
            let copy_num          = 10
            let missing_value_num = 3
            x[1] <- nan; x[obvs] <- nan; x[obvs+2] <- nan
            let param = [| double em_iter_num; double da_iter_num; em_accuracy; double copy_num; double missing_value_num |]
            let simul_missing_vals = Array.zeroCreate<double> (missing_value_num*copy_num)
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x)
            Vsl.SSEditMissingValues(task, param.Length, param, 0, null, 0, null, simul_missing_vals.Length, simul_missing_vals, 0, null) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.MISSING_VALS, VslMethod.MI) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            Array.sumBy abs simul_missing_vals |> Check.notDefaultValue
        }

        test "missing_data_single" {
            let! obvs = Gen.Int[8,10]
            and! vars = Gen.Int[3,4]
            let! x = Gen.Single.OneTwo.Array[obvs*vars]
            let em_iter_num       = 3
            let da_iter_num       = 2
            let em_accuracy       = 0.001f
            let copy_num          = 10
            let missing_value_num = 3
            x[1] <- nanf; x[obvs] <- nanf; x[obvs+2] <- nanf
            let param = [| single em_iter_num; single da_iter_num; em_accuracy; single copy_num; single missing_value_num |]
            let simul_missing_vals = Array.zeroCreate<single> (missing_value_num*copy_num)
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x)
            Vsl.SSEditMissingValues(task, param.Length, param, 0, null, 0, null, simul_missing_vals.Length, simul_missing_vals, 0, null) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.MISSING_VALS, VslMethod.MI) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            Array.sumBy abs simul_missing_vals |> Check.notDefaultValue
        }

        test "outliers_double" {
            let! obvs = Gen.Int[20,25]
            and! vars = Gen.Int[3,4]
            let! x = Gen.Double.OneTwo.Array[obvs*vars]
            let init_method = double VslBaconInit.MEDIAN
            let alpha       = 0.005
            let beta        = 0.005
            x[1] <- 100.0; x[2+obvs*2] <- -100.0
            let param = [| init_method; alpha; beta |]
            let baconWeights = Array.zeroCreate<double> obvs
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x)
            Vsl.SSEditOutliersDetection(task, param.Length, param, baconWeights) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.OUTLIERS, VslMethod.BACON) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            Array.sumBy abs baconWeights |> Check.notDefaultValue
            Array.forall (fun i -> i = 0.0 || i = 1.0) baconWeights |> Check.isTrue
        }

        test "outliers_single" {
            let! obvs = Gen.Int[20,25]
            and! vars = Gen.Int[3,4]
            let! x = Gen.Single.OneTwo.Array[obvs*vars]
            let init_method = single VslBaconInit.MEDIAN
            let alpha       = 0.005f
            let beta        = 0.005f
            x[1] <- 100.0f; x[2+obvs*2] <- -100.0f
            let param = [| init_method; alpha; beta |]
            let baconWeights = Array.zeroCreate<single> obvs
            let task = Vsl.SSNewTask(vars, obvs, VslStorage.ROWS, x)
            Vsl.SSEditOutliersDetection(task, param.Length, param, baconWeights) |> Check.equal 0
            Vsl.SSCompute(task, VslEstimate.OUTLIERS, VslMethod.BACON) |> Check.equal 0
            Vsl.SSDeleteTask task |> Check.equal 0
            Array.sumBy abs baconWeights |> Check.notDefaultValue
            Array.forall (fun i -> i = 0.0f || i = 1.0f) baconWeights |> Check.isTrue
        }
    }

let conv_corr =
    test "conv_corr" {

        test "corr_double" {
            let! x = Gen.Double[1,100].Array[1,100]
            let! y = Gen.Double[1,100].Array[1,100]
            let! lz = Gen.Int[1,min x.Length y.Length]
            let z = Array.zeroCreate lz
            let mutable task = Unchecked.defaultof<VsldCorrTask>
            Vsl.CorrNewTask1D(&task, VslMode.DIRECT, x.Length, y.Length, lz) |> Check.equal 0
            Vsl.CorrSetStart(task, [|0|]) |> Check.equal 0
            Vsl.CorrExec1D(task, x, 1, y, 1, z, 1) |> Check.equal 0
            Array.sum z |> Check.greaterThan 0.0
        }

        test "corr_single" {
            let! x = Gen.Single[1f,100f].Array[1,100]
            let! y = Gen.Single[1f,100f].Array[1,100]
            let! lz = Gen.Int[1,min x.Length y.Length]
            let z = Array.zeroCreate lz
            let mutable task = Unchecked.defaultof<VslsCorrTask>
            Vsl.CorrNewTask1D(&task, VslMode.DIRECT, x.Length, y.Length, lz) |> Check.equal 0
            Vsl.CorrSetStart(task, [|0|]) |> Check.equal 0
            Vsl.CorrExec1D(task, x, 1, y, 1, z, 1) |> Check.equal 0
            Array.sum z |> Check.greaterThan 0.0f
        }

        test "conv_single" {
            let! x = Gen.Single[1f,100f].Array[1,100]
            let! y = Gen.Single[1f,100f].Array[1,100]
            let! lz = Gen.Int[1,min x.Length y.Length]
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