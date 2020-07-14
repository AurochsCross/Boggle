using System.IO;
using System.Linq;

namespace Boggle.Utilities
{
    public class BoardParser
    {
        public static char[,] ParseFromFile(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                int[] parameters = reader.ReadLine().Split(' ').Select(x =>  int.Parse(x)).ToArray();
                char[,] result = new char[parameters[0], parameters[1]];

                var currentLine = 0;

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    for (var index = 0; index < parameters[1]; index++)
                    {
                        result[currentLine, index] = line[index];
                    }

                    currentLine++;
                }

                return result;
            }
        }
    }
}
