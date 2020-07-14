using System.IO;
using Boggle.Models;

namespace Boggle.Utilities
{
    public class TrieDictionaryReader
    {
        static public Trie ReadAndGenerate(string dictionaryPath)
        {
            var result = new Trie();

            FileStream fileStream = new FileStream(dictionaryPath, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                while (!reader.EndOfStream) {
                    string line = reader.ReadLine();
                    result.Insert(line.ToLower());
                }
            }

            return result;
        }
    }
}
