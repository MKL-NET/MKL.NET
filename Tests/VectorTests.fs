module VectorTests

open System
open MKLNET
open MKLNET.Expression
open CsCheck

let MAX_DIM = 5
let gen1D = Gen.Int.[1,MAX_DIM]
let gen2D = Gen.Select(gen1D,gen1D)

let genVector length =
    Gen.Create(fun (pcg:PCG) (_:Size) (size:Size byref) ->
        size <- Size 0UL
        let v = new vector(length)
        let gen = Gen.Double.OneTwo
        for i =0 to length-1 do
            let d,_ = gen.Generate(pcg, null)
            v.[i] <- d
        v
    )

let genMatrix rows cols =
    Gen.Create(fun (pcg:PCG) (_:Size) (size:Size byref) ->
        size <- Size 0UL
        let m = new matrix(rows,cols)
        let gen = Gen.Double.OneTwo
        for r =0 to rows-1 do
            for c=0 to cols-1 do
                let d,_ = gen.Generate(pcg, null)
                m.[r,c] <- d
        m
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

let impM (m:MatrixExpression) = MatrixExpression.op_Implicit m
let impV (m:VectorExpression) = VectorExpression.op_Implicit m
let impVE (m:vector) = VectorExpression.op_Implicit m

let add1 = test "add1" {

    test "vv" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        use expected = add_vv 1.0 a 1.0 b
        use actual = a + b |> impV
        Check.close High expected actual
    }

    test "vv_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        use expected = add_vv 1.0 a 1.0 b
        use actual = (a + 0.0) + (b + 0.0) |> impV
        Check.close High expected actual
    }

    test "vvS" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv 1.0 a s b
        use actual = a + s * b |> impV
        Check.close High expected actual
    }

    test "vvS_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv 1.0 a s b
        use actual = (a + 0.0) + (s * b + 0.0) |> impV
        Check.close High expected actual
    }

    test "vTvT" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        use expected = add_vv 1.0 a 1.0 b
        use actual = (a.T + b.T).T |> impV
        Check.close High expected actual
    }

    test "vTvT_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        use expected = add_vv 1.0 a 1.0 b
        use actual = ((a.T + 0.0) + (b.T + 0.0)).T |> impV
        Check.close High expected actual
    }

    test "vTvTS" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv 1.0 a s b
        use actual = (a.T + s * b.T).T |> impV
        Check.close High expected actual
    }

    test "vTvTS_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv 1.0 a s b
        use actual = ((a.T + 0.0) + (s * b.T + 0.0)).T |> impV
        Check.close High expected actual
    }

    test "vSv" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv s a 1.0 b
        use actual = s * a + b |> impV
        Check.close High expected actual
    }

    test "vSv_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv s a 1.0 b
        use actual = (s * a + 0.0) + (b + 0.0) |> impV
        Check.close High expected actual
    }

    test "vSvS" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = add_vv s1 a s2 b
        use actual = s1 * a + s2 * b |> impV
        Check.close High expected actual
    }

    test "vSvS_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = add_vv s1 a s2 b
        use actual = (s1 * a + 0.0) + (s2 * b + 0.0) |> impV
        Check.close High expected actual
    }

    test "vTSvT" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv s a 1.0 b
        use actual = (s * a.T + b.T).T |> impV
        Check.close High expected actual
    }

    test "vTSvT_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv s a 1.0 b
        use actual = ((s * a.T + 0.0) + (b.T + 0.0)).T |> impV
        Check.close High expected actual
    }

    test "vTSvTS" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = add_vv s1 a s2 b
        use actual = (s1 * a.T + s2 * b.T).T |> impV
        Check.close High expected actual
    }

    test "vTSvTS_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = add_vv s1 a s2 b
        use actual = ((s1 * a.T + 0.0) + (s2 * b.T + 0.0)).T |> impV
        Check.close High expected actual
    }
}

let add2 = test "add2" {

    test "vd" {
        let! n = gen1D
        use! A = genVector n
        let! a = Gen.Double.OneTwo
        use expected =
            let R = new vector(n)
            for i =0 to n-1 do
                R.[i] <- A.[i] + a
            R
        use actual = A + a |> impV
        Check.close High expected actual
    }

    test "vd_reuse" {
        let! n = gen1D
        use! A = genVector n
        let! a = Gen.Double.OneTwo
        use expected =
            let R = new vector(n)
            for i =0 to n-1 do
                R.[i] <- A.[i] + a
            R
        use actual = (A + 0.0) + a |> impV
        Check.close High expected actual
    }

    test "vTd" {
        let! n = gen1D
        use! A = genVector n
        let! a = Gen.Double.OneTwo
        use expected =
            let R = new vector(n)
            for i =0 to n-1 do
                R.[i] <- A.[i] + a
            R
        let actual = (A.T + a).T |> impV
        Check.close High expected actual
    }

    test "vTd_reuse" {
        let! n = gen1D
        use! A = genVector n
        let! a = Gen.Double.OneTwo
        use expected =
            let R = new vector(n)
            for i =0 to n-1 do
                R.[i] <- A.[i] + a
            R
        let actual = ((A.T + 0.0) + a).T |> impV
        Check.close High expected actual
    }

    test "mSd" {
        let! n = gen1D
        use! A = genVector n
        let! s = Gen.Double.OneTwo
        let! a = Gen.Double.OneTwo
        use expected =
            let R = new vector(n)
            for i =0 to n-1 do
                R.[i] <- s * A.[i] + a
            R
        use actual = (s * A) + a |> impV
        Check.close High expected actual
    }

    test "mSd_reuse" {
        let! n = gen1D
        use! A = genVector n
        let! s = Gen.Double.OneTwo
        let! a = Gen.Double.OneTwo
        use expected =
            let R = new vector(n)
            for i =0 to n-1 do
                R.[i] <- s * A.[i] + a
            R
        use actual = (s * A + 0.0) + a |> impV
        Check.close High expected actual
    }

    test "mTSd" {
        let! n = gen1D
        use! A = genVector n
        let! s = Gen.Double.OneTwo
        let! a = Gen.Double.OneTwo
        use expected =
            let R = new vector(n)
            for i =0 to n-1 do
                R.[i] <- (s * A.[i]) + a
            R
        let actual = ((s * A.T) + a).T |> impV
        Check.close High expected actual
    }

    test "mTSd_reuse" {
        let! n = gen1D
        use! A = genVector n
        let! s = Gen.Double.OneTwo
        let! a = Gen.Double.OneTwo
        use expected =
            let R = new vector(n)
            for i =0 to n-1 do
                R.[i] <- (s * A.[i]) + a
            R
        let actual = ((s * A.T + 0.0) + a).T |> impV
        Check.close High expected actual
    }
}

let sub1 = test "sub1" {

    test "vv" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        use expected = add_vv 1.0 a -1.0 b
        use actual = a - b |> impV
        Check.close High expected actual
    }

    test "vv_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        use expected = add_vv 1.0 a -1.0 b
        use actual = (a + 0.0) - (b + 0.0) |> impV
        Check.close High expected actual
    }

    test "vvS" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv 1.0 a -s b
        use actual = a - s * b |> impV
        Check.close High expected actual
    }

    test "vvS_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv 1.0 a -s b
        use actual = (a + 0.0) - (s * b + 0.0) |> impV
        Check.close High expected actual
    }

    test "vTvT" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        use expected = add_vv 1.0 a -1.0 b
        use actual = (a.T - b.T).T |> impV
        Check.close High expected actual
    }

    test "vTvT_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        use expected = add_vv 1.0 a -1.0 b
        use actual = ((a.T + 0.0) - (b.T + 0.0)).T |> impV
        Check.close High expected actual
    }

    test "vTvTS" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv 1.0 a -s b
        use actual = (a.T - s * b.T).T |> impV
        Check.close High expected actual
    }

    test "vTvTS_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv 1.0 a -s b
        use actual = ((a.T + 0.0) - (s * b.T + 0.0)).T |> impV
        Check.close High expected actual
    }

    test "vSv" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv s a -1.0 b
        use actual = s * a - b |> impV
        Check.close High expected actual
    }

    test "vSv_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv s a -1.0 b
        use actual = (s * a + 0.0) - (b + 0.0) |> impV
        Check.close High expected actual
    }

    test "vSvS" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = add_vv s1 a -s2 b
        use actual = s1 * a - s2 * b |> impV
        Check.close High expected actual
    }

    test "vSvS_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = add_vv s1 a -s2 b
        use actual = (s1 * a + 0.0) - (s2 * b + 0.0) |> impV
        Check.close High expected actual
    }

    test "vTSvT" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv s a -1.0 b
        use actual = (s * a.T - b.T).T |> impV
        Check.close High expected actual
    }

}

let sub2 = test "sub2" {

    test "vTSvT_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = add_vv s a -1.0 b
        use actual = ((s * a.T + 0.0) - (b.T + 0.0)).T |> impV
        Check.close High expected actual
    }

    test "vTSvTS" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = add_vv s1 a -s2 b
        use actual = (s1 * a.T - s2 * b.T).T |> impV
        Check.close High expected actual
    }

    test "vTSvTS_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = add_vv s1 a -s2 b
        use actual = ((s1 * a.T + 0.0) - (s2 * b.T + 0.0)).T |> impV
        Check.close High expected actual
    }
}

let mul1 = test "mul1" {

    test "vvT" {
        let! m,n = gen2D
        use! a = genVector m
        use! b = genVector n
        use expected = mul_vvT 1.0 a b
        use actual = (a * b.T) |> impM
        Check.close High expected actual
    }

    test "vvT_reuse" {
        let! m,n = gen2D
        use! a = genVector m
        use! b = genVector n
        use expected = mul_vvT 1.0 a b
        use actual = ((a + 0.0) * (b.T + 0.0)) |> impM
        Check.close High expected actual
    }

    test "vvTS" {
        let! m,n = gen2D
        use! a = genVector m
        use! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = mul_vvT s a b
        use actual = a * (s * b.T) |> impM
        Check.close High expected actual
    }

    test "vvTS_reuse" {
        let! m,n = gen2D
        use! a = genVector m
        use! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = mul_vvT s a b
        use actual = (a + 0.0) * (s * b.T + 0.0) |> impM
        Check.close High expected actual
    }

    test "vTv" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let expected = mul_vTv a b
        let actual = a.T * b
        Check.close High expected actual
    }

    test "vTv_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let expected = mul_vTv a b
        let actual = (a.T + 0.0) * (b + 0.0)
        Check.close High expected actual
    }

    test "vTvS" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Double.OneTwo
        let expected = mul_vTv a b * s
        let actual = a.T * (b * s)
        Check.close High expected actual
    }

    test "vTvS_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Double.OneTwo
        let expected = mul_vTv a b * s
        let actual = (a.T + 0.0) * (b * s + 0.0)
        Check.close High expected actual
    }

    test "vSvT" {
        let! m,n = gen2D
        use! a = genVector m
        use! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = mul_vvT s a b
        use actual = (s * a) * b.T |> impM
        Check.close High expected actual
    }

    test "vSvT_reuse" {
        let! m,n = gen2D
        use! a = genVector m
        use! b = genVector n
        let! s = Gen.Double.OneTwo
        use expected = mul_vvT s a b
        use actual = (s * a + 0.0) * (b.T + 0.0) |> impM
        Check.close High expected actual
    }

    test "vSvTS" {
        let! m,n = gen2D
        use! a = genVector m
        use! b = genVector n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = mul_vvT (s1*s2) a b
        use actual = (s1 * a) * (s2 * b.T) |> impM
        Check.close High expected actual
    }

    test "vSvTS_reuse" {
        let! m,n = gen2D
        use! a = genVector m
        use! b = genVector n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = mul_vvT (s1*s2) a b
        use actual = (s1 * a + 0.0) * (s2 * b.T + 0.0) |> impM
        Check.close High expected actual
    }

    test "vTSv" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Double.OneTwo
        let expected = s * mul_vTv a b
        let actual = (s * a.T) * b
        Check.close High expected actual
    }

    test "vTSv_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Double.OneTwo
        let expected = s * mul_vTv a b
        let actual = (s * a.T + 0.0) * (b + 0.0)
        Check.close High expected actual
    }
}

let mul2 = test "mul2" {

    test "vTSvS" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        let expected = s1 * mul_vTv a b * s2
        let actual = (s1 * a.T) * (b * s2)
        Check.close High expected actual
    }

    test "vTSvS_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        let expected = s1 * mul_vTv a b * s2
        let actual = (s1 * a.T + 0.0) * (b * s2 + 0.0)
        Check.close High expected actual
    }

    test "vTm" {
        let! m,n = gen2D
        use! a = genVector m
        use! B = genMatrix m n
        use expected = mul_vTm 1.0 a B
        use actual = (a.T * B).T |> impV
        Check.close High expected actual
    }

    test "vTm_reuse" {
        let! m,n = gen2D
        use! a = genVector m
        use! B = genMatrix m n
        use expected = mul_vTm 1.0 a B
        use actual = ((a.T + 0.0) * (B + 0.0)).T |> impV
        Check.close High expected actual
    }

    test "vTmT" {
        let! m,n = gen2D
        use! a = genVector m
        use! B = genMatrix n m
        use expected = mul_vTmT 1.0 a B
        use actual = (a.T * B.T).T |> impV
        Check.close High expected actual
    }

    test "vTmT_reuse" {
        let! m,n = gen2D
        use! a = genVector m
        use! B = genMatrix n m
        use expected = mul_vTmT 1.0 a B
        use actual = ((a.T + 0.0) * (B.T + 0.0)).T |> impV
        Check.close High expected actual
    }

    test "vTmTS" {
        let! m,n = gen2D
        use! a = genVector m
        use! B = genMatrix n m
        let! s = Gen.Double.OneTwo
        use expected = mul_vTmT s a B
        use actual = (a.T * (s * B.T)).T |> impV
        Check.close High expected actual
    }

    test "vTmTS_reuse" {
        let! m,n = gen2D
        use! a = genVector m
        use! B = genMatrix n m
        let! s = Gen.Double.OneTwo
        use expected = mul_vTmT s a B
        use actual = ((a.T + 0.0) * (s * B.T + 0.0)).T |> impV
        Check.close High expected actual
    }

    test "vTSm" {
        let! m,n = gen2D
        use! a = genVector m
        use! B = genMatrix m n
        let! s = Gen.Double.OneTwo
        use expected = mul_vTm s a B
        use actual = ((s * a.T) * B).T |> impV
        Check.close High expected actual
    }

    test "vTSm_reuse" {
        let! m,n = gen2D
        use! a = genVector m
        use! B = genMatrix m n
        let! s = Gen.Double.OneTwo
        use expected = mul_vTm s a B
        use actual = ((s * a.T + 0.0) * (B + 0.0)).T |> impV
        Check.close High expected actual
    }

    test "vTSmT" {
        let! m,n = gen2D
        use! a = genVector m
        use! B = genMatrix n m
        let! s = Gen.Double.OneTwo
        use expected = mul_vTmT s a B
        use actual = ((s * a.T) * B.T).T |> impV
        Check.close High expected actual
    }

    test "vTSmT_reuse" {
        let! m,n = gen2D
        use! a = genVector m
        use! B = genMatrix n m
        let! s = Gen.Double.OneTwo
        use expected = mul_vTmT s a B
        use actual = ((s * a.T + 0.0) * (B.T + 0.0)).T |> impV
        Check.close High expected actual
    }

    test "vTSmTS" {
        let! m,n = gen2D
        use! a = genVector m
        use! B = genMatrix n m
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = mul_vTmT (s1*s2) a B
        use actual = ((s1 * a.T) * (s2 * B.T)).T |> impV
        Check.close High expected actual
    }

    test "vTSmTS_reuse" {
        let! m,n = gen2D
        use! a = genVector m
        use! B = genMatrix n m
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = mul_vTmT (s1*s2) a B
        use actual = ((s1 * a.T + 0.0) * (s2 * B.T + 0.0)).T |> impV
        Check.close High expected actual
    }
}

let testUnary name
    (fexpected:double -> double)
    (factual:VectorExpression -> VectorExpression)
    (factualT:VectorTExpression -> VectorTExpression) =
    let map (A:vector) =
        let E = new vector(A.Length)
        for i = 0 to A.Length-1 do
            E.[i] <- fexpected(A.[i])
        E
    test name {
        let! n = gen1D
        use! A = genVector n
        use expected = map A
        use actual = A |> impVE |> factual |> impV
        Check.close High expected actual
        use actual = (factualT A.T).T |> impV
        Check.close High expected actual
    }

let functions1 = test "functions1" {

    testUnary "Abs" abs Vector.Abs Vector.Abs
    testUnary "Sqr" (fun x -> x*x) Vector.Sqr Vector.Sqr
    testUnary "Inv" (fun x -> 1.0/x) Vector.Inv Vector.Inv
    testUnary "Sqrt" sqrt Vector.Sqrt Vector.Sqrt
    testUnary "InvSqrt" (fun x -> 1.0/sqrt x) Vector.InvSqrt Vector.InvSqrt
#if NETCOREAPP
    testUnary "Cbrt" Math.Cbrt Vector.Cbrt Vector.Cbrt
    testUnary "InvCbrt" ((/) 1.0 >> Math.Cbrt) Vector.InvCbrt Vector.InvCbrt
    testUnary "Pow2o3" (fun a -> Math.Cbrt(a*a)) Vector.Pow2o3 Vector.Pow2o3
#endif
    testUnary "Pow3o2" (fun a -> Math.Sqrt(a*a*a)) Vector.Pow3o2 Vector.Pow3o2
    testUnary "Exp" exp Vector.Exp Vector.Exp
    testUnary "Exp2" (fun i -> Math.Pow(2.0,i)) Vector.Exp2 Vector.Exp2
    testUnary "Exp10" (fun i -> Math.Pow(10.0,i)) Vector.Exp10 Vector.Exp10
    testUnary "Expm1" (fun i -> exp i-1.0) Vector.Expm1 Vector.Expm1
    testUnary "Ln" log Vector.Ln Vector.Ln
#if NETCOREAPP
    testUnary "Log2" Math.Log2 Vector.Log2 Vector.Log2
#endif
    testUnary "Log10" log10 Vector.Log10 Vector.Log10
    testUnary "Log1p" (fun i -> log(i+1.0)) Vector.Log1p Vector.Log1p
#if NETCOREAPP
    testUnary "Logb" (fun i -> Math.ILogB(i) |> double) Vector.Logb Vector.Logb
#endif
}

let functions2 = test "functions2" {
    testUnary "Cos" cos Vector.Cos Vector.Cos
    testUnary "Sin" sin Vector.Sin Vector.Sin
    testUnary "Tan" tan Vector.Tan Vector.Tan
    testUnary "Cospi" (fun i -> cos(Math.PI*i)) Vector.Cospi Vector.Cospi
    testUnary "Sinpi" (fun i -> sin(Math.PI*i)) Vector.Sinpi Vector.Sinpi
    testUnary "Tanpi" (fun i -> tan(Math.PI*i)) Vector.Tanpi Vector.Tanpi
    testUnary "Cosd" (fun i -> cos(Math.PI/180.0*i)) Vector.Cosd Vector.Cosd
    testUnary "Sind" (fun i -> sin(Math.PI/180.0*i)) Vector.Sind Vector.Sind
    testUnary "Tand" (fun i -> tan(Math.PI/180.0*i)) Vector.Tand Vector.Tand
    testUnary "Acos" acos Vector.Acos Vector.Acos
    testUnary "Asin" asin Vector.Asin Vector.Asin
    testUnary "Atan" atan Vector.Atan Vector.Atan
    testUnary "Acospi" (fun i -> acos i / Math.PI) Vector.Acospi Vector.Acospi
    testUnary "Asinpi" (fun i -> asin i / Math.PI) Vector.Asinpi Vector.Asinpi
    testUnary "Atanpi" (fun i -> atan i / Math.PI) Vector.Atanpi Vector.Atanpi
    testUnary "Cosh" cosh Vector.Cosh Vector.Cosh
    testUnary "Sinh" sinh Vector.Sinh Vector.Sinh
    testUnary "Tanh" tanh Vector.Tanh Vector.Tanh
#if NETCOREAPP
    testUnary "Acosh" Math.Acosh Vector.Acosh Vector.Acosh
    testUnary "Asinh" Math.Asinh Vector.Asinh Vector.Asinh
    testUnary "Atanh" Math.Atanh Vector.Atanh Vector.Atanh
#endif
    testUnary "Erf" erf Vector.Erf Vector.Erf
    testUnary "Erfc" erfc Vector.Erfc Vector.Erfc
    testUnary "ErfInv" erfinv Vector.ErfInv Vector.ErfInv
    testUnary "ErfcInv" erfcinv Vector.ErfcInv Vector.ErfcInv
    testUnary "CdfNorm" normcdf Vector.CdfNorm Vector.CdfNorm
    testUnary "CdfNormInv" normcdfinv Vector.CdfNormInv Vector.CdfNormInv
    testUnary "LGamma" lgamma Vector.LGamma Vector.LGamma
    testUnary "TGamma" gamma Vector.TGamma Vector.TGamma
    testUnary "ExpInt1" (expint 1) Vector.ExpInt1 Vector.ExpInt1
    testUnary "Floor" floor Vector.Floor Vector.Floor
    testUnary "Ceil" ceil Vector.Ceil Vector.Ceil
    testUnary "Truncate" truncate Vector.Truncate Vector.Truncate
    testUnary "Round" Math.Round Vector.Round Vector.Round
    testUnary "RoundAwayFromZero" (fun a -> Math.Round(a, MidpointRounding.AwayFromZero)) Vector.RoundAwayFromZero Vector.RoundAwayFromZero
    testUnary "Frac" (fun a -> a - truncate a) Vector.Frac Vector.Frac
    testUnary "NearbyInt" (fun a -> Math.Round(a, MidpointRounding.ToEven)) Vector.NearbyInt Vector.NearbyInt
    testUnary "Rint" (fun a -> Math.Round(a, MidpointRounding.ToEven)) Vector.Rint Vector.Rint
}

let all =
    test "vector" {
        add1
        add2
        sub1
        sub2
        mul1
        mul2
        functions1
        functions2
    }