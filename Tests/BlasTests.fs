module BlasTests

open MKLNET
open CsCheck

let ROWS_MAX = 5

let all =
    test "blas_1" {

        test "asum_double" {
            let! x = Gen.Double.Array.[1,ROWS_MAX]
            let expected = Array.sumBy abs x
            Blas.asum x |> Check.close High expected
        }

        test "asum_single" {
            let! x = Gen.Single.Array.[1,ROWS_MAX]
            let expected = Array.sumBy abs x
            Blas.asum x |> Check.close High expected
        }

        test "asum_i_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,3]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Double.Array.[rows*cols]
            let mutable expected = 0.0
            for i = 0 to rows-1 do
                expected <- expected + abs x.[i*cols+ini]
            Blas.asum(rows, x, ini, cols) |> Check.close High expected
        }

        test "asum_i_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,3]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Single.Array.[rows*cols]
            let mutable expected = 0.0f
            for i = 0 to rows-1 do
                expected <- expected + abs x.[i*cols+ini]
            Blas.asum(rows, x, ini, cols) |> Check.close High expected
        }

        test "axpy_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! a = Gen.Double
            let! x = Gen.Double.Array.[rows]
            let! y = Gen.Double.Array.[rows]
            let expected = Array.map2 (fun x y -> a*x + y) x y
            Blas.axpy(a,x,y)
            Check.close High expected y
        }

        test "axpy_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! a = Gen.Single
            let! x = Gen.Single.NonNegative.Array.[rows]
            let! y = Gen.Single.NonNegative.Array.[rows]
            let expected = Array.map2 (fun x y -> a*x + y) x y
            Blas.axpy(a,x,y)
            Check.close Low expected y
        }

        test "axpy_i_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,3]
            let! ini = Gen.Int.[0,cols-1]
            let! a = Gen.Double
            let! x = Gen.Double.Array.[rows*cols]
            let! y = Gen.Double.Array.[rows*cols]
            let expected = Array.init rows (fun r -> a*x.[r*cols+ini] + y.[r*cols+ini])
            Blas.axpy(rows,a,x,ini,cols,y,ini,cols)
            for i = 0 to rows-1 do
                Check.close High expected.[i] y.[i*cols+ini]
        }

        test "axpy_i_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,3]
            let! ini = Gen.Int.[0,cols-1]
            let! a = Gen.Single
            let! x = Gen.Single.NonNegative.Array.[rows*cols]
            let! y = Gen.Single.NonNegative.Array.[rows*cols]
            let expected = Array.init rows (fun r -> a*x.[r*cols+ini] + y.[r*cols+ini])
            Blas.axpy(rows,a,x,ini,cols,y,ini,cols)
            for i = 0 to rows-1 do
                Check.close Low expected.[i] y.[i*cols+ini]
        }

        test "copy_double" {
            let! x = Gen.Double.Array.[1,ROWS_MAX]
            let y = Array.zeroCreate x.Length
            Blas.copy(x,y)
            Check.equal x y
        }

        test "copy_single" {
            let! x = Gen.Single.Array.[1,ROWS_MAX]
            let y = Array.zeroCreate x.Length
            Blas.copy(x,y)
            Check.equal x y
        }

        test "copy_i_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,3]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Double.Array.[rows*cols]
            let y = Array.zeroCreate x.Length
            Blas.copy(rows,x,ini,cols,y,ini,cols)
            for i = 0 to rows-1 do
                Check.equal x.[i*cols+ini] y.[i*cols+ini]
        }

        test "copy_i_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,3]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Single.Array.[rows*cols]
            let y = Array.zeroCreate x.Length
            Blas.copy(rows,x,ini,cols,y,ini,cols)
            for i = 0 to rows-1 do
                Check.equal x.[i*cols+ini] y.[i*cols+ini]
        }

        test "dot_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! x = Gen.Double.NonNegative.Array.[rows]
            let! y = Gen.Double.NonNegative.Array.[rows]
            let expected = Array.fold2 (fun s x y -> s + x*y) 0.0 x y
            Blas.dot(x,y)
            |> Check.close High expected
        }

        test "dot_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! x = Gen.Single.NonNegative.Array.[rows]
            let! y = Gen.Single.NonNegative.Array.[rows]
            let expected = Array.fold2 (fun s x y -> s + x*y) 0.0f x y
            Blas.dot(x,y)
            |> Check.close High expected
        }

        test "dot_i_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,3]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Double.NonNegative.Array.[rows*cols]
            let! y = Gen.Double.NonNegative.Array.[rows*cols]
            let mutable expected = 0.0
            for i = 0 to rows-1 do
                expected <- expected + x.[i*cols+ini]*y.[i*cols+ini]
            Blas.dot(rows,x,ini,cols,y,ini,cols)
            |> Check.close High expected
        }

        test "dot_i_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,3]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Single.NonNegative.Array.[rows*cols]
            let! y = Gen.Single.NonNegative.Array.[rows*cols]
            let mutable expected = 0.0f
            for i = 0 to rows-1 do
                expected <- expected + x.[i*cols+ini]*y.[i*cols+ini]
            Blas.dot(rows,x,ini,cols,y,ini,cols)
            |> Check.close High expected
        }

        test "sdot" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! x = Gen.Single.NonNegative.Array.[rows]
            let! y = Gen.Single.NonNegative.Array.[rows]
            let expected = Array.fold2 (fun s x y -> s + double x * double y) 0.0 x y
            Blas.sdot(x,y)
            |> Check.close High expected
        }

        test "sdot_sb" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! sb = Gen.Single.NonNegative
            let! x = Gen.Single.NonNegative.Array.[rows]
            let! y = Gen.Single.NonNegative.Array.[rows]
            let expected = Array.fold2 (fun s x y -> s + double x * double y) (double sb) x y
            Blas.sdot(sb,x,y)
            |> Check.close High (single expected)
        }

        test "sdot_i" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,3]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Single.NonNegative.Array.[rows*cols]
            let! y = Gen.Single.NonNegative.Array.[rows*cols]
            let mutable expected = 0.0
            for i = 0 to rows-1 do
                expected <- expected + double x.[i*cols+ini] * double y.[i*cols+ini]
            Blas.sdot(rows,x,ini,cols,y,ini,cols)
            |> Check.close High expected
        }

        test "sdot_sb_i" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,3]
            let! ini = Gen.Int.[0,cols-1]
            let! sb = Gen.Single.NonNegative
            let! x = Gen.Single.NonNegative.Array.[rows*cols]
            let! y = Gen.Single.NonNegative.Array.[rows*cols]
            let mutable expected = double sb
            for i = 0 to rows-1 do
                expected <- expected + (double x.[i*cols+ini] * double y.[i*cols+ini])
            Blas.sdot(rows,sb,x,ini,cols,y,ini,cols)
            |> Check.close High (single expected)
        }

        test "nrm2_double" {
            let! x = Gen.Double.Array.[1,ROWS_MAX]
            let expected = Array.sumBy (fun x -> x * x) x |> sqrt
            Blas.nrm2 x |> Check.close High expected
        }

        test "nrm2_single" {
            let! x = Gen.Single.Array.[1,ROWS_MAX]
            let expected = Array.sumBy (fun x -> x * x) x |> sqrt
            Blas.nrm2 x |> Check.close High expected
        }

        test "nrm2_i_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,3]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Double.Array.[rows*cols]
            let mutable expected = 0.0
            for i = 0 to rows-1 do
                let x = x.[i*cols+ini]
                expected <- expected + x * x
            Blas.nrm2(rows, x, ini, cols) |> Check.close High (sqrt expected)
        }

        test "nrm2_i_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,3]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Single.Array.[rows*cols]
            let mutable expected = 0.0f
            for i = 0 to rows-1 do
                let x = x.[i*cols+ini]
                expected <- expected + x * x
            Blas.nrm2(rows, x, ini, cols) |> Check.close High (sqrt expected)
        }

        test "rot_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! x = Gen.Double.Unit.Array.[rows]
            let! y = Gen.Double.Unit.Array.[rows]
            let! c = Gen.Double.Unit
            let! s = Gen.Double.Unit
            let expectedx = Array.init rows (fun i -> c*x.[i] + s*y.[i])
            let expectedy = Array.init rows (fun i -> c*y.[i] - s*x.[i])
            Blas.rot(x,y,c,s)
            for i = 0 to rows-1 do
                Check.close High expectedx.[i] x.[i]
                Check.close High expectedy.[i] y.[i]
        }

        test "rot_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! x = Gen.Single.Unit.Array.[rows]
            let! y = Gen.Single.Unit.Array.[rows]
            let! c = Gen.Single.Unit
            let! s = Gen.Single.Unit
            let expectedx = Array.init rows (fun i -> c*x.[i] + s*y.[i])
            let expectedy = Array.init rows (fun i -> c*y.[i] - s*x.[i])
            Blas.rot(x,y,c,s)
            for i = 0 to rows-1 do
                Check.close Medium expectedx.[i] x.[i]
                Check.close Medium expectedy.[i] y.[i]
        }

        test "rot_i_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,3]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Double.Unit.Array.[rows*cols]
            let! y = Gen.Double.Unit.Array.[rows*cols]
            let! c = Gen.Double.Unit
            let! s = Gen.Double.Unit
            let expectedx = Array.init rows (fun r -> c*x.[r*cols+ini] + s*y.[r*cols+ini])
            let expectedy = Array.init rows (fun r -> c*y.[r*cols+ini] - s*x.[r*cols+ini])
            Blas.rot(rows,x,ini,cols,y,ini,cols,c,s)
            for i = 0 to rows-1 do
                Check.close High expectedx.[i] x.[i*cols+ini]
                Check.close High expectedy.[i] y.[i*cols+ini]
        }

        test "rot_i_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,3]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Single.Unit.Array.[rows*cols]
            let! y = Gen.Single.Unit.Array.[rows*cols]
            let! c = Gen.Single.Unit
            let! s = Gen.Single.Unit
            let expectedx = Array.init rows (fun r -> c*x.[r*cols+ini] + s*y.[r*cols+ini])
            let expectedy = Array.init rows (fun r -> c*y.[r*cols+ini] - s*x.[r*cols+ini])
            Blas.rot(rows,x,ini,cols,y,ini,cols,c,s)
            for i = 0 to rows-1 do
                Check.close Medium expectedx.[i] x.[i*cols+ini]
                Check.close Medium expectedy.[i] y.[i*cols+ini]
        }

        test "sscal" {
            let x = [| 1.0f; 2.0f; 3.0f |]
            Blas.sscal(3, 2.0f, x, 1)
            Check.equal [| 2.0f; 4.0f; 6.0f |] x
        }

        test "dscal" {
            let x = [| 1.0; 2.0; 3.0 |]
            Blas.dscal(3, 2.0, x, 1)
            Check.equal [| 2.0; 4.0; 6.0 |] x
        }

        test "isamax" {
            Blas.isamax(3, [| 1.0f; 7.0f; -3.0f |], 1)
            |> Check.equal 1
        }

        test "idamax" {
            Blas.idamax(3, [| 1.0; 7.0; -3.0 |], 1)
            |> Check.equal 1
        }

        test "isamin" {
            Blas.isamin(3, [| 1.0f; 7.0f; -3.0f |], 1)
            |> Check.equal 0
        }

        test "idamin" {
            Blas.idamin(3, [| 1.0; 7.0; -3.0 |], 1)
            |> Check.equal 0
        }

        test "sgemv" {
            let y = Array.zeroCreate 3
            Blas.sgemv(Layout.RowMajor, Transpose.No, 3, 3, -2.0f,
                [| 1.0f; 1.0f; 2.0f; 1.0f; 2.0f; 1.0f; 2.0f; 1.0f; 1.0f |], 3,
                [| 3.0f; -1.0f; 2.0f |],
                1, 2.0f, y, 1)
            Check.equal [| -12.0f; -6.0f; -14.0f |] y
        }

        test "dgemv" {
            let y = Array.zeroCreate 3
            Blas.dgemv(Layout.RowMajor, Transpose.No, 3, 3, -2.0,
                [| 1.0; 1.0; 2.0; 1.0; 2.0; 1.0; 2.0; 1.0; 1.0 |], 3,
                [| 3.0; -1.0; 2.0 |],
                1, 2.0, y, 1)
            Check.equal [| -12.0; -6.0; -14.0 |] y
        }

        test "sgemm" {
            let c = Array.zeroCreate 6
            Blas.sgemm(Layout.RowMajor, Transpose.No, Transpose.No, 3, 2, 3, 1.0f,
                [| 8.0f; 4.0f; 2.0f; 1.0f; 3.0f; -6.0f; -7.0f; 0.0f; 5.0f |], 3,
                [| 5.0f; 2.0f; 3.0f; 1.0f; 4.0f; -1.0f |], 2,
                1.0f, c, 2)
            Check.equal [| 60.0f; 18.0f; -10.0f; 11.0f; -15.0f; -19.0f |] c
        }

        test "dgemm" {
            let c = Array.zeroCreate 6
            Blas.dgemm(Layout.RowMajor, Transpose.No, Transpose.No, 3, 2, 3, 1.0,
                [| 8.0; 4.0; 2.0; 1.0; 3.0; -6.0; -7.0; 0.0; 5.0 |], 3,
                [| 5.0; 2.0; 3.0; 1.0; 4.0; -1.0 |], 2,
                1.0, c, 2)
            Check.equal [| 60.0; 18.0; -10.0; 11.0; -15.0; -19.0 |] c
        }
    }