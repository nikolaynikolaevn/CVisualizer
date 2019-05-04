using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CVisualizer;

namespace CVisualizerTests
{
    [TestClass]
    public class DerivativeTests
    {


        /*
         * Prefix
         */


        [TestMethod]
        public void TestSimplifiedDerivative1()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("*(s(/(^(x,2),p)),2)");
            string simplifiedDerivativeStr = n.ReturnDerivative(1).Simplify().ToPrefixString();

            //Assert
            Assert.AreEqual("*(2,*(c(/(^(x,2),p)),/(*(*(r(2),x),p),^(p,2))))", simplifiedDerivativeStr);
        }

        [TestMethod]
        public void TestSimplifiedDerivative2()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("*(x,s(l(^(x,2))))");
            string simplifiedDerivativeStr = n.ReturnDerivative(10).Simplify().ToPrefixString();

            //Assert
            Assert.AreEqual("+(s(l(^(x,2))),*(x,*(c(l(^(x,2))),/(*(r(2),x),^(x,2)))))", simplifiedDerivativeStr);
        }

        [TestMethod]
        public void TestSimplifiedDerivative3()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("*(c(s(+(x,4))),l(x))");
            string simplifiedDerivativeStr = n.ReturnDerivative(10).Simplify().ToPrefixString();

            //Assert
            Assert.AreEqual("+(*(*(-(0,s(s(+(x,4)))),c(+(x,4))),l(x)),*(c(s(+(x,4))),/(1,x)))", simplifiedDerivativeStr);
        }

        [TestMethod]
        public void TestSimplifiedDerivative4()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("+(*(*(x,x),+(p, *(p, 3))),e(-(l(12),l(4))))");
            string simplifiedDerivativeStr = n.ReturnDerivative(1).Simplify().ToPrefixString();

            //Assert
            Assert.AreEqual("*(*(2,x),*(r(4),p))", simplifiedDerivativeStr);
        }


        /*
         * ToString - Infix
         */


        [TestMethod]
        public void TestSimplifiedDerivative1Infix()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("*(s(/(^(x,2),p)),2)");
            string simplifiedDerivativeStr = n.ReturnDerivative(1).Simplify().ToString();

            //Assert
            Assert.AreEqual("2 * cos(x^2 / π) * 2 * x * π / π^2", simplifiedDerivativeStr);
        }

        [TestMethod]
        public void TestSimplifiedDerivative2Infix()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("*(x,s(l(^(x,2))))");
            string simplifiedDerivativeStr = n.ReturnDerivative(10).Simplify().ToString();

            //Assert
            Assert.AreEqual("(sin(ln(x^2)) + x * cos(ln(x^2)) * 2 * x / x^2)", simplifiedDerivativeStr);
        }

        [TestMethod]
        public void TestSimplifiedDerivative3Infix()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("*(c(s(+(x,4))),l(x))");
            string simplifiedDerivativeStr = n.ReturnDerivative(10).Simplify().ToString();

            //Assert
            Assert.AreEqual("((0 - sin(sin((x + 4)))) * cos((x + 4)) * ln(x) + cos(sin((x + 4))) * 1 / x)", simplifiedDerivativeStr);
        }

        [TestMethod]
        public void TestSimplifiedDerivative4Infix()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("+(*(*(x,x),+(p, *(p, 3))),e(-(l(12),l(4))))");
            string simplifiedDerivativeStr = n.ReturnDerivative(1).Simplify().ToString();

            //Assert
            Assert.AreEqual("2 * x * 4 * π", simplifiedDerivativeStr);
        }

        [TestMethod]
        public void TestSimplifiedDerivativeInfix()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("-(*(!(5),x),e(5))");
            string simplifiedDerivativeStr = n.ReturnDerivative(1).Simplify().ToString();

            //Assert
            Assert.AreEqual("5!", simplifiedDerivativeStr);
        }

        [TestMethod]
        public void TestNewtonCoefficientDerivative()
        {
            //Arrange
            Node node = new PlusSign(new VariableNode(), new MultiplicationSign(new CosineFunction(new NaturalNumberNode(0)), new NaturalNumberNode(3)));

            //Act
            double result = node.ReturnNewtonDerivative(2);

            //Assert
            Assert.AreEqual(1, Math.Round(result, 11));
        }
    }
}
