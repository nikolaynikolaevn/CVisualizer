using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CVisualizer;

namespace CVisualizerTests
{
    [TestClass]
    public class GraphDrawerTests
    {
        [TestMethod]
        public void TestHorizontalLabelsSwitch()
        {
            //Arrange
            GraphDrawer graphDrawer = new GraphDrawer();

            //Act
            graphDrawer.ShowHorizontalLabels();
            graphDrawer.HideHorizontalLabels();

            //Assert
            Assert.AreEqual(graphDrawer.IsShowHorizontalAxisLabels, false);
        }

        [TestMethod]
        public void TestVerticalLabelsSwitch()
        {
            //Arrange
            GraphDrawer graphDrawer = new GraphDrawer();

            //Act
            graphDrawer.ShowVerticalLabels();
            graphDrawer.HideVerticalLabels();

            //Assert
            Assert.AreEqual(graphDrawer.IsShowVerticalAxisLabels, false);
        }

        [TestMethod]
        public void TestAxesSwitch()
        {
            //Arrange
            GraphDrawer graphDrawer = new GraphDrawer();

            //Act
            graphDrawer.ShowAxes();
            graphDrawer.HideAxes();

            //Assert
            Assert.AreEqual(graphDrawer.IsShowAxes, false);
        }

        [TestMethod]
        public void TestXYSwitch()
        {
            //Arrange
            GraphDrawer graphDrawer = new GraphDrawer();

            //Act
            graphDrawer.HideXY();
            graphDrawer.ShowXY();

            //Assert
            Assert.AreEqual(graphDrawer.IsShowXY, true);
        }

        [TestMethod]
        public void TestDerivativeSwitch()
        {
            //Arrange
            GraphDrawer graphDrawer = new GraphDrawer();

            //Act
            graphDrawer.HideDerivative();
            graphDrawer.ShowDerivative();

            //Assert
            Assert.AreEqual(graphDrawer.IsShowFunctionDerivative, true);
        }

        [TestMethod]
        public void TestFunctionSwitch()
        {
            //Arrange
            GraphDrawer graphDrawer = new GraphDrawer();

            //Act
            graphDrawer.HideFunction();
            graphDrawer.ShowFunction();

            //Assert
            Assert.AreEqual(graphDrawer.IsShowFunction, true);
        }

        [TestMethod]
        public void TestIntegralSwitch()
        {
            //Arrange
            GraphDrawer graphDrawer = new GraphDrawer();

            //Act
            graphDrawer.HideIntegral();
            graphDrawer.ShowIntegral();

            //Assert
            Assert.AreEqual(graphDrawer.IsShowFunctionIntegral, true);
        }

        [TestMethod]
        public void TestInverseFunctionSwitch()
        {
            //Arrange
            GraphDrawer graphDrawer = new GraphDrawer();

            //Act
            graphDrawer.HideInverseFunction();
            graphDrawer.ShowInverseFunction();

            //Assert
            Assert.AreEqual(graphDrawer.IsShowInverseFunction, true);
        }

        [TestMethod]
        public void TestMaclaurinSeriesSwitch()
        {
            //Arrange
            GraphDrawer graphDrawer = new GraphDrawer();

            //Act
            graphDrawer.HideMaclaurinSeries();
            graphDrawer.ShowMaclaurinSeries();

            //Assert
            Assert.AreEqual(graphDrawer.IsShowFunctionMaclaurinSeries, true);
        }

        [TestMethod]
        public void TestZoomIn()
        {
            //Arrange
            GraphDrawer graphDrawer = new GraphDrawer();

            //Act
            graphDrawer.ZoomIn();

            //Assert
            Assert.AreEqual(graphDrawer.GetScale(), 55);
        }

        [TestMethod]
        public void TestZoomOut()
        {
            //Arrange
            GraphDrawer graphDrawer = new GraphDrawer();

            //Act
            graphDrawer.ZoomOut();

            //Assert
            Assert.AreEqual(graphDrawer.GetScale(), 45);
        }

        [TestMethod]
        public void TestZoomInTwice()
        {
            //Arrange
            GraphDrawer graphDrawer = new GraphDrawer();

            //Act
            graphDrawer.ZoomInTwice();

            //Assert
            Assert.AreEqual(graphDrawer.GetScale(), 100);
        }

        [TestMethod]
        public void TestZoomOutTwice()
        {
            //Arrange
            GraphDrawer graphDrawer = new GraphDrawer();

            //Act
            graphDrawer.ZoomOutTwice();

            //Assert
            Assert.AreEqual(graphDrawer.GetScale(), 25);
        }

        [TestMethod]
        public void TestChangePrecision()
        {
            //Arrange
            GraphDrawer graphDrawer = new GraphDrawer();

            //Act
            graphDrawer.ChangePrecision(55);

            //Assert
            Assert.AreEqual(graphDrawer.GetPrecision(), 55);
        }

        [TestMethod]
        public void TestDerivativeAlgorithmSwitch()
        {
            //Arrange
            GraphDrawer graphDrawer = new GraphDrawer();

            //Act
            graphDrawer.EnableAnalyticalDerivative();
            graphDrawer.EnableNewtonDerivative();

            //Assert
            Assert.AreEqual(graphDrawer.IsShowFunctionAnalyticalDerivative, false);
            Assert.AreEqual(graphDrawer.IsShowFunctionNewtonDerivative, true);
        }

        [TestMethod]
        public void TestMaclaurinSeriesAlgorithmSwitch()
        {
            //Arrange
            GraphDrawer graphDrawer = new GraphDrawer();

            //Act
            graphDrawer.EnableAnalyticalMaclaurinSeries();
            graphDrawer.EnableNewtonMaclaurinSeries();

            //Assert
            Assert.AreEqual(graphDrawer.IsShowFunctionAnalyticalMaclaurinSeries, false);
            Assert.AreEqual(graphDrawer.IsShowFunctionNewtonMaclaurinSeries, true);
        }

        [TestMethod]
        public void TestDerivativeAlgorithmSwitch2()
        {
            //Arrange
            GraphDrawer graphDrawer = new GraphDrawer();

            //Act
            graphDrawer.SwitchDerivativeAlgorithm();

            //Assert
            Assert.AreEqual(graphDrawer.IsShowFunctionAnalyticalDerivative, true);
            Assert.AreEqual(graphDrawer.IsShowFunctionNewtonDerivative, false);
        }

        [TestMethod]
        public void TestMaclaurinSeriesAlgorithmSwitch2()
        {
            //Arrange
            GraphDrawer graphDrawer = new GraphDrawer();

            //Act
            graphDrawer.SwitchMaclaurinSeriesAlgorithm();

            //Assert
            Assert.AreEqual(graphDrawer.IsShowFunctionAnalyticalMaclaurinSeries, false);
            Assert.AreEqual(graphDrawer.IsShowFunctionNewtonMaclaurinSeries, true);
        }

        [TestMethod]
        public void TestScaleResetting()
        {
            //Arrange
            GraphDrawer graphDrawer = new GraphDrawer();

            //Act
            graphDrawer.ZoomIn();
            graphDrawer.ResetScale();

            //Assert
            Assert.AreEqual(graphDrawer.GetScale(), 50);
        }

        [TestMethod]
        public void TestSettingMaclaurinSeriesTerms()
        {
            //Arrange
            GraphDrawer graphDrawer = new GraphDrawer();

            //Act
            graphDrawer.SetNumberOfTerms(3);

            //Assert
            Assert.AreEqual(graphDrawer.MaclaurinTerms, 3);
        }
    }
}
