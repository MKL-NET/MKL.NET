module BlasTests

open MKLNET

let all =
    test "Blas" {
        test "dgemm" {
            let a = [| 8.0; 4.0; 2.0; 1.0; 3.0; -6.0; -7.0; 0.0; 5.0 |]
            let b = [| 5.0; 2.0; 3.0; 1.0; 4.0; -1.0 |]
            let c = Array.zeroCreate 6
            let expected = [| 60.0; 18.0; -10.0; 11.0; -15.0; -19.0 |]
            MKL.Blas.dgemm(Order.RowMajor, Transpose.No, Transpose.No,
                                   3, 2, 3, 1.0, a, 3, b, 2, 1.0, c, 2)
            for i = 0 to c.Length - 1 do
                Test.equal c.[i] expected.[i]
        }
    }