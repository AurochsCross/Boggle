using System.Collections.Generic;

namespace Boggle.Dictionary
{
    public class Node
    {
        public char Value { get; set; }
        public List<Node> Children { get; set; }
        public int Depth { get; set; }
        public bool IsLeaf
        {
            get
            {
                return Children.Count == 0;
            }
        }
        public bool IsStandalone
        {
            get
            {
                foreach (var child in Children)
                {
                    if (child.IsLeaf)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public Node(char value, int depth)
        {
            Value = value;
            Children = new List<Node>();
            Depth = depth;
        }

        public Node FindChildNode(char c)
        {
            foreach (var child in Children)
            {
                if (child.Value == c)
                    return child;
            }

            return null;
        }
    }
}