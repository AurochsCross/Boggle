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
            Console.Clear();

            program.SolveSet1();
            program.SolveSet2();
            program.SolveSet3();
            program.SolveSet4();
            program.SolveSet5();
            program.SolveSet6();
            program.SolveSet7();
            program.SolveSet8();

            for (int i = 0; i < 10; i++)
            { 
                program.SolveSet9();
            }

            for (int i = 0; i < 3; i++)
            {
                program.SolveSet10();
            }
        }

        internal char[,] GenerateRandomBoard(int width, int height)
        {
            char[,] result = new char[width, height];

            var letters = "abcdefghijklmnopqrstuvwxyz";

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    result[x, y] = letters[new Random().Next(letters.Length)];
                }
            }

            return result;
        }

        internal void PrintBoard(char[,] board)
        {
            for (int y = 0; y < board.GetLength(1); y++)
            {
                for (int x = 0; x < board.GetLength(0); x++)
                {
                    Console.Write(board[x, y]);
                }

                Console.WriteLine();
            }
        }

        internal void Solve(string setName, string path, char[,] board, bool printWords = true)
        {
            ISolver solver = MyBoggleSolution.CreateSolver(path);
            var result = solver.FindWords(board);

            Console.WriteLine(String.Format("=== {0} ===\nScore: {1}", setName, result.Score));

            if (result.Score == 0)
            {
                PrintBoard(board);
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
            var board = GenerateRandomBoard(width, height);
            Solve(String.Format("Small random board ({0}x{1})", width, height), path, board);
        }

        internal void SolveSet10()
        {
            var random = new Random();
            int width = random.Next(150, 300);
            int height = random.Next(150, 300);
            var path = "Assets/Dictionaries/Dictionary_Big2.txt";
            var board = GenerateRandomBoard(width, height);
            Solve(String.Format("Big random board ({0}x{1})", width, height), path, board, false);
        }

    }
}
