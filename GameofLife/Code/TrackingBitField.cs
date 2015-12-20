using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameofLife.Code
{
    public class TrackingBitField : BitField
    {

        public new bool this[int x, int y]
        {
            get
            {
                int bytePos, bitPos;
                Translate(x, y, out bytePos, out bitPos);
                return Get(bytePos, bitPos);
            }
            set
            {
                int bytePos, bitPos;
                Translate(x, y, out bytePos, out bitPos);
                if (Set(bytePos, bitPos, value))
                    LogChange(x, y);
            }
        }

        public TrackingBitField(int width, int height) : base(width, height)
        {
        }

        protected TrackingBitField(BitField origin) : base(origin)
        {
            if (origin is TrackingBitField)
            {
                var track = (TrackingBitField)origin;
                Point[] _buffer = new Point[track._changes.Count];
                track._changes.CopyTo(_buffer);
                _changes = new List<Point>(_buffer);
            }
        }

        private List<Point> _changes = new List<Point>();
        private object _logLock = new object();
        protected void LogChange(int x, int y)
        {
            lock (_logLock)
            {
                var point = new Point(x, y);
                if (!_changes.Contains(point))
                    _changes.Add(point);
            }
        }

        public IEnumerable<BitFieldEntry> getChangedEntries()
        {
            lock (_logLock)
            {
                var result = _changes.ToList();
                _changes.Clear();
                return result.Select(x => new BitFieldEntry(x.X, x.Y, this[x]));
            }
        }
    }
}
