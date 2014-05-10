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

        private ChartControl.ChartPathF datapath;
        private ChartControl.ChartPathF maxpath;
        private ChartControl.ChartPathF minpath;
        private ChartControl.ChartPathF averagepath;

        public frmStats(frmMain Host, ref BindingList<StatisticEntry> stats)
        {
            _host = Host;
            InitializeComponent();
            this.DoubleBuffered = true;

            datapath = new ChartControl.ChartPathF("Test");
            maxpath = new ChartControl.ChartPathF("Max", Color.Red);
            minpath = new ChartControl.ChartPathF("Min", Color.Blue);
            averagepath = new ChartControl.ChartPathF("Average", Color.Green);
            chart.addPath(datapath);
            chart.addPath(maxpath);
            chart.addPath(minpath);
            chart.addPath(averagepath);

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

        private float _average = 0.0f;
        private int _max = 0;
        private int _min = 0;
        protected void HandleListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (_stats.Count > 0)
            {
                _average = (float)Math.Round((float)_stats.Sum(x => x.LivingCells) / _stats.Count, 3);
                _max = _stats.Max(x => x.LivingCells);
                _min = _stats.Min(x => x.LivingCells);
                datapath.Add(new ChartControl.ChartPointF(_stats[e.NewIndex].Generation, _stats[e.NewIndex].LivingCells));
                //maxpath.Add(new ChartControl.ChartPointF(_stats[e.NewIndex].Generation, _max));
                //minpath.Add(new ChartControl.ChartPointF(_stats[e.NewIndex].Generation, _min));
                averagepath.Add(new ChartControl.ChartPointF(_stats[e.NewIndex].Generation, _average));
            }
            else
            {
                _average = 0.0f;
                _max = 0;
                _min = 0;
                datapath.Clear();
            }
            UpdateLabels();

        }


        private void cbAutoScale_CheckedChanged(object sender, EventArgs e)
        {
            nupXScale.Enabled = !cbAutoScale.Checked;
            chart.AutoAdjusting = cbAutoScale.Checked;
            if (!cbAutoScale.Checked)
            {
                chart.XValues = (int)nupXScale.Value;
            }
            chart.UpdateXValues();
            chart.Refresh();
        }

        private void btnResetStats_Click(object sender, EventArgs e)
        {
            _stats.Clear();
            datapath.Clear();
            averagepath.Clear();
            minpath.Clear();
            maxpath.Clear();
            this.Refresh();
        }

        private void nupXScale_ValueChanged(object sender, EventArgs e)
        {
            chart.XValues = (int)nupXScale.Value;
            chart.UpdateXValues();
            chart.Refresh();
        }

    }
}
