using System;

namespace CVisualizer
{
    public class SineFunction : Operation
    {
        public SineFunction(Node child) : base(child)
        {
            Label = "sin";
            ShortLabel = "s";
        }
        public override double Calculate(double x)
        {
            return Math.Sin(child.Calculate(x));
        }
        public override string ToString()
        {
            return "sin(" + child.ToString() + ")";
        }
        public override Node ReturnDerivative(double x)
        {
            CosineFunction cosineNode = new CosineFunction(child.Copy());
            Node childDerivative = child.ReturnDerivative(x);
            MultiplicationSign multiplicationSign = new MultiplicationSign(cosineNode, childDerivative);
            return multiplicationSign;
        }
        public override Node Simplify()
        {
            return new SineFunction(child.Simplify());
        }
        public override Node Copy()
        {
            return new SineFunction(child.Copy());
        }
    }
}
