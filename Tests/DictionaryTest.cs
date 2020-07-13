using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Boggle.Dictionary;

namespace Tests
{
    [TestClass]
    public class DictionaryTest
    {
        [TestMethod]
        public void FindChildNodeDidFindTest()
        {
            Node parentNode = new Node('*', 0);
            Node childNodeA = new Node('a', 1);
            Node childNodeB = new Node('b', 1);
            Node childNodeC = new Node('c', 1);
            parentNode.Children.Add(childNodeA);
            parentNode.Children.Add(childNodeB);
            parentNode.Children.Add(childNodeC);

            var foundNode = parentNode.FindChildNode('b');

            Assert.IsNotNull(foundNode);
        }

        [TestMethod]
        public void FindChildNodeDidNotFindTest()
        {
            Node parentNode = new Node('*', 0);
            Node childNodeA = new Node('a', 1);
            Node childNodeB = new Node('b', 1);
            Node childNodeC = new Node('c', 1);
            parentNode.Children.Add(childNodeA);
            parentNode.Children.Add(childNodeB);
            parentNode.Children.Add(childNodeC);

            var foundNode = parentNode.FindChildNode('d');

            Assert.IsNull(foundNode);
        }
    }
}
