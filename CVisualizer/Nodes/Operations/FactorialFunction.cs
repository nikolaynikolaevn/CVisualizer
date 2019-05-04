using System;

namespace CVisualizer
{
    public class FactorialFunction : Operation
    {
        public FactorialFunction(Node child) : base(child)
        {
            Label = "!";
            ShortLabel = Label;
        }
        public override double Calculate(double x)
        {
            int value;
            int.TryParse(child.Calculate(x).ToString(), out value);
            if (value >= 0) return CalculateFactorial(value);
            throw new NotImplementedException();
        }
        private int CalculateFactorial(int x)
        {
            if (x <= 1) return 1;
            return x * CalculateFactorial(x - 1);
        }
        public override string ToString()
        {
            return child.ToString() + "!";
        }
        public override Node ReturnDerivative(double x)
        {
            if (child is NaturalNumberNode) return new NaturalNumberNode(0);
            throw new NotImplementedException();
        }
        public override Node Simplify()
        {
            return new FactorialFunction(child.Simplify());
        }
        public override Node Copy()
        {
            return new FactorialFunction(child.Copy());
        }
    }
}
