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
            var rowOneChar = gameBoard[0, 0];
            var rowTwoChar = gameBoard[1, 0];
            var rowThreeChar = gameBoard[2, 0];
            if (rowOneChar == 'X' && rowTwoChar == 'X' &&
                rowThreeChar == 'X')
            {
                return rowOneChar;
            }
            rowOneChar = gameBoard[0, 1];
            rowTwoChar = gameBoard[1, 1];
            rowThreeChar = gameBoard[2, 1];
            if (rowOneChar == 'X' && rowTwoChar == 'X' &&
                rowThreeChar == 'X')
            {
                return rowOneChar;
            }
            rowOneChar = gameBoard[0, 2];
            rowTwoChar = gameBoard[1, 2];
            rowThreeChar = gameBoard[2, 2];
            if (rowOneChar == 'X' && rowTwoChar == 'X' &&
                rowThreeChar == 'X')
            {
                return rowOneChar;
            }
            return SymbolForNoWinner;

        }

        private static char CheckForThreeInARowInHorizontalRow(char[,] gameBoard)
        {
            var columnOneChar = gameBoard[0, 0];
            var columnTwoChar = gameBoard[0, 1];
            var columnThreeChar = gameBoard[0, 2];
            if (columnOneChar == 'X' && columnTwoChar == 'X' && 
                columnThreeChar == 'X')
            {
                return columnOneChar;
            }
            columnOneChar = gameBoard[1, 0];
            columnTwoChar = gameBoard[1, 1];
            columnThreeChar = gameBoard[1, 2];
            if (columnOneChar == 'X' && columnTwoChar == 'X' &&
                columnThreeChar == 'X')
            {
                return columnOneChar;
            }
            columnOneChar = gameBoard[2, 0];
            columnTwoChar = gameBoard[2, 1];
            columnThreeChar = gameBoard[2, 2];
            if (columnOneChar == 'X' && columnTwoChar == 'X' &&
                columnThreeChar == 'X')
            {
                return columnOneChar;
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
