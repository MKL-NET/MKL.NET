module SolveTests

open System
open System.Threading
open MKLNET
open Microsoft.FSharp.NativeInterop

#nowarn "9"

let all = test "solve" {

    let checkIsValid (r:SolveResult) =
         ( r = SolveResult.S_NORM_2_LESS_THAN_EPS3
        || r = SolveResult.F_NORM_2_LESS_THAN_EPS1)
        |> Check.isTrue

    test "quadratic_action_double" {
        let mutable calls = 0
        let F (x:double[]) (Fx:double[]) =
            Interlocked.Increment(&calls) |> ignore
            let a, b = x.[0], x.[1]
            let x, y = 0.0, -1.0
            Fx.[0] <- y - (x-a) * (x-b)
            let x, y = 1.0, 0.0
            Fx.[1] <- y - (x-a) * (x-b)
            let x, y = -1.0, 0.0
            Fx.[2] <- y - (x-a) * (x-b)
        let x = [|-5.0; 8.0|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(Action<_,_> F, x, Fx)
        checkIsValid result
        Check.close High -1.0 x.[0]
        Check.close High 1.0 x.[1]
        let nonJCalls = calls

        calls <- 0
        let J (x:double[]) (J:double[]) =
            Interlocked.Increment(&calls) |> ignore
            let a, b = x.[0], x.[1]
            let x = 0.0
            J.[0] <- x - b
            let x = 1.0
            J.[1] <- x - b
            let x = -1.0
            J.[2] <- x - b
            let x = 0.0
            J.[3] <- x - a
            let x = 1.0
            J.[4] <- x - a
            let x = -1.0
            J.[5] <- x - a
        let x = [|-5.0; 8.0|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(Action<_,_> F, Action<_,_> J, x, Fx)
        checkIsValid result
        Check.close High -1.0 x.[0]
        Check.close High 1.0 x.[1]
        Check.greaterThan calls nonJCalls
        Check.info "Non J calls = %i" nonJCalls
        Check.info "J calls = %i" calls
    }

    test "quadratic_native_double" {
        let mutable calls = 0
        let F m n (x:nativeptr<double>) (Fx:nativeptr<double>) =
            Interlocked.Increment(&calls) |> ignore
            let a, b = NativePtr.get x 0, NativePtr.get x 1
            let x, y = 0.0, -1.0
            NativePtr.set Fx 0  (y - (x-a) * (x-b))
            let x, y = 1.0, 0.0
            NativePtr.set Fx 1  (y - (x-a) * (x-b))
            let x, y = -1.0, 0.0
            NativePtr.set Fx 2  (y - (x-a) * (x-b))
        let x = [|-5.0; 8.0|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(SolveFn F, x, Fx)
        checkIsValid result
        Check.close High -1.0 x.[0]
        Check.close High 1.0 x.[1]
        let nonJCalls = calls

        calls <- 0
        let J (x:double[]) (J:double[]) =
            Interlocked.Increment(&calls) |> ignore
            let a, b = x.[0], x.[1]
            let x = 0.0
            J.[0] <- x - b
            let x = 1.0
            J.[1] <- x - b
            let x = -1.0
            J.[2] <- x - b
            let x = 0.0
            J.[3] <- x - a
            let x = 1.0
            J.[4] <- x - a
            let x = -1.0
            J.[5] <- x - a
        let x = [|-5.0; 8.0|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(SolveFn F, Action<_,_> J, x, Fx)
        checkIsValid result
        Check.close High -1.0 x.[0]
        Check.close High 1.0 x.[1]
        Check.greaterThan calls nonJCalls
        Check.info "Non J calls = %i" nonJCalls
        Check.info "J calls = %i" calls
    }

    test "quadratic_action_bound_double" {
        let mutable calls = 0
        let F (x:double[]) (Fx:double[]) =
            Interlocked.Increment(&calls) |> ignore
            let a, b = x.[0], x.[1]
            let x, y = 0.0, -1.0
            Fx.[0] <- y - (x-a) * (x-b)
            let x, y = 1.0, 0.0
            Fx.[1] <- y - (x-a) * (x-b)
            let x, y = -1.0, 0.0
            Fx.[2] <- y - (x-a) * (x-b)
        let x = [|-1.9; 1.9|]
        let lower = [|-2.0; -2.0|]
        let upper = [|2.0; 2.0|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(Action<_,_> F, x, lower, upper, Fx)
        checkIsValid result
        Check.close High -1.0 x.[0]
        Check.close High 1.0 x.[1]
        let nonJCalls = calls

        calls <- 0
        let J (x:double[]) (J:double[]) =
            Interlocked.Increment(&calls) |> ignore
            let a, b = x.[0], x.[1]
            let x = 0.0
            J.[0] <- x - b
            let x = 1.0
            J.[1] <- x - b
            let x = -1.0
            J.[2] <- x - b
            let x = 0.0
            J.[3] <- x - a
            let x = 1.0
            J.[4] <- x - a
            let x = -1.0
            J.[5] <- x - a
        let x = [|-1.9; 1.9|]
        let lower = [|-2.0; -2.0|]
        let upper = [|2.0; 2.0|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(Action<_,_> F, Action<_,_> J, x, lower, upper, Fx)
        checkIsValid result
        Check.close High -1.0 x.[0]
        Check.close High 1.0 x.[1]
        Check.greaterThan calls nonJCalls
        Check.info "Non J calls = %i" nonJCalls
        Check.info "J calls = %i" calls
    }

    test "quadratic_native_bound_double" {
        let mutable calls = 0
        let F m n (x:nativeptr<double>) (Fx:nativeptr<double>) =
            Interlocked.Increment(&calls) |> ignore
            let a, b = NativePtr.get x 0, NativePtr.get x 1
            let x, y = 0.0, -1.0
            NativePtr.set Fx 0  (y - (x-a) * (x-b))
            let x, y = 1.0, 0.0
            NativePtr.set Fx 1  (y - (x-a) * (x-b))
            let x, y = -1.0, 0.0
            NativePtr.set Fx 2  (y - (x-a) * (x-b))
        let x = [|-1.9; 1.9|]
        let lower = [|-2.0; -2.0|]
        let upper = [|2.0; 2.0|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(SolveFn F, x, lower, upper, Fx)
        checkIsValid result
        Check.close High -1.0 x.[0]
        Check.close High 1.0 x.[1]
        let nonJCalls = calls

        calls <- 0
        let J (x:double[]) (J:double[]) =
            Interlocked.Increment(&calls) |> ignore
            let a, b = x.[0], x.[1]
            let x = 0.0
            J.[0] <- x - b
            let x = 1.0
            J.[1] <- x - b
            let x = -1.0
            J.[2] <- x - b
            let x = 0.0
            J.[3] <- x - a
            let x = 1.0
            J.[4] <- x - a
            let x = -1.0
            J.[5] <- x - a
        let x = [|-1.9; 1.9|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(SolveFn F, Action<_,_> J, x, lower, upper, Fx)
        checkIsValid result
        Check.close High -1.0 x.[0]
        Check.close High 1.0 x.[1]
        Check.greaterThan calls nonJCalls
        Check.info "Non J calls = %i" nonJCalls
        Check.info "J calls = %i" calls
    }

    test "quadratic_action_single" {
        let mutable calls = 0
        let F (x:single[]) (Fx:single[]) =
            Interlocked.Increment(&calls) |> ignore
            let a, b = x.[0], x.[1]
            let x, y = 0.0f, -1.0f
            Fx.[0] <- y - (x-a) * (x-b)
            let x, y = 1.0f, 0.0f
            Fx.[1] <- y - (x-a) * (x-b)
            let x, y = -1.0f, 0.0f
            Fx.[2] <- y - (x-a) * (x-b)
        let x = [|-5.0f; 8.0f|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(Action<_,_> F, x, Fx)
        checkIsValid result
        Check.close High -1.0f x.[0]
        Check.close High 1.0f x.[1]
        let nonJCalls = calls
        
        calls <- 0
        let J (x:single[]) (J:single[]) =
            Interlocked.Increment(&calls) |> ignore
            let a, b = x.[0], x.[1]
            let x = 0.0f
            J.[0] <- x - b
            let x = 1.0f
            J.[1] <- x - b
            let x = -1.0f
            J.[2] <- x - b
            let x = 0.0f
            J.[3] <- x - a
            let x = 1.0f
            J.[4] <- x - a
            let x = -1.0f
            J.[5] <- x - a
        let x = [|-5.0f; 8.0f|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(Action<_,_> F, Action<_,_> J, x, Fx)
        checkIsValid result
        Check.close High -1.0f x.[0]
        Check.close High 1.0f x.[1]
        Check.greaterThan calls nonJCalls
        Check.info "Non J calls = %i" nonJCalls
        Check.info "J calls = %i" calls
    }

    test "quadratic_native_single" {
        let mutable calls = 0
        let F m n (x:nativeptr<single>) (Fx:nativeptr<single>) =
            Interlocked.Increment(&calls) |> ignore
            let a, b = NativePtr.get x 0, NativePtr.get x 1
            let x, y = 0.0f, -1.0f
            NativePtr.set Fx 0  (y - (x-a) * (x-b))
            let x, y = 1.0f, 0.0f
            NativePtr.set Fx 1  (y - (x-a) * (x-b))
            let x, y = -1.0f, 0.0f
            NativePtr.set Fx 2  (y - (x-a) * (x-b))
        let x = [|-5.0f; 8.0f|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(SolveFnF F, x, Fx)
        checkIsValid result
        Check.close High -1.0f x.[0]
        Check.close High 1.0f x.[1]
        let nonJCalls = calls
        
        calls <- 0
        let J (x:single[]) (J:single[]) =
            Interlocked.Increment(&calls) |> ignore
            let a, b = x.[0], x.[1]
            let x = 0.0f
            J.[0] <- x - b
            let x = 1.0f
            J.[1] <- x - b
            let x = -1.0f
            J.[2] <- x - b
            let x = 0.0f
            J.[3] <- x - a
            let x = 1.0f
            J.[4] <- x - a
            let x = -1.0f
            J.[5] <- x - a
        let x = [|-5.0f; 8.0f|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(SolveFnF F, Action<_,_> J, x, Fx)
        checkIsValid result
        Check.close High -1.0f x.[0]
        Check.close High 1.0f x.[1]
        Check.greaterThan calls nonJCalls
        Check.info "Non J calls = %i" nonJCalls
        Check.info "J calls = %i" calls
    }

    test "quadratic_action_bound_single" {
        let mutable calls = 0
        let F (x:single[]) (Fx:single[]) =
            Interlocked.Increment(&calls) |> ignore
            let a, b = x.[0], x.[1]
            let x, y = 0.0f, -1.0f
            Fx.[0] <- y - (x-a) * (x-b)
            let x, y = 1.0f, 0.0f
            Fx.[1] <- y - (x-a) * (x-b)
            let x, y = -1.0f, 0.0f
            Fx.[2] <- y - (x-a) * (x-b)
        let x = [|-5.0f; 8.0f|]
        let lower = [|-2.0f; -2.0f|]
        let upper = [|2.0f; 2.0f|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(Action<_,_> F, x, lower, upper, Fx)
        checkIsValid result
        Check.close High -1.0f x.[0]
        Check.close High 1.0f x.[1]
        let nonJCalls = calls
        
        calls <- 0
        let J (x:single[]) (J:single[]) =
            Interlocked.Increment(&calls) |> ignore
            let a, b = x.[0], x.[1]
            let x = 0.0f
            J.[0] <- x - b
            let x = 1.0f
            J.[1] <- x - b
            let x = -1.0f
            J.[2] <- x - b
            let x = 0.0f
            J.[3] <- x - a
            let x = 1.0f
            J.[4] <- x - a
            let x = -1.0f
            J.[5] <- x - a
        let x = [|-1.9f; 1.9f|]
        let lower = [|-2.0f; -2.0f|]
        let upper = [|2.0f; 2.0f|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(Action<_,_> F, Action<_,_> J, x, lower, upper, Fx)
        checkIsValid result
        Check.close High -1.0f x.[0]
        Check.close High 1.0f x.[1]
        Check.greaterThan calls nonJCalls
        Check.info "Non J calls = %i" nonJCalls
        Check.info "J calls = %i" calls
    }

    test "quadratic_native_bound_single" {
        let mutable calls = 0
        let F m n (x:nativeptr<single>) (Fx:nativeptr<single>) =
            Interlocked.Increment(&calls) |> ignore
            let a, b = NativePtr.get x 0, NativePtr.get x 1
            let x, y = 0.0f, -1.0f
            NativePtr.set Fx 0  (y - (x-a) * (x-b))
            let x, y = 1.0f, 0.0f
            NativePtr.set Fx 1  (y - (x-a) * (x-b))
            let x, y = -1.0f, 0.0f
            NativePtr.set Fx 2  (y - (x-a) * (x-b))
        let x = [|-5.0f; 8.0f|]
        let lower = [|-2.0f; -2.0f|]
        let upper = [|2.0f; 2.0f|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(SolveFnF F, x, lower, upper, Fx)
        checkIsValid result
        Check.close High -1.0f x.[0]
        Check.close High 1.0f x.[1]
        let nonJCalls = calls
        
        calls <- 0
        let J (x:single[]) (J:single[]) =
            Interlocked.Increment(&calls) |> ignore
            let a, b = x.[0], x.[1]
            let x = 0.0f
            J.[0] <- x - b
            let x = 1.0f
            J.[1] <- x - b
            let x = -1.0f
            J.[2] <- x - b
            let x = 0.0f
            J.[3] <- x - a
            let x = 1.0f
            J.[4] <- x - a
            let x = -1.0f
            J.[5] <- x - a
        let x = [|-1.9f; 1.9f|]
        let lower = [|-2.0f; -2.0f|]
        let upper = [|2.0f; 2.0f|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(SolveFnF F, Action<_,_> J, x, lower, upper, Fx)
        checkIsValid result
        Check.close High -1.0f x.[0]
        Check.close High 1.0f x.[1]
        Check.greaterThan calls nonJCalls
        Check.info "Non J calls = %i" nonJCalls
        Check.info "J calls = %i" calls
    }
}