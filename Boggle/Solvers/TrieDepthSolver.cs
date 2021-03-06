﻿using System;
using System.Collections.Generic;
using Boggle.Models;
using Boggle.Models.Results;
using Boggle.Utilities;

namespace Boggle.Solvers
{
    public class TrieDepthSolver: ISolver
    {
        private Trie _trie;
        private HashSet<string> _foundWords;

        public TrieDepthSolver(string dictionaryPath)
        {
            _trie = TrieDictionaryReader.ReadAndGenerate(dictionaryPath);
        }

        public IResults FindWords(char[,] board)
        {
            _foundWords = new HashSet<string>();
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    Find(_trie.root, "", board, new HashSet<(int, int)>(), x, y);
                }
            }

            var result = new BoggleResults(_foundWords);
            _foundWords = null;

            return result;
        }

        private void Find(Node lastNode, string assembledWord, char[,] board, HashSet<(int, int)> visited, int x, int y)
        {
            var currentChar = board[x, y];
            var currentNode = lastNode.FindChildNode(currentChar);


            if (currentNode == null)
                return;

            assembledWord += currentChar;
            if (currentChar == 'q')
            {
                assembledWord += 'u';
                currentNode = currentNode.FindChildNode('u');

                if (currentNode == null)
                    return;
            }

            if (currentNode != null && currentNode.IsStandalone && currentNode.Depth > 2)
                _foundWords.Add(assembledWord);

            visited.Add((x, y));

            foreach (var neighbour in Mover.AvailableNeighbours(visited, x, y, board.GetLength(0), board.GetLength(1)))
            {
                Find(currentNode, assembledWord, board, visited, x + neighbour.Item1, y + neighbour.Item2);
            }

            visited.Remove((x, y));
        }
    }
}
