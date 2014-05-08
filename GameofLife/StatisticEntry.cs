using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameofLife
{
    class StatisticEntry
    {

        public int Generation { get; protected set; }
        public int LivingCells { get; protected set; }


        public StatisticEntry(int Generation, int LivingCells)
        {
            this.Generation = Generation;
            this.LivingCells = LivingCells;
        }
    }
}
