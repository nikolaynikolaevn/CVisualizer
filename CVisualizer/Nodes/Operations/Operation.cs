using System;

namespace CVisualizer
{
    public abstract class Operation : Node
    {
        protected Node child;
        public Operation(Node child)
        {
            this.child = child;
        }
        public Node ReturnChild()
        {
            return child;
        }
        public override string ToPrefixString()
        {
            return this.ShortLabel + "(" + child.ToPrefixString() + ")";
        }
    }
}
