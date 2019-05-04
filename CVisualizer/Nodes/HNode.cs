using System;

namespace CVisualizer
{
    class HNode : NumberNode
    {
        public HNode()
        {
            Label = "h";
        }
        public override double Calculate(double x)
        {
            return 0.001;
        }
        public override string ToString()
        {
            return "h";
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
            return new HNode();
        }
    }
}
