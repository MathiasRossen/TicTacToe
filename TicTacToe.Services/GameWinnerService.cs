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
                if (gameBoard[0, columnNum] == 'X' && gameBoard[1, columnNum] == 'X' && gameBoard[2, columnNum] == 'X')
                    return 'X';
            }

            return SymbolForNoWinner;

        }

        private static char CheckForThreeInARowInHorizontalRow(char[,] gameBoard)
        {
            for(int rowNum = 0; rowNum < 3; rowNum++)
            {
                if (gameBoard[rowNum, 0] == 'X' && gameBoard[rowNum, 1] == 'X' && gameBoard[rowNum, 2] == 'X')
                    return 'X';
            }

            return SymbolForNoWinner;
        }

        private static char CheckForThreeInARowDiagonally(char[,] gameBoard)
        {
            var cellOneChar = gameBoard[0, 0];
            var cellTwoChar = gameBoard[1, 1];
            var cellThreeChar = gameBoard[2, 2];
            if (cellOneChar == 'X' && cellTwoChar == 'X' &&
                cellThreeChar == 'X')
            {
                return cellOneChar;
            }
            cellOneChar = gameBoard[0, 2];
            cellTwoChar = gameBoard[1, 1];
            cellThreeChar = gameBoard[2, 0];
            if (cellOneChar == 'X' && cellTwoChar == 'X' &&
                cellThreeChar == 'X')
            {
                return cellOneChar;
            }
            return SymbolForNoWinner;
        }
    }
}
