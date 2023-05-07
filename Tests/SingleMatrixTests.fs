module SingleMatrixTests

open System
open MKLNET.Single
open MKLNET.Single.Expression
open CsCheck

let MAX_DIM = 5
let gen1D = Gen.Int[1,MAX_DIM]
let gen2D = Gen.Select(gen1D,gen1D)
let gen3D = Gen.Select(gen1D,gen1D,gen1D)

module BothPrecisions =
    open MKLNET

    let md = new matrix(2,2)
    let vd = new vector(2)

    let d = md * vd

    let mf = new Single.matrix(2,2)
    let vf = new Single.vector(2)

    let f = mf * vf

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

let add_mm (aS:single) (A:matrix) (bS:single) (B:matrix) =
    let C = new matrix(A.Rows,A.Cols)
    for r=0 to A.Rows-1 do
        for c=0 to A.Cols-1 do
            C[r,c] <- aS * A[r,c] + bS * B[r,c]
    C

let add_mmT (aS:single) (A:matrix) (bS:single) (B:matrix) =
    let C = new matrix(A.Rows,A.Cols)
    for r=0 to A.Rows-1 do
        for c=0 to A.Cols-1 do
            C[r,c] <- aS * A[r,c] + bS * B[c,r]
    C

let add_mTm (aS:single) (A:matrix) (bS:single) (B:matrix) =
    let C = new matrix(A.Cols,A.Rows)
    for r=0 to A.Cols-1 do
        for c=0 to A.Rows-1 do
            C[r,c] <- aS * A[c,r] + bS * B[r,c]
    C

let add_mTmT (aS:single) (A:matrix) (bS:single) (B:matrix) =
    let C = new matrix(A.Cols,A.Rows)
    for r=0 to A.Cols-1 do
        for c=0 to A.Rows-1 do
            C[r,c] <- aS * A[c,r] + bS * B[c,r]
    C

let mul_mm (s:single) (A:matrix) (B:matrix) =
    let C = new matrix(A.Rows,B.Cols)
    for r=0 to A.Rows-1 do
        for c=0 to B.Cols-1 do
            let mutable t = 0.0f
            for i = 0 to A.Cols-1 do
                t <- t + A[r,i] * B[i,c]
            C[r,c] <- s * t
    C

let mul_mTm (s:single) (A:matrix) (B:matrix) =
    let C = new matrix(A.Cols,B.Cols)
    for r=0 to A.Cols-1 do
        for c=0 to B.Cols-1 do
            let mutable t = 0.0f
            for i = 0 to A.Rows-1 do
                t <- t + A[i,r] * B[i,c]
            C[r,c] <- s * t
    C

let mul_mmT (s:single) (A:matrix) (B:matrix) =
    let C = new matrix(A.Rows,B.Rows)
    for r=0 to A.Rows-1 do
        for c=0 to B.Rows-1 do
            let mutable t = 0.0f
            for i = 0 to A.Cols-1 do
                t <- t + A[r,i] * B[c,i]
            C[r,c] <- s * t
    C

let mul_mTmT (s:single) (A:matrix) (B:matrix) =
    let C = new matrix(A.Cols,B.Rows)
    for r=0 to A.Cols-1 do
        for c=0 to B.Rows-1 do
            let mutable t = 0.0f
            for i = 0 to A.Rows-1 do
                t <- t + A[i,r] * B[c,i]
            C[r,c] <- s * t
    C

let mul_mv (s:single) (A:matrix) (b:vector) =
    let c = new vector(A.Rows)
    for r=0 to A.Rows-1 do
        let mutable t = 0.0f
        for c=0 to A.Cols-1 do
            t <- t + A[r,c] * b[c]
        c[r] <- s * t
    c

let mul_mTv (s:single) (A:matrix) (b:vector) =
    let c = new vector(A.Cols)
    for r=0 to A.Cols-1 do
        let mutable t = 0.0f
        for c=0 to A.Rows-1 do
            t <- t + A[c,r] * b[c]
        c[r] <- s * t
    c

let impM (m:MatrixExpression) = MatrixExpression.op_Implicit m
let impME (m:matrix) = MatrixExpression.op_Implicit m

let implicit = test "implicit" {

    test "mT" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use expected =
            let T = new matrix(n,m)
            for r = 0 to n-1 do
                for c = 0 to m-1 do
                    T[r,c] <- A[c,r]
            T
        use actual = impM A.T
        Check.close Medium expected actual
    }

    test "mS" {
        let! m,n = gen2D
        use! A = genMatrix m n
        let! s = Gen.Single.OneTwo
        use expected =
            let AT = new matrix(m,n)
            for r = 0 to m-1 do
                for c = 0 to n-1 do
                    AT[r,c] <- s * A[r,c]
            AT
        use actual = impM (s * A)
        Check.close Medium expected actual
    }

    test "mTS" {
        let! m,n = gen2D
        use! A = genMatrix m n
        let! s = Gen.Single.OneTwo
        use expected =
            let T = new matrix(n,m)
            for r = 0 to n-1 do
                for c = 0 to m-1 do
                    T[r,c] <- s * A[c,r]
            T
        use actual = impM (s * A.T)
        Check.close Medium expected actual
    }
}

let add1 = test "add1" {

    test "mm" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix m n
        use expected = add_mm 1.0f A 1.0f B
        use actual = A + B |> impM
        Check.close Medium expected actual
    }

    test "mm_reuse" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix m n
        use expected = add_mm 1.0f A 1.0f B
        use actual = (A + 0.0f) + (B + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mmT" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix n m
        use expected = add_mmT 1.0f A 1.0f B
        use actual = A + B.T |> impM
        Check.close Medium expected actual
    }

    test "mmT_reuse" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix n m
        use expected = add_mmT 1.0f A 1.0f B
        use actual = (A + 0.0f) + (B.T + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mmS" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix m n
        let s = 1.0f
        use expected = add_mm 1.0f A s B
        use actual = A + s * B |> impM
        Check.close Medium expected actual
    }

    test "mmS_reuse" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix m n
        let s = 1.0f
        use expected = add_mm 1.0f A s B
        use actual = (A + 0.0f) + (s * B + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mmTS" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix n m
        let! s = Gen.Single.OneTwo
        use expected = add_mmT 1.0f A s B
        use actual = A + (s * B.T) |> impM
        Check.close Medium expected actual
    }

    test "mmTS_reuse" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix n m
        let! s = Gen.Single.OneTwo
        use expected = add_mmT 1.0f A s B
        use actual = (A + 0.0f) + ((s * B.T) + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mTm" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix m n
        use expected = add_mTm 1.0f A 1.0f B
        use actual = A.T + B |> impM
        Check.close Medium expected actual
    }

    test "mTm_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix m n
        use expected = add_mTm 1.0f A 1.0f B
        use actual = (A.T + 0.0f) + (B + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mTmT" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix n m
        use expected = add_mTmT 1.0f A 1.0f B
        use actual = A.T + B.T |> impM
        Check.close Medium expected actual
    }

    test "mTmT_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix n m
        use expected = add_mTmT 1.0f A 1.0f B
        use actual = (A.T + 0.0f) + (B.T + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mTmS" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix m n
        let! s = Gen.Single.OneTwo
        use expected = add_mTm 1.0f A s B
        use actual = A.T + (s * B) |> impM
        Check.close Medium expected actual
    }

    test "mTmS_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix m n
        let! s = Gen.Single.OneTwo
        use expected = add_mTm 1.0f A s B
        use actual = (A.T + 0.0f) + ((s * B) + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mTmTS" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix n m
        let! s = Gen.Single.OneTwo
        use expected = add_mTmT 1.0f A s B
        use actual = (A.T + (s * B.T)) * 1.0f + 0.0f |> impM
        Check.close Medium expected actual
    }

    test "mTmTS_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix n m
        let! s = Gen.Single.OneTwo
        use expected = add_mTmT 1.0f A s B
        use actual = ((A.T + 0.0f) + ((s * B.T) + 0.0f)) * 1.0f + 0.0f |> impM
        Check.close Medium expected actual
    }

    test "mSm" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix m n
        let! s = Gen.Single.OneTwo
        use expected = add_mm s A 1.0f B
        use actual = (s * A) + B |> impM
        Check.close Medium expected actual
    }

    test "mSm_reuse" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix m n
        let! s = Gen.Single.OneTwo
        use expected = add_mm s A 1.0f B
        use actual = (s * A + 0.0f) + (B + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mSmT" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix n m
        let! s = Gen.Single.OneTwo
        use expected = add_mmT s A 1.0f B
        use actual = (s * A) + B.T |> impM
        Check.close Medium expected actual
    }

    test "mSmT_reuse" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix n m
        let! s = Gen.Single.OneTwo
        use expected = add_mmT s A 1.0f B
        use actual = (s * A + 0.0f) + (B.T + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mSmS" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix m n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = add_mm s1 A s2 B
        use actual = (s1 * A) + (s2 * B) |> impM
        Check.close Medium expected actual
    }

    test "mSmS_reuse" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix m n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = add_mm s1 A s2 B
        use actual = (s1 * A + 0.0f) + (s2 * B + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mSmTS" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix n m
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = add_mmT s1 A s2 B
        use actual = (s1 * A) + (s2 * B.T) |> impM
        Check.close Medium expected actual
    }

}

let add2 = test "add2" {

    test "mSmTS_reuse" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix n m
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = add_mmT s1 A s2 B
        use actual = (s1 * A + 0.0f) + (s2 * B.T + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mTSm" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix m n
        let! s = Gen.Single.OneTwo
        use expected = add_mTm s A 1.0f B
        use actual = ((s * A.T) + B) + 0.0f |> impM
        Check.close Medium expected actual
    }

    test "mTSm_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix m n
        let! s = Gen.Single.OneTwo
        use expected = add_mTm s A 1.0f B
        use actual = ((s * A.T + 0.0f) + (B + 0.0f)) + 0.0f |> impM
        Check.close Medium expected actual
    }

    test "mTSmT" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix n m
        let! s = Gen.Single.OneTwo
        use expected = add_mTmT s A 1.0f B
        use actual = (s * A.T) + B.T |> impM
        Check.close Medium expected actual
    }

    test "mTSmT_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix n m
        let! s = Gen.Single.OneTwo
        use expected = add_mTmT s A 1.0f B
        use actual = (s * A.T + 0.0f) + (B.T + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mTSmS" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix m n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = add_mTm s1 A s2 B
        use actual = ((s1 * A.T) + (s2 * B)) + 0.0f |> impM
        Check.close Medium expected actual
    }

    test "mTSmS_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix m n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = add_mTm s1 A s2 B
        use actual = ((s1 * A.T + 0.0f) + (s2 * B + 0.0f)) + 0.0f |> impM
        Check.close Medium expected actual
    }

    test "mTSmTS" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix n m
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = add_mTmT s1 A s2 B
        use actual = (s1 * A.T) + (s2 * B.T) |> impM
        Check.close Medium expected actual
    }

    test "mTSmTS_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix n m
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = add_mTmT s1 A s2 B
        use actual = (s1 * A.T + 0.0f) + (s2 * B.T + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "md" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new matrix(n,m)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R[r,c] <- A[r,c] + a
            R
        use actual = A + a |> impM
        Check.close Medium expected actual
    }

    test "md_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new matrix(n,m)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R[r,c] <- A[r,c] + a
            R
        use actual = (A + 0.0f) + a |> impM
        Check.close Medium expected actual
    }

    test "mTd" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new matrix(m,n)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R[c,r] <- A[r,c] + a
            R
        use actual = A.T + a |> impM
        Check.close Medium expected actual
    }

    test "mTd_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new matrix(m,n)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R[c,r] <- A[r,c] + a
            R
        use actual = (A.T + 0.0f) + a |> impM
        Check.close Medium expected actual
    }

    test "mSd" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! s = Gen.Single.OneTwo
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new matrix(n,m)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R[r,c] <- s * A[r,c] + a
            R
        use actual = (s * A) + a |> impM
        Check.close Medium expected actual
    }

    test "mSd_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! s = Gen.Single.OneTwo
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new matrix(n,m)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R[r,c] <- s * A[r,c] + a
            R
        use actual = (s * A + 0.0f) + a |> impM
        Check.close Medium expected actual
    }

    test "mTSd" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! s = Gen.Single.OneTwo
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new matrix(m,n)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R[c,r] <- s * A[r,c] + a
            R
        use actual = (s * A.T) + a |> impM
        Check.close Medium expected actual
    }

    test "mTSd_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! s = Gen.Single.OneTwo
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new matrix(m,n)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R[c,r] <- s * A[r,c] + a
            R
        use actual = (s * A.T + 0.0f) + a |> impM
        Check.close Medium expected actual
    }
}

let sub1 = test "sub1" {

    test "mm" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix m n
        use expected = add_mm 1.0f A -1.0f B
        use actual = A - B |> impM
        Check.close Medium expected actual
    }

    test "mm_reuse" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix m n
        use expected = add_mm 1.0f A -1.0f B
        use actual = (A + 0.0f) - (B + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mmT" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix n m
        use expected = add_mmT 1.0f A -1.0f B
        use actual = A - B.T |> impM
        Check.close Medium expected actual
    }

    test "mmT_reuse" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix n m
        use expected = add_mmT 1.0f A -1.0f B
        use actual = (A + 0.0f) - (B.T + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mmS" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix m n
        let! s = Gen.Single.OneTwo
        use expected = add_mm 1.0f A -s B
        use actual = A - s * B |> impM
        Check.close Medium expected actual
    }

    test "mmS_reuse" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix m n
        let! s = Gen.Single.OneTwo
        use expected = add_mm 1.0f A -s B
        use actual = (A + 0.0f) - (s * B + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mmTS" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix n m
        let! s = Gen.Single.OneTwo
        use expected = add_mmT 1.0f A -s B
        use actual = (A - (s * B.T)) * 1.0f * 1.0f |> impM
        Check.close Medium expected actual
    }

    test "mmTS_reuse" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix n m
        let! s = Gen.Single.OneTwo
        use expected = add_mmT 1.0f A -s B
        use actual = ((A + 0.0f) - (s * B.T + 0.0f)) * 1.0f * 1.0f |> impM
        Check.close Medium expected actual
    }

    test "mTm" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix m n
        use expected = add_mTm 1.0f A -1.0f B
        use actual = A.T - B |> impM
        Check.close Medium expected actual
    }

    test "mTm_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix m n
        use expected = add_mTm 1.0f A -1.0f B
        use actual = (A.T + 0.0f) - (B + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mTmT" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix n m
        use expected = add_mTmT 1.0f A -1.0f B
        use actual = A.T - B.T |> impM
        Check.close Medium expected actual
    }

    test "mTmT_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix n m
        use expected = add_mTmT 1.0f A -1.0f B
        use actual = (A.T + 0.0f) - (B.T + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mTmS" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix m n
        let! s = Gen.Single.OneTwo
        use expected = add_mTm 1.0f A -s B
        use actual = A.T - (s * B) |> impM
        Check.close Medium expected actual
    }

    test "mTmS_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix m n
        let! s = Gen.Single.OneTwo
        use expected = add_mTm 1.0f A -s B
        use actual = (A.T + 0.0f) - ((s * B) + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mTmTS" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix n m
        let! s = Gen.Single.OneTwo
        use expected = add_mTmT 1.0f A -s B
        use actual = A.T - (s * B.T) |> impM
        Check.close Medium expected actual
    }

    test "mTmTS_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix n m
        let! s = Gen.Single.OneTwo
        use expected = add_mTmT 1.0f A -s B
        use actual = (A.T + 0.0f) - ((s * B.T) + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mSm" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix m n
        let! s = Gen.Single.OneTwo
        use expected = add_mm s A -1.0f B
        use actual = (s * A) - B |> impM
        Check.close Medium expected actual
    }

    test "mSm_reuse" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix m n
        let! s = Gen.Single.OneTwo
        use expected = add_mm s A -1.0f B
        use actual = (s * A + 0.0f) - (B + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mSmT" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix n m
        let! s = Gen.Single.OneTwo
        use expected = add_mmT s A -1.0f B
        use actual = (s * A) - B.T |> impM
        Check.close Medium expected actual
    }

    test "mSmT_reuse" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix n m
        let! s = Gen.Single.OneTwo
        use expected = add_mmT s A -1.0f B
        use actual = ((s * A) + 0.0f) - (B.T + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mSmS" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix m n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = add_mm s1 A -s2 B
        use actual = ((s1 * A) - (s2 * B)) * 1.0f |> impM
        Check.close Medium expected actual
    }

    test "mSmS_reuse" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix m n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = add_mm s1 A -s2 B
        use actual = ((s1 * A + 0.0f) - (s2 * B + 0.0f)) * 1.0f |> impM
        Check.close Medium expected actual
    }

    test "mSmTS" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix n m
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = add_mmT s1 A -s2 B
        use actual = (s1 * A) - (s2 * B.T) |> impM
        Check.close Medium expected actual
    }

    test "mSmTS_reuse" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix n m
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = add_mmT s1 A -s2 B
        use actual = (s1 * A + 0.0f) - (s2 * B.T + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mTSm" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix m n
        let! s = Gen.Single.OneTwo
        use expected = add_mTm s A -1.0f B
        use actual = (s * A.T) - B |> impM
        Check.close Medium expected actual
    }

    test "mTSm_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix m n
        let! s = Gen.Single.OneTwo
        use expected = add_mTm s A -1.0f B
        use actual = (s * A.T + 0.0f) - (B + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mTSmT" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix n m
        let! s = Gen.Single.OneTwo
        use expected = add_mTmT s A -1.0f B
        use actual = (s * A.T) - B.T |> impM
        Check.close Medium expected actual
    }

    test "mTSmT_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix n m
        let! s = Gen.Single.OneTwo
        use expected = add_mTmT s A -1.0f B
        use actual = (s * A.T + 0.0f) - (B.T + 0.0f) |> impM
        Check.close Medium expected actual
    }

}

let sub2 = test "sub2" {

    test "mTSmS" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix m n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = add_mTm s1 A -s2 B
        use actual = (s1 * A.T) - (s2 * B) |> impM
        Check.close Medium expected actual
    }

    test "mTSmS_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix m n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = add_mTm s1 A -s2 B
        use actual = (s1 * A.T + 0.0f) - (s2 * B + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mTSmTS" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix n m
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = add_mTmT s1 A -s2 B
        use actual = (s1 * A.T) - (s2 * B.T) + 0.0f |> impM
        Check.close Medium expected actual
    }

    test "mTSmTS_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix n m
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = add_mTmT s1 A -s2 B
        use actual = (s1 * A.T + 0.0f) - (s2 * B.T + 0.0f) + 0.0f |> impM
        Check.close Medium expected actual
    }

    test "md" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new matrix(n,m)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R[r,c] <- A[r,c] - a
            R
        use actual = A - a |> impM
        Check.close Medium expected actual
    }

    test "md_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new matrix(n,m)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R[r,c] <- A[r,c] - a
            R
        use actual = (A + 0.0f) - a |> impM
        Check.close Medium expected actual
    }

    test "mTd" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new matrix(m,n)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R[c,r] <- A[r,c] - a
            R
        use actual = A.T - a |> impM
        Check.close Medium expected actual
    }

    test "mTd_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new matrix(m,n)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R[c,r] <- A[r,c] - a
            R
        use actual = (A.T + 0.0f) - a |> impM
        Check.close Medium expected actual
    }

    test "mSd" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! s = Gen.Single.OneTwo
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new matrix(n,m)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R[r,c] <- s * A[r,c] - a
            R
        use actual = (s * A) - a |> impM
        Check.close Medium expected actual
    }

    test "mSd_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! s = Gen.Single.OneTwo
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new matrix(n,m)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R[r,c] <- s * A[r,c] - a
            R
        use actual = (s * A + 0.0f) - a |> impM
        Check.close Medium expected actual
    }

    test "mTSd" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! s = Gen.Single.OneTwo
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new matrix(m,n)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R[c,r] <- s * A[r,c] - a
            R
        use actual = (s * A.T) - a |> impM
        Check.close Medium expected actual
    }

    test "mTSd_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! s = Gen.Single.OneTwo
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new matrix(m,n)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R[c,r] <- s * A[r,c] - a
            R
        use actual = (s * A.T + 0.0f) - a |> impM
        Check.close Medium expected actual
    }

    test "dm" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new matrix(n,m)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R[r,c] <- a - A[r,c]
            R
        use actual = a - A |> impM
        Check.close Medium expected actual
    }

    test "dm_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new matrix(n,m)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R[r,c] <- a - A[r,c]
            R
        use actual = a - (A + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "dmT" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new matrix(m,n)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R[c,r] <- a - A[r,c]
            R
        use actual = a - A.T |> impM
        Check.close Medium expected actual
    }

    test "dmT_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new matrix(m,n)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R[c,r] <- a - A[r,c]
            R
        use actual = a - (A.T + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "dmS" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! s = Gen.Single.OneTwo
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new matrix(n,m)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R[r,c] <- a - s * A[r,c]
            R
        use actual = a - (s * A) |> impM
        Check.close Medium expected actual
    }

    test "dmS_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! s = Gen.Single.OneTwo
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new matrix(n,m)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R[r,c] <- a - s * A[r,c]
            R
        use actual = a - (s * A + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "dmTS" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! s = Gen.Single.OneTwo
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new matrix(m,n)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R[c,r] <- a - s * A[r,c]
            R
        use actual = (a - (s * A.T)) * 1.0f |> impM
        Check.close Medium expected actual
    }

    test "dmTS_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! s = Gen.Single.OneTwo
        let! a = Gen.Single.OneTwo
        use expected =
            let R = new matrix(m,n)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R[c,r] <- a - s * A[r,c]
            R
        use actual = (a - (s * A.T + 0.0f)) * 1.0f |> impM
        Check.close Medium expected actual
    }
}

let mul1 = test "mul1" {

    test "mm" {
        let! m,k,n = gen3D
        use! A = genMatrix m k
        use! B = genMatrix k n
        use expected = mul_mm 1.0f A B
        use actual = A * B |> impM
        Check.close Medium expected actual
    }

    test "mm_reuse" {
        let! k,n = gen2D
        use! A = genMatrix k k
        use! B = genMatrix k n
        use expected = mul_mm 1.0f A B
        use actual = (A + 0.0f) * (B + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mmT" {
        let! m,k,n = gen3D
        use! A = genMatrix m k
        use! B = genMatrix n k
        use expected = mul_mmT 1.0f A B
        use actual = A * B.T |> impM
        Check.close Medium expected actual
    }

    test "mmT_reuse" {
        let! m,k,n = gen3D
        use! A = genMatrix m k
        use! B = genMatrix n k
        use expected = mul_mmT 1.0f A B
        use actual = (A + 0.0f) * (B.T + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mmS" {
        let! m,k,n = gen3D
        use! A = genMatrix m k
        use! B = genMatrix k n
        let! s = Gen.Single.OneTwo
        use expected = mul_mm s A B
        use actual = A * (s * B) |> impM
        Check.close Medium expected actual
    }

    test "mmS_reuse" {
        let! m,k,n = gen3D
        use! A = genMatrix m k
        use! B = genMatrix k n
        let! s = Gen.Single.OneTwo
        use expected = mul_mm s A B
        use actual = (A + 0.0f) * ((s * B) + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mmTS" {
        let! m,k,n = gen3D
        use! A = genMatrix m k
        use! B = genMatrix n k
        let! s = Gen.Single.OneTwo
        use expected = mul_mmT s A B
        use actual = A * (s * B.T) |> impM
        Check.close Medium expected actual
    }

    test "mmTS_reuse" {
        let! m,k,n = gen3D
        use! A = genMatrix m k
        use! B = genMatrix n k
        let! s = Gen.Single.OneTwo
        use expected = mul_mmT s A B
        use actual = (A + 0.0f) * ((s * B.T) + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mTm" {
        let! m,k,n = gen3D
        use! A = genMatrix k m
        use! B = genMatrix k n
        use expected = mul_mTm 1.0f A B
        use actual = A.T * B |> impM
        Check.close Medium expected actual
    }

    test "mTm_reuse" {
        let! m,k,n = gen3D
        use! A = genMatrix k m
        use! B = genMatrix k n
        use expected = mul_mTm 1.0f A B
        use actual = (A.T + 0.0f) * (B + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mTmT" {
        let! m,k,n = gen3D
        use! A = genMatrix k m
        use! B = genMatrix n k
        use expected = mul_mTmT 1.0f A B
        use actual = A.T * B.T |> impM
        Check.close Medium expected actual
    }

    test "mTmT_reuse" {
        let! m,k,n = gen3D
        use! A = genMatrix k m
        use! B = genMatrix n k
        use expected = mul_mTmT 1.0f A B
        use actual = (A.T + 0.0f) * (B.T + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mTmS" {
        let! m,k,n = gen3D
        use! A = genMatrix k m
        use! B = genMatrix k n
        let! s = Gen.Single.OneTwo
        use expected = mul_mTm s A B
        use actual = A.T * (s * B) |> impM
        Check.close Medium expected actual
    }

    test "mTmS_reuse" {
        let! m,k,n = gen3D
        use! A = genMatrix k m
        use! B = genMatrix k n
        let! s = Gen.Single.OneTwo
        use expected = mul_mTm s A B
        use actual = (A.T + 0.0f) * ((s * B) + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mTmTS" {
        let! m,k,n = gen3D
        use! A = genMatrix k m
        use! B = genMatrix n k
        let! s = Gen.Single.OneTwo
        use expected = mul_mTmT s A B
        use actual = A.T * (s * B.T) |> impM
        Check.close Medium expected actual
    }

    test "mTmTS_reuse" {
        let! m,k,n = gen3D
        use! A = genMatrix k m
        use! B = genMatrix n k
        let! s = Gen.Single.OneTwo
        use expected = mul_mTmT s A B
        use actual = (A.T + 0.0f) * ((s * B.T) + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mSm" {
        let! m,k,n = gen3D
        use! A = genMatrix m k
        use! B = genMatrix k n
        let! s = Gen.Single.OneTwo
        use expected = mul_mm s A B
        use actual = (s * A) * B |> impM
        Check.close Medium expected actual
    }

    test "mSm_reuse" {
        let! m,k,n = gen3D
        use! A = genMatrix m k
        use! B = genMatrix k n
        let! s = Gen.Single.OneTwo
        use expected = mul_mm s A B
        use actual = ((s * A) + 0.0f) * (B + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mSmT" {
        let! m,k,n = gen3D
        use! A = genMatrix m k
        use! B = genMatrix n k
        let! s = Gen.Single.OneTwo
        use expected = mul_mmT s A B
        use actual = (s * A) * B.T |> impM
        Check.close Medium expected actual
    }

    test "mSmT_reuse" {
        let! m,k,n = gen3D
        use! A = genMatrix m k
        use! B = genMatrix n k
        let! s = Gen.Single.OneTwo
        use expected = mul_mmT s A B
        use actual = ((s * A) + 0.0f) * (B.T + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mSmS" {
        let! m,k,n = gen3D
        use! A = genMatrix m k
        use! B = genMatrix k n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = mul_mm (s1*s2) A B
        use actual = (s1 * A) * (s2 * B) |> impM
        Check.close Medium expected actual
    }

    test "mSmS_reuse" {
        let! m,k,n = gen3D
        use! A = genMatrix m k
        use! B = genMatrix k n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = mul_mm (s1*s2) A B
        use actual = (s1 * A + 0.0f) * (s2 * B + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mSmTS" {
        let! m,k,n = gen3D
        use! A = genMatrix m k
        use! B = genMatrix n k
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = mul_mmT (s1*s2) A B
        use actual = (s1 * A) * (s2 * B.T) |> impM
        Check.close Medium expected actual
    }

    test "mSmTS_reuse" {
        let! m,k,n = gen3D
        use! A = genMatrix m k
        use! B = genMatrix n k
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = mul_mmT (s1*s2) A B
        use actual = (s1 * A + 0.0f) * (s2 * B.T + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mTSm" {
        let! m,k,n = gen3D
        use! A = genMatrix k m
        use! B = genMatrix k n
        let! s = Gen.Single.OneTwo
        use expected = mul_mTm s A B
        use actual = (s * A.T) * B |> impM
        Check.close Medium expected actual
    }

}

let mul2 = test "mul2" {

    test "mTSm_reuse" {
        let! m,k,n = gen3D
        use! A = genMatrix k m
        use! B = genMatrix k n
        let! s = Gen.Single.OneTwo
        use expected = mul_mTm s A B
        use actual = (s * A.T + 0.0f) * (B + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mTSmT" {
        let! m,k,n = gen3D
        use! A = genMatrix k m
        use! B = genMatrix n k
        let! s = Gen.Single.OneTwo
        use expected = mul_mTmT s A B
        use actual = (s * A.T) * B.T |> impM
        Check.close Medium expected actual
    }

    test "mTSmT_reuse" {
        let! m,k,n = gen3D
        use! A = genMatrix k m
        use! B = genMatrix n k
        let! s = Gen.Single.OneTwo
        use expected = mul_mTmT s A B
        use actual = (s * A.T + 0.0f) * (B.T + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mTSmS" {
        let! m,k,n = gen3D
        use! A = genMatrix k m
        use! B = genMatrix k n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = mul_mTm (s1*s2) A B
        use actual = (s1 * A.T) * (s2 * B) |> impM
        Check.close Medium expected actual
    }

    test "mTSmS_reuse" {
        let! m,k,n = gen3D
        use! A = genMatrix k m
        use! B = genMatrix k n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = mul_mTm (s1*s2) A B
        use actual = (s1 * A.T + 0.0f) * (s2 * B + 0.0f) |> impM
        Check.close Medium expected actual
    }

    test "mTSmTS" {
        let! m,k,n = gen3D
        use! A = genMatrix k m
        use! B = genMatrix n k
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = mul_mTmT (s1*s2) A B
        use actual = ((s1 * A.T) * (s2 * B.T) + 0.0f) * 1.0f |> impM
        Check.close Medium expected actual
    }

    test "mTSmTS_reuse" {
        let! m,k,n = gen3D
        use! A = genMatrix k m
        use! B = genMatrix n k
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = mul_mTmT (s1*s2) A B
        use actual = ((s1 * A.T + 0.0f) * (s2 * B.T) + 0.0f) * 1.0f |> impM
        Check.close Medium expected actual
    }

    test "mv" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! b = SingleVectorTests.genVector n
        use expected = mul_mv 1.0f A b
        use actual = A * b |> SingleVectorTests.impV
        Check.close Medium expected actual
    }

    test "mv_reuse" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! b = SingleVectorTests.genVector n
        use expected = mul_mv 1.0f A b
        use actual = (A + 0.0f) * (b + 0.0f) |> SingleVectorTests.impV
        Check.close Medium expected actual
    }

    test "mvS" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! b = SingleVectorTests.genVector n
        let! s = Gen.Single.OneTwo
        use expected = mul_mv s A b
        use actual = A * (s * b) |> SingleVectorTests.impV
        Check.close Medium expected actual
    }

    test "mvS_reuse" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! b = SingleVectorTests.genVector n
        let! s = Gen.Single.OneTwo
        use expected = mul_mv s A b
        use actual = (A + 0.0f) * (s * b + 0.0f) |> SingleVectorTests.impV
        Check.close Medium expected actual
    }

    test "mTv" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! b = SingleVectorTests.genVector n
        use expected = mul_mTv 1.0f A b
        use actual = A.T * b |> SingleVectorTests.impV
        Check.close Medium expected actual
    }

    test "mTv_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! b = SingleVectorTests.genVector n
        use expected = mul_mTv 1.0f A b
        use actual = (A.T + 0.0f) * (b + 0.0f) |> SingleVectorTests.impV
        Check.close Medium expected actual
    }

    test "mTvS" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! b = SingleVectorTests.genVector n
        let! s = Gen.Single.OneTwo
        use expected = mul_mTv s A b
        use actual = A.T * (s * b) |> SingleVectorTests.impV
        Check.close Medium expected actual
    }

    test "mTvS_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! b = SingleVectorTests.genVector n
        let! s = Gen.Single.OneTwo
        use expected = mul_mTv s A b
        use actual = (A.T + 0.0f) * ((s * b) + 0.0f) |> SingleVectorTests.impV
        Check.close Medium expected actual
    }

    test "mSv" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! b = SingleVectorTests.genVector n
        let! s = Gen.Single.OneTwo
        use expected = mul_mv s A b
        use actual = (s * A) * b |> SingleVectorTests.impV
        Check.close Medium expected actual
    }

    test "mSv_reuse" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! b = SingleVectorTests.genVector n
        let! s = Gen.Single.OneTwo
        use expected = mul_mv s A b
        use actual = (s * A + 0.0f) * (b + 0.0f) |> SingleVectorTests.impV
        Check.close Medium expected actual
    }

    test "mSvS" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! b = SingleVectorTests.genVector n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = mul_mv (s1*s2) A b
        use actual = ((s1 * A) * (s2 * b)) * 1.0f + 0.0f |> SingleVectorTests.impV
        Check.close Medium expected actual
    }

    test "mSvS_reuse" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! b = SingleVectorTests.genVector n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = mul_mv (s1*s2) A b
        use actual = ((s1 * A + 0.0f) * (s2 * b + 0.0f)) * 1.0f + 0.0f |> SingleVectorTests.impV
        Check.close Medium expected actual
    }

    test "mTSv" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! b = SingleVectorTests.genVector n
        let! s = Gen.Single.OneTwo
        use expected = mul_mTv s A b
        use actual = (s * A.T) * b |> SingleVectorTests.impV
        Check.close Medium expected actual
    }

    test "mTSv_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! b = SingleVectorTests.genVector n
        let! s = Gen.Single.OneTwo
        use expected = mul_mTv s A b
        use actual = (s * A.T + 0.0f) * (b + 0.0f) |> SingleVectorTests.impV
        Check.close Medium expected actual
    }

    test "mTSvS" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! b = SingleVectorTests.genVector n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = mul_mTv (s1*s2) A b
        use actual = ((s1 * A.T) * (s2 * b) + 0.0f) * 1.0f |> SingleVectorTests.impV
        Check.close Medium expected actual
    }

    test "mTSvS_reuse" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! b = SingleVectorTests.genVector n
        let! s1 = Gen.Single.OneTwo
        let! s2 = Gen.Single.OneTwo
        use expected = mul_mTv (s1*s2) A b
        use actual = ((s1 * A.T + 0.0f) * (s2 * b + 0.0f) + 0.0f) * 1.0f |> SingleVectorTests.impV
        Check.close Medium expected actual
    }
}

let testUnary name
    (fexpected:single -> single)
    (factual:Expression.MatrixExpression -> Expression.MatrixExpression) =
    let map (A:matrix) =
        let E = new matrix(A.Rows,A.Cols)
        for r = 0 to A.Rows-1 do
            for c = 0 to A.Cols-1 do
                E[r,c] <- fexpected(A[r,c])
        E
    test name {
        let! m,n = gen2D
        use! A = genMatrix m n
        use expected = map A
        use actual = A |> impME |> factual |> impM
        Check.close Medium expected actual
    }

let functions1 = test "functions1" {

    testUnary "Abs" abs Matrix.Abs
    testUnary "Sqr" (fun x -> x*x) Matrix.Sqr
    testUnary "Inv" (fun x -> 1.0f/x) Matrix.Inv
    testUnary "Sqrt" sqrt Matrix.Sqrt
    testUnary "InvSqrt" (fun x -> 1.0f/sqrt x) Matrix.InvSqrt
#if NETCOREAPP
    testUnary "Cbrt" (double >> Math.Cbrt >> single) Matrix.Cbrt
    testUnary "InvCbrt" ((/) 1.0f >> double >> Math.Cbrt >> single) Matrix.InvCbrt
    testUnary "Pow2o3" (fun a -> let a = double a in Math.Cbrt(a*a) |> single) Matrix.Pow2o3
#endif
    testUnary "Pow3o2" (fun a -> let a = double a in Math.Sqrt(a*a*a) |> single) Matrix.Pow3o2
    testUnary "Exp" exp Matrix.Exp
    testUnary "Exp2" (fun i -> Math.Pow(2.0,double i) |> single) Matrix.Exp2
    testUnary "Exp10" (fun i -> Math.Pow(10.0,double i) |> single) Matrix.Exp10
    testUnary "Expm1" (fun i -> exp i-1.0f) Matrix.Expm1
    testUnary "Ln" log Matrix.Ln
#if NETCOREAPP
    testUnary "Log2" (double >> Math.Log2 >> single) Matrix.Log2
#endif
    testUnary "Log10" log10 Matrix.Log10
    testUnary "Log1p" (fun i -> log(i+1.0f)) Matrix.Log1p
#if NETCOREAPP
    testUnary "Logb" (fun i -> Math.ILogB(double i) |> single) Matrix.Logb
#endif
    testUnary "Cos" cos Matrix.Cos
    testUnary "Sin" sin Matrix.Sin
    testUnary "Tan" tan Matrix.Tan
    testUnary "Cospi" (fun i -> cos(Math.PI*(double i)) |> single) Matrix.Cospi
    testUnary "Sinpi" (fun i -> sin(Math.PI*(double i)) |> single) Matrix.Sinpi
    testUnary "Tanpi" (fun i -> tan(Math.PI*(double i)) |> single) Matrix.Tanpi
    testUnary "Cosd" (fun i -> cos(Math.PI/180.0*(double i)) |> single) Matrix.Cosd
    testUnary "Sind" (fun i -> sin(Math.PI/180.0*(double i)) |> single) Matrix.Sind
    testUnary "Tand" (fun i -> tan(Math.PI/180.0*(double i)) |> single) Matrix.Tand
    testUnary "Acos" acos Matrix.Acos
    testUnary "Asin" asin Matrix.Asin
    testUnary "Atan" atan Matrix.Atan
    testUnary "Cosh" cosh Matrix.Cosh
    testUnary "Sinh" sinh Matrix.Sinh
    testUnary "Tanh" tanh Matrix.Tanh
#if NETCOREAPP
    testUnary "Acosh" (double >> Math.Acosh >> single) Matrix.Acosh
    testUnary "Asinh" (double >> Math.Asinh >> single) Matrix.Asinh
    testUnary "Atanh" (double >> Math.Atanh >> single) Matrix.Atanh
#endif
}

let functions2 = test "functions2" {

    testUnary "Erf" (double >> erf >> single) Matrix.Erf
    testUnary "Erfc" (double >> erfc >> single) Matrix.Erfc
    testUnary "ErfInv" (double >> erfinv >> single) Matrix.ErfInv
    testUnary "ErfcInv" (double >> erfcinv >> single) Matrix.ErfcInv
    testUnary "CdfNorm" (double >> normcdf >> single) Matrix.CdfNorm
    testUnary "CdfNormInv" (double >> normcdfinv >> single) Matrix.CdfNormInv
    testUnary "LGamma" (double >> lgamma >> single) Matrix.LGamma
    testUnary "TGamma" (double >> gamma >> single) Matrix.TGamma
    testUnary "ExpInt1" (double >> expint 1 >> single) Matrix.ExpInt1
    testUnary "Floor" floor Matrix.Floor
    testUnary "Ceil" ceil Matrix.Ceil
    testUnary "Truncate" truncate Matrix.Truncate
    testUnary "Round" (double >> Math.Round >> single) Matrix.Round
    testUnary "RoundAwayFromZero" (fun a -> Math.Round(double a, MidpointRounding.AwayFromZero) |> single) Matrix.RoundAwayFromZero
    testUnary "Frac" (fun a -> a - truncate a) Matrix.Frac
    testUnary "NearbyInt" (fun a -> Math.Round(double a, MidpointRounding.ToEven) |> single) Matrix.NearbyInt
    testUnary "Rint" (fun a -> Math.Round(double a, MidpointRounding.ToEven) |> single) Matrix.Rint

    test "Eigens" {
        use m = new matrix(3,3)
        m[0,0] <- 14165.f; m[0,1] <- 8437.f; m[0,2] <- 7554.f
        m[1,0] <- 8437.f; m[1,1] <- 11902.f; m[1,2] <- 7962.f
        m[2,0] <- 7554.f; m[2,1] <- 7962.f; m[2,2] <- 5940.f
        let struct (v,e) = Matrix.Eigens(impME m)
        Check.close Accuracy.High 128.1346664f e[0]
        Check.close Accuracy.High 4698.444253f e[1]
        Check.close Accuracy.High 27180.42108f e[2]
        v.Dispose()
        e.Dispose()
    }

    test "Det" {
        use m = new matrix(3,3)
        m[0,0] <- 5.f; m[0,1] <- 7.f; m[0,2] <- 8.f
        m[1,0] <- 3.f; m[1,1] <- 6.f; m[1,2] <- 3.f
        m[2,0] <- 6.f; m[2,1] <- 4.f; m[2,2] <- 8.f
        let d = Matrix.Det(impME m)
        Check.close Accuracy.High -54.0f d
    }
}

let all =
    test "singlematrix" {
        implicit
        add1
        add2
        sub1
        sub2
        mul1
        mul2
        functions1
        functions2
    }