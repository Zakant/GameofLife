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

        private List<StatisticEntry> _stats;
        private frmMain _host;

        public frmStats(frmMain Host, ref List<StatisticEntry> stats)
        {
            _host = Host;
            InitializeComponent();
            _host.StatisticValuesChanged += _host_NewStatisticValues;
            _stats = stats;
        }

        void _host_NewStatisticValues()
        {
            
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
