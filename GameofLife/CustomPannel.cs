using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GameofLife
{
    class CustomPanel : Panel
    {
        private int _colums = 3;
        public int Colums
        {
            get { return _colums; }
            set { _colums = value; backgrounddraw = true; }
        }

        private int _rows = 3;
        public int Rows
        {
            get { return _rows; }
            set { _rows = value; backgrounddraw = true; }
        }

        public Zelle[,] Zellen { get; set; }

        public bool Blocks { get; set; }

        private bool backgrounddraw = true;
        private bool changedall = false;
        private bool clearall = false;

        private decimal rowsize = 1;
        private decimal columsize = 1;
        private Brush bwhite = new SolidBrush(Color.White);
        private Brush bblue = new SolidBrush(Color.Blue);
        private Pen pblack = new Pen(Color.Black, 1f);
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (backgrounddraw)
            {
                Graphics g = e.Graphics;
                Rectangle rec = e.ClipRectangle;
                e.Graphics.FillRectangle(bwhite, e.ClipRectangle);

                Rows = Rows == 0 ? 3 : Rows;
                Colums = Colums == 0 ? 3 : Colums;
                columsize = (decimal)rec.Width / Colums;
                rowsize = (decimal)rec.Height  / Rows;
                for (int c = 0; c <= Colums; c++)
                {
                    g.DrawLine(pblack, (float)(c * columsize), 0, (float)(c * columsize), rec.Height);
                }
                for (int r = 0; r <= Rows; r++)
                {
                    g.DrawLine(pblack, 0, (float)(r * rowsize), rec.Width, (float)(r * rowsize));
                }
                backgrounddraw = false;
            }
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int x = 0; x <= Zellen.GetUpperBound(0); x++)
            {
                for (int y = 0; y <= Zellen.GetUpperBound(1); y++)
                {
                    if (Zellen[x, y].hasChanged || changedall)
                    {
                        float xmitte = (float)(x * columsize + columsize / 2);
                        float ymitte = (float)(y * rowsize + rowsize / 2);
                        float size = (float)(rowsize > columsize ? columsize : rowsize) - 2;
                        decimal sizew = columsize - 2;
                        decimal sizeh = rowsize - 2;
                        RectangleF r = new RectangleF(xmitte - size / 2, ymitte - size / 2, size, size);
                        RectangleF rf = new RectangleF(xmitte - (float)sizew / 2, ymitte - (float)sizeh / 2, (float)sizew, (float)sizeh);

                        Zellen[x, y].hasChanged = false;
                        if (Zellen[x, y].Status == ZellenStatus.Lebt)
                        {
                            if (clearall) g.FillRectangle(bwhite, rf);
                            if (Blocks) g.FillRectangle(bblue, rf);
                            else g.FillEllipse(bblue, r);
                        }
                        else
                        {
                            g.FillRectangle(bwhite, rf);
                            //g.FillEllipse(bwhite, r);
                        }
                    }
                }
            }
            changedall = false;
            clearall = false;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            backgrounddraw = true;
            changedall = true;
            this.Refresh();
            base.OnSizeChanged(e);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            backgrounddraw = true;
            base.OnVisibleChanged(e);
        }

        public PointF getIndex(int x, int y)
        {
            return new PointF((float)(x / columsize),(float)( y / rowsize));
        }

        public void DrawAll()
        {
            changedall = true;
        }

        public void DrawBackground()
        {
            backgrounddraw = true;
        }

        public void ClearAll()
        {
            clearall = true;
        }
    }
}
