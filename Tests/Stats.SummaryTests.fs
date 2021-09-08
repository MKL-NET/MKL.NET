module Stats.SummaryTests

open System.Threading.Tasks
open MKLNET
open CsCheck

let all =
    test "stats_summary" {

        test "quartiles_perf" {
            let! obvs = Gen.Int.[1000,2000]
            and! vars = Gen.Int.[5,10]
            let! a = Gen.Double.OneTwo.Array.[obvs*vars]
            let m = new matrix(obvs, vars, a)
            m.ReuseArray() |> ignore
            let quants = Stats.Quartiles(m)
            ()
        }
    }