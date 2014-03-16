using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace GameofLife
{
    [Serializable]
    public class SaveData
    {
        public Zelle[,] Zellen { get; set; }
        public int Rows { get; set; }
        public int Colums { get; set; }
        public int Intervall { get; set; }
        public int Ticks { get; set; }
        public bool Torus { get; set; }

    }
}
