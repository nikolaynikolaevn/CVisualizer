using System;
using System.Windows.Forms;

namespace CVisualizer
{
    partial class Settings : Form
    {
        private GraphDrawer graphDrawer;
        public delegate void ChangeParameterHandler();
        public event ChangeParameterHandler PrecisionChanged;
        private bool isInit;
        public Settings(ref GraphDrawer graphDrawer)
        {
            InitializeComponent();
            this.graphDrawer = graphDrawer;
            trackBarPrecision.Value = Convert.ToInt32(-this.graphDrawer.GetPrecision());
            InitValues();
        }

        private void InitValues()
        {
            if (graphDrawer.IsShowFunctionAnalyticalDerivative) cbDerivativeAlgorithm.SelectedIndex = 0;
            else cbDerivativeAlgorithm.SelectedIndex = 1;
            if (graphDrawer.IsShowFunctionAnalyticalMaclaurinSeries) cbMaclaurinSeriesAlgorithm.SelectedIndex = 0;
            else cbMaclaurinSeriesAlgorithm.SelectedIndex = 1;
            isInit = true;
        }

        private void trackBarPrecision_ValueChanged(object sender, EventArgs e)
        {
            if (trackBarPrecision.IsHandleCreated) graphDrawer.ChangePrecision(-trackBarPrecision.Value);
            if (PrecisionChanged != null) PrecisionChanged();
        }

        private void cbDerivativeAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInit)
            {
                if (cbDerivativeAlgorithm.SelectedIndex == 0) graphDrawer.EnableAnalyticalDerivative();
                else graphDrawer.EnableNewtonDerivative();
            }
        }

        private void cbMaclaurinSeriesAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInit)
            {
                if (cbMaclaurinSeriesAlgorithm.SelectedIndex == 0) graphDrawer.EnableAnalyticalMaclaurinSeries();
                else graphDrawer.EnableNewtonMaclaurinSeries();
            }
        }
    }
}
