// Copyright 2022 Anthony Lloyd
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace MKLNET.Expression;
public abstract class MatrixExpression
{
    public abstract matrix Evaluate();
    public static implicit operator MatrixExpression(matrix a) => new MatrixInput(a);
    public static implicit operator matrix(MatrixExpression a) => a.Evaluate();
    public static MatrixExpression operator +(MatrixExpression a, double s) => new MatrixAddScalar(a, s);
    public static MatrixExpression operator +(double s, MatrixExpression b) => new MatrixAddScalar(b, s);
    public static MatrixExpression operator -(MatrixExpression a, double s) => new MatrixAddScalar(a, -s);
    public static MatrixExpression operator -(double s, MatrixExpression a) =>
        new MatrixAddScalar(a is MatrixScale sm ? new MatrixScale(sm.E, -sm.S) : new MatrixScale(a, -1.0), s);
    public static MatrixExpression operator +(MatrixExpression a, MatrixExpression b)
    {
        if (a is MatrixTranspose or MatrixScale || b is MatrixTranspose or MatrixScale)
        {
            var (ea, ta, sa) = a is MatrixScale msa ? (msa.E is MatrixTranspose mta ? (mta.E, true, msa.S) : (msa.E, false, msa.S))
                             : a is MatrixTranspose mta2 ? (mta2.E, true, 1.0)
                             : (a, false, 1.0);
            var (eb, tb, sb) = b is MatrixScale msb ? (msb.E is MatrixTranspose mtb ? (mtb.E, true, msb.S) : (msb.E, false, msb.S))
                             : b is MatrixTranspose mtb2 ? (mtb2.E, true, 1.0)
                             : (b, false, 1.0);
            return new MatrixAdd(ea, ta, sa, eb, tb, sb, null);
        }
        return new MatrixAddSimple(a, b, null);
    }
    public static MatrixExpression operator -(MatrixExpression a, MatrixExpression b)
    {
        if (a is MatrixTranspose or MatrixScale || b is MatrixTranspose or MatrixScale)
        {
            var (ea, ta, sa) = a is MatrixScale msa ? (msa.E is MatrixTranspose mta ? (mta.E, true, msa.S) : (msa.E, false, msa.S))
                             : a is MatrixTranspose mta2 ? (mta2.E, true, 1.0)
                             : (a, false, 1.0);
            var (eb, tb, sb) = b is MatrixScale msb ? (msb.E is MatrixTranspose mtb ? (mtb.E, true, -msb.S) : (msb.E, false, -msb.S))
                             : b is MatrixTranspose mtb2 ? (mtb2.E, true, -1.0)
                             : (b, false, -1.0);
            return new MatrixAdd(ea, ta, sa, eb, tb, sb, null);
        }
        return new MatrixSubSimple(a, b, null);
    }
    public static MatrixExpression operator *(MatrixExpression a, double s) =>
          a is MatrixScale sa ? new MatrixScale(sa.E, sa.S * s)
        : a is MatrixMultiply mm ? new MatrixMultiply(mm.Ea * s, mm.Eb, mm.R)
        : a is MatrixAdd ma ? new MatrixAdd(ma.Ea, ma.Transa, ma.Sa * s, ma.Eb, ma.Transb, ma.Sb * s, null)
        : a is MatrixAddSimple mas ? new MatrixAdd(mas.Ea, false, s, mas.Eb, false, s, null)
        : a is MatrixSubSimple mss ? new MatrixAdd(mss.Ea, false, s, mss.Eb, false, -s, null)
        : new MatrixScale(a, s);
    public static MatrixExpression operator *(double s, MatrixExpression a) =>
          a is MatrixScale sa ? new MatrixScale(sa.E, sa.S * s)
        : a is MatrixMultiply mm ? new MatrixMultiply(mm.Ea * s, mm.Eb, mm.R)
        : a is MatrixAdd ma ? new MatrixAdd(ma.Ea, ma.Transa, ma.Sa * s, ma.Eb, ma.Transb, ma.Sb * s, null)
        : a is MatrixAddSimple mas ? new MatrixAdd(mas.Ea, false, s, mas.Eb, false, s, null)
        : a is MatrixSubSimple mss ? new MatrixAdd(mss.Ea, false, s, mss.Eb, false, -s, null)
        : new MatrixScale(a, s);
    public static MatrixExpression operator /(MatrixExpression a, double s) => a * (1 / s);
    public static MatrixExpression operator *(MatrixExpression a, MatrixExpression b) => new MatrixMultiply(a, b, null);
    public MatrixExpression T =>
          this is MatrixTranspose t ? t.E
        : this is MatrixScale ms ? new MatrixScale(ms.E.T, ms.S)
        : this is MatrixMultiply mm ? new MatrixMultiply(mm.Eb.T, mm.Ea.T, mm.R)
        : this is MatrixAdd ma ? new MatrixAdd(ma.Ea, !ma.Transa, ma.Sa, ma.Eb, !ma.Transb, ma.Sb, null)
        : this is MatrixAddSimple mas ? new MatrixAdd(mas.Ea, true, 1.0, mas.Eb, true, 1.0, null)
        : this is MatrixSubSimple mss ? new MatrixAdd(mss.Ea, true, 1.0, mss.Eb, true, -1.0, null)
        : new MatrixTranspose(this);
    public static VectorExpression operator *(MatrixExpression m, vector v) => new MatrixVectorMultiply(m, v, null);
    public static VectorExpression operator *(MatrixExpression m, VectorExpression v) => new MatrixVectorMultiply(m, v, null);
    public static VectorTExpression operator *(VectorTExpression vt, MatrixExpression m) => new VectorTMatrixMultiply(vt, m, null);
    public static VectorTExpression operator *(vectorT vt, MatrixExpression m) => new VectorTMatrixMultiply(vt, m, null);
}

public class MatrixInput : MatrixExpression
{
    readonly protected matrix m;
    public MatrixInput(matrix a) => m = a;
    public override matrix Evaluate() => m;
}

public class MatrixReuse : MatrixExpression
{
    readonly protected matrix m;
    public MatrixReuse(matrix a) => m = a;
    public override matrix Evaluate() => m;
}

public class MatrixScale : MatrixExpression
{
    public readonly MatrixExpression E;
    public readonly double S;
    public MatrixScale(MatrixExpression a, double s)
    {
        E = a;
        S = s;
    }
    public override matrix Evaluate()
    {
        if (E is MatrixTranspose mt)
        {
            var a = mt.E.Evaluate();
            if (mt.E is MatrixInput)
            {
                var r = new matrix(a.Cols, a.Rows);
                Blas.omatcopy(LayoutChar.ColMajor, TransChar.Yes, a.Rows, a.Cols, S, a.Array, a.Rows, r.Array, r.Rows);
                return r;
            }
            else
            {
                var r = new matrix(a.Cols, a.Rows, a.ReuseArray());
                Blas.imatcopy(LayoutChar.ColMajor, TransChar.Yes, a.Rows, a.Cols, S, a.Array, a.Rows, r.Rows);
                return r;
            }
        }
        else
        {
            var a = E.Evaluate();
            if (E is MatrixInput)
            {
                var r = new matrix(a.Rows, a.Cols);
                Blas.omatcopy(LayoutChar.ColMajor, TransChar.No, a.Rows, a.Cols, S, a.Array, a.Rows, r.Array, r.Rows);
                return r;
            }
            else
            {
                Blas.imatcopy(LayoutChar.ColMajor, TransChar.No, a.Rows, a.Cols, S, a.Array, a.Rows, a.Rows);
                return a;
            }
        }
    }
}

public class MatrixTranspose : MatrixExpression
{
    public readonly MatrixExpression E;
    public MatrixTranspose(MatrixExpression a)
    {
        E = a;
    }
    public override matrix Evaluate()
    {
        var a = E.Evaluate();
        if (E is MatrixInput)
        {
            var r = new matrix(a.Cols, a.Rows);
            Blas.omatcopy(LayoutChar.ColMajor, TransChar.Yes, a.Rows, a.Cols, 1.0, a.Array, a.Rows, r.Array, r.Rows);
            return r;
        }
        else
        {
            var r = new matrix(a.Cols, a.Rows, a.ReuseArray());
            Blas.imatcopy(LayoutChar.ColMajor, TransChar.Yes, a.Rows, a.Cols, 1.0, a.Array, a.Rows, r.Rows);
            return r;
        }
    }
}

public abstract class MatrixUnary : MatrixExpression
{
    readonly MatrixExpression E;
    protected MatrixUnary(MatrixExpression a) => E = a;
    protected abstract void Evaluate(matrix a, matrix r);
    public override matrix Evaluate()
    {
        var a = E.Evaluate();
        var r = E is MatrixInput ? new matrix(a.Rows, a.Cols) : a;
        Evaluate(a, r);
        return r;
    }
}

public abstract class MatrixBinary : MatrixExpression
{
    readonly MatrixExpression Ea, Eb;
    protected MatrixBinary(MatrixExpression a, MatrixExpression b)
    {
        Ea = a;
        Eb = b;
    }
    protected abstract void Evaluate(matrix a, matrix b, matrix r);
    public override matrix Evaluate()
    {
        var a = Ea.Evaluate();
        var b = Eb.Evaluate();
        if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
        var r = Ea is not MatrixInput ? a
              : Eb is not MatrixInput ? b
              : new matrix(a.Rows, a.Cols);
        Evaluate(a, b, r);
        if (Ea is not MatrixInput && Eb is not MatrixInput) b.Dispose();
        return r;
    }
}

public class MatrixAddSimple : MatrixExpression
{
    public readonly MatrixExpression Ea, Eb;
    public readonly double[]? R;
    public MatrixAddSimple(MatrixExpression a, MatrixExpression b, double[]? reuse)
    {
        Ea = a;
        Eb = b;
        R = reuse;
    }
    public override matrix Evaluate()
    {
        var a = Ea.Evaluate();
        var b = Eb.Evaluate();
        if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
        var r = R is not null ? new matrix(a.Rows, a.Cols, R)
              : Ea is not MatrixInput ? a
              : Eb is not MatrixInput ? b
              : new matrix(a.Rows, a.Cols);
        Vml.Add(a.Length, a.Array, b.Array, r.Array);
        if (Ea is not MatrixInput && Eb is not MatrixInput) b.Dispose();
        return r;
    }
}

public class MatrixSubSimple : MatrixExpression
{
    public readonly MatrixExpression Ea, Eb;
    public readonly double[]? R;
    public MatrixSubSimple(MatrixExpression a, MatrixExpression b, double[]? reuse)
    {
        Ea = a;
        Eb = b;
        R = reuse;
    }
    public override matrix Evaluate()
    {
        var a = Ea.Evaluate();
        var b = Eb.Evaluate();
        if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
        var r = R is not null ? new matrix(a.Rows, a.Cols, R)
              : Ea is not MatrixInput ? a
              : Eb is not MatrixInput ? b
              : new matrix(a.Rows, a.Cols);
        Vml.Sub(a.Length, a.Array, b.Array, r.Array);
        if (Ea is not MatrixInput && Eb is not MatrixInput) b.Dispose();
        return r;
    }
}

public class MatrixAdd : MatrixExpression
{
    public readonly MatrixExpression Ea, Eb;
    public readonly double Sa, Sb;
    public readonly bool Transa, Transb;
    public readonly double[]? R;
    public MatrixAdd(MatrixExpression a, bool transa, double sa, MatrixExpression b, bool transb, double sb, double[]? reuse)
    {
        Ea = a;
        Eb = b;
        Sa = sa;
        Sb = sb;
        Transa = transa;
        Transb = transb;
        R = reuse;
    }
    public override matrix Evaluate()
    {
        var a = Ea.Evaluate();
        var b = Eb.Evaluate();
        if ((Transa == Transb && (a.Rows != b.Rows || a.Cols != b.Cols))
           || (Transa != Transb && (a.Rows != b.Cols || a.Cols != b.Rows))) ThrowHelper.ThrowIncorrectDimensionsForOperation();
        var r = R is not null ? Transa ? new matrix(a.Cols, a.Rows, R) : new matrix(a.Rows, a.Cols, R)
              : Ea is not MatrixInput ? (Transa ? new matrix(a.Cols, a.Rows, a.ReuseArray()) : a)
              : Eb is not MatrixInput ? (Transb ? new matrix(b.Cols, b.Rows, b.ReuseArray()) : b)
              : Transa ? new matrix(a.Cols, a.Rows) : new matrix(a.Rows, a.Cols);
        Blas.omatadd(LayoutChar.ColMajor, Transa ? TransChar.Yes : TransChar.No, Transb ? TransChar.Yes : TransChar.No,
                        r.Rows, r.Cols, Sa, a.Array, a.Rows, Sb, b.Array, b.Rows, r.Array, r.Rows);
        if (Ea is not MatrixInput && Eb is not MatrixInput) b.Dispose();
        return r;
    }
}

public class MatrixAddScalar : MatrixExpression
{
    public readonly MatrixExpression E;
    public readonly double S;
    public MatrixAddScalar(MatrixExpression a, double s)
    {
        E = a;
        S = s;
    }
    public override matrix Evaluate()
    {
        var (e, sa) = E is MatrixScale Es ? (Es.E, Es.S) : (E, 1.0);
        var a = e.Evaluate();
        var r = e is MatrixInput ? new matrix(a.Rows, a.Cols) : a;
        Vml.LinearFrac(a.Length, a.Array, a.Array, sa, S, 0.0, 1.0, r.Array);
        return r;
    }
}

public class MatrixMultiply : MatrixExpression
{
    public readonly MatrixExpression Ea, Eb;
    public readonly double[]? R;
    public MatrixMultiply(MatrixExpression a, MatrixExpression b, double[]? reuse)
    {
        Ea = a;
        Eb = b;
        R = reuse;
    }
    public override matrix Evaluate()
    {
        var (ea, ta, sa) = Ea is MatrixScale msa ? (msa.E is MatrixTranspose mta ? (mta.E, Trans.Yes, msa.S) : (msa.E, Trans.No, msa.S))
                         : Ea is MatrixTranspose mta2 ? (mta2.E, Trans.Yes, 1.0)
                         : (Ea, Trans.No, 1.0);
        var (eb, tb, sb) = Eb is MatrixScale msb ? (msb.E is MatrixTranspose mtb ? (mtb.E, Trans.Yes, msb.S) : (msb.E, Trans.No, msb.S))
                         : Eb is MatrixTranspose mtb2 ? (mtb2.E, Trans.Yes, 1.0)
                         : (Eb, Trans.No, 1.0);
        var a = ea.Evaluate();
        var b = eb.Evaluate();
        var k = ta == Trans.Yes ? a.Rows : a.Cols;
        if (k != (tb == Trans.Yes ? b.Cols : b.Rows)) ThrowHelper.ThrowIncorrectDimensionsForOperation();
        var r = R is null ? new matrix(ta == Trans.Yes ? a.Cols : a.Rows, tb == Trans.Yes ? b.Rows : b.Cols)
                          : new matrix(ta == Trans.Yes ? a.Cols : a.Rows, tb == Trans.Yes ? b.Rows : b.Cols, R);
        Blas.gemm(Layout.ColMajor, ta, tb, r.Rows, r.Cols, k, sa * sb, a.Array, a.Rows, b.Array, b.Rows, 0.0, r.Array, r.Rows);
        if (ea is not MatrixInput) a.Dispose();
        if (eb is not MatrixInput) b.Dispose();
        return r;
    }
}

public class MatrixAbs : MatrixUnary
{
    public MatrixAbs(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Abs(a.Length, a.Array, r.Array);
}

public class MatrixSqr : MatrixUnary
{
    public MatrixSqr(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Sqr(a.Length, a.Array, r.Array);
}

public class MatrixInv : MatrixUnary
{
    public MatrixInv(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Inv(a.Length, a.Array, r.Array);
}

public class MatrixSqrt : MatrixUnary
{
    public MatrixSqrt(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Sqrt(a.Length, a.Array, r.Array);
}

public class MatrixInvSqrt : MatrixUnary
{
    public MatrixInvSqrt(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.InvSqrt(a.Length, a.Array, r.Array);
}

public class MatrixCbrt : MatrixUnary
{
    public MatrixCbrt(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Cbrt(a.Length, a.Array, r.Array);
}

public class MatrixInvCbrt : MatrixUnary
{
    public MatrixInvCbrt(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.InvCbrt(a.Length, a.Array, r.Array);
}

public class MatrixPow2o3 : MatrixUnary
{
    public MatrixPow2o3(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Pow2o3(a.Length, a.Array, r.Array);
}

public class MatrixPow3o2 : MatrixUnary
{
    public MatrixPow3o2(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Pow3o2(a.Length, a.Array, r.Array);
}

public class MatrixExp : MatrixUnary
{
    public MatrixExp(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Exp(a.Length, a.Array, r.Array);
}

public class MatrixExp2 : MatrixUnary
{
    public MatrixExp2(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Exp2(a.Length, a.Array, r.Array);
}

public class MatrixExp10 : MatrixUnary
{
    public MatrixExp10(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Exp10(a.Length, a.Array, r.Array);
}

public class MatrixExpm1 : MatrixUnary
{
    public MatrixExpm1(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Expm1(a.Length, a.Array, r.Array);
}

public class MatrixLn : MatrixUnary
{
    public MatrixLn(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Ln(a.Length, a.Array, r.Array);
}

public class MatrixLog2 : MatrixUnary
{
    public MatrixLog2(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Log2(a.Length, a.Array, r.Array);
}

public class MatrixLog10 : MatrixUnary
{
    public MatrixLog10(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Log10(a.Length, a.Array, r.Array);
}

public class MatrixLog1p : MatrixUnary
{
    public MatrixLog1p(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Log1p(a.Length, a.Array, r.Array);
}

public class MatrixLogb : MatrixUnary
{
    public MatrixLogb(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Logb(a.Length, a.Array, r.Array);
}
public class MatrixCos : MatrixUnary
{
    public MatrixCos(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Cos(a.Length, a.Array, r.Array);
}

public class MatrixSin : MatrixUnary
{
    public MatrixSin(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Sin(a.Length, a.Array, r.Array);
}

public class MatrixTan : MatrixUnary
{
    public MatrixTan(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Tan(a.Length, a.Array, r.Array);
}

public class MatrixCospi : MatrixUnary
{
    public MatrixCospi(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Cospi(a.Length, a.Array, r.Array);
}

public class MatrixSinpi : MatrixUnary
{
    public MatrixSinpi(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Sinpi(a.Length, a.Array, r.Array);
}

public class MatrixTanpi : MatrixUnary
{
    public MatrixTanpi(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Tanpi(a.Length, a.Array, r.Array);
}

public class MatrixCosd : MatrixUnary
{
    public MatrixCosd(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Cosd(a.Length, a.Array, r.Array);
}

public class MatrixSind : MatrixUnary
{
    public MatrixSind(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Sind(a.Length, a.Array, r.Array);
}

public class MatrixTand : MatrixUnary
{
    public MatrixTand(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Tand(a.Length, a.Array, r.Array);
}

public class MatrixAcos : MatrixUnary
{
    public MatrixAcos(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Acos(a.Length, a.Array, r.Array);
}

public class MatrixAsin : MatrixUnary
{
    public MatrixAsin(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Asin(a.Length, a.Array, r.Array);
}

public class MatrixAtan : MatrixUnary
{
    public MatrixAtan(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Atan(a.Length, a.Array, r.Array);
}

public class MatrixAcospi : MatrixUnary
{
    public MatrixAcospi(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Acospi(a.Length, a.Array, r.Array);
}

public class MatrixAsinpi : MatrixUnary
{
    public MatrixAsinpi(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Asinpi(a.Length, a.Array, r.Array);
}

public class MatrixAtanpi : MatrixUnary
{
    public MatrixAtanpi(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Atanpi(a.Length, a.Array, r.Array);
}

public class MatrixCosh : MatrixUnary
{
    public MatrixCosh(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Cosh(a.Length, a.Array, r.Array);
}

public class MatrixSinh : MatrixUnary
{
    public MatrixSinh(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Sinh(a.Length, a.Array, r.Array);
}

public class MatrixTanh : MatrixUnary
{
    public MatrixTanh(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Tanh(a.Length, a.Array, r.Array);
}

public class MatrixAcosh : MatrixUnary
{
    public MatrixAcosh(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Acosh(a.Length, a.Array, r.Array);
}

public class MatrixAsinh : MatrixUnary
{
    public MatrixAsinh(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Asinh(a.Length, a.Array, r.Array);
}

public class MatrixAtanh : MatrixUnary
{
    public MatrixAtanh(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Atanh(a.Length, a.Array, r.Array);
}

public class MatrixErf : MatrixUnary
{
    public MatrixErf(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Erf(a.Length, a.Array, r.Array);
}

public class MatrixErfc : MatrixUnary
{
    public MatrixErfc(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Erfc(a.Length, a.Array, r.Array);
}

public class MatrixErfInv : MatrixUnary
{
    public MatrixErfInv(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.ErfInv(a.Length, a.Array, r.Array);
}

public class MatrixErfcInv : MatrixUnary
{
    public MatrixErfcInv(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.ErfcInv(a.Length, a.Array, r.Array);
}

public class MatrixCdfNorm : MatrixUnary
{
    public MatrixCdfNorm(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.CdfNorm(a.Length, a.Array, r.Array);
}

public class MatrixCdfNormInv : MatrixUnary
{
    public MatrixCdfNormInv(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.CdfNormInv(a.Length, a.Array, r.Array);
}

public class MatrixLGamma : MatrixUnary
{
    public MatrixLGamma(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.LGamma(a.Length, a.Array, r.Array);
}

public class MatrixTGamma : MatrixUnary
{
    public MatrixTGamma(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.TGamma(a.Length, a.Array, r.Array);
}

public class MatrixExpInt1 : MatrixUnary
{
    public MatrixExpInt1(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.ExpInt1(a.Length, a.Array, r.Array);
}

public class MatrixFloor : MatrixUnary
{
    public MatrixFloor(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Floor(a.Length, a.Array, r.Array);
}

public class MatrixCeil : MatrixUnary
{
    public MatrixCeil(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Ceil(a.Length, a.Array, r.Array);
}

public class MatrixTrunc : MatrixUnary
{
    public MatrixTrunc(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Trunc(a.Length, a.Array, r.Array);
}

public class MatrixRound : MatrixUnary
{
    public MatrixRound(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Round(a.Length, a.Array, r.Array);
}

public class MatrixFrac : MatrixUnary
{
    public MatrixFrac(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Frac(a.Length, a.Array, r.Array);
}

public class MatrixNearbyInt : MatrixUnary
{
    public MatrixNearbyInt(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.NearbyInt(a.Length, a.Array, r.Array);
}

public class MatrixRint : MatrixUnary
{
    public MatrixRint(MatrixExpression a) : base(a) { }
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Rint(a.Length, a.Array, r.Array);
}

public class MatrixPowx : MatrixUnary
{
    readonly double b;
    public MatrixPowx(MatrixExpression a, double b) : base(a) => this.b = b;
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Powx(a.Length, a.Array, b, r.Array);
}

public class MatrixMaxScalar : MatrixUnary
{
    readonly double b;
    public MatrixMaxScalar(MatrixExpression a, double b) : base(a) => this.b = b;
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Fmax(a.Length, a.Array, 0, a.Length, b, r.Array, 0, r.Length);
}

public class MatrixMinScalar : MatrixUnary
{
    readonly double b;
    public MatrixMinScalar(MatrixExpression a, double b) : base(a) => this.b = b;
    protected override void Evaluate(matrix a, matrix r)
        => Vml.Fmin(a.Length, a.Array, 0, a.Length, b, r.Array, 0, r.Length);
}

public class MatrixCopySign : MatrixBinary
{
    public MatrixCopySign(MatrixExpression a, MatrixExpression b) : base(a, b) { }
    protected override void Evaluate(matrix a, matrix b, matrix r)
        => Vml.CopySign(a.Length, a.Array, b.Array, r.Array);
}

public class MatrixFmax : MatrixBinary
{
    public MatrixFmax(MatrixExpression a, MatrixExpression b) : base(a, b) { }
    protected override void Evaluate(matrix a, matrix b, matrix r)
        => Vml.Fmax(a.Length, a.Array, b.Array, r.Array);
}

public class MatrixFmin : MatrixBinary
{
    public MatrixFmin(MatrixExpression a, MatrixExpression b) : base(a, b) { }
    protected override void Evaluate(matrix a, matrix b, matrix r)
        => Vml.Fmin(a.Length, a.Array, b.Array, r.Array);
}

public class MatrixFdim : MatrixBinary
{
    public MatrixFdim(MatrixExpression a, MatrixExpression b) : base(a, b) { }
    protected override void Evaluate(matrix a, matrix b, matrix r)
        => Vml.Fdim(a.Length, a.Array, b.Array, r.Array);
}

public class MatrixMaxMag : MatrixBinary
{
    public MatrixMaxMag(MatrixExpression a, MatrixExpression b) : base(a, b) { }
    protected override void Evaluate(matrix a, matrix b, matrix r)
        => Vml.MaxMag(a.Length, a.Array, b.Array, r.Array);
}

public class MatrixNextAfter : MatrixBinary
{
    public MatrixNextAfter(MatrixExpression a, MatrixExpression b) : base(a, b) { }
    protected override void Evaluate(matrix a, matrix b, matrix r)
        => Vml.NextAfter(a.Length, a.Array, b.Array, r.Array);
}

public class MatrixMul : MatrixBinary
{
    public MatrixMul(MatrixExpression a, MatrixExpression b) : base(a, b) { }
    protected override void Evaluate(matrix a, matrix b, matrix r)
        => Vml.Mul(a.Length, a.Array, b.Array, r.Array);
}

public class MatrixFmod : MatrixBinary
{
    public MatrixFmod(MatrixExpression a, MatrixExpression b) : base(a, b) { }
    protected override void Evaluate(matrix a, matrix b, matrix r)
        => Vml.Fmod(a.Length, a.Array, b.Array, r.Array);
}

public class MatrixAtan2 : MatrixBinary
{
    public MatrixAtan2(MatrixExpression a, MatrixExpression b) : base(a, b) { }
    protected override void Evaluate(matrix a, matrix b, matrix r)
        => Vml.Atan2(a.Length, a.Array, b.Array, r.Array);
}

public class MatrixAtan2pi : MatrixBinary
{
    public MatrixAtan2pi(MatrixExpression a, MatrixExpression b) : base(a, b) { }
    protected override void Evaluate(matrix a, matrix b, matrix r)
        => Vml.Atan2pi(a.Length, a.Array, b.Array, r.Array);
}

public class MatrixPowr : MatrixBinary
{
    public MatrixPowr(MatrixExpression a, MatrixExpression b) : base(a, b) { }
    protected override void Evaluate(matrix a, matrix b, matrix r)
        => Vml.Powr(a.Length, a.Array, b.Array, r.Array);
}

public class MatrixRemainder : MatrixBinary
{
    public MatrixRemainder(MatrixExpression a, MatrixExpression b) : base(a, b) { }
    protected override void Evaluate(matrix a, matrix b, matrix r)
        => Vml.Remainder(a.Length, a.Array, b.Array, r.Array);
}

public class MatrixHypot : MatrixBinary
{
    public MatrixHypot(MatrixExpression a, MatrixExpression b) : base(a, b) { }
    protected override void Evaluate(matrix a, matrix b, matrix r)
        => Vml.Hypot(a.Length, a.Array, b.Array, r.Array);
}

public class MatrixDiv : MatrixBinary
{
    public MatrixDiv(MatrixExpression a, MatrixExpression b) : base(a, b) { }
    protected override void Evaluate(matrix a, matrix b, matrix r)
        => Vml.Div(a.Length, a.Array, b.Array, r.Array);
}

public class MatrixPow : MatrixBinary
{
    public MatrixPow(MatrixExpression a, MatrixExpression b) : base(a, b) { }
    protected override void Evaluate(matrix a, matrix b, matrix r)
        => Vml.Pow(a.Length, a.Array, b.Array, r.Array);
}

public class MatrixLinearFrac : MatrixBinary
{
    readonly double Scalea, Shifta, Scaleb, Shiftb;
    public MatrixLinearFrac(MatrixExpression a, MatrixExpression b, double scalea, double shifta, double scaleb, double shiftb) : base(a, b)
    {
        Scalea = scalea;
        Shifta = shifta;
        Scaleb = scaleb;
        Shiftb = shiftb;
    }
    protected override void Evaluate(matrix a, matrix b, matrix r)
        => Vml.LinearFrac(a.Length, a.Array, b.Array, Scalea, Shifta, Scaleb, Shiftb, r.Array);
}

public class MatrixInverse : MatrixExpression
{
    readonly MatrixExpression E;
    public MatrixInverse(MatrixExpression a) => E = a;
    public override matrix Evaluate()
    {
        var a = E.Evaluate();
        if (a.Rows != a.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
        if (E is MatrixInput) a = Matrix.Copy(a);
        var ipiv = Pool.Int.Rent(a.Rows);
        ThrowHelper.Check(Lapack.getrf(Layout.ColMajor, a.Rows, a.Rows, a.Array, a.Rows, ipiv));
        ThrowHelper.Check(Lapack.getri(Layout.ColMajor, a.Rows, a.Array, a.Rows, ipiv));
        Pool.Int.Return(ipiv);
        return a;
    }
}

public class MatrixLower : MatrixExpression
{
    readonly MatrixExpression E;
    public MatrixLower(MatrixExpression a) => E = a;
    public override matrix Evaluate()
    {
        var a = E.Evaluate();
        if (E is MatrixInput) a = Matrix.Copy(a);
        for (int c = 1; c < a.Cols; c++)
            for (int r = 0; r < c; r++)
                a[r, c] = 0.0;
        return a;
    }
}

public class MatrixUpper : MatrixExpression
{
    readonly MatrixExpression E;
    public MatrixUpper(MatrixExpression a) => E = a;
    public override matrix Evaluate()
    {
        var a = E.Evaluate();
        if (E is MatrixInput) a = Matrix.Copy(a);
        for (int c = 0; c < a.Cols; c++)
            for (int r = c + 1; r < a.Rows; r++)
                a[r, c] = 0.0;
        return a;
    }
}

public class MatrixCholesky : MatrixExpression
{
    readonly MatrixExpression E;
    public MatrixCholesky(MatrixExpression a) => E = a;
    public override matrix Evaluate()
    {
        var a = new MatrixLower(E).Evaluate();
        if (a.Rows != a.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
        ThrowHelper.Check(Lapack.potrf2(Layout.ColMajor, UpLoChar.Lower, a.Rows, a.Array, a.Rows));
        return a;
    }
}

public class MatrixSolve : MatrixExpression
{
    readonly MatrixExpression Ea, Eb;
    public MatrixSolve(MatrixExpression a, MatrixExpression b)
    {
        Ea = a;
        Eb = b;
    }
    public override matrix Evaluate()
    {
        var a = Ea.Evaluate();
        var b = Eb.Evaluate();
        if (a.Rows != a.Cols || a.Rows != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
        if (Ea is MatrixInput) a = Matrix.Copy(a);
        if (Eb is MatrixInput) b = Matrix.Copy(b);
        var ipiv = Pool.Int.Rent(a.Rows);
        ThrowHelper.Check(Lapack.gesv(Layout.ColMajor, a.Rows, b.Cols, a.Array, a.Rows, ipiv, b.Array, a.Rows));
        Pool.Int.Return(ipiv);
        if (Ea is not MatrixInput) a.Dispose();
        return b;
    }
}

public class MatrixLeastSquares : MatrixExpression
{
    readonly MatrixExpression Ea, Eb;
    public MatrixLeastSquares(MatrixExpression a, MatrixExpression b)
    {
        Ea = a;
        Eb = b;
    }
    public override matrix Evaluate()
    {
        var a = Ea.Evaluate();
        var b = Eb.Evaluate();
        if (a.Rows != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
        if (Ea is MatrixInput) a = Matrix.Copy(a);
        if (Eb is MatrixInput) b = Matrix.Copy(b);
        Lapack.gels(Layout.RowMajor, TransChar.No, a.Rows, a.Cols, b.Cols, a.Array, a.Cols, b.Array, b.Cols);
        if (Ea is not MatrixInput) a.Dispose();
        return b;
    }
}