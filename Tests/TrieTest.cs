using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Boggle.Dictionary;

namespace Tests
{
    [TestClass]
    public class TrieTest
    {
        [TestMethod]
        public void TrieCreateFromSingleWordTest()
        {
            var word = "test";
            var trie = new Trie();

            trie.Insert(word);

            Assert.AreEqual(word.Length, trie.Count);
        }

        [TestMethod]
        public void TrieCreateFromSeveralWordsTest()
        {
            List<string> words = new List<string> { "test", "tent", "ball" };
            var trie = new Trie();

            trie.InsertRange(words);

            Assert.AreEqual(trie.Count, 10);
        }

        [TestMethod]
        public void TrieGetPrefixDoGetTest()
        {
            var testWord = "tes";
            List<string> words = new List<string> { "test", "tent", "ball" };
            var trie = new Trie();
            trie.InsertRange(words);

            var prefix = trie.Prefix(testWord);

            Assert.AreEqual(prefix.Depth, testWord.Length);
        }

        [TestMethod]
        public void TrieGetPrefixDoNotGetTest()
        {
            var testWord = "tender";
            List<string> words = new List<string> { "test", "tent", "ball" };
            var trie = new Trie();
            trie.InsertRange(words);

            var prefix = trie.Prefix(testWord);

            Assert.AreNotEqual(prefix.Depth, testWord.Length);
        }

        [TestMethod]
        public void TrieSearchDidFindTest()
        {
            List<string> words = new List<string> { "test", "tent", "ball" };
            var trie = new Trie();
            trie.InsertRange(words);

            var didFind = trie.Search("test");

            Assert.AreEqual(didFind, true);
        }

        [TestMethod]
        public void TrieSearchDidNotFindTest()
        {
            List<string> words = new List<string> { "test", "tent", "ball" };
            var trie = new Trie();
            trie.InsertRange(words);

            var didFind = trie.Search("tes");

            Assert.AreEqual(didFind, false);
        }

        [TestMethod]
        public void TrieCreateFromFile()
        {
            var fileLocation = "Assets/Dictionaries/Dictionary_CountSize10.txt";
            TrieDictionaryReader reader = new TrieDictionaryReader(fileLocation);

            var trie = reader.ReadAndGenerate();

            Assert.AreEqual(trie.Count, 10);
        }
    }
}
