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
    public class Chart : Panel
    {
        private AdvancedList<ChartPath> _chartpath = new AdvancedList<ChartPath>();
        private AdvancedList<ChartPathF> _chartpathf = new AdvancedList<ChartPathF>();

        [Browsable(true)]
        public ChartMode Mode { get; set; }

        public Chart()
        {
            Mode = ChartMode.Scrolling;
            _chartpath.PropertyChanged += HandlePropertyChanged;
            _chartpathf.PropertyChanged += HandlePropertyChanged;
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
        void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
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
