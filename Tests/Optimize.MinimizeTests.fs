module Optimize.MinimizeTests

open MKLNET
open CsCheck

let all =
    test "optimize_minimize" {

        test "minimize_quadratic_correct" {
            let! root1 = Gen.Double.[-10.0, 10.0]
            let! root2 = Gen.Double.[-10.0, 10.0]
            let f x = (x - root1) * (x - root2)
            let! x =
                let genD = Gen.Double.[-20.0, 20.0]
                Gen.Select(genD, genD, genD)
                    .Where(fun struct (a, b, c) -> a < b && b < c)
                    .Select(fun struct (a, b, c) -> a, f(a), b, f(b), c, f(c))
                    .Select(fun (a, fa, b, fb, c, fc) -> Optimize.Minimize_Quadratic(a, fa, b, fb, c, fc))
            Check.close Low ((root1 + root2) * 0.5) x
        }

        test "minimize_quadratic_between" {
            let! a, _, _, _, c, _, x =
                let genD = Gen.Double.[-1e100, 1e100]
                Gen.Select(genD, genD, genD, genD, genD, genD)
                    .Where(fun struct (a, fa, b, fb, c, fc) -> a < b && b < c && Optimize.Minimize_Bracketed(fa, fb, fc))
                    .Select(fun struct (a, fa, b, fb, c, fc) -> a, fa, b, fb, c, fc, Optimize.Minimize_Quadratic(a, fa, b, fb, c, fc))
            Check.between a c x
        }
    }