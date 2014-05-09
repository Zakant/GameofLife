using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ChartControl
{
    class ChartPoint
    {
        public int XValue { get; set; }
        public int YValue { get; set; }

        public ChartPoint(Point p)
        {
            XValue = p.X;
            YValue = p.Y;
        }
        public ChartPoint(int x, int y)
        {
            XValue = x;
            YValue = y;
        }
    }
}
