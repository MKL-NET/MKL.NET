module Optimize.MinimumTests

open System
open System.Collections.Generic
open MKLNET
open CsCheck

let all =
    test "optimize_minimum" {

        test "minimum_quadratic_between" {
            let! a, _, _, _, c, _, x =
                let genD = Gen.Double.[-1e100, 1e100]
                Gen.Select(genD, genD, genD, genD, genD, genD)
                    .Where(fun struct (a, fa, b, fb, c, fc) -> a < b && b < c && Optimize.Minimum_Is_Bracketed(fa, fb, fc))
                    .Select(fun struct (a, fa, b, fb, c, fc) -> a, fa, b, fb, c, fc, Optimize.Minimum_Quadratic(a, fa, b, fb, c, fc))
            Check.between a c x
        }

        test "minimum_quadratic_correct" {
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

        test "minimum_cubic_between" {
            let! a, _, _, _, c, _, _, _, x =
                let genD = Gen.Double.[-1e100, 1e100]
                let genC = genD.Select(genD)
                Gen.Select(genC, genC, genC, genC)
                    .Where(fun struct ((a, fa), (b, fb), (c, fc), (d, _)) -> a < b && b < c && (d < a || d > c) && Optimize.Minimum_Is_Bracketed(fa, fb, fc))
                    .Select(fun struct ((a, fa), (b, fb), (c, fc), (d, fd)) -> a, fa, b, fb, c, fc, d, fd, Optimize.Minimum_Cubic(a, fa, b, fb, c, fc, d, fd))
            Check.between a c x
        }

        test "minimum_cubic_correct" {
            let! root1 = Gen.Double.[-10.0, -4.0]
            let! root2 = Gen.Double.[-3.0, 3.0]
            let! root3 = Gen.Double.[4.0, 10.0]
            let f x = (x - root1) * (x - root2) * (x - root3)
            let! x =
                let genD = Gen.Double.[root2, root3 * 2.0]
                Gen.Select(genD, genD, genD, genD)
                    .Select(fun struct (a, b, c, d) -> a, f(a), b, f(b), c, f(c), d, f(d))
                    .Where(fun (a, fa, b, fb, c, fc, d, _) -> a < b && b < c && (d < a || d > c) && Optimize.Minimum_Is_Bracketed(fa, fb, fc))
                    .Select(fun (a, fa, b, fb, c, fc, d, fd) -> Optimize.Minimum_Cubic(a, fa, b, fb, c, fc, d, fd))
            Check.greaterThan (f(x)) (f(x - (root3 - root2) * 0.001))
            Check.greaterThan (f(x)) (f(x + (root3 - root2) * 0.001))
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
                    let inRangeFx = evals |> Seq.where (fun i -> i.Key >= x - tol && i.Key <= x + tol)
                                    |> Seq.sortBy (fun i -> i.Key)
                                    |> Seq.map (fun i -> i.Value)
                                    |> Seq.toArray
                    Check.between 3 4 inRangeFx.Length
                    Check.equal (Seq.min inRangeFx) (Seq.min evals.Values)
                    if inRangeFx.Length = 3 then
                        Check.isTrue (Optimize.Minimum_Is_Bracketed(inRangeFx.[0], inRangeFx.[1], inRangeFx.[2]))
                    else
                        Check.isTrue (Optimize.Minimum_Is_Bracketed(inRangeFx.[0], inRangeFx.[1], inRangeFx.[2])) |||
                        Check.isTrue (Optimize.Minimum_Is_Bracketed(inRangeFx.[1], inRangeFx.[2], inRangeFx.[3]))
                testAssert count
            }

        test_solver "brent_7" 1e-7 Optimize.Minimum_Brent (Check.between 5310 5313)
        test_solver "brent_9" 1e-9 Optimize.Minimum_Brent (Check.between 6390 6433)
        test_solver "brent_11" 1e-11 Optimize.Minimum_Brent (Check.between 7582 7608)

        let minimum_bracketed (atol, rtol, f:Func<_,_>, a, b, c) =
            Optimize.Minimum_Bracketed(atol, rtol, f, a, f.Invoke(a), b, f.Invoke(b), c, f.Invoke(c), Double.PositiveInfinity, 0.0)

        test_solver "hybrid_bracketed_7" 1e-7 minimum_bracketed (Check.between 2721 2721)
        test_solver "hybrid_bracketed_9" 1e-9 minimum_bracketed (Check.between 3217 3217)
        test_solver "hybrid_bracketed_11" 1e-11 minimum_bracketed (Check.between 4171 4179)

        let minimum (atol, rtol, f:Func<float,float>, _, b, _) = Optimize.Minimum(atol, rtol, f, b)

        test_solver "hybrid_7" 1e-7 minimum (Check.between 2264 2264)
        test_solver "hybrid_9" 1e-9 minimum (Check.between 2863 2863)
        test_solver "hybrid_11" 1e-11 minimum (Check.between 3947 3953)

        let MathNet_Minimum tol func (x:float[]) =
            let mutable count = 0
            let obf = MathNet.Numerics.Optimization.ObjectiveFunction.Gradient(
                        Func<_,_>(fun v -> count <- count + 1; func(v.AsArray())),
                        Func<_,_>(fun v ->
                            let x = v.AsArray()
                            count <- count + 1
                            let fx = func x
                            let r = Array.init x.Length (fun i ->
                                let x_i = x.[i];
                                x.[i] <- x_i + tol / 100.0
                                count <- count + 1
                                let dfi = (func x - fx) / (x_i + (tol / 100.0) - x_i)
                                x.[i] <- x_i
                                dfi
                            )
                            MathNet.Numerics.LinearAlgebra.CreateVector.Dense(r)
                        ))
            let DOESNT_SEEM_TO_BE_USED = 0.0
            let r = MathNet.Numerics.Optimization.BfgsMinimizer(tol, tol, DOESNT_SEEM_TO_BE_USED)
                        .FindMinimum(obf, MathNet.Numerics.LinearAlgebra.CreateVector.Dense(x))
            for i = 0 to x.Length-1 do
                x.[i] <- r.MinimizingPoint.[i]
            count

        test "rosen_5_mklnet" {
            let x = [|1.3; 0.7; 0.8; 1.9; 1.2|]
            let mutable count = 0
            Optimize.Minimum(1e-7, 0.0, Func<_,_>(fun x -> count <- count + 1; Optimization.Rosenbrock x), x);
            for xi in x do
                Check.info "x: %.9f" xi
                Check.close Medium 1.0 xi
            Check.between 248 248 count
        }

        test "rosen_5_mathnet" {
            let x = [|1.3; 0.7; 0.8; 1.9; 1.2|]
            let count = MathNet_Minimum 1e-7 Optimization.Rosenbrock x
            for xi in x do
                Check.info "x: %.9f" xi
                Check.close Medium 1.0 xi
            Check.between 728 728 count
        }

        //test "stybl_5_mklnet" {
        //    let x = [|-1.0; -0.5; -0.5; -0.5; -0.5|]
        //    let mutable count = 0
        //    Optimize.Minimum(1e-7, 0.0, Func<_,_>(fun x -> count <- count + 1; Optimization.StyblinskiTang x), x);
        //    for xi in x do
        //        Check.info "x: %.9f" xi
        //        Check.close Medium -2.903534 xi
        //    Check.between 251 251 count
        //}

        test "stybl_5_mathnet" {
            let x = [|-1.0; -0.5; -0.5; -0.5; -0.5|]
            let count = MathNet_Minimum 1e-7 Optimization.StyblinskiTang x
            for xi in x do
                Check.info "x: %.9f" xi
                Check.close Medium -2.903534 xi
            Check.between 455 455 count
        }
    }