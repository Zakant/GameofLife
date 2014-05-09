using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameofLife
{
    public partial class frmStats : Form
    {

        private BindingList<StatisticEntry> _stats;
        private frmMain _host;

        public frmStats(frmMain Host, ref BindingList<StatisticEntry> stats)
        {
            _host = Host;
            InitializeComponent();
            this.DoubleBuffered = true;

            var path = new ChartControl.ChartPath("Test");
            path.Add(new ChartControl.ChartPoint(1, 10));
            chart.addPath(path);
            path.Add(new ChartControl.ChartPoint(2, 20));

            _stats = stats;
            _stats.ListChanged += this.HandleListChanged;
            UpdateLabels();
        }

        protected void UpdateLabels()
        {
            if (lblAverage.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                    {
                        lblAverage.Text = _average.ToString();
                        lblMaximum.Text = _max.ToString();
                        lblMinimum.Text = _min.ToString();
                    }));
            }
            else
            {
                lblAverage.Text = _average.ToString();
                lblMaximum.Text = _max.ToString();
                lblMinimum.Text = _min.ToString();
            }

        }

        private double _average = 0.0d;
        private int _max = 0;
        private int _min = 0;
        protected void HandleListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (_stats.Count > 0)
            {
                _average = Math.Round((float)_stats.Sum(x => x.LivingCells) / _stats.Count, 3);
                _max = _stats.Max(x => x.LivingCells);
                _min = _stats.Min(x => x.LivingCells);
            }
            else
            {
                _average = 0.0d;
                _max = 0;
                _min = 0;
            }
            UpdateLabels();

        }


        private void cbAutoScale_CheckedChanged(object sender, EventArgs e)
        {
            nupXScale.Enabled = cbAutoScale.Enabled;
        }

        private void btnResetStats_Click(object sender, EventArgs e)
        {
            _stats.Clear();
        }

    }
}
