module Stats.EstimatorTests

open System
open MKLNET
open CsCheck
open TestsCSharp

let all =
    test "stats_estimator" {

        test "quartile_5_order" {
            let! xs = Gen.Double.OneTwo.Array.[5]
            let qe = QuartileEstimator()
            for x in xs do qe.Add x
            Check.greaterThanOrEqual qe.Q0 qe.Q1
            Check.greaterThanOrEqual qe.Q1 qe.Q2
            Check.greaterThanOrEqual qe.Q2 qe.Q3
            Check.greaterThanOrEqual qe.Q3 qe.Q4
        }

        test "quartile_p2" {
            let! xs = Gen.Double.[-1000.0, 1000.0].Array.[5, 50]
            let expected = P2QuantileEstimator(0.5)
            let actual = QuartileEstimator()
            for x in xs do
                expected.AddValue x
                actual.Add x
            Check.equal (expected.GetQuantile()) actual.Median
            Check.greaterThanOrEqual actual.Q0 actual.Q1
            Check.greaterThanOrEqual actual.Q1 actual.Q2
            Check.greaterThanOrEqual actual.Q2 actual.Q3
            Check.greaterThanOrEqual actual.Q3 actual.Q4
        }

        test "quartile_faster" {
            let! xs = Gen.Double.OneTwo.Array
            Check.faster
                (fun () ->
                    let e = QuartileEstimator()
                    for x in xs do e.Add x
                )
                (fun () ->
                    let e = P2QuantileEstimator(0.5)
                    for x in xs do e.AddValue x
                )
        }

        test "quartile_add_same" {
            let! xs1 = Gen.Double.OneTwo.Array.[5, 50]
            and! xs2 = Gen.Double.OneTwo.Array.[5, 50]
            let qe1 = QuartileEstimator()
            for x in xs1 do qe1.Add x
            let qe2 = QuartileEstimator()
            for x in xs2 do qe2.Add x
            let qe3 = qe1 + qe2
            qe1.Add qe2
            Check.equal qe3.N qe1.N
            Check.equal qe3.Q0 qe1.Q0
            Check.equal qe3.Q1 qe1.Q1
            Check.equal qe3.Q2 qe1.Q2
            Check.equal qe3.Q3 qe1.Q3
            Check.equal qe3.Q4 qe1.Q4
        }

        test "quartile_add" {
            let! xs1 = Gen.Double.OneTwo.Array.[5, 50]
            and! xs2 = Gen.Double.OneTwo.Array.[5, 50]
            let qe3 = QuartileEstimator()
            let qe1 = QuartileEstimator()
            for x in xs1 do
                qe1.Add x
                qe3.Add x
            let qe2 = QuartileEstimator()
            for x in xs2 do
                qe2.Add x
                qe3.Add x
            qe1.Add qe2
            Check.equal qe3.N qe1.N
            Check.equal qe3.Q0 qe1.Q0
            Check.equal qe3.Q4 qe1.Q4
        }
    }