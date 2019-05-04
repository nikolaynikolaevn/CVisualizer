using System;

namespace CVisualizer
{
    public class PiNode : IrrationalNumberNode
    {
        public PiNode()
        {
            Label = "pi";
        }
        public override double Calculate(double x)
        {
            return Math.PI;
        }
        public override string ToString()
        {
            return "π";
        }
        public override Node Simplify()
        {
            return this;
        }
        public override string ToPrefixString()
        {
            return "p";
        }
        public override Node Copy()
        {
            return new PiNode();
        }
    }
}