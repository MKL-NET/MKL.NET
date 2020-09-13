module VmlTests

open MKLNET
open CsCheck

let all =
    test "Vml" {

        test "Add" {
            let! a = Gen.Double.Array.[0,3]
            let! b = Gen.Double.Array.[a.Length]
            let actual = Array.zeroCreate a.Length
            Vml.Add(a.Length,a,b,actual)
            let expected = Array.map2 (+) a b
            Check.equal expected actual
        }

        test "Add_inplace" {
            let! a = Gen.Double.Array.[0,3]
            let! b = Gen.Double.Array.[a.Length]
            let expected = Array.map2 (+) a b
            Vml.Add(a.Length,a,b,a)
            Check.equal expected a
        }

        test "Add_mode" {
            let! a = Gen.Double.Array.[0,3]
            let! b = Gen.Double.Array.[a.Length]
            let actual = Array.zeroCreate a.Length
            Vml.Add(a.Length,a,b,actual,VmlMode.EP)
            let expected = Array.map2 (+) a b
            Check.equal expected actual
        }

        test "Add_single" {
            let! a = Gen.Single.Array.[0,3]
            let! b = Gen.Single.Array.[a.Length]
            let actual = Array.zeroCreate a.Length
            Vml.Add(a.Length,a,b,actual)
            let expected = Array.map2 (+) a b
            Check.equal expected actual
        }

        test "Add_inplace_single" {
            let! a = Gen.Single.Array.[0,3]
            let! b = Gen.Single.Array.[a.Length]
            let expected = Array.map2 (+) a b
            Vml.Add(a.Length,a,b,a)
            Check.equal expected a
        }

        test "Add_mode_single" {
            let! a = Gen.Single.Array.[0,3]
            let! b = Gen.Single.Array.[a.Length]
            let actual = Array.zeroCreate a.Length
            Vml.Add(a.Length,a,b,actual,VmlMode.EP)
            let expected = Array.map2 (+) a b
            Check.equal expected actual
        }
    }