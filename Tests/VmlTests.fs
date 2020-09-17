module VmlTests

open System
open MKLNET
open CsCheck

let testUnary name (gen:Gen<'a>)
        (fexpected:'a -> 'a)
        (factual:'a[] -> 'a[] -> unit) =
    test name {
        let gena = GenArray gen
        let! a = gena.[0,5]
        let actual = Array.zeroCreate a.Length
        factual a actual
        let expected = Array.map fexpected a
        Check.close High expected actual
        factual a a
        Check.close High expected a |> Check.message "inplace"
    }

let testBinary name (gen:Gen<'a>)
        (fexpected:'a -> 'a -> 'a)
        (factual:'a[] -> 'a[] -> 'a[] -> unit) =
    test name {
        let gena = GenArray gen
        let! a = gena.[0,5]
        let! b = gena.[a.Length]
        let actual = Array.zeroCreate a.Length
        factual a b actual
        let expected = Array.map2 fexpected a b
        Check.close High expected actual
        factual a b a
        Check.close High expected a |> Check.message "inplace"
    }

let arithmetic =
    test "arithmetic" {

        testUnary "Abs_double" Gen.Double Math.Abs
            (fun a r -> Vml.Abs(a.Length,a,r))

        testUnary "Abs_mode_double" Gen.Double Math.Abs
            (fun a r -> Vml.Abs(a.Length,a,r,VmlMode.HA))

        testUnary "Abs_single" Gen.Single Math.Abs
            (fun a r -> Vml.Abs(a.Length,a,r))

        testUnary "Abs_mode_single" Gen.Single Math.Abs
            (fun a r -> Vml.Abs(a.Length,a,r,VmlMode.HA))

        testBinary "Add_double" Gen.Double (+)
            (fun a b r -> Vml.Add(a.Length,a,b,r))

        testBinary "Add_mode_double" Gen.Double (+)
            (fun a b r -> Vml.Add(a.Length,a,b,r,VmlMode.HA))

        testBinary "Add_single" Gen.Single (+)
            (fun a b r -> Vml.Add(a.Length,a,b,r))

        testBinary "Add_mode_single" Gen.Single (+)
            (fun a b r -> Vml.Add(a.Length,a,b,r,VmlMode.HA))

        testBinary "Sub_double" Gen.Double (-)
            (fun a b r -> Vml.Sub(a.Length,a,b,r))

        testBinary "Sub_mode_double" Gen.Double (-)
            (fun a b r -> Vml.Sub(a.Length,a,b,r,VmlMode.HA))

        testBinary "Sub_single" Gen.Single (-)
            (fun a b r -> Vml.Sub(a.Length,a,b,r))

        testBinary "Sub_mode_single" Gen.Single (-)
            (fun a b r -> Vml.Sub(a.Length,a,b,r,VmlMode.HA))

        testUnary "Inv_double" Gen.Double ((/) 1.0)
            (fun a r -> Vml.Inv(a.Length,a,r))

        testUnary "Inv_mode_double" Gen.Double ((/) 1.0)
            (fun a r -> Vml.Inv(a.Length,a,r,VmlMode.HA))

        testUnary "Inv_single" Gen.Single ((/) 1.0f)
            (fun a r -> Vml.Inv(a.Length,a,r))

        testUnary "Inv_mode_single" Gen.Single ((/) 1.0f)
            (fun a r -> Vml.Inv(a.Length,a,r,VmlMode.HA))

        testUnary "Sqrt_double" Gen.Double Math.Sqrt
            (fun a r -> Vml.Sqrt(a.Length,a,r))

        testUnary "Sqrt_mode_double" Gen.Double Math.Sqrt
            (fun a r -> Vml.Sqrt(a.Length,a,r,VmlMode.HA))

        testUnary "Sqrt_single" Gen.Single
            (float >> Math.Sqrt >> float32)
            (fun a r -> Vml.Sqrt(a.Length,a,r))

        testUnary "Sqrt_mode_single" Gen.Single
            (float >> Math.Sqrt >> float32)
            (fun a r -> Vml.Sqrt(a.Length,a,r,VmlMode.HA))

        testUnary "InvSqrt_double" Gen.Double
            ((/) 1.0 >> Math.Sqrt)
            (fun a r -> Vml.InvSqrt(a.Length,a,r))

        testUnary "InvSqrt_mode_double" Gen.Double
            ((/) 1.0 >> Math.Sqrt)
            (fun a r -> Vml.InvSqrt(a.Length,a,r,VmlMode.HA))

        testUnary "InvSqrt_single" Gen.Single
            (float >> (/) 1.0 >> Math.Sqrt >> float32)
            (fun a r -> Vml.InvSqrt(a.Length,a,r))

        testUnary "InvSqrt_mode_single" Gen.Single
            (float >> (/) 1.0 >> Math.Sqrt >> float32)
            (fun a r -> Vml.InvSqrt(a.Length,a,r,VmlMode.HA))

#if NETCOREAPP // No Math.Cbrt in .NET framework
        testUnary "Cbrt_double" Gen.Double Math.Cbrt
            (fun a r -> Vml.Cbrt(a.Length,a,r))

        testUnary "Cbrt_mode_double" Gen.Double Math.Cbrt
            (fun a r -> Vml.Cbrt(a.Length,a,r,VmlMode.HA))

        testUnary "Cbrt_single" Gen.Single
            (float >> Math.Cbrt >> float32)
            (fun a r -> Vml.Cbrt(a.Length,a,r))

        testUnary "Cbrt_mode_single" Gen.Single
            (float >> Math.Cbrt >> float32)
            (fun a r -> Vml.Cbrt(a.Length,a,r,VmlMode.HA))

        testUnary "InvCbrt_double" Gen.Double
            ((/) 1.0 >> Math.Cbrt)
            (fun a r -> Vml.InvCbrt(a.Length,a,r))

        testUnary "InvCbrt_mode_double" Gen.Double
            ((/) 1.0 >> Math.Cbrt)
            (fun a r -> Vml.InvCbrt(a.Length,a,r,VmlMode.HA))

        testUnary "InvCbrt_single" Gen.Single
            (float >> (/) 1.0 >> Math.Cbrt >> float32)
            (fun a r -> Vml.InvCbrt(a.Length,a,r))

        testUnary "InvCbrt_mode_single" Gen.Single
            (float >> (/) 1.0 >> Math.Cbrt >> float32)
            (fun a r -> Vml.InvCbrt(a.Length,a,r,VmlMode.HA))
#endif

        testUnary "Sqr_double" Gen.Double (fun i -> i * i)
            (fun a r -> Vml.Sqr(a.Length,a,r))

        testUnary "Sqr_mode_double" Gen.Double (fun i -> i * i)
            (fun a r -> Vml.Sqr(a.Length,a,r,VmlMode.HA))

        testUnary "Sqr_single" Gen.Single (fun i -> i * i)
            (fun a r -> Vml.Sqr(a.Length,a,r))

        testUnary "Sqr_mode_single" Gen.Single (fun i -> i * i)
            (fun a r -> Vml.Sqr(a.Length,a,r,VmlMode.HA))

        testUnary "Exp_double" Gen.Double Math.Exp
            (fun a r -> Vml.Exp(a.Length,a,r))

        testUnary "Exp_mode_double" Gen.Double Math.Exp
            (fun a r -> Vml.Exp(a.Length,a,r,VmlMode.HA))

        testUnary "Exp_single" Gen.Single
            (float >> Math.Exp >> float32)
            (fun a r -> Vml.Exp(a.Length,a,r))

        testUnary "Exp_mode_single" Gen.Single
            (float >> Math.Exp >> float32)
            (fun a r -> Vml.Exp(a.Length,a,r,VmlMode.HA))

        testUnary "Exp2_double" Gen.Double
            (fun i -> Math.Pow(2.0,i))
            (fun a r -> Vml.Exp2(a.Length,a,r))

        testUnary "Exp2_mode_double" Gen.Double
            (fun i -> Math.Pow(2.0,i))
            (fun a r -> Vml.Exp2(a.Length,a,r,VmlMode.HA))

        testUnary "Exp2_single" Gen.Single
            (fun i -> Math.Pow(2.0,float i) |> float32)
            (fun a r -> Vml.Exp2(a.Length,a,r))

        testUnary "Exp2_mode_single" Gen.Single
            (fun i -> Math.Pow(2.0,float i) |> float32)
            (fun a r -> Vml.Exp2(a.Length,a,r,VmlMode.HA))

        testUnary "Exp10_double" Gen.Double
            (fun i -> Math.Pow(10.0,i))
            (fun a r -> Vml.Exp10(a.Length,a,r))

        testUnary "Exp10_mode_double" Gen.Double
            (fun i -> Math.Pow(10.0,i))
            (fun a r -> Vml.Exp10(a.Length,a,r,VmlMode.HA))

        testUnary "Exp10_single" Gen.Single
            (fun i -> Math.Pow(10.0,float i) |> float32)
            (fun a r -> Vml.Exp10(a.Length,a,r))

        testUnary "Exp10_mode_single" Gen.Single
            (fun i -> Math.Pow(10.0,float i) |> float32)
            (fun a r -> Vml.Exp10(a.Length,a,r,VmlMode.HA))

        testUnary "Expm1_double" Gen.Double
            (fun i -> Math.Exp i-1.0)
            (fun a r -> Vml.Expm1(a.Length,a,r))

        testUnary "Expm1_mode_double" Gen.Double
            (fun i -> Math.Exp i-1.0)
            (fun a r -> Vml.Expm1(a.Length,a,r,VmlMode.HA))

        testUnary "Expm1_single" Gen.Single
            (fun i -> Math.Exp(float i)-1.0 |> float32)
            (fun a r -> Vml.Expm1(a.Length,a,r))

        testUnary "Expm1_mode_single" Gen.Single
            (fun i -> Math.Exp(float i)-1.0 |> float32)
            (fun a r -> Vml.Expm1(a.Length,a,r,VmlMode.HA))

        testUnary "Ln_double" Gen.Double Math.Log
            (fun a r -> Vml.Ln(a.Length,a,r))

        testUnary "Ln_mode_double" Gen.Double Math.Log
            (fun a r -> Vml.Ln(a.Length,a,r,VmlMode.HA))

        testUnary "Ln_single" Gen.Single
            (float >> Math.Log >> float32)
            (fun a r -> Vml.Ln(a.Length,a,r))

        testUnary "Ln_mode_single" Gen.Single
            (float >> Math.Log >> float32)
            (fun a r -> Vml.Ln(a.Length,a,r,VmlMode.HA))

#if NETCOREAPP // No Math.Log2 in .NET framework
        testUnary "Log2_double" Gen.Double Math.Log2
            (fun a r -> Vml.Log2(a.Length,a,r))

        testUnary "Log2_mode_double" Gen.Double Math.Log2
            (fun a r -> Vml.Log2(a.Length,a,r,VmlMode.HA))

        testUnary "Log2_single" Gen.Single
            (float >> Math.Log2 >> float32)
            (fun a r -> Vml.Log2(a.Length,a,r))

        testUnary "Log2_mode_single" Gen.Single
            (float >> Math.Log2 >> float32)
            (fun a r -> Vml.Log2(a.Length,a,r,VmlMode.HA))
#endif

        testUnary "Log10_double" Gen.Double Math.Log10
            (fun a r -> Vml.Log10(a.Length,a,r))

        testUnary "Log10_mode_double" Gen.Double Math.Log10
            (fun a r -> Vml.Log10(a.Length,a,r,VmlMode.HA))

        testUnary "Log10_single" Gen.Single
            (float >> Math.Log10 >> float32)
            (fun a r -> Vml.Log10(a.Length,a,r))

        testUnary "Log10_mode_single" Gen.Single
            (float >> Math.Log10 >> float32)
            (fun a r -> Vml.Log10(a.Length,a,r,VmlMode.HA))

        testUnary "Log1p_double" Gen.Double
            (fun i -> Math.Log(i+1.0))
            (fun a r -> Vml.Log1p(a.Length,a,r))

        testUnary "Log1p_mode_double" Gen.Double
            (fun i -> Math.Log(i+1.0))
            (fun a r -> Vml.Log1p(a.Length,a,r,VmlMode.HA))

        testUnary "Log1p_single" Gen.Single
            (fun i -> Math.Log(float i+1.0) |> float32)
            (fun a r -> Vml.Log1p(a.Length,a,r))

        testUnary "Log1p_mode_single" Gen.Single
            (fun i -> Math.Log(float i+1.0) |> float32)
            (fun a r -> Vml.Log1p(a.Length,a,r,VmlMode.HA))

#if NETCOREAPP // No Math.ILogB in .NET framework
        testUnary "Logb_double" Gen.Double.[0.0,Double.MaxValue]
            (fun i -> Math.ILogB(i) |> float)
            (fun a r -> Vml.Logb(a.Length,a,r))

        testUnary "Logb_mode_double" Gen.Double.[0.0,Double.MaxValue]
            (fun i -> Math.ILogB(i) |> float)
            (fun a r -> Vml.Logb(a.Length,a,r,VmlMode.HA))

        testUnary "Logb_single" Gen.Single.[0.0f,Single.MaxValue]
            (fun i -> Math.ILogB(float i) |> float32)
            (fun a r -> Vml.Logb(a.Length,a,r))

        testUnary "Logb_mode_single" Gen.Single.[0.0f,Single.MaxValue]
            (fun i -> Math.ILogB(float i) |> float32)
            (fun a r -> Vml.Logb(a.Length,a,r,VmlMode.HA))
#endif
    }

let trigonometric =
    test "trigonometric" {
        testUnary "Cos_double" Gen.Double.[-65536.0,65536.0]
            Math.Cos
            (fun a r -> Vml.Cos(a.Length,a,r))

        testUnary "Cos_mode_double" Gen.Double.[-65536.0,65536.0]
            Math.Cos
            (fun a r -> Vml.Cos(a.Length,a,r,VmlMode.HA))

        testUnary "Cos_single" Gen.Single.[-8192.0f,8192.0f]
            (float >> Math.Cos >> float32)
            (fun a r -> Vml.Cos(a.Length,a,r))

        testUnary "Cos_mode_single" Gen.Single.[-8192.0f,8192.0f]
            (float >> Math.Cos >> float32)
            (fun a r -> Vml.Cos(a.Length,a,r,VmlMode.HA))

        testUnary "Sin_double" Gen.Double.[-65536.0,65536.0]
            Math.Sin
            (fun a r -> Vml.Sin(a.Length,a,r))

        testUnary "Sin_mode_double" Gen.Double.[-65536.0,65536.0]
            Math.Sin
            (fun a r -> Vml.Sin(a.Length,a,r,VmlMode.HA))

        testUnary "Sin_single" Gen.Single.[-8192.0f,8192.0f]
            (float >> Math.Sin >> float32)
            (fun a r -> Vml.Sin(a.Length,a,r))

        testUnary "Sin_mode_single" Gen.Single.[-8192.0f,8192.0f]
            (float >> Math.Sin >> float32)
            (fun a r -> Vml.Sin(a.Length,a,r,VmlMode.HA))

        testUnary "Tan_double" Gen.Double.[-65536.0,65536.0]
            Math.Tan
            (fun a r -> Vml.Tan(a.Length,a,r))

        testUnary "Tan_mode_double" Gen.Double.[-65536.0,65536.0]
            Math.Tan
            (fun a r -> Vml.Tan(a.Length,a,r,VmlMode.HA))

        testUnary "Tan_single" Gen.Single.[-8192.0f,8192.0f]
            (float >> Math.Tan >> float32)
            (fun a r -> Vml.Tan(a.Length,a,r))

        testUnary "Tan_mode_single" Gen.Single.[-8192.0f,8192.0f]
            (float >> Math.Tan >> float32)
            (fun a r -> Vml.Tan(a.Length,a,r,VmlMode.HA))

        testUnary "Cospi_double" Gen.Double.[-65536.0,65536.0]
            (fun i -> Math.Cos(Math.PI*i))
            (fun a r -> Vml.Cospi(a.Length,a,r))

        testUnary "Cospi_mode_double" Gen.Double.[-65536.0,65536.0]
            (fun i -> Math.Cos(Math.PI*i))
            (fun a r -> Vml.Cospi(a.Length,a,r,VmlMode.HA))

        testUnary "Cospi_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> Math.Cos(Math.PI*float i) |> float32)
            (fun a r -> Vml.Cospi(a.Length,a,r))

        testUnary "Cospi_mode_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> Math.Cos(Math.PI*float i) |> float32)
            (fun a r -> Vml.Cospi(a.Length,a,r,VmlMode.HA))

        testUnary "Sinpi_double" Gen.Double.[-65536.0,65536.0]
            (fun i -> Math.Sin(Math.PI*i))
            (fun a r -> Vml.Sinpi(a.Length,a,r))

        testUnary "Sinpi_mode_double" Gen.Double.[-65536.0,65536.0]
            (fun i -> Math.Sin(Math.PI*i))
            (fun a r -> Vml.Sinpi(a.Length,a,r,VmlMode.HA))

        testUnary "Sinpi_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> Math.Sin(Math.PI*float i) |> float32)
            (fun a r -> Vml.Sinpi(a.Length,a,r))

        testUnary "Sinpi_mode_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> Math.Sin(Math.PI*float i) |> float32)
            (fun a r -> Vml.Sinpi(a.Length,a,r,VmlMode.HA))

        testUnary "Tanpi_double" Gen.Double.[-100.0,100.0]
            (fun i -> Math.Tan(Math.PI*i))
            (fun a r -> Vml.Tanpi(a.Length,a,r))

        testUnary "Tanpi_mode_double" Gen.Double.[-100.0,100.0]
            (fun i -> Math.Tan(Math.PI*i))
            (fun a r -> Vml.Tanpi(a.Length,a,r,VmlMode.HA))

        testUnary "Tanpi_single" Gen.Single.[-100.0f,100.0f]
            (fun i -> Math.Tan(Math.PI*float i) |> float32)
            (fun a r -> Vml.Tanpi(a.Length,a,r))

        testUnary "Tanpi_mode_single" Gen.Single.[-100.0f,100.0f]
            (fun i -> Math.Tan(Math.PI*float i) |> float32)
            (fun a r -> Vml.Tanpi(a.Length,a,r,VmlMode.HA))

        testUnary "Cosd_double" Gen.Double.[-65536.0,65536.0]
            (fun i -> Math.Cos(Math.PI/180.0*i))
            (fun a r -> Vml.Cosd(a.Length,a,r))

        testUnary "Cosd_mode_double" Gen.Double.[-65536.0,65536.0]
            (fun i -> Math.Cos(Math.PI/180.0*i))
            (fun a r -> Vml.Cosd(a.Length,a,r,VmlMode.HA))

        testUnary "Cosd_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> Math.Cos(Math.PI/180.0*float i) |> float32)
            (fun a r -> Vml.Cosd(a.Length,a,r))

        testUnary "Cosd_mode_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> Math.Cos(Math.PI/180.0*float i) |> float32)
            (fun a r -> Vml.Cosd(a.Length,a,r,VmlMode.HA))

        testUnary "Sind_double" Gen.Double.[-65536.0,65536.0]
            (fun i -> Math.Sin(Math.PI/180.0*i))
            (fun a r -> Vml.Sind(a.Length,a,r))

        testUnary "Sind_mode_double" Gen.Double.[-65536.0,65536.0]
            (fun i -> Math.Sin(Math.PI/180.0*i))
            (fun a r -> Vml.Sind(a.Length,a,r,VmlMode.HA))

        testUnary "Sind_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> Math.Sin(Math.PI/180.0*float i) |> float32)
            (fun a r -> Vml.Sind(a.Length,a,r))

        testUnary "Sind_mode_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> Math.Sin(Math.PI/180.0*float i) |> float32)
            (fun a r -> Vml.Sind(a.Length,a,r,VmlMode.HA))

        testUnary "Tand_double" Gen.Double.[-1000.0,1000.0]
            (fun i -> Math.Tan(Math.PI/180.0*i))
            (fun a r -> Vml.Tand(a.Length,a,r))

        testUnary "Tand_mode_double" Gen.Double.[-1000.0,1000.0]
            (fun i -> Math.Tan(Math.PI/180.0*i))
            (fun a r -> Vml.Tand(a.Length,a,r,VmlMode.HA))

        testUnary "Tand_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> Math.Tan(Math.PI/180.0*float i) |> float32)
            (fun a r -> Vml.Tand(a.Length,a,r))

        testUnary "Tand_mode_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> Math.Tan(Math.PI/180.0*float i) |> float32)
            (fun a r -> Vml.Tand(a.Length,a,r,VmlMode.HA))

        testUnary "Cosh_double" Gen.Double
            Math.Cosh
            (fun a r -> Vml.Cosh(a.Length,a,r))

        testUnary "Cosh_mode_double" Gen.Double
            Math.Cosh
            (fun a r -> Vml.Cosh(a.Length,a,r,VmlMode.HA))

        testUnary "Cosh_single" Gen.Single
            (float >> Math.Cosh >> float32)
            (fun a r -> Vml.Cosh(a.Length,a,r))

        testUnary "Cosh_mode_single" Gen.Single
            (float >> Math.Cosh >> float32)
            (fun a r -> Vml.Cosh(a.Length,a,r,VmlMode.HA))

        testUnary "Sinh_double" Gen.Double
            Math.Sinh
            (fun a r -> Vml.Sinh(a.Length,a,r))

        testUnary "Sinh_mode_double" Gen.Double
            Math.Sinh
            (fun a r -> Vml.Sinh(a.Length,a,r,VmlMode.HA))

        testUnary "Sinh_single" Gen.Single
            (float >> Math.Sinh >> float32)
            (fun a r -> Vml.Sinh(a.Length,a,r))

        testUnary "Sinh_mode_single" Gen.Single
            (float >> Math.Sinh >> float32)
            (fun a r -> Vml.Sinh(a.Length,a,r,VmlMode.HA))

        testUnary "Tanh_double" Gen.Double
            Math.Tanh
            (fun a r -> Vml.Tanh(a.Length,a,r))

        testUnary "Tanh_mode_double" Gen.Double
            Math.Tanh
            (fun a r -> Vml.Tanh(a.Length,a,r,VmlMode.HA))

        testUnary "Tanh_single" Gen.Single
            (float >> Math.Tanh >> float32)
            (fun a r -> Vml.Tanh(a.Length,a,r))

        testUnary "Tanh_mode_single" Gen.Single
            (float >> Math.Tanh >> float32)
            (fun a r -> Vml.Tanh(a.Length,a,r,VmlMode.HA))

        testUnary "Acos_double" Gen.Double.[-1.0,1.0]
            Math.Acos
            (fun a r -> Vml.Acos(a.Length,a,r))

        testUnary "Acos_mode_double" Gen.Double.[-1.0,1.0]
            Math.Acos
            (fun a r -> Vml.Acos(a.Length,a,r,VmlMode.HA))

        testUnary "Acos_single" Gen.Single.[-1.0f,1.0f]
            (float >> Math.Acos >> float32)
            (fun a r -> Vml.Acos(a.Length,a,r))

        testUnary "Acos_mode_single" Gen.Single.[-1.0f,1.0f]
            (float >> Math.Acos >> float32)
            (fun a r -> Vml.Acos(a.Length,a,r,VmlMode.HA))

        testUnary "Asin_double" Gen.Double.[-1.0,1.0]
            Math.Asin
            (fun a r -> Vml.Asin(a.Length,a,r))

        testUnary "Asin_mode_double" Gen.Double.[-1.0,1.0]
            Math.Asin
            (fun a r -> Vml.Asin(a.Length,a,r,VmlMode.HA))

        testUnary "Asin_single" Gen.Single.[-1.0f,1.0f]
            (float >> Math.Asin >> float32)
            (fun a r -> Vml.Asin(a.Length,a,r))

        testUnary "Asin_mode_single" Gen.Single.[-1.0f,1.0f]
            (float >> Math.Asin >> float32)
            (fun a r -> Vml.Asin(a.Length,a,r,VmlMode.HA))

        testUnary "Atan_double" Gen.Double
            Math.Atan
            (fun a r -> Vml.Atan(a.Length,a,r))

        testUnary "Atan_mode_double" Gen.Double
            Math.Atan
            (fun a r -> Vml.Atan(a.Length,a,r,VmlMode.HA))

        testUnary "Atan_single" Gen.Single
            (float >> Math.Atan >> float32)
            (fun a r -> Vml.Atan(a.Length,a,r))

        testUnary "Atan_mode_single" Gen.Single
            (float >> Math.Atan >> float32)
            (fun a r -> Vml.Atan(a.Length,a,r,VmlMode.HA))
    }

let all =
    test "Vml" {
        arithmetic
        //trigonometric
    }
