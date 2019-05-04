using System;
using System.Drawing;
using System.Windows.Forms;

namespace CVisualizer
{
    public partial class MainInterface : Form
    {
        private Parser parser;
        private GraphDrawer graphDrawer;
        private Node n;
        private ContextMenu cm;
        private Settings settingsForm;
        private ShowDetails showDetailsForm;
        public MainInterface()
        {
            InitializeComponent();
            parser = new Parser();
            graphDrawer = new GraphDrawer();
            this.pictureBoxGraph.Paint += new System.Windows.Forms.PaintEventHandler(graphDrawer.DrawCoordinateSystem);
            UpdateUnitScale();
            cm = new ContextMenu();
            pictureBoxGraph.ContextMenu = cm;
            cm.MenuItems.Add("Export", new EventHandler(graphDrawer.ExportToPNG));
        }

        private void btnVisualize_Click(object sender, EventArgs e)
        {
            try
            {
                n = parser.ParseExpression(tbxInput.Text);
            }
            catch (Exception ex)
            {
                DirectMessage.ShowError(ex.Message);
            }
            this.pictureBoxGraph.Paint -= new System.Windows.Forms.PaintEventHandler(graphDrawer.DrawCoordinateSystem);
            graphDrawer = new GraphDrawer(n, chbHorizontalLabels.Checked, chbVerticalLabels.Checked, chbAxes.Checked, chbXY.Checked, chbFunction.Checked,
                chbInverseFunction.Checked, chbFunctionDerivative.Checked, chbFunctionIntegral.Checked, chbFunctionMaclaurin.Checked);
            this.pictureBoxGraph.Paint += new System.Windows.Forms.PaintEventHandler(graphDrawer.DrawCoordinateSystem);
            graphDrawer.OnIntegralPrompted += new GraphDrawer.FunctionDomainPrompt(HideFunctionIntegral);
            graphDrawer.OnMaclaurinPrompted += new GraphDrawer.FunctionDomainPrompt(HideFunctionMaclaurin);
            pictureBoxGraph.Refresh();
            cm.MenuItems.Clear();
            cm.MenuItems.Add("Export", new EventHandler(graphDrawer.ExportToPNG));
            if (settingsForm != null)
            {
                if (IsSettingsFormOpened())
                {
                    settingsForm.Close();
                    settingsForm = null;
                    OpenSettingsForm();
                }
            }
            chbPolynomial.Checked = false;
            graphDrawer.DisablePolynomialMode();
            ActiveControl = null;
        }

        private void HideFunctionIntegral()
        {
            chbFunctionIntegral.Checked = false;
        }

        private void HideFunctionMaclaurin()
        {
            chbFunctionMaclaurin.Checked = false;
        }

        private void MainInterface_Resize(object sender, EventArgs e)
        {
            this.pictureBoxGraph.Invalidate();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            graphDrawer.ZoomIn();
            UpdateUnitScale();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            graphDrawer.ZoomOut();
            UpdateUnitScale();
        }

        private void btnResetScale_Click(object sender, EventArgs e)
        {
            graphDrawer.ResetScale();
            UpdateUnitScale();
        }

        private void MainInterface_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private Point MouseDownLocation;

        private void pictureBoxGraph_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void pictureBoxGraph_MouseMove(object sender, MouseEventArgs e)
        {
            PointF p = graphDrawer.GetMouseLocation(e.Location, false);
            lblMousePosition.Text = "x = " + Math.Round(p.X, 3) + "\ny = " + Math.Round(p.Y, 3);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                graphDrawer.Move(-(e.X - MouseDownLocation.X) / 20, (e.Y - MouseDownLocation.Y) / 20);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!tbxInput.Focused)
            {
                if ((keyData == Keys.Right) || (keyData == Keys.Left) || (keyData == Keys.Up) || (keyData == Keys.Down))
                {
                    int code = (int)keyData;
                    if (code == 37)
                    {
                        graphDrawer.Move(-5, 0);
                    }
                    else if (code == 38)
                    {
                        graphDrawer.Move(0, 5);
                    }
                    else if (code == 39)
                    {
                        graphDrawer.Move(5, 0);
                    }
                    else
                    {
                        graphDrawer.Move(0, -5);
                    }
                    return true;
                }
                return false;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void pictureBoxGraph_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) graphDrawer.ZoomIn();
            else graphDrawer.ZoomOut();
            UpdateUnitScale();
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            if (n != null)
            {
                FormCollection fc = Application.OpenForms;
                foreach (Form frm in fc)
                {
                    if (frm is ShowDetails)
                    {
                        showDetailsForm = (ShowDetails)frm;
                        showDetailsForm.Focus();
                    }
                }
                if (showDetailsForm != null)
                {
                    showDetailsForm.Close();
                }
                showDetailsForm = new ShowDetails(n, graphDrawer.PolynomialNode, graphDrawer.MaclaurinTerms);
                showDetailsForm.Show();
            }
        }

        private void chbHorizontalLabels_CheckedChanged(object sender, EventArgs e)
        {
            if (chbHorizontalLabels.Checked) graphDrawer.ShowHorizontalLabels();
            else graphDrawer.HideHorizontalLabels();
        }

        private void chbVerticalLabels_CheckedChanged(object sender, EventArgs e)
        {
            if (chbVerticalLabels.Checked) graphDrawer.ShowVerticalLabels();
            else graphDrawer.HideVerticalLabels();
        }

        private void chbAxes_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAxes.Checked) graphDrawer.ShowAxes();
            else graphDrawer.HideAxes();
        }

        private void chbXY_CheckedChanged(object sender, EventArgs e)
        {
            if (chbXY.Checked) graphDrawer.ShowXY();
            else graphDrawer.HideXY();
        }

        private void chbFunction_CheckedChanged(object sender, EventArgs e)
        {
            if (chbFunction.Checked) graphDrawer.ShowFunction();
            else graphDrawer.HideFunction();
        }

        private void chbInverseFunction_CheckedChanged(object sender, EventArgs e)
        {
            if (chbInverseFunction.Checked) graphDrawer.ShowInverseFunction();
            else graphDrawer.HideInverseFunction();
        }

        private void chbFunctionDerivative_CheckedChanged(object sender, EventArgs e)
        {
            if (chbFunctionDerivative.Checked) graphDrawer.ShowDerivative();
            else graphDrawer.HideDerivative();
        }

        private void chbFunctionIntegral_CheckedChanged(object sender, EventArgs e)
        {
            if (chbFunctionIntegral.Checked) graphDrawer.ShowIntegral();
            else graphDrawer.HideIntegral();
        }

        private void chbFunctionMaclaurin_CheckedChanged(object sender, EventArgs e)
        {
            if (chbFunctionMaclaurin.Checked) graphDrawer.ShowMaclaurinSeries();
            else graphDrawer.HideMaclaurinSeries();
        }

        private void UpdateUnitScale()
        {
            lblUnitScale.Text = graphDrawer.GetScale() + " pixels / unit";
        }

        private void OpenSettingsForm()
        {
            if (IsSettingsFormOpened()) settingsForm.Focus();
            else
            {
                settingsForm = new Settings(ref graphDrawer);
                settingsForm.Show();
            }
        }

        private bool IsSettingsFormOpened()
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm is Settings)
                {
                    return true;
                }
            }
            return false;
        }

        private void pictureBoxGraph_Click(object sender, EventArgs e)
        {
            if (chbPolynomial.Checked)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                PointF p = graphDrawer.GetMouseLocation(me.Location, false);
                graphDrawer.AddPolynomialPoint(p.X, p.Y);
            }
        }

        private void chbPolynomial_CheckedChanged(object sender, EventArgs e)
        {
            graphDrawer.TogglePolynomialMode();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            OpenSettingsForm();
        }

        private void tbxInput_Enter(object sender, EventArgs e)
        {
            KeyPreview = false;
        }

        private void tbxInput_Leave(object sender, EventArgs e)
        {
            KeyPreview = true;
        }

        private void pictureBoxGraph_MouseEnter(object sender, EventArgs e)
        {
            ActiveControl = null;
        }
    }
}
