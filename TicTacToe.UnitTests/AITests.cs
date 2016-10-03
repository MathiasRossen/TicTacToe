using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Services;

namespace TicTacToe.UnitTests
{
    [TestClass]
    public class AITests
    {
        private char[,] gameBoard;

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
            gameBoard = AI.TakeTurn(gameBoard);

            char[,] expected = new char[3, 3]
            {
                { ' ', ' ', ' ' },
                { ' ', 'X', ' ' },
                { ' ', ' ', ' ' }
            };

            Assert.AreEqual(expected, gameBoard);
        }

        [TestMethod]
        public void CanPlayAsO()
        {
            AI.Symbol = 'O';

            gameBoard = new char[3, 3]
            {
                { 'X', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            };

            gameBoard = AI.TakeTurn(gameBoard);

            char[,] expected = new char[3, 3]
            {
                { 'O', ' ', ' ' },
                { ' ', 'X', ' ' },
                { ' ', ' ', ' ' }
            };

            Assert.AreEqual(expected, gameBoard);
        }

        [TestMethod]
        public void HighestPrioSquareNotTaken()
        {
            gameBoard = new char [3, 3] 
            {
                { 'X', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            };

            gameBoard = AI.TakeTurn(gameBoard);

            char[,] expected = new char[3, 3]
            {
                { 'X', ' ', ' ' },
                { ' ', 'O', ' ' },
                { ' ', ' ', ' ' }
            };

            Assert.AreEqual(expected, gameBoard);
        }

        [TestMethod]
        public void HighestPrioSquareTaken()
        {
            gameBoard = new char[3, 3]
            {
                { ' ', ' ', ' ' },
                { ' ', 'X', ' ' },
                { ' ', ' ', ' ' }
            };

            gameBoard = AI.TakeTurn(gameBoard);

            char[,] expected = new char[3, 3]
            {
                { 'O', ' ', ' ' },
                { ' ', 'X', ' ' },
                { ' ', ' ', ' ' }
            };

            Assert.AreEqual(expected, gameBoard);
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

            gameBoard = AI.TakeTurn(gameBoard);

            char[,] expected = new char[3, 3]
            {
                { 'X', ' ', ' ' },
                { 'X', 'O', ' ' },
                { 'O', ' ', ' ' }
            };

            Assert.AreEqual(expected, gameBoard);
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

            gameBoard = AI.TakeTurn(gameBoard);

            char[,] expected = new char[3, 3]
            {
                { 'O', ' ', ' ' },
                { 'X', 'X', 'O' },
                { ' ', ' ', ' ' }
            };

            Assert.AreEqual(expected, gameBoard);
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

            gameBoard = AI.TakeTurn(gameBoard);

            char[,] expected = new char[3, 3]
            {
                { 'O', ' ', 'X' },
                { ' ', 'X', ' ' },
                { 'O', ' ', ' ' }
            };

            Assert.AreEqual(expected, gameBoard);
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

            gameBoard = AI.TakeTurn(gameBoard);

            char[,] expected = new char[3, 3]
            {
                { 'X', 'O', ' ' },
                { 'X', 'O', ' ' },
                { ' ', 'O', 'X' }
            };

            Assert.AreEqual(expected, gameBoard);
        }

        [TestMethod]
        public void WillWinColumn()
        {
            gameBoard = new char[3, 3]
            {
                { 'O', 'O', ' ' },
                { 'X', 'X', ' ' },
                { ' ', ' ', 'X' }
            };

            gameBoard = AI.TakeTurn(gameBoard);

            char[,] expected = new char[3, 3]
            {
                { 'O', 'O', 'O' },
                { 'X', 'X', ' ' },
                { ' ', ' ', 'X' }
            };

            Assert.AreEqual(expected, gameBoard);
        }

        [TestMethod]
        public void WillWinDiagonally()
        {
            gameBoard = new char[3, 3]
            {
                { 'X', ' ', ' ' },
                { 'X', 'O', ' ' },
                { 'O', ' ', 'X' }
            };

            gameBoard = AI.TakeTurn(gameBoard);

            char[,] expected = new char[3, 3]
            {
                { 'X', ' ', 'O' },
                { 'X', 'O', ' ' },
                { 'O', ' ', 'X' }
            };

            Assert.AreEqual(expected, gameBoard);
        }
    }
}
