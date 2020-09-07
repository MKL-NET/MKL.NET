module BlasTests

open MKLNET

let all =
    test "Blas" {

        test "sasum" {
            Blas.sasum(3, [| 1.0f; 0.1f; 0.01f |], 1)
            |> Check.equal 1.11f
        }

        test "dasum" {
            Blas.dasum(3, [| 1.0; 0.1; 0.01 |], 1)
            |> Check.equal 1.11
        }

        test "saxpy" {
            let y = [| 1.0f; 1.0f; 1.0f |]
            Blas.saxpy(3, 2.0f, [| 1.0f; 1.0f; 1.0f |], 1, y, 1)
            Check.equal [| 3.0f; 3.0f; 3.0f |] y
        }

        test "daxpy" {
            let y = [| 1.0; 1.0; 1.0 |]
            Blas.daxpy(3, 2.0, [| 1.0; 1.0; 1.0 |], 1, y, 1)
            Check.equal [| 3.0; 3.0; 3.0 |] y
        }

        test "scopy" {
            let x = [| 1.0f; -1.0f; 0.0f |]
            let y = Array.zeroCreate 3
            Blas.scopy(3, x, 1 , y, 1)
            Check.equal x y
        }

        test "dcopy" {
            let x = [| 1.0; -1.0; 0.0 |]
            let y = Array.zeroCreate 3
            Blas.dcopy(3, x, 1 , y, 1)
            Check.equal x y
        }

        test "sdot" {
            Blas.sdot(3,
                [| 1.0f; 2.0f; 3.0f |], 1,
                [| 4.0f; 5.0f; 6.0f ;|], 1)
            |> Check.equal 32.0f
        }

        test "ddot" {
            Blas.ddot(3,
                [| 1.0; 2.0; 3.0 |], 1,
                [| 4.0; 5.0; 6.0 ;|], 1)
            |> Check.equal 32.0
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