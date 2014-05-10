using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ChartControl
{
    [Serializable()]
    public class ChartPointF : BasePoint<float>
    {

        public static explicit operator ChartPoint(ChartPointF pf)
        {
            return new ChartPoint((int)pf.X, (int)pf.Y);
        }

        public static implicit operator PointF(ChartPointF pf)
        {
            return new PointF(pf.X, pf.Y);
        }

        public ChartPointF(PointF p)
        {
            X = p.X;
            Y = p.Y;
        }
        public ChartPointF(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
