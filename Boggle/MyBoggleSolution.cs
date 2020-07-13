using System;
namespace Boggle
{
    public class MyBoggleSolution
    {
        public static ISolver CreateSolver(string dictionaryPath)
        {
            return new Solver.TrieDepthSolver(dictionaryPath);
        }
    }
}
