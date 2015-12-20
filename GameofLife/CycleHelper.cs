using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GameofLife
{
    public static class CycleHelper
    {
        public static bool FindCycle(this bool[,] data, int deep = -1)
        {

        }


        private static byte[] CalculateHash(this bool[,] data)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                return md5.ComputeHash(data.toPlainArray().toByteArray());
        }
        private static byte[] toByteArray(bool[,] data)
        { 
            int columCount = data.GetUpperBound(0) + 1;
            int rowCount = data.GetUpperBound(1) + 1;
            byte[] result = new byte[(int)Math.Ceiling(columCount * rowCount / 8.0f)];
            for (int y = 0; y < rowCount; y++)
                for (int x = 0; x < columCount; x++)
                {
                    int linPos = y * columCount + x;
                    int bytePos = linPos / 8;
                    int inPos = linPos % 8;
                }
            return result;
        }
    }
}
