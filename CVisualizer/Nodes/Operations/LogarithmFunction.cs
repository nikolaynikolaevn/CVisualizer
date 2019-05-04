using System;

namespace CVisualizer
{
    public class LogarithmFunction : Operation
    {
        private Node logBase;
        public LogarithmFunction(Node logNumber) : base(logNumber)
        {
            logBase = null;
            Label = "ln";
            ShortLabel = "l";
        }
        public LogarithmFunction(Node logNumber, Node logBase) : base(logNumber)
        {
            this.logBase = logBase;
        }
        public override double Calculate(double x)
        {
            if (logBase == null) return Math.Log(child.Calculate(x));
            return Math.Log(child.Calculate(x), logBase.Calculate(x));
        }
        public override string ToString()
        {
            if (logBase == null) return "ln(" + child.ToString() + ")";
            return "log(" + logBase + ", " + child + ")";
        }
        public override Node ReturnDerivative(double x)
        {
            if (Calculate(x) > 0)
            {
                Node childDerivative = child.ReturnDerivative(x);
                DivisionSign divisionSignA = new DivisionSign(childDerivative, child.Copy());
                return divisionSignA;
            }
            return new RationalNumberNode(Double.NaN);

        }
        public override Node Simplify()
        {
            Node simplifiedChild = child.Simplify();
            if (child.Calculate(0) == 1) return new NaturalNumberNode(0); //ln(1) = 0
            else if (simplifiedChild is ExponentialFunction && ((Operation)simplifiedChild).ReturnChild() is NumberNode) //ln(e^5) = 5
            {
                return ((Operation)simplifiedChild).ReturnChild();
            }
            else if (simplifiedChild is CaretSign)
            {
                Node coefficient = ((Operator)simplifiedChild).ReturnRightNode().Simplify();
                if (coefficient.Calculate(2) % 2 == 1) //ln(x^3) = 3 * ln(x)
                    return new MultiplicationSign(coefficient, new LogarithmFunction(((Operator)simplifiedChild).ReturnLeftNode().Simplify())).Simplify();
            }
            return new LogarithmFunction(simplifiedChild);
        }
        public override Node Copy()
        {
            return new LogarithmFunction(child.Copy());
        }
    }
}
