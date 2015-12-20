using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameofLife.Code.Simulation
{
    public interface IRuleSet
    {
        string Name { get; }
        string Author { get; }
        string Description { get; }


        Dictionary<int, bool> StatusChanges { get; }
    }
}
