namespace CVisualizer
{
    partial class MainInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainInterface));
            this.tbxInput = new System.Windows.Forms.TextBox();
            this.btnVisualize = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.pictureBoxGraph = new System.Windows.Forms.PictureBox();
            this.btnResetScale = new System.Windows.Forms.Button();
            this.btnShowDetails = new System.Windows.Forms.Button();
            this.chbHorizontalLabels = new System.Windows.Forms.CheckBox();
            this.chbVerticalLabels = new System.Windows.Forms.CheckBox();
            this.chbAxes = new System.Windows.Forms.CheckBox();
            this.chbFunctionDerivative = new System.Windows.Forms.CheckBox();
            this.chbFunction = new System.Windows.Forms.CheckBox();
            this.chbFunctionIntegral = new System.Windows.Forms.CheckBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.chbXY = new System.Windows.Forms.CheckBox();
            this.chbInverseFunction = new System.Windows.Forms.CheckBox();
            this.lblMousePosition = new System.Windows.Forms.Label();
            this.lblUnitScale = new System.Windows.Forms.Label();
            this.chbFunctionMaclaurin = new System.Windows.Forms.CheckBox();
            this.chbPolynomial = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxInput
            // 
            this.tbxInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxInput.Location = new System.Drawing.Point(12, 12);
            this.tbxInput.Name = "tbxInput";
            this.tbxInput.Size = new System.Drawing.Size(759, 20);
            this.tbxInput.TabIndex = 0;
            this.tbxInput.Enter += new System.EventHandler(this.tbxInput_Enter);
            this.tbxInput.Leave += new System.EventHandler(this.tbxInput_Leave);
            // 
            // btnVisualize
            // 
            this.btnVisualize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisualize.Location = new System.Drawing.Point(777, 10);
            this.btnVisualize.Name = "btnVisualize";
            this.btnVisualize.Size = new System.Drawing.Size(75, 23);
            this.btnVisualize.TabIndex = 1;
            this.btnVisualize.Text = "Visualize";
            this.btnVisualize.UseVisualStyleBackColor = true;
            this.btnVisualize.Click += new System.EventHandler(this.btnVisualize_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomIn.Location = new System.Drawing.Point(887, 75);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(34, 31);
            this.btnZoomIn.TabIndex = 3;
            this.btnZoomIn.Text = "+";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomOut.Location = new System.Drawing.Point(887, 112);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(34, 31);
            this.btnZoomOut.TabIndex = 4;
            this.btnZoomOut.Text = "-";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // pictureBoxGraph
            // 
            this.pictureBoxGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxGraph.Location = new System.Drawing.Point(12, 63);
            this.pictureBoxGraph.Name = "pictureBoxGraph";
            this.pictureBoxGraph.Size = new System.Drawing.Size(921, 449);
            this.pictureBoxGraph.TabIndex = 2;
            this.pictureBoxGraph.TabStop = false;
            this.pictureBoxGraph.Click += new System.EventHandler(this.pictureBoxGraph_Click);
            this.pictureBoxGraph.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraph_MouseDown);
            this.pictureBoxGraph.MouseEnter += new System.EventHandler(this.pictureBoxGraph_MouseEnter);
            this.pictureBoxGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraph_MouseMove);
            this.pictureBoxGraph.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraph_MouseWheel);
            // 
            // btnResetScale
            // 
            this.btnResetScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetScale.Location = new System.Drawing.Point(858, 149);
            this.btnResetScale.Name = "btnResetScale";
            this.btnResetScale.Size = new System.Drawing.Size(63, 23);
            this.btnResetScale.TabIndex = 5;
            this.btnResetScale.Text = "Reset";
            this.btnResetScale.UseVisualStyleBackColor = true;
            this.btnResetScale.Click += new System.EventHandler(this.btnResetScale_Click);
            // 
            // btnShowDetails
            // 
            this.btnShowDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowDetails.Location = new System.Drawing.Point(858, 36);
            this.btnShowDetails.Name = "btnShowDetails";
            this.btnShowDetails.Size = new System.Drawing.Size(75, 23);
            this.btnShowDetails.TabIndex = 6;
            this.btnShowDetails.Text = "Details";
            this.btnShowDetails.UseVisualStyleBackColor = true;
            this.btnShowDetails.Click += new System.EventHandler(this.btnShowDetails_Click);
            // 
            // chbHorizontalLabels
            // 
            this.chbHorizontalLabels.AutoSize = true;
            this.chbHorizontalLabels.Checked = true;
            this.chbHorizontalLabels.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbHorizontalLabels.Location = new System.Drawing.Point(12, 40);
            this.chbHorizontalLabels.Name = "chbHorizontalLabels";
            this.chbHorizontalLabels.Size = new System.Drawing.Size(103, 17);
            this.chbHorizontalLabels.TabIndex = 8;
            this.chbHorizontalLabels.Text = "Horizontal labels";
            this.chbHorizontalLabels.UseVisualStyleBackColor = true;
            this.chbHorizontalLabels.CheckedChanged += new System.EventHandler(this.chbHorizontalLabels_CheckedChanged);
            // 
            // chbVerticalLabels
            // 
            this.chbVerticalLabels.AutoSize = true;
            this.chbVerticalLabels.Checked = true;
            this.chbVerticalLabels.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbVerticalLabels.Location = new System.Drawing.Point(121, 40);
            this.chbVerticalLabels.Name = "chbVerticalLabels";
            this.chbVerticalLabels.Size = new System.Drawing.Size(91, 17);
            this.chbVerticalLabels.TabIndex = 9;
            this.chbVerticalLabels.Text = "Vertical labels";
            this.chbVerticalLabels.UseVisualStyleBackColor = true;
            this.chbVerticalLabels.CheckedChanged += new System.EventHandler(this.chbVerticalLabels_CheckedChanged);
            // 
            // chbAxes
            // 
            this.chbAxes.AutoSize = true;
            this.chbAxes.Checked = true;
            this.chbAxes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAxes.Location = new System.Drawing.Point(218, 40);
            this.chbAxes.Name = "chbAxes";
            this.chbAxes.Size = new System.Drawing.Size(49, 17);
            this.chbAxes.TabIndex = 10;
            this.chbAxes.Text = "Axes";
            this.chbAxes.UseVisualStyleBackColor = true;
            this.chbAxes.CheckedChanged += new System.EventHandler(this.chbAxes_CheckedChanged);
            // 
            // chbFunctionDerivative
            // 
            this.chbFunctionDerivative.AutoSize = true;
            this.chbFunctionDerivative.Location = new System.Drawing.Point(486, 40);
            this.chbFunctionDerivative.Name = "chbFunctionDerivative";
            this.chbFunctionDerivative.Size = new System.Drawing.Size(74, 17);
            this.chbFunctionDerivative.TabIndex = 11;
            this.chbFunctionDerivative.Text = "Derivative";
            this.chbFunctionDerivative.UseVisualStyleBackColor = true;
            this.chbFunctionDerivative.CheckedChanged += new System.EventHandler(this.chbFunctionDerivative_CheckedChanged);
            // 
            // chbFunction
            // 
            this.chbFunction.AutoSize = true;
            this.chbFunction.Checked = true;
            this.chbFunction.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbFunction.Location = new System.Drawing.Point(346, 40);
            this.chbFunction.Name = "chbFunction";
            this.chbFunction.Size = new System.Drawing.Size(67, 17);
            this.chbFunction.TabIndex = 12;
            this.chbFunction.Text = "Function";
            this.chbFunction.UseVisualStyleBackColor = true;
            this.chbFunction.CheckedChanged += new System.EventHandler(this.chbFunction_CheckedChanged);
            // 
            // chbFunctionIntegral
            // 
            this.chbFunctionIntegral.AutoSize = true;
            this.chbFunctionIntegral.Location = new System.Drawing.Point(565, 40);
            this.chbFunctionIntegral.Name = "chbFunctionIntegral";
            this.chbFunctionIntegral.Size = new System.Drawing.Size(61, 17);
            this.chbFunctionIntegral.TabIndex = 13;
            this.chbFunctionIntegral.Text = "Integral";
            this.chbFunctionIntegral.UseVisualStyleBackColor = true;
            this.chbFunctionIntegral.CheckedChanged += new System.EventHandler(this.chbFunctionIntegral_CheckedChanged);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.Location = new System.Drawing.Point(858, 10);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 14;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // chbXY
            // 
            this.chbXY.AutoSize = true;
            this.chbXY.Location = new System.Drawing.Point(273, 40);
            this.chbXY.Name = "chbXY";
            this.chbXY.Size = new System.Drawing.Size(67, 17);
            this.chbXY.TabIndex = 15;
            this.chbXY.Text = "x = y line";
            this.chbXY.UseVisualStyleBackColor = true;
            this.chbXY.CheckedChanged += new System.EventHandler(this.chbXY_CheckedChanged);
            // 
            // chbInverseFunction
            // 
            this.chbInverseFunction.AutoSize = true;
            this.chbInverseFunction.Location = new System.Drawing.Point(419, 40);
            this.chbInverseFunction.Name = "chbInverseFunction";
            this.chbInverseFunction.Size = new System.Drawing.Size(61, 17);
            this.chbInverseFunction.TabIndex = 16;
            this.chbInverseFunction.Text = "Inverse";
            this.chbInverseFunction.UseVisualStyleBackColor = true;
            this.chbInverseFunction.CheckedChanged += new System.EventHandler(this.chbInverseFunction_CheckedChanged);
            // 
            // lblMousePosition
            // 
            this.lblMousePosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMousePosition.AutoSize = true;
            this.lblMousePosition.Location = new System.Drawing.Point(880, 481);
            this.lblMousePosition.Name = "lblMousePosition";
            this.lblMousePosition.Size = new System.Drawing.Size(26, 13);
            this.lblMousePosition.TabIndex = 17;
            this.lblMousePosition.Text = "(x,y)";
            // 
            // lblUnitScale
            // 
            this.lblUnitScale.AutoSize = true;
            this.lblUnitScale.Location = new System.Drawing.Point(20, 71);
            this.lblUnitScale.Name = "lblUnitScale";
            this.lblUnitScale.Size = new System.Drawing.Size(54, 13);
            this.lblUnitScale.TabIndex = 18;
            this.lblUnitScale.Text = "Unit scale";
            // 
            // chbFunctionMaclaurin
            // 
            this.chbFunctionMaclaurin.AutoSize = true;
            this.chbFunctionMaclaurin.Location = new System.Drawing.Point(627, 40);
            this.chbFunctionMaclaurin.Name = "chbFunctionMaclaurin";
            this.chbFunctionMaclaurin.Size = new System.Drawing.Size(72, 17);
            this.chbFunctionMaclaurin.TabIndex = 19;
            this.chbFunctionMaclaurin.Text = "Maclaurin";
            this.chbFunctionMaclaurin.UseVisualStyleBackColor = true;
            this.chbFunctionMaclaurin.CheckedChanged += new System.EventHandler(this.chbFunctionMaclaurin_CheckedChanged);
            // 
            // chbPolynomial
            // 
            this.chbPolynomial.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbPolynomial.AutoSize = true;
            this.chbPolynomial.Location = new System.Drawing.Point(704, 36);
            this.chbPolynomial.Name = "chbPolynomial";
            this.chbPolynomial.Size = new System.Drawing.Size(67, 23);
            this.chbPolynomial.TabIndex = 20;
            this.chbPolynomial.Text = "Polynomial";
            this.chbPolynomial.UseVisualStyleBackColor = true;
            this.chbPolynomial.CheckedChanged += new System.EventHandler(this.chbPolynomial_CheckedChanged);
            // 
            // MainInterface
            // 
            this.AcceptButton = this.btnVisualize;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 524);
            this.Controls.Add(this.chbPolynomial);
            this.Controls.Add(this.chbFunctionMaclaurin);
            this.Controls.Add(this.lblUnitScale);
            this.Controls.Add(this.lblMousePosition);
            this.Controls.Add(this.chbInverseFunction);
            this.Controls.Add(this.chbXY);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.chbFunctionIntegral);
            this.Controls.Add(this.chbFunction);
            this.Controls.Add(this.chbFunctionDerivative);
            this.Controls.Add(this.chbAxes);
            this.Controls.Add(this.chbVerticalLabels);
            this.Controls.Add(this.chbHorizontalLabels);
            this.Controls.Add(this.btnShowDetails);
            this.Controls.Add(this.btnResetScale);
            this.Controls.Add(this.btnZoomOut);
            this.Controls.Add(this.btnZoomIn);
            this.Controls.Add(this.pictureBoxGraph);
            this.Controls.Add(this.btnVisualize);
            this.Controls.Add(this.tbxInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainInterface";
            this.Text = "CVisualizer";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainInterface_KeyDown);
            this.Resize += new System.EventHandler(this.MainInterface_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxInput;
        private System.Windows.Forms.Button btnVisualize;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.PictureBox pictureBoxGraph;
        private System.Windows.Forms.Button btnResetScale;
        private System.Windows.Forms.Button btnShowDetails;
        private System.Windows.Forms.CheckBox chbHorizontalLabels;
        private System.Windows.Forms.CheckBox chbVerticalLabels;
        private System.Windows.Forms.CheckBox chbAxes;
        private System.Windows.Forms.CheckBox chbFunctionDerivative;
        private System.Windows.Forms.CheckBox chbFunction;
        private System.Windows.Forms.CheckBox chbFunctionIntegral;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.CheckBox chbXY;
        private System.Windows.Forms.CheckBox chbInverseFunction;
        private System.Windows.Forms.Label lblMousePosition;
        private System.Windows.Forms.Label lblUnitScale;
        private System.Windows.Forms.CheckBox chbFunctionMaclaurin;
        private System.Windows.Forms.CheckBox chbPolynomial;
    }
}

