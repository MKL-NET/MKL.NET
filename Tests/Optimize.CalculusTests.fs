module Optimize.CalculusTests

open System
open MKLNET
open CsCheck

let all =
    test "optimize_calculus" {

        test "derivative_approx_exp" {
            let! x = Gen.Double.[-10.0, 10.0]
            let actual = Optimize.Derivative_Approx(Func<_,_> Math.Exp, x, 1e-9)
            Check.close Low (Math.Exp x) actual
        }

        test "derivative_approx_sin" {
            let! x = Gen.Double.[-10.0, 10.0]
            let actual = Optimize.Derivative_Approx(Func<_,_> Math.Sin, x, 1e-9)
            Check.close Low (Math.Cos x) actual
        }

        test "derivative_approx_richardson_exp" {
            let! x = Gen.Double.[-10.0, 10.0]
            let actual = Optimize.Derivative_Approx(1e-8, 1e-5, Func<_,_> Math.Exp, x, 1e-3)
            Check.close Medium (Math.Exp x) actual
        }

        test "derivative_approx_richardson_sin" {
            let! x = Gen.Double.[-10.0, 10.0]
            let actual = Optimize.Derivative_Approx(1e-8, 1e-5, Func<_,_> Math.Sin, x, 1e-3)
            Check.close Medium (Math.Cos x) actual
        }

        test "intergral_approx_exp" {
            let! x = Gen.Double.[-1.0, 1.0]
            let actual = Optimize.Integral_Approx(100, Func<_,_> Math.Exp, x, x + 0.1)
            Check.close Low (Math.Exp(x + 0.1) - Math.Exp x) actual
        }

        test "intergral_approx_cos" {
            let! x = Gen.Double.[-10.0, 10.0]
            let actual = Optimize.Integral_Approx(100, Func<_,_> Math.Cos, x, x + 0.1)
            Check.close Low (Math.Sin(x + 0.1) - Math.Sin x) actual
        }

        test "intergral_approx_richardson_exp" {
            let! x = Gen.Double.[-1.0, 1.0]
            let actual = Optimize.Integral_Approx(1e-8, 1e-5, Func<_,_> Math.Exp, x, x + 0.1)
            Check.close Medium (Math.Exp(x + 0.1) - Math.Exp x) actual
        }

        test "intergral_approx_richardson_cos" {
            let! x = Gen.Double.[-10.0, 10.0]
            let actual = Optimize.Integral_Approx(1e-8, 1e-5, Func<_,_> Math.Cos, x, x + 0.1)
            Check.close Medium (Math.Sin(x + 0.1) - Math.Sin x) actual
        }

        test "derivative_approx_parallel_exp" {
            let! x = Gen.Double.[-10.0, 10.0]
            let actual = Optimize.Derivative_Approx_Parallel(Func<_,_> Math.Exp, x, 1e-9)
            Check.close Low (Math.Exp x) actual
        }

        test "derivative_approx_parallel_sin" {
            let! x = Gen.Double.[-10.0, 10.0]
            let actual = Optimize.Derivative_Approx_Parallel(Func<_,_> Math.Sin, x, 1e-9)
            Check.close Low (Math.Cos x) actual
        }

        test "derivative_approx_parallel_richardson_exp" {
            let! x = Gen.Double.[-10.0, 10.0]
            let actual = Optimize.Derivative_Approx_Parallel(1e-8, 1e-5, Func<_,_> Math.Exp, x, 1e-3)
            Check.close Medium (Math.Exp x) actual
        }

        test "derivative_approx_parallel_richardson_sin" {
            let! x = Gen.Double.[-10.0, 10.0]
            let actual = Optimize.Derivative_Approx_Parallel(1e-8, 1e-5, Func<_,_> Math.Sin, x, 1e-3)
            Check.close Medium (Math.Cos x) actual
        }

        test "intergral_approx_parallel_exp" {
            let! x = Gen.Double.[-1.0, 1.0]
            let actual = Optimize.Integral_Approx_Parallel(100, Func<_,_> Math.Exp, x, x + 0.1)
            Check.close Low (Math.Exp(x + 0.1) - Math.Exp x) actual
        }

        test "intergral_approx_parallel_cos" {
            let! x = Gen.Double.[-10.0, 10.0]
            let actual = Optimize.Integral_Approx_Parallel(100, Func<_,_> Math.Cos, x, x + 0.1)
            Check.close Low (Math.Sin(x + 0.1) - Math.Sin x) actual
        }

        test "intergral_approx_parallel_richardson_exp" {
            let! x = Gen.Double.[-1.0, 1.0]
            let actual = Optimize.Integral_Approx_Parallel(1e-8, 1e-5, Func<_,_> Math.Exp, x, x + 0.1)
            Check.close Medium (Math.Exp(x + 0.1) - Math.Exp x) actual
        }

        test "intergral_approx_parallel_richardson_cos" {
            let! x = Gen.Double.[-10.0, 10.0]
            let actual = Optimize.Integral_Approx_Parallel(1e-8, 1e-5, Func<_,_> Math.Cos, x, x + 0.1)
            Check.close Medium (Math.Sin(x + 0.1) - Math.Sin x) actual
        }
    }