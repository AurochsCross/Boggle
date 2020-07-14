using System.Collections.Generic;

namespace Boggle.Models
{
    public class Trie
    {
        private const char TRIE_START = '^';
        private const char TRIE_END = '$';

        public readonly Node root;

        public int Count { get; private set; }

        public Trie()
        {
            root = new Node(TRIE_START, 0);
        }

        public Node Prefix(string searchString)
        {
            var currentNode = root;
            var result = currentNode;

            foreach (var searchChar in searchString)
            {
                currentNode = currentNode.FindChildNode(searchChar);
                if (currentNode == null)
                    break;

                result = currentNode;
            }

            return result;
        }

        public bool Search(string searchString)
        {
            var prefix = Prefix(searchString.ToLower() + TRIE_END);
            return prefix.Depth == searchString.Length + 1;
        }

        public void InsertRange(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
                Insert(items[i]);
        }

        public void Insert(string stringToInsert)
        {
            var commonPrefix = Prefix(stringToInsert);
            var current = commonPrefix;

            for (var i = current.Depth; i < stringToInsert.Length; i++)
            {
                var newNode = new Node(stringToInsert[i], current.Depth + 1);
                current.Children.Add(newNode);
                current = newNode;
                Count++;
            }

            current.Children.Add(new Node(TRIE_END, current.Depth + 1));
        }
    }
}
