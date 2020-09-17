module VmlTests

open System
open MKLNET
open CsCheck

let all =
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

    test "Vml" {

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
    }