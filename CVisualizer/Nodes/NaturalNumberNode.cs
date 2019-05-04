namespace CVisualizer
{
    public class NaturalNumberNode : NumberNode
    {
        private int value;
        public int Value
        {
            get { return value; }
        }
        public NaturalNumberNode(int value)
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
            if (ToString().Length > 1) return "n(" + ToString() + ")";
            else return ToString();
        }
        public override Node Copy()
        {
            return new NaturalNumberNode(value);
        }
    }
}
