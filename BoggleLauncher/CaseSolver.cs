using System;
using System.Linq;
using Boggle;

namespace BoggleLauncher
{
    public class CaseSolver
    {

        public void SolveAll()
        {
            SolveSet1();
            SolveSet2();
            SolveSet3();
            SolveSet4();
            SolveSet5();
            SolveSet6();
            SolveSet7();
            SolveSet8();

            for (int i = 0; i < 10; i++)
            {
                SolveSet9();
            }

            for (int i = 0; i < 3; i++)
            {
                SolveSet10();
            }
        }

        internal void Solve(string setName, string path, char[,] board, bool printWords = true)
        {
            ISolver solver = MyBoggleSolution.CreateSolver(path);
            var result = solver.FindWords(board);

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

        internal void SolveSet9()
        {
            var random = new Random();
            int width = random.Next(2, 10);
            int height = random.Next(2, 10);
            var path = "Assets/Dictionaries/Dictionary_Big2.txt";
            var board = BoardUtility.GenerateRandomBoard(width, height);
            Solve(String.Format("Small random board ({0}x{1})", width, height), path, board);
        }

        internal void SolveSet10()
        {
            var random = new Random();
            int width = random.Next(150, 300);
            int height = random.Next(150, 300);
            var path = "Assets/Dictionaries/Dictionary_Big2.txt";
            var board = BoardUtility.GenerateRandomBoard(width, height);
            Solve(String.Format("Big random board ({0}x{1})", width, height), path, board, false);
        }

        internal void SolveSetUnity1()
        {
            var random = new Random();
            int width = random.Next(150, 300);
            int height = random.Next(150, 300);
            var path = "Assets/Dictionaries/Dictionary_Big2.txt";
            var board = BoardUtility.GenerateRandomBoard(width, height);
            Solve(String.Format("Big random board ({0}x{1})", width, height), path, board, false);
        }
    }
}
