using System;
using System.Drawing;
using System.Windows.Forms;

namespace CVisualizer
{
    public partial class ShowDetails : Form
    {
        Node root;
        Node rootDerivative;
        Node rootMaclaurinSeries;
        Node rootPolynomial;
        Node simpleRoot;
        Node simpleRootDerivative;
        BinaryTreeDrawer binaryTreeDrawer;
        string functionBinaryTreeName = "functionBinaryTree";
        string functionDerivativeBinaryTreeName = "functionDerivativeBinaryTree";
        string simpleFunctionBinaryTreeName = "simpleFunctionBinaryTree";
        string simpleFunctionDerivativeBinaryTreeName = "simpleFunctionDerivativeBinaryTree";
        string functionMaclaurinSeriesBinaryTreeName = "functionMaclaurinSeriesBinaryTree";
        string polynomialBinaryTreeName = "polynomialBinaryTree";
        public ShowDetails(Node root, Node polynomial, int ?terms)
        {
            InitializeComponent();
            this.root = root;
            this.rootDerivative = root.ReturnDerivative(1);
            if (terms != null)
            {
                this.rootMaclaurinSeries = root.ReturnMaclaurinSeriesPolynomial(0, terms.Value);
            }
            else rbtnMaclaurinSeries.Visible = false;
            if (polynomial != null)
            {
                this.rootPolynomial = polynomial;
            }
            else rbtnPolynomial.Visible = false;
            this.simpleRoot = root.Simplify();
            this.simpleRootDerivative = root.ReturnDerivative(1).Simplify();
            GenerateImage(root, functionBinaryTreeName);
            UpdateExpressionLabel(root);

            ContextMenu cm = new ContextMenu();
            pictureBoxBinaryTree.ContextMenu = cm;
            cm.MenuItems.Add("Export", new EventHandler(ExportToPNG));
        }

        public void ExportToPNG(object sender, System.EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Images| *.png";
                sfd.DefaultExt = "png";
                sfd.FileName = "binary-tree-graph_" + PathValidator.ValidatePath(lblInfixExpression.Text);
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bitmap = new Bitmap(pictureBoxBinaryTree.ClientSize.Width, pictureBoxBinaryTree.ClientSize.Height);
                    pictureBoxBinaryTree.DrawToBitmap(bitmap, pictureBoxBinaryTree.ClientRectangle);
                    bitmap.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }
        private void GenerateImage(Node n, string name)
        {
            binaryTreeDrawer = new BinaryTreeDrawer(n);
            pictureBoxBinaryTree.ImageLocation = binaryTreeDrawer.GenerateBinaryTreeGraph(name);
        }
        private void UpdateExpressionLabel(Node n)
        {
            lblInfixExpression.Text = n.ToString();
            lblPrefixExpression.Text = n.ToPrefixString();
        }
        private void rbtnFunction_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnFunction.Checked) ShowFunction();
        }
        private void rbtnMaclaurinSeries_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnMaclaurinSeries.Checked) ShowFunctionMaclaurinSeries();
        }

        private void rbtnPolynomial_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPolynomial.Checked) ShowPolynomial();
        }

        private void rbtnFunctionDerivative_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnFunctionDerivative.Checked) ShowFunctionDerivative();
        }
        private void ShowFunction()
        {
            if (chbSimplify.Checked)
            {
                GenerateImage(simpleRoot, simpleFunctionBinaryTreeName);
                UpdateExpressionLabel(simpleRoot);
            }
            else
            {
                GenerateImage(root, functionBinaryTreeName);
                UpdateExpressionLabel(root);
            }
        }
        private void ShowFunctionDerivative()
        {
            if (chbSimplify.Checked)
            {
                GenerateImage(simpleRootDerivative, simpleFunctionDerivativeBinaryTreeName);
                UpdateExpressionLabel(simpleRootDerivative);
            }
            else
            {
                GenerateImage(rootDerivative, functionDerivativeBinaryTreeName);
                UpdateExpressionLabel(rootDerivative);
            }
        }
        private void ShowFunctionMaclaurinSeries()
        {
            GenerateImage(rootMaclaurinSeries, functionMaclaurinSeriesBinaryTreeName);
            UpdateExpressionLabel(rootMaclaurinSeries);
        }

        private void ShowPolynomial()
        {
            GenerateImage(rootPolynomial, polynomialBinaryTreeName);
            UpdateExpressionLabel(rootPolynomial);
        }

        private void chbSimplify_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnFunction.Checked) ShowFunction();
            else if (rbtnMaclaurinSeries.Checked) ShowFunctionMaclaurinSeries();
            else if (rbtnPolynomial.Checked) ShowPolynomial();
            else ShowFunctionDerivative();
        }
    }
}
