using System;
using System.Linq;
using Boggle;

class Program
{
    static void Main(string[] args)
    {
        var program = new Program();
        program.SolveSet1();
    }

    internal void Solve(string path, char[,] board)
    {
        ISolver solver = MyBoggleSolution.CreateSolver(path);
        var result = solver.FindWords(board);

        Console.WriteLine(String.Format("Score: {0}", result.Score));

        foreach (var word in result.Words.ToArray().OrderBy(x => x))
        {
            Console.WriteLine(word);
        }
    }

    internal void SolveSet1()
    {
        var path = "Assets/Dictionaries/Dictionary_doodo.txt";
        var board = Boggle.Utilities.BoardParser.ParseFromFile("Assets/Boards/Board_dood.txt");
        Solve(path, board);
    }

}
