module DftiTests

open System.Numerics
open MKLNET

let all =
    test "Dfti" {

        test "forward_zero_real" {
            let input = Array.zeroCreate<double> 64
            let output = Dfti.ComputeForward input
            for i = 0 to 63 do
                Check.equal 0.0 input.[i]
                Check.equal 0.0 output.[i].Real
                Check.equal 0.0 output.[i].Imaginary
        }

        test "forward_zero_complex" {
            let input = Array.zeroCreate<Complex> 64
            let output = Dfti.ComputeForward input
            for i = 0 to 63 do
                Check.equal 0.0 input.[i].Real
                Check.equal 0.0 input.[i].Imaginary
                Check.equal 0.0 output.[i].Real
                Check.equal 0.0 output.[i].Imaginary
        }

        test "forward_zero_inplace" {
            let input = Array.zeroCreate<Complex> 64
            Dfti.ComputeForwardInplace input
            for i = 0 to 63 do
                Check.equal 0.0 input.[i].Real
                Check.equal 0.0 input.[i].Imaginary
        }

        test "backward_zero" {
            let input = Array.zeroCreate 64
            let output = Dfti.ComputeBackward input
            for i = 0 to 63 do
                Check.equal 0.0 input.[i].Real
                Check.equal 0.0 input.[i].Imaginary
                Check.equal 0.0 output.[i].Real
                Check.equal 0.0 output.[i].Imaginary
        }

        test "backward_zero_inplace" {
            let input = Array.zeroCreate 64
            Dfti.ComputeBackwardInplace input
            for i = 0 to 63 do
                Check.equal 0.0 input.[i].Real
                Check.equal 0.0 input.[i].Imaginary
        }

        test "forward_one_real" {
            let input = Array.create 64 1.0
            let output = Dfti.ComputeForward input
            for i = 0 to 63 do
                Check.equal 1.0 input.[i]
                Check.equal (if i = 0 then 64.0 else 0.0) output.[i].Real
                Check.equal 0.0 output.[i].Imaginary
        }

        test "forward_one_complex" {
            let input = Array.create 64 (Complex(1.0, 0.0))
            let output = Dfti.ComputeForward input
            for i = 0 to 63 do
                Check.equal 1.0 input.[i].Real
                Check.equal 0.0 input.[i].Imaginary
                Check.equal (if i = 0 then 64.0 else 0.0) output.[i].Real
                Check.equal 0.0 output.[i].Imaginary
        }

        test "forward_one_inplace" {
            let input = Array.create 64 (Complex(1.0, 0.0))
            Dfti.ComputeForwardInplace input
            for i = 0 to 63 do
                Check.equal (if i = 0 then 64.0 else 0.0) input.[i].Real
                Check.equal 0.0 input.[i].Imaginary
        }

        test "backward_one" {
            let input = Array.zeroCreate 64
            input.[0] <- Complex(64.0, 0.0)
            let output = Dfti.ComputeBackward input
            for i = 0 to 63 do
                Check.equal (if i = 0 then 64.0 else 0.0) input.[i].Real
                Check.equal 0.0 input.[i].Imaginary
                Check.equal 1.0 output.[i].Real
                Check.equal 0.0 output.[i].Imaginary
        }

        test "backward_one_inplace" {
            let input = Array.zeroCreate 64
            input.[0] <- Complex(64.0, 0.0)
            Dfti.ComputeBackwardInplace input
            for i = 0 to 63 do
                Check.equal 1.0 input.[i].Real
                Check.equal 0.0 input.[i].Imaginary
        }

        test "forward_alternate_real" {
            let input = Array.init 64 (fun i -> if i &&& 1 = 0 then 1.0 else -1.0)
            let output = Dfti.ComputeForward input
            for i = 0 to 63 do
                Check.equal (if i &&& 1 = 0 then 1.0 else -1.0) input.[i]
                Check.equal (if i = 32 then 64.0 else 0.0) output.[i].Real
                Check.equal 0.0 output.[i].Imaginary
        }

        test "forward_alternate_complex" {
            let input = Array.init 64 (fun i -> Complex((if i &&& 1 = 0 then 1.0 else -1.0), 0.0))
            let output = Dfti.ComputeForward input
            for i = 0 to 63 do
                Check.equal (if i &&& 1 = 0 then 1.0 else -1.0) input.[i].Real
                Check.equal 0.0 input.[i].Imaginary
                Check.equal (if i = 32 then 64.0 else 0.0) output.[i].Real
                Check.equal 0.0 output.[i].Imaginary
        }

        test "forward_alternate_inplace" {
            let input = Array.init 64 (fun i -> Complex((if i &&& 1 = 0 then 1.0 else -1.0), 0.0))
            Dfti.ComputeForwardInplace input
            for i = 0 to 63 do
                Check.equal (if i = 32 then 64.0 else 0.0) input.[i].Real
                Check.equal 0.0 input.[i].Imaginary
        }

        test "backward_alternate" {
            let input = Array.zeroCreate 64
            input.[32] <- Complex(64.0, 0.0)
            let output = Dfti.ComputeBackward input
            for i = 0 to 63 do
                Check.equal (if i = 32 then 64.0 else 0.0) input.[i].Real
                Check.equal 0.0 input.[i].Imaginary
                Check.equal (if i &&& 1 = 0 then 1.0 else -1.0) output.[i].Real
                Check.equal 0.0 output.[i].Imaginary
        }

        test "backward_alternate_inplace" {
            let input = Array.zeroCreate 64
            input.[32] <- Complex(64.0, 0.0)
            Dfti.ComputeBackwardInplace input
            for i = 0 to 63 do
                Check.equal (if i &&& 1 = 0 then 1.0 else -1.0) input.[i].Real
                Check.equal 0.0 input.[i].Imaginary
        }
    }