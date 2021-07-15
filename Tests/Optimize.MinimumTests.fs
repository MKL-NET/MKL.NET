module Optimize.MinimumTests

open System
open System.Collections.Generic
open MKLNET
open CsCheck

let all =
    test "optimize_minimum" {

        test "Minimum_quadratic_correct" {
            let! root1 = Gen.Double.[-10.0, 10.0]
            let! root2 = Gen.Double.[-10.0, 10.0]
            let f x = (x - root1) * (x - root2)
            let! x =
                let genD = Gen.Double.[-20.0, 20.0]
                Gen.Select(genD, genD, genD)
                    .Where(fun struct (a, b, c) -> a < b && b < c)
                    .Select(fun struct (a, b, c) -> a, f(a), b, f(b), c, f(c))
                    .Select(fun (a, fa, b, fb, c, fc) -> Optimize.Minimum_Quadratic(a, fa, b, fb, c, fc))
            Check.close Low ((root1 + root2) * 0.5) x
        }

        test "Minimum_quadratic_between" {
            let! a, _, _, _, c, _, x =
                let genD = Gen.Double.[-1e100, 1e100]
                Gen.Select(genD, genD, genD, genD, genD, genD)
                    .Where(fun struct (a, fa, b, fb, c, fc) -> a < b && b < c && Optimize.Minimum_Bracketed(fa, fb, fc))
                    .Select(fun struct (a, fa, b, fb, c, fc) -> a, fa, b, fb, c, fc, Optimize.Minimum_Quadratic(a, fa, b, fb, c, fc))
            Check.between a c x
        }

        let test_solver name tol solver (testAssert:int -> TestResult) =
            test name {
                let problems = Optimization.MinimumTestProblems
                let mutable count = 0
                for i = 0 to problems.Length - 1 do
                    let struct (F, min, low, max) = problems.[i]
                    let fmin = F.Invoke(min)
                    let flow = F.Invoke(low)
                    let fmax = F.Invoke(max)
                    Check.greaterThan flow fmin |> Check.message "flow > fmin (%f,%f,%f)" fmin flow fmax
                    Check.greaterThan flow fmax |> Check.message "flow > fmax (%f,%f,%f)" fmin flow fmax
                    let evals = Dictionary()
                    let x = solver(tol, 0.0, Func<_,_> (fun x -> let Fx = F.Invoke(x) in evals.Add(x, Fx); Fx), min, low, max)
                    count <- count + evals.Count
                    let inRangeFx = evals |> Seq.where (fun i -> i.Key >= x - tol * 1.01 && i.Key <= x + tol * 1.01)
                                    |> Seq.sortBy (fun i -> i.Key)
                                    |> Seq.map (fun i -> i.Value)
                                    |> Seq.toArray
                    Check.equal 3 inRangeFx.Length
                    Check.equal (Seq.min inRangeFx) (Seq.min evals.Values)
                    Check.isTrue (Optimize.Minimum_Bracketed(inRangeFx.[0], inRangeFx.[1], inRangeFx.[2]))
                testAssert count
            }

        test_solver "brent_7" 1e-7 Optimize.Minimum_Brent (Check.between 5310 5313)
        test_solver "brent_9" 1e-9 Optimize.Minimum_Brent (Check.between 6390 6433)
        test_solver "brent_11" 1e-11 Optimize.Minimum_Brent (Check.between 7582 7608)

        test_solver "hybrid_7" 1e-7 Optimize.Minimum (Check.equal 2875)
        test_solver "hybrid_9" 1e-9 Optimize.Minimum (Check.equal 3478)
        test_solver "hybrid_11" 1e-11 Optimize.Minimum (Check.equal 4453)
    }