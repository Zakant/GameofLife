using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameofLife.Code
{
    public class BitFieldEntry
    {
        public Point Point { get; protected set; }
        public bool Value { get; protected set; }

        public BitFieldEntry(int x, int y, bool value)
        {
            Point = new Point(x, y);
            Value = value;
        }
    }
}
