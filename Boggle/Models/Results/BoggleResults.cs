using System;
using System.Collections.Generic;

namespace Boggle.Models.Results
{
    public class BoggleResults: IResults
    {
        public IEnumerable<string> Words { get; private set; }

        public int Score
        {
            get
            {
                return 0;
            }
        }

        public BoggleResults(IEnumerable<string> words)
        {
            Words = words;
        }
    }
}
