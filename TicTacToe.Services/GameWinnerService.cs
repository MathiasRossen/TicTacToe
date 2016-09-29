using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe.Services
{
    public interface IGameWinnerService
    {
        char Validate(char[,] gameBoard);
    }

    public class GameWinnerService : IGameWinnerService
    {
        private const char SymbolForNoWinner = ' ';
        public static char CurrentPlayer = 'X';

        public char Validate(char[,] gameBoard)
        {
            var currentWinningSymbol = CheckForThreeInARowInHorizontalRow(gameBoard);
            if (currentWinningSymbol != SymbolForNoWinner)
                return currentWinningSymbol;
            currentWinningSymbol = CheckForThreeInARowInVerticalColumn(gameBoard);
            if (currentWinningSymbol != SymbolForNoWinner)
                return currentWinningSymbol;
            currentWinningSymbol = CheckForThreeInARowDiagonally(gameBoard);
            return currentWinningSymbol;
        }

        private static char CheckForThreeInARowInVerticalColumn(char[,] gameBoard)
        {
            for (int columnNum = 0; columnNum < 3; columnNum++)
            {
                if (gameBoard[0, columnNum] == CurrentPlayer && gameBoard[1, columnNum] == CurrentPlayer && gameBoard[2, columnNum] == CurrentPlayer)
                    return CurrentPlayer;
            }

            return SymbolForNoWinner;

        }

        private static char CheckForThreeInARowInHorizontalRow(char[,] gameBoard)
        {
            for(int rowNum = 0; rowNum < 3; rowNum++)
            {
                if (gameBoard[rowNum, 0] == CurrentPlayer && gameBoard[rowNum, 1] == CurrentPlayer && gameBoard[rowNum, 2] == CurrentPlayer)
                    return CurrentPlayer;
            }

            return SymbolForNoWinner;
        }

        private static char CheckForThreeInARowDiagonally(char[,] gameBoard)
        {
            var cellOneChar = gameBoard[0, 0];
            var cellTwoChar = gameBoard[1, 1];
            var cellThreeChar = gameBoard[2, 2];
            if (cellOneChar == CurrentPlayer && cellTwoChar == CurrentPlayer &&
                cellThreeChar == CurrentPlayer)
            {
                return cellOneChar;
            }
            cellOneChar = gameBoard[0, 2];
            cellTwoChar = gameBoard[1, 1];
            cellThreeChar = gameBoard[2, 0];
            if (cellOneChar == CurrentPlayer && cellTwoChar == CurrentPlayer &&
                cellThreeChar == CurrentPlayer)
            {
                return cellOneChar;
            }
            return SymbolForNoWinner;
        }
    }
}
