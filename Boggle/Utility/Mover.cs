using System;
using System.Collections.Generic;

namespace Boggle.Utility
{
    public class Mover
    {
        readonly static (int, int)[] Neighbours = { (-1, -1), (0, -1), (1, -1), (-1, 0), (1, 0), (-1, 1), (0, 1), (1, 1) };

        public static HashSet<(int, int)> AvailableNeighbours(HashSet<(int, int)> visited, int x, int y, int boardWidth, int boardHeight)
        {
            var availableNeighbours = new HashSet<(int, int)>();

            foreach (var neighbour in Neighbours)
            {
                var dx = x + neighbour.Item1;
                var dy = y + neighbour.Item2;

                if (!visited.Contains((dx, dy)) && dx >= 0 && dy >= 0 && dx < boardWidth && dy < boardHeight)
                {
                    availableNeighbours.Add(neighbour);
                }
            }

            return availableNeighbours;
        }
    }
}
