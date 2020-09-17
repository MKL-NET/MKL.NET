module VslTests

open MKLNET

let all =
    test "Vsl" {

        test "stream" {
            let stream = Vsl.NewStream(VslBrng.MRG32K3A, 77u)
            let r = Array.zeroCreate 3
            Vsl.RngGaussian(VslMethodGaussian.ICDF, stream, r.Length, r, 0.0, 1.0)
            |> Check.equal 0
            Vsl.DeleteStream(stream) |> Check.equal 0
            let expected = [| 2.197108196; 0.1405333963; -0.4023745985 |]
            Check.close High expected r
        }
    }