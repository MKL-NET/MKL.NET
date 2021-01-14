module SolveTests

open System
open System.Threading
open MKLNET
open Microsoft.FSharp.NativeInterop

#nowarn "9"

let all = test "rci" {

    test "quadratic_action" {
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
        let eps = Array.create 6 0.00001
        let x = [|-5.0; 8.0|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(Action<_,_> F, x, Fx, eps, 1000, 100, 0.0)
        Check.equal RciStatus.F_NORM_2_LESS_THAN_EPS1 result
        Check.info "x    : %A" x
        Check.info "Fx   : %A" Fx
        Check.info "Calls: %i" calls
    }

    test "quadratic_callback" {
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
        let eps = Array.create 6 0.00001
        let x = [|-5.0; 8.0|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(Solve.djacobi_function F, x, Fx, eps, 1000, 100, 0.0)
        Check.equal RciStatus.F_NORM_2_LESS_THAN_EPS1 result
        Check.info "x    : %A" x
        Check.info "Fx   : %A" Fx
        Check.info "Calls: %i" calls
    }

    test "quadratic_action_bound" {
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
        let eps = Array.create 6 0.00001
        let x = [|-5.0; 8.0|]
        let lower = [|-2.0; -2.0|]
        let upper = [|2.0; 2.0|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(Action<_,_> F, x, lower, upper, Fx, eps, 1000, 100, 0.0)
        Check.equal RciStatus.F_NORM_2_LESS_THAN_EPS1 result
        Check.info "x    : %A" x
        Check.info "Fx   : %A" Fx
        Check.info "Calls: %i" calls
    }

    test "quadratic_callback_bound" {
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
        let eps = Array.create 6 0.00001
        let x = [|-5.0; 8.0|]
        let lower = [|-2.0; -2.0|]
        let upper = [|2.0; 2.0|]
        let Fx = Array.zeroCreate 3
        let result = Solve.NonLinearLeastSquares(Solve.djacobi_function F, x, lower, upper, Fx, eps, 1000, 100, 0.0)
        Check.equal RciStatus.F_NORM_2_LESS_THAN_EPS1 result
        Check.info "x    : %A" x
        Check.info "Fx   : %A" Fx
        Check.info "Calls: %i" calls
    }
}