using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameofLife.Code.Simulation
{
    public class SimulationUnit : ISimulationUnit
    {
        public IRuleSet RuleSet { get; set; }

        public bool Torus { get; set; }

        public BitField computeTick(BitField field)
        {
            var newField = field.Clone();
            computeTickInPlace(newField);
            return newField;
        }

        public void computeTickInPlace(BitField field)
        {
            foreach (var entry in field.getAllEntries())
                field[entry.Point] = RuleSet.StatusChanges[getLivingNeighbours(entry.Point.X, entry.Point.Y, field)];
        }


        protected int getLivingNeighbours(int x, int y, BitField field)
        {
            var points = new List<Point>();
            for (int _x = -1; _x <= 1; _x++)
                for (int _y = -1; _y <= 1; _y++)
                    if (_x == 0 && _y == 0) continue;
                    else
                        points.Add(new Point(x + _x, y + _y));
            if (Torus)
                points = points.Select(e => new Point(e.X < 0 ? field.Width + e.X : e.X, e.Y < 0 ? field.Height + e.Y : e.Y)).ToList();
            else
                points = points.Where(e => e.X >= 0 && e.Y >= 0).ToList();
            return points.Sum(e => field[e] ? 1 : 0);
        }
    }
}
