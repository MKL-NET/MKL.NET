module VslTests

open System
open System.Threading
open MKLNET

let semaphore = new SemaphoreSlim(1, 1)

let all =
    test "Vsl" {

        test "stream" {
            semaphore.Wait()
            let mutable stream = IntPtr.Zero
            Vsl.NewStream(&stream, 3145728, 77u) |> Check.equal 0
            let r = Array.zeroCreate 3
            Vsl.dRngGaussian(2, stream, 5, r, 0.0, 1.0) |> Check.equal 0
            Vsl.DeleteStream(&stream) |> Check.equal 0
            let expected = [| 2.197108196; 0.1405333963; -0.4023745985 |]
            Check.close Accuracy.high expected r
            semaphore.Release() |> ignore
        }
    }