
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameofLife
{
    [Serializable()]
    public class Zelle
    {
        public Zelle()
        {
            Status = ZellenStatus.Tot;
            Aenderung = ZellenStatus.Tot;
            hasChanged = true;
        }

        public ZellenStatus Status { get; set; }
        public ZellenStatus Aenderung { get; set; }

        public bool hasChanged { get; set; }

    }
    [Serializable()]
    public enum ZellenStatus : byte
    {
        Lebt, Tot
    }       
}
