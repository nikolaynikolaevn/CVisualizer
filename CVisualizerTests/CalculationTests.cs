using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CVisualizer;

namespace CVisualizerTests
{
    [TestClass]
    public class CalculationTests
    {
        [TestMethod]
        public void TestCosine()
        {
            //Arrange
            VariableNode variableNode = new VariableNode();
            PiNode piNode = new PiNode();
            CosineFunction cosineNode1 = new CosineFunction(variableNode);
            CosineFunction cosineNode2 = new CosineFunction(piNode);

            //Act
            double result1 = cosineNode1.Calculate(0);
            double result2 = cosineNode2.Calculate(0);

            //Assert
            Assert.AreEqual(1, result1);
            Assert.AreEqual(-1, result2);
        }

        [TestMethod]
        public void TestSine()
        {
            //Arrange
            VariableNode variableNode = new VariableNode();
            PiNode piNode = new PiNode();
            SineFunction sineNode1 = new SineFunction(variableNode);
            SineFunction sineNode2 = new SineFunction(piNode);

            //Act
            double result1 = sineNode1.Calculate(0);
            double result2 = sineNode2.Calculate(0);

            //Assert
            Assert.AreEqual(0, result1);
            Assert.AreEqual(0, Math.Round(result2, 15));
        }

        [TestMethod]
        public void TestExponential()
        {
            //Arrange
            VariableNode variableNode = new VariableNode();
            ExponentialFunction exponentialNode = new ExponentialFunction(variableNode);

            //Act
            double result1 = exponentialNode.Calculate(0);
            double result2 = exponentialNode.Calculate(2);

            //Assert
            Assert.AreEqual(1, result1);
            Assert.AreEqual(7.3891, Math.Round(result2, 4));
        }

        [TestMethod]
        public void TestFactorial()
        {
            //Arrange
            VariableNode variableNode = new VariableNode();
            FactorialFunction factorialNode = new FactorialFunction(variableNode);

            //Act
            double result1 = factorialNode.Calculate(0);
            double result2 = factorialNode.Calculate(1);
            double result3 = factorialNode.Calculate(2);
            double result4 = factorialNode.Calculate(4);

            //Assert
            Assert.AreEqual(1, result1);
            Assert.AreEqual(1, result2);
            Assert.AreEqual(2, result3);
            Assert.AreEqual(24, result4);
        }


        [TestMethod]
        public void TestLogarithm()
        {
            //Arrange
            VariableNode variableNode = new VariableNode();
            LogarithmFunction logarithmNode = new LogarithmFunction(variableNode);

            //Act
            double result1 = logarithmNode.Calculate(1);
            double result2 = logarithmNode.Calculate(2);
            double result4 = logarithmNode.Calculate(4);

            //Assert
            Assert.AreEqual(0, result1);
            Assert.AreEqual(0.6931, Math.Round(result2, 4));
            Assert.AreEqual(1.3863, Math.Round(result4, 4));
        }

        [TestMethod]
        public void TestCalculateMatrixRoots()
        {
            //Arrange
            float[,] points = { { -7.32f, 2.96f }, { -3.78f, 0.98f } };
            double[] expectedRoots = { -0.5593, -1.1342 };

            //Act
            double[] roots = PolynomialCalculator.GenerateMatrix(points);

            //Assert
            Assert.AreEqual(expectedRoots[0], Math.Round(roots[0], 4));
            Assert.AreEqual(expectedRoots[1], Math.Round(roots[1], 4));
        }

        [TestMethod]
        public void TestMaclaurinSeries()
        {
            //Arrange
            Node node = new PlusSign(new VariableNode(), new MultiplicationSign(new CosineFunction(new NaturalNumberNode(0)), new NaturalNumberNode(3)));

            //Act
            double result = node.ReturnMaclaurinSeries(1, 2);

            //Assert
            Assert.AreEqual(4, Math.Round(result, 4));
        }

        [TestMethod]
        public void TestMaclaurinSeriesPolynomial()
        {
            //Arrange
            Node node = new PlusSign(new VariableNode(), new MultiplicationSign(new CosineFunction(new NaturalNumberNode(0)), new NaturalNumberNode(3)));

            //Act
            Node result = node.ReturnMaclaurinSeriesPolynomial(1, 2);

            //Assert
            Assert.AreEqual("(x^2 * 0 / 2! + ((1 + 3 * (0 - sin(0)) * 0) * x + (x + cos(0) * 3)))", result.ToString());
        }

        [TestMethod]
        public void TestNewtonMaclaurinSeries()
        {
            //Arrange
            Node node = new PlusSign(new VariableNode(), new MultiplicationSign(new CosineFunction(new NaturalNumberNode(0)), new NaturalNumberNode(3)));

            //Act
            double result = node.ReturnNewtonMaclaurinSeries(1, 2);

            //Assert
            Assert.AreEqual(4, Math.Round(result, 0));
        }
    }
}
