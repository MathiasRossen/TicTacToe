using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Services;

namespace TicTacToe.UnitTests
{
    [TestClass]
    public class AITests
    {
        private char[,] gameBoard;
        string output = "";

        [TestInitialize]
        public void SetupUnitTests()
        {
            gameBoard = new char[3, 3]
            {
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            };
        }

        [TestMethod]
        public void CanPlayAsX()
        {
            AI.Symbol = 'X';
            output = AI.TakeTurn(gameBoard);

            Assert.AreEqual("5", output);
        }

        [TestMethod]
        public void CanPlayAsO()
        {
            AI.Symbol = 'O';

            gameBoard = new char[3, 3]
            {
                { ' ', ' ', ' ' },
                { ' ', 'X', ' ' },
                { ' ', ' ', ' ' }
            };

            output = AI.TakeTurn(gameBoard);

            Assert.AreEqual("1", output);
        }

        [TestMethod]
        public void HighestPrioSquareNotTaken()
        {
            gameBoard = new char[3, 3]
            {
                { 'X', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            };

            output = AI.TakeTurn(gameBoard);

            Assert.AreEqual("5", output);
        }

        [TestMethod]
        public void WillBlockOpponentOnRow()
        {
            gameBoard = new char[3, 3]
            {
                { 'X', ' ', ' ' },
                { 'X', 'O', ' ' },
                { ' ', ' ', ' ' }
            };

            output = AI.TakeTurn(gameBoard);

            Assert.AreEqual("7", output);
        }

        [TestMethod]
        public void WillBlockOpponentOnColumn()
        {
            gameBoard = new char[3, 3]
            {
                { 'O', ' ', ' ' },
                { 'X', 'X', ' ' },
                { ' ', ' ', ' ' }
            };

            output = AI.TakeTurn(gameBoard);

            Assert.AreEqual("6", output);
        }

        [TestMethod]
        public void WillBlockOpponentDiagonally()
        {
            gameBoard = new char[3, 3]
            {
                { 'O', ' ', 'X' },
                { ' ', 'X', ' ' },
                { ' ', ' ', ' ' }
            };

            output = AI.TakeTurn(gameBoard);

            Assert.AreEqual("7", output);
        }

        [TestMethod]
        public void WillWinRow()
        {
            gameBoard = new char[3, 3]
            {
                { 'X', 'O', ' ' },
                { 'X', 'O', ' ' },
                { ' ', ' ', 'X' }
            };

            output = AI.TakeTurn(gameBoard);

            Assert.AreEqual("8", output);
        }

        [TestMethod]
        public void WillWinColumn()
        {
            gameBoard = new char[3, 3]
            {
                { ' ', ' ', 'X' },
                { 'X', 'X', ' ' },
                { 'O', 'O', ' ' }
            };

            output = AI.TakeTurn(gameBoard);

            Assert.AreEqual("9", output);
        }

        [TestMethod]
        public void WillWinDiagonally()
        {
            gameBoard = new char[3, 3]
            {
                { ' ', ' ', 'O' },
                { 'X', 'O', ' ' },
                { ' ', 'X', 'X' }
            };

            output = AI.TakeTurn(gameBoard);

            Assert.AreEqual("7", output);
        }
    }
}
