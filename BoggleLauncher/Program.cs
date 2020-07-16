using System;
using System.Linq;
using Boggle;

namespace BoggleLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            var caseSolver = new CaseSolver();
            caseSolver.SolveAll();

            var sequenceSolver = new SequentialSolver("Assets/Dictionaries/Dictionary_Big2.txt");
            sequenceSolver.SolveAll();
        }

        
    }
}
