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
