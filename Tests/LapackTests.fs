module LapackTests

open System
open MKLNET
open CsCheck

let ROWS_MAX = 5
let COLS_MAX = 3

let inline mul rows (A:'a[]) mids (B:'a[]) cols =
    Array.init (rows*cols) (fun i ->
        let row,col = Math.DivRem(i,cols)
        let mutable t = Unchecked.defaultof<'a>
        for k = 0 to mids-1 do
            t <- t + A.[k+row*mids] * B.[col+k*cols]
        t
    )

let perm (ipiv:int[]) n one =
    let p = Array.init n id
    for i = 0 to ipiv.Length-1 do
        let j = ipiv.[i]-1
        let swap = p.[i]
        p.[i] <- p.[j]
        p.[j] <- swap
    let r = Array.zeroCreate (n*n)
    for col = 0 to n-1 do
        let row = p.[col]
        r.[col+row*n] <- one
    r


let all =
    test "Lapack" {

        test "getrf_double" { // LU factorization
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Double.OneTwo.Array.[rows*cols]
            let mids = min rows cols
            let ipiv = Array.zeroCreate mids
            let expected = Array.copy A
            Lapack.getrf(Layout.RowMajor, rows, cols, A, cols, ipiv) |> Check.equal 0
            let L = Array.init (rows*mids) (fun i ->
                let row,col = Math.DivRem(i,mids)
                if col > row then 0.0
                elif col = row then 1.0
                else A.[col+row*cols]
            )
            let U = Array.init (mids*cols) (fun i ->
                let row,col = Math.DivRem(i,cols)
                if col < row then 0.0
                else A.[col+row*cols]
            )
            let P = perm ipiv rows 1.0
            let LU = mul rows L mids U cols
            let PLU = mul rows P rows LU cols
            Check.close VeryHigh expected PLU
        }

        test "getrf_single" { // LU factorization
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Single.OneTwo.Array.[rows*cols]
            let mids = min rows cols
            let ipiv = Array.zeroCreate mids
            let expected = Array.copy A
            Lapack.getrf(Layout.RowMajor, rows, cols, A, cols, ipiv) |> Check.equal 0
            let L = Array.init (rows*mids) (fun i ->
                let row,col = Math.DivRem(i,mids)
                if col > row then 0.0f
                elif col = row then 1.0f
                else A.[col+row*cols]
            )
            let U = Array.init (mids*cols) (fun i ->
                let row,col = Math.DivRem(i,cols)
                if col < row then 0.0f
                else A.[col+row*cols]
            )
            let P = perm ipiv rows 1.0f
            let LU = mul rows L mids U cols
            let PLU = mul rows P rows LU cols
            Check.close High expected PLU
        }

        test "potrf_double" { // Cholesky
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! expected = Gen.Double.OneTwo.Array.[rows*rows]
            for i = 0 to rows-2 do
                for j = i+1 to rows-1 do
                    expected.[j+i*rows] <- 0.0

            let a = Array.init (rows*rows) (fun i ->
                let row, col = Math.DivRem(i,rows)
                if col > row then 0.0
                else
                    let mutable t = 0.0
                    for k = 0 to row do
                        t <- t + expected.[k+col*rows] * expected.[k+row*rows]
                    t
            )
            Lapack.potrf(Layout.RowMajor, UpLoChar.Lower, rows, a, rows) |> Check.equal 0
            Check.close High expected a
        }

        test "potrf_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! expected = Gen.Single.OneTwo.Array.[rows*rows]
            for i = 0 to rows-2 do
                for j = i+1 to rows-1 do
                    expected.[j+i*rows] <- 0.0f

            let a = Array.init (rows*rows) (fun i ->
                let row, col = Math.DivRem(i,rows)
                if col > row then 0.0f
                else
                    let mutable t = 0.0f
                    for k = 0 to row do
                        t <- t + expected.[k+col*rows] * expected.[k+row*rows]
                    t
            )
            Lapack.potrf(Layout.RowMajor, UpLoChar.Lower, rows, a, rows) |> Check.equal 0
            Check.close High expected a
        }
    }