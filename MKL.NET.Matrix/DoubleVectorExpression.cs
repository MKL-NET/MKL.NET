namespace MKLNET.Expression
{
    public abstract class VectorExpression : MatrixExpression
    {
        public abstract vector EvaluteVector();
        public override matrix EvaluateMatrix() => EvaluteVector();
        public new VectorTranspose T => new(this);
        public static implicit operator VectorExpression(vector m) => new VectorInput(m);
        public static implicit operator vector(VectorExpression m) => m.EvaluteVector();
        public static VectorAddScalar operator +(VectorExpression a, double s) => new(a, s);
        public static VectorAddScalar operator +(double s, VectorExpression b) => new(b, s);
        public static VectorAddScalar operator -(VectorExpression m, double s) => new(m, -s);
        public static VectorScalarSub operator -(double s, VectorExpression m) => new(m, s);
        public static VectorAdd operator +(VectorExpression a, VectorExpression b) => new(a, b);
        public static VectorSub operator -(VectorExpression a, VectorExpression b) => new(a, b);
        public static VectorExpression operator *(VectorExpression a, double s) =>
            a is VectorScale sa ? new VectorScale(sa.E, sa.S * s)
            : new VectorScale(a, s);
        public static VectorExpression operator *(double s, VectorExpression a) =>
            a is VectorScale sa ? new VectorScale(sa.E, sa.S * s)
            : new VectorScale(a, s);
    }

    public abstract class VectorTExpression : MatrixExpression
    {
        public abstract vectorT EvaluteVector();
        public override matrix EvaluateMatrix() => EvaluteVector();
        public new VectorTTranspose T => new(this);
        public static implicit operator VectorTExpression(vectorT m) => new VectorTInput(m);
        public static implicit operator vectorT(VectorTExpression m) => m.EvaluteVector();
        public static VectorTAddScalar operator +(VectorTExpression m, double s) => new(m, s);
        public static VectorTAddScalar operator +(double s, VectorTExpression m) => new(m, s);
        public static VectorTAddScalar operator -(VectorTExpression m, double s) => new(m, -s);
        public static VectorTScalarSub operator -(double s, VectorTExpression m) => new(m, s);
        public static VectorTAdd operator +(VectorTExpression a, VectorTExpression b) => new(a, b);
        public static VectorTSub operator -(VectorTExpression a, VectorTExpression b) => new(a, b);
    }

    public class VectorInput : VectorExpression, Input
    {
        readonly vector m;
        public VectorInput(vector a) => m = a;
        public override vector EvaluteVector() => m;
    }

    public class VectorTInput : VectorTExpression, Input
    {
        readonly vectorT m;
        public VectorTInput(vectorT a) => m = a;
        public override vectorT EvaluteVector() => m;
    }


    public class VectorResult : VectorExpression // This is not rerunable, need to make classes for all uses
    {
        readonly vector m;
        public VectorResult(vector a) => m = a;
        public override vector EvaluteVector() => m;
    }

    public class VectorTResult : VectorTExpression // This is not rerunable, need to make classes for all uses
    {
        readonly vectorT m;
        public VectorTResult(vectorT a) => m = a;
        public override vectorT EvaluteVector() => m;
    }

    public class VectorScale : VectorExpression, IScale
    {
        public readonly VectorExpression E;
        public readonly double S;
        public VectorScale(VectorExpression a, double s)
        {
            E = a;
            S = s;
        }
        MatrixExpression IScale.E => E;
        double IScale.S => S;

        public override vector EvaluteVector()
        {
            var m = new MatrixScale(E, S).EvaluateMatrix();
            return new(m.Rows, m.Array);
        }
        public static VectorScale operator *(VectorScale a, double b) => new(a.E, a.S * b);
        public static VectorScale operator *(double a, VectorScale b) => new(b.E, a * b.S);
    }

    public class VectorTranspose : VectorTExpression
    {
        readonly VectorExpression E;
        public VectorTranspose(VectorExpression a) => E = a;
        public override vectorT EvaluteVector()
        {
            var m = new MatrixTranspose(E).EvaluateMatrix();
            return new(m.Rows, m.Array);
        }
    }

    public class VectorTTranspose : VectorExpression
    {
        readonly vectorT E;
        public VectorTTranspose(vectorT a) => E = a;
        public override vector EvaluteVector()
        {
            var m = new MatrixTranspose(E).EvaluateMatrix();
            return new(m.Rows, m.Array);
        }
    }

    public class VectorAddScalar : VectorExpression
    {
        public readonly VectorExpression E;
        public readonly double S;
        public VectorAddScalar(VectorExpression a, double s)
        {
            E = a;
            S = s;
        }
        public override vector EvaluteVector()
        {
            var m = new MatrixAddScalar(E, S).EvaluateMatrix();
            return new(m.Rows, m.Array);
        }
    }

    public class VectorTAddScalar : VectorTExpression
    {
        public readonly VectorTExpression E;
        public readonly double S;
        public VectorTAddScalar(VectorTExpression a, double s)
        {
            E = a;
            S = s;
        }
        public override vectorT EvaluteVector()
        {
            var m = new MatrixAddScalar(E, S).EvaluateMatrix();
            return new(m.Rows, m.Array);
        }
    }

    public class VectorScalarSub : VectorExpression
    {
        public readonly VectorExpression E;
        public readonly double S;
        public VectorScalarSub(VectorExpression a, double s)
        {
            E = a;
            S = s;
        }
        public override vector EvaluteVector()
        {
            var m = new MatrixScalarSub(E, S).EvaluateMatrix();
            return new(m.Rows, m.Array);
        }
    }

    public class VectorTScalarSub : VectorTExpression
    {
        public readonly VectorTExpression E;
        public readonly double S;
        public VectorTScalarSub(VectorTExpression a, double s)
        {
            E = a;
            S = s;
        }
        public override vectorT EvaluteVector()
        {
            var m = new MatrixScalarSub(E, S).EvaluateMatrix();
            return new(m.Rows, m.Array);
        }
    }

    public class VectorAdd : VectorExpression
    {
        readonly VectorExpression A, B;
        public VectorAdd(VectorExpression a, VectorExpression b)
        {
            A = a;
            B = b;
        }
        public override vector EvaluteVector()
        {
            var m = new MatrixAdd(A, B).EvaluateMatrix();
            return new(m.Rows, m.Array);
        }
    }

    public class VectorTAdd : VectorTExpression
    {
        readonly VectorTExpression A, B;
        public VectorTAdd(VectorTExpression a, VectorTExpression b)
        {
            A = a;
            B = b;
        }
        public override vectorT EvaluteVector()
        {
            var m = new MatrixAdd(A, B).EvaluateMatrix();
            return new(m.Rows, m.Array);
        }
    }

    public class VectorSub : VectorExpression
    {
        readonly VectorExpression A, B;
        public VectorSub(VectorExpression a, VectorExpression b)
        {
            A = a;
            B = b;
        }
        public override vector EvaluteVector()
        {
            var m = new MatrixSub(A, B).EvaluateMatrix();
            return new(m.Rows, m.Array);
        }
    }

    public class VectorTSub : VectorTExpression
    {
        readonly VectorTExpression A, B;
        public VectorTSub(VectorTExpression a, VectorTExpression b)
        {
            A = a;
            B = b;
        }
        public override vectorT EvaluteVector()
        {
            var m = new MatrixSub(A, B).EvaluateMatrix();
            return new(m.Rows, m.Array);
        }
    }

    public abstract class VectorUnary : VectorExpression
    {
        readonly VectorExpression E;
        public VectorUnary(VectorExpression a) => E = a;
        protected abstract void Evaluate(vector a, vector o);
        public override vector EvaluteVector()
        {
            var i = E.EvaluteVector();
            var o = E is VectorInput ? new vector(i.Length) : i;
            Evaluate(i, o);
            return o;
        }
    }
}
