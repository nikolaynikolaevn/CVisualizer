namespace CVisualizer
{
    partial class ShowDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowDetails));
            this.lblBinaryTree = new System.Windows.Forms.Label();
            this.pictureBoxBinaryTree = new System.Windows.Forms.PictureBox();
            this.lblInfixExpression = new System.Windows.Forms.Label();
            this.rbtnFunction = new System.Windows.Forms.RadioButton();
            this.rbtnFunctionDerivative = new System.Windows.Forms.RadioButton();
            this.chbSimplify = new System.Windows.Forms.CheckBox();
            this.rbtnMaclaurinSeries = new System.Windows.Forms.RadioButton();
            this.rbtnPolynomial = new System.Windows.Forms.RadioButton();
            this.lblPrefixExpression = new System.Windows.Forms.Label();
            this.lblInfix = new System.Windows.Forms.Label();
            this.lblPrefix = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBinaryTree)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBinaryTree
            // 
            this.lblBinaryTree.AutoSize = true;
            this.lblBinaryTree.Location = new System.Drawing.Point(9, 16);
            this.lblBinaryTree.Name = "lblBinaryTree";
            this.lblBinaryTree.Size = new System.Drawing.Size(57, 13);
            this.lblBinaryTree.TabIndex = 0;
            this.lblBinaryTree.Text = "Binary tree";
            // 
            // pictureBoxBinaryTree
            // 
            this.pictureBoxBinaryTree.Location = new System.Drawing.Point(12, 63);
            this.pictureBoxBinaryTree.Name = "pictureBoxBinaryTree";
            this.pictureBoxBinaryTree.Size = new System.Drawing.Size(717, 259);
            this.pictureBoxBinaryTree.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBinaryTree.TabIndex = 1;
            this.pictureBoxBinaryTree.TabStop = false;
            // 
            // lblInfixExpression
            // 
            this.lblInfixExpression.AutoSize = true;
            this.lblInfixExpression.Location = new System.Drawing.Point(116, 16);
            this.lblInfixExpression.Name = "lblInfixExpression";
            this.lblInfixExpression.Size = new System.Drawing.Size(98, 13);
            this.lblInfixExpression.TabIndex = 2;
            this.lblInfixExpression.Text = "<ExpressionInInfix>";
            // 
            // rbtnFunction
            // 
            this.rbtnFunction.AutoSize = true;
            this.rbtnFunction.Checked = true;
            this.rbtnFunction.Location = new System.Drawing.Point(12, 40);
            this.rbtnFunction.Name = "rbtnFunction";
            this.rbtnFunction.Size = new System.Drawing.Size(66, 17);
            this.rbtnFunction.TabIndex = 3;
            this.rbtnFunction.TabStop = true;
            this.rbtnFunction.Text = "Function";
            this.rbtnFunction.UseVisualStyleBackColor = true;
            this.rbtnFunction.CheckedChanged += new System.EventHandler(this.rbtnFunction_CheckedChanged);
            // 
            // rbtnFunctionDerivative
            // 
            this.rbtnFunctionDerivative.Location = new System.Drawing.Point(84, 40);
            this.rbtnFunctionDerivative.Name = "rbtnFunctionDerivative";
            this.rbtnFunctionDerivative.Size = new System.Drawing.Size(122, 17);
            this.rbtnFunctionDerivative.TabIndex = 0;
            this.rbtnFunctionDerivative.Text = "Function derivative";
            this.rbtnFunctionDerivative.UseVisualStyleBackColor = true;
            this.rbtnFunctionDerivative.CheckedChanged += new System.EventHandler(this.rbtnFunctionDerivative_CheckedChanged);
            // 
            // chbSimplify
            // 
            this.chbSimplify.AutoSize = true;
            this.chbSimplify.Location = new System.Drawing.Point(668, 41);
            this.chbSimplify.Name = "chbSimplify";
            this.chbSimplify.Size = new System.Drawing.Size(61, 17);
            this.chbSimplify.TabIndex = 4;
            this.chbSimplify.Text = "Simplify";
            this.chbSimplify.UseVisualStyleBackColor = true;
            this.chbSimplify.CheckedChanged += new System.EventHandler(this.chbSimplify_CheckedChanged);
            // 
            // rbtnMaclaurinSeries
            // 
            this.rbtnMaclaurinSeries.Location = new System.Drawing.Point(199, 41);
            this.rbtnMaclaurinSeries.Name = "rbtnMaclaurinSeries";
            this.rbtnMaclaurinSeries.Size = new System.Drawing.Size(155, 17);
            this.rbtnMaclaurinSeries.TabIndex = 6;
            this.rbtnMaclaurinSeries.Text = "Function Maclaurin Series";
            this.rbtnMaclaurinSeries.UseVisualStyleBackColor = true;
            this.rbtnMaclaurinSeries.CheckedChanged += new System.EventHandler(this.rbtnMaclaurinSeries_CheckedChanged);
            // 
            // rbtnPolynomial
            // 
            this.rbtnPolynomial.Location = new System.Drawing.Point(348, 41);
            this.rbtnPolynomial.Name = "rbtnPolynomial";
            this.rbtnPolynomial.Size = new System.Drawing.Size(85, 17);
            this.rbtnPolynomial.TabIndex = 7;
            this.rbtnPolynomial.Text = "Polynomial";
            this.rbtnPolynomial.UseVisualStyleBackColor = true;
            this.rbtnPolynomial.CheckedChanged += new System.EventHandler(this.rbtnPolynomial_CheckedChanged);
            // 
            // lblPrefixExpression
            // 
            this.lblPrefixExpression.AutoSize = true;
            this.lblPrefixExpression.Location = new System.Drawing.Point(471, 16);
            this.lblPrefixExpression.MaximumSize = new System.Drawing.Size(200, 100);
            this.lblPrefixExpression.Name = "lblPrefixExpression";
            this.lblPrefixExpression.Size = new System.Drawing.Size(96, 13);
            this.lblPrefixExpression.TabIndex = 8;
            this.lblPrefixExpression.Text = "<ExpressionPrefix>";
            // 
            // lblInfix
            // 
            this.lblInfix.AutoSize = true;
            this.lblInfix.Location = new System.Drawing.Point(81, 16);
            this.lblInfix.Name = "lblInfix";
            this.lblInfix.Size = new System.Drawing.Size(29, 13);
            this.lblInfix.TabIndex = 9;
            this.lblInfix.Text = "Infix:";
            // 
            // lblPrefix
            // 
            this.lblPrefix.AutoSize = true;
            this.lblPrefix.Location = new System.Drawing.Point(429, 16);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(36, 13);
            this.lblPrefix.TabIndex = 10;
            this.lblPrefix.Text = "Prefix:";
            // 
            // ShowDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 334);
            this.Controls.Add(this.lblPrefix);
            this.Controls.Add(this.lblInfix);
            this.Controls.Add(this.lblPrefixExpression);
            this.Controls.Add(this.rbtnPolynomial);
            this.Controls.Add(this.rbtnMaclaurinSeries);
            this.Controls.Add(this.chbSimplify);
            this.Controls.Add(this.rbtnFunctionDerivative);
            this.Controls.Add(this.rbtnFunction);
            this.Controls.Add(this.lblInfixExpression);
            this.Controls.Add(this.pictureBoxBinaryTree);
            this.Controls.Add(this.lblBinaryTree);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShowDetails";
            this.Text = "Details";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBinaryTree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBinaryTree;
        private System.Windows.Forms.PictureBox pictureBoxBinaryTree;
        private System.Windows.Forms.Label lblInfixExpression;
        private System.Windows.Forms.RadioButton rbtnFunction;
        private System.Windows.Forms.RadioButton rbtnFunctionDerivative;
        private System.Windows.Forms.CheckBox chbSimplify;
        private System.Windows.Forms.RadioButton rbtnMaclaurinSeries;
        private System.Windows.Forms.RadioButton rbtnPolynomial;
        private System.Windows.Forms.Label lblPrefixExpression;
        private System.Windows.Forms.Label lblInfix;
        private System.Windows.Forms.Label lblPrefix;
    }
}