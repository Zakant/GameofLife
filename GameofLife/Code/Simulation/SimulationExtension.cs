using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameofLife.Code.Simulation
{
    public static class SimulationExtension
    {

        public static BitField SimulateMultiple(this ISimulationUnit simulator, BitField field, int generations)
        {
            BitField result = field.Clone();
            simulator.SimulateMultipleInPlace(result, generations);
            return result;
        }

        public static void SimulateMultipleInPlace(this ISimulationUnit simulator, BitField field, int generations)
        {
            for (int i = 0; i < generations; i++)
                simulator.SimulateInPlace(field);
        }
    }
}
