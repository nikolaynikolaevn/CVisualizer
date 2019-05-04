using System;

namespace CVisualizer
{
    public class MultiplicationSign : Operator
    {
        public MultiplicationSign(Node leftNode, Node rightNode) : base(leftNode, rightNode)
        {
            Label = "*";
            ShortLabel = Label;
        }
        public override double Calculate(double x)
        {
            return leftNode.Calculate(x) * rightNode.Calculate(x);
        }
        public override string ToString()
        {
            return leftNode.ToString() + " * " + rightNode.ToString();
        }
        public override Node ReturnDerivative(double x)
        {
            if (leftNode is NumberNode)
            {
                return new MultiplicationSign(leftNode.Copy(), rightNode.ReturnDerivative(x));
            }
            else if (rightNode is NumberNode)
            {
                return new MultiplicationSign(rightNode.Copy(), leftNode.ReturnDerivative(x));
            }
            else
            {
                MultiplicationSign multiplicationSignA = new MultiplicationSign(leftNode.ReturnDerivative(x), rightNode.Copy());
                MultiplicationSign multiplicationSignB = new MultiplicationSign(leftNode.Copy(), rightNode.ReturnDerivative(x));
                PlusSign plusSign = new PlusSign(multiplicationSignA, multiplicationSignB);
                return plusSign;
            }
        }
        public override Node Simplify()
        {
            Node simplifiedLeftNode = leftNode.Simplify();
            Node simplifiedRightNode = rightNode.Simplify();
            if (simplifiedLeftNode is NaturalNumberNode && simplifiedLeftNode.Calculate(0) == 1) return simplifiedRightNode; //1 * 5 = 5
            else if (simplifiedRightNode is NaturalNumberNode && simplifiedRightNode.Calculate(0) == 1) return simplifiedLeftNode; //5 * 1 = 5
            else if (simplifiedLeftNode is NaturalNumberNode && simplifiedLeftNode.Calculate(0) == 0
                || simplifiedRightNode is NaturalNumberNode && simplifiedRightNode.Calculate(0) == 0) return new NaturalNumberNode(0); //0 * 5 = 0, 5 * 0 = 0
            else if ((simplifiedLeftNode is TangentFunction && simplifiedRightNode is CotangentFunction)
                || (simplifiedLeftNode is CotangentFunction && simplifiedRightNode is TangentFunction)) // tan(x) * cotg(x) = 1
            {
                double childValueA = ((Operation)simplifiedLeftNode).ReturnChild().Calculate(5);
                double childValueB = ((Operation)simplifiedRightNode).ReturnChild().Calculate(5);
                if (childValueA == childValueB) return new NaturalNumberNode(1);
                return new MultiplicationSign(simplifiedLeftNode, simplifiedRightNode);
            }
            else if ((simplifiedLeftNode is TangentFunction && simplifiedRightNode is CosineFunction)
                || (simplifiedLeftNode is CosineFunction && simplifiedRightNode is TangentFunction) &&
            ((Operation)simplifiedLeftNode).ReturnChild().Calculate(5) == ((Operation)simplifiedRightNode).ReturnChild().Calculate(5)) //tan(x) * cos(x) = sin(x)
            {
                Node child = ((Operation)simplifiedLeftNode).ReturnChild();
                return new SineFunction(child);
            }
            else if ((simplifiedLeftNode is CotangentFunction && simplifiedRightNode is SineFunction)
                || (simplifiedLeftNode is SineFunction && simplifiedRightNode is CotangentFunction) &&
            ((Operation)simplifiedLeftNode).ReturnChild().Calculate(5) == ((Operation)simplifiedRightNode).ReturnChild().Calculate(5)) //cotg(x) * sin(x) = cos(x)
            {
                Node child = ((Operation)simplifiedLeftNode).ReturnChild();
                return new CosineFunction(child);
            }
            else if (simplifiedLeftNode is NumberNode && simplifiedRightNode is NumberNode
                && (!(simplifiedLeftNode is IrrationalNumberNode) && !(simplifiedRightNode is IrrationalNumberNode))) //5 * 2 = 10
            {
                double valueA = 0;
                double valueB = 0;
                if (simplifiedLeftNode is RationalNumberNode) valueA = ((RationalNumberNode)simplifiedLeftNode).Value;
                if (simplifiedLeftNode is NaturalNumberNode) valueA = ((NaturalNumberNode)simplifiedLeftNode).Value;
                if (simplifiedRightNode is RationalNumberNode) valueB = ((RationalNumberNode)simplifiedRightNode).Value;
                if (simplifiedRightNode is NaturalNumberNode) valueB = ((NaturalNumberNode)simplifiedRightNode).Value;
                return new RationalNumberNode(valueA * valueB);
            }
            else if (simplifiedLeftNode is ExponentialFunction && simplifiedRightNode is ExponentialFunction) //e^3 * e^2 = e^5
                return new ExponentialFunction(new PlusSign(((Operation)simplifiedLeftNode).ReturnChild().Simplify(),
                    ((Operation)simplifiedRightNode).ReturnChild().Simplify()).Simplify());
            else if (simplifiedLeftNode is VariableNode && simplifiedRightNode is NumberNode) //x * 5 = 5 * x
                return new MultiplicationSign(simplifiedRightNode, simplifiedLeftNode).Simplify();
            else if (simplifiedLeftNode is PiNode && simplifiedRightNode is NumberNode && !(simplifiedRightNode is IrrationalNumberNode)) //p * 5 = 5 * p
                return new MultiplicationSign(simplifiedRightNode, simplifiedLeftNode).Simplify();
            else if (simplifiedLeftNode is NumberNode && simplifiedRightNode is MultiplicationSign
                && ((MultiplicationSign)simplifiedRightNode).ReturnLeftNode().Simplify() is NaturalNumberNode) //5 * (2 * x) = 10 * x
                return new MultiplicationSign(
                    new RationalNumberNode(simplifiedLeftNode.Calculate(1) * ((MultiplicationSign)simplifiedRightNode).ReturnLeftNode().Simplify().Calculate(1)),
                    ((MultiplicationSign)simplifiedRightNode).ReturnRightNode().Simplify());
            else if (simplifiedLeftNode is MultiplicationSign && simplifiedRightNode is MultiplicationSign
                && ((MultiplicationSign)simplifiedRightNode).ReturnLeftNode().Simplify() is NaturalNumberNode) //(5 * x) * (2 * p) = 10 * p * x
                return new MultiplicationSign(
                    new RationalNumberNode(((MultiplicationSign)simplifiedLeftNode).ReturnLeftNode().Simplify().Calculate(1)
                    * ((MultiplicationSign)simplifiedRightNode).ReturnLeftNode().Simplify().Calculate(1)),
                    new MultiplicationSign(((MultiplicationSign)simplifiedLeftNode).ReturnRightNode().Simplify(),
                    ((MultiplicationSign)simplifiedRightNode).ReturnRightNode().Simplify())).Simplify();
            else if (simplifiedLeftNode is VariableNode && simplifiedRightNode is VariableNode) //x * x = x^2
                return new CaretSign(simplifiedLeftNode, new NaturalNumberNode(2));
            else if (simplifiedLeftNode is MultiplicationSign && simplifiedRightNode is VariableNode) //(5 * x) * x = 5 * x^2
            {
                MultiplicationSign multiplicationSign = (MultiplicationSign)simplifiedLeftNode;
                if (multiplicationSign.ReturnLeftNode() is NaturalNumberNode && multiplicationSign.ReturnRightNode() is VariableNode)
                    return new MultiplicationSign(multiplicationSign.ReturnLeftNode(), new CaretSign(simplifiedRightNode, new NaturalNumberNode(2)));
                else return new MultiplicationSign(simplifiedLeftNode, simplifiedRightNode);
            }
            else return new MultiplicationSign(simplifiedLeftNode, simplifiedRightNode);
        }
        public override Node Copy()
        {
            return new MultiplicationSign(leftNode.Copy(), rightNode.Copy());
        }
    }
}
