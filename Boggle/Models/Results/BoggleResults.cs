using System.Collections;
using System.Collections.Generic;

namespace Boggle.Models.Results
{
    public class BoggleResults: IResults
    {
        public IEnumerable<string> Words { get; private set; }
        private readonly Hashtable _scores = new Hashtable { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 1 }, { 4, 1 }, { 5, 2 }, { 6, 3 }, { 7, 5 }};

        public int Score
        {
            get
            {
                var result = 0;

                foreach (var word in Words)
                {
                    var score = _scores[word.Length];
                    if (score != null)
                        result += (int)score;
                    else
                        result += 11;
                }

                return result;
            }
        }

        public BoggleResults(IEnumerable<string> words)
        {
            Words = words;
        }
    }
}
