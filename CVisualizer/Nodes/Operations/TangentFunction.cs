using System;

namespace CVisualizer
{
    class TangentFunction : Operation
    {
        public TangentFunction(Node child) : base(child)
        {
            Label = "tan";
            ShortLabel = "t";
        }
        public override double Calculate(double x)
        {
            return Math.Tan(child.Calculate(x));
        }
        public override string ToString()
        {
            return "tan(" + child.ToString() + ")";
        }
        public override Node ReturnDerivative(double x)
        {
            SineFunction sineNode = new SineFunction(child.Copy());
            CosineFunction cosineNode = new CosineFunction(child.Copy());
            DivisionSign division = new DivisionSign(sineNode, cosineNode);
            return division.ReturnDerivative(x);
        }
        public override Node Simplify()
        {
            return new TangentFunction(child.Simplify());
        }
        public override Node Copy()
        {
            return new TangentFunction(child.Copy());
        }
    }
}
