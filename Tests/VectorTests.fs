module VectorTests

open MKLNET
open CsCheck

let MAX_DIM = 5
let gen1D = Gen.Int.[1,MAX_DIM]
let gen2D = Gen.Select(gen1D,gen1D)

let genVector length =
    Gen.Create(fun pcg ->
        let v = new vector(length)
        let gen = Gen.Double.OneTwo
        for i =0 to length-1 do
            let struct (d,_) = gen.Generate pcg
            v.[i] <- d
        v, Size 0UL
    )

let genMatrix rows cols =
    Gen.Create(fun pcg ->
        let m = new matrix(rows,cols)
        let gen = Gen.Double.OneTwo
        for r =0 to rows-1 do
            for c=0 to cols-1 do
                let struct (d,_) = gen.Generate pcg
                m.[r,c] <- d
        m, Size 0UL
    )

let add_vv (aS:double) (a:vector) (bS:double) (b:vector) =
    let c = new vector(a.Length)
    for i = 0 to a.Length-1 do
         c.[i] <- aS * a.[i] + bS * b.[i]
    c

let mul_vvT (s:double) (a:vector) (b:vector) =
    let C = new matrix(a.Length, b.Length)
    for r = 0 to C.Rows-1 do
        for c=0 to C.Cols-1 do
            C.[r,c] <- s * a.[r] * b.[c]
    C

let mul_vTv (a:vector) (b:vector) =
    let mutable t = 0.0
    for i = 0 to a.Length-1 do
        t <- t + a.[i] * b.[i]
    t

let mul_vTm (s:double) (a:vector) (B:matrix) =
    let c = new vector(B.Cols)
    for i = 0 to B.Cols - 1 do
        let mutable t = 0.0
        for r = 0 to a.Length - 1 do
            t <- t + a.[r] * B.[r,i]
        c.[i] <- s * t
    c

let mul_vTmT (s:double) (a:vector) (B:matrix) =
    let c = new vector(B.Rows)
    for i = 0 to B.Rows - 1 do
        let mutable t = 0.0
        for r = 0 to a.Length - 1 do
            t <- t + a.[r] * B.[i,r]
        c.[i] <- s * t
    c

let add = test "add" {

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
}

let sub = test "sub" {

    test "vv" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        use expected = add_vv 1.0 a -1.0 b
        use actual = a - b
        Check.close High expected actual
    }

    test "vvS" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv 1.0 a -s b
        use actual = a - s * b
        Check.close High expected actual
    }

    test "vTvT" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        use expected = add_vv 1.0 a -1.0 b
        use actual = (a.T - b.T).T
        Check.close High expected actual
    }

    test "vTvTS" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv 1.0 a -s b
        use actual = (a.T - s * b.T).T
        Check.close High expected actual
    }

    test "vSv" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv s a -1.0 b
        use actual = s * a - b
        Check.close High expected actual
    }

    test "vSvS" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = add_vv s1 a -s2 b
        use actual = s1 * a - s2 * b
        Check.close High expected actual
    }

    test "vTSvT" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv s a -1.0 b
        use actual = (s * a.T - b.T).T
        Check.close High expected actual
    }

    test "vTSvTS" {
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

let mul = test "mul" {

    test "vvT" {
        let! m,n = gen2D
        let! a = genVector m
        let! b = genVector n
        use expected = mul_vvT 1.0 a b
        use actual = a * b.T
        Check.close High expected actual
    }

    test "vvTS" {
        let! m,n = gen2D
        let! a = genVector m
        let! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = mul_vvT s a b
        use actual = a * (s * b.T)
        Check.close High expected actual
    }

    test "vTv" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        let expected = mul_vTv a b
        let actual = a.T * b
        Check.close High expected actual
    }

    test "vTvS" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        let! s = Gen.Double.OneTwo
        let expected = mul_vTv a b * s
        let actual = a.T * (b * s)
        Check.close High expected actual
    }

    test "vSvT" {
        let! m,n = gen2D
        let! a = genVector m
        let! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = mul_vvT s a b
        use actual = (s * a) * b.T
        Check.close High expected actual
    }

    test "vSvTS" {
        let! m,n = gen2D
        let! a = genVector m
        let! b = genVector n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = mul_vvT (s1*s2) a b
        use actual = (s1 * a) * (s2 * b.T)
        Check.close High expected actual
    }

    test "vTSv" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        let! s = Gen.Double.OneTwo
        let expected = s * mul_vTv a b
        let actual = (s * a.T) * b
        Check.close High expected actual
    }

    test "vTSvS" {
        let! n = gen1D
        let! a = genVector n
        let! b = genVector n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        let expected = s1 * mul_vTv a b * s2
        let actual = (s1 * a.T) * (b * s2)
        Check.close High expected actual
    }

    test "vTm" {
        let! m,n = gen2D
        let! a = genVector m
        let! B = genMatrix m n
        use expected = mul_vTm 1.0 a B
        use actual = (a.T * B).T
        Check.close High expected actual
    }

    test "vTmT" {
        let! m,n = gen2D
        let! a = genVector m
        let! B = genMatrix n m
        use expected = mul_vTmT 1.0 a B
        use actual = (a.T * B.T).T
        Check.close High expected actual
    }

    test "vTmTS" {
        let! m,n = gen2D
        let! a = genVector m
        let! B = genMatrix n m
        let! s = Gen.Double.OneTwo
        use expected = mul_vTmT s a B
        use actual = (a.T * (s * B.T)).T
        Check.close High expected actual
    }

    test "vTSm" {
        let! m,n = gen2D
        let! a = genVector m
        let! B = genMatrix m n
        let! s = Gen.Double.OneTwo
        use expected = mul_vTm s a B
        use actual = ((s * a.T) * B).T
        Check.close High expected actual
    }

    test "vTSmT" {
        let! m,n = gen2D
        let! a = genVector m
        let! B = genMatrix n m
        let! s = Gen.Double.OneTwo
        use expected = mul_vTmT s a B
        use actual = ((s * a.T) * B.T).T
        Check.close High expected actual
    }

    test "vTSmTS" {
        let! m,n = gen2D
        let! a = genVector m
        let! B = genMatrix n m
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = mul_vTmT (s1*s2) a B
        use actual = ((s1 * a.T) * (s2 * B.T)).T
        Check.close High expected actual
    }
}

let all =
    test "vector" {
        add
        sub
        mul
    }