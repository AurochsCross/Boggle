using System.Linq;
using System.Collections.Generic;

namespace Boggle.Utilities
{
    public class Mover
    {
        private static readonly (int, int)[] _neighbours = { (-1, -1), (0, -1), (1, -1), (-1, 0), (1, 0), (-1, 1), (0, 1), (1, 1) };

        public static HashSet<(int, int)> AvailableNeighbours(HashSet<(int, int)> visited, int x, int y, int boardWidth, int boardHeight)
        {
            return _neighbours.Aggregate(new HashSet<(int, int)>(), (set, neighbour) =>
            {
                var dx = x + neighbour.Item1;
                var dy = y + neighbour.Item2;

                if (!visited.Contains((dx, dy)) && dx >= 0 && dy >= 0 && dx < boardWidth && dy < boardHeight)
                {
                    set.Add(neighbour);
                }

                return set;
            });
        }
    }
}
