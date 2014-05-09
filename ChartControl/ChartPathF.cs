using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ChartControl
{
    [Serializable()]
    public class ChartPathF : BaseChartPath<ChartPointF>
    {
        public ChartPathF(string name)
        {
            this.Name = name;
        }
        public ChartPathF(string name, Color color)
        {
            this.Name = name;
            this.Color = color;
        }
    }
}
