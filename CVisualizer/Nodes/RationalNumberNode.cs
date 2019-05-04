namespace CVisualizer
{
    public class RationalNumberNode : NumberNode
    {
        private double value;
        public double Value
        {
            get { return value; }
        }
        public RationalNumberNode(double value)
        {
            this.value = value;
            Label = value.ToString();
        }
        public override double Calculate(double x)
        {
            return value;
        }
        public override string ToString()
        {
            return value.ToString();
        }
        public override Node Simplify()
        {
            return this;
        }
        public override string ToPrefixString()
        {
            return "r(" + ToString() + ")";
        }
        public override Node Copy()
        {
            return new RationalNumberNode(value);
        }
    }
}
