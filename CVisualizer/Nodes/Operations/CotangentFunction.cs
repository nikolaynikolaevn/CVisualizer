using System;

namespace CVisualizer
{
    class CotangentFunction : Operation
    {
        public CotangentFunction(Node child) : base(child)
        {
            Label = "cot";
            ShortLabel = "ct";
        }
        public override double Calculate(double x)
        {
            return 1 / Math.Tan(child.Calculate(x));
        }
        public override string ToString()
        {
            return "cot(" + child.ToString() + ")";
        }
        public override Node ReturnDerivative(double x)
        {
            SineFunction sineNode = new SineFunction(child.Copy());
            CosineFunction cosineNode = new CosineFunction(child.Copy());
            DivisionSign division = new DivisionSign(cosineNode, sineNode);
            return division.ReturnDerivative(x);
        }
        public override Node Simplify()
        {
            return new CotangentFunction(child.Simplify());
        }
        public override Node Copy()
        {
            return new CotangentFunction(child.Copy());
        }
    }
}
