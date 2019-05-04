using System;

namespace CVisualizer
{
    public class CaretSign : Operator
    {
        public CaretSign(Node leftNode, Node rightNode) : base(leftNode, rightNode)
        {
            Label = "^";
            ShortLabel = Label;
        }
        public override double Calculate(double x)
        {
            return Math.Pow(leftNode.Calculate(x), rightNode.Calculate(x));
        }
        public override string ToString()
        {
            return leftNode.ToString() + "^" + rightNode.ToString();
        }
        public override Node ReturnDerivative(double x)
        {
            if (leftNode is NumberNode && rightNode is NumberNode) return new NaturalNumberNode(0);
            else if (leftNode is VariableNode && (rightNode is NaturalNumberNode || rightNode is RationalNumberNode))
            {
                RationalNumberNode rationalNumberNodeA = new RationalNumberNode(rightNode.Calculate(x));
                RationalNumberNode rationalNumberNodeB = new RationalNumberNode(rightNode.Calculate(x) - 1);
                CaretSign caretSign = new CaretSign(leftNode.Copy(), rationalNumberNodeB);
                MultiplicationSign multiplicationSign = new MultiplicationSign(rationalNumberNodeA, caretSign);
                return multiplicationSign;
            }
            else if (leftNode is NumberNode)
            {
                LogarithmFunction logarithmFunction = new LogarithmFunction(leftNode.Copy());
                CaretSign caretSign = new CaretSign(leftNode.Copy(), rightNode.Copy());
                MultiplicationSign multiplicationSignA = new MultiplicationSign(logarithmFunction, caretSign);
                MultiplicationSign multiplicationSignB = new MultiplicationSign(multiplicationSignA, caretSign.rightNode.ReturnDerivative(x));
                return multiplicationSignB;
            }
            else
            {
                MinusSign minusSign = new MinusSign(rightNode.Copy(), new NaturalNumberNode(1));
                CaretSign caretSign = new CaretSign(leftNode.Copy(), minusSign);
                MultiplicationSign multiplicationSignA = new MultiplicationSign(rightNode.Copy(), caretSign);
                MultiplicationSign multiplicationSignB = new MultiplicationSign(multiplicationSignA, leftNode.ReturnDerivative(x));
                return multiplicationSignB;
            }
        }
        public override Node Simplify()
        {
            Node simplifiedLeftNode = leftNode.Simplify();
            Node simplifiedRightNode = rightNode.Simplify();
            if ((simplifiedLeftNode is NaturalNumberNode && simplifiedLeftNode.Calculate(0) == 1 && simplifiedRightNode is NumberNode)
                || simplifiedRightNode.Calculate(0) == 1) return simplifiedLeftNode; //1^5 = 1, 5^1 = 5
            else if (simplifiedRightNode is NumberNode && simplifiedRightNode.Calculate(0) == 0) return new NaturalNumberNode(1); //100^0 = 1
            else if (simplifiedLeftNode is NumberNode && simplifiedLeftNode.Calculate(0) == 0) return new NaturalNumberNode(0); //0^100 = 0
            else if (simplifiedLeftNode is NumberNode && !(simplifiedLeftNode is IrrationalNumberNode) 
                && simplifiedRightNode is NumberNode && !(simplifiedRightNode is IrrationalNumberNode)) //5^2 = 25
            {
                double valueA = 0;
                double valueB = 0;
                if (simplifiedLeftNode is RationalNumberNode) valueA = ((RationalNumberNode)simplifiedLeftNode).Value;
                if (simplifiedLeftNode is NaturalNumberNode) valueA = ((NaturalNumberNode)simplifiedLeftNode).Value;
                if (simplifiedRightNode is RationalNumberNode) valueB = ((RationalNumberNode)simplifiedRightNode).Value;
                if (simplifiedRightNode is NaturalNumberNode) valueB = ((NaturalNumberNode)simplifiedRightNode).Value;
                return new RationalNumberNode(Math.Pow(valueA, valueB));
            }
            else if (simplifiedLeftNode is ExponentialFunction) //(e^5)^3 = e^15
                return new ExponentialFunction(new MultiplicationSign(((Operation)simplifiedLeftNode).ReturnChild().Simplify(), simplifiedRightNode).Simplify());
            else return new CaretSign(simplifiedLeftNode, simplifiedRightNode);
        }
        public override Node Copy()
        {
            return new CaretSign(leftNode.Copy(), rightNode.Copy());
        }
    }
}
