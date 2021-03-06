﻿using System;
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
            GameWinnerService.CurrentPlayer = 'X';
            _gameBoard = new char[3, 3] {
                {'X', 'X', 'X'},
                {' ', ' ', ' '},
                {' ', ' ', ' '}
            };

            Assert.AreEqual('X', _gameWinnerService.Validate(_gameBoard));
        }

        [TestMethod]
        public void PlayerWithAllSpacesInSecondRowIsWinner()
        {
            GameWinnerService.CurrentPlayer = 'X';
            _gameBoard = new char[3, 3] {
                {' ', ' ', ' '},
                {'X', 'X', 'X'},
                {' ', ' ', ' '}
            };

            Assert.AreEqual('X', _gameWinnerService.Validate(_gameBoard));
        }

        [TestMethod]
        public void PlayerWithAllSpacesInThirdRowIsWinner()
        {
            _gameBoard = new char[3, 3] {
                {' ', ' ', ' '},
                {' ', ' ', ' '},
                {'X', 'X', 'X'},
            };
            Assert.AreEqual('X', _gameWinnerService.Validate(_gameBoard));
        }

        [TestMethod]
        public void PlayerWithAllSpacesInFirstColumnIsWinner()
        {
            GameWinnerService.CurrentPlayer = 'X';
            _gameBoard = new char[3, 3] {
                {'X', ' ', ' '},
                {'X', ' ', ' '},
                {'X', ' ', ' '},
            };

            Assert.AreEqual('X', _gameWinnerService.Validate(_gameBoard));
        }

        [TestMethod]
        public void PlayerWithAllSpacesInSecondColumnIsWinner()
        {
            GameWinnerService.CurrentPlayer = 'X';
            _gameBoard = new char[3, 3] {
                {' ', 'X', ' '},
                {' ', 'X', ' '},
                {' ', 'X', ' '},
            };

            Assert.AreEqual('X', _gameWinnerService.Validate(_gameBoard));
        }

        [TestMethod]
        public void PlayerWithAllSpacesInThirdColumnIsWinner()
        {
            GameWinnerService.CurrentPlayer = 'X';
            _gameBoard = new char[3, 3] {
                {' ', ' ', 'X'},
                {' ', ' ', 'X'},
                {' ', ' ', 'X'},
            };

            Assert.AreEqual('X', _gameWinnerService.Validate(_gameBoard));
        }

        [TestMethod]
        public void PlayerWithThreeInARowDiagonallyDownAndToRightIsWinner()
        {
            _gameBoard = new char[3, 3] {
                {'X', ' ', ' '},
                {' ', 'X', ' '},
                {' ', ' ', 'X'},
            };

            Assert.AreEqual('X', _gameWinnerService.Validate(_gameBoard));
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
            Assert.AreEqual('X', actual);
        }

        [TestMethod]
        public void NooneWins()
        {
            _gameBoard = new char[3, 3] {
                {' ', ' ', ' '},
                {' ', 'X', 'X'},
                {'X', ' ', ' '},
            };

            Assert.AreEqual(' ', _gameWinnerService.Validate(_gameBoard));

            _gameBoard = new char[3, 3] {
                {'X', ' ', 'X'},
                {' ', 'X', ' '},
                {' ', ' ', ' '},
            };

            Assert.AreEqual(' ', _gameWinnerService.Validate(_gameBoard));
        }

        [TestMethod]
        public void PlayerOWinsTopRow()
        {
            GameWinnerService.CurrentPlayer = 'O';

            _gameBoard = new char[3, 3] {
                {'O', 'O', 'O'},
                {' ', ' ', ' '},
                {' ', ' ', ' '},
            };

            Assert.AreEqual('O', _gameWinnerService.Validate(_gameBoard));       
        }

        [TestMethod]
        public void PlayerOWinsColumnTwo()
        {
            _gameBoard = new char[3, 3] {
                {' ', 'O', ' '},
                {' ', 'O', ' '},
                {' ', 'O', ' '},
            };

            Assert.AreEqual('O', _gameWinnerService.Validate(_gameBoard));
        }

        [TestMethod]
        public void PlayerOWinsDiagonally()
        {
            _gameBoard = new char[3, 3] {
                {'O', ' ', ' '},
                {' ', 'O', ' '},
                {' ', ' ', 'O'},
            };

            Assert.AreEqual('O', _gameWinnerService.Validate(_gameBoard));
        }


    }
}
