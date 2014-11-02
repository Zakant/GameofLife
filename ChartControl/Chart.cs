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
        private AdvancedList<ChartPathF> _chartpaths = new AdvancedList<ChartPathF>();

        private int leftmargin = 20;
        private int rightmargin = 20;
        private int topmargin = 20;
        private int botmargin = 20;

        private Font f = new Font("Segoe UI", 8, FontStyle.Regular, GraphicsUnit.Point);


        [Browsable(true)]
        public ChartMode Mode { get; set; }

        [Browsable(true)]
        public bool AutoAdjusting { get; set; }

        [Browsable(true)]
        public int XValues { get; set; }

        [Browsable(true)]
        public float ValueMargin { get; set; }

        public Chart()
        {
            Mode = ChartMode.Scrolling;
            ValueMargin = 2;
            AutoAdjusting = true;
            CalculateMargins();
            UpdateXValues();
            _chartpaths.PropertyChanged += HandlePropertyChanged;
            this.DoubleBuffered = true;
        }



        #region ChartMethoden

        public void addPath(ChartPathF path)
        {
            _chartpaths.Add(path);
        }

        public void removePath(ChartPathF path)
        {
            _chartpaths.Remove(path);
        }

        public IEnumerator<ChartPathF> getEnumerator()
        {
            return _chartpaths.GetEnumerator();
        }

        #endregion

        #region EventHandler
        void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CalculateYBoarder();
            CalculateMargins();
            UpdateData();
            this.Refresh();
        }


        protected override void OnSizeChanged(EventArgs e)
        {
            UpdateXValues();
            CalculateYBoarder();
            base.OnSizeChanged(e);
        }

        int yboarder = 0;
        protected void CalculateYBoarder()
        {
            switch (Mode)
            {
                case ChartMode.Scrolling:
                    List<ChartPointF> _temp = new List<ChartPointF>();
                    foreach (var c in _chartpaths)
                    {
                        foreach (var i in c.OrderByDescending((x => x.X)).Take(XValues))
                        {
                            _temp.Add(i);
                        }
                    }
                    if (_temp.Count > 0)
                        yboarder = (int)_temp.Max((x => x.Y)) + 5;
                    break;
                case ChartMode.Static:
                    List<ChartPointF> _temp2 = new List<ChartPointF>();
                    foreach (var c in _chartpaths)
                        foreach (var i in c)
                            _temp2.Add(i);
                    if (_temp2.Count > 0)
                        yboarder = (int)_temp2.Max((x => x.Y)) + 5;
                    break;
            }
        }


        public void UpdateXValues()
        {
            if (AutoAdjusting)
            {
                ValueMargin = 2;
                XValues = (int)((this.Size.Width - leftmargin - rightmargin) / ValueMargin);
            }
            else
            {
                ValueMargin = ((float)((this.Size.Width - leftmargin - rightmargin)) / (XValues - 1));
            }

        }

        protected void CalculateMargins()
        {
            using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(new Bitmap(1, 1)))
            {
                SizeF size = graphics.MeasureString(yboarder.ToString(), f);
                leftmargin = (int)(3 + size.Width + 3);
            }
            UpdateXValues();
        }

        private DataEntry[] _data = new DataEntry[0];
        protected void UpdateData()
        {
            List<DataEntry> _datatemp = new List<DataEntry>();
            foreach (var path in _chartpaths)
            {
                ChartPointF[] data = path.OrderByDescending(x => x.X).Take(XValues).ToArray();
                if (data.Length > 0)
                {
                    switch (Mode)
                    {
                        case ChartMode.Scrolling:
                            PointF[] projektion = data.Select((p, i) =>
                                {
                                    return new PointF((this.Width - rightmargin) - ValueMargin * i, (1.0f - p.Y / yboarder) * (this.Height - topmargin - botmargin) + topmargin);
                                }).ToArray();
                            _datatemp.Add(new DataEntry() { points = projektion, color = path.Color });
                            break;
                        case ChartMode.Static:
                            break;
                    }
                }
            }
            _data = _datatemp.ToArray();
        }

        private Brush bwhite = new SolidBrush(Color.White);
        private Brush bblack = new SolidBrush(Color.Black);

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;


            g.DrawString(yboarder.ToString(), f, bblack, new PointF(3, topmargin - g.MeasureString(yboarder.ToString(), f).Height / 2));
            string middel = ((int)(yboarder / 2)).ToString();
            g.DrawString(middel, f, bblack, new PointF(3, (this.Height - topmargin - botmargin) / 2 - g.MeasureString(middel, f).Height / 2));
            g.DrawString("0", f, bblack, new PointF(3, this.Height - botmargin - g.MeasureString("0", f).Height / 2));



            foreach (var d in _data)
            {
                if (d.points.Length > 2)
                    g.DrawCurve(new Pen(d.color), d.points);
            }
        }

        private Pen pblack = new Pen(Color.Black, 2);
        protected bool repaintbackground = true;
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //if (repaintbackground)
            //{
            Graphics g = e.Graphics;
            g.FillRectangle(bwhite, e.ClipRectangle); // Hintergrund weiß machen

            //X-Achse
            g.DrawLine(pblack, new Point(leftmargin, topmargin), new Point(leftmargin, e.ClipRectangle.Height - botmargin));
            //Y-Achse
            g.DrawLine(pblack, new Point(leftmargin, e.ClipRectangle.Height - botmargin), new Point(e.ClipRectangle.Width - rightmargin, e.ClipRectangle.Height - botmargin));
            repaintbackground = false;
            //}
        }


        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }

        protected struct DataEntry
        {
            public PointF[] points;
            public Color color;
        }
    }
}
