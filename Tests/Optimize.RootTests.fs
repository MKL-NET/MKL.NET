module Optimize.RootTests

open System
open MKLNET
open CsCheck

// temp workaround
let genPositive = Gen.Double.Where(fun i -> not(Double.IsNaN i) && i > 0.0)
let genNegative = Gen.Double.Where(fun i -> not(Double.IsNaN i) && i < 0.0)

let all =
    test "optimize_root" {

        test "root_bound" {
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

        test "root_linear_between" {
            let! a, _, b, _, x =
                let genD = Gen.Double
                Gen.Select(genD, genD, genD, genD)
                    .Where(fun struct (a, fa, b, fb) -> a < b && Optimize.Root_Bound(fa, fb))
                    .Select(fun struct (a, fa, b, fb) -> a, fa, b, fb, Optimize.Root_Linear(a, fa, b, fb))
            Check.between a b x
        }

        test "root_linear_correct" {
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

        test "root_quadratic_between" {
            let! a, _, b, _, _, _, x =
                let genD = Gen.Double
                Gen.Select(genD, genD, genD, genD, genD, genD)
                    .Where(fun struct (a, fa, b, fb, c, _) -> a < b && (c < a || c > b) && Optimize.Root_Bound(fa, fb))
                    .Select(fun struct (a, fa, b, fb, c, fc) -> a, fa, b, fb, c, fc, Optimize.Root_Quadratic(a, fa, b, fb, c, fc))
            Check.between a b x
        }

        test "root_quadratic_correct" {
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

        test "root_inversequadratic_between" {
            let! a, _, b, _, _, _, x =
                let genD = Gen.Double
                Gen.Select(genD, genD, genD, genD, genD, genD)
                    .Where(fun struct (a, fa, b, fb, c, _) -> a < b && (c < a || c > b) && Optimize.Root_Bound(fa, fb))
                    .Select(fun struct (a, fa, b, fb, c, fc) -> a, fa, b, fb, c, fc, Optimize.Root_InverseQuadratic(a, fa, b, fb, c, fc))
            Check.between a b x
        }

        test "test_problems" {
            let test_solver name tol solver (testAssert:int -> TestResult) =
                test name {
                    let problems = Optimization.TestProblems
                    Check.equal 154 problems.Length
                    let mutable count = 0
                    for i = 0 to problems.Length - 1 do
                        let struct (F, Min, Max) = problems.[i]
                        let x = solver(tol, Func<_,_>(fun x -> count <- count + 1; F.Invoke(x)), Min, Max)
                        Check.isTrue (Optimize.Root_Bound(F.Invoke(x - tol), F.Invoke(x + tol)) || F.Invoke(x) = 0.0)
                    testAssert count
                }

            test_solver "hybrid_6" 1e-6 Optimize.Root (Check.equal 2162)
            test_solver "hybrid_7" 1e-7 Optimize.Root (Check.equal 2256)
            test_solver "hybrid_9" 1e-9 Optimize.Root (Check.between 2311 2311)
            test_solver "hybrid_11" 1e-11 Optimize.Root (Check.between 2347 2347)

            test_solver "brent_6" 1e-6 Optimize.Root_Brent (Check.equal 2763)
            test_solver "brent_7" 1e-7 Optimize.Root_Brent (Check.equal 2816)
            test_solver "brent_9" 1e-9 Optimize.Root_Brent (Check.equal 2889)
            test_solver "brent_11" 1e-11 Optimize.Root_Brent (Check.equal 2935)

            test_solver "toms748_11_mathxk" 1e-11 Optimize.Root_Toms748_MathXK (Check.equal 3544)
            test_solver "toms748_11_scipy" 1e-11 Optimize.Root_Toms748_SciPy (Check.equal 2964)

            test "bond_spread" {
                let tol = 1e-11
                let run solver =
                    let mutable count = 0
                    let x = solver(tol, Func<_,_>(fun x -> count <- count + 1; 0.9 - Optimization.BondPrice(x, 0.075, 0.035, 20.0)), -0.1, 1.0)
                    x, count
                let root, root_i = run Optimize.Root
                let root_brent, root_brent_i = run Optimize.Root_Brent
                Check.isTrue (abs(root - root_brent) < tol * 2.0)
                Check.equal 10 root_i
                Check.equal 13 root_brent_i
            }

            test "option_volatility" {
                let tol = 1e-11
                let run solver =
                    let mutable count = 0
                    let x = solver(tol, Func<_,_>(fun x -> count <- count + 1; Optimization.BlackScholes(true, 9.0, 10.0, 2.0, 0.02, x) - 1.0), 0.0, 1.0)
                    x, count
                let root, root_i = run Optimize.Root
                let root_brent, root_brent_i = run Optimize.Root_Brent
                Check.isTrue (abs(root - root_brent) < tol * 2.0)
                Check.equal 7 root_i
                Check.equal 8 root_brent_i
            }
        }
    }