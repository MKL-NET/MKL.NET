module LapackTests

open MKLNET

let all =
    test "Lapack" {
        test "dpotrf" {
            let a = [|
                 4.0;   0.0;   0.0;
                 6.0;  25.0;   0.0;
                10.0;  39.0; 110.0;
            |]
            let expected = [|
                 2.0;   0.0;   0.0;
                 3.0;   4.0;   0.0;
                 5.0;   6.0;   7.0;
            |]
            let info = Lapack.dpotrf(Order.RowMajor, UpLo.Lower, 3, a, 3);
            Check.equal info 0
            for i = 0 to a.Length - 1 do
                Check.equal a.[i] expected.[i]
        }
    }