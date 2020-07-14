using Boggle.Solvers;

namespace Boggle
{
    public class MyBoggleSolution
    {
        public static ISolver CreateSolver(string dictionaryPath)
        {
            return new TrieDepthSolver(dictionaryPath);
        }
    }
}
