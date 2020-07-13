using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Boggle.Utility;
using Boggle;

namespace Tests
{
    [TestClass]
    public class UtilitiesTest
    {
        [TestMethod]
        public void BoardParserReadBoardTest()
        {
            var boardPath = "Assets/Boards/Board_ReadTest.txt";
            char[,] controlBoard = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' }};

            var board = BoardParser.ParseFromFile(boardPath);

            Assert.AreEqual('9', board[2, 2]);
        }

        [TestMethod]
        public void MoverAvailableNeighboursTest()
        {
            var board = BoardParser.ParseFromFile("Assets/Boards/Board_ReadTest.txt");
            var visited = new HashSet<(int, int)> { (0, 0), (1, 1), (2, 1), (2, 2) };

            var availableNeighbours = Mover.AvailableNeighbours(visited, 2, 2, 3, 3);

            Assert.AreEqual(1, availableNeighbours.Count);
        }
    }
}
