namespace GameofLife
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbLimit = new System.Windows.Forms.CheckBox();
            this.nupLimit = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.cbBlocks = new System.Windows.Forms.CheckBox();
            this.cbTorus = new System.Windows.Forms.CheckBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnResetTicks = new System.Windows.Forms.Button();
            this.lblTicks = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.nupIntervall = new System.Windows.Forms.NumericUpDown();
            this.btnClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nupColums = new System.Windows.Forms.NumericUpDown();
            this.nupRows = new System.Windows.Forms.NumericUpDown();
            this.canvas = new GameofLife.CustomPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblLivingCells = new System.Windows.Forms.Label();
            this.cbRuleSet = new System.Windows.Forms.ComboBox();
            this.btnShowStatistics = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupIntervall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupColums)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupRows)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.canvas);
            this.splitContainer1.Size = new System.Drawing.Size(597, 469);
            this.splitContainer1.SplitterDistance = 124;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.btnShowStatistics);
            this.groupBox1.Controls.Add(this.cbRuleSet);
            this.groupBox1.Controls.Add(this.lblLivingCells);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbLimit);
            this.groupBox1.Controls.Add(this.nupLimit);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbBlocks);
            this.groupBox1.Controls.Add(this.cbTorus);
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnResetTicks);
            this.groupBox1.Controls.Add(this.lblTicks);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.nupIntervall);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nupColums);
            this.groupBox1.Controls.Add(this.nupRows);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Einstellungen";
            // 
            // cbLimit
            // 
            this.cbLimit.AutoSize = true;
            this.cbLimit.Location = new System.Drawing.Point(205, 104);
            this.cbLimit.Name = "cbLimit";
            this.cbLimit.Size = new System.Drawing.Size(47, 17);
            this.cbLimit.TabIndex = 18;
            this.cbLimit.Text = "Limit";
            this.cbLimit.UseVisualStyleBackColor = true;
            this.cbLimit.CheckedChanged += new System.EventHandler(this.cbLimit_CheckedChanged);
            // 
            // nupLimit
            // 
            this.nupLimit.Enabled = false;
            this.nupLimit.Location = new System.Drawing.Point(53, 102);
            this.nupLimit.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nupLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupLimit.Name = "nupLimit";
            this.nupLimit.Size = new System.Drawing.Size(120, 20);
            this.nupLimit.TabIndex = 17;
            this.nupLimit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Limit";
            // 
            // cbBlocks
            // 
            this.cbBlocks.AutoSize = true;
            this.cbBlocks.Location = new System.Drawing.Point(313, 104);
            this.cbBlocks.Name = "cbBlocks";
            this.cbBlocks.Size = new System.Drawing.Size(58, 17);
            this.cbBlocks.TabIndex = 15;
            this.cbBlocks.Text = "Blocks";
            this.cbBlocks.UseVisualStyleBackColor = true;
            this.cbBlocks.CheckedChanged += new System.EventHandler(this.cbBlocks_CheckedChanged);
            // 
            // cbTorus
            // 
            this.cbTorus.AutoSize = true;
            this.cbTorus.Location = new System.Drawing.Point(258, 104);
            this.cbTorus.Name = "cbTorus";
            this.cbTorus.Size = new System.Drawing.Size(53, 17);
            this.cbTorus.TabIndex = 14;
            this.cbTorus.Text = "Torus";
            this.cbTorus.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(366, 78);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(60, 23);
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(300, 78);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnResetTicks
            // 
            this.btnResetTicks.Location = new System.Drawing.Point(300, 49);
            this.btnResetTicks.Name = "btnResetTicks";
            this.btnResetTicks.Size = new System.Drawing.Size(126, 23);
            this.btnResetTicks.TabIndex = 8;
            this.btnResetTicks.Text = "Reset Ticks";
            this.btnResetTicks.UseVisualStyleBackColor = true;
            this.btnResetTicks.Click += new System.EventHandler(this.btnResetTicks_Click);
            // 
            // lblTicks
            // 
            this.lblTicks.Location = new System.Drawing.Point(337, 19);
            this.lblTicks.Name = "lblTicks";
            this.lblTicks.Size = new System.Drawing.Size(89, 23);
            this.lblTicks.TabIndex = 11;
            this.lblTicks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(297, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ticks: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "ms";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Interval";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(205, 74);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(205, 48);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // nupIntervall
            // 
            this.nupIntervall.Location = new System.Drawing.Point(53, 73);
            this.nupIntervall.Maximum = new decimal(new int[] {
            600000,
            0,
            0,
            0});
            this.nupIntervall.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupIntervall.Name = "nupIntervall";
            this.nupIntervall.Size = new System.Drawing.Size(120, 20);
            this.nupIntervall.TabIndex = 3;
            this.nupIntervall.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(205, 19);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear Field";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Colums";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rows";
            // 
            // nupColums
            // 
            this.nupColums.Location = new System.Drawing.Point(53, 47);
            this.nupColums.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nupColums.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupColums.Name = "nupColums";
            this.nupColums.Size = new System.Drawing.Size(120, 20);
            this.nupColums.TabIndex = 1;
            this.nupColums.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nupColums.ValueChanged += new System.EventHandler(this.nupColums_ValueChanged);
            // 
            // nupRows
            // 
            this.nupRows.Location = new System.Drawing.Point(53, 21);
            this.nupRows.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nupRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupRows.Name = "nupRows";
            this.nupRows.Size = new System.Drawing.Size(120, 20);
            this.nupRows.TabIndex = 0;
            this.nupRows.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nupRows.ValueChanged += new System.EventHandler(this.nupRows_ValueChanged);
            // 
            // canvas
            // 
            this.canvas.Blocks = false;
            this.canvas.Colums = 1;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Name = "canvas";
            this.canvas.Rows = 1;
            this.canvas.Size = new System.Drawing.Size(597, 341);
            this.canvas.TabIndex = 0;
            this.canvas.Zellen = null;
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseClick);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseLeave += new System.EventHandler(this.canvas_MouseLeave);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(432, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Living Cells:";
            // 
            // lblLivingCells
            // 
            this.lblLivingCells.Location = new System.Drawing.Point(501, 21);
            this.lblLivingCells.Name = "lblLivingCells";
            this.lblLivingCells.Size = new System.Drawing.Size(84, 23);
            this.lblLivingCells.TabIndex = 21;
            this.lblLivingCells.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbRuleSet
            // 
            this.cbRuleSet.FormattingEnabled = true;
            this.cbRuleSet.Location = new System.Drawing.Point(435, 50);
            this.cbRuleSet.Name = "cbRuleSet";
            this.cbRuleSet.Size = new System.Drawing.Size(150, 21);
            this.cbRuleSet.TabIndex = 22;
            // 
            // btnShowStatistics
            // 
            this.btnShowStatistics.Location = new System.Drawing.Point(435, 78);
            this.btnShowStatistics.Name = "btnShowStatistics";
            this.btnShowStatistics.Size = new System.Drawing.Size(150, 23);
            this.btnShowStatistics.TabIndex = 23;
            this.btnShowStatistics.Text = "Show Statistics";
            this.btnShowStatistics.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 469);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Name = "frmMain";
            this.Text = "Game of Life";
            this.Click += new System.EventHandler(this.btnClear_Click);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupIntervall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupColums)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupRows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nupColums;
        private System.Windows.Forms.NumericUpDown nupRows;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NumericUpDown nupIntervall;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label2;
        private CustomPanel canvas;
        private System.Windows.Forms.Button btnResetTicks;
        private System.Windows.Forms.Label lblTicks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox cbTorus;
        private System.Windows.Forms.CheckBox cbBlocks;
        private System.Windows.Forms.CheckBox cbLimit;
        private System.Windows.Forms.NumericUpDown nupLimit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnShowStatistics;
        private System.Windows.Forms.ComboBox cbRuleSet;
        private System.Windows.Forms.Label lblLivingCells;
        private System.Windows.Forms.Label label7;
    }
}

