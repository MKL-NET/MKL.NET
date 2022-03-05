module Optimize.GlobalTests

open System
open MKLNET
open CsCheck

let all =
    test "optimize_global" {

        let test_global name f min max =
            test name {
                let! globalMin = Optimize.Minimum_GlobalAsync(1e-7, 0.0, Func<_,_> f, min, max, TimeSpan.FromMinutes 5)
                for (i:Optimize.MinimumIteration) in globalMin do
                    Check.info "time = %0.1f next = %0.1f fmin = %+2.5f xmin = %s" i.TimeSpan.TotalSeconds i.NextTimeSpan.TotalSeconds i.Fmin (Check.Print i.Xmin)
            }

        test_global "rastrigin" Optimization.Rastrigin [|-4; -4|] [|5.12; 5.12|]
        test_global "ackley" (fun x -> Optimization.Ackley(x[0], x[1])) [|-4; -4|] [|5; 5|]
        test_global "rosenbrock" Optimization.Rosenbrock [|-2; -1|] [|2; 3|]
        test_global "beale" (fun x -> Optimization.Beale(x[0], x[1])) [|-4.5; -4.5|] [|4.5; 4.5|]
        test_global "bukin6" (fun x -> Optimization.Bukin6(x[0], x[1])) [|-15; -3|] [|-5; 3|]
        test_global "levi13" (fun x -> Optimization.Levi13(x[0], x[1])) [|-10; -10|] [|10; 10|]
        test_global "himmelblau" (fun x -> Optimization.Himmelblau(x[0], x[1])) [|-5; -5|] [|5; 5|]
        test_global "easom" (fun x -> Optimization.Easom(x[0], x[1])) [|-10; -10|] [|10; 10|]
        test_global "crossintray" (fun x -> Optimization.CrossInTray(x[0], x[1])) [|-10; -10|] [|10; 10|]
        test_global "eggholder" (fun x -> Optimization.Eggholder(x[0], x[1])) [|-512; -512|] [|512; 512|]
        test_global "holder" (fun x -> Optimization.Holder(x[0], x[1])) [|-10; -10|] [|10; 10|]
        test_global "mccormick" (fun x -> Optimization.McCormick(x[0], x[1])) [|-1.5; -3.0|] [|4.0; 4.0|]
        test_global "schaffer2" (fun x -> Optimization.Schaffer2(x[0], x[1])) [|-50.0; -70.0|] [|90.0; 80.0|]
        test_global "schaffer4" (fun x -> Optimization.Schaffer4(x[0], x[1])) [|-40.0; -50.0|] [|50.0; 40.0|]
        test_global "styblinski_tang" Optimization.StyblinskiTang [|-5; -5|] [|5; 5|]
    }
