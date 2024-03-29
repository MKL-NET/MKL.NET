﻿module DftiTests

open System.Numerics
open MKLNET

let all =
    test "Dfti" {

        let checkStatus status =
            Check.isTrue (status = 0L || Dfti.ErrorClass(status, DftiErrorClass.NO_ERROR) <> 0L)
            |> Check.message "status = %i" status

        test "forward_zero_real" {
            let input = Array.zeroCreate<double> 64
            let output = Array.create 64 (Complex(-7.0,-2.0))
            Dfti.ComputeForward(input, output) |> checkStatus
            for i = 0 to 63 do
                Check.equal 0.0 input[i]
                Check.equal 0.0 output[i].Real
                Check.equal 0.0 output[i].Imaginary
        }

        test "forward_zero_complex" {
            let input = Array.zeroCreate<Complex> 64
            let output = Array.create 64 (Complex(-7.0,-2.0))
            Dfti.ComputeForward(input, output) |> checkStatus
            for i = 0 to 63 do
                Check.equal 0.0 input[i].Real
                Check.equal 0.0 input[i].Imaginary
                Check.equal 0.0 output[i].Real
                Check.equal 0.0 output[i].Imaginary
        }

        test "forward_zero_inplace" {
            let input = Array.zeroCreate<Complex> 64
            Dfti.ComputeForward input |> checkStatus
            for i = 0 to 63 do
                Check.equal 0.0 input[i].Real
                Check.equal 0.0 input[i].Imaginary
        }

        test "backward_zero" {
            let input = Array.zeroCreate 64
            let output = Array.create 64 (Complex(-7.0,-2.0))
            Dfti.ComputeBackward(input, output) |> checkStatus
            for i = 0 to 63 do
                Check.equal 0.0 input[i].Real
                Check.equal 0.0 input[i].Imaginary
                Check.equal 0.0 output[i].Real
                Check.equal 0.0 output[i].Imaginary
        }

        test "backward_zero_inplace" {
            let input = Array.zeroCreate 64
            Dfti.ComputeBackward input |> checkStatus
            for i = 0 to 63 do
                Check.equal 0.0 input[i].Real
                Check.equal 0.0 input[i].Imaginary
        }

        test "forward_one_real" {
            let input = Array.create 64 1.0
            let output = Array.create 64 (Complex(-7.0,-2.0))
            Dfti.ComputeForward(input, output) |> checkStatus
            for i = 0 to 63 do
                Check.equal 1.0 input[i]
                Check.equal (if i = 0 then 64.0 else 0.0) output[i].Real
                Check.equal 0.0 output[i].Imaginary
        }

        test "forward_one_real_scale" {
            let input = Array.create 64 1.0
            let output = Array.create 64 (Complex(-7.0,-2.0))
            Dfti.ComputeForward(input, output, 1.0 / 64.0) |> checkStatus
            for i = 0 to 63 do
                Check.equal 1.0 input[i]
                Check.equal (if i = 0 then 1.0 else 0.0) output[i].Real
                Check.equal 0.0 output[i].Imaginary
        }

        test "forward_one_complex" {
            let input = Array.create 64 (Complex(1.0, 0.0))
            let output = Array.create 64 (Complex(-7.0,-2.0))
            Dfti.ComputeForward(input, output) |> checkStatus
            for i = 0 to 63 do
                Check.equal 1.0 input[i].Real
                Check.equal 0.0 input[i].Imaginary
                Check.equal (if i = 0 then 64.0 else 0.0) output[i].Real
                Check.equal 0.0 output[i].Imaginary
        }

        test "forward_one_complex_scale" {
            let input = Array.create 64 (Complex(1.0, 0.0))
            let output = Array.create 64 (Complex(-7.0,-2.0))
            Dfti.ComputeForward(input, output, 1.0 / 64.0) |> checkStatus
            for i = 0 to 63 do
                Check.equal 1.0 input[i].Real
                Check.equal 0.0 input[i].Imaginary
                Check.equal (if i = 0 then 1.0 else 0.0) output[i].Real
                Check.equal 0.0 output[i].Imaginary
        }

        test "forward_one_inplace" {
            let input = Array.create 64 (Complex(1.0, 0.0))
            Dfti.ComputeForward input |> checkStatus
            for i = 0 to 63 do
                Check.equal (if i = 0 then 64.0 else 0.0) input[i].Real
                Check.equal 0.0 input[i].Imaginary
        }

        test "forward_one_inplace_scale" {
            let input = Array.create 64 (Complex(1.0, 0.0))
            Dfti.ComputeForward(input, 1.0 / 64.0) |> checkStatus
            for i = 0 to 63 do
                Check.equal (if i = 0 then 1.0 else 0.0) input[i].Real
                Check.equal 0.0 input[i].Imaginary
        }

        test "backward_one" {
            let input = Array.zeroCreate 64
            input[0] <- Complex(64.0, 0.0)
            let output = Array.create 64 (Complex(-7.0,-2.0))
            Dfti.ComputeBackward(input, output) |> checkStatus
            for i = 0 to 63 do
                Check.equal (if i = 0 then 64.0 else 0.0) input[i].Real
                Check.equal 0.0 input[i].Imaginary
                Check.equal 64.0 output[i].Real
                Check.equal 0.0 output[i].Imaginary
        }

        test "backward_one_scale" {
            let input = Array.zeroCreate 64
            let output = Array.create 64 (Complex(-7.0,-2.0))
            input[0] <- Complex(64.0, 0.0)
            Dfti.ComputeBackward(input, output, 1.0 / float(input.Length)) |> checkStatus
            for i = 0 to 63 do
                Check.equal (if i = 0 then 64.0 else 0.0) input[i].Real
                Check.equal 0.0 input[i].Imaginary
                Check.equal 1.0 output[i].Real
                Check.equal 0.0 output[i].Imaginary
        }

        test "backward_one_inplace" {
            let input = Array.zeroCreate 64
            input[0] <- Complex(64.0, 0.0)
            Dfti.ComputeBackward(input) |> checkStatus
            for i = 0 to 63 do
                Check.equal 64.0 input[i].Real
                Check.equal 0.0 input[i].Imaginary
        }

        test "backward_one_inplace_scale" {
            let input = Array.zeroCreate 64
            input[0] <- Complex(64.0, 0.0)
            Dfti.ComputeBackward(input, 1.0 / float(input.Length)) |> checkStatus
            for i = 0 to 63 do
                Check.equal 1.0 input[i].Real
                Check.equal 0.0 input[i].Imaginary
        }

        test "forward_alternate_real" {
            let input = Array.init 64 (fun i -> if i &&& 1 = 0 then 1.0 else -1.0)
            let output = Array.create 64 (Complex(-7.0,-2.0))
            Dfti.ComputeForward(input, output) |> checkStatus
            for i = 0 to 63 do
                Check.equal (if i &&& 1 = 0 then 1.0 else -1.0) input[i]
                Check.equal (if i = 32 then 64.0 else 0.0) output[i].Real
                Check.equal 0.0 output[i].Imaginary
        }

        test "forward_alternate_real_scale" {
            let input = Array.init 64 (fun i -> if i &&& 1 = 0 then 1.0 else -1.0)
            let output = Array.create 64 (Complex(-7.0,-2.0))
            Dfti.ComputeForward(input, output, 1.0 / 64.0) |> checkStatus
            for i = 0 to 63 do
                Check.equal (if i &&& 1 = 0 then 1.0 else -1.0) input[i]
                Check.equal (if i = 32 then 1.0 else 0.0) output[i].Real
                Check.equal 0.0 output[i].Imaginary
        }

        test "forward_alternate_complex" {
            let input = Array.init 64 (fun i -> Complex((if i &&& 1 = 0 then 1.0 else -1.0), 0.0))
            let output = Array.create 64 (Complex(-7.0,-2.0))
            Dfti.ComputeForward(input, output) |> checkStatus
            for i = 0 to 63 do
                Check.equal (if i &&& 1 = 0 then 1.0 else -1.0) input[i].Real
                Check.equal 0.0 input[i].Imaginary
                Check.equal (if i = 32 then 64.0 else 0.0) output[i].Real
                Check.equal 0.0 output[i].Imaginary
        }

        test "forward_alternate_complex_scale" {
            let input = Array.init 64 (fun i -> Complex((if i &&& 1 = 0 then 1.0 else -1.0), 0.0))
            let output = Array.create 64 (Complex(-7.0,-2.0))
            Dfti.ComputeForward(input, output, 1.0 / 64.0) |> checkStatus
            for i = 0 to 63 do
                Check.equal (if i &&& 1 = 0 then 1.0 else -1.0) input[i].Real
                Check.equal 0.0 input[i].Imaginary
                Check.equal (if i = 32 then 1.0 else 0.0) output[i].Real
                Check.equal 0.0 output[i].Imaginary
        }

        test "forward_alternate_inplace" {
            let input = Array.init 64 (fun i -> Complex((if i &&& 1 = 0 then 1.0 else -1.0), 0.0))
            Dfti.ComputeForward input |> checkStatus
            for i = 0 to 63 do
                Check.equal (if i = 32 then 64.0 else 0.0) input[i].Real
                Check.equal 0.0 input[i].Imaginary
        }

        test "forward_alternate_inplace_scale" {
            let input = Array.init 64 (fun i -> Complex((if i &&& 1 = 0 then 1.0 else -1.0), 0.0))
            Dfti.ComputeForward(input, 1.0 / 64.0) |> checkStatus
            for i = 0 to 63 do
                Check.equal (if i = 32 then 1.0 else 0.0) input[i].Real
                Check.equal 0.0 input[i].Imaginary
        }

        test "backward_alternate" {
            let input = Array.zeroCreate 64
            input[32] <- Complex(64.0, 0.0)
            let output = Array.create 64 (Complex(-7.0,-2.0))
            Dfti.ComputeBackward(input, output) |> checkStatus
            for i = 0 to 63 do
                Check.equal (if i = 32 then 64.0 else 0.0) input[i].Real
                Check.equal 0.0 input[i].Imaginary
                Check.equal (if i &&& 1 = 0 then 64.0 else -64.0) output[i].Real
                Check.equal 0.0 output[i].Imaginary
        }

        test "backward_alternate_scale" {
            let input = Array.zeroCreate 64
            input[32] <- Complex(64.0, 0.0)
            let output = Array.create 64 (Complex(-7.0,-2.0))
            Dfti.ComputeBackward(input, output, 1.0 / float(input.Length)) |> checkStatus
            for i = 0 to 63 do
                Check.equal (if i = 32 then 64.0 else 0.0) input[i].Real
                Check.equal 0.0 input[i].Imaginary
                Check.equal (if i &&& 1 = 0 then 1.0 else -1.0) output[i].Real
                Check.equal 0.0 output[i].Imaginary
        }

        test "backward_alternate_inplace" {
            let input = Array.zeroCreate 64
            input[32] <- Complex(64.0, 0.0)
            Dfti.ComputeBackward(input) |> checkStatus
            for i = 0 to 63 do
                Check.equal (if i &&& 1 = 0 then 64.0 else -64.0) input[i].Real
                Check.equal 0.0 input[i].Imaginary
        }

        test "backward_alternate_inplace_scale" {
            let input = Array.zeroCreate 64
            input[32] <- Complex(64.0, 0.0)
            Dfti.ComputeBackward(input, 1.0 / float(input.Length)) |> checkStatus
            for i = 0 to 63 do
                Check.equal (if i &&& 1 = 0 then 1.0 else -1.0) input[i].Real
                Check.equal 0.0 input[i].Imaginary
        }
    }