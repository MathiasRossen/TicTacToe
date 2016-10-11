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

            Assert.AreEqual('X', gameBoard[1, 1]);
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

            gameBoard = AI.TakeTurn(gameBoard);

            Assert.AreEqual('O', gameBoard[0, 0]);
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

            Assert.AreEqual('O', gameBoard[1, 1]);
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

            Assert.AreEqual('O', gameBoard[2, 0]);
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

            Assert.AreEqual('O', gameBoard[2, 1]);
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

            Assert.AreEqual('O', gameBoard[2, 0]);
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

            Assert.AreEqual('O', gameBoard[2, 1]);
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

            gameBoard = AI.TakeTurn(gameBoard);

            Assert.AreEqual('O', gameBoard[2, 2]);
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

            gameBoard = AI.TakeTurn(gameBoard);

            Assert.AreEqual('O', gameBoard[2, 0]);
        }
    }
}
