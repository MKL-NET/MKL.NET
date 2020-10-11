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

let trans (A:'a[]) rows cols =
    Array.init A.Length (fun i ->
        let row,col = Math.DivRem(i,rows)
        A.[row+col*cols]
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

let lower (A:'a[]) rows =
    for i = 0 to rows-2 do
        for j = i+1 to rows-1 do
            A.[j+i*rows] <- Unchecked.defaultof<'a>

let symmetric (A:'a[]) rows =
    for r = 0 to rows-2 do
        for c = r+1 to rows-1 do
            A.[c+r*rows] <- A.[r+c*rows]

let factorization =
    test "factorization" {

        test "getrf_double" { // LU factorization with permutation matrix
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
            Check.close High expected PLU
        }

        test "getrf_single" { // LU factorization with permutation matrix
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

        test "getrfnp_double" { // LU factorization
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Double.OneTwo.Array.[rows*cols]
            let expected = Array.copy A
            Lapack.getrfnp(Layout.RowMajor, rows, cols, A, cols) |> Check.equal 0
            let mids = min rows cols
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
            let LU = mul rows L mids U cols
            Check.close High expected LU
        }

        test "getrfnp_single" { // LU factorization
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Single.OneTwo.Array.[rows*cols]
            let expected = Array.copy A
            Lapack.getrfnp(Layout.RowMajor, rows, cols, A, cols) |> Check.equal 0
            let mids = min rows cols
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
            let LU = mul rows L mids U cols
            Check.close Low expected LU
        }

        test "getrfnpi_double" { // LU factorization incomplete
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Double.OneTwo.Array.[rows*cols]
            let expected = Array.copy A
            let mids = min rows cols
            Lapack.getrfnpi(Layout.RowMajor, rows, cols, mids, A, cols) |> Check.equal 0
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
            let LU = mul rows L mids U cols
            Check.close High expected LU
        }

        test "getrfnpi_single" { // LU factorization incomplete
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Single.OneTwo.Array.[rows*cols]
            let expected = Array.copy A
            let mids = min rows cols
            Lapack.getrfnpi(Layout.RowMajor, rows, cols, mids, A, cols) |> Check.equal 0
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
            let LU = mul rows L mids U cols
            Check.close Low expected LU
        }

        test "getrf2_double" { // LU factorization with permutation matrix partial pivoting
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Double.OneTwo.Array.[rows*cols]
            let mids = min rows cols
            let ipiv = Array.zeroCreate mids
            let expected = Array.copy A
            Lapack.getrf2(Layout.RowMajor, rows, cols, A, cols, ipiv) |> Check.equal 0
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
            Check.close High expected PLU
        }

        test "getrf2_single" { // LU factorization with permutation matrix partial pivoting
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Single.OneTwo.Array.[rows*cols]
            let mids = min rows cols
            let ipiv = Array.zeroCreate mids
            let expected = Array.copy A
            Lapack.getrf2(Layout.RowMajor, rows, cols, A, cols, ipiv) |> Check.greaterThan -1
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

        test "potrf_double" { // Cholesky factorization
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! L = Gen.Double.OneTwo.Array.[rows*rows]
            lower L rows
            let A = mul rows L rows (trans L rows rows) rows
            Lapack.potrf(Layout.RowMajor, UpLoChar.Lower, rows, A, rows) |> Check.equal 0
            lower A rows
            Check.close High L A
        }

        test "potrf_single" { // Cholesky factorization
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! L = Gen.Single.OneTwo.Array.[rows*rows]
            lower L rows
            let A = mul rows L rows (trans L rows rows) rows
            Lapack.potrf(Layout.RowMajor, UpLoChar.Lower, rows, A, rows) |> Check.equal 0
            lower A rows
            Check.close High L A
        }

        test "potrf2_double" { // Cholesky factorization using a recursive algorithm
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! L = Gen.Double.OneTwo.Array.[rows*rows]
            lower L rows
            let A = mul rows L rows (trans L rows rows) rows
            Lapack.potrf2(Layout.RowMajor, UpLoChar.Lower, rows, A, rows) |> Check.equal 0
            lower A rows
            Check.close High L A
        }

        test "potrf2_single" { // Cholesky factorization using a recursive algorithm
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! L = Gen.Single.OneTwo.Array.[rows*rows]
            lower L rows
            let A = mul rows L rows (trans L rows rows) rows
            Lapack.potrf2(Layout.RowMajor, UpLoChar.Lower, rows, A, rows) |> Check.equal 0
            lower A rows
            Check.close High L A
        }

        test "pstrf_double" { // Cholesky factorization with complete pivoting
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! L = Gen.Double.OneTwo.Array.[rows*rows]
            lower L rows
            let A = mul rows L rows (trans L rows rows) rows
            let L = Array.copy A
            let piv = Array.zeroCreate rows
            let mutable rank = 0
            Lapack.pstrf(Layout.RowMajor, UpLoChar.Lower, rows, L, rows, piv, &rank, -1.0) |> Check.equal 0
            lower L rows
            let P = Array.zeroCreate (rows*rows)
            for i = 0 to rows-1 do P.[i+(piv.[i]-1)*rows] <- 1.0
            let PL = mul rows P rows L rows
            let expected = mul rows PL rows (trans PL rows rows) rows
            Check.close High expected A
        }

        test "pstrf_single" { // Cholesky factorization with complete pivoting
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! L = Gen.Single.OneTwo.Array.[rows*rows]
            lower L rows
            let A = mul rows L rows (trans L rows rows) rows
            let L = Array.copy A
            let piv = Array.zeroCreate rows
            let mutable rank = 0
            Lapack.pstrf(Layout.RowMajor, UpLoChar.Lower, rows, L, rows, piv, &rank, -1.0f) |> Check.equal 0
            lower L rows
            let P = Array.zeroCreate (rows*rows)
            for i = 0 to rows-1 do P.[i+(piv.[i]-1)*rows] <- 1.0f
            let PL = mul rows P rows L rows
            let expected = mul rows PL rows (trans PL rows rows) rows
            Check.close High expected A
        }

        test "sytrf_double" { // Bunch-Kaufman factorization
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! L = Gen.Double.OneTwo.Array.[rows*rows]
            lower L rows
            let A = mul rows L rows (trans L rows rows) rows
            let ipiv = Array.zeroCreate rows
            let D = Array.copy A
            Lapack.sytrf(Layout.RowMajor, UpLoChar.Lower, rows, D, rows, ipiv) |> Check.equal 0
            let L = Array.init (rows*rows) (fun i ->
                let row,col = Math.DivRem(i,rows)
                if col > row then 0.0
                elif col = row then 1.0
                else D.[col+row*rows]
            )
            let D = Array.init (rows*rows) (fun i ->
                let row,col = Math.DivRem(i,rows)
                if col = row then D.[col+row*rows]
                else 0.0
            )
            let expected = mul rows (mul rows L rows D rows) rows (trans L rows rows) rows
            if Array.indexed ipiv |> Array.forall (fun (i,j) -> i=j-1) then
                Check.close High expected A
        }

        test "sytrf_float" { // Bunch-Kaufman factorization
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! L = Gen.Single.OneTwo.Array.[rows*rows]
            lower L rows
            let A = mul rows L rows (trans L rows rows) rows
            let ipiv = Array.zeroCreate rows
            let D = Array.copy A
            Lapack.sytrf(Layout.RowMajor, UpLoChar.Lower, rows, D, rows, ipiv) |> Check.equal 0
            let L = Array.init (rows*rows) (fun i ->
                let row,col = Math.DivRem(i,rows)
                if col > row then 0.0f
                elif col = row then 1.0f
                else D.[col+row*rows]
            )
            let D = Array.init (rows*rows) (fun i ->
                let row,col = Math.DivRem(i,rows)
                if col = row then D.[col+row*rows]
                else 0.0f
            )
            let expected = mul rows (mul rows L rows D rows) rows (trans L rows rows) rows
            if Array.indexed ipiv |> Array.forall (fun (i,j) -> i=j-1) then
                Check.close High expected A
        }
    }

let linear_equations =
    test "linear_equations" {

        test "getrs_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Double.OneTwo.Array.[rows*rows]
            lower A rows
            let! B = Gen.Double.OneTwo.Array.[rows*cols]
            let LU = Array.copy A
            let X = Array.copy B
            let ipiv = Array.zeroCreate rows
            Lapack.getrf(Layout.RowMajor, rows, rows, LU, rows, ipiv) |> Check.equal 0
            Lapack.getrs(Layout.RowMajor, TransChar.No, rows, cols, LU, rows, ipiv, X, cols) |> Check.equal 0
            let expected = mul rows A rows X cols
            Check.close High expected B
        }

        test "getrs_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Single.OneTwo.Array.[rows*rows]
            lower A rows
            let! B = Gen.Single.OneTwo.Array.[rows*cols]
            let LU = Array.copy A
            let X = Array.copy B
            let ipiv = Array.zeroCreate rows
            Lapack.getrf(Layout.RowMajor, rows, rows, LU, rows, ipiv) |> Check.equal 0
            Lapack.getrs(Layout.RowMajor, TransChar.No, rows, cols, LU, rows, ipiv, X, cols) |> Check.equal 0
            let expected = mul rows A rows X cols
            Check.close Medium expected B
        }

        test "potrs_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! L = Gen.Double.OneTwo.Array.[rows*rows]
            lower L rows
            let A = mul rows L rows (trans L rows rows) rows
            let! B = Gen.Double.OneTwo.Array.[rows*cols]
            let LU = Array.copy A
            let X = Array.copy B
            Lapack.potrf(Layout.RowMajor, UpLoChar.Lower, rows, LU, rows) |> Check.equal 0
            Lapack.potrs(Layout.RowMajor, UpLoChar.Lower, rows, cols, LU, rows, X, cols) |> Check.equal 0
            let expected = mul rows A rows X cols
            Check.close High expected B
        }

        test "potrs_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! L = Gen.Single.OneTwo.Array.[rows*rows]
            lower L rows
            let A = mul rows L rows (trans L rows rows) rows
            let! B = Gen.Single.OneTwo.Array.[rows*cols]
            let LU = Array.copy A
            let X = Array.copy B
            Lapack.potrf(Layout.RowMajor, UpLoChar.Lower, rows, LU, rows) |> Check.equal 0
            Lapack.potrs(Layout.RowMajor, UpLoChar.Lower, rows, cols, LU, rows, X, cols) |> Check.equal 0
            let expected = mul rows A rows X cols
            Check.close Medium expected B
        }

        test "sytrs_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! L = Gen.Double.OneTwo.Array.[rows*rows]
            lower L rows
            let A = mul rows L rows (trans L rows rows) rows
            let! B = Gen.Double.OneTwo.Array.[rows*cols]
            let ipiv = Array.zeroCreate rows
            let D = Array.copy A
            let X = Array.copy B
            Lapack.sytrf(Layout.RowMajor, UpLoChar.Lower, rows, D, rows, ipiv) |> Check.equal 0
            Lapack.sytrs(Layout.RowMajor, UpLoChar.Lower, rows, cols, D, rows, ipiv, X, cols) |> Check.equal 0
            let expected = mul rows A rows X cols
            Check.close High expected B
        }

        test "sytrs_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! L = Gen.Single.OneTwo.Array.[rows*rows]
            lower L rows
            let A = mul rows L rows (trans L rows rows) rows
            let! B = Gen.Single.OneTwo.Array.[rows*cols]
            let ipiv = Array.zeroCreate rows
            let D = Array.copy A
            let X = Array.copy B
            Lapack.sytrf(Layout.RowMajor, UpLoChar.Lower, rows, D, rows, ipiv) |> Check.equal 0
            Lapack.sytrs(Layout.RowMajor, UpLoChar.Lower, rows, cols, D, rows, ipiv, X, cols) |> Check.equal 0
            let expected = mul rows A rows X cols
            Check.close Medium expected B
        }

        test "sytrs2_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! L = Gen.Double.OneTwo.Array.[rows*rows]
            lower L rows
            let A = mul rows L rows (trans L rows rows) rows
            let! B = Gen.Double.OneTwo.Array.[rows*cols]
            let ipiv = Array.zeroCreate rows
            let D = Array.copy A
            let X = Array.copy B
            Lapack.sytrf(Layout.RowMajor, UpLoChar.Lower, rows, D, rows, ipiv) |> Check.equal 0
            Lapack.sytrs2(Layout.RowMajor, UpLoChar.Lower, rows, cols, D, rows, ipiv, X, cols) |> Check.equal 0
            let expected = mul rows A rows X cols
            Check.close High expected B
        }

        test "sytrs2_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! L = Gen.Single.OneTwo.Array.[rows*rows]
            lower L rows
            let A = mul rows L rows (trans L rows rows) rows
            let! B = Gen.Single.OneTwo.Array.[rows*cols]
            let ipiv = Array.zeroCreate rows
            let D = Array.copy A
            let X = Array.copy B
            Lapack.sytrf(Layout.RowMajor, UpLoChar.Lower, rows, D, rows, ipiv) |> Check.equal 0
            Lapack.sytrs2(Layout.RowMajor, UpLoChar.Lower, rows, cols, D, rows, ipiv, X, cols) |> Check.equal 0
            let expected = mul rows A rows X cols
            Check.close Medium expected B
        }

        test "gesv_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Double.OneTwo.Array.[rows*rows]
            let! B = Gen.Double.OneTwo.Array.[rows*cols]
            let LU = Array.copy A
            let X = Array.copy B
            let ipiv = Array.zeroCreate rows
            Lapack.gesv(Layout.RowMajor, rows, cols, LU, rows, ipiv, X, cols) |> Check.equal 0
            let expected = mul rows A rows X cols
            Check.close High expected B
        }

        test "gesv_float" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Single.OneTwo.Array.[rows*rows]
            let! B = Gen.Single.OneTwo.Array.[rows*cols]
            lower A rows
            let A = mul rows A rows (trans A rows rows) rows
            let LU = Array.copy A
            let X = Array.copy B
            let ipiv = Array.zeroCreate rows
            Lapack.gesv(Layout.RowMajor, rows, cols, LU, rows, ipiv, X, cols) |> Check.equal 0
            let expected = mul rows A rows X cols
            Check.close Low expected B
        }

        test "posv_double" {
            let! rows = Gen.Int.[2,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Double.OneTwo.Array.[rows*rows]
            let! B = Gen.Double.OneTwo.Array.[rows*cols]
            lower A rows
            let A = mul rows A rows (trans A rows rows) rows
            let L = Array.copy A
            let X = Array.copy B
            Lapack.posv(Layout.RowMajor, UpLoChar.Lower, rows, cols, L, rows, X, cols) |> Check.equal 0
            let expected = mul rows A rows X cols
            Check.close High expected B
        }

        test "posv_single" {
            let! rows = Gen.Int.[2,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Single.OneTwo.Array.[rows*rows]
            let! B = Gen.Single.OneTwo.Array.[rows*cols]
            lower A rows
            let A = mul rows A rows (trans A rows rows) rows
            let L = Array.copy A
            let X = Array.copy B
            Lapack.posv(Layout.RowMajor, UpLoChar.Lower, rows, cols, L, rows, X, cols) |> Check.equal 0
            let expected = mul rows A rows X cols
            Check.close Medium expected B
        }

        test "sysv_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Double.OneTwo.Array.[rows*rows]
            let! B = Gen.Double.OneTwo.Array.[rows*cols]
            lower A rows
            let A = mul rows A rows (trans A rows rows) rows
            let LU = Array.copy A
            let X = Array.copy B
            let ipiv = Array.zeroCreate rows
            Lapack.sysv(Layout.RowMajor, UpLoChar.Lower, rows, cols, LU, rows, ipiv, X, cols) |> Check.equal 0
            let expected = mul rows A rows X cols
            Check.close High expected B
        }

        test "sysv_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Single.OneTwo.Array.[rows*rows]
            let! B = Gen.Single.OneTwo.Array.[rows*cols]
            lower A rows
            let A = mul rows A rows (trans A rows rows) rows
            let LU = Array.copy A
            let X = Array.copy B
            let ipiv = Array.zeroCreate rows
            Lapack.sysv(Layout.RowMajor, UpLoChar.Lower, rows, cols, LU, rows, ipiv, X, cols) |> Check.equal 0
            let expected = mul rows A rows X cols
            Check.close Medium expected B
        }
    }

let inversion =
    test "inversion" {

        test "getri_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! A = Gen.Double.OneTwo.Array.[rows*rows]
            let ipiv = Array.zeroCreate rows
            let LU = Array.copy A
            Lapack.getrf(Layout.RowMajor, rows, rows, LU, rows, ipiv) |> Check.equal 0
            Lapack.getri(Layout.RowMajor, rows, LU, rows, ipiv) |> Check.equal 0
            let expected = mul rows (mul rows A rows LU rows) rows A rows
            Check.close High expected A
        }

        test "getri_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! A = Gen.Single.OneTwo.Array.[rows*rows]
            lower A rows
            let A = mul rows A rows (trans A rows rows) rows
            let ipiv = Array.zeroCreate rows
            let LU = Array.copy A
            Lapack.getrf(Layout.RowMajor, rows, rows, LU, rows, ipiv) |> Check.equal 0
            Lapack.getri(Layout.RowMajor, rows, LU, rows, ipiv) |> Check.equal 0
            let expected = mul rows (mul rows A rows LU rows) rows A rows
            Check.close Low expected A
        }

        test "getrinp_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! A = Gen.Double.OneTwo.Array.[rows*rows]
            let LU = Array.copy A
            Lapack.getrfnp(Layout.RowMajor, rows, rows, LU, rows) |> Check.equal 0
            Lapack.getrinp(Layout.RowMajor, rows, LU, rows) |> Check.equal 0
            let expected = mul rows (mul rows A rows LU rows) rows A rows
            Check.close High expected A
        }

        test "getrinp_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! A = Gen.Single.OneTwo.Array.[rows*rows]
            lower A rows
            let A = mul rows A rows (trans A rows rows) rows
            let LU = Array.copy A
            Lapack.getrfnp(Layout.RowMajor, rows, rows, LU, rows) |> Check.equal 0
            Lapack.getrinp(Layout.RowMajor, rows, LU, rows) |> Check.equal 0
            let expected = mul rows (mul rows A rows LU rows) rows A rows
            Check.close Low expected A
        }

        test "potri_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! L = Gen.Double.OneTwo.Array.[rows*rows]
            lower L rows
            let A = mul rows L rows (trans L rows rows) rows
            let LU = Array.copy A
            Lapack.potrf(Layout.RowMajor, UpLoChar.Lower, rows, LU, rows) |> Check.equal 0
            Lapack.potri(Layout.RowMajor, UpLoChar.Lower, rows, LU, rows) |> Check.equal 0
            for r = 0 to rows-2 do
                for c = r+1 to rows-1 do
                    LU.[c+r*rows] <- LU.[r+c*rows]
            let expected = mul rows (mul rows A rows LU rows) rows A rows
            Check.close High expected A
        }

        test "potri_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! L = Gen.Single.OneTwo.Array.[rows*rows]
            lower L rows
            let A = mul rows L rows (trans L rows rows) rows
            let LU = Array.copy A
            Lapack.potrf(Layout.RowMajor, UpLoChar.Lower, rows, LU, rows) |> Check.equal 0
            Lapack.potri(Layout.RowMajor, UpLoChar.Lower, rows, LU, rows) |> Check.equal 0
            for r = 0 to rows-2 do
                for c = r+1 to rows-1 do
                    LU.[c+r*rows] <- LU.[r+c*rows]
            let expected = mul rows (mul rows A rows LU rows) rows A rows
            Check.close Medium expected A
        }

        test "sytri_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! A = Gen.Double.OneTwo.Array.[rows*rows]
            symmetric A rows
            let D = Array.copy A
            let ipiv = Array.zeroCreate rows
            Lapack.sytrf(Layout.RowMajor, UpLoChar.Lower, rows, D, rows, ipiv) |> Check.equal 0
            Lapack.sytri(Layout.RowMajor, UpLoChar.Lower, rows, D, rows, ipiv) |> Check.equal 0
            symmetric D rows
            let expected = mul rows (mul rows A rows D rows) rows A rows
            Check.close High expected A
        }

        test "sytri_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! A = Gen.Single.OneTwo.Array.[rows*rows]
            lower A rows
            let A = mul rows A rows (trans A rows rows) rows
            let D = Array.copy A
            let ipiv = Array.zeroCreate rows
            Lapack.sytrf(Layout.RowMajor, UpLoChar.Lower, rows, D, rows, ipiv) |> Check.equal 0
            Lapack.sytri(Layout.RowMajor, UpLoChar.Lower, rows, D, rows, ipiv) |> Check.equal 0
            symmetric D rows
            let expected = mul rows (mul rows A rows D rows) rows A rows
            Check.close Low expected A
        }

        test "sytri2_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! A = Gen.Double.OneTwo.Array.[rows*rows]
            symmetric A rows
            let D = Array.copy A
            let ipiv = Array.zeroCreate rows
            Lapack.sytrf(Layout.RowMajor, UpLoChar.Lower, rows, D, rows, ipiv) |> Check.equal 0
            Lapack.sytri2(Layout.RowMajor, UpLoChar.Lower, rows, D, rows, ipiv) |> Check.equal 0
            symmetric D rows
            let expected = mul rows (mul rows A rows D rows) rows A rows
            Check.close High expected A
        }

        test "sytri2_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! A = Gen.Single.OneTwo.Array.[rows*rows]
            lower A rows
            let A = mul rows A rows (trans A rows rows) rows
            let D = Array.copy A
            let ipiv = Array.zeroCreate rows
            Lapack.sytrf(Layout.RowMajor, UpLoChar.Lower, rows, D, rows, ipiv) |> Check.equal 0
            Lapack.sytri2(Layout.RowMajor, UpLoChar.Lower, rows, D, rows, ipiv) |> Check.equal 0
            symmetric D rows
            let expected = mul rows (mul rows A rows D rows) rows A rows
            Check.close Low expected A
        }
    }

let least_squares =
    test "least_squares" {

        test "gels_double" {
            let! rowsa = Gen.Int.[1,ROWS_MAX]
            let! colsa = Gen.Int.[1,rowsa]
            let! colsb = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Double.OneTwo.Array.[rowsa*colsa]
            let! B = Gen.Double.OneTwo.Array.[rowsa*colsb]
            let QR = Array.copy A
            let X = Array.copy B
            Lapack.gels(Layout.RowMajor, TransChar.No, rowsa, colsa, colsb, QR, colsa, X, colsb) |> Check.equal 0
            let X = Array.init (colsa*colsb) (fun i ->
                let row,col = Math.DivRem(i,colsb)
                X.[col+row*colsb]
            )
            let norm2 X =
                let AX = mul rowsa A colsa X colsb
                Array.fold2 (fun t a b -> t + (a-b)*(a-b)) 0.0 B AX
            let norm2_0 = norm2 X
            let! di = Gen.Int.[0,X.Length-1]
            X.[di] <- X.[di] + 0.001
            let norm2_d = norm2 X
            Check.greaterThanOrEqual norm2_0 norm2_d
        }

        test "gels_single" {
            let! rowsa = Gen.Int.[1,ROWS_MAX]
            let! colsa = Gen.Int.[1,rowsa]
            let! colsb = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Single.OneTwo.Array.[rowsa*colsa]
            let! B = Gen.Single.OneTwo.Array.[rowsa*colsb]
            let QR = Array.copy A
            let X = Array.copy B
            Lapack.gels(Layout.RowMajor, TransChar.No, rowsa, colsa, colsb, QR, colsa, X, colsb) |> Check.equal 0
            let X = Array.init (colsa*colsb) (fun i ->
                let row,col = Math.DivRem(i,colsb)
                X.[col+row*colsb]
            )
            let norm2 X =
                let AX = mul rowsa A colsa X colsb
                Array.fold2 (fun t a b -> t + (a-b)*(a-b)) 0.0f B AX
            let norm2_0 = norm2 X
            let! di = Gen.Int.[0,X.Length-1]
            X.[di] <- X.[di] + 0.01f
            let norm2_d = norm2 X
            Check.greaterThanOrEqual norm2_0 norm2_d
        }
    }

let all =
    test "Lapack" {
        factorization
        linear_equations
        inversion
        least_squares
    }