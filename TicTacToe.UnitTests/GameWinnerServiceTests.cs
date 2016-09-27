using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Services;

namespace TicTacToe.UnitTests
{
    [TestClass]
    public class GameWinnerServiceTests
    {
        private IGameWinnerService _gameWinnerService;
        private char[,] _gameBoard;
        
        [TestInitialize]
        public void SetupUnitTests()
        {
            _gameWinnerService = new GameWinnerService();
            _gameBoard = new char[3, 3]
                  {
                      {' ', ' ', ' '}, 
                      {' ', ' ', ' '}, 
                      {' ', ' ', ' '}
                  };
        }
        [TestMethod]
        public void NeitherPlayerHasThreeInARow()
        {
            const char expected = ' ';            
            var actual = _gameWinnerService.Validate(_gameBoard);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PlayerWithAllSpacesInTopRowIsWinner()
        {
            _gameBoard = new char[3, 3] {
                {'X', 'X', 'X'},
                {' ', ' ', ' '},
                {' ', ' ', ' '}
            };

            Assert.AreEqual("X", _gameWinnerService.Validate(_gameBoard).ToString());
        }

        [TestMethod]
        public void PlayerWithAllSpacesInSecondRowIsWinner()
        {
            _gameBoard = new char[3, 3] {
                {' ', ' ', ' '},
                {'X', 'X', 'X'},
                {' ', ' ', ' '}
            };

            Assert.AreEqual("X", _gameWinnerService.Validate(_gameBoard).ToString());
        }

        [TestMethod]
        public void PlayerWithAllSpacesInThirdRowIsWinner()
        {
            _gameBoard = new char[3, 3] {
                {' ', ' ', ' '},
                {' ', ' ', ' '},
                {'X', 'X', 'X'},
            };
            Assert.AreEqual("X", _gameWinnerService.Validate(_gameBoard).ToString());
        }

        [TestMethod]
        public void PlayerWithAllSpacesInFirstColumnIsWinner()
        {
            _gameBoard = new char[3, 3] {
                {'X', ' ', ' '},
                {'X', ' ', ' '},
                {'X', ' ', ' '},
            };

            Assert.AreEqual("X", _gameWinnerService.Validate(_gameBoard).ToString());
        }

        [TestMethod]
        public void PlayerWithAllSpacesInSecondColumnIsWinner()
        {
            _gameBoard = new char[3, 3] {
                {' ', 'X', ' '},
                {' ', 'X', ' '},
                {' ', 'X', ' '},
            };

            Assert.AreEqual("X", _gameWinnerService.Validate(_gameBoard).ToString());
        }

        [TestMethod]
        public void PlayerWithAllSpacesInThirdColumnIsWinner()
        {
            _gameBoard = new char[3, 3] {
                {' ', ' ', 'X'},
                {' ', ' ', 'X'},
                {' ', ' ', 'X'},
            };

            Assert.AreEqual("X", _gameWinnerService.Validate(_gameBoard).ToString());
        }

        [TestMethod]
        public void PlayerWithThreeInARowDiagonallyDownAndToRightIsWinner()
        {
            _gameBoard = new char[3, 3] {
                {'X', ' ', ' '},
                {' ', 'X', ' '},
                {' ', ' ', 'X'},
            };

            Assert.AreEqual("X", _gameWinnerService.Validate(_gameBoard).ToString());
        }

        [TestMethod]
        public void PlayerWithThreeInARowDiagonallyDownAndToLeftIsWinner()
        {
            _gameBoard = new char[3, 3] {
                {' ', ' ', 'X'},
                {' ', 'X', ' '},
                {'X', ' ', ' '},
            };

            var actual = _gameWinnerService.Validate(_gameBoard);
            Assert.AreEqual('X', actual.ToString());
        }

        [TestMethod]
        public void NooneWins()
        {
            _gameBoard = new char[3, 3] {
                {' ', ' ', ' '},
                {' ', 'X', 'X'},
                {'X', ' ', ' '},
            };

            Assert.AreEqual(" ", _gameWinnerService.Validate(_gameBoard).ToString());

            _gameBoard = new char[3, 3] {
                {'X', ' ', 'X'},
                {' ', 'X', ' '},
                {' ', ' ', ' '},
            };

            Assert.AreEqual(" ", _gameWinnerService.Validate(_gameBoard).ToString());
        }

    }
}
