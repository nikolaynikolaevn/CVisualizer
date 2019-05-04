namespace CVisualizer
{
    public abstract class NumberNode : Node
    {
        public override Node ReturnDerivative(double x)
        {
            return new NaturalNumberNode(0);
        }
    }
}
