module SingleVectorTests

open System
open MKLNET.Single
open MKLNET.Single.Expression
open CsCheck

let MAX_DIM = 5
let gen1D = Gen.Int[1,MAX_DIM]
let gen2D = Gen.Select(gen1D,gen1D)

let genVector length =
    Gen.Create(fun (pcg:PCG) (_:Size) (size:Size byref) ->
        size <- Size 0UL
        let v = new vector(length)
        let gen = Gen.Single.OneTwo
        for i =0 to length-1 do
            let d,_ = gen.Generate(pcg, null)
            v[i] <- d
        v
    )

let genMatrix rows cols =
    Gen.Create(fun (pcg:PCG) (_:Size) (size:Size byref) ->
        size <- Size 0UL
        let m = new matrix(rows,cols)
        let gen = Gen.Single.OneTwo
        for r =0 to rows-1 do
            for c=0 to cols-1 do
                let d,_ = gen.Generate(pcg, null)
                m[r,c] <- d
        m
    )

let add_vv (aS:single) (a:vector) (bS:single) (b:vector) =
    let c = new vector(a.Length)
    for i = 0 to a.Length-1 do
         c[i] <- aS * a[i] + bS * b[i]
    c

let mul_vvT (s:single) (a:vector) (b:vector) =
    let C = new matrix(a.Length, b.Length)
    for r = 0 to C.Rows-1 do
        for c=0 to C.Cols-1 do
            C[r,c] <- s * a[r] * b[c]
    C

let mul_vTv (a:vector) (b:vector) =
    let mutable t = 0.0f
    for i = 0 to a.Length-1 do
        t <- t + a[i] * b[i]
    t

let mul_vTm (s:single) (a:vector) (B:matrix) =
    let c = new vector(B.Cols)
    for i = 0 to B.Cols - 1 do
        let mutable t = 0.0f
        for r = 0 to a.Length - 1 do
            t <- t + a[r] * B[r,i]
        c[i] <- s * t
    c

let mul_vTmT (s:single) (a:vector) (B:matrix) =
    let c = new vector(B.Rows)
    for i = 0 to B.Rows - 1 do
        let mutable t = 0.0f
        for r = 0 to a.Length - 1 do
            t <- t + a[r] * B[i,r]
        c[i] <- s * t
    c

let impM (m:MatrixExpression) = MatrixExpression.op_Implicit m
let impV (m:VectorExpression) = VectorExpression.op_Implicit m
let impVE (m:vector) = VectorExpression.op_Implicit m

let add1 = test "add1" {

    test "vv" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        use expected = add_vv 1.0f a 1.0f b
        use actual = a + b |> impV
        Check.close Medium expected actual
    }

    test "vv_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        use expected = add_vv 1.0f a 1.0f b
        use actual = (a + 0.0f) + (b + 0.0f) |> impV
        Check.close Medium expected actual
    }

    test "vvS" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Single.OneTwo
        use expected = add_vv 1.0f a s b
        use actual = a + s * b |> impV
        Check.close Medium expected actual
    }

    test "vvS_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Single.OneTwo
        use expected = add_vv 1.0f a s b
        use actual = (a + 0.0f) + (s * b + 0.0f) |> impV
        Check.close Medium expected actual
    }

    test "vTvT" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        use expected = add_vv 1.0f a 1.0f b
        use actual = (a.T + b.T).T |> impV
        Check.close Medium expected actual
    }

    test "vTvT_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        use expected = add_vv 1.0f a 1.0f b
        use actual = ((a.T + 0.0f) + (b.T + 0.0f)).T |> impV
        Check.close Medium expected actual
    }

    test "vTvTS" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Single.OneTwo
        use expected = add_vv 1.0f a s b
        use actual = (a.T + s * b.T).T |> impV
        Check.close Medium expected actual
    }

    test "vTvTS_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Single.OneTwo
        use expected = add_vv 1.0f a s b
        use actual = ((a.T + 0.0f) + (s * b.T + 0.0f)).T |> impV
        Check.close Medium expected actual
    }

    test "vSv" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Single.OneTwo
        use expected = add_vv s a 1.0f b
        use actual = s * a + b |> impV
        Check.close Medium expected actual
    }

    test "vSv_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Single.OneTwo
        use expected = add_vv s a 1.0f b
        use actual = (s * a + 0.0f) + (b + 0.0f) |> impV
        Check.close Medium expected actual
    }

    test "vSvS" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = add_vv s1 a s2 b
        use actual = s1 * a + s2 * b |> impV
        Check.close Medium expected actual
    }

    test "vSvS_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = add_vv s1 a s2 b
        use actual = (s1 * a + 0.0f) + (s2 * b + 0.0f) |> impV
        Check.close Medium expected actual
    }

    test "vTSvT" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Single.OneTwo
        use expected = add_vv s a 1.0f b
        use actual = (s * a.T + b.T).T |> impV
        Check.close Medium expected actual
    }

    test "vTSvT_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Single.OneTwo
        use expected = add_vv s a 1.0f b
        use actual = ((s * a.T + 0.0f) + (b.T + 0.0f)).T |> impV
        Check.close Medium expected actual
    }

    test "vTSvTS" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = add_vv s1 a s2 b
        use actual = (s1 * a.T + s2 * b.T).T |> impV
        Check.close Medium expected actual
    }

    test "vTSvTS_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = add_vv s1 a s2 b
        use actual = ((s1 * a.T + 0.0f) + (s2 * b.T + 0.0f)).T |> impV
        Check.close Medium expected actual
    }
}

let add2 = test "add2" {

    test "vd" {
        let! n = gen1D
        use! A = genVector n
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new vector(n)
            for i =0 to n-1 do
                R[i] <- A[i] + a
            R
        use actual = A + a |> impV
        Check.close Medium expected actual
    }

    test "vd_reuse" {
        let! n = gen1D
        use! A = genVector n
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new vector(n)
            for i =0 to n-1 do
                R[i] <- A[i] + a
            R
        use actual = (A + 0.0f) + a |> impV
        Check.close Medium expected actual
    }

    test "vTd" {
        let! n = gen1D
        use! A = genVector n
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new vector(n)
            for i =0 to n-1 do
                R[i] <- A[i] + a
            R
        let actual = (A.T + a).T |> impV
        Check.close Medium expected actual
    }

    test "vTd_reuse" {
        let! n = gen1D
        use! A = genVector n
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new vector(n)
            for i =0 to n-1 do
                R[i] <- A[i] + a
            R
        let actual = ((A.T + 0.0f) + a).T |> impV
        Check.close Medium expected actual
    }

    test "mSd" {
        let! n = gen1D
        use! A = genVector n
        let! s = Gen.Single.OneTwo
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new vector(n)
            for i =0 to n-1 do
                R[i] <- s * A[i] + a
            R
        use actual = (s * A) + a |> impV
        Check.close Medium expected actual
    }

    test "mSd_reuse" {
        let! n = gen1D
        use! A = genVector n
        let! s = Gen.Single.OneTwo
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new vector(n)
            for i =0 to n-1 do
                R[i] <- s * A[i] + a
            R
        use actual = (s * A + 0.0f) + a |> impV
        Check.close Medium expected actual
    }

    test "mTSd" {
        let! n = gen1D
        use! A = genVector n
        let! s = Gen.Single.OneTwo
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new vector(n)
            for i =0 to n-1 do
                R[i] <- (s * A[i]) + a
            R
        let actual = ((s * A.T) + a).T |> impV
        Check.close Medium expected actual
    }

    test "mTSd_reuse" {
        let! n = gen1D
        use! A = genVector n
        let! s = Gen.Single.OneTwo
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new vector(n)
            for i =0 to n-1 do
                R[i] <- (s * A[i]) + a
            R
        let actual = ((s * A.T + 0.0f) + a).T |> impV
        Check.close Medium expected actual
    }
}

let sub1 = test "sub1" {

    test "vv" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        use expected = add_vv 1.0f a -1.0f b
        use actual = a - b |> impV
        Check.close Medium expected actual
    }

    test "vv_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        use expected = add_vv 1.0f a -1.0f b
        use actual = (a + 0.0f) - (b + 0.0f) |> impV
        Check.close Medium expected actual
    }

    test "vvS" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Single.OneTwo
        use expected = add_vv 1.0f a -s b
        use actual = a - s * b |> impV
        Check.close Medium expected actual
    }

    test "vvS_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Single.OneTwo
        use expected = add_vv 1.0f a -s b
        use actual = (a + 0.0f) - (s * b + 0.0f) |> impV
        Check.close Medium expected actual
    }

    test "vTvT" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        use expected = add_vv 1.0f a -1.0f b
        use actual = (a.T - b.T).T |> impV
        Check.close Medium expected actual
    }

    test "vTvT_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        use expected = add_vv 1.0f a -1.0f b
        use actual = ((a.T + 0.0f) - (b.T + 0.0f)).T |> impV
        Check.close Medium expected actual
    }

    test "vTvTS" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Single.OneTwo
        use expected = add_vv 1.0f a -s b
        use actual = (a.T - s * b.T).T |> impV
        Check.close Medium expected actual
    }

    test "vTvTS_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Single.OneTwo
        use expected = add_vv 1.0f a -s b
        use actual = ((a.T + 0.0f) - (s * b.T + 0.0f)).T |> impV
        Check.close Medium expected actual
    }

    test "vSv" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Single.OneTwo
        use expected = add_vv s a -1.0f b
        use actual = s * a - b |> impV
        Check.close Medium expected actual
    }

    test "vSv_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Single.OneTwo
        use expected = add_vv s a -1.0f b
        use actual = (s * a + 0.0f) - (b + 0.0f) |> impV
        Check.close Medium expected actual
    }

    test "vSvS" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = add_vv s1 a -s2 b
        use actual = s1 * a - s2 * b |> impV
        Check.close Medium expected actual
    }

    test "vSvS_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = add_vv s1 a -s2 b
        use actual = (s1 * a + 0.0f) - (s2 * b + 0.0f) |> impV
        Check.close Medium expected actual
    }

    test "vTSvT" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Single.OneTwo
        use expected = add_vv s a -1.0f b
        use actual = (s * a.T - b.T).T |> impV
        Check.close Medium expected actual
    }

}

let sub2 = test "sub2" {

    test "vTSvT_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Single.OneTwo
        use expected = add_vv s a -1.0f b
        use actual = ((s * a.T + 0.0f) - (b.T + 0.0f)).T |> impV
        Check.close Medium expected actual
    }

    test "vTSvTS" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = add_vv s1 a -s2 b
        use actual = (s1 * a.T - s2 * b.T).T |> impV
        Check.close Medium expected actual
    }

    test "vTSvTS_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = add_vv s1 a -s2 b
        use actual = ((s1 * a.T + 0.0f) - (s2 * b.T + 0.0f)).T |> impV
        Check.close Medium expected actual
    }
}

let mul1 = test "mul1" {

    test "vvT" {
        let! m,n = gen2D
        use! a = genVector m
        use! b = genVector n
        use expected = mul_vvT 1.0f a b
        use actual = (a * b.T) |> impM
        Check.close Medium expected actual
    }

    test "vvT_reuse" {
        let! m,n = gen2D
        use! a = genVector m
        use! b = genVector n
        use expected = mul_vvT 1.0f a b
        use actual = ((a + 0.0f) * (b.T + 0.0f)) |> impM
        Check.close Medium expected actual
    }

    test "vvTS" {
        let! m,n = gen2D
        use! a = genVector m
        use! b = genVector n
        let! s = Gen.Single.OneTwo
        use expected = mul_vvT s a b
        use actual = a * (s * b.T) |> impM
        Check.close Medium expected actual
    }

    test "vvTS_reuse" {
        let! m,n = gen2D
        use! a = genVector m
        use! b = genVector n
        let! s = Gen.Single.OneTwo
        use expected = mul_vvT s a b
        use actual = (a + 0.0f) * (s * b.T + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "vTv" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let expected = mul_vTv a b
        let actual = a.T * b
        Check.close Medium expected actual
    }

    test "vTv_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let expected = mul_vTv a b
        let actual = (a.T + 0.0f) * (b + 0.0f)
        Check.close Medium expected actual
    }

    test "vTvS" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Single.OneTwo
        let expected = mul_vTv a b * s
        let actual = a.T * (b * s)
        Check.close Medium expected actual
    }

    test "vTvS_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Single.OneTwo
        let expected = mul_vTv a b * s
        let actual = (a.T + 0.0f) * (b * s + 0.0f)
        Check.close Medium expected actual
    }

    test "vSvT" {
        let! m,n = gen2D
        use! a = genVector m
        use! b = genVector n
        let! s = Gen.Single.OneTwo
        use expected = mul_vvT s a b
        use actual = (s * a) * b.T |> impM
        Check.close Medium expected actual
    }

    test "vSvT_reuse" {
        let! m,n = gen2D
        use! a = genVector m
        use! b = genVector n
        let! s = Gen.Single.OneTwo
        use expected = mul_vvT s a b
        use actual = (s * a + 0.0f) * (b.T + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "vSvTS" {
        let! m,n = gen2D
        use! a = genVector m
        use! b = genVector n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = mul_vvT (s1*s2) a b
        use actual = (s1 * a) * (s2 * b.T) |> impM
        Check.close Medium expected actual
    }

    test "vSvTS_reuse" {
        let! m,n = gen2D
        use! a = genVector m
        use! b = genVector n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = mul_vvT (s1*s2) a b
        use actual = (s1 * a + 0.0f) * (s2 * b.T + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "vTSv" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Single.OneTwo
        let expected = s * mul_vTv a b
        let actual = (s * a.T) * b
        Check.close Medium expected actual
    }

    test "vTSv_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s = Gen.Single.OneTwo
        let expected = s * mul_vTv a b
        let actual = (s * a.T + 0.0f) * (b + 0.0f)
        Check.close Medium expected actual
    }
}

let mul2 = test "mul2" {

    test "vTSvS" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        let expected = s1 * mul_vTv a b * s2
        let actual = (s1 * a.T) * (b * s2)
        Check.close Medium expected actual
    }

    test "vTSvS_reuse" {
        let! n = gen1D
        use! a = genVector n
        use! b = genVector n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        let expected = s1 * mul_vTv a b * s2
        let actual = (s1 * a.T + 0.0f) * (b * s2 + 0.0f)
        Check.close Medium expected actual
    }

    test "vTm" {
        let! m,n = gen2D
        use! a = genVector m
        use! B = genMatrix m n
        use expected = mul_vTm 1.0f a B
        use actual = (a.T * B).T |> impV
        Check.close Medium expected actual
    }

    test "vTm_reuse" {
        let! m,n = gen2D
        use! a = genVector m
        use! B = genMatrix m n
        use expected = mul_vTm 1.0f a B
        use actual = ((a.T + 0.0f) * (B + 0.0f)).T |> impV
        Check.close Medium expected actual
    }

    test "vTmT" {
        let! m,n = gen2D
        use! a = genVector m
        use! B = genMatrix n m
        use expected = mul_vTmT 1.0f a B
        use actual = (a.T * B.T).T |> impV
        Check.close Medium expected actual
    }

    test "vTmT_reuse" {
        let! m,n = gen2D
        use! a = genVector m
        use! B = genMatrix n m
        use expected = mul_vTmT 1.0f a B
        use actual = ((a.T + 0.0f) * (B.T + 0.0f)).T |> impV
        Check.close Medium expected actual
    }

    test "vTmTS" {
        let! m,n = gen2D
        use! a = genVector m
        use! B = genMatrix n m
        let! s = Gen.Single.OneTwo
        use expected = mul_vTmT s a B
        use actual = (a.T * (s * B.T)).T |> impV
        Check.close Medium expected actual
    }

    test "vTmTS_reuse" {
        let! m,n = gen2D
        use! a = genVector m
        use! B = genMatrix n m
        let! s = Gen.Single.OneTwo
        use expected = mul_vTmT s a B
        use actual = ((a.T + 0.0f) * (s * B.T + 0.0f)).T |> impV
        Check.close Medium expected actual
    }

    test "vTSm" {
        let! m,n = gen2D
        use! a = genVector m
        use! B = genMatrix m n
        let! s = Gen.Single.OneTwo
        use expected = mul_vTm s a B
        use actual = ((s * a.T) * B).T |> impV
        Check.close Medium expected actual
    }

    test "vTSm_reuse" {
        let! m,n = gen2D
        use! a = genVector m
        use! B = genMatrix m n
        let! s = Gen.Single.OneTwo
        use expected = mul_vTm s a B
        use actual = ((s * a.T + 0.0f) * (B + 0.0f)).T |> impV
        Check.close Medium expected actual
    }

    test "vTSmT" {
        let! m,n = gen2D
        use! a = genVector m
        use! B = genMatrix n m
        let! s = Gen.Single.OneTwo
        use expected = mul_vTmT s a B
        use actual = ((s * a.T) * B.T).T |> impV
        Check.close Medium expected actual
    }

    test "vTSmT_reuse" {
        let! m,n = gen2D
        use! a = genVector m
        use! B = genMatrix n m
        let! s = Gen.Single.OneTwo
        use expected = mul_vTmT s a B
        use actual = ((s * a.T + 0.0f) * (B.T + 0.0f)).T |> impV
        Check.close Medium expected actual
    }

    test "vTSmTS" {
        let! m,n = gen2D
        use! a = genVector m
        use! B = genMatrix n m
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = mul_vTmT (s1*s2) a B
        use actual = ((s1 * a.T) * (s2 * B.T)).T |> impV
        Check.close Medium expected actual
    }

    test "vTSmTS_reuse" {
        let! m,n = gen2D
        use! a = genVector m
        use! B = genMatrix n m
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = mul_vTmT (s1*s2) a B
        use actual = ((s1 * a.T + 0.0f) * (s2 * B.T + 0.0f)).T |> impV
        Check.close Medium expected actual
    }
}

let testUnary name
    (fexpected:single -> single)
    (factual:VectorExpression -> VectorExpression)
    (factualT:VectorTExpression -> VectorTExpression) =
    let map (A:vector) =
        let E = new vector(A.Length)
        for i = 0 to A.Length-1 do
            E[i] <- fexpected(A[i])
        E
    test name {
        let! n = gen1D
        use! A = genVector n
        use expected = map A
        use actual = A |> impVE |> factual |> impV
        Check.close Medium expected actual
        use actual = (factualT A.T).T |> impV
        Check.close Medium expected actual
    }

let testUnaryLow name
    (fexpected:single -> single)
    (factual:VectorExpression -> VectorExpression)
    (factualT:VectorTExpression -> VectorTExpression) =
    let map (A:vector) =
        let E = new vector(A.Length)
        for i = 0 to A.Length-1 do
            E[i] <- fexpected(A[i])
        E
    test name {
        let! n = gen1D
        use! A = genVector n
        use expected = map A
        use actual = A |> impVE |> factual |> impV
        Check.close Low expected actual
        use actual = (factualT A.T).T |> impV
        Check.close Low expected actual
    }

let functions1 = test "functions1" {

    testUnary "Abs" abs Vector.Abs Vector.Abs
    testUnary "Sqr" (fun x -> x*x) Vector.Sqr Vector.Sqr
    testUnary "Inv" (fun x -> 1.0f/x) Vector.Inv Vector.Inv
    testUnary "Sqrt" sqrt Vector.Sqrt Vector.Sqrt
    testUnary "InvSqrt" (fun x -> 1.0f/sqrt x) Vector.InvSqrt Vector.InvSqrt
#if NETCOREAPP
    testUnary "Cbrt" (double >> Math.Cbrt >> single) Vector.Cbrt Vector.Cbrt
    testUnary "InvCbrt" ((/) 1.0f >> double >> Math.Cbrt >> single) Vector.InvCbrt Vector.InvCbrt
    testUnary "Pow2o3" (fun a -> let a = double a in Math.Cbrt(a*a) |> single) Vector.Pow2o3 Vector.Pow2o3
#endif
    testUnary "Pow3o2" (fun a -> let a = double a in Math.Sqrt(a*a*a) |> single) Vector.Pow3o2 Vector.Pow3o2
    testUnary "Exp" exp Vector.Exp Vector.Exp
    testUnary "Exp2" (fun i -> Math.Pow(2.0,double i) |> single) Vector.Exp2 Vector.Exp2
    testUnary "Exp10" (fun i -> Math.Pow(10.0,double i) |> single) Vector.Exp10 Vector.Exp10
    testUnary "Expm1" (fun i -> exp i-1.0f) Vector.Expm1 Vector.Expm1
    testUnary "Ln" log Vector.Ln Vector.Ln
#if NETCOREAPP
    testUnary "Log2" (double >> Math.Log2 >> single) Vector.Log2 Vector.Log2
#endif
    testUnary "Log10" log10 Vector.Log10 Vector.Log10
    testUnary "Log1p" (fun i -> log(i+1.0f)) Vector.Log1p Vector.Log1p
#if NETCOREAPP
    testUnary "Logb" (fun i -> Math.ILogB(double i) |> single) Vector.Logb Vector.Logb
#endif
}

let functions2 = test "functions2" {
    testUnary "Cos" cos Vector.Cos Vector.Cos
    testUnary "Sin" sin Vector.Sin Vector.Sin
    testUnary "Tan" tan Vector.Tan Vector.Tan
    testUnary "Cospi" (fun i -> cos(single Math.PI*i)) Vector.Cospi Vector.Cospi
    testUnary "Sinpi" (fun i -> sin(single Math.PI*i)) Vector.Sinpi Vector.Sinpi
    testUnaryLow "Tanpi" (fun i -> tan(single Math.PI*i)) Vector.Tanpi Vector.Tanpi
    testUnary "Cosd" (fun i -> cos(single (Math.PI/180.0)*i)) Vector.Cosd Vector.Cosd
    testUnary "Sind" (fun i -> sin(single (Math.PI/180.0)*i)) Vector.Sind Vector.Sind
    testUnary "Tand" (fun i -> tan(single (Math.PI/180.0)*i)) Vector.Tand Vector.Tand
    testUnary "Acos" acos Vector.Acos Vector.Acos
    testUnary "Asin" asin Vector.Asin Vector.Asin
    testUnary "Atan" atan Vector.Atan Vector.Atan
    testUnary "Cosh" cosh Vector.Cosh Vector.Cosh
    testUnary "Sinh" sinh Vector.Sinh Vector.Sinh
    testUnary "Tanh" tanh Vector.Tanh Vector.Tanh
#if NETCOREAPP
    testUnary "Acosh" (double >> Math.Acosh >> single) Vector.Acosh Vector.Acosh
    testUnary "Asinh" (double >> Math.Asinh >> single) Vector.Asinh Vector.Asinh
    testUnary "Atanh" (double >> Math.Atanh >> single) Vector.Atanh Vector.Atanh
#endif
    testUnary "Erf" (double >> erf >> single) Vector.Erf Vector.Erf
    testUnary "Erfc" (double >> erfc >> single) Vector.Erfc Vector.Erfc
    testUnary "ErfInv" (double >> erfinv >> single) Vector.ErfInv Vector.ErfInv
    testUnary "ErfcInv" (double >> erfcinv >> single) Vector.ErfcInv Vector.ErfcInv
    testUnary "CdfNorm" (double >> normcdf >> single) Vector.CdfNorm Vector.CdfNorm
    testUnary "CdfNormInv" (double >> normcdfinv >> single) Vector.CdfNormInv Vector.CdfNormInv
    testUnary "LGamma" (double >> lgamma >> single) Vector.LGamma Vector.LGamma
    testUnary "TGamma" (double >> gamma >> single) Vector.TGamma Vector.TGamma
    testUnary "ExpInt1" (double >> expint 1 >> single) Vector.ExpInt1 Vector.ExpInt1
    testUnary "Floor" floor Vector.Floor Vector.Floor
    testUnary "Ceil" ceil Vector.Ceil Vector.Ceil
    testUnary "Truncate" truncate Vector.Truncate Vector.Truncate
    testUnary "Round" (double >> Math.Round >> single) Vector.Round Vector.Round
    testUnary "RoundAwayFromZero" (fun a -> Math.Round(double a, MidpointRounding.AwayFromZero) |> single) Vector.RoundAwayFromZero Vector.RoundAwayFromZero
    testUnary "Frac" (fun a -> a - truncate a) Vector.Frac Vector.Frac
    testUnary "NearbyInt" (fun a -> Math.Round(double a, MidpointRounding.ToEven) |> single) Vector.NearbyInt Vector.NearbyInt
    testUnary "Rint" (fun a -> Math.Round(double a, MidpointRounding.ToEven) |> single) Vector.Rint Vector.Rint
}

let all =
    test "singlevector" {
        add1
        add2
        sub1
        sub2
        mul1
        mul2
        functions1
        functions2
    }