namespace CVisualizer
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.trackBarPrecision = new System.Windows.Forms.TrackBar();
            this.lblPrecision = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.cbDerivativeAlgorithm = new System.Windows.Forms.ComboBox();
            this.cbMaclaurinSeriesAlgorithm = new System.Windows.Forms.ComboBox();
            this.lblDerivativeAlgorithm = new System.Windows.Forms.Label();
            this.lblMaclaurinSeriesAlgorithm = new System.Windows.Forms.Label();
            this.lblAlgorithms = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPrecision)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarPrecision
            // 
            this.trackBarPrecision.AccessibleDescription = "";
            this.trackBarPrecision.Location = new System.Drawing.Point(57, 26);
            this.trackBarPrecision.Maximum = -1;
            this.trackBarPrecision.Minimum = -100;
            this.trackBarPrecision.Name = "trackBarPrecision";
            this.trackBarPrecision.Size = new System.Drawing.Size(242, 45);
            this.trackBarPrecision.TabIndex = 0;
            this.trackBarPrecision.Tag = "";
            this.trackBarPrecision.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarPrecision.Value = -1;
            this.trackBarPrecision.ValueChanged += new System.EventHandler(this.trackBarPrecision_ValueChanged);
            // 
            // lblPrecision
            // 
            this.lblPrecision.AutoSize = true;
            this.lblPrecision.Location = new System.Drawing.Point(54, 10);
            this.lblPrecision.Name = "lblPrecision";
            this.lblPrecision.Size = new System.Drawing.Size(50, 13);
            this.lblPrecision.TabIndex = 1;
            this.lblPrecision.Text = "Precision";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(10, 39);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(41, 13);
            this.lblMin.TabIndex = 2;
            this.lblMin.Text = "Lowest";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(305, 39);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(43, 13);
            this.lblMax.TabIndex = 3;
            this.lblMax.Text = "Highest";
            // 
            // cbDerivativeAlgorithm
            // 
            this.cbDerivativeAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDerivativeAlgorithm.FormattingEnabled = true;
            this.cbDerivativeAlgorithm.Items.AddRange(new object[] {
            "Analytical",
            "Newton"});
            this.cbDerivativeAlgorithm.Location = new System.Drawing.Point(221, 92);
            this.cbDerivativeAlgorithm.Name = "cbDerivativeAlgorithm";
            this.cbDerivativeAlgorithm.Size = new System.Drawing.Size(121, 21);
            this.cbDerivativeAlgorithm.TabIndex = 4;
            this.cbDerivativeAlgorithm.SelectedIndexChanged += new System.EventHandler(this.cbDerivativeAlgorithm_SelectedIndexChanged);
            // 
            // cbMaclaurinSeriesAlgorithm
            // 
            this.cbMaclaurinSeriesAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaclaurinSeriesAlgorithm.FormattingEnabled = true;
            this.cbMaclaurinSeriesAlgorithm.Items.AddRange(new object[] {
            "Analytical",
            "Newton"});
            this.cbMaclaurinSeriesAlgorithm.Location = new System.Drawing.Point(221, 119);
            this.cbMaclaurinSeriesAlgorithm.Name = "cbMaclaurinSeriesAlgorithm";
            this.cbMaclaurinSeriesAlgorithm.Size = new System.Drawing.Size(121, 21);
            this.cbMaclaurinSeriesAlgorithm.TabIndex = 5;
            this.cbMaclaurinSeriesAlgorithm.SelectedIndexChanged += new System.EventHandler(this.cbMaclaurinSeriesAlgorithm_SelectedIndexChanged);
            // 
            // lblDerivativeAlgorithm
            // 
            this.lblDerivativeAlgorithm.AutoSize = true;
            this.lblDerivativeAlgorithm.Location = new System.Drawing.Point(10, 92);
            this.lblDerivativeAlgorithm.Name = "lblDerivativeAlgorithm";
            this.lblDerivativeAlgorithm.Size = new System.Drawing.Size(55, 13);
            this.lblDerivativeAlgorithm.TabIndex = 6;
            this.lblDerivativeAlgorithm.Text = "Derivative";
            // 
            // lblMaclaurinSeriesAlgorithm
            // 
            this.lblMaclaurinSeriesAlgorithm.AutoSize = true;
            this.lblMaclaurinSeriesAlgorithm.Location = new System.Drawing.Point(10, 119);
            this.lblMaclaurinSeriesAlgorithm.Name = "lblMaclaurinSeriesAlgorithm";
            this.lblMaclaurinSeriesAlgorithm.Size = new System.Drawing.Size(85, 13);
            this.lblMaclaurinSeriesAlgorithm.TabIndex = 7;
            this.lblMaclaurinSeriesAlgorithm.Text = "Maclaurin Series";
            // 
            // lblAlgorithms
            // 
            this.lblAlgorithms.AutoSize = true;
            this.lblAlgorithms.Location = new System.Drawing.Point(284, 76);
            this.lblAlgorithms.Name = "lblAlgorithms";
            this.lblAlgorithms.Size = new System.Drawing.Size(58, 13);
            this.lblAlgorithms.TabIndex = 8;
            this.lblAlgorithms.Text = "Algorithms:";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 164);
            this.Controls.Add(this.lblAlgorithms);
            this.Controls.Add(this.lblMaclaurinSeriesAlgorithm);
            this.Controls.Add(this.lblDerivativeAlgorithm);
            this.Controls.Add(this.cbMaclaurinSeriesAlgorithm);
            this.Controls.Add(this.cbDerivativeAlgorithm);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblPrecision);
            this.Controls.Add(this.trackBarPrecision);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPrecision)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarPrecision;
        private System.Windows.Forms.Label lblPrecision;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.ComboBox cbDerivativeAlgorithm;
        private System.Windows.Forms.ComboBox cbMaclaurinSeriesAlgorithm;
        private System.Windows.Forms.Label lblDerivativeAlgorithm;
        private System.Windows.Forms.Label lblMaclaurinSeriesAlgorithm;
        private System.Windows.Forms.Label lblAlgorithms;
    }
}