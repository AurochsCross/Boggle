using System;
namespace BoggleLauncher
{
    public class BoardUtility
    {
        public static char[,] GenerateRandomBoard(int width, int height)
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

        public static void PrintBoard(char[,] board)
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
    }
}
