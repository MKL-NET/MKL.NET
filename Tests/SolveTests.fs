module SolveTests

open System
open System.Threading
open MKLNET
open Microsoft.FSharp.NativeInterop

#nowarn "9"

let all = test "solve" {

    test "quadratic_action_double" {
        let mutable calls = 0
        let F (x:double[]) (Fx:double[]) =
            Interlocked.Increment(&calls) |> ignore
            let a, b = x.[0], x.[1]
            let x, y = 0.0, -1.0
            Fx.[0] <- y - (x-a) * (x-b)
            let x,y = 1.0, 0.0
            Fx.[1] <- y - (x-a) * (x-b)
            let x,y = -1.0, 0.0
            Fx.[2] <- y - (x-a) * (x-b)
        let x = [|-5.0; 8.0|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(Action<_,_> F, x, Fx)
        Check.equal SolveResult.S_NORM_2_LESS_THAN_EPS3 result
        Check.info "x    : %A" x
        Check.info "Fx   : %A" Fx
        Check.info "Calls: %i" calls
    }

    test "quadratic_native_double" {
        let mutable calls = 0
        let F m n (x:nativeptr<double>) (Fx:nativeptr<double>) =
            Interlocked.Increment(&calls) |> ignore
            let a, b = NativePtr.get x 0, NativePtr.get x 1
            let x, y = 0.0, -1.0
            NativePtr.set Fx 0  (y - (x-a) * (x-b))
            let x,y = 1.0, 0.0
            NativePtr.set Fx 1  (y - (x-a) * (x-b))
            let x,y = -1.0, 0.0
            NativePtr.set Fx 2  (y - (x-a) * (x-b))
        let x = [|-5.0; 8.0|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(SolveFn F, x, Fx)
        Check.equal SolveResult.S_NORM_2_LESS_THAN_EPS3 result
        Check.info "x    : %A" x
        Check.info "Fx   : %A" Fx
        Check.info "Calls: %i" calls
    }

    test "quadratic_action_bound_double" {
        let mutable calls = 0
        let F (x:double[]) (Fx:double[]) =
            Interlocked.Increment(&calls) |> ignore
            let a, b = x.[0], x.[1]
            let x, y = 0.0, -1.0
            Fx.[0] <- y - (x-a) * (x-b)
            let x,y = 1.0, 0.0
            Fx.[1] <- y - (x-a) * (x-b)
            let x,y = -1.0, 0.0
            Fx.[2] <- y - (x-a) * (x-b)
        let x = [|-5.0; 8.0|]
        let lower = [|-2.0; -2.0|]
        let upper = [|2.0; 2.0|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(Action<_,_> F, x, lower, upper, Fx)
        Check.equal SolveResult.F_NORM_2_LESS_THAN_EPS1 result
        Check.info "x    : %A" x
        Check.info "Fx   : %A" Fx
        Check.info "Calls: %i" calls
    }

    test "quadratic_native_bound_double" {
        let mutable calls = 0
        let F m n (x:nativeptr<double>) (Fx:nativeptr<double>) =
            Interlocked.Increment(&calls) |> ignore
            let a, b = NativePtr.get x 0, NativePtr.get x 1
            let x, y = 0.0, -1.0
            NativePtr.set Fx 0  (y - (x-a) * (x-b))
            let x,y = 1.0, 0.0
            NativePtr.set Fx 1  (y - (x-a) * (x-b))
            let x,y = -1.0, 0.0
            NativePtr.set Fx 2  (y - (x-a) * (x-b))
        let x = [|-5.0; 8.0|]
        let lower = [|-2.0; -2.0|]
        let upper = [|2.0; 2.0|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(SolveFn F, x, lower, upper, Fx)
        Check.equal SolveResult.F_NORM_2_LESS_THAN_EPS1 result
        Check.info "x    : %A" x
        Check.info "Fx   : %A" Fx
        Check.info "Calls: %i" calls
    }

    test "quadratic_action_single" {
        let mutable calls = 0
        let F (x:single[]) (Fx:single[]) =
            Interlocked.Increment(&calls) |> ignore
            let a, b = x.[0], x.[1]
            let x, y = 0.0f, -1.0f
            Fx.[0] <- y - (x-a) * (x-b)
            let x,y = 1.0f, 0.0f
            Fx.[1] <- y - (x-a) * (x-b)
            let x,y = -1.0f, 0.0f
            Fx.[2] <- y - (x-a) * (x-b)
        let x = [|-5.0f; 8.0f|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(Action<_,_> F, x, Fx)
        Check.equal SolveResult.F_NORM_2_LESS_THAN_EPS1 result
        Check.info "x    : %A" x
        Check.info "Fx   : %A" Fx
        Check.info "Calls: %i" calls
    }

    test "quadratic_native_single" {
        let mutable calls = 0
        let F m n (x:nativeptr<single>) (Fx:nativeptr<single>) =
            Interlocked.Increment(&calls) |> ignore
            let a, b = NativePtr.get x 0, NativePtr.get x 1
            let x, y = 0.0f, -1.0f
            NativePtr.set Fx 0  (y - (x-a) * (x-b))
            let x,y = 1.0f, 0.0f
            NativePtr.set Fx 1  (y - (x-a) * (x-b))
            let x,y = -1.0f, 0.0f
            NativePtr.set Fx 2  (y - (x-a) * (x-b))
        let x = [|-5.0f; 8.0f|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(SolveFnF F, x, Fx)
        Check.equal SolveResult.F_NORM_2_LESS_THAN_EPS1 result
        Check.info "x    : %A" x
        Check.info "Fx   : %A" Fx
        Check.info "Calls: %i" calls
    }

    test "quadratic_action_bound_single" {
        let mutable calls = 0
        let F (x:single[]) (Fx:single[]) =
            Interlocked.Increment(&calls) |> ignore
            let a, b = x.[0], x.[1]
            let x, y = 0.0f, -1.0f
            Fx.[0] <- y - (x-a) * (x-b)
            let x,y = 1.0f, 0.0f
            Fx.[1] <- y - (x-a) * (x-b)
            let x,y = -1.0f, 0.0f
            Fx.[2] <- y - (x-a) * (x-b)
        let x = [|-5.0f; 8.0f|]
        let lower = [|-2.0f; -2.0f|]
        let upper = [|2.0f; 2.0f|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(Action<_,_> F, x, lower, upper, Fx)
        Check.equal SolveResult.F_NORM_2_LESS_THAN_EPS1 result
        Check.info "x    : %A" x
        Check.info "Fx   : %A" Fx
        Check.info "Calls: %i" calls
    }

    test "quadratic_native_bound_single" {
        let mutable calls = 0
        let F m n (x:nativeptr<single>) (Fx:nativeptr<single>) =
            Interlocked.Increment(&calls) |> ignore
            let a, b = NativePtr.get x 0, NativePtr.get x 1
            let x, y = 0.0f, -1.0f
            NativePtr.set Fx 0  (y - (x-a) * (x-b))
            let x,y = 1.0f, 0.0f
            NativePtr.set Fx 1  (y - (x-a) * (x-b))
            let x,y = -1.0f, 0.0f
            NativePtr.set Fx 2  (y - (x-a) * (x-b))
        let x = [|-5.0f; 8.0f|]
        let lower = [|-2.0f; -2.0f|]
        let upper = [|2.0f; 2.0f|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(SolveFnF F, x, lower, upper, Fx)
        Check.equal SolveResult.F_NORM_2_LESS_THAN_EPS1 result
        Check.info "x    : %A" x
        Check.info "Fx   : %A" Fx
        Check.info "Calls: %i" calls
    }
}