module VmlTests

open System
open MKLNET
open CsCheck

let ARRAY_SIZE_MAX = 5

let testUnary name (gen:Gen<'a>)
        (fexpected:'a -> 'a)
        (factual:'a[] -> 'a[] -> unit) =
    test name {
        let gena = GenArray gen
        let! a = gena.[0,ARRAY_SIZE_MAX]
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
        let! a = gena.[0,ARRAY_SIZE_MAX]
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

        testUnary "Abs_double" Gen.Double abs
            (fun a r -> Vml.Abs(a.Length,a,r))

        testUnary "Abs_mode_double" Gen.Double abs
            (fun a r -> Vml.Abs(a.Length,a,r,VmlMode.HA))

        testUnary "Abs_single" Gen.Single abs
            (fun a r -> Vml.Abs(a.Length,a,r))

        testUnary "Abs_mode_single" Gen.Single abs
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

        testUnary "Sqr_double" Gen.Double (fun i -> i * i)
            (fun a r -> Vml.Sqr(a.Length,a,r))
            
        testUnary "Sqr_mode_double" Gen.Double (fun i -> i * i)
            (fun a r -> Vml.Sqr(a.Length,a,r,VmlMode.HA))
            
        testUnary "Sqr_single" Gen.Single (fun i -> i * i)
            (fun a r -> Vml.Sqr(a.Length,a,r))
            
        testUnary "Sqr_mode_single" Gen.Single (fun i -> i * i)
            (fun a r -> Vml.Sqr(a.Length,a,r,VmlMode.HA))

        testBinary "Mul_double" Gen.Double (*)
            (fun a b r -> Vml.Mul(a.Length,a,b,r))

        testBinary "Mul_mode_double" Gen.Double (*)
            (fun a b r -> Vml.Mul(a.Length,a,b,r,VmlMode.HA))

        testBinary "Mul_single" Gen.Single (*)
            (fun a b r -> Vml.Mul(a.Length,a,b,r))

        testBinary "Mul_mode_single" Gen.Single (*)
            (fun a b r -> Vml.Mul(a.Length,a,b,r,VmlMode.HA))

        testBinary "Fmod_double" Gen.Double.[0.01,10000.0]
            (fun a b -> a - Math.Truncate(a/b) * b)
            (fun a b r -> Vml.Fmod(a.Length,a,b,r))

        testBinary "Fmod_mode_double" Gen.Double.[0.01,10000.0]
            (fun a b -> a - Math.Truncate(a/b) * b)
            (fun a b r -> Vml.Fmod(a.Length,a,b,r,VmlMode.HA))
        
        testBinary "Fmod_single" Gen.Single.[0.01f,10000.0f]
            (fun a b -> float a - Math.Truncate(float a/float b) * float b |> float32)
            (fun a b r -> Vml.Fmod(a.Length,a,b,r))
        
        testBinary "Fmod_mode_single" Gen.Single.[0.01f,10000.0f]
            (fun a b -> float a - Math.Truncate(float a/float b) * float b |> float32)
            (fun a b r -> Vml.Fmod(a.Length,a,b,r,VmlMode.HA))

        testBinary "Remainder_double" Gen.Double.[0.01,10000.0]
            (fun a b -> a - Math.Round(a/b) * b)
            (fun a b r -> Vml.Remainder(a.Length,a,b,r))

        testBinary "Remainder_mode_double" Gen.Double.[0.01,10000.0]
            (fun a b -> a - Math.Round(a/b) * b)
            (fun a b r -> Vml.Remainder(a.Length,a,b,r,VmlMode.HA))
        
        testBinary "Remainder_single" Gen.Single.[0.01f,10000.0f]
            (fun a b -> float a - Math.Round(float a/float b) * float b |> float32)
            (fun a b r -> Vml.Remainder(a.Length,a,b,r))
        
        testBinary "Remainder_mode_single" Gen.Single.[0.01f,10000.0f]
            (fun a b -> float a - Math.Round(float a/float b) * float b |> float32)
            (fun a b r -> Vml.Remainder(a.Length,a,b,r,VmlMode.HA))

        test "LinearFrac_double" {
            let! a = Gen.Double.[0.01,100.0].Array.[0,ARRAY_SIZE_MAX]
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
            Vml.LinearFrac(a.Length,a,b,scalea,shifta,scaleb,shiftb,actual)
            Check.close High expected actual
            Vml.LinearFrac(a.Length,a,b,scalea,shifta,scaleb,shiftb,actual,VmlMode.HA)
            Check.close High expected actual |> Check.message "mode"
            Vml.LinearFrac(a.Length,a,b,scalea,shifta,scaleb,shiftb,a)
            Check.close High expected a |> Check.message "inplace"
        }

        test "LinearFrac_single" {
            let! a = Gen.Single.[0.01f,100.0f].Array.[0,ARRAY_SIZE_MAX]
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
            Vml.LinearFrac(a.Length,a,b,scalea,shifta,scaleb,shiftb,actual)
            Check.close High expected actual
            Vml.LinearFrac(a.Length,a,b,scalea,shifta,scaleb,shiftb,actual,VmlMode.HA)
            Check.close High expected actual |> Check.message "mode"
            Vml.LinearFrac(a.Length,a,b,scalea,shifta,scaleb,shiftb,a)
            Check.close High expected a |> Check.message "inplace"
        }
    }

let power =
    test "power" {
        testUnary "Inv_double" Gen.Double ((/) 1.0)
            (fun a r -> Vml.Inv(a.Length,a,r))

        testUnary "Inv_mode_double" Gen.Double ((/) 1.0)
            (fun a r -> Vml.Inv(a.Length,a,r,VmlMode.HA))

        testUnary "Inv_single" Gen.Single ((/) 1.0f)
            (fun a r -> Vml.Inv(a.Length,a,r))

        testUnary "Inv_mode_single" Gen.Single ((/) 1.0f)
            (fun a r -> Vml.Inv(a.Length,a,r,VmlMode.HA))

        testUnary "Sqrt_double" Gen.Double sqrt
            (fun a r -> Vml.Sqrt(a.Length,a,r))

        testUnary "Sqrt_mode_double" Gen.Double sqrt
            (fun a r -> Vml.Sqrt(a.Length,a,r,VmlMode.HA))

        testUnary "Sqrt_single" Gen.Single
            (float >> sqrt >> float32)
            (fun a r -> Vml.Sqrt(a.Length,a,r))

        testUnary "Sqrt_mode_single" Gen.Single
            (float >> sqrt >> float32)
            (fun a r -> Vml.Sqrt(a.Length,a,r,VmlMode.HA))

        testUnary "InvSqrt_double" Gen.Double
            ((/) 1.0 >> sqrt)
            (fun a r -> Vml.InvSqrt(a.Length,a,r))

        testUnary "InvSqrt_mode_double" Gen.Double
            ((/) 1.0 >> sqrt)
            (fun a r -> Vml.InvSqrt(a.Length,a,r,VmlMode.HA))

        testUnary "InvSqrt_single" Gen.Single
            (float >> (/) 1.0 >> sqrt >> float32)
            (fun a r -> Vml.InvSqrt(a.Length,a,r))

        testUnary "InvSqrt_mode_single" Gen.Single
            (float >> (/) 1.0 >> sqrt >> float32)
            (fun a r -> Vml.InvSqrt(a.Length,a,r,VmlMode.HA))

#if NETCOREAPP
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
        testBinary "Hypot_double" Gen.Double
            (fun a b -> sqrt(a*a+b*b))
            (fun a b r -> Vml.Hypot(a.Length,a,b,r))

        testBinary "Hypot_mode_double" Gen.Double
            (fun a b -> sqrt(a*a+b*b))
            (fun a b r -> Vml.Hypot(a.Length,a,b,r,VmlMode.HA))

        testBinary "Hypot_single" Gen.Single
            (fun a b -> sqrt(a*a+b*b))
            (fun a b r -> Vml.Hypot(a.Length,a,b,r))

        testBinary "Hypot_mode_single" Gen.Single
            (fun a b -> sqrt(a*a+b*b))
            (fun a b r -> Vml.Hypot(a.Length,a,b,r,VmlMode.HA))

        testBinary "Div_double" Gen.Double (/)
            (fun a b r -> Vml.Div(a.Length,a,b,r))

        testBinary "Div_mode_double" Gen.Double (/)
            (fun a b r -> Vml.Div(a.Length,a,b,r,VmlMode.HA))

        testBinary "Div_single" Gen.Single (/)
            (fun a b r -> Vml.Div(a.Length,a,b,r))

        testBinary "Div_mode_single" Gen.Single (/)
            (fun a b r -> Vml.Div(a.Length,a,b,r,VmlMode.HA))

#if NETCOREAPP
        testUnary "Pow2o3_double" Gen.Double
            (fun a -> Math.Cbrt(a*a))
            (fun a r -> Vml.Pow2o3(a.Length,a,r))

        testUnary "Pow2o3_mode_double" Gen.Double
            (fun a -> Math.Cbrt(a*a))
            (fun a r -> Vml.Pow2o3(a.Length,a,r,VmlMode.HA))

        testUnary "Pow2o3_single" Gen.Single
            (fun a -> Math.Cbrt(float a*float a) |> float32)
            (fun a r -> Vml.Pow2o3(a.Length,a,r))

        testUnary "Pow2o3_mode_single" Gen.Single
            (fun a -> Math.Cbrt(float a*float a) |> float32)
            (fun a r -> Vml.Pow2o3(a.Length,a,r,VmlMode.HA))
#endif

        testUnary "Pow3o2_double" Gen.Double.[0.0,Double.MaxValue]
            (fun a -> sqrt(a*a*a))
            (fun a r -> Vml.Pow3o2(a.Length,a,r))

        testUnary "Pow3o2_mode_double" Gen.Double.[0.0,Double.MaxValue]
            (fun a -> sqrt(a*a*a))
            (fun a r -> Vml.Pow3o2(a.Length,a,r,VmlMode.HA))

        testUnary "Pow3o2_single" Gen.Single.[0.0f,Single.MaxValue]
            (fun a -> sqrt(a*a*a))
            (fun a r -> Vml.Pow3o2(a.Length,a,r))

        testUnary "Pow3o2_mode_single" Gen.Single.[0.0f,Single.MaxValue]
            (fun a -> sqrt(a*a*a))
            (fun a r -> Vml.Pow3o2(a.Length,a,r,VmlMode.HA))

        testBinary "Pow_double" Gen.Double
            (fun a b -> Math.Pow(a,b))
            (fun a b r -> Vml.Pow(a.Length,a,b,r))

        testBinary "Pow_mode_double" Gen.Double
            (fun a b -> Math.Pow(a,b))
            (fun a b r -> Vml.Pow(a.Length,a,b,r,VmlMode.HA))

        testBinary "Pow_single" Gen.Single
            (fun a b -> Math.Pow(float a,float b) |> float32)
            (fun a b r -> Vml.Pow(a.Length,a,b,r))

        testBinary "Pow_mode_single" Gen.Single
            (fun a b -> Math.Pow(float a,float b) |> float32)
            (fun a b r -> Vml.Pow(a.Length,a,b,r,VmlMode.HA))

        testBinary "Powr_double" Gen.Double.[0.0,Double.MaxValue]
            (fun a b -> Math.Pow(a,b))
            (fun a b r -> Vml.Powr(a.Length,a,b,r))

        testBinary "Powr_mode_double" Gen.Double.[0.0,Double.MaxValue]
            (fun a b -> Math.Pow(a,b))
            (fun a b r -> Vml.Powr(a.Length,a,b,r,VmlMode.HA))

        testBinary "Powr_single" Gen.Single.[0.0f,Single.MaxValue]
            (fun a b -> Math.Pow(float a,float b) |> float32)
            (fun a b r -> Vml.Powr(a.Length,a,b,r))

        testBinary "Powr_mode_single" Gen.Single.[0.0f,Single.MaxValue]
            (fun a b -> Math.Pow(float a,float b) |> float32)
            (fun a b r -> Vml.Powr(a.Length,a,b,r,VmlMode.HA))

        test "Powx_double" {
            let! a = Gen.Double.[0.0,Double.MaxValue].Array.[0,ARRAY_SIZE_MAX]
            let! b = Gen.Double
            let expected = Array.map (fun a -> Math.Pow(a,b)) a
            let actual = Array.zeroCreate a.Length
            Vml.Powx(a.Length,a,b,actual)
            Check.close High expected actual
            Vml.Powx(a.Length,a,b,actual,VmlMode.HA)
            Check.close High expected actual |> Check.message "mode"
            Vml.Powx(a.Length,a,b,a)
            Check.close High expected a |> Check.message "inplace"
        }

        test "Powx_single" {
            let! a = Gen.Single.[0.0f,Single.MaxValue].Array.[0,ARRAY_SIZE_MAX]
            let! b = Gen.Single
            let expected = Array.map (fun a -> Math.Pow(float a,float b) |> float32) a
            let actual = Array.zeroCreate a.Length
            Vml.Powx(a.Length,a,b,actual)
            Check.close High expected actual
            Vml.Powx(a.Length,a,b,actual,VmlMode.HA)
            Check.close High expected actual |> Check.message "mode"
            Vml.Powx(a.Length,a,b,a)
            Check.close High expected a |> Check.message "inplace"
        }
    }

let exponential =
    test "exponential" {
        testUnary "Exp_double" Gen.Double exp
            (fun a r -> Vml.Exp(a.Length,a,r))

        testUnary "Exp_mode_double" Gen.Double exp
            (fun a r -> Vml.Exp(a.Length,a,r,VmlMode.HA))

        testUnary "Exp_single" Gen.Single
            (float >> exp >> float32)
            (fun a r -> Vml.Exp(a.Length,a,r))

        testUnary "Exp_mode_single" Gen.Single
            (float >> exp >> float32)
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
            (fun i -> exp i-1.0)
            (fun a r -> Vml.Expm1(a.Length,a,r))

        testUnary "Expm1_mode_double" Gen.Double
            (fun i -> exp i-1.0)
            (fun a r -> Vml.Expm1(a.Length,a,r,VmlMode.HA))

        testUnary "Expm1_single" Gen.Single
            (fun i -> exp(float i)-1.0 |> float32)
            (fun a r -> Vml.Expm1(a.Length,a,r))

        testUnary "Expm1_mode_single" Gen.Single
            (fun i -> exp(float i)-1.0 |> float32)
            (fun a r -> Vml.Expm1(a.Length,a,r,VmlMode.HA))

        testUnary "Ln_double" Gen.Double log
            (fun a r -> Vml.Ln(a.Length,a,r))

        testUnary "Ln_mode_double" Gen.Double log
            (fun a r -> Vml.Ln(a.Length,a,r,VmlMode.HA))

        testUnary "Ln_single" Gen.Single
            (float >> log >> float32)
            (fun a r -> Vml.Ln(a.Length,a,r))

        testUnary "Ln_mode_single" Gen.Single
            (float >> log >> float32)
            (fun a r -> Vml.Ln(a.Length,a,r,VmlMode.HA))

#if NETCOREAPP
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

        testUnary "Log10_double" Gen.Double log10
            (fun a r -> Vml.Log10(a.Length,a,r))

        testUnary "Log10_mode_double" Gen.Double log10
            (fun a r -> Vml.Log10(a.Length,a,r,VmlMode.HA))

        testUnary "Log10_single" Gen.Single
            (float >> log10 >> float32)
            (fun a r -> Vml.Log10(a.Length,a,r))

        testUnary "Log10_mode_single" Gen.Single
            (float >> log10 >> float32)
            (fun a r -> Vml.Log10(a.Length,a,r,VmlMode.HA))

        testUnary "Log1p_double" Gen.Double
            (fun i -> log(i+1.0))
            (fun a r -> Vml.Log1p(a.Length,a,r))

        testUnary "Log1p_mode_double" Gen.Double
            (fun i -> log(i+1.0))
            (fun a r -> Vml.Log1p(a.Length,a,r,VmlMode.HA))

        testUnary "Log1p_single" Gen.Single
            (fun i -> log(float i+1.0) |> float32)
            (fun a r -> Vml.Log1p(a.Length,a,r))

        testUnary "Log1p_mode_single" Gen.Single
            (fun i -> log(float i+1.0) |> float32)
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
            cos
            (fun a r -> Vml.Cos(a.Length,a,r))

        testUnary "Cos_mode_double" Gen.Double.[-65536.0,65536.0]
            cos
            (fun a r -> Vml.Cos(a.Length,a,r,VmlMode.HA))

        testUnary "Cos_single" Gen.Single.[-8192.0f,8192.0f]
            (float >> cos >> float32)
            (fun a r -> Vml.Cos(a.Length,a,r))

        testUnary "Cos_mode_single" Gen.Single.[-8192.0f,8192.0f]
            (float >> cos >> float32)
            (fun a r -> Vml.Cos(a.Length,a,r,VmlMode.HA))

        testUnary "Sin_double" Gen.Double.[-65536.0,65536.0]
            sin
            (fun a r -> Vml.Sin(a.Length,a,r))

        testUnary "Sin_mode_double" Gen.Double.[-65536.0,65536.0]
            sin
            (fun a r -> Vml.Sin(a.Length,a,r,VmlMode.HA))

        testUnary "Sin_single" Gen.Single.[-8192.0f,8192.0f]
            (float >> sin >> float32)
            (fun a r -> Vml.Sin(a.Length,a,r))

        testUnary "Sin_mode_single" Gen.Single.[-8192.0f,8192.0f]
            (float >> sin >> float32)
            (fun a r -> Vml.Sin(a.Length,a,r,VmlMode.HA))

        testUnary "Tan_double" Gen.Double.[-1.0,1.0]
            tan
            (fun a r -> Vml.Tan(a.Length,a,r))

        testUnary "Tan_mode_double" Gen.Double.[-1.0,1.0]
            tan
            (fun a r -> Vml.Tan(a.Length,a,r,VmlMode.HA))

        testUnary "Tan_single" Gen.Single.[-1.0f,1.0f]
            (float >> tan >> float32)
            (fun a r -> Vml.Tan(a.Length,a,r))

        testUnary "Tan_mode_single" Gen.Single.[-1.0f,1.0f]
            (float >> tan >> float32)
            (fun a r -> Vml.Tan(a.Length,a,r,VmlMode.HA))

        testUnary "Cospi_double" Gen.Double.[-65536.0,65536.0]
            (fun i -> cos(Math.PI*i))
            (fun a r -> Vml.Cospi(a.Length,a,r))

        testUnary "Cospi_mode_double" Gen.Double.[-65536.0,65536.0]
            (fun i -> cos(Math.PI*i))
            (fun a r -> Vml.Cospi(a.Length,a,r,VmlMode.HA))

        testUnary "Cospi_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> cos(Math.PI*float i) |> float32)
            (fun a r -> Vml.Cospi(a.Length,a,r))

        testUnary "Cospi_mode_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> cos(Math.PI*float i) |> float32)
            (fun a r -> Vml.Cospi(a.Length,a,r,VmlMode.HA))

        testUnary "Sinpi_double" Gen.Double.[-65536.0,65536.0]
            (fun i -> sin(Math.PI*i))
            (fun a r -> Vml.Sinpi(a.Length,a,r))

        testUnary "Sinpi_mode_double" Gen.Double.[-65536.0,65536.0]
            (fun i -> sin(Math.PI*i))
            (fun a r -> Vml.Sinpi(a.Length,a,r,VmlMode.HA))

        testUnary "Sinpi_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> sin(Math.PI*float i) |> float32)
            (fun a r -> Vml.Sinpi(a.Length,a,r))

        testUnary "Sinpi_mode_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> sin(Math.PI*float i) |> float32)
            (fun a r -> Vml.Sinpi(a.Length,a,r,VmlMode.HA))

        testUnary "Tanpi_double" Gen.Double.[-0.3,0.3]
            (fun i -> tan(Math.PI*i))
            (fun a r -> Vml.Tanpi(a.Length,a,r))

        testUnary "Tanpi_mode_double" Gen.Double.[-0.3,0.3]
            (fun i -> tan(Math.PI*i))
            (fun a r -> Vml.Tanpi(a.Length,a,r,VmlMode.HA))

        testUnary "Tanpi_single" Gen.Single.[-0.3f,0.3f]
            (fun i -> tan(Math.PI*float i) |> float32)
            (fun a r -> Vml.Tanpi(a.Length,a,r))

        testUnary "Tanpi_mode_single" Gen.Single.[-0.3f,0.3f]
            (fun i -> tan(Math.PI*float i) |> float32)
            (fun a r -> Vml.Tanpi(a.Length,a,r,VmlMode.HA))

        testUnary "Cosd_double" Gen.Double.[-65536.0,65536.0]
            (fun i -> cos(Math.PI/180.0*i))
            (fun a r -> Vml.Cosd(a.Length,a,r))

        testUnary "Cosd_mode_double" Gen.Double.[-65536.0,65536.0]
            (fun i -> cos(Math.PI/180.0*i))
            (fun a r -> Vml.Cosd(a.Length,a,r,VmlMode.HA))

        testUnary "Cosd_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> cos(Math.PI/180.0*float i) |> float32)
            (fun a r -> Vml.Cosd(a.Length,a,r))

        testUnary "Cosd_mode_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> cos(Math.PI/180.0*float i) |> float32)
            (fun a r -> Vml.Cosd(a.Length,a,r,VmlMode.HA))

        testUnary "Sind_double" Gen.Double.[-65536.0,65536.0]
            (fun i -> sin(Math.PI/180.0*i))
            (fun a r -> Vml.Sind(a.Length,a,r))

        testUnary "Sind_mode_double" Gen.Double.[-65536.0,65536.0]
            (fun i -> sin(Math.PI/180.0*i))
            (fun a r -> Vml.Sind(a.Length,a,r,VmlMode.HA))

        testUnary "Sind_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> sin(Math.PI/180.0*float i) |> float32)
            (fun a r -> Vml.Sind(a.Length,a,r))

        testUnary "Sind_mode_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> sin(Math.PI/180.0*float i) |> float32)
            (fun a r -> Vml.Sind(a.Length,a,r,VmlMode.HA))

        testUnary "Tand_double" Gen.Double.[-57.0,57.0]
            (fun i -> tan(Math.PI/180.0*i))
            (fun a r -> Vml.Tand(a.Length,a,r))

        testUnary "Tand_mode_double" Gen.Double.[-57.0,57.0]
            (fun i -> tan(Math.PI/180.0*i))
            (fun a r -> Vml.Tand(a.Length,a,r,VmlMode.HA))

        testUnary "Tand_single" Gen.Single.[-57.0f,57.0f]
            (fun i -> tan(Math.PI/180.0*float i) |> float32)
            (fun a r -> Vml.Tand(a.Length,a,r))

        testUnary "Tand_mode_single" Gen.Single.[-57.0f,57.0f]
            (fun i -> tan(Math.PI/180.0*float i) |> float32)
            (fun a r -> Vml.Tand(a.Length,a,r,VmlMode.HA))

        testUnary "Acos_double" Gen.Double.[-1.0,1.0]
            acos
            (fun a r -> Vml.Acos(a.Length,a,r))

        testUnary "Acos_mode_double" Gen.Double.[-1.0,1.0]
            acos
            (fun a r -> Vml.Acos(a.Length,a,r,VmlMode.HA))

        testUnary "Acos_single" Gen.Single.[-1.0f,1.0f]
            (float >> acos >> float32)
            (fun a r -> Vml.Acos(a.Length,a,r))

        testUnary "Acos_mode_single" Gen.Single.[-1.0f,1.0f]
            (float >> acos >> float32)
            (fun a r -> Vml.Acos(a.Length,a,r,VmlMode.HA))

        testUnary "Asin_double" Gen.Double.[-1.0,1.0]
            asin
            (fun a r -> Vml.Asin(a.Length,a,r))

        testUnary "Asin_mode_double" Gen.Double.[-1.0,1.0]
            asin
            (fun a r -> Vml.Asin(a.Length,a,r,VmlMode.HA))

        testUnary "Asin_single" Gen.Single.[-1.0f,1.0f]
            (float >> asin >> float32)
            (fun a r -> Vml.Asin(a.Length,a,r))

        testUnary "Asin_mode_single" Gen.Single.[-1.0f,1.0f]
            (float >> asin >> float32)
            (fun a r -> Vml.Asin(a.Length,a,r,VmlMode.HA))

        testUnary "Atan_double" Gen.Double
            atan
            (fun a r -> Vml.Atan(a.Length,a,r))

        testUnary "Atan_mode_double" Gen.Double
            atan
            (fun a r -> Vml.Atan(a.Length,a,r,VmlMode.HA))

        testUnary "Atan_single" Gen.Single
            (float >> atan >> float32)
            (fun a r -> Vml.Atan(a.Length,a,r))

        testUnary "Atan_mode_single" Gen.Single
            (float >> atan >> float32)
            (fun a r -> Vml.Atan(a.Length,a,r,VmlMode.HA))

        testUnary "Acospi_double" Gen.Double.[-1.0,1.0]
            (fun i -> acos(i) / Math.PI)
            (fun a r -> Vml.Acospi(a.Length,a,r))

        testUnary "Acospi_mode_double" Gen.Double.[-1.0,1.0]
            (fun i -> acos(i) / Math.PI)
            (fun a r -> Vml.Acospi(a.Length,a,r,VmlMode.HA))

        testUnary "Acospi_single" Gen.Single.[-1.0f,1.0f]
            (fun i -> acos(float i) / Math.PI |> float32)
            (fun a r -> Vml.Acospi(a.Length,a,r))

        testUnary "Acospi_mode_single" Gen.Single.[-1.0f,1.0f]
            (fun i -> acos(float i) / Math.PI |> float32)
            (fun a r -> Vml.Acospi(a.Length,a,r,VmlMode.HA))

        testUnary "Asinpi_double" Gen.Double.[-1.0,1.0]
            (fun i -> asin(i) / Math.PI)
            (fun a r -> Vml.Asinpi(a.Length,a,r))

        testUnary "Asinpi_mode_double" Gen.Double.[-1.0,1.0]
            (fun i -> asin(i) / Math.PI)
            (fun a r -> Vml.Asinpi(a.Length,a,r,VmlMode.HA))

        testUnary "Asinpi_single" Gen.Single.[-1.0f,1.0f]
            (fun i -> asin(float i) / Math.PI |> float32)
            (fun a r -> Vml.Asinpi(a.Length,a,r))

        testUnary "Asinpi_mode_single" Gen.Single.[-1.0f,1.0f]
            (fun i -> asin(float i) / Math.PI |> float32)
            (fun a r -> Vml.Asinpi(a.Length,a,r,VmlMode.HA))

        testUnary "Atanpi_double" Gen.Double
            (fun i -> atan(i) / Math.PI)
            (fun a r -> Vml.Atanpi(a.Length,a,r))

        testUnary "Atanpi_mode_double" Gen.Double
            (fun i -> atan(i) / Math.PI)
            (fun a r -> Vml.Atanpi(a.Length,a,r,VmlMode.HA))

        testUnary "Atanpi_single" Gen.Single
            (fun i -> atan(float i) / Math.PI |> float32)
            (fun a r -> Vml.Atanpi(a.Length,a,r))

        testUnary "Atanpi_mode_single" Gen.Single
            (fun i -> atan(float i) / Math.PI |> float32)
            (fun a r -> Vml.Atanpi(a.Length,a,r,VmlMode.HA))

        testBinary "Atan2_double" Gen.Double
            atan2
            (fun a b r -> Vml.Atan2(a.Length,a,b,r))

        testBinary "Atan2_mode_double" Gen.Double
            atan2
            (fun a b r -> Vml.Atan2(a.Length,a,b,r,VmlMode.HA))

        testBinary "Atan2_single" Gen.Single
            (fun a b -> atan2 (float a) (float b) |> float32)
            (fun a b r -> Vml.Atan2(a.Length,a,b,r))

        testBinary "Atan2_mode_single" Gen.Single
            (fun a b -> atan2 (float a) (float b) |> float32)
            (fun a b r -> Vml.Atan2(a.Length,a,b,r,VmlMode.HA))

        testBinary "Atan2pi_double" Gen.Double
            (fun a b -> atan2 a b / Math.PI)
            (fun a b r -> Vml.Atan2pi(a.Length,a,b,r))

        testBinary "Atan2pi_mode_double" Gen.Double
            (fun a b -> atan2 a b / Math.PI)
            (fun a b r -> Vml.Atan2pi(a.Length,a,b,r,VmlMode.HA))

        testBinary "Atan2pi_single" Gen.Single
            (fun a b -> atan2 (float a) (float b) / Math.PI |> float32)
            (fun a b r -> Vml.Atan2pi(a.Length,a,b,r))

        testBinary "Atan2pi_mode_single" Gen.Single
            (fun a b -> atan2 (float a) (float b) / Math.PI |> float32)
            (fun a b r -> Vml.Atan2pi(a.Length,a,b,r,VmlMode.HA))

        test "SinCos_double" {
            let! a = Gen.Double.[-65536.0,65536.0].Array.[0,ARRAY_SIZE_MAX]
            let expected1 = Array.map sin a
            let expected2 = Array.map cos a
            let actual1 = Array.zeroCreate a.Length
            let actual2 = Array.zeroCreate a.Length
            Vml.SinCos(a.Length,a,actual1,actual2)
            Check.close High expected1 actual1 |> Check.message "sin"
            Check.close High expected2 actual2 |> Check.message "sin"
            Vml.SinCos(a.Length,a,actual1,actual2,VmlMode.HA)
            Check.close High expected1 actual1 |> Check.message "mode_sin"
            Check.close High expected2 actual2 |> Check.message "mode_sin"
            Vml.SinCos(a.Length,a,a,actual2)
            Check.close High expected1 a |> Check.message "inplace"
        }

        test "SinCos_single" {
            let! a = Gen.Single.[-8192.0f,8192.0f].Array.[0,ARRAY_SIZE_MAX]
            let expected1 = Array.map sin a
            let expected2 = Array.map cos a
            let actual1 = Array.zeroCreate a.Length
            let actual2 = Array.zeroCreate a.Length
            Vml.SinCos(a.Length,a,actual1,actual2)
            Check.close High expected1 actual1 |> Check.message "sin"
            Check.close High expected2 actual2 |> Check.message "sin"
            Vml.SinCos(a.Length,a,actual1,actual2,VmlMode.HA)
            Check.close High expected1 actual1 |> Check.message "mode_sin"
            Check.close High expected2 actual2 |> Check.message "mode_sin"
            Vml.SinCos(a.Length,a,a,actual2)
            Check.close High expected1 a |> Check.message "inplace"
        }
    }

let hyperbolic =
    test "hyperbolic" {
        testUnary "Cosh_double" Gen.Double
            cosh
            (fun a r -> Vml.Cosh(a.Length,a,r))

        testUnary "Cosh_mode_double" Gen.Double
            cosh
            (fun a r -> Vml.Cosh(a.Length,a,r,VmlMode.HA))

        testUnary "Cosh_single" Gen.Single
            (float >> cosh >> float32)
            (fun a r -> Vml.Cosh(a.Length,a,r))

        testUnary "Cosh_mode_single" Gen.Single
            (float >> cosh >> float32)
            (fun a r -> Vml.Cosh(a.Length,a,r,VmlMode.HA))

        testUnary "Sinh_double" Gen.Double
            sinh
            (fun a r -> Vml.Sinh(a.Length,a,r))

        testUnary "Sinh_mode_double" Gen.Double
            sinh
            (fun a r -> Vml.Sinh(a.Length,a,r,VmlMode.HA))

        testUnary "Sinh_single" Gen.Single
            (float >> sinh >> float32)
            (fun a r -> Vml.Sinh(a.Length,a,r))

        testUnary "Sinh_mode_single" Gen.Single
            (float >> sinh >> float32)
            (fun a r -> Vml.Sinh(a.Length,a,r,VmlMode.HA))

        testUnary "Tanh_double" Gen.Double
            tanh
            (fun a r -> Vml.Tanh(a.Length,a,r))

        testUnary "Tanh_mode_double" Gen.Double
            tanh
            (fun a r -> Vml.Tanh(a.Length,a,r,VmlMode.HA))

        testUnary "Tanh_single" Gen.Single
            (float >> tanh >> float32)
            (fun a r -> Vml.Tanh(a.Length,a,r))

        testUnary "Tanh_mode_single" Gen.Single
            (float >> tanh >> float32)
            (fun a r -> Vml.Tanh(a.Length,a,r,VmlMode.HA))

#if NETCOREAPP
        testUnary "Acosh_double" Gen.Double.[1.0,Double.MaxValue]
            Math.Acosh
            (fun a r -> Vml.Acosh(a.Length,a,r))

        testUnary "Acosh_mode_double" Gen.Double.[1.0,Double.MaxValue]
            Math.Acosh
            (fun a r -> Vml.Acosh(a.Length,a,r,VmlMode.HA))

        testUnary "Acosh_single" Gen.Single.[1.0f,Single.MaxValue]
            (float >> Math.Acosh >> float32)
            (fun a r -> Vml.Acosh(a.Length,a,r))

        testUnary "Acosh_mode_single" Gen.Single.[1.0f,Single.MaxValue]
            (float >> Math.Acosh >> float32)
            (fun a r -> Vml.Acosh(a.Length,a,r,VmlMode.HA))

        testUnary "Asinh_double" Gen.Double
            Math.Asinh
            (fun a r -> Vml.Asinh(a.Length,a,r))

        testUnary "Asinh_mode_double" Gen.Double
            Math.Asinh
            (fun a r -> Vml.Asinh(a.Length,a,r,VmlMode.HA))

        testUnary "Asinh_single" Gen.Single
            (float >> Math.Asinh >> float32)
            (fun a r -> Vml.Asinh(a.Length,a,r))

        testUnary "Asinh_mode_single" Gen.Single
            (float >> Math.Asinh >> float32)
            (fun a r -> Vml.Asinh(a.Length,a,r,VmlMode.HA))

        testUnary "Atanh_double" Gen.Double.[-1.0,1.0]
            Math.Atanh
            (fun a r -> Vml.Atanh(a.Length,a,r))

        testUnary "Atanh_mode_double" Gen.Double.[-1.0,1.0]
            Math.Atanh
            (fun a r -> Vml.Atanh(a.Length,a,r,VmlMode.HA))

        testUnary "Atanh_single" Gen.Single.[-1.0f,1.0f]
            (float >> Math.Atanh >> float32)
            (fun a r -> Vml.Atanh(a.Length,a,r))

        testUnary "Atanh_mode_single" Gen.Single.[-1.0f,1.0f]
            (float >> Math.Atanh >> float32)
            (fun a r -> Vml.Atanh(a.Length,a,r,VmlMode.HA))
#endif
    }

let special =
    test "special" {
        ()
        // Erf
        // Erfc
        // CdfNorm
        // ErfInv
        // ErfcInv
        // CdfNormInv
        // LGamma
        // TGamma
        // ExpInt1
    }

let rounding =
    test "rounding" {

        testUnary "Floor_double" Gen.Double
            floor
            (fun a r -> Vml.Floor(a.Length,a,r))

        testUnary "Floor_mode_double" Gen.Double
            floor
            (fun a r -> Vml.Floor(a.Length,a,r,VmlMode.HA))

        testUnary "Floor_single" Gen.Single
            (float >> floor >> float32)
            (fun a r -> Vml.Floor(a.Length,a,r))

        testUnary "Floor_mode_single" Gen.Single
            (float >> floor >> float32)
            (fun a r -> Vml.Floor(a.Length,a,r,VmlMode.HA))

        testUnary "Ceil_double" Gen.Double
            ceil
            (fun a r -> Vml.Ceil(a.Length,a,r))

        testUnary "Ceil_mode_double" Gen.Double
            ceil
            (fun a r -> Vml.Ceil(a.Length,a,r,VmlMode.HA))

        testUnary "Ceil_single" Gen.Single
            (float >> ceil >> float32)
            (fun a r -> Vml.Ceil(a.Length,a,r))

        testUnary "Ceil_mode_single" Gen.Single
            (float >> ceil >> float32)
            (fun a r -> Vml.Ceil(a.Length,a,r,VmlMode.HA))

        testUnary "Trunc_double" Gen.Double
            truncate
            (fun a r -> Vml.Trunc(a.Length,a,r))

        testUnary "Trunc_mode_double" Gen.Double
            truncate
            (fun a r -> Vml.Trunc(a.Length,a,r,VmlMode.HA))

        testUnary "Trunc_single" Gen.Single
            truncate
            (fun a r -> Vml.Trunc(a.Length,a,r))

        testUnary "Trunc_mode_single" Gen.Single
            truncate
            (fun a r -> Vml.Trunc(a.Length,a,r,VmlMode.HA))

        testUnary "Round_double" Gen.Double
            (fun a -> Math.Round(a, MidpointRounding.AwayFromZero))
            (fun a r -> Vml.Round(a.Length,a,r))

        testUnary "Round_mode_double" Gen.Double
            (fun a -> Math.Round(a, MidpointRounding.AwayFromZero))
            (fun a r -> Vml.Round(a.Length,a,r,VmlMode.HA))

        testUnary "Round_single" Gen.Single
            (fun a -> Math.Round(float a, MidpointRounding.AwayFromZero) |> float32)
            (fun a r -> Vml.Round(a.Length,a,r))

        testUnary "Round_mode_single" Gen.Single
            (fun a -> Math.Round(float a, MidpointRounding.AwayFromZero) |> float32)
            (fun a r -> Vml.Round(a.Length,a,r,VmlMode.HA))

        testUnary "Frac_double" Gen.Double
            (fun a -> a - truncate a)
            (fun a r -> Vml.Frac(a.Length,a,r))

        testUnary "Frac_mode_double" Gen.Double
            (fun a -> a - truncate a)
            (fun a r -> Vml.Frac(a.Length,a,r,VmlMode.HA))

        testUnary "Frac_single" Gen.Single
            (fun a -> a - truncate a)
            (fun a r -> Vml.Frac(a.Length,a,r))

        testUnary "Frac_mode_single" Gen.Single
            (fun a -> a - truncate a)
            (fun a r -> Vml.Frac(a.Length,a,r,VmlMode.HA))

        testUnary "NearbyInt_double" Gen.Double
            (fun a -> Math.Round(a, MidpointRounding.ToEven))
            (fun a r -> Vml.NearbyInt(a.Length,a,r))

        testUnary "NearbyInt_mode_double" Gen.Double
            (fun a -> Math.Round(a, MidpointRounding.ToEven))
            (fun a r -> Vml.NearbyInt(a.Length,a,r,VmlMode.HA))

        testUnary "NearbyInt_single" Gen.Single
            (fun a -> Math.Round(float a, MidpointRounding.ToEven) |> float32)
            (fun a r -> Vml.NearbyInt(a.Length,a,r))

        testUnary "NearbyInt_mode_single" Gen.Single
            (fun a -> Math.Round(float a, MidpointRounding.ToEven) |> float32)
            (fun a r -> Vml.NearbyInt(a.Length,a,r,VmlMode.HA))

        testUnary "Rint_double" Gen.Double
            (fun a -> Math.Round(a, MidpointRounding.ToEven))
            (fun a r -> Vml.Rint(a.Length,a,r))

        testUnary "Rint_mode_double" Gen.Double
            (fun a -> Math.Round(a, MidpointRounding.ToEven))
            (fun a r -> Vml.Rint(a.Length,a,r,VmlMode.HA))

        testUnary "Rint_single" Gen.Single
            (fun a -> Math.Round(float a, MidpointRounding.ToEven) |> float32)
            (fun a r -> Vml.Rint(a.Length,a,r))

        testUnary "Rint_mode_single" Gen.Single
            (fun a -> Math.Round(float a, MidpointRounding.ToEven) |> float32)
            (fun a r -> Vml.Rint(a.Length,a,r,VmlMode.HA))

        test "Modf_double" {
            let! a = Gen.Double.Array.[0,ARRAY_SIZE_MAX]
            let expected1 = Array.map truncate a
            let expected2 = Array.map (fun a -> a - truncate a) a
            let actual1 = Array.zeroCreate a.Length
            let actual2 = Array.zeroCreate a.Length
            Vml.Modf(a.Length,a,actual1,actual2)
            Check.close High expected1 actual1 |> Check.message "int"
            Check.close High expected2 actual2 |> Check.message "fra"
            Vml.Modf(a.Length,a,actual1,actual2,VmlMode.HA)
            Check.close High expected1 actual1 |> Check.message "mode_int"
            Check.close High expected2 actual2 |> Check.message "mode_fra"
            Vml.Modf(a.Length,a,a,actual2)
            Check.close High expected1 a |> Check.message "inplace"
        }

        test "Modf_single" {
            let! a = Gen.Single.Array.[0,ARRAY_SIZE_MAX]
            let expected1 = Array.map truncate a
            let expected2 = Array.map (fun a -> a - truncate a) a
            let actual1 = Array.zeroCreate a.Length
            let actual2 = Array.zeroCreate a.Length
            Vml.Modf(a.Length,a,actual1,actual2)
            Check.close High expected1 actual1 |> Check.message "int"
            Check.close High expected2 actual2 |> Check.message "fra"
            Vml.Modf(a.Length,a,actual1,actual2,VmlMode.HA)
            Check.close High expected1 actual1 |> Check.message "mode_int"
            Check.close High expected2 actual2 |> Check.message "mode_fra"
            Vml.Modf(a.Length,a,a,actual2)
            Check.close High expected1 a |> Check.message "inplace"
        }
    }

let miscellaneous =
    test "miscellaneous" {
#if NETCOREAPP
        testBinary "CopySign_double" Gen.Double
            (fun a b -> Math.CopySign(a,b))
            (fun a b r -> Vml.CopySign(a.Length,a,b,r))

        testBinary "CopySign_mode_double" Gen.Double
            (fun a b -> Math.CopySign(a,b))
            (fun a b r -> Vml.CopySign(a.Length,a,b,r,VmlMode.HA))

        testBinary "CopySign_single" Gen.Single
            (fun a b -> Math.CopySign(float a, float b) |> float32)
            (fun a b r -> Vml.CopySign(a.Length,a,b,r))

        testBinary "CopySign_mode_single" Gen.Single
            (fun a b -> Math.CopySign(float a, float b) |> float32)
            (fun a b r -> Vml.CopySign(a.Length,a,b,r,VmlMode.HA))
#endif

        testBinary "Fmax_double" Gen.Double.Normal
            (fun a b -> Math.Max(a,b))
            (fun a b r -> Vml.Fmax(a.Length,a,b,r))

        testBinary "Fmax_mode_double" Gen.Double.Normal
            (fun a b -> Math.Max(a,b))
            (fun a b r -> Vml.Fmax(a.Length,a,b,r,VmlMode.HA))

        testBinary "Fmax_single" Gen.Single.Normal
            (fun a b -> Math.Max(a,b))
            (fun a b r -> Vml.Fmax(a.Length,a,b,r))

        testBinary "Fmax_mode_single" Gen.Single.Normal
            (fun a b -> Math.Max(a,b))
            (fun a b r -> Vml.Fmax(a.Length,a,b,r,VmlMode.HA))

        testBinary "Fmin_double" Gen.Double.Normal
            (fun a b -> Math.Min(a,b))
            (fun a b r -> Vml.Fmin(a.Length,a,b,r))

        testBinary "Fmin_mode_double" Gen.Double.Normal
            (fun a b -> Math.Min(a,b))
            (fun a b r -> Vml.Fmin(a.Length,a,b,r,VmlMode.HA))

        testBinary "Fmin_single" Gen.Single.Normal
            (fun a b -> Math.Min(a,b))
            (fun a b r -> Vml.Fmin(a.Length,a,b,r))

        testBinary "Fmin_mode_single" Gen.Single.Normal
            (fun a b -> Math.Min(a,b))
            (fun a b r -> Vml.Fmin(a.Length,a,b,r,VmlMode.HA))

        testBinary "Fdim_double" Gen.Double.Normal
            (fun a b -> max (a-b) 0.0)
            (fun a b r -> Vml.Fdim(a.Length,a,b,r))

        testBinary "Fdim_mode_double" Gen.Double.Normal
            (fun a b -> max (a-b) 0.0)
            (fun a b r -> Vml.Fdim(a.Length,a,b,r,VmlMode.HA))

        testBinary "Fdim_single" Gen.Single.Normal
            (fun a b -> max (a-b) 0.0f)
            (fun a b r -> Vml.Fdim(a.Length,a,b,r))

        testBinary "Fdim_mode_single" Gen.Single.Normal
            (fun a b -> max (a-b) 0.0f)
            (fun a b r -> Vml.Fdim(a.Length,a,b,r,VmlMode.HA))

        testBinary "MaxMag_double" Gen.Double.Normal
            (fun a b -> if abs a > abs b then a
                        elif abs a < abs b then b
                        else max a b)
            (fun a b r -> Vml.MaxMag(a.Length,a,b,r))

        testBinary "MaxMag_mode_double" Gen.Double.Normal
            (fun a b -> if abs a > abs b then a
                        elif abs a < abs b then b
                        else max a b)
            (fun a b r -> Vml.MaxMag(a.Length,a,b,r,VmlMode.HA))

        testBinary "MaxMag_single" Gen.Single.Normal
            (fun a b -> if abs a > abs b then a
                        elif abs a < abs b then b
                        else max a b)
            (fun a b r -> Vml.MaxMag(a.Length,a,b,r))

        testBinary "MaxMag_mode_single" Gen.Single.Normal
            (fun a b -> if abs a > abs b then a
                        elif abs a < abs b then b
                        else max a b)
            (fun a b r -> Vml.MaxMag(a.Length,a,b,r,VmlMode.HA))

        testBinary "MinMag_double" Gen.Double.Normal
            (fun a b -> if abs a < abs b then a
                        elif abs a > abs b then b
                        else min a b)
            (fun a b r -> Vml.MinMag(a.Length,a,b,r))

        testBinary "MinMag_mode_double" Gen.Double.Normal
            (fun a b -> if abs a < abs b then a
                        elif abs a > abs b then b
                        else min a b)
            (fun a b r -> Vml.MinMag(a.Length,a,b,r,VmlMode.HA))

        testBinary "MinMag_single" Gen.Single.Normal
            (fun a b -> if abs a < abs b then a
                        elif abs a > abs b then b
                        else min a b)
            (fun a b r -> Vml.MinMag(a.Length,a,b,r))

        testBinary "MinMag_mode_single" Gen.Single.Normal
            (fun a b -> if abs a < abs b then a
                        elif abs a > abs b then b
                        else min a b)
            (fun a b r -> Vml.MinMag(a.Length,a,b,r,VmlMode.HA))

#if NETCOREAPP
        testBinary "NextAfter_double" Gen.Double.Normal
            (fun a b -> if b > 0.0 then Math.BitIncrement(a)
                                   else Math.BitDecrement(a))
            (fun a b r -> Vml.NextAfter(a.Length,a,b,r))

        testBinary "NextAfter_mode_double" Gen.Double.Normal
            (fun a b -> if b > 0.0 then Math.BitIncrement(a)
                                   else Math.BitDecrement(a))
            (fun a b r -> Vml.NextAfter(a.Length,a,b,r,VmlMode.HA))

        testBinary "NextAfter_single" Gen.Single.Normal
            (fun a b -> if b > 0.0f then Math.BitIncrement(float a) |> float32
                                    else Math.BitDecrement(float a) |> float32)
            (fun a b r -> Vml.NextAfter(a.Length,a,b,r))

        testBinary "NextAfter_mode_single" Gen.Single.Normal
            (fun a b -> if b > 0.0f then Math.BitIncrement(float a) |> float32
                                    else Math.BitDecrement(float a) |> float32)
            (fun a b r -> Vml.NextAfter(a.Length,a,b,r,VmlMode.HA))
#endif
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
    }