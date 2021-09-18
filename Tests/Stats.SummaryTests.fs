module Stats.SummaryTests

open System
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
            let quantiles = [|0.25;0.50;0.75|]
            let percentile s ss se p =
                let inline linear2 (x1,y1) (x2,y2) x = y1 + (x - x1) * (y2 - y1) / (x2 - x1)
                let si = double ss + double(se-ss-1)*p
                if si <= double ss then Array.get s ss
                elif si >= double(se-1) then Array.get s (se-1)
                else linear2 (floor si,s.[int si]) (floor si + 1.0,s.[int si + 1]) si
            let expected = Array.init (vars*quantiles.Length) (fun i ->
                let var, qi = Math.DivRem(i,quantiles.Length)
                Array.Sort(a, var*obvs, obvs)
                percentile a (var*obvs) (var*obvs+obvs) quantiles.[qi]
            )
            Check.close High expected quants.Array
        }
    }