using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CVisualizer
{
    public class GraphDrawer
    {
        private Node startNode;
        private float increment = 50;
        private int originX, originY;
        private int newX, newY;
        private int halfX, halfY;
        private int x = 0;
        private int y = 0;
        public bool IsShowHorizontalAxisLabels { get; private set; } = true;
        public bool IsShowVerticalAxisLabels { get; private set; } = true;
        public bool IsShowAxes { get; private set; } = true;
        public bool IsShowXY { get; private set; } = false;
        public bool IsShowFunction { get; private set; } = true;
        public bool IsShowInverseFunction { get; private set; } = false;
        public bool IsShowFunctionDerivative { get; private set; } = false;
        public bool IsShowFunctionAnalyticalDerivative { get; private set; } = false;
        public bool IsShowFunctionNewtonDerivative { get; private set; } = true;
        public bool IsShowFunctionIntegral { get; private set; } = false;
        public bool IsShowFunctionMaclaurinSeries { get; private set; } = false;
        public bool IsShowFunctionAnalyticalMaclaurinSeries { get; private set; } = true;
        public bool IsShowFunctionNewtonMaclaurinSeries { get; private set; } = false;
        private float unitsX, unitsY;
        private float startPoint, endPoint;
        public int? MaclaurinTerms { get; private set; }
        private List<float[]> polynomialPoints;
        private bool isPolynomialPointsInputFinished = false;
        public Node PolynomialNode { get; private set; }
        private Font labelFont;
        private Brush labelBrush;
        private Matrix matrix = null;
        private float precision = 1;
        public delegate void FunctionDomainPrompt();
        public event FunctionDomainPrompt OnIntegralPrompted;
        public event FunctionDomainPrompt OnMaclaurinPrompted;
        private PictureBox pictureBoxGraph;

        public void Move(int x, int y)
        {
            this.x += x;
            this.y += y;
            Refresh();
        }

        public GraphDrawer(Node n)
        {
            this.startNode = n;
            polynomialPoints = new List<float[]>();
        }
        public GraphDrawer(Node n, bool isShowHorizontalAxisLabels, bool isShowVerticalAxisLabels, bool isShowAxes,
            bool isShowXY, bool isShowFunction, bool isShowInverseFunction, bool isShowFunctionDerivative, bool isShowFunctionIntegral, bool isShowFunctionMaclaurinSeries)
        {
            this.startNode = n;
            IsShowHorizontalAxisLabels = isShowHorizontalAxisLabels;
            IsShowVerticalAxisLabels = isShowVerticalAxisLabels;
            IsShowAxes = isShowAxes;
            IsShowXY = isShowXY;
            IsShowFunction = isShowFunction;
            IsShowInverseFunction = isShowInverseFunction;
            IsShowFunctionDerivative = isShowFunctionDerivative;
            IsShowFunctionIntegral = isShowFunctionIntegral;
            IsShowFunctionMaclaurinSeries = isShowFunctionMaclaurinSeries;
            polynomialPoints = new List<float[]>();
        }
        public GraphDrawer()
        {
            polynomialPoints = new List<float[]>();
        }
        public void DrawCoordinateSystem(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            pictureBoxGraph = (PictureBox)sender;
            g.FillRectangle(Brushes.White, 0, 0, pictureBoxGraph.Width, pictureBoxGraph.Height);
            Pen axisPen = Pens.LightGray;
            Pen axisOriginPen = Pens.Black;
            labelFont = SystemFonts.DefaultFont;
            Size labelFontSize = new Size(25, SystemFonts.DefaultFont.Height);
            labelBrush = Brushes.Black;
            originX = pictureBoxGraph.Width / 2 - x;
            originY = pictureBoxGraph.Height / 2 + y;
            g.TranslateTransform(originX, originY);
            matrix = e.Graphics.Transform;
            newX = pictureBoxGraph.Width + Math.Abs(2 * x);
            newY = pictureBoxGraph.Height + Math.Abs(2 * y);

            halfX = newX / 2;
            halfY = newY / 2;

            unitsX = originX / increment;
            unitsY = originX / increment;

            int count = 0;
            for (float i = 0; i < halfX; i += increment)
            {
                g.DrawLine(axisPen, i, -halfY, i, halfY);
                if (i != 0)
                {
                    g.DrawLine(axisPen, -i, -halfY, -i, halfY);
                }
            }
            for (float i = 0; i < halfY; i += increment)
            {
                g.DrawLine(axisPen, -halfX, i, halfX, i);
                if (i != 0)
                {
                    g.DrawLine(axisPen, -halfX, -i, halfX, -i);
                }
                count++;
            }

            if (IsShowAxes)
            {
                g.DrawLine(axisOriginPen, -halfX, 0, halfX, 0); // drow horizontal origin axis
                g.DrawLine(axisOriginPen, 0, -halfY, 0, halfY); // drow vertical origin axis
            }

            if (IsShowXY)
            {
                DrawXY(ref g);
            }

            if (startNode != null)
            {
                if (IsShowFunction) DrawFunction(ref g, startNode, Pens.Red);
                if (IsShowFunctionDerivative) DrawFunctionDerivative(ref g, Pens.Purple);
                if (IsShowFunctionIntegral) DrawFunctionIntegral(ref g, Pens.Red);
                if (IsShowInverseFunction) DrawInverseFunction(ref g, Pens.Magenta);
                if (IsShowFunctionMaclaurinSeries) DrawFunctionMaclaurinSeries(ref g, Pens.Green);
            }
            if (polynomialPoints.Count > 1 && isPolynomialPointsInputFinished) DrawPolynomial(ref g, Pens.Black);
            float labelCoefficient = increment / (increment / 25);
            if (IsShowHorizontalAxisLabels)
            {
                string PositiveX, NegativeX;
                for (float i = 0; i < halfX; i += labelCoefficient)
                {
                    PositiveX = Math.Round(i / increment, 2).ToString();
                    NegativeX = Math.Round(-i / increment, 2).ToString();
                    g.DrawString(NegativeX, GetCorrectFont(g, NegativeX, labelFontSize, labelFont), labelBrush, -i, 0);
                    g.DrawString(PositiveX, GetCorrectFont(g, NegativeX, labelFontSize, labelFont), labelBrush, i, 0);
                }
            }
            if (IsShowVerticalAxisLabels)
            {
                string PositiveY, NegativeY;
                for (float i = 0; i < halfY; i += labelCoefficient)
                {
                    PositiveY = Math.Round(i / increment, 2).ToString();
                    NegativeY = Math.Round(-i / increment, 2).ToString();
                    g.DrawString(PositiveY, GetCorrectFont(g, NegativeY, labelFontSize, labelFont), labelBrush, 0, -i);
                    g.DrawString(NegativeY, GetCorrectFont(g, NegativeY, labelFontSize, labelFont), labelBrush, 0, i);
                }
            }
            foreach (float[] p in polynomialPoints)
            {
                g.FillEllipse(Brushes.Black, ReturnWidthCoordinate(p[0]) - 3, ReturnHeightCoordinate(p[1]) - 3, 5, 5);
            }
        }

        private void Refresh()
        {
            if (startNode != null) pictureBoxGraph.Refresh();
        }

        public PointF GetMouseLocation(Point p0, bool forward)
        {
            if (matrix != null)
            {
                Matrix m = matrix.Clone();
                if (!forward) m.Invert();

                var pt = new PointF[] { p0 };
                m.TransformPoints(pt);
                pt[0].X = pt[0].X / increment;
                pt[0].Y = -pt[0].Y / increment;
                return pt[0];
            }
            return Point.Empty;
        }

        public void DrawXY(ref Graphics g)
        {
            Pen dashedPen = new Pen(Color.DarkGray, 1.5f);
            dashedPen.DashStyle = DashStyle.Dash;
            List<PointF> points = new List<PointF>();
            for (int i = -halfX; i < halfX; i++)
            {
                if (-i >= -halfY && -i <= halfY)
                {
                    points.Add(new PointF(i, -i));
                }
            }
            if (points.Count > 1) g.DrawLines(dashedPen, points.ToArray());
        }

        public void DrawLine(ref Graphics g, float x1, float x2, float y1, float y2, Pen p)
        {
            try
            {
                if (Double.IsInfinity(y1) || Double.IsNaN(y1)) { return; }
                g.DrawLine(p, x2, y2, x1, y1);
            }
            catch { return; }
        }

        public void DrawFunction(ref Graphics g, Node n, Pen p)
        {
            float[] points = new float[2];
            for (float i = -halfX; i < halfX; i += precision)
            {
                double xval = ReturnXValue(Convert.ToInt32(i));
                try { points[0] = (float)n.Calculate(xval); }
                catch { }
                try
                {
                    points[1] = points[0];
                    xval = ReturnXValue(Convert.ToInt32(i + precision));
                    float f2 = (float)n.Calculate(xval);
                    points[0] = f2;
                    if (Double.IsInfinity(f2) || Double.IsNaN(f2)) { continue; }
                    g.DrawLine(p, i + 1, ReturnHeightCoordinate(points[0]), i, ReturnHeightCoordinate(points[1]));
                }
                catch (DivideByZeroException) { continue; }
                catch { continue; }
            }
        }

        private List<PointF> CalculatePoints(float startPoint, float endPoint, bool transform)
        {
            List<PointF> points = new List<PointF>();
            if (transform)
            {
                startPoint = ReturnWidthCoordinate(startPoint);
                endPoint = ReturnWidthCoordinate(endPoint);
            }
            for (float i = startPoint; i < endPoint; i += precision)
            {
                try
                {
                    double y = startNode.Calculate(ReturnXValue(Convert.ToInt32(i)));
                    float yValue = ReturnHeightCoordinate((float)y);
                    if (i < -1073741376) i = -1073741376;
                    if (yValue < -1073740288) yValue = -1073740288;
                    if (!Double.IsInfinity(y) && !Double.IsNaN(y) && i < int.MaxValue && yValue < int.MaxValue) points.Add(new PointF(i, yValue));
                }
                catch { continue; }
            }
            return points;
        }

        public void DrawInverseFunction(ref Graphics g, Pen p)
        {
            for (float i = -halfY; i < halfY; i += precision)
            {
                double y1 = startNode.Calculate(ReturnXValue(Convert.ToInt32(i)));
                int x2 = Convert.ToInt32(i + precision);
                double y2 = startNode.Calculate(ReturnXValue(x2));
                try
                {
                    DrawLine(ref g, ReturnHeightCoordinate(-(float)y1), ReturnHeightCoordinate(-(float)y2), -i, -x2, p);
                }
                catch { continue; }
            }
        }

        public void DrawFunctionDerivative(ref Graphics g, Pen p)
        {
            if (IsShowFunctionAnalyticalDerivative) DrawFunctionAnalyticalDerivative(ref g, p);
            else DrawFunctionNewtonDerivative(ref g, p);
        }

        private void DrawFunctionAnalyticalDerivative(ref Graphics g, Pen p)
        {
            for (float i = -halfX; i < halfX; i += precision)
            {
                double xValue = ReturnXValue(Convert.ToInt32(i));
                double y1 = startNode.ReturnDerivative(xValue).Calculate(xValue);
                int x2 = Convert.ToInt32(i + precision);
                double y2 = startNode.ReturnDerivative(xValue).Calculate(ReturnXValue(x2));
                try
                {
                    DrawLine(ref g, i, x2, ReturnHeightCoordinate((float)y1), ReturnHeightCoordinate((float)y2), p);
                }
                catch { continue; }
            }
        }

        private void DrawFunctionNewtonDerivative(ref Graphics g, Pen p)
        {
            for (float i = -halfX; i < halfX; i += precision)
            {
                double y1 = startNode.ReturnNewtonDerivative(ReturnXValue(Convert.ToInt32(i)));
                int x2 = Convert.ToInt32(i + precision);
                double y2 = startNode.ReturnNewtonDerivative(ReturnXValue(x2));
                try
                {
                    DrawLine(ref g, i, x2, ReturnHeightCoordinate((float)y1), ReturnHeightCoordinate((float)y2), p);
                }
                catch { continue; }
            }
        }

        public void DrawFunctionMaclaurinSeries(ref Graphics g, Pen p)
        {
            bool isNoInput = false;
            if (MaclaurinTerms is null) isNoInput = MaclaurinTermsPrompt();
            if (!isNoInput)
            {
                if (IsShowFunctionAnalyticalMaclaurinSeries) DrawFunctionAnalyticalMaclaurinSeries(ref g, p);
                else DrawFunctionNewtonMaclaurinSeries(ref g, p);
            }
        }

        private void DrawFunctionAnalyticalMaclaurinSeries(ref Graphics g, Pen p)
        {
            for (float i = -halfX; i < halfX; i += precision)
            {
                double y1 = startNode.ReturnMaclaurinSeries(ReturnXValue(Convert.ToInt32(i)), (int)MaclaurinTerms);
                int x2 = Convert.ToInt32(i + precision);
                double y2 = startNode.ReturnMaclaurinSeries(ReturnXValue(x2), (int)MaclaurinTerms);
                try
                {
                    DrawLine(ref g, i, x2, ReturnHeightCoordinate((float)y1), ReturnHeightCoordinate((float)y2), p);
                }
                catch { continue; }
            }
        }

        private void DrawFunctionNewtonMaclaurinSeries(ref Graphics g, Pen p)
        {
            for (float i = -halfX; i < halfX; i += precision)
            {
                double y1 = startNode.ReturnNewtonMaclaurinSeries(ReturnXValue(Convert.ToInt32(i)), (int)MaclaurinTerms);
                int x2 = Convert.ToInt32(i + precision);
                double y2 = startNode.ReturnNewtonMaclaurinSeries(ReturnXValue(x2), (int)MaclaurinTerms);
                try
                {
                    DrawLine(ref g, i, x2, ReturnHeightCoordinate((float)y1), ReturnHeightCoordinate((float)y2), p);
                }
                catch { continue; }
            }
        }

        private void DrawPolynomial(ref Graphics g, Pen p)
        {
            polynomialPoints = polynomialPoints.OrderBy(point => point[0]).ToList();
            float[,] polynomialPointsArray = CreateRectangularArray(polynomialPoints);
            double[] polynomialRoots = PolynomialCalculator.GenerateMatrix(polynomialPointsArray);
            string formula = "0";
            int counter = polynomialRoots.Length - 1;
            foreach (double root in polynomialRoots)
            {
                formula = "+(*(r(" + root + "),^(x," + counter + "))," + formula + ")";
                counter--;
            }
            Parser parser = new Parser();
            PolynomialNode = parser.ParseExpression(formula);
            DrawFunction(ref g, PolynomialNode, p);
        }

        private static T[,] CreateRectangularArray<T>(IList<T[]> arrays)
        {
            int minorLength = arrays[0].Length;
            T[,] ret = new T[arrays.Count, minorLength];
            for (int i = 0; i < arrays.Count; i++)
            {
                var array = arrays[i];
                if (array.Length != minorLength) throw new ArgumentException("All arrays must be the same length.");
                for (int j = 0; j < minorLength; j++)
                {
                    ret[i, j] = array[j];
                }
            }
            return ret;
        }

        public void AddPolynomialPoint(float x, float y)
        {
            float[] point = { x, y };
            foreach (float[] p in polynomialPoints)
            {
                if (p[1] == point[1])
                {
                    MessageBox.Show("You cannot have a function with 2 different x-values for the same y-value!");
                    return;
                }
            }
            polynomialPoints.Add(point);
            Refresh();
        }

        public void DrawFunctionIntegral(ref Graphics g, Pen p)
        {
            bool isNoInput = false;
            double riemannSum = 0;
            if (startPoint == 0 && endPoint == 0)
            {
                isNoInput = IntegralPointsPrompt();
            }
            if (!isNoInput)
            {
                float startPointPixels = ReturnWidthCoordinate(startPoint);
                float endPointPixels = ReturnWidthCoordinate(endPoint);
                List<RectangleF> rectangles = new List<RectangleF>();
                List<PointF> points = CalculatePoints(startPointPixels, endPointPixels, false);
                foreach (PointF point in points)
                {
                    double y = ReturnYValue(Convert.ToInt32(point.Y));
                    if (y < 0) g.FillRectangle(Brushes.Red, point.X, 0, 1, point.Y);
                    else g.FillRectangle(Brushes.Red, point.X, point.Y, 1, -point.Y);
                    riemannSum += y;
                }
                riemannSum = ReturnRealValue(riemannSum);
                g.DrawString("c = " + riemannSum.ToString(), labelFont, labelBrush, (startPointPixels + endPointPixels) / 2 - 15, -30);
                if (rectangles.Count > 1) g.DrawRectangles(p, rectangles.ToArray());
            }
        }

        private bool IntegralPointsPrompt()
        {
            string title = "Enter points for calculating definite integral";

            float startPoint = 0;
            float endPoint = 0;
            while (true)
            {
                string inputStartPoint = InputPrompt.ShowDialog("Enter start point x:", title);
                if (inputStartPoint == "")
                {
                    if (OnIntegralPrompted != null) OnIntegralPrompted();
                    return true;
                }
                try
                {
                    startPoint = float.Parse(inputStartPoint);
                    while (true)
                    {
                        string inputEndPoint = InputPrompt.ShowDialog("Enter end point x:", title);
                        if (inputEndPoint == "") break;
                        try
                        {
                            endPoint = float.Parse(inputEndPoint);
                            break;
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Incorrect format for end point x");
                        }
                    }
                    break;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Incorrect format for start point x");
                }
            }
            SetFunctionDomain(startPoint, endPoint);
            return false;
        }

        private bool MaclaurinTermsPrompt()
        {
            string title = "Enter number of terms for Maclaurin approximation";

            int terms = 0;
            while (true)
            {
                string intputTerms = InputPrompt.ShowDialog("n = ", title);
                if (intputTerms == "")
                {
                    if (OnMaclaurinPrompted != null) OnMaclaurinPrompted();
                    return true;
                }
                try
                {
                    terms = int.Parse(intputTerms);
                    break;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Incorrect format for terms");
                }
            }
            SetNumberOfTerms(terms);
            return false;
        }

        public void TogglePolynomialMode()
        {
            isPolynomialPointsInputFinished = !isPolynomialPointsInputFinished;
            if (!isPolynomialPointsInputFinished) polynomialPoints = new List<float[]>();
            Refresh();
        }

        public void EnablePolynomialMode()
        {
            isPolynomialPointsInputFinished = true;
            polynomialPoints = new List<float[]>();
            Refresh();
        }

        public void DisablePolynomialMode()
        {
            isPolynomialPointsInputFinished = false;
            Refresh();
        }

        private void DrawPoint(ref Graphics g, int x, int y)
        {
            g.DrawLine(Pens.Red, ReturnPoint(-50, 0), ReturnPoint(50, 0));
        }

        private PointF ReturnPoint(float x, float y)
        {
            return new PointF(x * increment, -y * increment);
        }

        public void SetFunctionDomain(float startPoint, float endPoint)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }

        public void SetNumberOfTerms(int terms)
        {
            this.MaclaurinTerms = terms;
        }

        private double ReturnXValue(int xPixels)
        {
            return xPixels / increment;
        }

        private double ReturnYValue(int yPixels)
        {
            return -yPixels / increment;
        }

        private double ReturnRealValue(double value)
        {
            return value / increment;
        }

        private float ReturnWidthCoordinate(float x)
        {
            return x * increment;
        }

        private float ReturnHeightCoordinate(float y)
        {
            return -y * increment;
        }

        public void HideHorizontalLabels()
        {
            IsShowHorizontalAxisLabels = false;
            Refresh();
        }

        public void HideVerticalLabels()
        {
            IsShowVerticalAxisLabels = false;
            Refresh();
        }

        public void HideAxes()
        {
            IsShowAxes = false;
            Refresh();
        }

        public void HideXY()
        {
            IsShowXY = false;
            Refresh();
        }

        public void HideFunction()
        {
            IsShowFunction = false;
            Refresh();
        }

        public void HideInverseFunction()
        {
            IsShowInverseFunction = false;
            Refresh();
        }

        public void HideDerivative()
        {
            IsShowFunctionDerivative = false;
            Refresh();
        }

        public void HideIntegral()
        {
            IsShowFunctionIntegral = false;
            Refresh();
        }

        public void HideMaclaurinSeries()
        {
            IsShowFunctionMaclaurinSeries = false;
            Refresh();
        }

        public void ShowHorizontalLabels()
        {
            IsShowHorizontalAxisLabels = true;
            Refresh();
        }

        public void ShowVerticalLabels()
        {
            IsShowVerticalAxisLabels = true;
            Refresh();
        }

        public void ShowAxes()
        {
            IsShowAxes = true;
            Refresh();
        }

        public void ShowXY()
        {
            IsShowXY = true;
            Refresh();
        }

        public void ShowFunction()
        {
            IsShowFunction = true;
            Refresh();
        }

        public void ShowInverseFunction()
        {
            IsShowInverseFunction = true;
            Refresh();
        }

        public void ShowDerivative()
        {
            IsShowFunctionDerivative = true;
            Refresh();
        }

        public void ShowIntegral()
        {
            IsShowFunctionIntegral = true;
            Refresh();
        }

        public void ShowMaclaurinSeries()
        {
            IsShowFunctionMaclaurinSeries = true;
            Refresh();
        }

        public void SwitchDerivativeAlgorithm()
        {
            IsShowFunctionAnalyticalDerivative = !IsShowFunctionAnalyticalDerivative;
            IsShowFunctionNewtonDerivative = !IsShowFunctionNewtonDerivative;
            Refresh();
        }

        public void EnableAnalyticalDerivative()
        {
            IsShowFunctionAnalyticalDerivative = true;
            IsShowFunctionNewtonDerivative = false;
            Refresh();
        }

        public void EnableNewtonDerivative()
        {
            IsShowFunctionAnalyticalDerivative = false;
            IsShowFunctionNewtonDerivative = true;
            Refresh();
        }

        public void SwitchMaclaurinSeriesAlgorithm()
        {
            IsShowFunctionAnalyticalMaclaurinSeries = !IsShowFunctionAnalyticalMaclaurinSeries;
            IsShowFunctionNewtonMaclaurinSeries = !IsShowFunctionNewtonMaclaurinSeries;
            Refresh();
        }

        public void EnableAnalyticalMaclaurinSeries()
        {
            IsShowFunctionAnalyticalMaclaurinSeries = true;
            IsShowFunctionNewtonMaclaurinSeries = false;
            Refresh();
        }

        public void EnableNewtonMaclaurinSeries()
        {
            IsShowFunctionAnalyticalMaclaurinSeries = false;
            IsShowFunctionNewtonMaclaurinSeries = true;
            Refresh();
        }

        private Font GetCorrectFont(Graphics graphic, String text, Size maxStringSize, Font labelFont)
        {
            //based on the Label string,we need to vary font size 
            //current width the text string
            SizeF sizeStr = graphic.MeasureString(text, labelFont);
            Font fontStr = new Font(labelFont.Name, labelFont.Size);
            while (sizeStr.Width > maxStringSize.Width)
            {
                //adjust the font size based on width ratio
                float wRatio = (maxStringSize.Width) / sizeStr.Width;
                //reduce the font size
                float newSize = (int)(fontStr.Size * wRatio);
                //this creates a new font with given fontfamily name
                fontStr = new Font(labelFont.Name, newSize);
                sizeStr = graphic.MeasureString(text, fontStr);
            }
            return fontStr;
        }

        public float ZoomInTwice()
        {
            increment *= 2;
            Refresh();
            return increment;
        }
        public float ZoomOutTwice()
        {
            if (increment > 15) increment *= 0.5f;
            Refresh();
            return increment;
        }
        public float ZoomIn()
        {
            increment += 5;
            Refresh();
            return increment;
        }
        public float ZoomOut()
        {
            if (increment > 15) increment -= 5;
            Refresh();
            return increment;
        }
        public void ResetScale()
        {
            increment = 50;
            x = y = 0;
            startNode = null;
            Refresh();
        }
        public float GetScale()
        {
            return increment;
        }
        public float GetPrecision()
        {
            return precision;
        }
        public void ChangePrecision(float precision)
        {
            this.precision = precision;
            Refresh();
        }
        public void ExportToPNG(object sender, System.EventArgs e)
        {
            string formula = "";
            if (startNode != null) formula = "_" + PathValidator.ValidatePath(startNode.ToString());
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Images| *.png";
                sfd.DefaultExt = "png";
                sfd.FileName = "graph" + formula;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bitmap = new Bitmap(pictureBoxGraph.ClientSize.Width, pictureBoxGraph.ClientSize.Height);
                    pictureBoxGraph.DrawToBitmap(bitmap, pictureBoxGraph.ClientRectangle);
                    bitmap.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }
    }
}
