module VmlTests

open MKLNET

let all =
    test "Vml" {

        test "Add" {
            let r = Array.zeroCreate 3
            Vml.Add(3,
                [| 1.0; 2.0; 3.0 |],
                [| 4.0; 5.0; 6.0 |],
                r
                )
            Check.equal [| 5.0; 7.0; 9.0 |] r
        }
    }