using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ChartControl
{
    class ChartPointF
    {
        public float XValue { get; set; }
        public float YValue { get; set; }

        public ChartPointF(PointF p)
        {
            XValue = p.X;
            YValue = p.Y;
        }
        public ChartPointF(float x, float y)
        {
            XValue = x;
            YValue = y;
        }
    }
}
