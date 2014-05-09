using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ChartControl
{
    [Serializable()]
    public class ChartPath : BaseChartPath<ChartPoint>
    {
        public ChartPath(string name)
        {
            this.Name = name;
            this.Color = Color.Black;
        }
        public ChartPath(string name, Color color)
        {
            this.Name = name;
            this.Color = color;
        }
    }
}
