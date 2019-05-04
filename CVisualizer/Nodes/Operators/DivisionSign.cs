using System;

namespace CVisualizer
{
    public class DivisionSign : Operator
    {
        public DivisionSign(Node leftNode, Node rightNode) : base(leftNode, rightNode)
        {
            Label = "/";
            ShortLabel = Label;
        }
        public override double Calculate(double x)
        {
            double a = leftNode.Calculate(x);
            double b = rightNode.Calculate(x);
            try
            {
                if (rightNode.Calculate(x) == 0) throw new DivideByZeroException();
                return leftNode.Calculate(x) / rightNode.Calculate(x);
            }
            catch
            {
                if (a > 0) return Double.PositiveInfinity;
                else return Double.NegativeInfinity; 
            }
}
        public override string ToString()
        {
            return leftNode.ToString() + " / " + rightNode.ToString();
        }
        public override Node ReturnDerivative(double x)
        {
            MultiplicationSign multiplicationSignA = new MultiplicationSign(leftNode.ReturnDerivative(x), rightNode.Copy());
            MultiplicationSign multiplicationSignB = new MultiplicationSign(leftNode.Copy(), rightNode.ReturnDerivative(x));
            MinusSign minusSign = new MinusSign(multiplicationSignA, multiplicationSignB);
            NaturalNumberNode naturalNumberNode = new NaturalNumberNode(2);
            CaretSign caretSign = new CaretSign(rightNode.Copy(), naturalNumberNode);
            DivisionSign division = new DivisionSign(minusSign, caretSign);
            return division;
        }
        public override Node Simplify()
        {
            Node simplifiedLeftNode = leftNode.Simplify();
            Node simplifiedRightNode = rightNode.Simplify();
            if (simplifiedLeftNode.GetType() == simplifiedRightNode.GetType() && simplifiedLeftNode.Calculate(2) == simplifiedRightNode.Calculate(2))
                return new NaturalNumberNode(1); //5 / 5 = 1, x / x = 1
            else if (simplifiedRightNode is NaturalNumberNode && simplifiedRightNode.Calculate(0) == 1) return simplifiedLeftNode; //5 / 1 = 5, x / 1 = 1
            else if (simplifiedLeftNode is NaturalNumberNode && simplifiedLeftNode.Calculate(0) == 0) return new NaturalNumberNode(0); //0 / 5 = 0
            else if (simplifiedLeftNode is SineFunction && simplifiedRightNode is CosineFunction || (simplifiedLeftNode is CosineFunction && simplifiedRightNode is SineFunction))
            {
                Operation functionB = (Operation)simplifiedRightNode;
                if (simplifiedLeftNode is Operation && simplifiedRightNode is Operation)
                {
                    Operation functionA = (Operation)simplifiedLeftNode;
                    double childValueA = functionA.ReturnChild().Calculate(5);
                    double childValueB = functionB.ReturnChild().Calculate(5);
                    if (simplifiedLeftNode is SineFunction && simplifiedRightNode is CosineFunction)
                    {
                        if (childValueA == childValueB) return new TangentFunction(functionA.ReturnChild()); //sin(x) / cos(x) = tan(x)
                    }
                    else if (simplifiedLeftNode is CosineFunction && simplifiedRightNode is SineFunction)
                    {
                        if (childValueA == childValueB) return new CotangentFunction(functionA.ReturnChild()); //cos(x) / sin(x) = cotg(x)
                    }
                }
                return new DivisionSign(simplifiedLeftNode, simplifiedRightNode);
            }
            //else if (simplifiedLeftNode is NaturalNumberNode && simplifiedLeftNode.Calculate(5) == 1 && simplifiedRightNode is TangentFunction) //1 / tan(x) = cotg(x)
            //    return new CotangentFunction(functionB.ReturnChild());
            //else if (simplifiedLeftNode is NaturalNumberNode && simplifiedLeftNode.Calculate(5) == 1 && simplifiedRightNode is CotangentFunction) // 1 / cotg(x) = tan(x)
            //    return new TangentFunction(functionB.ReturnChild());
            else if (simplifiedLeftNode is NumberNode && simplifiedRightNode is NumberNode) // 10 / 2 = 5
            {
                double valueA = 0;
                double valueB = 0;
                if (simplifiedLeftNode is RationalNumberNode) valueA = ((RationalNumberNode)simplifiedLeftNode).Value;
                if (simplifiedLeftNode is NaturalNumberNode) valueA = ((NaturalNumberNode)simplifiedLeftNode).Value;
                if (simplifiedRightNode is RationalNumberNode) valueB = ((RationalNumberNode)simplifiedRightNode).Value;
                if (simplifiedRightNode is NaturalNumberNode) valueB = ((NaturalNumberNode)simplifiedRightNode).Value;
                return new RationalNumberNode(valueA / valueB);
            }
            else if (simplifiedLeftNode is ExponentialFunction && simplifiedRightNode is ExponentialFunction) //e^5 / e^3 = e^2
                return new ExponentialFunction(new MinusSign(((Operation)simplifiedLeftNode).ReturnChild().Simplify(),
                    ((Operation)simplifiedRightNode).ReturnChild().Simplify()).Simplify());
            else if (simplifiedLeftNode is VariableNode && simplifiedRightNode is CaretSign)
            {
                CaretSign caretSign = (CaretSign)simplifiedRightNode;
                if (caretSign.ReturnLeftNode() is VariableNode && caretSign.ReturnRightNode() is NaturalNumberNode) //x / x^5 = 1 / x^4
                {
                    return new DivisionSign(new NaturalNumberNode(1), new CaretSign(new VariableNode(),
                        new NaturalNumberNode(Convert.ToInt32(caretSign.ReturnRightNode().Calculate(1)) - 1)));
                }
                else return new CaretSign(simplifiedLeftNode, simplifiedRightNode);
            }
            else if (simplifiedRightNode is VariableNode && simplifiedLeftNode is CaretSign)
            {
                CaretSign caretSign = (CaretSign)simplifiedLeftNode;
                if (caretSign.ReturnLeftNode() is VariableNode && caretSign.ReturnRightNode() is NaturalNumberNode)
                {
                    return new CaretSign(new VariableNode(), new NaturalNumberNode(Convert.ToInt32(caretSign.ReturnRightNode().Calculate(1)) - 1)); //x^5 / x = x^4
                }
                else return new CaretSign(simplifiedLeftNode, simplifiedRightNode);
            }
            else return new DivisionSign(simplifiedLeftNode, simplifiedRightNode);
        }
        public override Node Copy()
        {
            return new DivisionSign(leftNode.Copy(), rightNode.Copy());
        }
    }
}
