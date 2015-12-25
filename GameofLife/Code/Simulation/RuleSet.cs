using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameofLife.Code.Simulation
{
    public class RuleSet
    {
        public string Name { get; protected set; }
        public string Author { get; protected set; }
        public string Description { get; protected set; }

        protected Dictionary<int, bool> _alive = new Dictionary<int, bool>();
        public bool isAlive(int livingNeighbours)
        {
            return _alive[livingNeighbours];
        }

        public static RuleSet LoadFile(string path)
        {
            throw new NotImplementedException();
        }

        public void SaveFile(string path)
        {
            throw new NotImplementedException();
        }
    }
}
