module Stats.SummaryTests

open System
open MKLNET
open CsCheck

let all =
    test "stats_summary" {

        test "quartiles" {
            let! obvs = Gen.Int.[10,20]
            and! vars = Gen.Int.[4,7]
            use! m = Gen.Double.OneTwo.Matrix(obvs, vars)
            let quants = Stats.Quartiles(m)
            let quantiles = [|0.25;0.50;0.75|]
            let percentile s ss se p =
                let inline linear2 (x1,y1) (x2,y2) x = y1 + (x - x1) * (y2 - y1) / (x2 - x1)
                let si = double ss + double(se-ss-1)*p
                if si <= double ss then Array.get s ss
                elif si >= double(se-1) then Array.get s (se-1)
                else linear2 (floor si,s.[int si]) (floor si + 1.0,s.[int si + 1]) si
            for var = 0 to vars - 1 do
                Array.Sort(m.Array, var*obvs, obvs)
                for q = 0 to quantiles.Length - 1 do
                    let expected = percentile m.Array (var*obvs) (var*obvs+obvs) quantiles.[q]
                    Check.close High expected quants.[q,var]
        }

        let sqr x = x * x

        test "moments" {
            let! obvs = Gen.Int.[10,20]
            and! vars = Gen.Int.[4,7]
            use! m = Gen.Double.OneTwo.Matrix(obvs, vars)
            let struct (mean, mom2c) = Stats.Moments(m);
            for var = 0 to vars - 1 do
                let meanExpected = Blas.asum(obvs, m.Array, var*obvs, 1) / float obvs
                let mutable mom2cExpected = 0.0
                for i = var*obvs to var*obvs + obvs - 1 do
                    mom2cExpected <- mom2cExpected + sqr(m.Array.[i] - meanExpected)
                mom2cExpected <- mom2cExpected / float(obvs - 1)
                Check.close High meanExpected mean.[var] |> Check.message "mean"
                Check.close High mom2cExpected mom2c.[var] |> Check.message "mom2c"
        }

        test "covariance" {
            let! obvs = Gen.Int.[10,20]
            and! vars = Gen.Int.[4,7]
            use! m = Gen.Double.OneTwo.Matrix(obvs, vars)
            let cov, mean = Stats.Covariance(m);
            use expectedMean = new vectorT(vars, fun i ->
                let mutable total = 0.0
                for j = 0 to obvs - 1 do
                    total <- total + m.[j, i]
                total / double obvs
            )
            use expectedCov = new matrix(vars, vars, fun i j ->
                let mutable total = 0.0
                for k = 0 to obvs - 1 do
                    total <- total + (m.[k, i]-mean.[i]) * (m.[k, j]-mean.[j])
                total / double(obvs-1)
            )
            Check.close High expectedMean mean
            Check.close High expectedCov cov
        }

        test "covariance_weighted" {
            let! obvs = Gen.Int.[10,20]
            and! vars = Gen.Int.[4,7]
            use! m = Gen.Double.OneTwo.Matrix(obvs, vars)
            use w = new vector(obvs, fun i -> double(i+1))
            let cov, mean = Stats.Covariance(m, w);
            let mutable W, B = 0.0, 0.0
            for i = 0 to obvs - 1 do
                W <- W + w.[i]
                B <- B + sqr(w.[i])
            B <- W - B / W
            use expectedMean = new vectorT(vars, fun i ->
                let mutable total = 0.0
                for j = 0 to obvs - 1 do
                    total <- total + w.[j] * m.[j, i]
                total / W
            )
            use expectedCov = new matrix(vars, vars, fun i j ->
                let mutable total = 0.0
                for k = 0 to obvs - 1 do
                    total <- total + w.[k] * (m.[k, i]-mean.[i]) * (m.[k, j]-mean.[j])
                total / B
            )    
            Check.close High expectedMean mean
            Check.close High expectedCov cov
        }

        test "correlation" {
            let! obvs = Gen.Int.[10,20]
            and! vars = Gen.Int.[4,7]
            use! m = Gen.Double.OneTwo.Matrix(obvs, vars)
            let cor, mean = Stats.Correlation(m);
            use expectedMean = new vectorT(vars, fun j ->
                let mutable total = 0.0
                for i = 0 to obvs - 1 do
                    total <- total + m.[i, j]
                total / double obvs
            )
            use expectedCor = new matrix(vars, vars, fun i j ->
                let mutable total = 0.0
                for k = 0 to obvs - 1 do
                    total <- total + (m.[k, i]-mean.[i]) * (m.[k, j]-mean.[j])
                total / double(obvs-1)
            )
            for i = 0 to vars - 1 do
                for j = 0 to vars - 1 do
                    expectedCor.[i,j] <-
                        if i=j then expectedCor.[i,j]
                        else expectedCor.[i,j] / sqrt(expectedCor.[i,i] * expectedCor.[j,j])
            Check.close High expectedMean mean
            Check.close High expectedCor cor
        }

        test "correlation_weighted" {
            let! obvs = Gen.Int.[10,20]
            and! vars = Gen.Int.[4,7]
            use! m = Gen.Double.OneTwo.Matrix(obvs, vars)
            use w = new vector(obvs, fun i -> double(i+1))
            let cor, mean = Stats.Correlation(m, w);
            let mutable W, B = 0.0, 0.0
            for i = 0 to obvs - 1 do
                W <- W + w.[i]
                B <- B + sqr(w.[i])
            B <- W - B / W
            use expectedMean = new vectorT(vars, fun j ->
                let mutable total = 0.0
                for i = 0 to obvs - 1 do
                    total <- total + w.[i] * m.[i, j]
                total / W
            )
            use expectedCor = new matrix(vars, vars, fun i j ->
                let mutable total = 0.0
                for k = 0 to obvs - 1 do
                    total <- total + w.[k] * (m.[k, i]-mean.[i]) * (m.[k, j]-mean.[j])
                total / B
            )    
            for i = 0 to vars - 1 do
                for j = 0 to vars - 1 do
                    expectedCor.[i,j] <-
                        if i=j then expectedCor.[i,j]
                        else expectedCor.[i,j] / sqrt(expectedCor.[i,i] * expectedCor.[j,j])
            Check.close High expectedMean mean
            Check.close High expectedCor cor
        }
    }