using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameofLife.Code.Simulation
{
    public interface ISimulationUnit
    {

        RuleSet RuleSet { get; set; }
        bool Torus { get; set; }

        BitField Simulate(BitField field);

        void SimulateInPlace(BitField field);
    }
}
