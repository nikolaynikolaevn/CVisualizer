using System;

namespace CVisualizer
{
    public class ExponentialFunction : Operation
    {
        public ExponentialFunction(Node child) : base(child)
        {
            Label = "e";
            ShortLabel = Label;
        }
        public override double Calculate(double x)
        {
            return Math.Exp(child.Calculate(x));
        }
        public override string ToString()
        {
            return "e^" + child.ToString();
        }
        public override Node ReturnDerivative(double x)
        {
            ExponentialFunction exponentialFunction = new ExponentialFunction(child.Copy());
            MultiplicationSign multiplicationSign = new MultiplicationSign(exponentialFunction, child.ReturnDerivative(x));
            return multiplicationSign;
        }
        public override Node Simplify()
        {
            Node simplifiedChild = child.Simplify();
            if (simplifiedChild.Calculate(1) == 0) return new NaturalNumberNode(1); //e^0 = 1
            else if(simplifiedChild is LogarithmFunction) //e^ln(5) = 5
            {
                return ((Operation)simplifiedChild).ReturnChild().Simplify();
            }
            return new ExponentialFunction(simplifiedChild);
        }
        public override Node Copy()
        {
            return new ExponentialFunction(child.Copy());
        }
    }
}
