using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameofLife.Code
{
    public class BitField
    {

        public int Width { get; private set; }
        public int Height { get; private set; }

        private byte[] _data;
        private object _lock = new object();

        public bool this[int x, int y]
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
                Set(bytePos, bitPos, value);

            }
        }

        public bool this[Point p]
        {
            get { return this[p.X, p.Y]; }
            set { this[p.X, p.Y] = value; }
        }

        private byte[] _id = null;
        private bool _isDirty = true;
        public byte[] Identity
        {
            get { return _id = _isDirty ? CalculateIdentity() : _id; }
        }

        public BitField(int width, int height)
        {
            Width = width;
            Height = height;
            _data = new byte[(int)Math.Ceiling(Width * Height / 8.0f)];
        }

        protected BitField(BitField origin) : this(origin.Width, origin.Height)
        {
            lock (_lock)
            {
                lock (origin._lock)
                {
                    for (int i = 0; i < _data.Length; i++)
                        _data[i] = origin._data[i];
                    _id = origin._id;
                    _isDirty = origin._isDirty;
                }
            }
        }


        public IEnumerable<BitFieldEntry> getAllEntries()
        {
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    yield return new BitFieldEntry(x, y, this[x, y]);
        }

        protected bool Set(int bytePos, int bitPos, bool value)
        {
            lock (_lock)
            {
                bool current = Get(bytePos, bitPos);
                if (current == value) return false;
                byte mask = (byte)(0x01 << bitPos);
                if (value) // value == true, current == false
                    _data[bytePos] = (byte)(_data[bytePos] + mask);
                else // value == false, current == true
                    _data[bytePos] = (byte)(_data[bytePos] - mask);
                _isDirty = true;
                return true;
            }
        }

        protected bool Get(int bytePos, int bitPos)
        {
            lock (_lock)
            {
                return (_data[bytePos] & (0x01 << bitPos)) > 0;
            }
        }

        protected void Translate(int xin, int yin, out int bytePos, out int bitPos)
        {
            int linearPos = yin * Width + xin;
            bytePos = linearPos / 8;
            bitPos = linearPos % 8;
        }

        protected byte[] CalculateIdentity()
        {
            lock (_lock)
            {
                using (System.Security.Cryptography.SHA1Managed sha1 = new System.Security.Cryptography.SHA1Managed())
                {
                    _isDirty = false;
                    return sha1.ComputeHash(_data);
                }
            }
        }

        public override bool Equals(object obj)
        {
            return (obj as BitField)?.Identity == this.Identity;
        }

        public static bool operator ==(BitField field1, BitField field2)
        {
            if (ReferenceEquals(field1, field2)) return true;
            if (ReferenceEquals(field1, null) || ReferenceEquals(field2, null)) return false;
            return field1.Identity == field2.Identity;
        }

        public static bool operator !=(BitField field1, BitField field2)
        {
            return !(field1 == field2);
        }

        public override int GetHashCode()
        {
            return BitConverter.ToInt32(Identity.Take(4).ToArray(), 0);
        }

        public BitField Clone()
        {
            return new BitField(this);
        }
    }
}
