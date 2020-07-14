using System;
using System.Linq;
using Boggle;

namespace BoggleLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.SolveSet1();
            program.SolveSet2();
            program.SolveSet3();
            program.SolveSet4();
            program.SolveSet5();
            program.SolveSet6();
            program.SolveSet7();
            program.SolveSet8();
        }

        internal void Solve(string setName, string path, char[,] board)
        {
            ISolver solver = MyBoggleSolution.CreateSolver(path);
            var result = solver.FindWords(board);

            Console.WriteLine(String.Format("=== {0} ===\nScore: {1}", setName, result.Score));

            foreach (var word in result.Words.ToArray().OrderBy(x => x))
            {
                Console.WriteLine(word);
            }

            Console.WriteLine();
        }

        internal void SolveSet1()
        {
            var path = "Assets/Dictionaries/Dictionary_dood.txt";
            var board = Boggle.Utilities.BoardParser.ParseFromFile("Assets/Boards/Board_dood.txt");
            Solve("Dood", path, board);
        }

        internal void SolveSet2()
        {
            var path = "Assets/Dictionaries/Dictionary_Big2.txt";
            var board = Boggle.Utilities.BoardParser.ParseFromFile("Assets/Boards/Board_3x3.txt");
            Solve("Big dictionary", path, board);
        }

        internal void SolveSet3()
        {
            var path = "Assets/Dictionaries/Dictionary_LongShort.txt";
            var board = Boggle.Utilities.BoardParser.ParseFromFile("Assets/Boards/Board_LongShort1.txt");
            Solve("Long Short 1", path, board);
        }

        internal void SolveSet4()
        {
            var path = "Assets/Dictionaries/Dictionary_LongShort.txt";
            var board = Boggle.Utilities.BoardParser.ParseFromFile("Assets/Boards/Board_LongShort2.txt");
            Solve("Long Short 2", path, board);
        }

        internal void SolveSet5()
        {
            var path = "Assets/Dictionaries/Dictionary_UnityControl.txt";
            var board = Boggle.Utilities.BoardParser.ParseFromFile("Assets/Boards/Board_3x3.txt");
            Solve("Unity Control", path, board);
        }

        internal void SolveSet6()
        {
            var path = "Assets/Dictionaries/Dictionary_Big2.txt";
            var board = Boggle.Utilities.BoardParser.ParseFromFile("Assets/Boards/Board_4x3.txt");
            Solve("Big dictionary alternative board 1", path, board);
        }

        internal void SolveSet7()
        {
            var path = "Assets/Dictionaries/Dictionary_Big2.txt";
            var board = Boggle.Utilities.BoardParser.ParseFromFile("Assets/Boards/Board_4x5.txt");
            Solve("Big dictionary alternative board 2", path, board);
        }

        internal void SolveSet8()
        {
            var path = "Assets/Dictionaries/Dictionary_Qu.txt";
            var board = Boggle.Utilities.BoardParser.ParseFromFile("Assets/Boards/Board_Qu.txt");
            Solve("Qu", path, board);
        }
    }
}
