module VmlTests

open System
open MKLNET
open CsCheck

let ROWS_MAX = 5

let testUnary name (gen:Gen<'a>)
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

let testUnaryM name (gen:Gen<'a>)
        (fexpected:'a -> 'a)
        (factual:'a[]*'a[]*VmlMode -> unit) =
    testUnary name gen fexpected
        (fun (a,r) -> factual(a,r,VmlMode.HA))

let testBinary name (gen:Gen<'a>)
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

let testBinaryM name (gen:Gen<'a>)
    (fexpected:'a -> 'a -> 'a)
    (factual:'a[]*'a[]*'a[]*VmlMode -> unit) =
    testBinary name gen fexpected
        (fun (a,b,r) -> factual(a,b,r,VmlMode.HA))

let testUnaryI name (gen:Gen<'a>)
        (fexpected:'a -> 'a)
        (factual:(int*'a[]*int*int*'a[]*int*int) -> unit) =
    test name {
        let! cols = Gen.Int.[1,3]
        let! ini = Gen.Int.[0,cols-1]
        let! rows = Gen.Int.[1,ROWS_MAX]
        let! a = (GenArray gen).[rows*cols]
        let actual = Array.copy a
        factual(a.Length/cols,a,ini,cols,actual,ini,cols)
        let expected = Array.mapi (fun i a -> if i % cols = ini then fexpected a else a) a
        Check.close High expected actual
        factual(a.Length/cols,a,ini,cols,a,ini,cols)
        Check.close High expected a |> Check.message "inplace"
    }

let testUnaryIM name (gen:Gen<'a>)
        (fexpected:'a -> 'a)
        (factual:(int*'a[]*int*int*'a[]*int*int*VmlMode) -> unit) =
    testUnaryI name gen fexpected
        (fun (n,a,ia,sa,r,ir,sr) -> factual(n,a,ia,sa,r,ir,sr,VmlMode.HA))

let testUnaryX name (gen:Gen<'a>)
        (factual:'a[]*'a[] -> unit)
        (factualM:'a[]*'a[]*VmlMode -> unit)
        (factualI:(int*'a[]*int*int*'a[]*int*int) -> unit)
        (factualIM:(int*'a[]*int*int*'a[]*int*int*VmlMode) -> unit)
        (fexpected:'a -> 'a)
        =
        test name {
            testUnary "N" gen fexpected factual
            testUnaryM "M" gen fexpected factualM
            testUnaryI "I" gen fexpected factualI
            testUnaryIM "IM" gen fexpected factualIM
        }


let testBinaryI name (gen:Gen<'a>)
        (fexpected:'a -> 'a -> 'a)
        (factual:(int*'a[]*int*int*'a[]*int*int*'a[]*int*int) -> unit) =
    test name {
        let gena = GenArray gen
        let! cols = Gen.Int.[1,3]
        let! ini = Gen.Int.[0,cols-1]
        let! rows = Gen.Int.[1,ROWS_MAX]
        let! a = gena.[rows*cols]
        let! b = gena.[a.Length]
        let actual = Array.copy a
        factual(a.Length/cols,a,ini,cols,b,ini,cols,actual,ini,cols)
        let expected = Array.mapi2 (fun i a b -> if i % cols = ini then fexpected a b else a) a b
        Check.close High expected actual
        factual(a.Length/cols,a,ini,cols,b,ini,cols,a,ini,cols)
        Check.close High expected a |> Check.message "inplace"
    }

let testBinaryIM name (gen:Gen<'a>)
        (fexpected:'a -> 'a -> 'a)
        (factual:(int*'a[]*int*int*'a[]*int*int*'a[]*int*int*VmlMode) -> unit) =
    testBinaryI name gen fexpected
        (fun (n,a,ia,sa,b,ib,sb,r,ir,sr) -> factual(n,a,ia,sa,b,ib,sb,r,ir,sr,VmlMode.HA))

let testBinaryX name (gen:Gen<'a>)
    (factualN:'a[]*'a[]*'a[] -> unit)
    (factualM:'a[]*'a[]*'a[]*VmlMode -> unit)
    (factualI:(int*'a[]*int*int*'a[]*int*int*'a[]*int*int) -> unit)
    (factualB:(int*'a[]*int*int*'a[]*int*int*'a[]*int*int*VmlMode) -> unit)
    (fexpected:'a -> 'a -> 'a)
    =
    test name {
        testBinary "N" gen fexpected factualN
        testBinaryM "M" gen fexpected factualM
        testBinaryI "I" gen fexpected factualI
        testBinaryIM "B" gen fexpected factualB
    }

let arithmetic =
    test "arithmetic" {

        testUnaryX "Abs_double" Gen.Double
            Vml.Abs Vml.Abs Vml.Abs Vml.Abs
            abs

        testUnaryX "Abs_single" Gen.Single
            Vml.Abs Vml.Abs Vml.Abs Vml.Abs
            abs

        testBinaryX "Add_double" Gen.Double
            Vml.Add Vml.Add Vml.Add Vml.Add
            (+)

        testBinaryX "Add_single" Gen.Single
            Vml.Add Vml.Add Vml.Add Vml.Add
            (+)

        testBinaryX "Sub_double" Gen.Double
            Vml.Sub Vml.Sub Vml.Sub Vml.Sub
            (-)

        testBinaryX "Sub_single" Gen.Single
            Vml.Sub Vml.Sub Vml.Sub Vml.Sub
            (-)

        testUnaryX "Sqr_double" Gen.Double
            Vml.Sqr Vml.Sqr Vml.Sqr Vml.Sqr
            (fun i -> i * i)

        testUnaryX "Sqr_single" Gen.Single
            Vml.Sqr Vml.Sqr Vml.Sqr Vml.Sqr
            (fun i -> i * i)

        testBinaryX "Mul_double" Gen.Double
            Vml.Mul Vml.Mul Vml.Mul Vml.Mul
            (*)

        testBinaryX "Mul_single" Gen.Single
            Vml.Mul Vml.Mul Vml.Mul Vml.Mul
            (*)

        testBinaryX "Fmod_double" Gen.Double.[0.01,10000.0]
            Vml.Fmod Vml.Fmod Vml.Fmod Vml.Fmod
            (fun a b -> a - Math.Truncate(a/b) * b)

        testBinaryX "Fmod_single" Gen.Single.[0.01f,10000.0f]
            Vml.Fmod Vml.Fmod Vml.Fmod Vml.Fmod
            (fun a b -> float a - Math.Truncate(float a/float b) * float b |> float32)

        testBinaryX "Remainder_double" Gen.Double.[0.01,10000.0]
            Vml.Remainder Vml.Remainder Vml.Remainder Vml.Remainder
            (fun a b -> a - Math.Round(a/b) * b)

        testBinaryX "Remainder_single" Gen.Single.[0.01f,10000.0f]
            Vml.Remainder Vml.Remainder Vml.Remainder Vml.Remainder
            (fun a b -> float a - Math.Round(float a/float b) * float b |> float32)
    }

let power =
    test "power" {
        testUnary "Inv_double" Gen.Double ((/) 1.0) Vml.Inv

        testUnaryM "Inv_mode_double" Gen.Double ((/) 1.0) Vml.Inv

        testUnary "Inv_single" Gen.Single ((/) 1.0f) Vml.Inv

        testUnaryM "Inv_mode_single" Gen.Single ((/) 1.0f) Vml.Inv

        testUnary "Sqrt_double" Gen.Double sqrt Vml.Sqrt

        testUnaryM "Sqrt_mode_double" Gen.Double sqrt Vml.Sqrt

        testUnary "Sqrt_single" Gen.Single
            (float >> sqrt >> float32)
            Vml.Sqrt

        testUnaryM "Sqrt_mode_single" Gen.Single
            (float >> sqrt >> float32)
            Vml.Sqrt

        testUnary "InvSqrt_double" Gen.Double
            ((/) 1.0 >> sqrt)
            Vml.InvSqrt

        testUnaryM "InvSqrt_mode_double" Gen.Double
            ((/) 1.0 >> sqrt)
            Vml.InvSqrt

        testUnary "InvSqrt_single" Gen.Single
            (float >> (/) 1.0 >> sqrt >> float32)
            Vml.InvSqrt

        testUnaryM "InvSqrt_mode_single" Gen.Single
            (float >> (/) 1.0 >> sqrt >> float32)
            Vml.InvSqrt

#if NETCOREAPP
        testUnary "Cbrt_double" Gen.Double Math.Cbrt
            Vml.Cbrt

        testUnaryM "Cbrt_mode_double" Gen.Double Math.Cbrt
            Vml.Cbrt

        testUnary "Cbrt_single" Gen.Single
            (float >> Math.Cbrt >> float32)
            Vml.Cbrt

        testUnaryM "Cbrt_mode_single" Gen.Single
            (float >> Math.Cbrt >> float32)
            Vml.Cbrt

        testUnary "InvCbrt_double" Gen.Double
            ((/) 1.0 >> Math.Cbrt)
            Vml.InvCbrt

        testUnaryM "InvCbrt_mode_double" Gen.Double
            ((/) 1.0 >> Math.Cbrt)
            Vml.InvCbrt

        testUnary "InvCbrt_single" Gen.Single
            (float >> (/) 1.0 >> Math.Cbrt >> float32)
            Vml.InvCbrt

        testUnaryM "InvCbrt_mode_single" Gen.Single
            (float >> (/) 1.0 >> Math.Cbrt >> float32)
            Vml.InvCbrt
#endif
        testBinary "Hypot_double" Gen.Double
            (fun a b -> sqrt(a*a+b*b))
            Vml.Hypot

        testBinaryM "Hypot_mode_double" Gen.Double
            (fun a b -> sqrt(a*a+b*b))
            Vml.Hypot

        testBinary "Hypot_single" Gen.Single
            (fun a b -> sqrt(a*a+b*b))
            Vml.Hypot

        testBinaryM "Hypot_mode_single" Gen.Single
            (fun a b -> sqrt(a*a+b*b))
            Vml.Hypot

        testBinary "Div_double" Gen.Double (/)
            Vml.Div

        testBinaryM "Div_mode_double" Gen.Double (/)
            Vml.Div

        testBinary "Div_single" Gen.Single (/)
            Vml.Div

        testBinaryM "Div_mode_single" Gen.Single (/)
            Vml.Div

#if NETCOREAPP
        testUnary "Pow2o3_double" Gen.Double
            (fun a -> Math.Cbrt(a*a))
            Vml.Pow2o3

        testUnaryM "Pow2o3_mode_double" Gen.Double
            (fun a -> Math.Cbrt(a*a))
            Vml.Pow2o3

        testUnary "Pow2o3_single" Gen.Single
            (fun a -> Math.Cbrt(float a*float a) |> float32)
            Vml.Pow2o3

        testUnaryM "Pow2o3_mode_single" Gen.Single
            (fun a -> Math.Cbrt(float a*float a) |> float32)
            Vml.Pow2o3
#endif

        testUnary "Pow3o2_double" Gen.Double.[0.0,Double.MaxValue]
            (fun a -> sqrt(a*a*a))
            Vml.Pow3o2

        testUnaryM "Pow3o2_mode_double" Gen.Double.[0.0,Double.MaxValue]
            (fun a -> sqrt(a*a*a))
            Vml.Pow3o2

        testUnary "Pow3o2_single" Gen.Single.[0.0f,Single.MaxValue]
            (fun a -> sqrt(a*a*a))
            Vml.Pow3o2

        testUnaryM "Pow3o2_mode_single" Gen.Single.[0.0f,Single.MaxValue]
            (fun a -> sqrt(a*a*a))
            Vml.Pow3o2

        testBinary "Pow_double" Gen.Double
            (fun a b -> Math.Pow(a,b))
            Vml.Pow

        testBinaryM "Pow_mode_double" Gen.Double
            (fun a b -> Math.Pow(a,b))
            Vml.Pow

        testBinary "Pow_single" Gen.Single
            (fun a b -> Math.Pow(float a,float b) |> float32)
            Vml.Pow

        testBinaryM "Pow_mode_single" Gen.Single
            (fun a b -> Math.Pow(float a,float b) |> float32)
            Vml.Pow

        testBinary "Powr_double" Gen.Double.[0.01,100.0]
            (fun a b -> Math.Pow(a,b))
            Vml.Powr

        testBinaryM "Powr_mode_double" Gen.Double.[0.01,100.0]
            (fun a b -> Math.Pow(a,b))
            Vml.Powr

        testBinary "Powr_single" Gen.Single.[0.01f,100.0f]
            (fun a b -> Math.Pow(float a,float b) |> float32)
            Vml.Powr

        testBinaryM "Powr_mode_single" Gen.Single.[0.01f,100.0f]
            (fun a b -> Math.Pow(float a,float b) |> float32)
            Vml.Powr
    }

let exponential =
    test "exponential" {
        testUnary "Exp_double" Gen.Double exp Vml.Exp

        testUnaryM "Exp_mode_double" Gen.Double exp Vml.Exp

        testUnary "Exp_single" Gen.Single
            (float >> exp >> float32)
            Vml.Exp

        testUnaryM "Exp_mode_single" Gen.Single
            (float >> exp >> float32)
            Vml.Exp

        testUnary "Exp2_double" Gen.Double
            (fun i -> Math.Pow(2.0,i))
            Vml.Exp2

        testUnaryM "Exp2_mode_double" Gen.Double
            (fun i -> Math.Pow(2.0,i))
            Vml.Exp2

        testUnary "Exp2_single" Gen.Single
            (fun i -> Math.Pow(2.0,float i) |> float32)
            Vml.Exp2

        testUnaryM "Exp2_mode_single" Gen.Single
            (fun i -> Math.Pow(2.0,float i) |> float32)
            Vml.Exp2

        testUnary "Exp10_double" Gen.Double
            (fun i -> Math.Pow(10.0,i))
            Vml.Exp10

        testUnaryM "Exp10_mode_double" Gen.Double
            (fun i -> Math.Pow(10.0,i))
            Vml.Exp10

        testUnary "Exp10_single" Gen.Single
            (fun i -> Math.Pow(10.0,float i) |> float32)
            Vml.Exp10

        testUnaryM "Exp10_mode_single" Gen.Single
            (fun i -> Math.Pow(10.0,float i) |> float32)
            Vml.Exp10

        testUnary "Expm1_double" Gen.Double
            (fun i -> exp i-1.0)
            Vml.Expm1

        testUnaryM "Expm1_mode_double" Gen.Double
            (fun i -> exp i-1.0)
            Vml.Expm1

        testUnary "Expm1_single" Gen.Single
            (fun i -> exp(float i)-1.0 |> float32)
            Vml.Expm1

        testUnaryM "Expm1_mode_single" Gen.Single
            (fun i -> exp(float i)-1.0 |> float32)
            Vml.Expm1

        testUnary "Ln_double" Gen.Double log
            Vml.Ln

        testUnaryM "Ln_mode_double" Gen.Double log
            Vml.Ln

        testUnary "Ln_single" Gen.Single
            (float >> log >> float32)
            Vml.Ln

        testUnaryM "Ln_mode_single" Gen.Single
            (float >> log >> float32)
            Vml.Ln

#if NETCOREAPP
        testUnary "Log2_double" Gen.Double Math.Log2
            Vml.Log2

        testUnaryM "Log2_mode_double" Gen.Double Math.Log2
            Vml.Log2

        testUnary "Log2_single" Gen.Single
            (float >> Math.Log2 >> float32)
            Vml.Log2

        testUnaryM "Log2_mode_single" Gen.Single
            (float >> Math.Log2 >> float32)
            Vml.Log2
#endif

        testUnary "Log10_double" Gen.Double log10
            Vml.Log10

        testUnaryM "Log10_mode_double" Gen.Double log10
            Vml.Log10

        testUnary "Log10_single" Gen.Single
            (float >> log10 >> float32)
            Vml.Log10

        testUnaryM "Log10_mode_single" Gen.Single
            (float >> log10 >> float32)
            Vml.Log10

        testUnary "Log1p_double" Gen.Double
            (fun i -> log(i+1.0))
            Vml.Log1p

        testUnaryM "Log1p_mode_double" Gen.Double
            (fun i -> log(i+1.0))
            Vml.Log1p

        testUnary "Log1p_single" Gen.Single
            (fun i -> log(float i+1.0) |> float32)
            Vml.Log1p

        testUnaryM "Log1p_mode_single" Gen.Single
            (fun i -> log(float i+1.0) |> float32)
            Vml.Log1p

#if NETCOREAPP
        testUnary "Logb_double" Gen.Double.[0.0,Double.MaxValue]
            (fun i -> Math.ILogB(i) |> float)
            Vml.Logb

        testUnaryM "Logb_mode_double" Gen.Double.[0.0,Double.MaxValue]
            (fun i -> Math.ILogB(i) |> float)
            Vml.Logb

        testUnary "Logb_single" Gen.Single.[0.0f,Single.MaxValue]
            (fun i -> Math.ILogB(float i) |> float32)
            Vml.Logb

        testUnaryM "Logb_mode_single" Gen.Single.[0.0f,Single.MaxValue]
            (fun i -> Math.ILogB(float i) |> float32)
            Vml.Logb
#endif
    }

let trigonometric =
    test "trigonometric" {
        testUnary "Cos_double" Gen.Double.[-65536.0,65536.0]
            cos
            Vml.Cos

        testUnaryM "Cos_mode_double" Gen.Double.[-65536.0,65536.0]
            cos
            Vml.Cos

        testUnary "Cos_single" Gen.Single.[-8192.0f,8192.0f]
            (float >> cos >> float32)
            Vml.Cos

        testUnaryM "Cos_mode_single" Gen.Single.[-8192.0f,8192.0f]
            (float >> cos >> float32)
            Vml.Cos

        testUnary "Sin_double" Gen.Double.[-65536.0,65536.0]
            sin
            Vml.Sin

        testUnaryM "Sin_mode_double" Gen.Double.[-65536.0,65536.0]
            sin
            Vml.Sin

        testUnary "Sin_single" Gen.Single.[-8192.0f,8192.0f]
            (float >> sin >> float32)
            Vml.Sin

        testUnaryM "Sin_mode_single" Gen.Single.[-8192.0f,8192.0f]
            (float >> sin >> float32)
            Vml.Sin

        testUnary "Tan_double" Gen.Double.[-1.0,1.0]
            tan
            Vml.Tan

        testUnaryM "Tan_mode_double" Gen.Double.[-1.0,1.0]
            tan
            Vml.Tan

        testUnary "Tan_single" Gen.Single.[-1.0f,1.0f]
            (float >> tan >> float32)
            Vml.Tan

        testUnaryM "Tan_mode_single" Gen.Single.[-1.0f,1.0f]
            (float >> tan >> float32)
            Vml.Tan

        testUnary "Cospi_double" Gen.Double.[-65536.0,65536.0]
            (fun i -> cos(Math.PI*i))
            Vml.Cospi

        testUnaryM "Cospi_mode_double" Gen.Double.[-65536.0,65536.0]
            (fun i -> cos(Math.PI*i))
            Vml.Cospi

        testUnary "Cospi_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> cos(Math.PI*float i) |> float32)
            Vml.Cospi

        testUnaryM "Cospi_mode_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> cos(Math.PI*float i) |> float32)
            Vml.Cospi

        testUnary "Sinpi_double" Gen.Double.[-65536.0,65536.0]
            (fun i -> sin(Math.PI*i))
            Vml.Sinpi

        testUnaryM "Sinpi_mode_double" Gen.Double.[-65536.0,65536.0]
            (fun i -> sin(Math.PI*i))
            Vml.Sinpi

        testUnary "Sinpi_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> sin(Math.PI*float i) |> float32)
            Vml.Sinpi

        testUnaryM "Sinpi_mode_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> sin(Math.PI*float i) |> float32)
            Vml.Sinpi

        testUnary "Tanpi_double" Gen.Double.[-0.3,0.3]
            (fun i -> tan(Math.PI*i))
            Vml.Tanpi

        testUnaryM "Tanpi_mode_double" Gen.Double.[-0.3,0.3]
            (fun i -> tan(Math.PI*i))
            Vml.Tanpi

        testUnary "Tanpi_single" Gen.Single.[-0.3f,0.3f]
            (fun i -> tan(Math.PI*float i) |> float32)
            Vml.Tanpi

        testUnaryM "Tanpi_mode_single" Gen.Single.[-0.3f,0.3f]
            (fun i -> tan(Math.PI*float i) |> float32)
            Vml.Tanpi

        testUnary "Cosd_double" Gen.Double.[-65536.0,65536.0]
            (fun i -> cos(Math.PI/180.0*i))
            Vml.Cosd

        testUnaryM "Cosd_mode_double" Gen.Double.[-65536.0,65536.0]
            (fun i -> cos(Math.PI/180.0*i))
            Vml.Cosd

        testUnary "Cosd_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> cos(Math.PI/180.0*float i) |> float32)
            Vml.Cosd

        testUnaryM "Cosd_mode_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> cos(Math.PI/180.0*float i) |> float32)
            Vml.Cosd

        testUnary "Sind_double" Gen.Double.[-65536.0,65536.0]
            (fun i -> sin(Math.PI/180.0*i))
            Vml.Sind

        testUnaryM "Sind_mode_double" Gen.Double.[-65536.0,65536.0]
            (fun i -> sin(Math.PI/180.0*i))
            Vml.Sind

        testUnary "Sind_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> sin(Math.PI/180.0*float i) |> float32)
            Vml.Sind

        testUnaryM "Sind_mode_single" Gen.Single.[-4194304.0f,4194304.0f]
            (fun i -> sin(Math.PI/180.0*float i) |> float32)
            Vml.Sind

        testUnary "Tand_double" Gen.Double.[-57.0,57.0]
            (fun i -> tan(Math.PI/180.0*i))
            Vml.Tand

        testUnaryM "Tand_mode_double" Gen.Double.[-57.0,57.0]
            (fun i -> tan(Math.PI/180.0*i))
            Vml.Tand

        testUnary "Tand_single" Gen.Single.[-57.0f,57.0f]
            (fun i -> tan(Math.PI/180.0*float i) |> float32)
            Vml.Tand

        testUnaryM "Tand_mode_single" Gen.Single.[-57.0f,57.0f]
            (fun i -> tan(Math.PI/180.0*float i) |> float32)
            Vml.Tand

        testUnary "Acos_double" Gen.Double.[-1.0,1.0]
            acos
            Vml.Acos

        testUnaryM "Acos_mode_double" Gen.Double.[-1.0,1.0]
            acos
            Vml.Acos

        testUnary "Acos_single" Gen.Single.[-1.0f,1.0f]
            (float >> acos >> float32)
            Vml.Acos

        testUnaryM "Acos_mode_single" Gen.Single.[-1.0f,1.0f]
            (float >> acos >> float32)
            Vml.Acos

        testUnary "Asin_double" Gen.Double.[-1.0,1.0]
            asin
            Vml.Asin

        testUnaryM "Asin_mode_double" Gen.Double.[-1.0,1.0]
            asin
            Vml.Asin

        testUnary "Asin_single" Gen.Single.[-1.0f,1.0f]
            (float >> asin >> float32)
            Vml.Asin

        testUnaryM "Asin_mode_single" Gen.Single.[-1.0f,1.0f]
            (float >> asin >> float32)
            Vml.Asin

        testUnary "Atan_double" Gen.Double
            atan
            Vml.Atan

        testUnaryM "Atan_mode_double" Gen.Double
            atan
            Vml.Atan

        testUnary "Atan_single" Gen.Single
            (float >> atan >> float32)
            Vml.Atan

        testUnaryM "Atan_mode_single" Gen.Single
            (float >> atan >> float32)
            Vml.Atan

        testUnary "Acospi_double" Gen.Double.[-1.0,1.0]
            (fun i -> acos(i) / Math.PI)
            Vml.Acospi

        testUnaryM "Acospi_mode_double" Gen.Double.[-1.0,1.0]
            (fun i -> acos(i) / Math.PI)
            Vml.Acospi

        testUnary "Acospi_single" Gen.Single.[-1.0f,1.0f]
            (fun i -> acos(float i) / Math.PI |> float32)
            Vml.Acospi

        testUnaryM "Acospi_mode_single" Gen.Single.[-1.0f,1.0f]
            (fun i -> acos(float i) / Math.PI |> float32)
            Vml.Acospi

        testUnary "Asinpi_double" Gen.Double.[-1.0,1.0]
            (fun i -> asin(i) / Math.PI)
            Vml.Asinpi

        testUnaryM "Asinpi_mode_double" Gen.Double.[-1.0,1.0]
            (fun i -> asin(i) / Math.PI)
            Vml.Asinpi

        testUnary "Asinpi_single" Gen.Single.[-1.0f,1.0f]
            (fun i -> asin(float i) / Math.PI |> float32)
            Vml.Asinpi

        testUnaryM "Asinpi_mode_single" Gen.Single.[-1.0f,1.0f]
            (fun i -> asin(float i) / Math.PI |> float32)
            Vml.Asinpi

        testUnary "Atanpi_double" Gen.Double
            (fun i -> atan(i) / Math.PI)
            Vml.Atanpi

        testUnaryM "Atanpi_mode_double" Gen.Double
            (fun i -> atan(i) / Math.PI)
            Vml.Atanpi

        testUnary "Atanpi_single" Gen.Single
            (fun i -> atan(float i) / Math.PI |> float32)
            Vml.Atanpi

        testUnaryM "Atanpi_mode_single" Gen.Single
            (fun i -> atan(float i) / Math.PI |> float32)
            Vml.Atanpi

        testBinary "Atan2_double" Gen.Double
            atan2
            Vml.Atan2

        testBinaryM "Atan2_mode_double" Gen.Double
            atan2
            Vml.Atan2

        testBinary "Atan2_single" Gen.Single
            (fun a b -> atan2 (float a) (float b) |> float32)
            Vml.Atan2

        testBinaryM "Atan2_mode_single" Gen.Single
            (fun a b -> atan2 (float a) (float b) |> float32)
            Vml.Atan2

        testBinary "Atan2pi_double" Gen.Double
            (fun a b -> atan2 a b / Math.PI)
            Vml.Atan2pi

        testBinaryM "Atan2pi_mode_double" Gen.Double
            (fun a b -> atan2 a b / Math.PI)
            Vml.Atan2pi

        testBinary "Atan2pi_single" Gen.Single
            (fun a b -> atan2 (float a) (float b) / Math.PI |> float32)
            Vml.Atan2pi

        testBinaryM "Atan2pi_mode_single" Gen.Single
            (fun a b -> atan2 (float a) (float b) / Math.PI |> float32)
            Vml.Atan2pi
    }

let hyperbolic =
    test "hyperbolic" {
        testUnary "Cosh_double" Gen.Double
            cosh
            Vml.Cosh

        testUnaryM "Cosh_mode_double" Gen.Double
            cosh
            Vml.Cosh

        testUnary "Cosh_single" Gen.Single
            (float >> cosh >> float32)
            Vml.Cosh

        testUnaryM "Cosh_mode_single" Gen.Single
            (float >> cosh >> float32)
            Vml.Cosh

        testUnary "Sinh_double" Gen.Double
            sinh
            Vml.Sinh

        testUnaryM "Sinh_mode_double" Gen.Double
            sinh
            Vml.Sinh

        testUnary "Sinh_single" Gen.Single
            (float >> sinh >> float32)
            Vml.Sinh

        testUnaryM "Sinh_mode_single" Gen.Single
            (float >> sinh >> float32)
            Vml.Sinh

        testUnary "Tanh_double" Gen.Double
            tanh
            Vml.Tanh

        testUnaryM "Tanh_mode_double" Gen.Double
            tanh
            Vml.Tanh

        testUnary "Tanh_single" Gen.Single
            (float >> tanh >> float32)
            Vml.Tanh

        testUnaryM "Tanh_mode_single" Gen.Single
            (float >> tanh >> float32)
            Vml.Tanh

#if NETCOREAPP
        testUnary "Acosh_double" Gen.Double.[1.0,Double.MaxValue]
            Math.Acosh
            Vml.Acosh

        testUnaryM "Acosh_mode_double" Gen.Double.[1.0,Double.MaxValue]
            Math.Acosh
            Vml.Acosh

        testUnary "Acosh_single" Gen.Single.[1.0f,Single.MaxValue]
            (float >> Math.Acosh >> float32)
            Vml.Acosh

        testUnaryM "Acosh_mode_single" Gen.Single.[1.0f,Single.MaxValue]
            (float >> Math.Acosh >> float32)
            Vml.Acosh

        testUnary "Asinh_double" Gen.Double
            Math.Asinh
            Vml.Asinh

        testUnaryM "Asinh_mode_double" Gen.Double
            Math.Asinh
            Vml.Asinh

        testUnary "Asinh_single" Gen.Single
            (float >> Math.Asinh >> float32)
            Vml.Asinh

        testUnaryM "Asinh_mode_single" Gen.Single
            (float >> Math.Asinh >> float32)
            Vml.Asinh

        testUnary "Atanh_double" Gen.Double.[-1.0,1.0]
            Math.Atanh
            Vml.Atanh

        testUnaryM "Atanh_mode_double" Gen.Double.[-1.0,1.0]
            Math.Atanh
            Vml.Atanh

        testUnary "Atanh_single" Gen.Single.[-1.0f,1.0f]
            (float >> Math.Atanh >> float32)
            Vml.Atanh

        testUnaryM "Atanh_mode_single" Gen.Single.[-1.0f,1.0f]
            (float >> Math.Atanh >> float32)
            Vml.Atanh
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
            Vml.Floor

        testUnaryM "Floor_mode_double" Gen.Double
            floor
            Vml.Floor

        testUnary "Floor_single" Gen.Single
            (float >> floor >> float32)
            Vml.Floor

        testUnaryM "Floor_mode_single" Gen.Single
            (float >> floor >> float32)
            Vml.Floor

        testUnary "Ceil_double" Gen.Double
            ceil
            Vml.Ceil

        testUnaryM "Ceil_mode_double" Gen.Double
            ceil
            Vml.Ceil

        testUnary "Ceil_single" Gen.Single
            (float >> ceil >> float32)
            Vml.Ceil

        testUnaryM "Ceil_mode_single" Gen.Single
            (float >> ceil >> float32)
            Vml.Ceil

        testUnary "Trunc_double" Gen.Double
            truncate
            Vml.Trunc

        testUnaryM "Trunc_mode_double" Gen.Double
            truncate
            Vml.Trunc

        testUnary "Trunc_single" Gen.Single
            truncate
            Vml.Trunc

        testUnaryM "Trunc_mode_single" Gen.Single
            truncate
            Vml.Trunc

        testUnary "Round_double" Gen.Double
            (fun a -> Math.Round(a, MidpointRounding.AwayFromZero))
            Vml.Round

        testUnaryM "Round_mode_double" Gen.Double
            (fun a -> Math.Round(a, MidpointRounding.AwayFromZero))
            Vml.Round

        testUnary "Round_single" Gen.Single
            (fun a -> Math.Round(float a, MidpointRounding.AwayFromZero) |> float32)
            Vml.Round

        testUnaryM "Round_mode_single" Gen.Single
            (fun a -> Math.Round(float a, MidpointRounding.AwayFromZero) |> float32)
            Vml.Round

        testUnary "Frac_double" Gen.Double
            (fun a -> a - truncate a)
            Vml.Frac

        testUnaryM "Frac_mode_double" Gen.Double
            (fun a -> a - truncate a)
            Vml.Frac

        testUnary "Frac_single" Gen.Single
            (fun a -> a - truncate a)
            Vml.Frac

        testUnaryM "Frac_mode_single" Gen.Single
            (fun a -> a - truncate a)
            Vml.Frac

        testUnary "NearbyInt_double" Gen.Double
            (fun a -> Math.Round(a, MidpointRounding.ToEven))
            Vml.NearbyInt

        testUnaryM "NearbyInt_mode_double" Gen.Double
            (fun a -> Math.Round(a, MidpointRounding.ToEven))
            Vml.NearbyInt

        testUnary "NearbyInt_single" Gen.Single
            (fun a -> Math.Round(float a, MidpointRounding.ToEven) |> float32)
            Vml.NearbyInt

        testUnaryM "NearbyInt_mode_single" Gen.Single
            (fun a -> Math.Round(float a, MidpointRounding.ToEven) |> float32)
            Vml.NearbyInt

        testUnary "Rint_double" Gen.Double
            (fun a -> Math.Round(a, MidpointRounding.ToEven))
            Vml.Rint

        testUnaryM "Rint_mode_double" Gen.Double
            (fun a -> Math.Round(a, MidpointRounding.ToEven))
            Vml.Rint

        testUnary "Rint_single" Gen.Single
            (fun a -> Math.Round(float a, MidpointRounding.ToEven) |> float32)
            Vml.Rint

        testUnaryM "Rint_mode_single" Gen.Single
            (fun a -> Math.Round(float a, MidpointRounding.ToEven) |> float32)
            Vml.Rint
    }

let miscellaneous =
    test "miscellaneous" {
#if NETCOREAPP
        testBinary "CopySign_double" Gen.Double
            (fun a b -> Math.CopySign(a,b))
            Vml.CopySign

        testBinaryM "CopySign_mode_double" Gen.Double
            (fun a b -> Math.CopySign(a,b))
            Vml.CopySign

        testBinary "CopySign_single" Gen.Single
            (fun a b -> Math.CopySign(float a, float b) |> float32)
            Vml.CopySign

        testBinaryM "CopySign_mode_single" Gen.Single
            (fun a b -> Math.CopySign(float a, float b) |> float32)
            Vml.CopySign
#endif

        testBinary "Fmax_double" Gen.Double.Normal
            (fun a b -> Math.Max(a,b))
            Vml.Fmax

        testBinaryM "Fmax_mode_double" Gen.Double.Normal
            (fun a b -> Math.Max(a,b))
            Vml.Fmax

        testBinary "Fmax_single" Gen.Single.Normal
            (fun a b -> Math.Max(a,b))
            Vml.Fmax

        testBinaryM "Fmax_mode_single" Gen.Single.Normal
            (fun a b -> Math.Max(a,b))
            Vml.Fmax

        testBinary "Fmin_double" Gen.Double.Normal
            (fun a b -> Math.Min(a,b))
            Vml.Fmin

        testBinaryM "Fmin_mode_double" Gen.Double.Normal
            (fun a b -> Math.Min(a,b))
            Vml.Fmin

        testBinary "Fmin_single" Gen.Single.Normal
            (fun a b -> Math.Min(a,b))
            Vml.Fmin

        testBinaryM "Fmin_mode_single" Gen.Single.Normal
            (fun a b -> Math.Min(a,b))
            Vml.Fmin

        testBinary "Fdim_double" Gen.Double.Normal
            (fun a b -> max (a-b) 0.0)
            Vml.Fdim

        testBinaryM "Fdim_mode_double" Gen.Double.Normal
            (fun a b -> max (a-b) 0.0)
            Vml.Fdim

        testBinary "Fdim_single" Gen.Single.Normal
            (fun a b -> max (a-b) 0.0f)
            Vml.Fdim

        testBinaryM "Fdim_mode_single" Gen.Single.Normal
            (fun a b -> max (a-b) 0.0f)
            Vml.Fdim

        testBinary "MaxMag_double" Gen.Double.Normal
            (fun a b -> if abs a > abs b then a
                        elif abs a < abs b then b
                        else max a b)
            Vml.MaxMag

        testBinaryM "MaxMag_mode_double" Gen.Double.Normal
            (fun a b -> if abs a > abs b then a
                        elif abs a < abs b then b
                        else max a b)
            Vml.MaxMag

        testBinary "MaxMag_single" Gen.Single.Normal
            (fun a b -> if abs a > abs b then a
                        elif abs a < abs b then b
                        else max a b)
            Vml.MaxMag

        testBinaryM "MaxMag_mode_single" Gen.Single.Normal
            (fun a b -> if abs a > abs b then a
                        elif abs a < abs b then b
                        else max a b)
            Vml.MaxMag

        testBinary "MinMag_double" Gen.Double.Normal
            (fun a b -> if abs a < abs b then a
                        elif abs a > abs b then b
                        else min a b)
            Vml.MinMag

        testBinaryM "MinMag_mode_double" Gen.Double.Normal
            (fun a b -> if abs a < abs b then a
                        elif abs a > abs b then b
                        else min a b)
            Vml.MinMag

        testBinary "MinMag_single" Gen.Single.Normal
            (fun a b -> if abs a < abs b then a
                        elif abs a > abs b then b
                        else min a b)
            Vml.MinMag

        testBinaryM "MinMag_mode_single" Gen.Single.Normal
            (fun a b -> if abs a < abs b then a
                        elif abs a > abs b then b
                        else min a b)
            Vml.MinMag

#if NETCOREAPP
        testBinary "NextAfter_double" Gen.Double.Normal
            (fun a b -> if b > 0.0 then Math.BitIncrement(a)
                                   else Math.BitDecrement(a))
            Vml.NextAfter

        testBinaryM "NextAfter_mode_double" Gen.Double.Normal
            (fun a b -> if b > 0.0 then Math.BitIncrement(a)
                                   else Math.BitDecrement(a))
            Vml.NextAfter

        testBinary "NextAfter_single" Gen.Single.Normal
            (fun a b -> if b > 0.0f then Math.BitIncrement(float a) |> float32
                                    else Math.BitDecrement(float a) |> float32)
            Vml.NextAfter

        testBinaryM "NextAfter_mode_single" Gen.Single.Normal
            (fun a b -> if b > 0.0f then Math.BitIncrement(float a) |> float32
                                    else Math.BitDecrement(float a) |> float32)
            Vml.NextAfter
#endif
    }

let bespoke =
    test "bespoke" {

        test "Powx_double" {
            let! a = Gen.Double.[0.0,Double.MaxValue].Array.[0,ROWS_MAX]
            let! b = Gen.Double
            let expected = Array.map (fun a -> Math.Pow(a,b)) a
            let actual = Array.zeroCreate a.Length
            Vml.Powx(a,b,actual)
            Check.close High expected actual
            Vml.Powx(a,b,actual,VmlMode.HA)
            Check.close High expected actual |> Check.message "mode"
            Vml.Powx(a,b,a)
            Check.close High expected a |> Check.message "inplace"
        }

        test "Powx_single" {
            let! a = Gen.Single.[0.0f,Single.MaxValue].Array.[0,ROWS_MAX]
            let! b = Gen.Single
            let expected = Array.map (fun a -> Math.Pow(float a,float b) |> float32) a
            let actual = Array.zeroCreate a.Length
            Vml.Powx(a,b,actual)
            Check.close High expected actual
            Vml.Powx(a,b,actual,VmlMode.HA)
            Check.close High expected actual |> Check.message "mode"
            Vml.Powx(a,b,a)
            Check.close High expected a |> Check.message "inplace"
        }

        test "SinCos_double" {
            let! a = Gen.Double.[-65536.0,65536.0].Array.[0,ROWS_MAX]
            let expected1 = Array.map sin a
            let expected2 = Array.map cos a
            let actual1 = Array.zeroCreate a.Length
            let actual2 = Array.zeroCreate a.Length
            Vml.SinCos(a,actual1,actual2)
            Check.close High expected1 actual1 |> Check.message "sin"
            Check.close High expected2 actual2 |> Check.message "sin"
            Vml.SinCos(a,actual1,actual2,VmlMode.HA)
            Check.close High expected1 actual1 |> Check.message "mode_sin"
            Check.close High expected2 actual2 |> Check.message "mode_sin"
            Vml.SinCos(a,a,actual2)
            Check.close High expected1 a |> Check.message "inplace"
        }

        test "SinCos_single" {
            let! a = Gen.Single.[-8192.0f,8192.0f].Array.[0,ROWS_MAX]
            let expected1 = Array.map sin a
            let expected2 = Array.map cos a
            let actual1 = Array.zeroCreate a.Length
            let actual2 = Array.zeroCreate a.Length
            Vml.SinCos(a,actual1,actual2)
            Check.close High expected1 actual1 |> Check.message "sin"
            Check.close High expected2 actual2 |> Check.message "sin"
            Vml.SinCos(a,actual1,actual2,VmlMode.HA)
            Check.close High expected1 actual1 |> Check.message "mode_sin"
            Check.close High expected2 actual2 |> Check.message "mode_sin"
            Vml.SinCos(a,a,actual2)
            Check.close High expected1 a |> Check.message "inplace"
        }

        test "Modf_double" {
            let! a = Gen.Double.Array.[0,ROWS_MAX]
            let expected1 = Array.map truncate a
            let expected2 = Array.map (fun a -> a - truncate a) a
            let actual1 = Array.zeroCreate a.Length
            let actual2 = Array.zeroCreate a.Length
            Vml.Modf(a,actual1,actual2)
            Check.close High expected1 actual1 |> Check.message "int"
            Check.close High expected2 actual2 |> Check.message "fra"
            Vml.Modf(a,actual1,actual2,VmlMode.HA)
            Check.close High expected1 actual1 |> Check.message "mode_int"
            Check.close High expected2 actual2 |> Check.message "mode_fra"
            Vml.Modf(a,a,actual2)
            Check.close High expected1 a |> Check.message "inplace"
        }

        test "Modf_single" {
            let! a = Gen.Single.Array.[0,ROWS_MAX]
            let expected1 = Array.map truncate a
            let expected2 = Array.map (fun a -> a - truncate a) a
            let actual1 = Array.zeroCreate a.Length
            let actual2 = Array.zeroCreate a.Length
            Vml.Modf(a,actual1,actual2)
            Check.close High expected1 actual1 |> Check.message "int"
            Check.close High expected2 actual2 |> Check.message "fra"
            Vml.Modf(a,actual1,actual2,VmlMode.HA)
            Check.close High expected1 actual1 |> Check.message "mode_int"
            Check.close High expected2 actual2 |> Check.message "mode_fra"
            Vml.Modf(a,a,actual2)
            Check.close High expected1 a |> Check.message "inplace"
        }

        test "LinearFrac_double" {
            let! a = Gen.Double.[0.01,100.0].Array.[0,ROWS_MAX]
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
            Vml.LinearFrac(a,b,scalea,shifta,scaleb,shiftb,actual,VmlMode.HA)
            Check.close High expected actual |> Check.message "mode"
            Vml.LinearFrac(a,b,scalea,shifta,scaleb,shiftb,a)
            Check.close High expected a |> Check.message "inplace"
        }

        test "LinearFrac_single" {
            let! a = Gen.Single.[0.01f,100.0f].Array.[0,ROWS_MAX]
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
            Vml.LinearFrac(a,b,scalea,shifta,scaleb,shiftb,actual,VmlMode.HA)
            Check.close High expected actual |> Check.message "mode"
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