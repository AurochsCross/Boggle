using System;
using System.Linq;
using Boggle;

namespace BoggleLauncher
{
    public class SequentialSolver
    {
        private ISolver _solver;

        public SequentialSolver(string dictionaryPath)
        {
            _solver = MyBoggleSolution.CreateSolver(dictionaryPath);
        }

        public void SolveAll()
        {
            SolveSet1();
            SolveSet2();
            SolveSet3();
        }

        internal void Solve(string setName, char[,] board, bool printWords = true)
        {
            var result = _solver.FindWords(board);

            Console.WriteLine(String.Format("=== {0} ===\nScore: {1}", setName, result.Score));

            if (result.Score == 0)
            {
                BoardUtility.PrintBoard(board);
            }

            if (printWords)
            {
                foreach (var word in result.Words.ToArray().OrderBy(x => x))
                {
                    Console.WriteLine(word);
                }

                Console.WriteLine(String.Format("=== {0} ===\nScore: {1}", setName, result.Score));
            }

            Console.WriteLine();
        }

        void SolveSet1()
        {
            var board = Boggle.Utilities.BoardParser.ParseFromFile("Assets/Boards/Board_Unity1.txt");
            Solve("Step 1", board);
        }

        void SolveSet2()
        {
            var board = Boggle.Utilities.BoardParser.ParseFromFile("Assets/Boards/Board_Unity2.txt");
            Solve("Step 2", board);
        }

        void SolveSet3()
        {
            var board = Boggle.Utilities.BoardParser.ParseFromFile("Assets/Boards/Board_Unity3.txt");
            Solve("Step 3", board);
        }
    }
}
