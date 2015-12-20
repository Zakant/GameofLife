using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using GameofLife.Code;

namespace GameofLife
{
    class CanvasPanel : Panel
    {
        public TrackingBitField ZellenFeld { get; set; }

        public bool Blocks { get; set; }

        private bool _forceBackground = true;
        private bool _forceDraw = true;

        private decimal _rowSize = 1;
        private decimal _columSize = 1;
        private Brush _bWhite = new SolidBrush(Color.White);
        private Brush _bBlue = new SolidBrush(Color.Blue);
        private Pen _pBlack = new Pen(Color.Black, 1f);

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (_forceBackground)
            {
                Graphics g = e.Graphics;
                Rectangle rec = e.ClipRectangle;
                e.Graphics.FillRectangle(_bWhite, e.ClipRectangle);

                _columSize = (decimal)rec.Width / ZellenFeld?.Width ?? 3;
                _rowSize = (decimal)rec.Height / ZellenFeld?.Height ?? 3;
                for (int c = 0; c <= ZellenFeld.Width; c++)
                    g.DrawLine(_pBlack, (float)(c * _columSize), 0, (float)(c * _columSize), rec.Height);

                for (int r = 0; r <= ZellenFeld.Height; r++)
                    g.DrawLine(_pBlack, 0, (float)(r * _rowSize), rec.Width, (float)(r * _rowSize));

                _forceBackground = false;
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (ZellenFeld != null)
            {
                foreach (var entry in _forceDraw ? ZellenFeld.getAllEntries() : ZellenFeld.getChangedEntries())
                    DrawCell(entry, g);
                _forceDraw = false;
            }
        }

        protected void DrawCell(BitFieldEntry entry, Graphics g)
        {
            float xmitte = (float)(entry.Point.X * _columSize + _columSize / 2);
            float ymitte = (float)(entry.Point.Y * _rowSize + _rowSize / 2);
            float size = (float)(_rowSize > _columSize ? _columSize : _rowSize) - 2;
            decimal sizew = _columSize - 2;
            decimal sizeh = _rowSize - 2;
            RectangleF r = new RectangleF(xmitte - size / 2, ymitte - size / 2, size, size);
            RectangleF rf = new RectangleF(xmitte - (float)sizew / 2, ymitte - (float)sizeh / 2, (float)sizew, (float)sizeh);

            if (entry.Value)
                if (Blocks) g.FillRectangle(_bBlue, rf);
                else g.FillEllipse(_bBlue, r);
            else
                g.FillRectangle(_bWhite, rf);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            _forceBackground = true;
            _forceDraw = true;
            this.Refresh();
            base.OnSizeChanged(e);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            _forceBackground = true;
            base.OnVisibleChanged(e);
        }

        public PointF getIndex(int x, int y)
        {
            return new PointF((float)(x / _columSize), (float)(y / _rowSize));
        }

        public RectangleF getRectangle(int x, int y)
        {
            float xmitte = (float)(x * _columSize + _columSize / 2);
            float ymitte = (float)(y * _rowSize + _rowSize / 2);
            decimal sizew = _columSize;
            decimal sizeh = _rowSize;
            return new RectangleF(xmitte - (float)sizew / 2, ymitte - (float)sizeh / 2, (float)sizew, (float)sizeh);
        }

        public void DrawAll()
        {
            _forceDraw = true;
        }

        public void DrawBackground()
        {
            _forceBackground = true;
        }

        public void ClearAll()
        {
            _forceDraw = true;
        }
    }
}
