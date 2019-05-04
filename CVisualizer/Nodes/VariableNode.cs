namespace CVisualizer
{
    public class VariableNode : Node
    {
        public VariableNode()
        {
            Label = "x";
        }
        public override double Calculate(double x)
        {
            return x;
        }
        public override string ToString()
        {
            return "x";
        }
        public override Node ReturnDerivative(double x)
        {
            return new NaturalNumberNode(1);
        }
        public override Node Simplify()
        {
            return this;
        }
        public override string ToPrefixString()
        {
            return ToString();
        }
        public override Node Copy()
        {
            return new VariableNode();
        }
    }
}
