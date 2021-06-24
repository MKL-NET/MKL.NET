module Optimize.RootTests

open System
open MKLNET
open CsCheck

let all =
    test "optimize_root" {

        test "Root_Bound" {
            let fa = 1e-162
            let fb = -1e-162
            Check.isTrue (Optimize.Root_Bound(fa, fb))
            let Root_Bound_Bad fa fb = fa * fb < 0.0
            Check.isFalse (Root_Bound_Bad fa fb)
            let! fa = Gen.Double.[Double.Epsilon, 100.0]
            let! fb = Gen.Double.[-100.0, -Double.Epsilon]
            Check.isTrue (Optimize.Root_Bound(fa, fb))
            Check.isTrue (Optimize.Root_Bound(fb, fa))
            Check.isFalse (Optimize.Root_Bound(fa, -fb))
            Check.isFalse (Optimize.Root_Bound(-fa, fb))
        }

        test "Root_Linear_Bound" {
            let genD = Gen.Double.[-10_000.0, 10_000.0]
            let! a, _, b, _, x =
                Gen.Select(genD, genD, genD, genD)
                    .Where(fun struct (a, fa, b, fb) -> a < b && Optimize.Root_Bound(fa, fb))
                    .Select(fun struct (a, fa, b, fb) -> a, fa, b, fb, Optimize.Root_Linear(a, fa, b, fb))
            Check.greaterThanOrEqual a x
            Check.greaterThanOrEqual x b
        }

        test "Root_Quadratic_Increasing" {
            let f x = x * x - 100.0
            Optimize.Root_Quadratic(9.4, f(9.4), 11.7, f(11.7), 20.11, f(20.11)) |> Check.equal 10.0
        }

        test "Root_Quadratic_Decreasing" {
            let f x = x * x - 100.0
            Optimize.Root_Quadratic(-11.0, f(-11.0), -8.7, f(-8.7), -20.0, f(-20.0)) |> Check.equal -10.0
        }

        test "QuadraticRoot_Bound" {
            let genD = Gen.Double.[-10_000.0, 10_000.0]
            let! a, _, b, _, _, _, x =
                Gen.Select(genD, genD, genD, genD, genD, genD)
                    .Where(fun struct (a, fa, b, fb, c, _) -> a < b && (c < a || c > b) && Optimize.Root_Bound(fa, fb))
                    .Select(fun struct (a, fa, b, fb, c, fc) -> a, fa, b, fb, c, fc, Optimize.Root_Quadratic(a, fa, b, fb, c, fc))
            Check.greaterThanOrEqual a x
            Check.greaterThanOrEqual x b
        }
    }