using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Boggle.Models.Results
{
    public class BoggleResults : IResults
    {
        public IEnumerable<string> Words { get; private set; }
        private readonly int[] _scores = { 0, 0, 0 ,1, 1, 2, 3, 5 };

        public int Score
        {
            get
            {
                return Words.Aggregate(0, (accumulate, value) =>
                {
                    var length = value.Length;
                    if (length <= _scores.Length)
                    {
                        accumulate += _scores[length];
                    }
                    else
                    {
                        accumulate += 11;
                    }

                    return accumulate;
                });
            }
        }

        public BoggleResults(IEnumerable<string> words)
        {
            Words = words;
        }
    }
}
