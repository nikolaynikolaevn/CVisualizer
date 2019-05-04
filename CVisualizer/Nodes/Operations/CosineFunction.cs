using System;

namespace CVisualizer
{
    public class CosineFunction : Operation
    {
        public CosineFunction(Node child) : base(child)
        {
            Label = "cos";
            ShortLabel = "c";
        }
        public override double Calculate(double x)
        {
            return Math.Cos(child.Calculate(x));
        }
        public override string ToString()
        {
            return "cos(" + child.ToString() + ")";
        }
        public override Node ReturnDerivative(double x)
        {
            NaturalNumberNode zero = new NaturalNumberNode(0);
            SineFunction sineNode = new SineFunction(child.Copy());
            MinusSign minusNode = new MinusSign(zero, sineNode);
            Node childDerivative = child.ReturnDerivative(x);
            MultiplicationSign multiplicationSign = new MultiplicationSign(minusNode, childDerivative);
            return multiplicationSign;
        }
        public override Node Simplify()
        {
            return new CosineFunction(child.Simplify());
        }
        public override Node Copy()
        {
            return new CosineFunction(child.Copy());
        }
    }
}
