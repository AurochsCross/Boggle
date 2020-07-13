using System;
using System.Collections.Generic;
using Boggle.Dictionary;

namespace Boggle.Solver
{
    public class TrieDepthSolver: ISolver
    {
        private (int, int)[] _neighbours = { (-1, -1), (0, -1), (1, -1), (-1, 0), (1, 0), (-1, 1), (0, 1), (1, 1) };
        private Trie _trie;
        private HashSet<string> foundWords = new HashSet<string>();

        public TrieDepthSolver(string dictionaryPath)
        {
            var dictionaryReader = new TrieDictionaryReader(dictionaryPath);
            _trie = dictionaryReader.ReadAndGenerate();
        }

        public IResults FindWords(char[,] board)
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    Find(_trie.root, "", board, new HashSet<(int, int)>(), x, y);
                }
            }

            return new Model.BoggleResults(foundWords);
        }

        private void Find(Node lastNode, string assembledWord, char[,] board, HashSet<(int, int)> visited, int x, int y)
        {
            var currentChar = board[y, x];

            var currentNode = lastNode.FindChildNode(currentChar);

            if (currentNode != null)
            {
                assembledWord += currentChar;

                if (assembledWord == "datiz")
                {
                    var temp = 0;
                }

                if (currentNode.IsStandalone)
                    foundWords.Add(assembledWord);

                visited.Add((x, y));

                foreach (var neighbour in Utility.Mover.AvailableNeighbours(visited, x, y, board.GetLength(0), board.GetLength(1)))
                {
                    Find(currentNode, assembledWord, board, visited, x + neighbour.Item1, y + neighbour.Item2);
                }

                visited.Remove((x, y));
            }
        }
    }
}
