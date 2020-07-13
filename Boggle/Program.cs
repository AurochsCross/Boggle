using System;
using System.Linq;
using System.Collections.Generic;
using Boggle.Solver;

namespace Boggle
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.SolveSet1();
        }

        void Solve(string path, char[,] board)
        {
            ISolver solver = MyBoggleSolution.CreateSolver(path);
            var result = solver.FindWords(board);

            Console.WriteLine(String.Format("Score: {0}", result.Score));

            foreach (var word in result.Words.ToArray().OrderBy(x => x))
            {
                Console.WriteLine(word);
            }
        }

        void SolveSet1()
        {
            var path = "Assets/Dictionaries/Dictionary_Single.txt";
            var board = Utility.BoardParser.ParseFromFile("Assets/Boards/Board_3x3.txt");
            Solve(path, board);
        }

    }
}
