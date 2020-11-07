module MatrixTests

open System
open MKLNET
open CsCheck

let MAX_DIM = 5
let gen1D = Gen.Int.[1,MAX_DIM]
let gen2D = Gen.Select(gen1D,gen1D)
let gen3D = Gen.Select(gen1D,gen1D,gen1D)

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

let add_mm (aS:double) (A:matrix) (bS:double) (B:matrix) =
    let C = new matrix(A.Rows,A.Cols)
    for r=0 to A.Rows-1 do
        for c=0 to A.Cols-1 do
            C.[r,c] <- aS * A.[r,c] + bS * B.[r,c]
    C

let add_mmT (aS:double) (A:matrix) (bS:double) (B:matrix) =
    let C = new matrix(A.Rows,A.Cols)
    for r=0 to A.Rows-1 do
        for c=0 to A.Cols-1 do
            C.[r,c] <- aS * A.[r,c] + bS * B.[c,r]
    C

let add_mTm (aS:double) (A:matrix) (bS:double) (B:matrix) =
    let C = new matrix(A.Cols,A.Rows)
    for r=0 to A.Cols-1 do
        for c=0 to A.Rows-1 do
            C.[r,c] <- aS * A.[c,r] + bS * B.[r,c]
    C

let add_mTmT (aS:double) (A:matrix) (bS:double) (B:matrix) =
    let C = new matrix(A.Cols,A.Rows)
    for r=0 to A.Cols-1 do
        for c=0 to A.Rows-1 do
            C.[r,c] <- aS * A.[c,r] + bS * B.[c,r]
    C

let mul_mm (s:double) (A:matrix) (B:matrix) =
    let C = new matrix(A.Rows,B.Cols)
    for r=0 to A.Rows-1 do
        for c=0 to B.Cols-1 do
            let mutable t = 0.0
            for i = 0 to A.Cols-1 do
                t <- t + A.[r,i] * B.[i,c]
            C.[r,c] <- s * t
    C

let mul_mTm (s:double) (A:matrix) (B:matrix) =
    let C = new matrix(A.Cols,B.Cols)
    for r=0 to A.Cols-1 do
        for c=0 to B.Cols-1 do
            let mutable t = 0.0
            for i = 0 to A.Rows-1 do
                t <- t + A.[i,r] * B.[i,c]
            C.[r,c] <- s * t
    C

let mul_mmT (s:double) (A:matrix) (B:matrix) =
    let C = new matrix(A.Rows,B.Rows)
    for r=0 to A.Rows-1 do
        for c=0 to B.Rows-1 do
            let mutable t = 0.0
            for i = 0 to A.Cols-1 do
                t <- t + A.[r,i] * B.[c,i]
            C.[r,c] <- s * t
    C

let mul_mTmT (s:double) (A:matrix) (B:matrix) =
    let C = new matrix(A.Cols,B.Rows)
    for r=0 to A.Cols-1 do
        for c=0 to B.Rows-1 do
            let mutable t = 0.0
            for i = 0 to A.Rows-1 do
                t <- t + A.[i,r] * B.[c,i]
            C.[r,c] <- s * t
    C

let mul_mv (s:double) (A:matrix) (b:vector) =
    let c = new vector(A.Rows)
    for r=0 to A.Rows-1 do
        let mutable t = 0.0
        for c=0 to A.Cols-1 do
            t <- t + A.[r,c] * b.[c]
        c.[r] <- s * t
    c

let mul_mTv (s:double) (A:matrix) (b:vector) =
    let c = new vector(A.Cols)
    for r=0 to A.Cols-1 do
        let mutable t = 0.0
        for c=0 to A.Rows-1 do
            t <- t + A.[c,r] * b.[c]
        c.[r] <- s * t
    c

let implicit = test "implicit" {

    test "mT" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use expected =
            let T = new matrix(n,m)
            for r = 0 to n-1 do
                for c = 0 to m-1 do
                    T.[r,c] <- A.[c,r]
            T
        use actual = matrixT.op_Implicit A.T
        Check.close High expected actual
    }

    test "mS" {
        let! m,n = gen2D
        use! A = genMatrix m n
        let! s = Gen.Double.OneTwo
        use expected =
            let AT = new matrix(m,n)
            for r = 0 to m-1 do
                for c = 0 to n-1 do
                    AT.[r,c] <- s * A.[r,c]
            AT
        use actual = matrixS.op_Implicit (s * A)
        Check.close High expected actual
    }

    test "mTS" {
        let! m,n = gen2D
        use! A = genMatrix m n
        let! s = Gen.Double.OneTwo
        use expected =
            let T = new matrix(n,m)
            for r = 0 to n-1 do
                for c = 0 to m-1 do
                    T.[r,c] <- s * A.[c,r]
            T
        use actual = matrixTS.op_Implicit (s * A.T)
        Check.close High expected actual
    }
}

let add = test "add" {

    test "mm" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix m n
        use expected = add_mm 1.0 A 1.0 B
        use actual = A + B
        Check.close High expected actual
    }

    test "mmT" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix n m
        use expected = add_mmT 1.0 A 1.0 B
        use actual = A + B.T
        Check.close High expected actual
    }

    test "mmS" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix m n
        let! s = Gen.Double.OneTwo
        use expected = add_mm 1.0 A s B
        use actual = A + s * B
        Check.close High expected actual
    }

    test "mmTS" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix n m
        let! s = Gen.Double.OneTwo
        use expected = add_mmT 1.0 A s B
        use actual = A + (s * B.T)
        Check.close High expected actual
    }

    test "mTm" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix m n
        use expected = add_mTm 1.0 A 1.0 B
        use actual = A.T + B
        Check.close High expected actual
    }

    test "mTmT" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix n m
        use expected = add_mTmT 1.0 A 1.0 B
        use actual = A.T + B.T
        Check.close High expected actual
    }

    test "mTmS" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix m n
        let! s = Gen.Double.OneTwo
        use expected = add_mTm 1.0 A s B
        use actual = A.T + (s * B)
        Check.close High expected actual
    }

    test "mTmTS" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix n m
        let! s = Gen.Double.OneTwo
        use expected = add_mTmT 1.0 A s B
        use actual = A.T + (s * B.T)
        Check.close High expected actual
    }

    test "mSm" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix m n
        let! s = Gen.Double.OneTwo
        use expected = add_mm s A 1.0 B
        use actual = (s * A) + B
        Check.close High expected actual
    }

    test "mSmT" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix n m
        let! s = Gen.Double.OneTwo
        use expected = add_mmT s A 1.0 B
        use actual = (s * A) + B.T
        Check.close High expected actual
    }

    test "mSmS" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix m n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = add_mm s1 A s2 B
        use actual = (s1 * A) + (s2 * B)
        Check.close High expected actual
    }

    test "mSmTS" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix n m
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = add_mmT s1 A s2 B
        use actual = (s1 * A) + (s2 * B.T)
        Check.close High expected actual
    }

    test "mTSm" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix m n
        let! s = Gen.Double.OneTwo
        use expected = add_mTm s A 1.0 B
        use actual = (s * A.T) + B
        Check.close High expected actual
    }

    test "mTSmT" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix n m
        let! s = Gen.Double.OneTwo
        use expected = add_mTmT s A 1.0 B
        use actual = (s * A.T) + B.T
        Check.close High expected actual
    }

    test "mTSmS" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix m n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = add_mTm s1 A s2 B
        use actual = (s1 * A.T) + (s2 * B)
        Check.close High expected actual
    }

    test "mTSmTS" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix n m
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = add_mTmT s1 A s2 B
        use actual = (s1 * A.T) + (s2 * B.T)
        Check.close High expected actual
    }
}

let sub = test "sub" {

    test "mm" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix m n
        use expected = add_mm 1.0 A -1.0 B
        use actual = A - B
        Check.close High expected actual
    }

    test "mmT" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix n m
        use expected = add_mmT 1.0 A -1.0 B
        use actual = A - B.T
        Check.close High expected actual
    }

    test "mmS" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix m n
        let! s = Gen.Double.OneTwo
        use expected = add_mm 1.0 A -s B
        use actual = A - s * B
        Check.close High expected actual
    }

    test "mmTS" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix n m
        let! s = Gen.Double.OneTwo
        use expected = add_mmT 1.0 A -s B
        use actual = A - (s * B.T)
        Check.close High expected actual
    }

    test "mTm" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix m n
        use expected = add_mTm 1.0 A -1.0 B
        use actual = A.T - B
        Check.close High expected actual
    }

    test "mTmT" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix n m
        use expected = add_mTmT 1.0 A -1.0 B
        use actual = A.T - B.T
        Check.close High expected actual
    }

    test "mTmS" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix m n
        let! s = Gen.Double.OneTwo
        use expected = add_mTm 1.0 A -s B
        use actual = A.T - (s * B)
        Check.close High expected actual
    }

    test "mTmTS" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix n m
        let! s = Gen.Double.OneTwo
        use expected = add_mTmT 1.0 A -s B
        use actual = A.T - (s * B.T)
        Check.close High expected actual
    }

    test "mSm" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix m n
        let! s = Gen.Double.OneTwo
        use expected = add_mm s A -1.0 B
        use actual = (s * A) - B
        Check.close High expected actual
    }

    test "mSmT" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix n m
        let! s = Gen.Double.OneTwo
        use expected = add_mmT s A -1.0 B
        use actual = (s * A) - B.T
        Check.close High expected actual
    }

    test "mSmS" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix m n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = add_mm s1 A -s2 B
        use actual = (s1 * A) - (s2 * B)
        Check.close High expected actual
    }

    test "mSmTS" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! B = genMatrix n m
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = add_mmT s1 A -s2 B
        use actual = (s1 * A) - (s2 * B.T)
        Check.close High expected actual
    }

    test "mTSm" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix m n
        let! s = Gen.Double.OneTwo
        use expected = add_mTm s A -1.0 B
        use actual = (s * A.T) - B
        Check.close High expected actual
    }

    test "mTSmT" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix n m
        let! s = Gen.Double.OneTwo
        use expected = add_mTmT s A -1.0 B
        use actual = (s * A.T) - B.T
        Check.close High expected actual
    }

    test "mTSmS" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix m n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = add_mTm s1 A -s2 B
        use actual = (s1 * A.T) - (s2 * B)
        Check.close High expected actual
    }

    test "mTSmTS" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! B = genMatrix n m
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = add_mTmT s1 A -s2 B
        use actual = (s1 * A.T) - (s2 * B.T)
        Check.close High expected actual
    }
}

let mul = test "mul" {

    test "mm" {
        let! m,k,n = gen3D
        use! A = genMatrix m k
        use! B = genMatrix k n
        use expected = mul_mm 1.0 A B
        use actual = A * B
        Check.close High expected actual
    }

    test "mmT" {
        let! m,k,n = gen3D
        use! A = genMatrix m k
        use! B = genMatrix n k
        use expected = mul_mmT 1.0 A B
        use actual = A * B.T
        Check.close High expected actual
    }

    test "mmS" {
        let! m,k,n = gen3D
        use! A = genMatrix m k
        use! B = genMatrix k n
        let! s = Gen.Double.OneTwo
        use expected = mul_mm s A B
        use actual = A * (s * B)
        Check.close High expected actual
    }

    test "mmTS" {
        let! m,k,n = gen3D
        use! A = genMatrix m k
        use! B = genMatrix n k
        let! s = Gen.Double.OneTwo
        use expected = mul_mmT s A B
        use actual = A * (s * B.T)
        Check.close High expected actual
    }

    test "mTm" {
        let! m,k,n = gen3D
        use! A = genMatrix k m
        use! B = genMatrix k n
        use expected = mul_mTm 1.0 A B
        use actual = A.T * B
        Check.close High expected actual
    }

    test "mTmT" {
        let! m,k,n = gen3D
        use! A = genMatrix k m
        use! B = genMatrix n k
        use expected = mul_mTmT 1.0 A B
        use actual = A.T * B.T
        Check.close High expected actual
    }

    test "mTmS" {
        let! m,k,n = gen3D
        use! A = genMatrix k m
        use! B = genMatrix k n
        let! s = Gen.Double.OneTwo
        use expected = mul_mTm s A B
        use actual = A.T * (s * B)
        Check.close High expected actual
    }

    test "mTmTS" {
        let! m,k,n = gen3D
        use! A = genMatrix k m
        use! B = genMatrix n k
        let! s = Gen.Double.OneTwo
        use expected = mul_mTmT s A B
        use actual = A.T * (s * B.T)
        Check.close High expected actual
    }

    test "mSm" {
        let! m,k,n = gen3D
        use! A = genMatrix m k
        use! B = genMatrix k n
        let! s = Gen.Double.OneTwo
        use expected = mul_mm s A B
        use actual = (s * A) * B
        Check.close High expected actual
    }

    test "mSmT" {
        let! m,k,n = gen3D
        use! A = genMatrix m k
        use! B = genMatrix n k
        let! s = Gen.Double.OneTwo
        use expected = mul_mmT s A B
        use actual = (s * A) * B.T
        Check.close High expected actual
    }

    test "mSmS" {
        let! m,k,n = gen3D
        use! A = genMatrix m k
        use! B = genMatrix k n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = mul_mm (s1*s2) A B
        use actual = (s1 * A) * (s2 * B)
        Check.close High expected actual
    }

    test "mSmTS" {
        let! m,k,n = gen3D
        use! A = genMatrix m k
        use! B = genMatrix n k
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = mul_mmT (s1*s2) A B
        use actual = (s1 * A) * (s2 * B.T)
        Check.close High expected actual
    }

    test "mTSm" {
        let! m,k,n = gen3D
        use! A = genMatrix k m
        use! B = genMatrix k n
        let! s = Gen.Double.OneTwo
        use expected = mul_mTm s A B
        use actual = (s * A.T) * B
        Check.close High expected actual
    }

    test "mTSmT" {
        let! m,k,n = gen3D
        use! A = genMatrix k m
        use! B = genMatrix n k
        let! s = Gen.Double.OneTwo
        use expected = mul_mTmT s A B
        use actual = (s * A.T) * B.T
        Check.close High expected actual
    }

    test "mTSmS" {
        let! m,k,n = gen3D
        use! A = genMatrix k m
        use! B = genMatrix k n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = mul_mTm (s1*s2) A B
        use actual = (s1 * A.T) * (s2 * B)
        Check.close High expected actual
    }

    test "mTSmTS" {
        let! m,k,n = gen3D
        use! A = genMatrix k m
        use! B = genMatrix n k
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = mul_mTmT (s1*s2) A B
        use actual = (s1 * A.T) * (s2 * B.T)
        Check.close High expected actual
    }

    test "mv" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! b = VectorTests.genVector n
        use expected = mul_mv 1.0 A b
        use actual = A * b
        Check.close High expected actual
    }

    test "mvS" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! b = VectorTests.genVector n
        let! s = Gen.Double.OneTwo
        use expected = mul_mv s A b
        use actual = A * (s * b)
        Check.close High expected actual
    }

    test "mTv" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! b = VectorTests.genVector n
        use expected = mul_mTv 1.0 A b
        use actual = A.T * b
        Check.close High expected actual
    }

    test "mTvS" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! b = VectorTests.genVector n
        let! s = Gen.Double.OneTwo
        use expected = mul_mTv s A b
        use actual = A.T * (s * b)
        Check.close High expected actual
    }

    test "mSv" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! b = VectorTests.genVector n
        let! s = Gen.Double.OneTwo
        use expected = mul_mv s A b
        use actual = (s * A) * b
        Check.close High expected actual
    }

    test "mSvS" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use! b = VectorTests.genVector n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = mul_mv (s1*s2) A b
        use actual = (s1 * A) * (s2 * b)
        Check.close High expected actual
    }

    test "mTSv" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! b = VectorTests.genVector n
        let! s = Gen.Double.OneTwo
        use expected = mul_mTv s A b
        use actual = (s * A.T) * b
        Check.close High expected actual
    }

    test "mTSvS" {
        let! m,n = gen2D
        use! A = genMatrix n m
        use! b = VectorTests.genVector n
        let! s1 = Gen.Double.OneTwo
        let! s2 = Gen.Double.OneTwo
        use expected = mul_mTv (s1*s2) A b
        use actual = (s1 * A.T) * (s2 * b)
        Check.close High expected actual
    }
}

let functions = test "functions" {

    test "sqrt" {
        let! m,n = gen2D
        use! A = genMatrix m n
        use expected =
            let E = new matrix(m,n)
            for r = 0 to m-1 do
                for c = 0 to n-1 do
                    E.[r,c] <- Math.Sqrt(A.[r,c])
            E
        use actual = Matrix.Sqrt(A)
        Check.close High expected actual
    }
}

let all =
    test "matrix" {
        implicit
        add
        sub
        mul
        functions
    }