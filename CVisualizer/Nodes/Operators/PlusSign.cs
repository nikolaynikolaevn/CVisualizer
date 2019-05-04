using System;

namespace CVisualizer
{
    public class PlusSign : Operator
    {
        public PlusSign(Node leftNode, Node rightNode) : base(leftNode, rightNode)
        {
            Label = "+";
            ShortLabel = Label;
        }
        public override double Calculate(double x)
        {
            return leftNode.Calculate(x) + rightNode.Calculate(x);
        }
        public override string ToString()
        {
            return "(" + leftNode.ToString() + " + " + rightNode.ToString() + ")";
        }
        public override Node ReturnDerivative(double x)
        {
            return new PlusSign(leftNode.ReturnDerivative(x), rightNode.ReturnDerivative(x));
        }
        public override Node Simplify()
        {
            Node simplifiedLeftNode = leftNode.Simplify();
            Node simplifiedRightNode = rightNode.Simplify();
            if (simplifiedLeftNode is NumberNode && simplifiedLeftNode.Calculate(0) == 0) return simplifiedRightNode; //0 + 5 = 5
            else if (simplifiedRightNode is NumberNode && simplifiedRightNode.Calculate(0) == 0) return simplifiedLeftNode; //5 + 0 = 0
            else if (simplifiedLeftNode is VariableNode && simplifiedRightNode is VariableNode) //x + x = 2 * x
                return new MultiplicationSign(new NaturalNumberNode(2), simplifiedLeftNode);
            else if (simplifiedLeftNode is NumberNode && simplifiedRightNode is NumberNode
                && (!(simplifiedLeftNode is IrrationalNumberNode) && !(simplifiedRightNode is IrrationalNumberNode))) //2 + 5 = 7
            {
                double valueA = 0;
                double valueB = 0;
                if (simplifiedLeftNode is RationalNumberNode) valueA = ((RationalNumberNode)simplifiedLeftNode).Value;
                if (simplifiedLeftNode is NaturalNumberNode) valueA = ((NaturalNumberNode)simplifiedLeftNode).Value;
                if (simplifiedRightNode is RationalNumberNode) valueB = ((RationalNumberNode)simplifiedRightNode).Value;
                if (simplifiedRightNode is NaturalNumberNode) valueB = ((NaturalNumberNode)simplifiedRightNode).Value;
                return new RationalNumberNode(valueA + valueB);
            }
            else if ((simplifiedLeftNode is VariableNode || simplifiedLeftNode is IrrationalNumberNode)
                && simplifiedRightNode is MultiplicationSign) //x + 4x = 5x, p + 4p = 5p
            {
                MultiplicationSign simplifiedMultiplicationRightNode = (MultiplicationSign)simplifiedRightNode;
                double valueA = 0;
                if (simplifiedMultiplicationRightNode.ReturnRightNode() is VariableNode || simplifiedMultiplicationRightNode.ReturnRightNode() is IrrationalNumberNode)
                {
                    if (simplifiedMultiplicationRightNode.ReturnRightNode().GetType() == simplifiedLeftNode.GetType())
                    {
                        if (simplifiedMultiplicationRightNode.ReturnLeftNode() is RationalNumberNode)
                            valueA = ((RationalNumberNode)simplifiedMultiplicationRightNode.ReturnLeftNode()).Value;
                        if (simplifiedMultiplicationRightNode.ReturnLeftNode() is NaturalNumberNode)
                            valueA = ((NaturalNumberNode)simplifiedMultiplicationRightNode.ReturnLeftNode()).Value;
                        return new MultiplicationSign(new RationalNumberNode(valueA + 1), simplifiedMultiplicationRightNode.ReturnRightNode());
                    }
                    return new PlusSign(simplifiedLeftNode, simplifiedRightNode);
                }
                else
                {
                    if (simplifiedMultiplicationRightNode.ReturnLeftNode().GetType() == simplifiedLeftNode.GetType())
                    {
                        if (simplifiedMultiplicationRightNode.ReturnRightNode() is RationalNumberNode)
                            valueA = ((RationalNumberNode)simplifiedMultiplicationRightNode.ReturnRightNode()).Value;
                        if (simplifiedMultiplicationRightNode.ReturnRightNode() is NaturalNumberNode)
                            valueA = ((NaturalNumberNode)simplifiedMultiplicationRightNode.ReturnRightNode()).Value;
                        return new MultiplicationSign(new RationalNumberNode(valueA + 1), simplifiedMultiplicationRightNode.ReturnLeftNode());
                    }
                    return new PlusSign(simplifiedLeftNode, simplifiedRightNode);
                }
            }
            else if (simplifiedLeftNode is MultiplicationSign
                && (simplifiedRightNode is VariableNode || simplifiedRightNode is IrrationalNumberNode)) //4x + x = 5x, 4p + p = 5p
            {
                MultiplicationSign simplifiedMultiplicationLeftNode = (MultiplicationSign)simplifiedLeftNode;
                double valueA = 0;
                if (simplifiedMultiplicationLeftNode.ReturnRightNode() is VariableNode || simplifiedMultiplicationLeftNode.ReturnRightNode() is IrrationalNumberNode)
                {
                    if (simplifiedMultiplicationLeftNode.ReturnRightNode().GetType() == simplifiedRightNode.GetType())
                    {
                        if (simplifiedMultiplicationLeftNode.ReturnLeftNode() is RationalNumberNode) valueA = ((RationalNumberNode)simplifiedMultiplicationLeftNode.ReturnLeftNode()).Value;
                        if (simplifiedMultiplicationLeftNode.ReturnLeftNode() is NaturalNumberNode) valueA = ((NaturalNumberNode)simplifiedMultiplicationLeftNode.ReturnLeftNode()).Value;
                        return new MultiplicationSign(new RationalNumberNode(valueA + 1), simplifiedMultiplicationLeftNode.ReturnRightNode());
                    }
                    return new PlusSign(simplifiedLeftNode, simplifiedRightNode);
                }
                else
                {
                    if (simplifiedMultiplicationLeftNode.ReturnLeftNode().GetType() == simplifiedRightNode.GetType())
                    {
                        if (simplifiedMultiplicationLeftNode.ReturnRightNode() is RationalNumberNode) valueA = ((RationalNumberNode)simplifiedMultiplicationLeftNode.ReturnRightNode()).Value;
                        if (simplifiedMultiplicationLeftNode.ReturnRightNode() is NaturalNumberNode) valueA = ((NaturalNumberNode)simplifiedMultiplicationLeftNode.ReturnRightNode()).Value;
                        return new MultiplicationSign(new RationalNumberNode(valueA + 1), simplifiedMultiplicationLeftNode.ReturnLeftNode());
                    }
                    return new PlusSign(simplifiedLeftNode, simplifiedRightNode);
                }
            }
            else if (simplifiedLeftNode is IrrationalNumberNode
                && simplifiedRightNode is IrrationalNumberNode && simplifiedLeftNode.Calculate(0) == simplifiedRightNode.Calculate(0)) //p + p = 2 * p
                return new MultiplicationSign(new NaturalNumberNode(2), simplifiedLeftNode);
            else if (simplifiedLeftNode is LogarithmFunction && simplifiedRightNode is LogarithmFunction) //ln(5) + ln(2) = ln(10)
                return new LogarithmFunction(new MultiplicationSign(((Operation)simplifiedLeftNode).ReturnChild().Simplify(),
                    ((Operation)simplifiedRightNode).ReturnChild().Simplify())).Simplify();
            else if (simplifiedLeftNode is MultiplicationSign && simplifiedRightNode is MultiplicationSign
                && ((((Operator)simplifiedLeftNode).ReturnRightNode() is VariableNode && ((Operator)simplifiedRightNode).ReturnRightNode() is VariableNode)
                || (((Operator)simplifiedLeftNode).ReturnRightNode() is PiNode && ((Operator)simplifiedRightNode).ReturnRightNode() is PiNode))) //2x + 3x = 5x, 2p + 3p = 5p
            {
                if (((Operator)simplifiedLeftNode).ReturnLeftNode() is NumberNode
                    && Math.Abs(((Operator)simplifiedLeftNode).ReturnLeftNode().Calculate(1) % 1) <= (Double.Epsilon * 100)
                    && ((Operator)simplifiedRightNode).ReturnLeftNode() is NumberNode
                    && Math.Abs(((Operator)simplifiedRightNode).ReturnLeftNode().Calculate(1) % 1) <= (Double.Epsilon * 100))
                    return new MultiplicationSign(new NaturalNumberNode(
                        Convert.ToInt32(((Operator)simplifiedLeftNode).ReturnLeftNode().Calculate(1) + ((Operator)simplifiedRightNode).ReturnLeftNode().Calculate(1))),
                        ((Operator)simplifiedLeftNode).ReturnRightNode()).Simplify();
                else return new PlusSign(simplifiedLeftNode, simplifiedRightNode);
            }
            else return new PlusSign(simplifiedLeftNode, simplifiedRightNode);
        }
        public override Node Copy()
        {
            return new PlusSign(leftNode.Copy(), rightNode.Copy());
        }
    }
}
