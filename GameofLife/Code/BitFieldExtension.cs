using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameofLife.Code
{
    public static class BitFieldExtension
    {
        #region BufferedField
        private static Dictionary<BitField, List<BitFieldEntry>> _buffer = new Dictionary<BitField, List<BitFieldEntry>>();

        public static void WriteBuffer(this BitField field, int x, int y, bool value)
        {
            lock (field.getLock())
            {
                if (!_buffer.ContainsKey(field))
                    _buffer.Add(field, new List<BitFieldEntry>());
                _buffer[field].Add(new BitFieldEntry(x, y, value));
            }
        }

        public static void WriteBuffer(this BitField field, Point p, bool value)
        {
            field.WriteBuffer(p.X, p.Y, value);
        }

        public static void FlushBuffer(this BitField field)
        {

            lock (field.getLock())
            {
                foreach (var entry in _buffer[field])
                    field[entry.Point] = entry.Value;
                _buffer.Remove(field);
                field.removeLock();
            }
        }

        private static object _lock = new object();
        private static Dictionary<BitField, object> _locks = new Dictionary<BitField, object>();
        private static object getLock(this BitField field)
        {
            lock (_lock)
            {
                if (!_locks.ContainsKey(field))
                    _locks.Add(field, new object());
                return _locks[field];
            }
        }

        private static void removeLock(this BitField field)
        {
            lock (_lock)
            {
                _locks.Remove(field);
            }
        }
        #endregion

        #region SubFields
        public static BitField getSubField(this BitField field, Rectangle rec)
        {
            return field.getSubField(rec, (w, h) => new BitField(w, h));
        }

        public static BitField getSubField(this BitField field, Rectangle rec, Func<int, int, BitField> constructor)
        {
            var result = constructor(rec.Width, rec.Height);
            for (int y = rec.Y; y < rec.Y + rec.Height; y++)
                for (int x = rec.X; x < rec.X + rec.Width; x++)
                    result[x - rec.X, y - rec.Y] = field[x, y];
            return result;
        }

        #endregion
    }
}
