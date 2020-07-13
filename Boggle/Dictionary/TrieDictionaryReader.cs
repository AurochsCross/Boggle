using System.IO;

namespace Boggle.Dictionary
{
    public class TrieDictionaryReader
    {
        private string _dictionaryPath;

        public TrieDictionaryReader(string dictionaryPath)
        {
            _dictionaryPath = dictionaryPath;
        }

        public Trie ReadAndGenerate()
        {
            var result = new Trie();

            FileStream fileStream = new FileStream(_dictionaryPath, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                while (!reader.EndOfStream) {
                    string line = reader.ReadLine();
                    result.Insert(line);
                }
            }

            return result;
        }
    }
}
