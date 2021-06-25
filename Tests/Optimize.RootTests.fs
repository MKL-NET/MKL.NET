module Optimize.RootTests

open System
open MKLNET
open CsCheck

// temp workaround
let genPositive = Gen.Double.Where(fun i -> not(Double.IsNaN i) && i > 0.0)
let genNegative = Gen.Double.Where(fun i -> not(Double.IsNaN i) && i < 0.0)

let all =
    test "optimize_root" {

        test "Root_Bound" {
            let fa = 1e-162
            let fb = -1e-162
            Check.isTrue (Optimize.Root_Bound(fa, fb))
            let Root_Bound_Bad fa fb = fa * fb < 0.0
            Check.isFalse (Root_Bound_Bad fa fb)
            let! fa = genPositive
            let! fb = genNegative
            Check.isTrue (Optimize.Root_Bound(fa, fb))
            Check.isTrue (Optimize.Root_Bound(fb, fa))
            Check.isFalse (Optimize.Root_Bound(fa, -fb))
            Check.isFalse (Optimize.Root_Bound(-fa, fb))
        }

        test "Root_Linear_Between" {
            let! a, _, b, _, x =
                let genD = Gen.Double
                Gen.Select(genD, genD, genD, genD)
                    .Where(fun struct (a, fa, b, fb) -> a < b && Optimize.Root_Bound(fa, fb))
                    .Select(fun struct (a, fa, b, fb) -> a, fa, b, fb, Optimize.Root_Linear(a, fa, b, fb))
            Check.between a b x
        }

        test "Root_Linear_Correct" {
            let! root = Gen.Double.[1.0, 10.0]
            let f x = x - root
            let! x =
                let genD = Gen.Double.[root * -3.0, root * 3.0]
                Gen.Select(genD, genD)
                    .Select(fun struct (a, b) -> a, f(a), b, f(b))
                    .Where(fun (a, fa, b, fb) -> a < b && Optimize.Root_Bound(fa, fb))
                    .Select(fun (a, fa, b, fb) -> Optimize.Root_Linear(a, fa, b, fb))
            Check.close High root x
        }

        test "Root_Quadratic_Between" {
            let! a, _, b, _, _, _, x =
                let genD = Gen.Double
                Gen.Select(genD, genD, genD, genD, genD, genD)
                    .Where(fun struct (a, fa, b, fb, c, _) -> a < b && (c < a || c > b) && Optimize.Root_Bound(fa, fb))
                    .Select(fun struct (a, fa, b, fb, c, fc) -> a, fa, b, fb, c, fc, Optimize.Root_Quadratic(a, fa, b, fb, c, fc))
            Check.between a b x
        }

        test "Root_Quadratic_Correct" {
            let! root1 = Gen.Double.[-10.0, -1.0]
            let! root2 = Gen.Double.[1.0, 10.0]
            let f x = (x - root1) * (x - root2)
            let! x =
                let genD = Gen.Double.[root1 * 3.0, root2 * 3.0]
                Gen.Select(genD, genD, genD)
                    .Select(fun struct (a, b, c) -> a, f(a), b, f(b), c, f(c))
                    .Where(fun (a, fa, b, fb, c, _) -> a < b && (c < a || c > b) && Optimize.Root_Bound(fa, fb))
                    .Select(fun (a, fa, b, fb, c, fc) -> Optimize.Root_Quadratic(a, fa, b, fb, c, fc))
            Check.close Medium root1 x ||| Check.close Medium root2 x
        }
    }