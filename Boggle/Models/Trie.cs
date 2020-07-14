using System.Collections.Generic;

namespace Boggle.Models
{
    public class Trie
    {
        public readonly Node root;

        public int Count { get { return _count; } }
        private int _count = 0;

        public Trie()
        {
            root = new Node('^', 0);
        }

        public Node Prefix(string s)
        {
            var currentNode = root;
            var result = currentNode;

            foreach (var c in s)
            {
                currentNode = currentNode.FindChildNode(c);
                if (currentNode == null)
                    break;

                result = currentNode;
            }

            return result;
        }

        public bool Search(string s)
        {
            var prefix = Prefix(s.ToLower() + '$');
            return prefix.Depth == s.Length + 1;
        }

        public void InsertRange(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
                Insert(items[i]);
        }

        public void Insert(string s)
        {
            var commonPrefix = Prefix(s);
            var current = commonPrefix;

            for (var i = current.Depth; i < s.Length; i++)
            {
                var newNode = new Node(s[i], current.Depth + 1);
                current.Children.Add(newNode);
                current = newNode;
                _count++;
            }

            current.Children.Add(new Node('$', current.Depth + 1));
        }
    }
}
