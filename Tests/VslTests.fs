module VslTests

open System
open MKLNET

let all =
    test "Vls" {

        test "stream" {
            let stream = ref (IntPtr())
            Vsl.NewStream(stream, 3145728, 77u) |> Check.equal 0
            let r = Array.zeroCreate 3
            Vsl.dRngGaussian(2, !stream, 5, r, 0.0, 1.0) |> Check.equal 0
            Vsl.DeleteStream(stream) |> Check.equal 0
            let expected = [| 2.197108196; 0.1405333963; -0.4023745985 |]
            Check.close Accuracy.high expected r
        }
    }