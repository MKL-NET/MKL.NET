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

    test "md" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! a = Gen.Double.OneTwo
        use expected =
            let R = new matrix(n,m)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R.[r,c] <- A.[r,c] + a
            R
        use actual = A + a
        Check.close High expected actual
    }

    test "mTd" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! a = Gen.Double.OneTwo
        use expected =
            let R = new matrix(m,n)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R.[c,r] <- A.[r,c] + a
            R
        use actual = A.T + a
        Check.close High expected actual
    }

    test "mSd" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! s = Gen.Double.OneTwo
        let! a = Gen.Double.OneTwo
        use expected =
            let R = new matrix(n,m)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R.[r,c] <- s * A.[r,c] + a
            R
        use actual = (s * A) + a
        Check.close High expected actual
    }

    test "mTSd" {
        let! m,n = gen2D
        use! A = genMatrix n m
        let! s = Gen.Double.OneTwo
        let! a = Gen.Double.OneTwo
        use expected =
            let R = new matrix(m,n)
            for r =0 to n-1 do
                for c=0 to m-1 do
                    R.[c,r] <- s * A.[r,c] + a
            R
        use actual = (s * A.T) + a
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

let testUnary name
    (fexpected:double -> double)
    (factual:matrix -> matrix)
    (factualT:matrixT -> matrix)
    (factualS:matrixS -> matrix)
    (factualTS:matrixTS -> matrix) =
    let map (A:matrix) =
        let E = new matrix(A.Rows,A.Cols)
        for r = 0 to A.Rows-1 do
            for c = 0 to A.Cols-1 do
                E.[r,c] <- fexpected(A.[r,c])
        E
    test name {
        let! m,n = gen2D
        use! A = genMatrix m n
        let! s = Gen.Double.Unit
        use expected = map A
        use actual = factual A
        Check.close High expected actual
        use T = matrixT.op_Implicit A.T
        use expectedT = map T
        use actualT = factualT A.T
        Check.close High expectedT actualT
        use S = matrixS.op_Implicit (s * A)
        use expectedS = map S
        use actualS = factualS (s * A)
        Check.close High expectedS actualS
        use TS = matrixTS.op_Implicit (s * A.T)
        use expectedTS = map TS
        use actualTS = factualTS (s * A.T)
        Check.close High expectedTS actualTS
    }

let functions = test "functions" {

    testUnary "Abs" abs Matrix.Abs Matrix.Abs Matrix.Abs Matrix.Abs
    testUnary "Sqr" (fun x -> x*x) Matrix.Sqr Matrix.Sqr Matrix.Sqr Matrix.Sqr
    testUnary "Inv" (fun x -> 1.0/x) Matrix.Inv Matrix.Inv Matrix.Inv Matrix.Inv
    testUnary "Sqrt" sqrt Matrix.Sqrt Matrix.Sqrt Matrix.Sqrt Matrix.Sqrt
    testUnary "InvSqrt" (fun x -> 1.0/sqrt x) Matrix.InvSqrt Matrix.InvSqrt Matrix.InvSqrt Matrix.InvSqrt
#if NETCOREAPP
    testUnary "Cbrt" Math.Cbrt Matrix.Cbrt Matrix.Cbrt Matrix.Cbrt Matrix.Cbrt
    testUnary "InvCbrt" ((/) 1.0 >> Math.Cbrt) Matrix.InvCbrt Matrix.InvCbrt Matrix.InvCbrt Matrix.InvCbrt
    testUnary "Pow2o3" (fun a -> Math.Cbrt(a*a)) Matrix.Pow2o3 Matrix.Pow2o3 Matrix.Pow2o3 Matrix.Pow2o3
#endif
    testUnary "Pow3o2" (fun a -> Math.Sqrt(a*a*a)) Matrix.Pow3o2 Matrix.Pow3o2 Matrix.Pow3o2 Matrix.Pow3o2
    testUnary "Exp" exp Matrix.Exp Matrix.Exp Matrix.Exp Matrix.Exp
    testUnary "Exp2" (fun i -> Math.Pow(2.0,i)) Matrix.Exp2 Matrix.Exp2 Matrix.Exp2 Matrix.Exp2
    testUnary "Exp10" (fun i -> Math.Pow(10.0,i)) Matrix.Exp10 Matrix.Exp10 Matrix.Exp10 Matrix.Exp10
    testUnary "Expm1" (fun i -> exp i-1.0) Matrix.Expm1 Matrix.Expm1 Matrix.Expm1 Matrix.Expm1
    testUnary "Ln" log Matrix.Ln Matrix.Ln Matrix.Ln Matrix.Ln
#if NETCOREAPP
    testUnary "Log2" Math.Log2 Matrix.Log2 Matrix.Log2 Matrix.Log2 Matrix.Log2
#endif
    testUnary "Log10" log10 Matrix.Log10 Matrix.Log10 Matrix.Log10 Matrix.Log10
    testUnary "Log1p" (fun i -> log(i+1.0)) Matrix.Log1p Matrix.Log1p Matrix.Log1p Matrix.Log1p
#if NETCOREAPP
    testUnary "Logb" (fun i -> Math.ILogB(i) |> double) Matrix.Logb Matrix.Logb Matrix.Logb Matrix.Logb
#endif
    testUnary "Cos" cos Matrix.Cos Matrix.Cos Matrix.Cos Matrix.Cos
    testUnary "Sin" sin Matrix.Sin Matrix.Sin Matrix.Sin Matrix.Sin
    testUnary "Tan" tan Matrix.Tan Matrix.Tan Matrix.Tan Matrix.Tan
    testUnary "Cospi" (fun i -> cos(Math.PI*i)) Matrix.Cospi Matrix.Cospi Matrix.Cospi Matrix.Cospi
    testUnary "Sinpi" (fun i -> sin(Math.PI*i)) Matrix.Sinpi Matrix.Sinpi Matrix.Sinpi Matrix.Sinpi
    testUnary "Tanpi" (fun i -> tan(Math.PI*i)) Matrix.Tanpi Matrix.Tanpi Matrix.Tanpi Matrix.Tanpi
    testUnary "Cosd" (fun i -> cos(Math.PI/180.0*i)) Matrix.Cosd Matrix.Cosd Matrix.Cosd Matrix.Cosd
    testUnary "Sind" (fun i -> sin(Math.PI/180.0*i)) Matrix.Sind Matrix.Sind Matrix.Sind Matrix.Sind
    testUnary "Tand" (fun i -> tan(Math.PI/180.0*i)) Matrix.Tand Matrix.Tand Matrix.Tand Matrix.Tand
    testUnary "Acos" acos Matrix.Acos Matrix.Acos Matrix.Acos Matrix.Acos
    testUnary "Asin" asin Matrix.Asin Matrix.Asin Matrix.Asin Matrix.Asin
    testUnary "Atan" atan Matrix.Atan Matrix.Atan Matrix.Atan Matrix.Atan
    testUnary "Acospi" (fun i -> acos i / Math.PI) Matrix.Acospi Matrix.Acospi Matrix.Acospi Matrix.Acospi
    testUnary "Asinpi" (fun i -> asin i / Math.PI) Matrix.Asinpi Matrix.Asinpi Matrix.Asinpi Matrix.Asinpi
    testUnary "Atanpi" (fun i -> atan i / Math.PI) Matrix.Atanpi Matrix.Atanpi Matrix.Atanpi Matrix.Atanpi
    testUnary "Cosh" cosh Matrix.Cosh Matrix.Cosh Matrix.Cosh Matrix.Cosh
    testUnary "Sinh" sinh Matrix.Sinh Matrix.Sinh Matrix.Sinh Matrix.Sinh
    testUnary "Tanh" tanh Matrix.Tanh Matrix.Tanh Matrix.Tanh Matrix.Tanh
#if NETCOREAPP
    testUnary "Acosh" Math.Acosh Matrix.Acosh Matrix.Acosh Matrix.Acosh Matrix.Acosh
    testUnary "Asinh" Math.Asinh Matrix.Asinh Matrix.Asinh Matrix.Asinh Matrix.Asinh
    testUnary "Atanh" Math.Atanh Matrix.Atanh Matrix.Atanh Matrix.Atanh Matrix.Atanh
#endif
    testUnary "Erf" erf Matrix.Erf Matrix.Erf Matrix.Erf Matrix.Erf
    testUnary "Erfc" erfc Matrix.Erfc Matrix.Erfc Matrix.Erfc Matrix.Erfc
    testUnary "ErfInv" erfinv Matrix.ErfInv Matrix.ErfInv Matrix.ErfInv Matrix.ErfInv
    testUnary "ErfcInv" erfcinv Matrix.ErfcInv Matrix.ErfcInv Matrix.ErfcInv Matrix.ErfcInv
    testUnary "CdfNorm" normcdf Matrix.CdfNorm Matrix.CdfNorm Matrix.CdfNorm Matrix.CdfNorm
    testUnary "CdfNormInv" normcdfinv Matrix.CdfNormInv Matrix.CdfNormInv Matrix.CdfNormInv Matrix.CdfNormInv
    testUnary "LGamma" lgamma Matrix.LGamma Matrix.LGamma Matrix.LGamma Matrix.LGamma
    testUnary "TGamma" gamma Matrix.TGamma Matrix.TGamma Matrix.TGamma Matrix.TGamma
    testUnary "ExpInt1" (expint 1) Matrix.ExpInt1 Matrix.ExpInt1 Matrix.ExpInt1 Matrix.ExpInt1
    testUnary "Floor" floor Matrix.Floor Matrix.Floor Matrix.Floor Matrix.Floor
    testUnary "Ceil" ceil Matrix.Ceil Matrix.Ceil Matrix.Ceil Matrix.Ceil
    testUnary "Trunc" truncate Matrix.Trunc Matrix.Trunc Matrix.Trunc Matrix.Trunc
    testUnary "Round" (fun a -> Math.Round(a, MidpointRounding.AwayFromZero))
        Matrix.Round Matrix.Round Matrix.Round Matrix.Round
    testUnary "Frac" (fun a -> a - truncate a)
        Matrix.Frac Matrix.Frac Matrix.Frac Matrix.Frac
    testUnary "NearbyInt" (fun a -> Math.Round(a, MidpointRounding.ToEven))
        Matrix.NearbyInt Matrix.NearbyInt Matrix.NearbyInt Matrix.NearbyInt
    testUnary "Rint" (fun a -> Math.Round(a, MidpointRounding.ToEven))
        Matrix.Rint Matrix.Rint Matrix.Rint Matrix.Rint
}

let all =
    test "matrix" {
        implicit
        add
        sub
        mul
        functions
    }