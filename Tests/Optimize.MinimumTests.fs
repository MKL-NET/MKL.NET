module Optimize.MinimumTests

open System
open System.Collections.Generic
open MKLNET
open CsCheck

let all =
    test "optimize_minimum" {

        test "minimum_quadratic_between" {
            let! a, _, _, _, c, _, x =
                let genD = Gen.Double[-1e100, 1e100]
                Gen.Select(genD, genD, genD, genD, genD, genD)
                    .Where(fun struct (a, fa, b, fb, c, fc) -> a < b && b < c && Optimize.Minimum_Is_Bracketed(fa, fb, fc))
                    .Select(fun struct (a, fa, b, fb, c, fc) -> a, fa, b, fb, c, fc, Optimize.Minimum_Quadratic(a, fa, b, fb, c, fc))
            Check.between a c x
        }

        test "minimum_quadratic_correct" {
            let! root1 = Gen.Double[-10, 10]
            let! root2 = Gen.Double[-10, 10]
            let f x = (x - root1) * (x - root2)
            let! x =
                let genD = Gen.Double[-20, 20]
                Gen.Select(genD, genD, genD)
                    .Where(fun struct (a, b, c) -> a < b && b < c && not(Accuracy.areClose Low a b) && not(Accuracy.areClose Low b c))
                    .Select(fun struct (a, b, c) -> a, f(a), b, f(b), c, f(c))
                    .Select(fun (a, fa, b, fb, c, fc) -> Optimize.Minimum_Quadratic(a, fa, b, fb, c, fc))
            Check.close Low ((root1 + root2) * 0.5) x
        }

        test "minimum_cubic_between" {
            let! a, _, _, _, c, _, _, _, x =
                let genD = Gen.Double[-1e100, 1e100]
                let genC = genD.Select(genD)
                Gen.Select(genC, genC, genC, genC)
                    .Where(fun struct ((a, fa), (b, fb), (c, fc), (d, _)) -> a < b && b < c && (d < a || d > c) && Optimize.Minimum_Is_Bracketed(fa, fb, fc))
                    .Select(fun struct ((a, fa), (b, fb), (c, fc), (d, fd)) -> a, fa, b, fb, c, fc, d, fd, Optimize.Minimum_Cubic(a, fa, b, fb, c, fc, d, fd))
            Check.between a c x
        }

        test "minimum_cubic_correct" {
            let! root1 = Gen.Double[-10, -4]
            let! root2 = Gen.Double[-3, 3]
            let! root3 = Gen.Double[4, 10]
            let f x = (x - root1) * (x - root2) * (x - root3)
            let! x =
                let genD = Gen.Double[root2, root3 * 2.0]
                Gen.Select(genD, genD, genD, genD)
                    .Where(fun struct (a, b, c, d) -> a < b && b < c && (d < a || d > c) && not(Accuracy.areClose Low a b) && not(Accuracy.areClose Low b c)
                                                                                         && not(Accuracy.areClose Low d a) && not(Accuracy.areClose Low d c))
                    .Select(fun struct (a, b, c, d) -> a, f(a), b, f(b), c, f(c), d, f(d))
                    .Where(fun (_, fa, _, fb, _, fc, _, _) -> Optimize.Minimum_Is_Bracketed(fa, fb, fc))
                    .Select(fun (a, fa, b, fb, c, fc, d, fd) -> Optimize.Minimum_Cubic(a, fa, b, fb, c, fc, d, fd))
            Check.greaterThan (f(x)) (f(x - (root3 - root2) * 0.001))
            Check.greaterThan (f(x)) (f(x + (root3 - root2) * 0.001))
        }

        let test_solver name tol solver (testAssert:int -> TestResult) =
            test name {
                let problems = Optimization.MinimumTestProblems
                let mutable count = 0
                for i = 0 to problems.Length - 1 do
                    let struct (F, min, low, max) = problems[i]
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
                        Check.isTrue (Optimize.Minimum_Is_Bracketed(inRangeFx[0], inRangeFx[1], inRangeFx[2]))
                    else
                        Check.isTrue (Optimize.Minimum_Is_Bracketed(inRangeFx[0], inRangeFx[1], inRangeFx[2])) |||
                        Check.isTrue (Optimize.Minimum_Is_Bracketed(inRangeFx[1], inRangeFx[2], inRangeFx[3]))
                testAssert count
            }

        test_solver "brent_7" 1e-7 Optimize.Minimum_Brent (Check.between 5310 5313)
        test_solver "brent_9" 1e-9 Optimize.Minimum_Brent (Check.between 6390 6433)
        test_solver "brent_11" 1e-11 Optimize.Minimum_Brent (Check.between 7582 7620)

        let minimum_bracketed (atol, rtol, f:Func<_,_>, a, b, c) =
            Optimize.Minimum_Bracketed(atol, rtol, f, a, f.Invoke(a), b, f.Invoke(b), c, f.Invoke(c), Double.PositiveInfinity, 0.0)

        test_solver "hybrid_bracketed_7" 1e-7 minimum_bracketed (Check.between 2721 2723)
        test_solver "hybrid_bracketed_9" 1e-9 minimum_bracketed (Check.between 3215 3238)
        test_solver "hybrid_bracketed_11" 1e-11 minimum_bracketed (Check.between 4087 4187)

        let minimum (atol, rtol, f:Func<float,float>, _, b, _) = Optimize.Minimum(atol, rtol, f, b)

        test_solver "hybrid_7" 1e-7 minimum (Check.between 2250 2273)
        test_solver "hybrid_9" 1e-9 minimum (Check.between 2840 2863)
        test_solver "hybrid_11" 1e-11 minimum (Check.between 3867 3963)

        let MathNet_Minimum tol func (x:float[]) =
            let mutable count = 0
            let obf = MathNet.Numerics.Optimization.ObjectiveFunction.Gradient(
                        Func<_,_>(fun v -> count <- count + 1; func(v.AsArray())),
                        Func<_,_>(fun v ->
                            let x = v.AsArray()
                            count <- count + 1
                            let fx = func x
                            let r = Array.init x.Length (fun i ->
                                let x_i = x[i];
                                x[i] <- x_i + tol / 100.0
                                count <- count + 1
                                let dfi = (func x - fx) / (x_i + (tol / 100.0) - x_i)
                                x[i] <- x_i
                                dfi
                            )
                            MathNet.Numerics.LinearAlgebra.CreateVector.Dense(r)
                        ))
            let r = MathNet.Numerics.Optimization.BfgsMinimizer(tol, tol, 0.0)
                        .FindMinimum(obf, MathNet.Numerics.LinearAlgebra.CreateVector.Dense(x))
            for i = 0 to x.Length-1 do
                x[i] <- r.MinimizingPoint[i]
            count, r.FunctionInfoAtMinimum.Value

        test "rosen_5_mklnet" {
            let x = [|1.3; 0.7; 0.8; 1.9; 1.2|]
            let mutable count = 0
            Optimize.Minimum(1e-7, 0.0, Func<_,_>(fun x -> count <- count + 1; Optimization.Rosenbrock x), x) |> ignore
            for xi in x do
                Check.close Medium 1.0 xi
            Check.between 212 215 count
        }

        test "rosen_5_mathnet" {
            let x = [|1.3; 0.7; 0.8; 1.9; 1.2|]
            let count,_ = MathNet_Minimum 1e-7 Optimization.Rosenbrock x
            for xi in x do
                Check.close Medium 1.0 xi
            Check.between 728 728 count
        }

        test "stybl_5_mklnet" {
            let x = [|-1.0; -0.5; -0.5; -0.5; -0.5|]
            let mutable count = 0
            Optimize.Minimum(1e-7, 0.0, Func<_,_>(fun x -> count <- count + 1; Optimization.StyblinskiTang x), x) |> ignore
            for xi in x do
                Check.close Medium -2.903534 xi
            Check.between 201 256 count
        }

        test "stybl_5_mathnet" {
            let x = [|-1.0; -0.5; -0.5; -0.5; -0.5|]
            let count,_ = MathNet_Minimum 1e-7 Optimization.StyblinskiTang x
            for xi in x do
                Check.close Medium -2.903534 xi
            Check.between 455 455 count
        }

        test "beale_mklnet" {
            let mutable x = 0.0
            let mutable y = 0.0
            let mutable count = 0
            Optimize.Minimum(1e-7, 0.0, Func<_,_,_>(fun x y -> count <- count + 1; Optimization.Beale(x, y)), &x, &y) |> ignore
            Check.close Medium 3.0 x
            Check.close Medium 0.5 y
            Check.between 123 123 count
        }

        test "beale_mathnet" {
            let x = [|0.0; 0.0|]
            let count,_ = MathNet_Minimum 1e-7 (fun xi -> Optimization.Beale(xi[0], xi[1])) x
            Check.close Medium 3.0 x[0]
            Check.close Medium 0.5 x[1]
            Check.between 152 152 count
        }

        test "goldp_mklnet" {
            let mutable x = -2.0
            let mutable y = -2.0
            let mutable count = 0
            Optimize.Minimum(1e-7, 0.0, Func<_,_,_>(fun x y -> count <- count + 1; Optimization.GoldsteinPrice(x, y)), &x, &y) |> ignore
            Check.close Low 0.0 x
            Check.close Low -1.0 y
            Check.between 125 127 count
        }

        test "goldp_mathnet" {
            let x = [|-2.0; -2.0|]
            let count,_ = MathNet_Minimum 1e-7 (fun xi -> Optimization.GoldsteinPrice(xi[0], xi[1])) x
            Check.close Low 0.0 x[0]
            Check.close Low -1.0 x[1]
            Check.between 296 296 count
        }

        test "booth_mklnet" {
            let mutable x = 0.0
            let mutable y = 0.0
            let mutable count = 0
            Optimize.Minimum(1e-7, 0.0, Func<_,_,_>(fun x y -> count <- count + 1; Optimization.Booth(x, y)), &x, &y) |> ignore
            Check.close Medium 1.0 x
            Check.close Medium 3.0 y
            Check.between 32 34 count
        }

        test "booth_mathnet" {
            let x = [|0.0; 0.0|]
            let count,_ = MathNet_Minimum 1e-7 (fun xi -> Optimization.Booth(xi[0], xi[1])) x
            Check.close Medium 1.0 x[0]
            Check.close Medium 3.0 x[1]
            Check.between 112 112 count
        }

        test "matyas_mklnet" {
            let mutable x = 1.0
            let mutable y = -1.0
            let mutable count = 0
            Optimize.Minimum(5e-8, 0.0, Func<_,_,_>(fun x y -> count <- count + 1; Optimization.Matyas(x, y)), &x, &y) |> ignore
            Check.close Medium 0.0 x
            Check.close Medium 0.0 y
            Check.between 18 18 count
        }

        test "matyas_mathnet" {
            let x = [|1.0; -1.0|]
            let count,_ = MathNet_Minimum 5e-8 (fun xi -> Optimization.Matyas(xi[0], xi[1])) x
            Check.close Medium 0.0 x[0]
            Check.close Medium 0.0 x[1]
            Check.between 80 80 count
        }

        test "himmel_mklnet" {
            let mutable x = 4.0
            let mutable y = 4.0
            let mutable count = 0
            Optimize.Minimum(1e-7, 0.0, Func<_,_,_>(fun x y -> count <- count + 1; Optimization.Himmelblau(x, y)), &x, &y) |> ignore
            Check.close Medium 3.0 x
            Check.close Medium 2.0 y
            Check.between 81 81 count
        }

        test "himmel_mathnet" {
            let x = [|4.0; 4.0|]
            let count,_ = MathNet_Minimum 1e-7 (fun xi -> Optimization.Himmelblau(xi[0], xi[1])) x
            Check.close Medium 3.0 x[0]
            Check.close Medium 2.0 x[1]
            Check.between 176 176 count
        }

        test "mccorm_mklnet" {
            let mutable x = 0.0
            let mutable y = 0.0
            let mutable count = 0
            Optimize.Minimum(1e-7, 0.0, Func<_,_,_>(fun x y -> count <- count + 1; Optimization.McCormick(x, y)), &x, &y) |> ignore
            Check.close Medium -0.547197 x
            Check.close Medium -1.547197 y
            Check.between 66 68 count
        }

        //test "mccorm_mathnet" { // fails to find minimum
        //    let x = [|0.0; 0.0|]
        //    let mutable count = 0
        //    let count = MathNet_Minimum 1e-7 (fun xi -> count <- count + 1; Optimization.McCormick(xi[0], xi[1])) x
        //    Check.info "x: %.9f" x[0]
        //    Check.info "y: %.9f" x[1]
        //    Check.close Medium -0.547197 x[0]
        //    Check.close Medium -1.547197 x[1]
        //    Check.between 180 180 count
        //}

        test "guas_3_mklnet" {
            let x = [|1.0; 2.0; 1.0|]
            let mutable count = 0
            let ols = Optimize.CurveFit_OLS(1e-7, 0.0, Func<_,_,_>(fun p x -> count <- count + 1; Optimization.Gaussian(p, x)), x, Optimization.GaussianT, Optimization.GaussianY)
            count <- count / Optimization.GaussianT.Length
            Check.between 140 142 count
            Check.close Medium 1.12793e-8 ols
        }

        test "guas_3_mathnet" {
            let x = [|1.0; 2.0; 1.0|]
            let count, ols = MathNet_Minimum 1e-7 (fun xi ->
                                let mutable sum = 0.0
                                for i = 0 to Optimization.GaussianT.Length - 1 do
                                    let d = Optimization.Gaussian(xi, Optimization.GaussianT[i]) - Optimization.GaussianY[i]
                                    sum <- sum + d * d
                                sum
                             ) x
            Check.between 150 150 count
            Check.close Medium 1.12793e-8 ols
        }

        test "wood_4_mklnet" {
            let mutable x1 = -3.0
            let mutable x2 = -1.0
            let mutable x3 = -3.0
            let mutable x4 = -1.0
            let mutable count = 0
            Optimize.Minimum(1e-7, 0.0, Func<_,_,_,_,_>(fun x1 x2 x3 x4 -> count <- count + 1; Optimization.Wood(x1, x2, x3, x4)), &x1, &x2, &x3, &x4) |> ignore
            Check.close Medium 1.0 x1
            Check.close Medium 1.0 x2
            Check.close Medium 1.0 x3
            Check.close Medium 1.0 x4
            Check.between 607 610 count
        }

        test "wood_4_mathnet" {
            let x = [|-3.0; -1.0; -3.0; -1.0|]
            let count,_ = MathNet_Minimum 1e-7 (fun xi -> Optimization.Wood(xi[0], xi[1], xi[2], xi[3])) x
            Check.close Medium 1.0 x[0]
            Check.close Medium 1.0 x[1]
            Check.close Medium 1.0 x[2]
            Check.close Medium 1.0 x[3]
            Check.between 924 924 count
        }

        test "osbo_11_mklnet" {
            let x = [|1.3; 0.65; 0.65; 0.7; 0.6; 3.0; 5.0; 7.0; 2.0; 4.5; 5.5|]
            let mutable count = 0
            let ols = Optimize.CurveFit_OLS(1e-7, 0.0, Func<_,_,_>(fun p x -> count <- count + 1; Optimization.Osbourne(p, x)), x, Optimization.OsbourneT, Optimization.OsbourneY)
            count <- count / Optimization.OsbourneT.Length
            Check.between 1023 1275 count
            Check.close Medium 0.0401377 ols
        }

        test "osbo_11_mathnet" {
            let x = [|1.3; 0.65; 0.65; 0.7; 0.6; 3.0; 5.0; 7.0; 2.0; 4.5; 5.5|]
            let count, ols = MathNet_Minimum 1e-7 (fun xi ->
                                let mutable sum = 0.0
                                for i = 0 to Optimization.OsbourneT.Length - 1 do
                                    let d = Optimization.Osbourne(xi, Optimization.OsbourneT[i]) - Optimization.OsbourneY[i]
                                    sum <- sum + d * d
                                sum
                             ) x
            Check.between 1287 1417 count
            Check.close Medium 0.0401377 ols
        }

        test "broyd_5_mklnet" {
            let n = 5
            let x = Array.create n -1.0
            let mutable count = 0
            let ols = Optimize.Minimum(1e-7, 0.0, Func<_,_>(fun x -> count <- count + 1; Optimization.Broyden x), x)
            Check.between 164 165 count
            Check.close High 0.0 ols
        }

        test "broyd_5_mathnet" {
            let n = 5
            let x = Array.create n -1.0
            let count, ols = MathNet_Minimum 1e-7 Optimization.Broyden x
            Check.between 392 392 count
            Check.close High 0.0 ols
        }

        test "broyd_16_mklnet" {
            let n = 16
            let x = Array.create n -1.0
            let mutable count = 0
            let ols = Optimize.Minimum(1e-7, 0.0, Func<_,_>(fun x -> count <- count + 1; Optimization.Broyden x), x)
            Check.between 578 582 count
            Check.close High 0.0 ols
        }

        test "broyd_16_mathnet" {
            let n = 16
            let x = Array.create n -1.0
            let count, ols = MathNet_Minimum 1e-7 Optimization.Broyden x
            Check.between 2304 2304 count
            Check.close High 0.0 ols
        }

        test "bound_20_mklnet" {
            let n = 20
            let h = 1.0 / float(n + 1)
            let x = Array.init n (fun i -> let t = float(i + 1) * h in t * (t - 1.0))
            let mutable count = 0
            let ols = Optimize.Minimum(1e-7, 0.0, Func<_,_>(fun x -> count <- count + 1; Optimization.Boundary x), x)
            Check.between 583 594 count
            Check.close High 0.0 ols
        }

        test "bound_20_mathnet" {
            let n = 20
            let h = 1.0 / float(n + 1)
            let x = Array.init n (fun i -> let t = float(i + 1) * h in t * (t - 1.0))
            let count, ols = MathNet_Minimum 1e-7 Optimization.Boundary x
            Check.between 1430 1430 count
            Check.close High 0.0 ols
        }

        test "integ_75_mklnet" {
            let n = 75
            let h = 1.0 / float(n + 1)
            let x = Array.init n (fun i -> let t = float(i + 1) * h in t * (t - 1.0))
            let mutable count = 0
            let ols = Optimize.Minimum(1e-7, 0.0, Func<_,_>(fun x -> count <- count + 1; Optimization.Integral x), x)
            Check.between 239 239 count
            Check.close High 0.0 ols
        }

        test "integ_75_mathnet" {
            let n = 75
            let h = 1.0 / float(n + 1)
            let x = Array.init n (fun i -> let t = float(i + 1) * h in t * (t - 1.0))
            let count, ols = MathNet_Minimum 1e-7 Optimization.Integral x
            Check.between 1463 1463 count
            Check.close High 0.0 ols
        }
    }