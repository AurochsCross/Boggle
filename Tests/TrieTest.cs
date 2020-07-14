using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Boggle.Models;
using Boggle.Utilities;

namespace Tests
{
    [TestClass]
    public class TrieTest
    {
        [TestMethod]
        public void TrieIsCreatedFromSingleWord()
        {
            var word = "test";
            var trie = new Trie();

            trie.Insert(word);

            Assert.AreEqual(word.Length, trie.Count);
        }

        [TestMethod]
        public void TrieIsCreatedFromSeveralWords()
        {
            List<string> words = new List<string> { "test", "tent", "ball" };
            var trie = new Trie();

            trie.InsertRange(words);

            Assert.AreEqual(trie.Count, 10);
        }

        [TestMethod]
        public void TrieFindsCorrectPrefix()
        {
            var testWord = "tes";
            List<string> words = new List<string> { "test", "tent", "ball" };
            var trie = new Trie();
            trie.InsertRange(words);

            var prefix = trie.Prefix(testWord);

            Assert.AreEqual(prefix.Depth, testWord.Length);
        }

        [TestMethod]
        public void TrieDoesNotGetCorrectPrefixForNonExistingSeach()
        {
            var testWord = "tender";
            List<string> words = new List<string> { "test", "tent", "ball" };
            var trie = new Trie();
            trie.InsertRange(words);

            var prefix = trie.Prefix(testWord);

            Assert.AreNotEqual(prefix.Depth, testWord.Length);
        }

        [TestMethod]
        public void TrieFindsStandAlonePrefixForExistingSearch()
        {
            var testWord = "test";
            List<string> words = new List<string> { "test", "tent", "ball" };
            var trie = new Trie();
            trie.InsertRange(words);

            var prefix = trie.Prefix(testWord);

            Assert.IsTrue(prefix.IsStandalone);
        }

        [TestMethod]
        public void TrieFindsNonStandAlonePrefixForNonExistingSearch()
        {
            var testWord = "tes";
            List<string> words = new List<string> { "test", "tent", "ball" };
            var trie = new Trie();
            trie.InsertRange(words);

            var prefix = trie.Prefix(testWord);

            Assert.IsFalse(prefix.IsStandalone);
        }

        [TestMethod]
        public void TrieFindsExistingSearch()
        {
            List<string> words = new List<string> { "test", "tent", "ball" };
            var trie = new Trie();
            trie.InsertRange(words);

            var didFind = trie.Search("test");

            Assert.IsTrue(didFind);
        }

        [TestMethod]
        public void TrieDoesNotFindNonExistingSearch()
        {
            List<string> words = new List<string> { "test", "tent", "ball" };
            var trie = new Trie();
            trie.InsertRange(words);

            var didFind = trie.Search("tes");

            Assert.IsFalse(didFind);
        }

        [TestMethod]
        public void TrieIsCreatedFromFile()
        {
            var fileLocation = "Assets/Dictionaries/Dictionary_CountSize10.txt";

            var trie = TrieDictionaryReader.ReadAndGenerate(fileLocation);

            Assert.AreEqual(trie.Count, 10);
        }

        [TestMethod]
        public void TrieIsCreatedAndSearchesInLargeSetFile()
        {
            var fileLocation = "Assets/Dictionaries/Dictionary_Big2.txt";

            var trie = TrieDictionaryReader.ReadAndGenerate(fileLocation);
            var didFind = trie.Search("hello");

            Assert.IsTrue(didFind);
        }
    }
}
