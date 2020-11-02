module MatrixTests

open MKLNET
open CsCheck

let MAX_ROWS = 5
let MAX_COLS = 5

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

let add (A:matrix) (B:matrix) =
    let C = new matrix(A.Rows,A.Cols)
    for r=0 to A.Rows-1 do
        for c=0 to A.Cols-1 do
            C.[r,c] <- A.[r,c] + B.[r,c]
    C

let sub (A:matrix) (B:matrix) =
    let C = new matrix(A.Rows,A.Cols)
    for r=0 to A.Rows-1 do
        for c=0 to A.Cols-1 do
            C.[r,c] <- A.[r,c] - B.[r,c]
    C

let mul (A:matrix) (B:matrix) =
    let C = new matrix(A.Rows,B.Cols)
    for r=0 to A.Rows-1 do
        for c=0 to B.Cols-1 do
            let mutable t = 0.0
            for i = 0 to A.Cols-1 do
                t <- t + A.[r,i] * B.[i,c]
            C.[r,c] <- t
    C

let mulScale (s:double) (A:matrix) (B:matrix) =
    let C = new matrix(A.Rows,B.Cols)
    for r=0 to A.Rows-1 do
        for c=0 to B.Cols-1 do
            let mutable t = 0.0
            for i = 0 to A.Cols-1 do
                t <- t + A.[r,i] * B.[i,c]
            C.[r,c] <- s * t
    C

let mulTransposeLeft (A:matrix) (B:matrix) =
    let C = new matrix(A.Cols,B.Cols)
    for r=0 to A.Cols-1 do
        for c=0 to B.Cols-1 do
            let mutable t = 0.0
            for i = 0 to A.Rows-1 do
                t <- t + A.[i,r] * B.[i,c]
            C.[r,c] <- t
    C

let mulTransposeRight (A:matrix) (B:matrix) =
    let C = new matrix(A.Rows,B.Rows)
    for r=0 to A.Rows-1 do
        for c=0 to B.Rows-1 do
            let mutable t = 0.0
            for i = 0 to A.Cols-1 do
                t <- t + A.[r,i] * B.[c,i]
            C.[r,c] <- t
    C

let mulTransposeBoth (A:matrix) (B:matrix) =
    let C = new matrix(A.Cols,B.Rows)
    for r=0 to A.Cols-1 do
        for c=0 to B.Rows-1 do
            let mutable t = 0.0
            for i = 0 to A.Rows-1 do
                t <- t + A.[i,r] * B.[c,i]
            C.[r,c] <- t
    C

let all =
    test "matrix" {

        test "add" {
            let! rows = Gen.Int.[1,MAX_ROWS]
            let! cols = Gen.Int.[1,MAX_COLS]
            use! A = genMatrix rows cols
            use! B = genMatrix rows cols
            use expected = add A B
            use actual = A + B
            Check.close High expected actual
        }

        test "sub" {
            let! rows = Gen.Int.[1,MAX_ROWS]
            let! cols = Gen.Int.[1,MAX_COLS]
            use! A = genMatrix rows cols
            use! B = genMatrix rows cols
            use expected = sub A B
            use actual = A - B
            Check.close High expected actual
        }

        test "mul" {
            let! rowsA = Gen.Int.[1,MAX_ROWS]
            let! rowsB = Gen.Int.[1,MAX_ROWS]
            let! colsB = Gen.Int.[1,MAX_COLS]
            use! A = genMatrix rowsA rowsB
            use! B = genMatrix rowsB colsB
            use expected = mul A B
            use actual = A * B
            Check.close High expected actual
        }

        test "mul_scale" {
            let! rowsA = Gen.Int.[1,MAX_ROWS]
            let! rowsB = Gen.Int.[1,MAX_ROWS]
            let! colsB = Gen.Int.[1,MAX_COLS]
            let! s = Gen.Double.OneTwo
            use! A = genMatrix rowsA rowsB
            use! B = genMatrix rowsB colsB
            use expected = mulScale s A B
            use actual1 = s * A * B
            Check.close High expected actual1
            use actual2 = (A * s) * B
            Check.close High expected actual2
            use actual3 = A * (s * B)
            Check.close High expected actual3
            use actual4 = A * (B * s)
            Check.close High expected actual4
        }

        test "mul_transpose_right" {
            let! rowsA = Gen.Int.[1,MAX_ROWS]
            let! rowsB = Gen.Int.[1,MAX_ROWS]
            let! colsB = Gen.Int.[1,MAX_COLS]
            use! A = genMatrix rowsA rowsB
            use! B = genMatrix colsB rowsB
            use expected = mulTransposeRight A B
            use actual = A * B.T
            Check.close High expected actual
        }

        test "mul_transpose_left" {
            let! rowsA = Gen.Int.[1,MAX_ROWS]
            let! rowsB = Gen.Int.[1,MAX_ROWS]
            let! colsB = Gen.Int.[1,MAX_COLS]
            use! A = genMatrix rowsB rowsA
            use! B = genMatrix rowsB colsB
            use expected = mulTransposeLeft A B
            use actual = A.T * B
            Check.close High expected actual
        }

        test "mul_transpose_both" {
            let! rowsA = Gen.Int.[1,MAX_ROWS]
            let! rowsB = Gen.Int.[1,MAX_ROWS]
            let! colsB = Gen.Int.[1,MAX_COLS]
            use! A = genMatrix rowsB rowsA
            use! B = genMatrix colsB rowsB
            use expected = mulTransposeBoth A B
            use actual = A.T * B.T
            Check.close High expected actual
        }
    }