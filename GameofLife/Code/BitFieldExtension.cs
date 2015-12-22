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

            lock(field.getLock())
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
            lock(_lock)
            {
                if (!_locks.ContainsKey(field))
                    _locks.Add(field, new object());
                return _locks[field];
            }
        }

        private static void removeLock(this BitField field)
        {
            lock(_lock)
            {
                _locks.Remove(field);
            }
        }
    }
}
