module PerfTests

open MKLNET
open CsCheck

let ROWS = 100

let all =
    test "perf" {

        let a = Array.zeroCreate<double> (ROWS*ROWS)
        let b = Array.zeroCreate<double> (ROWS*ROWS)
        let r = Array.zeroCreate<double> (ROWS*ROWS)

        test "add" {
            Check.Faster(
                (fun () -> Vml.Add(a, b, r)),
                (fun () ->
                    for i = 0 to a.Length-1 do
                        r.[i] <- a.[i] + b.[i])
            ,threads=1,sigma=100.0) |> Check.info "%O"
        }

        test "mul" {
            Check.Faster(
                (fun () -> Vml.Mul(a, b, r)),
                (fun () ->
                    for i = 0 to a.Length-1 do
                        r.[i] <- a.[i] + b.[i])
            ,threads=1,sigma=100.0) |> Check.info "%O"
        }

        test "dot" {
            Check.Faster(
                (fun () -> Blas.dot(a, b)),
                (fun () ->
                    let mutable t = 0.0
                    for i = 0 to a.Length-1 do
                        t <- t + a.[i] * b.[i]
                    t
                )
            ,threads=1,sigma=100.0) |> Check.info "%O"
        }

        test "gemm" {
            Check.Faster(
                (fun () -> Blas.gemm(Layout.RowMajor, Trans.No, Trans.No, ROWS, ROWS, ROWS, 1.0, a, ROWS, b, ROWS, 0.0, r, ROWS)),
                (fun () ->
                    for i = 0 to ROWS-1 do
                        for j = 0 to ROWS-1 do
                            let mutable t = 0.0
                            for k = 0 to ROWS-1 do
                                t <- t + a.[k+i*ROWS] * b.[j+k*ROWS]
                            r.[j+i*ROWS] <- t
                )
            ,threads=1,sigma=100.0) |> Check.info "%O"
        }
    }