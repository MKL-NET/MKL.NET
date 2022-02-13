module Optimize.GlobalTests

open System
open MKLNET
open CsCheck

let all =
    test "optimize_global" {

        test "rastrigin" {
            let globalMin = Optimize.Minimum_Global(1e-7, 0.0, Func<_,_> Optimization.Rastrigin, [|-4; -4|], [|5.12; 5.12|])
                            |> Seq.take 9
            for i in globalMin do
                Check.info "time = %0.1f next = %0.1f fmin = %+2.5f xmin = %s" i.TimeSpan.TotalSeconds i.NextTimeSpan.TotalSeconds i.Fmin (Check.Print i.Xmin)
        }

        test "ackley" {
            let globalMin = Optimize.Minimum_Global(1e-7, 0.0, Func<_,_>(fun x -> Optimization.Ackley(x[0], x[1])), [|-4; -4|], [|5; 5|])
                            |> Seq.take 9
            for i in globalMin do
                Check.info "time = %0.1f next = %0.1f fmin = %+2.5f xmin = %s" i.TimeSpan.TotalSeconds i.NextTimeSpan.TotalSeconds i.Fmin (Check.Print i.Xmin)
        }

        test "rosenbrock" {
            let globalMin = Optimize.Minimum_Global(1e-7, 0.0, Func<_,_>(fun x -> Optimization.Rosenbrock(x)), [|-2; -1|], [|2; 3|])
                            |> Seq.take 9
            for i in globalMin do
                Check.info "time = %0.1f next = %0.1f fmin = %+2.5f xmin = %s" i.TimeSpan.TotalSeconds i.NextTimeSpan.TotalSeconds i.Fmin (Check.Print i.Xmin)
        }

        test "beale" {
            let globalMin = Optimize.Minimum_Global(1e-7, 0.0, Func<_,_>(fun x -> Optimization.Beale(x[0], x[1])), [|-4.5; -4.5|], [|4.5; 4.5|])
                            |> Seq.take 9
            for i in globalMin do
                Check.info "time = %0.1f next = %0.1f fmin = %+2.5f xmin = %s" i.TimeSpan.TotalSeconds i.NextTimeSpan.TotalSeconds i.Fmin (Check.Print i.Xmin)
        }

        test "bukin6" {
            let globalMin = Optimize.Minimum_Global(1e-7, 0.0, Func<_,_>(fun x -> Optimization.Bukin6(x[0], x[1])), [|-15; -3|], [|-5; 3|])
                            |> Seq.take 9
            for i in globalMin do
                Check.info "time = %0.1f next = %0.1f fmin = %+2.5f xmin = %s" i.TimeSpan.TotalSeconds i.NextTimeSpan.TotalSeconds i.Fmin (Check.Print i.Xmin)
        }

        test "levi13" {
            let globalMin = Optimize.Minimum_Global(1e-7, 0.0, Func<_,_>(fun x -> Optimization.Levi13(x[0], x[1])), [|-10; -10|], [|10; 10|])
                            |> Seq.take 9
            for i in globalMin do
                Check.info "time = %0.1f next = %0.1f fmin = %+2.5f xmin = %s" i.TimeSpan.TotalSeconds i.NextTimeSpan.TotalSeconds i.Fmin (Check.Print i.Xmin)
        }

        test "himmelblau" {
            let globalMin = Optimize.Minimum_Global(1e-7, 0.0, Func<_,_>(fun x -> Optimization.Himmelblau(x[0], x[1])), [|-5; -5|], [|5; 5|])
                            |> Seq.take 9
            for i in globalMin do
                Check.info "time = %0.1f next = %0.1f fmin = %+2.5f xmin = %s" i.TimeSpan.TotalSeconds i.NextTimeSpan.TotalSeconds i.Fmin (Check.Print i.Xmin)
        }

        test "easom" {
            let globalMin = Optimize.Minimum_Global(1e-7, 0.0, Func<_,_>(fun x -> Optimization.Easom(x[0], x[1])), [|-10; -10|], [|10; 10|])
                            |> Seq.take 9
            for i in globalMin do
                Check.info "time = %0.1f next = %0.1f fmin = %+2.5f xmin = %s" i.TimeSpan.TotalSeconds i.NextTimeSpan.TotalSeconds i.Fmin (Check.Print i.Xmin)
        }

        test "crossintray" {
            let globalMin = Optimize.Minimum_Global(1e-7, 0.0, Func<_,_>(fun x -> Optimization.CrossInTray(x[0], x[1])), [|-10; -10|], [|10; 10|])
                            |> Seq.take 9
            for i in globalMin do
                Check.info "time = %0.1f next = %0.1f fmin = %+2.5f xmin = %s" i.TimeSpan.TotalSeconds i.NextTimeSpan.TotalSeconds i.Fmin (Check.Print i.Xmin)
        }

        test "eggholder" {
            let globalMin = Optimize.Minimum_Global(1e-7, 0.0, Func<_,_>(fun x -> Optimization.Eggholder(x[0], x[1])), [|-512; -512|], [|512; 512|])
                            |> Seq.take 9
            for i in globalMin do
                Check.info "time = %0.1f next = %0.1f fmin = %+2.5f xmin = %s" i.TimeSpan.TotalSeconds i.NextTimeSpan.TotalSeconds i.Fmin (Check.Print i.Xmin)
        }

        test "holder" {
            let globalMin = Optimize.Minimum_Global(1e-7, 0.0, Func<_,_>(fun x -> Optimization.Holder(x[0], x[1])), [|-10; -10|], [|10; 10|])
                            |> Seq.take 9
            for i in globalMin do
                Check.info "time = %0.1f next = %0.1f fmin = %+2.5f xmin = %s" i.TimeSpan.TotalSeconds i.NextTimeSpan.TotalSeconds i.Fmin (Check.Print i.Xmin)
        }

        test "mccormick" {
            let globalMin = Optimize.Minimum_Global(1e-7, 0.0, Func<_,_>(fun x -> Optimization.McCormick(x[0], x[1])), [|-1.5; -3.0|], [|4.0; 4.0|])
                            |> Seq.take 9
            for i in globalMin do
                Check.info "time = %0.1f next = %0.1f fmin = %+2.5f xmin = %s" i.TimeSpan.TotalSeconds i.NextTimeSpan.TotalSeconds i.Fmin (Check.Print i.Xmin)
        }

        //test "schaffer2" {
        //    let globalMin = Optimize.Minimum_Global(1e-7, 0.0, Func<_,_>(fun x -> Optimization.Schaffer2(x[0], x[1])), [|-50.0; -70.0|], [|90.0; 80.0|])
        //                    |> Seq.take 9
        //    for i in globalMin do
        //        Check.info "time = %0.1f next = %0.1f fmin = %+2.5f xmin = %s" i.TimeSpan.TotalSeconds i.NextTimeSpan.TotalSeconds i.Fmin (Check.Print i.Xmin)
        //}

        test "schaffer4" {
            let globalMin = Optimize.Minimum_Global(1e-7, 0.0, Func<_,_>(fun x -> Optimization.Schaffer4(x[0], x[1])), [|-40.0; -50.0|], [|50.0; 40.0|])
                            |> Seq.take 9
            for i in globalMin do
                Check.info "time = %0.1f next = %0.1f fmin = %+2.5f xmin = %s" i.TimeSpan.TotalSeconds i.NextTimeSpan.TotalSeconds i.Fmin (Check.Print i.Xmin)
        }

        test "styblinski_tang" {
            let globalMin = Optimize.Minimum_Global(1e-7, 0.0, Func<_,_>(fun x -> Optimization.StyblinskiTang(x)), [|-5; -5|], [|5; 5|])
                            |> Seq.take 9
            for i in globalMin do
                Check.info "time = %0.1f next = %0.1f fmin = %+2.5f xmin = %s" i.TimeSpan.TotalSeconds i.NextTimeSpan.TotalSeconds i.Fmin (Check.Print i.Xmin)
        }
    }
