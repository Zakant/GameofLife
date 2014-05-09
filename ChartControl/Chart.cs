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
    public class Chart : Panel, IBindingList
    {
        private BindingList<ChartPath> _chartpath = new BindingList<ChartPath>();
        private BindingList<ChartPathF> _chartpathf = new BindingList<ChartPathF>();

        private ChartMode mode;

        public Chart(ChartMode mode)
        {
            this.mode = mode;
            _chartpath.ListChanged += HandleListChanged;
            _chartpathf.ListChanged += HandleListChanged;
            this.DoubleBuffered = true;
        }

        #region ChartMethoden

        public void addPath(ChartPath path)
        {
            _chartpath.Add(path);
        }
        public void addPath(ChartPathF path)
        {
            _chartpathf.Add(path);
        }
        public void removePath(ChartPath path)
        {
            _chartpath.Remove(path);
        }
        public void removePath(ChartPathF path)
        {
            _chartpathf.Remove(path);
        }
        public IEnumerator<ChartPath> getEnumerator()
        {
            return _chartpath.GetEnumerator();
        }
        public IEnumerator<ChartPathF> getFEnumerator()
        {
            return _chartpathf.GetEnumerator();
        }

        #endregion

        #region EventHandler
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

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
