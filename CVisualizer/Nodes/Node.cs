using System;

namespace CVisualizer
{
    public abstract class Node
    {
        private static int id = 1;

        public int ID { get; }
        public string Label { get; protected set; }
        public string ShortLabel { get; protected set; }
        public Node()
        {
            ID = id;
            id++;
        }
        public abstract Node Copy();
        public abstract double Calculate(double x);

        public string GenerateBinaryTree()
        {
            string s = "node" + ID + " [ label = \"" + Label + "\" ]\n";
            string nextNode = "node" + ID + " -- node";
            if (this is Operator)
            {
                Node leftNode = ((Operator)this).ReturnLeftNode();
                Node rightNode = ((Operator)this).ReturnRightNode();
                if (leftNode != null)
                {
                    s += nextNode + leftNode.ID;
                    s += "\n";
                    s += leftNode.GenerateBinaryTree();
                }
                s += nextNode + rightNode.ID;
                s += "\n";
                s += rightNode.GenerateBinaryTree();
            }
            else if (this is Operation)
            {
                Node child = ((Operation)this).ReturnChild();
                s += nextNode + child.ID;
                s += "\n";
                s += child.GenerateBinaryTree();
            }
            else
            {

            }
            return s;
        }

        public abstract Node ReturnDerivative(double x);
        public double ReturnNewtonDerivative(double x)
        {
            HNode hNode = new HNode();
            return (Calculate(x + hNode.Calculate(x)) - Calculate(x)) / hNode.Calculate(x);
        }
        private int[] ReturnIndeterminateCoefficients(int order)
        {
            if (order == 0) return new int[1] { 1 };
            int[] previousCoefs = new int[2] { 1, -1 };
            if (order == 1) return previousCoefs;
            int[] nthOrderCoefs = null;
            for (int i = 1; i < order; i++)
            {
                nthOrderCoefs = new int[i + 2];
                nthOrderCoefs[0] = nthOrderCoefs[nthOrderCoefs.Length - 1] = 1;
                for (int j = 1; j < previousCoefs.Length; j++)
                {
                    nthOrderCoefs[j] = Math.Abs(previousCoefs[j - 1]) + Math.Abs(previousCoefs[j]);
                    if (j % 2 == 1) nthOrderCoefs[j] *= -1;
                    else nthOrderCoefs[j + 1] *= -1;
                }
                previousCoefs = nthOrderCoefs;
            }
            return nthOrderCoefs;
        }
        private PlusSign[] ReturnNewtonIndeterminates(int order)
        {
            PlusSign[] funcs = new PlusSign[order + 1];
            HNode hNode = new HNode();
            NaturalNumberNode orderNode;
            MultiplicationSign multiplicationSign;
            VariableNode variableNode = new VariableNode();
            for (int i = 0; i <= order; i++)
            {
                orderNode = new NaturalNumberNode(order - i);
                multiplicationSign = new MultiplicationSign(orderNode, hNode);
                funcs[i] = new PlusSign(variableNode, multiplicationSign);
            }
            return funcs;
        }
        private Node ReturnNewtonPolynomial(double x, int order)
        {
            Operator sign = null;
            int[] coefficients = ReturnIndeterminateCoefficients(order);
            PlusSign[] indeterminates = ReturnNewtonIndeterminates(order);

            if (order == 0) return new RationalNumberNode(Calculate(indeterminates[0].Calculate(x)));
            if (order == 1) return new MinusSign(new RationalNumberNode(Calculate(indeterminates[0].Calculate(x))), new RationalNumberNode(Calculate(indeterminates[1].Calculate(x))));

            NaturalNumberNode naturalNumberNode = new NaturalNumberNode(coefficients[0]);
            MultiplicationSign multiplicationSign = new MultiplicationSign(naturalNumberNode, new RationalNumberNode(Calculate(indeterminates[0].Calculate(x))));

            sign = multiplicationSign;

            for (int i = 1; i <= order; i++)
            {
                naturalNumberNode = new NaturalNumberNode(Math.Abs(coefficients[i]));
                multiplicationSign = new MultiplicationSign(naturalNumberNode, new RationalNumberNode(Calculate(indeterminates[i].Calculate(x))));
                if (i % 2 == 0) sign = new PlusSign(sign, multiplicationSign);
                else
                {
                    sign = new MinusSign(sign, multiplicationSign);
                }
            }
            return sign;
        }
        private double CalculatePolynomialDerivative(double x, int order)
        {
            HNode hNode = new HNode();
            return ReturnNewtonPolynomial(x, order).Calculate(x) / Math.Pow(hNode.Calculate(x), order);
        }
        public double ReturnMaclaurinSeries(double x, int order)
        {
            if (order == 0) return Calculate(0);
            if (order == 1) return ReturnDerivative(x).Calculate(0) * x + Calculate(0);
            VariableNode variableNode = new VariableNode();
            NaturalNumberNode orderNode = new NaturalNumberNode(order);
            CaretSign caretSign = new CaretSign(variableNode, orderNode);
            Node f0 = ReturnDerivative(x);
            for (int i = 1; i < order; i++)
            {
                f0 = f0.ReturnDerivative(x);
            }
            MultiplicationSign multiplicationSign = new MultiplicationSign(caretSign, new RationalNumberNode(f0.Calculate(0)));
            FactorialFunction factorialFunction = new FactorialFunction(orderNode);
            DivisionSign divisionSign = new DivisionSign(multiplicationSign, factorialFunction);
            return divisionSign.Calculate(x) + ReturnMaclaurinSeries(x, order - 1);
        }
        private Node GenerateMaclaurinSeriesPolynomial(double x, int order)
        {
            if (order == 0) return this;
            if (order == 1) return new PlusSign(new MultiplicationSign(ReturnDerivative(x), new VariableNode()), this);
            VariableNode variableNode = new VariableNode();
            NaturalNumberNode orderNode = new NaturalNumberNode(order);
            CaretSign caretSign = new CaretSign(variableNode, orderNode);
            Node f0 = ReturnDerivative(x);
            for (int i = 1; i < order; i++)
            {
                f0 = f0.ReturnDerivative(x);
            }
            MultiplicationSign multiplicationSign = new MultiplicationSign(caretSign, new RationalNumberNode(f0.Calculate(0)));
            FactorialFunction factorialFunction = new FactorialFunction(orderNode);
            DivisionSign divisionSign = new DivisionSign(multiplicationSign, factorialFunction);
            return new PlusSign(divisionSign, ReturnMaclaurinSeriesPolynomial(x, order - 1));
        }
        public Node ReturnMaclaurinSeriesPolynomial(double x, int order)
        {
            return GenerateMaclaurinSeriesPolynomial(x, order);
        }
        public double ReturnNewtonMaclaurinSeries(double x, int order)
        {
            if (order == 0) return Calculate(0);
            if (order == 1) return ReturnNewtonDerivative(0) * x + Calculate(0);
            VariableNode variableNode = new VariableNode();
            NaturalNumberNode orderNode = new NaturalNumberNode(order);
            CaretSign caretSign = new CaretSign(variableNode, orderNode);
            RationalNumberNode f0 = new RationalNumberNode(CalculatePolynomialDerivative(0, order));
            MultiplicationSign multiplicationSign = new MultiplicationSign(caretSign, f0);
            FactorialFunction factorialFunction = new FactorialFunction(orderNode);
            DivisionSign divisionSign = new DivisionSign(multiplicationSign, factorialFunction);
            return divisionSign.Calculate(x) + ReturnNewtonMaclaurinSeries(x, order - 1);
        }
        public abstract Node Simplify();

        public abstract string ToPrefixString();
    }
}
