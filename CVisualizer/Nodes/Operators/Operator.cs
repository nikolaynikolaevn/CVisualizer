using System;

namespace CVisualizer
{
    public abstract class Operator : Node
    {
        protected Node leftNode;
        protected Node rightNode;
        public Operator(Node leftNode, Node rightNode)
        {
            this.leftNode = leftNode;
            this.rightNode = rightNode;
        }
        public Node ReturnLeftNode()
        {
            return leftNode;
        }
        public Node ReturnRightNode()
        {
            return rightNode;
        }
        public override string ToPrefixString()
        {
            string s = this.ShortLabel + "(";
            if (leftNode != null) s += leftNode.ToPrefixString();
            s += "," + rightNode.ToPrefixString() + ")";
            return s;
        }
    }
}
