using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CVisualizer;

namespace CVisualizerTests
{
    [TestClass]
    public class FunctionSimplifyTests
    {
        [TestMethod]
        public void TestSimplifiedFunction1()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("+(*(*(x,x),+(p, *(p, 3))),e(-(l(12),l(4))))");
            string simplifiedFunctionStr = n.Simplify().ToPrefixString();

            //Assert
            Assert.AreEqual("+(*(^(x,2),*(r(4),p)),r(3))", simplifiedFunctionStr);
        }

        [TestMethod]
        public void TestSimplifiedFunction2()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("*(*(x, 5), x)");
            string simplifiedFunctionStr = n.Simplify().ToPrefixString();

            //Assert
            Assert.AreEqual("*(5,^(x,2))", simplifiedFunctionStr);
        }

        [TestMethod]
        public void TestSimplifiedFunction3()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("*(*(x,5),*(p,2))");
            string simplifiedFunctionStr = n.Simplify().ToPrefixString();

            //Assert
            Assert.AreEqual("*(r(10),*(p,x))", simplifiedFunctionStr);
        }

        [TestMethod]
        public void TestSimplifiedFunction4()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("*(5,2)");
            string simplifiedFunctionStr = n.Simplify().ToPrefixString();

            //Assert
            Assert.AreEqual("r(10)", simplifiedFunctionStr);
        }

        [TestMethod]
        public void TestSimplifiedFunction5()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("*(r(2.5),r(4.5))");
            string simplifiedFunctionStr = n.Simplify().ToPrefixString();

            //Assert
            Assert.AreEqual("r(11.25)", simplifiedFunctionStr);
        }

        [TestMethod]
        public void TestSimplifiedFunction6()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("+(ln(^(e(5),3)),ln(^(x,3)))");
            string simplifiedFunctionStr = n.Simplify().ToPrefixString();

            //Assert
            Assert.AreEqual("+(r(15),*(3,l(x)))", simplifiedFunctionStr);
        }

        [TestMethod]
        public void TestSimplifiedFunction7()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("+(+(/(x,^(x,5)),/(^(x,5),x)),/(x,x))");
            string simplifiedFunctionStr = n.Simplify().ToPrefixString();

            //Assert
            Assert.AreEqual("+(+(/(1,^(x,4)),^(x,4)),1)", simplifiedFunctionStr);
        }

        [TestMethod]
        public void TestSimplifiedFunction8()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("+(/(e(5),e(3)),-(x,x))");
            string simplifiedFunctionStr = n.Simplify().ToPrefixString();

            //Assert
            Assert.AreEqual("e(r(2))", simplifiedFunctionStr);
        }

        [TestMethod]
        public void TestSimplifiedFunction9()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("+(-(x,*(x,5)),-(*(5,x),x))");
            string simplifiedFunctionStr = n.Simplify().ToPrefixString();

            //Assert
            Assert.AreEqual("0", simplifiedFunctionStr);
        }

        [TestMethod]
        public void TestSimplifiedFunction10()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("+(-(*(5,x),*(x,3)),-(*(5,p),*(p,3)))");
            string simplifiedFunctionStr = n.Simplify().ToPrefixString();

            //Assert
            Assert.AreEqual("+(*(2,x),*(2,p))", simplifiedFunctionStr);
        }

        [TestMethod]
        public void TestSimplifiedFunction11()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("+(*(e(3),e(2)),*(5,*(2,x)))");
            string simplifiedFunctionStr = n.Simplify().ToPrefixString();

            //Assert
            Assert.AreEqual("+(e(r(5)),*(r(10),x))", simplifiedFunctionStr);
        }

        [TestMethod]
        public void TestSimplifiedFunction12()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("+(+(+(*(4,x),x),+(ln(5),ln(2))),+(p,p))");
            string simplifiedFunctionStr = n.Simplify().ToPrefixString();

            //Assert
            Assert.AreEqual("+(+(*(r(5),x),l(r(10))),*(2,p))", simplifiedFunctionStr);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingBracketException))]
        public void TestMissingBracketException()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("+(5,3");

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCharacterException))]
        public void TestInvalidCharactedException()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("y");

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidExpressionException))]
        public void TestInvalidExpressionException()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("()");

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(SeparatorExpectedException))]
        public void TestSeparatorExpectedException()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("+(53)");

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(IsNotValidNaturalNumberException))]
        public void TestIsNotValidNaturalNumberException()
        {
            //Arrange
            Parser p = new Parser();

            //Act
            Node n = p.ParseExpression("n(4.5)");

            //Assert
        }
    }
}
