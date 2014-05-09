using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ChartControl
{
    class Chart : Panel
    {
        private BindingList<ChartPath> _chartpath = new BindingList<ChartPath>();
        private BindingList<ChartPathF> _chartpathf = new BindingList<ChartPathF>();

        public Chart()
        {
            _chartpath.ListChanged += HandleListChanged;
            _chartpathf.ListChanged += HandleListChanged;
            this.DoubleBuffered = true;
        }

        void HandleListChanged(object sender, ListChangedEventArgs e)
        {
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
