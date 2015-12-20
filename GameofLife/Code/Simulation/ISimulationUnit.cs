using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameofLife.Code.Simulation
{
    public interface ISimulationUnit
    {

        IRuleSet RuleSet { get; set; }
        bool Torus { get; set; }

        BitField computeTick(BitField field);

        void computeTickInPlace(BitField field);
    }
}
