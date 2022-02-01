module Optimize.GlobalTests

open System
open MKLNET
open CsCheck

let all =
    test "optimize_global" {

        test "rastrigin" {
            let globalMin = Optimize.Minimum_Global(1e-6, 0.0, Func<_,_> Optimization.Rastrigin, [|-4.0; -4.0|], [|5.12; 5.12|])
                            |> Seq.take 5
            for i in globalMin do
                Check.info "time = %0.1f next = %0.1f fmin = %+2.5f xmin = %s" i.TimeSpan.TotalSeconds i.NextTimeSpan.TotalSeconds i.Fmin (Check.Print i.Xmin)
            // Seq.take 7 and tol 1e-7 to reproduce inf loop
        }

        test "holder" {
            let globalMin = Optimize.Minimum_Global(1e-6, 0.0, Func<_,_>(fun x -> Optimization.Holder(x[0], x[1])), [|-10.0; -10.0|], [|10.0; 10.0|])
                            |> Seq.take 7
            for i in globalMin do
                Check.info "time = %0.1f next = %0.1f fmin = %+2.5f xmin = %s" i.TimeSpan.TotalSeconds i.NextTimeSpan.TotalSeconds i.Fmin (Check.Print i.Xmin)
            // Seq.take 7 and tol 1e-7 to reproduce inf loop
        }


    }
