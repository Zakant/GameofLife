using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.ComponentModel;

namespace ChartControl
{
    [Serializable()]
    public class ChartPoint : BasePoint<int>
    {
        public static implicit operator ChartPointF(ChartPoint p)
        {
            return new ChartPointF(p.X, p.Y);
        }

        public ChartPoint(Point p)
        {
            X = p.X;
            Y = p.Y;
        }
        public ChartPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
