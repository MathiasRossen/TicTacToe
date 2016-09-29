using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicTacToe.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToe.UnitTests
{
    [TestClass]
    public class GameLogicTests
    {
        [TestInitialize]
        public void SetUpUnitTests()
        {
            
        }
          

        [TestMethod]
        public void TestIfGameInputIsBetweenOneandNine()
        {
            int lowerbound = 1;
            int upperbound = 9;
            int result;

            for (int i = lowerbound; i <= upperbound; i++)
            {
                Assert.IsTrue(GameLogic.Validate(i.ToString(), out result));
            }
        }

        [TestMethod]
        public void AssertIfLettersReturnFalse()
        {
            int result;
            Assert.IsFalse(GameLogic.Validate("aaa", out result));
            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void DoPlayersSwitchBetweenTurns()
        {
            GameWinnerService.CurrentPlayer = 'X';
            GameLogic.NextPlayer();
            Assert.AreEqual('O', GameWinnerService.CurrentPlayer);
        }

    }
}
