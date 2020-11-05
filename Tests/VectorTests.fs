module VectorTests

open MKLNET
open CsCheck

let MAX_DIM = 5
let gen1D = Gen.Int.[1,MAX_DIM]

let add_vv (aS:double) (a:vector) (bS:double) (b:vector) =
    let c = new vector(a.Length)
    for i=0 to a.Length-1 do
         c.[i] <- aS * a.[i] + bS * b.[i]
    c

let genVector length =
    Gen.Create(fun pcg ->
        let v = new vector(length)
        let gen = Gen.Double.OneTwo
        for i =0 to length-1 do
            let struct (d,_) = gen.Generate pcg
            v.[i] <- d
        v, Size 0UL
    )

let operators = test "operators" {

    test "add_vv" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        use expected = add_vv 1.0 a 1.0 b
        use actual = a + b
        Check.close High expected actual
    }

    test "add_vvS" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv 1.0 a s b
        use actual = a + s * b
        Check.close High expected actual
    }

    test "sub_vv" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        use expected = add_vv 1.0 a -1.0 b
        use actual = a - b
        Check.close High expected actual
    }

    test "sub_vvS" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv 1.0 a -s b
        use actual = a - s * b
        Check.close High expected actual
    }

    test "add_vTvT" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        use expected = add_vv 1.0 a 1.0 b
        use actual = (a.T + b.T).T
        Check.close High expected actual
    }

    test "add_vTvTS" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv 1.0 a s b
        use actual = (a.T + s * b.T).T
        Check.close High expected actual
    }

    test "sub_vTvT" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        use expected = add_vv 1.0 a -1.0 b
        use actual = (a.T - b.T).T
        Check.close High expected actual
    }

    test "sub_vTvTS" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv 1.0 a -s b
        use actual = (a.T - s * b.T).T
        Check.close High expected actual
    }

    test "add_vSv" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv s a 1.0 b
        use actual = s * a + b
        Check.close High expected actual
    }

    test "add_vSvS" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = add_vv s1 a s2 b
        use actual = s1 * a + s2 * b
        Check.close High expected actual
    }

    test "sub_vSv" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv s a -1.0 b
        use actual = s * a - b
        Check.close High expected actual
    }

    test "sub_vSvS" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = add_vv s1 a -s2 b
        use actual = s1 * a - s2 * b
        Check.close High expected actual
    }

    test "add_vTSvT" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv s a 1.0 b
        use actual = (s * a.T + b.T).T
        Check.close High expected actual
    }

    test "add_vTSvTS" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = add_vv s1 a s2 b
        use actual = (s1 * a.T + s2 * b.T).T
        Check.close High expected actual
    }

    test "sub_vTSvT" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv s a -1.0 b
        use actual = (s * a.T - b.T).T
        Check.close High expected actual
    }

    test "sub_vTSvTS" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = add_vv s1 a -s2 b
        use actual = (s1 * a.T - s2 * b.T).T
        Check.close High expected actual
    }
}

let all =
    test "vector" {
        operators
    }