using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Boggle.Models.Results;
namespace Tests
{
    [TestClass]
    public class ResultTests
    {
        [TestMethod]
        public void ResultScoreZeroTest()
        {
            string[] words = { "ab", "a", "cd", "", "gx" };

            BoggleResults results = new BoggleResults(words);
            var score = results.Score;

            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void ResultScoreNormalTest()
        {
            string[] words = { "abc", "degf", "ghiew", "jklmno", "mnopqrs" };

            BoggleResults results = new BoggleResults(words);
            var score = results.Score;

            Assert.AreEqual(12, score);
        }

        [TestMethod]
        public void ResultScoreBigWordsTest()
        {
            string[] words = { "abcfwefowooo", "degfwegweiwecw", "ghiewweiiigwe", "jklmnocweiijijiwe", "mnopqrswegjiwjicwe" };

            BoggleResults results = new BoggleResults(words);
            var score = results.Score;

            Assert.AreEqual(55, score);
        }

        [TestMethod]
        public void ResultScoreNoWordsTest()
        {
            string[] words = { };

            BoggleResults results = new BoggleResults(words);
            var score = results.Score;

            Assert.AreEqual(0, score);
        }
    }
}
