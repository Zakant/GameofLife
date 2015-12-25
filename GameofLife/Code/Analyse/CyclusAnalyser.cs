using GameofLife.Code.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameofLife.Code.Analyse
{
    public static class CyclusAnalyser
    {

        public static AnalyseResult AnalyseCyclus(BitField field, ISimulationUnit simulator, out int cycleOffset, out int cycleLength, int maxGenerations = Int32.MaxValue)
        {
            cycleLength = 1;
            cycleOffset = 0;
            Dictionary<byte[], int> _generations = new Dictionary<byte[], int>();

            int currentGenerationIndex = -1;
            BitField currentGeneration = field.Clone();
            byte[] currentHash;
            do
            {
                if (currentGeneration.isNullField)
                {
                    cycleOffset = currentGenerationIndex;
                    return AnalyseResult.NullCyleFound;
                }
                currentHash = currentGeneration.Identity;
                if (_generations.ContainsKey(currentHash)) // Cycle found!
                {
                    int firstApperence = _generations[currentHash];
                    cycleOffset = firstApperence;
                    cycleLength = currentGenerationIndex - firstApperence;
                    return AnalyseResult.CylceFound;
                }
                _generations.Add(currentGeneration.Identity, currentGenerationIndex);
                currentGenerationIndex++;
                simulator.SimulateInPlace(currentGeneration);
            } while (currentGenerationIndex <= maxGenerations);
            return AnalyseResult.NoCyleFound;
        }

    }
}
