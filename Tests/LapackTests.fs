module LapackTests

open System
open MKLNET
open CsCheck

let ROWS_MAX = 5
let COLS_MAX = 3

let all =
    test "Lapack" {

        test "potrf" {
            let! rows = Gen.Int.[3,ROWS_MAX]
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
    }