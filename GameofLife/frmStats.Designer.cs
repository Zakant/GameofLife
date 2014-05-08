namespace GameofLife
{
    partial class frmStats
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
            this.pnlChart = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nupXScale = new System.Windows.Forms.NumericUpDown();
            this.cbAutoScale = new System.Windows.Forms.CheckBox();
            this.btnResetStats = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupXScale)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlChart
            // 
            this.pnlChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChart.Location = new System.Drawing.Point(12, 12);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(462, 297);
            this.pnlChart.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnResetStats);
            this.groupBox1.Controls.Add(this.cbAutoScale);
            this.groupBox1.Controls.Add(this.nupXScale);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 315);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 87);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Einstellungen";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X Scale:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nupXScale
            // 
            this.nupXScale.Location = new System.Drawing.Point(59, 19);
            this.nupXScale.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nupXScale.Name = "nupXScale";
            this.nupXScale.Size = new System.Drawing.Size(120, 20);
            this.nupXScale.TabIndex = 1;
            // 
            // cbAutoScale
            // 
            this.cbAutoScale.AutoSize = true;
            this.cbAutoScale.Location = new System.Drawing.Point(9, 45);
            this.cbAutoScale.Name = "cbAutoScale";
            this.cbAutoScale.Size = new System.Drawing.Size(88, 17);
            this.cbAutoScale.TabIndex = 2;
            this.cbAutoScale.Text = "Auto X Scale";
            this.cbAutoScale.UseVisualStyleBackColor = true;
            this.cbAutoScale.CheckedChanged += new System.EventHandler(this.cbAutoScale_CheckedChanged);
            // 
            // btnResetStats
            // 
            this.btnResetStats.Location = new System.Drawing.Point(354, 19);
            this.btnResetStats.Name = "btnResetStats";
            this.btnResetStats.Size = new System.Drawing.Size(102, 23);
            this.btnResetStats.TabIndex = 3;
            this.btnResetStats.Text = "Reset Statistics";
            this.btnResetStats.UseVisualStyleBackColor = true;
            this.btnResetStats.Click += new System.EventHandler(this.btnResetStats_Click);
            // 
            // frmStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 410);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlChart);
            this.Name = "frmStats";
            this.Text = "Statistics";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupXScale)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlChart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnResetStats;
        private System.Windows.Forms.CheckBox cbAutoScale;
        private System.Windows.Forms.NumericUpDown nupXScale;
        private System.Windows.Forms.Label label1;
    }
}