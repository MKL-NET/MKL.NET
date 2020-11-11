module VmlTests

open System
open MKLNET
open CsCheck

let ROWS_MAX = 5

let testUnaryN name (gen:Gen<'a>)
        (fexpected:'a -> 'a)
        (factual:'a[]*'a[] -> unit) =
    test name {
        let gena = GenArray gen
        let! a = gena.[1,ROWS_MAX]
        let actual = Array.zeroCreate a.Length
        factual(a,actual)
        let expected = Array.map fexpected a
        Check.close High expected actual
        factual(a,a)
        Check.close High expected a |> Check.message "inplace"
    }

let testUnaryI name (gen:Gen<'a>)
        (fexpected:'a -> 'a)
        (factual:(int*'a[]*int*int*'a[]*int*int) -> unit) =
    test name {
        let! rows = Gen.Int.[1,ROWS_MAX]
        and! cols = Gen.Int.[1,3]
        let! ini = Gen.Int.[0,cols-1]
        let! a = (GenArray gen).[rows*cols]
        let actual = Array.copy a
        factual(a.Length/cols,a,ini,cols,actual,ini,cols)
        let expected = Array.mapi (fun i a -> if i % cols = ini then fexpected a else a) a
        Check.close High expected actual
        factual(a.Length/cols,a,ini,cols,a,ini,cols)
        Check.close High expected a |> Check.message "inplace"
    }

let testUnary name (gen:Gen<'a>)
        (factualN:'a[]*'a[] -> unit)
        (factualM:'a[]*'a[]*VmlMode -> unit)
        (factualI:(int*'a[]*int*int*'a[]*int*int) -> unit)
        (factualB:(int*'a[]*int*int*'a[]*int*int*VmlMode) -> unit)
        (fexpected:'a -> 'a)
        =
        test name {
            testUnaryN "N" gen fexpected factualN
            testUnaryN "M" gen fexpected
                (fun (a,r) -> factualM(a,r,VmlMode.HA))
            testUnaryI "I" gen fexpected factualI
            testUnaryI "B" gen fexpected
                (fun (n,a,ia,sa,r,ir,sr) ->
                    factualB(n,a,ia,sa,r,ir,sr,VmlMode.HA))
        }

let testBinaryN name (gen:Gen<'a>)
    (fexpected:'a -> 'a -> 'a)
    (factual:'a[]*'a[]*'a[] -> unit) =
    test name {
        let gena = GenArray gen
        let! a = gena.[1,ROWS_MAX]
        let! b = gena.[a.Length]
        let actual = Array.zeroCreate a.Length
        factual(a,b,actual)
        let expected = Array.map2 fexpected a b
        Check.close High expected actual
        factual(a,b,a)
        Check.close High expected a |> Check.message "inplace"
    }

let testBinaryI name (gen:Gen<'a>)
        (fexpected:'a -> 'a -> 'a)
        (factual:(int*'a[]*int*int*'a[]*int*int*'a[]*int*int) -> unit) =
    test name {
        let! rows = Gen.Int.[1,ROWS_MAX]
        and! cols = Gen.Int.[1,3]
        let! ini = Gen.Int.[0,cols-1]
        let gena = GenArray gen
        let! a = gena.[rows*cols]
        let! b = gena.[a.Length]
        let actual = Array.copy a
        factual(a.Length/cols,a,ini,cols,b,ini,cols,actual,ini,cols)
        let expected = Array.mapi2 (fun i a b -> if i % cols = ini then fexpected a b else a) a b
        Check.close High expected actual
        factual(a.Length/cols,a,ini,cols,b,ini,cols,a,ini,cols)
        Check.close High expected a |> Check.message "inplace"
    }

let testBinary name (gen:Gen<'a>)
    (factualN:'a[]*'a[]*'a[] -> unit)
    (factualM:'a[]*'a[]*'a[]*VmlMode -> unit)
    (factualI:(int*'a[]*int*int*'a[]*int*int*'a[]*int*int) -> unit)
    (factualB:(int*'a[]*int*int*'a[]*int*int*'a[]*int*int*VmlMode) -> unit)
    (fexpected:'a -> 'a -> 'a)
    =
    test name {
        testBinaryN "N" gen fexpected factualN
        testBinaryN "M" gen fexpected
            (fun (a,b,r) -> factualM(a,b,r,VmlMode.HA))
        testBinaryI "I" gen fexpected factualI
        testBinaryI "B" gen fexpected
            (fun (n,a,ia,sa,b,ib,sb,r,ir,sr) ->
                factualB(n,a,ia,sa,b,ib,sb,r,ir,sr,VmlMode.HA))
    }

let arithmetic =
    test "arithmetic" {

        testUnary "Abs_double" Gen.Double
            Vml.Abs Vml.Abs Vml.Abs Vml.Abs
            abs

        testUnary "Abs_single" Gen.Single
            Vml.Abs Vml.Abs Vml.Abs Vml.Abs
            abs

        testBinary "Add_double" Gen.Double
            Vml.Add Vml.Add Vml.Add Vml.Add
            (+)

        testBinary "Add_single" Gen.Single
            Vml.Add Vml.Add Vml.Add Vml.Add
            (+)

        testBinary "Sub_double" Gen.Double
            Vml.Sub Vml.Sub Vml.Sub Vml.Sub
            (-)

        testBinary "Sub_single" Gen.Single
            Vml.Sub Vml.Sub Vml.Sub Vml.Sub
            (-)

        testUnary "Sqr_double" Gen.Double
            Vml.Sqr Vml.Sqr Vml.Sqr Vml.Sqr
            (fun i -> i * i)

        testUnary "Sqr_single" Gen.Single
            Vml.Sqr Vml.Sqr Vml.Sqr Vml.Sqr
            (fun i -> i * i)

        testBinary "Mul_double" Gen.Double
            Vml.Mul Vml.Mul Vml.Mul Vml.Mul
            (*)

        testBinary "Mul_single" Gen.Single
            Vml.Mul Vml.Mul Vml.Mul Vml.Mul
            (*)

        testBinary "Fmod_double" Gen.Double.[0.01,10000.0]
            Vml.Fmod Vml.Fmod Vml.Fmod Vml.Fmod
            (fun a b -> a - Math.Truncate(a/b) * b)

        testBinary "Fmod_single" Gen.Single.[0.01f,10000.0f]
            Vml.Fmod Vml.Fmod Vml.Fmod Vml.Fmod
            (fun a b -> double a - Math.Truncate(double a/double b) * double b |> single)

        testBinary "Remainder_double" Gen.Double.[0.01,10000.0]
            Vml.Remainder Vml.Remainder Vml.Remainder Vml.Remainder
            (fun a b -> a - Math.Round(a/b) * b)

        testBinary "Remainder_single" Gen.Single.[0.01f,10000.0f]
            Vml.Remainder Vml.Remainder Vml.Remainder Vml.Remainder
            (fun a b -> double a - Math.Round(double a/double b) * double b |> single)
    }

let power =
    test "power" {

        testUnary "Inv_double" Gen.Double
            Vml.Inv Vml.Inv Vml.Inv Vml.Inv
            ((/) 1.0)

        testUnary "Inv_single" Gen.Single
            Vml.Inv Vml.Inv Vml.Inv Vml.Inv
            ((/) 1.0f)

        testUnary "Sqrt_double" Gen.Double
            Vml.Sqrt Vml.Sqrt Vml.Sqrt Vml.Sqrt
            sqrt

        testUnary "Sqrt_single" Gen.Single
            Vml.Sqrt Vml.Sqrt Vml.Sqrt Vml.Sqrt
            (double >> sqrt >> single)

        testUnary "InvSqrt_double" Gen.Double
            Vml.InvSqrt Vml.InvSqrt Vml.InvSqrt Vml.InvSqrt
            ((/) 1.0 >> sqrt)

        testUnary "InvSqrt_single" Gen.Single
            Vml.InvSqrt Vml.InvSqrt Vml.InvSqrt Vml.InvSqrt
            (double >> (/) 1.0 >> sqrt >> single)

#if NETCOREAPP
        testUnary "Cbrt_double" Gen.Double
            Vml.Cbrt Vml.Cbrt Vml.Cbrt Vml.Cbrt
            Math.Cbrt

        testUnary "Cbrt_single" Gen.Single
            Vml.Cbrt Vml.Cbrt Vml.Cbrt Vml.Cbrt
            (double >> Math.Cbrt >> single)

        testUnary "InvCbrt_double" Gen.Double
            Vml.InvCbrt Vml.InvCbrt Vml.InvCbrt Vml.InvCbrt
            ((/) 1.0 >> Math.Cbrt)

        testUnary "InvCbrt_single" Gen.Single
            Vml.InvCbrt Vml.InvCbrt Vml.InvCbrt Vml.InvCbrt
            (double >> (/) 1.0 >> Math.Cbrt >> single)
#endif

        testBinary "Hypot_double" Gen.Double
            Vml.Hypot Vml.Hypot Vml.Hypot Vml.Hypot
            (fun a b -> sqrt(a*a+b*b))

        testBinary "Hypot_single" Gen.Single
            Vml.Hypot Vml.Hypot Vml.Hypot Vml.Hypot
            (fun a b -> sqrt(a*a+b*b))

        testBinary "Div_double" Gen.Double
            Vml.Div Vml.Div Vml.Div Vml.Div
            (/)

        testBinary "Div_single" Gen.Single
            Vml.Div Vml.Div Vml.Div Vml.Div
            (/)

#if NETCOREAPP
        testUnary "Pow2o3_double" Gen.Double
            Vml.Pow2o3 Vml.Pow2o3 Vml.Pow2o3 Vml.Pow2o3
            (fun a -> Math.Cbrt(a*a))

        testUnary "Pow2o3_single" Gen.Single
            Vml.Pow2o3 Vml.Pow2o3 Vml.Pow2o3 Vml.Pow2o3
            (fun a -> Math.Cbrt(double a*double a) |> single)
#endif

        testUnary "Pow3o2_double" Gen.Double.NonNegative
            Vml.Pow3o2 Vml.Pow3o2 Vml.Pow3o2 Vml.Pow3o2
            (fun a -> sqrt(a*a*a))

        testUnary "Pow3o2_single" Gen.Single.NonNegative
            Vml.Pow3o2 Vml.Pow3o2 Vml.Pow3o2 Vml.Pow3o2
            (fun a -> sqrt(a*a*a))

        testBinary "Pow_double" Gen.Double
            Vml.Pow Vml.Pow Vml.Pow Vml.Pow
            (fun a b -> Math.Pow(a,b))

        testBinary "Pow_single" Gen.Single
            Vml.Pow Vml.Pow Vml.Pow Vml.Pow
            (fun a b -> Math.Pow(double a,double b) |> single)

        testBinary "Powr_double" Gen.Double.[0.01,100.0]
            Vml.Powr Vml.Powr Vml.Powr Vml.Powr
            (fun a b -> Math.Pow(a,b))

        testBinary "Powr_single" Gen.Single.[0.01f,100.0f]
            Vml.Powr Vml.Powr Vml.Powr Vml.Powr
            (fun a b -> Math.Pow(double a,double b) |> single)
    }

let exponential =
    test "exponential" {

        testUnary "Exp_double" Gen.Double
            Vml.Exp Vml.Exp Vml.Exp Vml.Exp
            exp

        testUnary "Exp_single" Gen.Single
            Vml.Exp Vml.Exp Vml.Exp Vml.Exp
            (double >> exp >> single)

        testUnary "Exp2_double" Gen.Double
            Vml.Exp2 Vml.Exp2 Vml.Exp2 Vml.Exp2
            (fun i -> Math.Pow(2.0,i))

        testUnary "Exp2_single" Gen.Single
            Vml.Exp2 Vml.Exp2 Vml.Exp2 Vml.Exp2
            (fun i -> Math.Pow(2.0,double i) |> single)

        testUnary "Exp10_double" Gen.Double
            Vml.Exp10 Vml.Exp10 Vml.Exp10 Vml.Exp10
            (fun i -> Math.Pow(10.0,i))

        testUnary "Exp10_single" Gen.Single
            Vml.Exp10 Vml.Exp10 Vml.Exp10 Vml.Exp10
            (fun i -> Math.Pow(10.0,double i) |> single)

        testUnary "Expm1_double" Gen.Double
            Vml.Expm1 Vml.Expm1 Vml.Expm1 Vml.Expm1
            (fun i -> exp i-1.0)

        testUnary "Expm1_single" Gen.Single
            Vml.Expm1 Vml.Expm1 Vml.Expm1 Vml.Expm1
            (fun i -> exp(double i)-1.0 |> single)

        testUnary "Ln_double" Gen.Double
            Vml.Ln Vml.Ln Vml.Ln Vml.Ln
            log

        testUnary "Ln_single" Gen.Single
            Vml.Ln Vml.Ln Vml.Ln Vml.Ln
            (double >> log >> single)

#if NETCOREAPP
        testUnary "Log2_double" Gen.Double
            Vml.Log2 Vml.Log2 Vml.Log2 Vml.Log2
            Math.Log2

        testUnary "Log2_single" Gen.Single
            Vml.Log2 Vml.Log2 Vml.Log2 Vml.Log2
            (double >> Math.Log2 >> single)
#endif

        testUnary "Log10_double" Gen.Double
            Vml.Log10 Vml.Log10 Vml.Log10 Vml.Log10
            log10

        testUnary "Log10_single" Gen.Single
            Vml.Log10 Vml.Log10 Vml.Log10 Vml.Log10
            (double >> log10 >> single)

        testUnary "Log1p_double" Gen.Double
            Vml.Log1p Vml.Log1p Vml.Log1p Vml.Log1p
            (fun i -> log(i+1.0))

        testUnary "Log1p_single" Gen.Single
            Vml.Log1p Vml.Log1p Vml.Log1p Vml.Log1p
            (fun i -> log(double i+1.0) |> single)

#if NETCOREAPP
        testUnary "Logb_double" Gen.Double.NormalNonNegative
            Vml.Logb Vml.Logb Vml.Logb Vml.Logb
            (fun i -> Math.ILogB(i) |> double)

        testUnary "Logb_single" Gen.Single.NormalNonNegative
            Vml.Logb Vml.Logb Vml.Logb Vml.Logb
            (fun i -> Math.ILogB(double i) |> single)
#endif
    }

let trigonometric =
    test "trigonometric" {

        testUnary "Cos_double" Gen.Double.[-65536.0,65536.0]
            Vml.Cos Vml.Cos Vml.Cos Vml.Cos
            cos

        testUnary "Cos_single" Gen.Single.[-8192.0f,8192.0f]
            Vml.Cos Vml.Cos Vml.Cos Vml.Cos
            (double >> cos >> single)

        testUnary "Sin_double" Gen.Double.[-65536.0,65536.0]
            Vml.Sin Vml.Sin Vml.Sin Vml.Sin
            sin

        testUnary "Sin_single" Gen.Single.[-8192.0f,8192.0f]
            Vml.Sin Vml.Sin Vml.Sin Vml.Sin
            (double >> sin >> single)

        testUnary "Tan_double" Gen.Double.[-1.0,1.0]
            Vml.Tan Vml.Tan Vml.Tan Vml.Tan
            tan

        testUnary "Tan_single" Gen.Single.[-1.0f,1.0f]
            Vml.Tan Vml.Tan Vml.Tan Vml.Tan
            (double >> tan >> single)

        testUnary "Cospi_double" Gen.Double.[-65536.0,65536.0]
            Vml.Cospi Vml.Cospi Vml.Cospi Vml.Cospi
            (fun i -> cos(Math.PI*i))

        testUnary "Cospi_single" Gen.Single.[-4194304.0f,4194304.0f]
            Vml.Cospi Vml.Cospi Vml.Cospi Vml.Cospi
            (fun i -> cos(Math.PI*double i) |> single)

        testUnary "Sinpi_double" Gen.Double.[-65536.0,65536.0]
            Vml.Sinpi Vml.Sinpi Vml.Sinpi Vml.Sinpi
            (fun i -> sin(Math.PI*i))

        testUnary "Sinpi_single" Gen.Single.[-4194304.0f,4194304.0f]
            Vml.Sinpi Vml.Sinpi Vml.Sinpi Vml.Sinpi
            (fun i -> sin(Math.PI*double i) |> single)

        testUnary "Tanpi_double" Gen.Double.[-0.3,0.3]
            Vml.Tanpi Vml.Tanpi Vml.Tanpi Vml.Tanpi
            (fun i -> tan(Math.PI*i))

        testUnary "Tanpi_single" Gen.Single.[-0.3f,0.3f]
            Vml.Tanpi Vml.Tanpi Vml.Tanpi Vml.Tanpi
            (fun i -> tan(Math.PI*double i) |> single)

        testUnary "Cosd_double" Gen.Double.[-65536.0,65536.0]
            Vml.Cosd Vml.Cosd Vml.Cosd Vml.Cosd
            (fun i -> cos(Math.PI/180.0*i))

        testUnary "Cosd_single" Gen.Single.[-4194304.0f,4194304.0f]
            Vml.Cosd Vml.Cosd Vml.Cosd Vml.Cosd
            (fun i -> cos(Math.PI/180.0*double i) |> single)

        testUnary "Sind_double" Gen.Double.[-65536.0,65536.0]
            Vml.Sind Vml.Sind Vml.Sind Vml.Sind
            (fun i -> sin(Math.PI/180.0*i))

        testUnary "Sind_single" Gen.Single.[-4194304.0f,4194304.0f]
            Vml.Sind Vml.Sind Vml.Sind Vml.Sind
            (fun i -> sin(Math.PI/180.0*double i) |> single)

        testUnary "Tand_double" Gen.Double.[-57.0,57.0]
            Vml.Tand Vml.Tand Vml.Tand Vml.Tand
            (fun i -> tan(Math.PI/180.0*i))

        testUnary "Tand_single" Gen.Single.[-57.0f,57.0f]
            Vml.Tand Vml.Tand Vml.Tand Vml.Tand
            (fun i -> tan(Math.PI/180.0*double i) |> single)

        testUnary "Acos_double" Gen.Double.[-1.0,1.0]
            Vml.Acos Vml.Acos Vml.Acos Vml.Acos
            acos

        testUnary "Acos_single" Gen.Single.[-1.0f,1.0f]
            Vml.Acos Vml.Acos Vml.Acos Vml.Acos
            (double >> acos >> single)

        testUnary "Asin_double" Gen.Double.[-1.0,1.0]
            Vml.Asin Vml.Asin Vml.Asin Vml.Asin
            asin

        testUnary "Asin_single" Gen.Single.[-1.0f,1.0f]
            Vml.Asin Vml.Asin Vml.Asin Vml.Asin
            (double >> asin >> single)

        testUnary "Atan_double" Gen.Double
            Vml.Atan Vml.Atan Vml.Atan Vml.Atan
            atan

        testUnary "Atan_single" Gen.Single
            Vml.Atan Vml.Atan Vml.Atan Vml.Atan
            (double >> atan >> single)

        testUnary "Acospi_double" Gen.Double.[-1.0,1.0]
            Vml.Acospi Vml.Acospi Vml.Acospi Vml.Acospi
            (fun i -> acos(i) / Math.PI)

        testUnary "Acospi_single" Gen.Single.[-1.0f,1.0f]
            Vml.Acospi Vml.Acospi Vml.Acospi Vml.Acospi
            (fun i -> acos(double i) / Math.PI |> single)

        testUnary "Asinpi_double" Gen.Double.[-1.0,1.0]
            Vml.Asinpi Vml.Asinpi Vml.Asinpi Vml.Asinpi
            (fun i -> asin(i) / Math.PI)

        testUnary "Asinpi_single" Gen.Single.[-1.0f,1.0f]
            Vml.Asinpi Vml.Asinpi Vml.Asinpi Vml.Asinpi
            (fun i -> asin(double i) / Math.PI |> single)

        testUnary "Atanpi_double" Gen.Double
            Vml.Atanpi Vml.Atanpi Vml.Atanpi Vml.Atanpi
            (fun i -> atan(i) / Math.PI)

        testUnary "Atanpi_single" Gen.Single
            Vml.Atanpi Vml.Atanpi Vml.Atanpi Vml.Atanpi
            (fun i -> atan(double i) / Math.PI |> single)

        testBinary "Atan2_double" Gen.Double
            Vml.Atan2 Vml.Atan2 Vml.Atan2 Vml.Atan2
            atan2

        testBinary "Atan2_single" Gen.Single
            Vml.Atan2 Vml.Atan2 Vml.Atan2 Vml.Atan2
            (fun a b -> atan2 (double a) (double b) |> single)

        testBinary "Atan2pi_double" Gen.Double
            Vml.Atan2pi Vml.Atan2pi Vml.Atan2pi Vml.Atan2pi
            (fun a b -> atan2 a b / Math.PI)

        testBinary "Atan2pi_single" Gen.Single
            Vml.Atan2pi Vml.Atan2pi Vml.Atan2pi Vml.Atan2pi
            (fun a b -> atan2 (double a) (double b) / Math.PI |> single)
    }

let hyperbolic =
    test "hyperbolic" {

        testUnary "Cosh_double" Gen.Double
            Vml.Cosh Vml.Cosh Vml.Cosh Vml.Cosh
            cosh

        testUnary "Cosh_single" Gen.Single
            Vml.Cosh Vml.Cosh Vml.Cosh Vml.Cosh
            (double >> cosh >> single)

        testUnary "Sinh_double" Gen.Double
            Vml.Sinh Vml.Sinh Vml.Sinh Vml.Sinh
            sinh

        testUnary "Sinh_single" Gen.Single
            Vml.Sinh Vml.Sinh Vml.Sinh Vml.Sinh
            (double >> sinh >> single)

        testUnary "Tanh_double" Gen.Double
            Vml.Tanh Vml.Tanh Vml.Tanh Vml.Tanh
            tanh

        testUnary "Tanh_single" Gen.Single
            Vml.Tanh Vml.Tanh Vml.Tanh Vml.Tanh
            (double >> tanh >> single)

#if NETCOREAPP
        testUnary "Acosh_double" Gen.Double.[1.0,Double.MaxValue]
            Vml.Acosh Vml.Acosh Vml.Acosh Vml.Acosh
            Math.Acosh

        testUnary "Acosh_single" Gen.Single.[1.0f,Single.MaxValue]
            Vml.Acosh Vml.Acosh Vml.Acosh Vml.Acosh
            (double >> Math.Acosh >> single)

        testUnary "Asinh_double" Gen.Double
            Vml.Asinh Vml.Asinh Vml.Asinh Vml.Asinh
            Math.Asinh

        testUnary "Asinh_single" Gen.Single
            Vml.Asinh Vml.Asinh Vml.Asinh Vml.Asinh
            (double >> Math.Asinh >> single)

        testUnary "Atanh_double" Gen.Double.[-1.0,1.0]
            Vml.Atanh Vml.Atanh Vml.Atanh Vml.Atanh
            Math.Atanh

        testUnary "Atanh_single" Gen.Single.[-1.0f,1.0f]
            Vml.Atanh Vml.Atanh Vml.Atanh Vml.Atanh
            (double >> Math.Atanh >> single)
#endif
    }

let special =
    test "special" {

        testUnary "Erf_double" Gen.Double
            Vml.Erf Vml.Erf Vml.Erf Vml.Erf
            erf

        testUnary "Erf_single" Gen.Single
            Vml.Erf Vml.Erf Vml.Erf Vml.Erf
            (double >> erf >> single)

        testUnary "Erfc_double" Gen.Double
            Vml.Erfc Vml.Erfc Vml.Erfc Vml.Erfc
            erfc

        testUnary "Erfc_single" Gen.Single
            Vml.Erfc Vml.Erfc Vml.Erfc Vml.Erfc
            (double >> erfc >> single)

        testUnary "ErfInv_double" Gen.Double.[-0.9999,0.9999]
            Vml.ErfInv Vml.ErfInv Vml.ErfInv Vml.ErfInv
            erfinv

        testUnary "ErfInv_single" Gen.Single.[-0.9999f,0.9999f]
            Vml.ErfInv Vml.ErfInv Vml.ErfInv Vml.ErfInv
            (double >> erfinv >> single)

        testUnary "ErfcInv_double" Gen.Double.[0.0001,1.9999]
            Vml.ErfcInv Vml.ErfcInv Vml.ErfcInv Vml.ErfcInv
            erfcinv

        testUnary "ErfcInv_single" Gen.Single.[0.0001f,1.9999f]
            Vml.ErfcInv Vml.ErfcInv Vml.ErfcInv Vml.ErfcInv
            (double >> erfcinv >> single)

        testUnary "CdfNorm_double" Gen.Double
            Vml.CdfNorm Vml.CdfNorm Vml.CdfNorm Vml.CdfNorm
            normcdf

        testUnary "CdfNorm_single" Gen.Single
            Vml.CdfNorm Vml.CdfNorm Vml.CdfNorm Vml.CdfNorm
            (double >> normcdf >> single)

        testUnary "CdfNormInv_double" Gen.Double.[0.0001,0.9999]
            Vml.CdfNormInv Vml.CdfNormInv Vml.CdfNormInv Vml.CdfNormInv
            normcdfinv

        testUnary "CdfNormInv_single" Gen.Single.[0.0001f,0.9999f]
            Vml.CdfNormInv Vml.CdfNormInv Vml.CdfNormInv Vml.CdfNormInv
            (double >> normcdfinv >> single)

        testUnary "LGamma_double" Gen.Double.[0.0,10000.0]
            Vml.LGamma Vml.LGamma Vml.LGamma Vml.LGamma
            lgamma

        testUnary "LGamma_single" Gen.Single.[0.0f,10000.0f]
            Vml.LGamma Vml.LGamma Vml.LGamma Vml.LGamma
            (double >> lgamma >> single)

        testUnary "TGamma_double" Gen.Double.[0.0,100000.0]
            Vml.TGamma Vml.TGamma Vml.TGamma Vml.TGamma
            gamma

        testUnary "TGamma_single" Gen.Single.[0.0f,100000.0f]
            Vml.TGamma Vml.TGamma Vml.TGamma Vml.TGamma
            (double >> gamma >> single)

        testUnary "ExpInt1_double" Gen.Double.[0.0,100000.0]
            Vml.ExpInt1 Vml.ExpInt1 Vml.ExpInt1 Vml.ExpInt1
            (expint 1)

        testUnary "ExpInt1_single" Gen.Single.[0.0f,100000.0f]
            Vml.ExpInt1 Vml.ExpInt1 Vml.ExpInt1 Vml.ExpInt1
            (double >> (expint 1) >> single)
    }

let rounding =
    test "rounding" {

        testUnary "Floor_double" Gen.Double
            Vml.Floor Vml.Floor Vml.Floor Vml.Floor
            floor

        testUnary "Floor_single" Gen.Single
            Vml.Floor Vml.Floor Vml.Floor Vml.Floor
            (double >> floor >> single)

        testUnary "Ceil_double" Gen.Double
            Vml.Ceil Vml.Ceil Vml.Ceil Vml.Ceil
            ceil

        testUnary "Ceil_single" Gen.Single
            Vml.Ceil Vml.Ceil Vml.Ceil Vml.Ceil
            (double >> ceil >> single)

        testUnary "Trunc_double" Gen.Double
            Vml.Trunc Vml.Trunc Vml.Trunc Vml.Trunc
            truncate

        testUnary "Trunc_single" Gen.Single
            Vml.Trunc Vml.Trunc Vml.Trunc Vml.Trunc
            truncate

        testUnary "Round_double" Gen.Double
            Vml.Round Vml.Round Vml.Round Vml.Round
            (fun a -> Math.Round(a, MidpointRounding.AwayFromZero))

        testUnary "Round_single" Gen.Single
            Vml.Round Vml.Round Vml.Round Vml.Round
            (fun a -> Math.Round(double a, MidpointRounding.AwayFromZero) |> single)

        testUnary "Frac_double" Gen.Double
            Vml.Frac Vml.Frac Vml.Frac Vml.Frac
            (fun a -> a - truncate a)

        testUnary "Frac_single" Gen.Single
            Vml.Frac Vml.Frac Vml.Frac Vml.Frac
            (fun a -> a - truncate a)

        testUnary "NearbyInt_double" Gen.Double
            Vml.NearbyInt Vml.NearbyInt Vml.NearbyInt Vml.NearbyInt
            (fun a -> Math.Round(a, MidpointRounding.ToEven))

        testUnary "NearbyInt_single" Gen.Single
            Vml.NearbyInt Vml.NearbyInt Vml.NearbyInt Vml.NearbyInt
            (fun a -> Math.Round(double a, MidpointRounding.ToEven) |> single)

        testUnary "Rint_double" Gen.Double
            Vml.Rint Vml.Rint Vml.Rint Vml.Rint
            (fun a -> Math.Round(a, MidpointRounding.ToEven))

        testUnary "Rint_single" Gen.Single
            Vml.Rint Vml.Rint Vml.Rint Vml.Rint
            (fun a -> Math.Round(double a, MidpointRounding.ToEven) |> single)
    }

let miscellaneous =
    test "miscellaneous" {
#if NETCOREAPP
        testBinary "CopySign_double" Gen.Double
            Vml.CopySign Vml.CopySign Vml.CopySign Vml.CopySign
            (fun a b -> Math.CopySign(a,b))

        testBinary "CopySign_single" Gen.Single
            Vml.CopySign Vml.CopySign Vml.CopySign Vml.CopySign
            (fun a b -> Math.CopySign(double a, double b) |> single)
#endif

        testBinary "Fmax_double" Gen.Double.Normal
            Vml.Fmax Vml.Fmax Vml.Fmax Vml.Fmax
            (fun a b -> Math.Max(a,b))

        testBinary "Fmax_single" Gen.Single.Normal
            Vml.Fmax Vml.Fmax Vml.Fmax Vml.Fmax
            (fun a b -> Math.Max(a,b))

        testBinary "Fmin_double" Gen.Double.Normal
            Vml.Fmin Vml.Fmin Vml.Fmin Vml.Fmin
            (fun a b -> Math.Min(a,b))

        testBinary "Fmin_single" Gen.Single.Normal
            Vml.Fmin Vml.Fmin Vml.Fmin Vml.Fmin
            (fun a b -> Math.Min(a,b))

        testBinary "Fdim_double" Gen.Double.Normal
            Vml.Fdim Vml.Fdim Vml.Fdim Vml.Fdim
            (fun a b -> max (a-b) 0.0)

        testBinary "Fdim_single" Gen.Single.Normal
            Vml.Fdim Vml.Fdim Vml.Fdim Vml.Fdim
            (fun a b -> max (a-b) 0.0f)

        testBinary "MaxMag_double" Gen.Double.Normal
            Vml.MaxMag Vml.MaxMag Vml.MaxMag Vml.MaxMag
            (fun a b -> if abs a > abs b then a
                        elif abs a < abs b then b
                        else max a b)

        testBinary "MaxMag_single" Gen.Single.Normal
            Vml.MaxMag Vml.MaxMag Vml.MaxMag Vml.MaxMag
            (fun a b -> if abs a > abs b then a
                        elif abs a < abs b then b
                        else max a b)

        testBinary "MinMag_double" Gen.Double.Normal
            Vml.MinMag Vml.MinMag Vml.MinMag Vml.MinMag
            (fun a b -> if abs a < abs b then a
                        elif abs a > abs b then b
                        else min a b)

        testBinary "MinMag_single" Gen.Single.Normal
            Vml.MinMag Vml.MinMag Vml.MinMag Vml.MinMag
            (fun a b -> if abs a < abs b then a
                        elif abs a > abs b then b
                        else min a b)

#if NETCOREAPP
        testBinary "NextAfter_double" Gen.Double.Normal
            Vml.NextAfter Vml.NextAfter Vml.NextAfter Vml.NextAfter
            (fun a b -> if b > 0.0 then Math.BitIncrement(a)
                                   else Math.BitDecrement(a))

        testBinary "NextAfter_single" Gen.Single.Normal
            Vml.NextAfter Vml.NextAfter Vml.NextAfter Vml.NextAfter
            (fun a b -> if b > 0.0f then Math.BitIncrement(double a) |> single
                                    else Math.BitDecrement(double a) |> single)
#endif
    }

let bespoke =
    test "bespoke" {

        test "Powx_double" {
            let! a = Gen.Double.[0.0,Double.MaxValue].Array.[1,ROWS_MAX]
            let! b = Gen.Double
            let expected = Array.map (fun a -> Math.Pow(a,b)) a
            let actual = Array.zeroCreate a.Length
            Vml.Powx(a,b,actual)
            Check.close High expected actual
            Vml.Powx(a,b,actual,VmlMode.HA)
            Check.close High expected actual |> Check.message "mode"
            Vml.Powx(a.Length,a,0,1,b,actual,0,1)
            Check.close High expected actual |> Check.message "I"
            Vml.Powx(a.Length,a,0,1,b,actual,0,1,VmlMode.HA)
            Check.close High expected actual |> Check.message "Imode"
            Vml.Powx(a,b,a)
            Check.close High expected a |> Check.message "inplace"
        }

        test "Powx_single" {
            let! a = Gen.Single.NonNegative.Array.[1,ROWS_MAX]
            let! b = Gen.Single
            let expected = Array.map (fun a -> Math.Pow(double a,double b) |> single) a
            let actual = Array.zeroCreate a.Length
            Vml.Powx(a,b,actual)
            Check.close High expected actual
            Vml.Powx(a,b,actual,VmlMode.HA)
            Check.close High expected actual |> Check.message "mode"
            Vml.Powx(a.Length,a,0,1,b,actual,0,1)
            Check.close High expected actual |> Check.message "I"
            Vml.Powx(a.Length,a,0,1,b,actual,0,1,VmlMode.HA)
            Check.close High expected actual |> Check.message "Imode"
            Vml.Powx(a,b,a)
            Check.close High expected a |> Check.message "inplace"
        }

        test "SinCos_double" {
            let! a = Gen.Double.[-65536.0,65536.0].Array.[1,ROWS_MAX]
            let expected1 = Array.map sin a
            let expected2 = Array.map cos a
            let actual1 = Array.zeroCreate a.Length
            let actual2 = Array.zeroCreate a.Length
            Vml.SinCos(a,actual1,actual2)
            Check.close High expected1 actual1 |> Check.message "sin"
            Check.close High expected2 actual2 |> Check.message "sin"
            Vml.SinCos(a.Length,a,0,1,actual1,0,1,actual2,0,1)
            Check.close High expected1 actual1 |> Check.message "I_sin"
            Check.close High expected2 actual2 |> Check.message "I_sin"
            Vml.SinCos(a,actual1,actual2,VmlMode.HA)
            Check.close High expected1 actual1 |> Check.message "mode_sin"
            Check.close High expected2 actual2 |> Check.message "mode_sin"
            Vml.SinCos(a.Length,a,0,1,actual1,0,1,actual2,0,1,VmlMode.HA)
            Check.close High expected1 actual1 |> Check.message "I_mode_sin"
            Check.close High expected2 actual2 |> Check.message "I_mode_sin"
            Vml.SinCos(a,a,actual2)
            Check.close High expected1 a |> Check.message "inplace"
        }

        test "SinCos_single" {
            let! a = Gen.Single.[-8192.0f,8192.0f].Array.[1,ROWS_MAX]
            let expected1 = Array.map sin a
            let expected2 = Array.map cos a
            let actual1 = Array.zeroCreate a.Length
            let actual2 = Array.zeroCreate a.Length
            Vml.SinCos(a,actual1,actual2)
            Check.close High expected1 actual1 |> Check.message "sin"
            Check.close High expected2 actual2 |> Check.message "sin"
            Vml.SinCos(a.Length,a,0,1,actual1,0,1,actual2,0,1)
            Check.close High expected1 actual1 |> Check.message "I_sin"
            Check.close High expected2 actual2 |> Check.message "I_sin"
            Vml.SinCos(a,actual1,actual2,VmlMode.HA)
            Check.close High expected1 actual1 |> Check.message "mode_sin"
            Check.close High expected2 actual2 |> Check.message "mode_sin"
            Vml.SinCos(a.Length,a,0,1,actual1,0,1,actual2,0,1,VmlMode.HA)
            Check.close High expected1 actual1 |> Check.message "I_mode_sin"
            Check.close High expected2 actual2 |> Check.message "I_mode_sin"
            Vml.SinCos(a,a,actual2)
            Check.close High expected1 a |> Check.message "inplace"
        }

        test "Modf_double" {
            let! a = Gen.Double.Array.[1,ROWS_MAX]
            let expected1 = Array.map truncate a
            let expected2 = Array.map (fun a -> a - truncate a) a
            let actual1 = Array.zeroCreate a.Length
            let actual2 = Array.zeroCreate a.Length
            Vml.Modf(a,actual1,actual2)
            Check.close High expected1 actual1 |> Check.message "int"
            Check.close High expected2 actual2 |> Check.message "fra"
            Vml.Modf(a.Length,a,0,1,actual1,0,1,actual2,0,1)
            Check.close High expected1 actual1 |> Check.message "I_int"
            Check.close High expected2 actual2 |> Check.message "I_fra"
            Vml.Modf(a,actual1,actual2,VmlMode.HA)
            Check.close High expected1 actual1 |> Check.message "mode_int"
            Check.close High expected2 actual2 |> Check.message "mode_fra"
            Vml.Modf(a.Length,a,0,1,actual1,0,1,actual2,0,1,VmlMode.HA)
            Check.close High expected1 actual1 |> Check.message "I_mode_int"
            Check.close High expected2 actual2 |> Check.message "I_mode_fra"
            Vml.Modf(a,a,actual2)
            Check.close High expected1 a |> Check.message "inplace"
        }

        test "Modf_single" {
            let! a = Gen.Single.Array.[1,ROWS_MAX]
            let expected1 = Array.map truncate a
            let expected2 = Array.map (fun a -> a - truncate a) a
            let actual1 = Array.zeroCreate a.Length
            let actual2 = Array.zeroCreate a.Length
            Vml.Modf(a,actual1,actual2)
            Check.close High expected1 actual1 |> Check.message "int"
            Check.close High expected2 actual2 |> Check.message "fra"
            Vml.Modf(a.Length,a,0,1,actual1,0,1,actual2,0,1)
            Check.close High expected1 actual1 |> Check.message "I_int"
            Check.close High expected2 actual2 |> Check.message "I_fra"
            Vml.Modf(a,actual1,actual2,VmlMode.HA)
            Check.close High expected1 actual1 |> Check.message "mode_int"
            Check.close High expected2 actual2 |> Check.message "mode_fra"
            Vml.Modf(a.Length,a,0,1,actual1,0,1,actual2,0,1,VmlMode.HA)
            Check.close High expected1 actual1 |> Check.message "I_mode_int"
            Check.close High expected2 actual2 |> Check.message "I_mode_fra"
            Vml.Modf(a,a,actual2)
            Check.close High expected1 a |> Check.message "inplace"
        }

        test "LinearFrac_double" {
            let! a = Gen.Double.[0.01,100.0].Array.[1,ROWS_MAX]
            let! b = Gen.Double.[0.01,100.0].Array.[a.Length]
            let! scalea = Gen.Double.[0.01,100.0]
            let! shifta = Gen.Double.[0.01,100.0]
            let! scaleb = Gen.Double.[0.01,100.0]
            let! shiftb = Gen.Double.[0.01,100.0]
            let expected =
                Array.map2
                    (fun a b -> (a*scalea + shifta)/(b*scaleb + shiftb))
                    a b
            let actual = Array.zeroCreate a.Length
            Vml.LinearFrac(a,b,scalea,shifta,scaleb,shiftb,actual)
            Check.close High expected actual
            Vml.LinearFrac(a.Length,a,0,1,b,0,1,scalea,shifta,scaleb,shiftb,actual,0,1)
            Check.close High expected actual |> Check.message "I"
            Vml.LinearFrac(a,b,scalea,shifta,scaleb,shiftb,actual,VmlMode.HA)
            Check.close High expected actual |> Check.message "mode"
            Vml.LinearFrac(a.Length,a,0,1,b,0,1,scalea,shifta,scaleb,shiftb,actual,0,1,VmlMode.HA)
            Check.close High expected actual |> Check.message "I_mode"
            Vml.LinearFrac(a,b,scalea,shifta,scaleb,shiftb,a)
            Check.close High expected a |> Check.message "inplace"
        }

        test "LinearFrac_single" {
            let! a = Gen.Single.[0.01f,100.0f].Array.[1,ROWS_MAX]
            let! b = Gen.Single.[0.01f,100.0f].Array.[a.Length]
            let! scalea = Gen.Single.[0.01f,100.0f]
            let! shifta = Gen.Single.[0.01f,100.0f]
            let! scaleb = Gen.Single.[0.01f,100.0f]
            let! shiftb = Gen.Single.[0.01f,100.0f]
            let expected =
                Array.map2
                    (fun a b -> (a*scalea + shifta)/(b*scaleb + shiftb))
                    a b
            let actual = Array.zeroCreate a.Length
            Vml.LinearFrac(a,b,scalea,shifta,scaleb,shiftb,actual)
            Check.close High expected actual
            Vml.LinearFrac(a.Length,a,0,1,b,0,1,scalea,shifta,scaleb,shiftb,actual,0,1)
            Check.close High expected actual |> Check.message "I"
            Vml.LinearFrac(a,b,scalea,shifta,scaleb,shiftb,actual,VmlMode.HA)
            Check.close High expected actual |> Check.message "mode"
            Vml.LinearFrac(a.Length,a,0,1,b,0,1,scalea,shifta,scaleb,shiftb,actual,0,1,VmlMode.HA)
            Check.close High expected actual |> Check.message "I_mode"
            Vml.LinearFrac(a,b,scalea,shifta,scaleb,shiftb,a)
            Check.close High expected a |> Check.message "inplace"
        }
    }

let all =
    test "Vml" {
        arithmetic
        power
        exponential
        trigonometric
        hyperbolic
        special
        rounding
        miscellaneous
        bespoke
    }