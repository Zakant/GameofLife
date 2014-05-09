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
