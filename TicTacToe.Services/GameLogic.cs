using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe.Services
{
    public static class GameLogic
    {

        private static char[,] gameBoard = new char[3, 3] 
                {
                    { ' ', ' ', ' ' },
                    { ' ', ' ', ' ' },
                    { ' ', ' ', ' ' }
                };

        public static char[,] GameBoard
        {
            set { gameBoard = value; }
            get { return gameBoard;  }
        }

        public static void ResetGame()
        {
            GameBoard = new char[3, 3]
                {
                    { ' ', ' ', ' ' },
                    { ' ', ' ', ' ' },
                    { ' ', ' ', ' ' }
                };
            GameWinnerService.CurrentPlayer = 'X';
        }

        public static bool SetPosition(string input)
        {

            int i;

            if (!Validate(input, out i))
                return false;

            switch (i)
            {
                case 1:
                    if (IsFieldEmpty(0,0))
                    {
                        GameBoard[0, 0] = GameWinnerService.CurrentPlayer;
                        return true;
                    }
                    break;

                case 2:
                    if (IsFieldEmpty(0,1))
                    {
                        GameBoard[0, 1] = GameWinnerService.CurrentPlayer;
                        return true;
                    }
                    break;

                case 3:
                    if (IsFieldEmpty(0,2))
                    {
                        GameBoard[0, 2] = GameWinnerService.CurrentPlayer;
                        return true;
                    }
                    break;

                case 4:
                    if (IsFieldEmpty(1,0))
                    {
                        GameBoard[1, 0] = GameWinnerService.CurrentPlayer;
                        return true;
                    }
                    break;

                case 5:
                    if (IsFieldEmpty(1,1))
                    {
                        GameBoard[1, 1] = GameWinnerService.CurrentPlayer;
                        return true;
                    }
                    break;

                case 6:
                    if (IsFieldEmpty(1,2))
                    {
                        GameBoard[1, 2] = GameWinnerService.CurrentPlayer;
                        return true;
                    }
                    break;

                case 7:
                    if (IsFieldEmpty(2,0))
                    {
                        GameBoard[2, 0] = GameWinnerService.CurrentPlayer;
                        return true;
                    }
                    break;

                case 8:
                    if (IsFieldEmpty(2,1))
                    {
                        GameBoard[2, 1] = GameWinnerService.CurrentPlayer;
                        return true;
                    }

                    break;
                case 9:
                    if (IsFieldEmpty(2,2))
                    {
                        GameBoard[2, 2] = GameWinnerService.CurrentPlayer;
                        return true;
                    }
                    break;

            }

            return false;

        }

        public static bool IsFieldEmpty(int y, int x)
        {
            if (GameBoard[y, x] == ' ')
                return true;
            return false;
        }

        public static bool Validate(string input, out int i)
        {

            int number;

            if (int.TryParse(input, out number))
            {
                if (number > 0 && number < 10)
                {
                    i = number;
                    return true;
                }
                    
            }

            i = 0;
            return false;

        }

        public static void NextPlayer()
        {

            if (GameWinnerService.CurrentPlayer == 'X')
                GameWinnerService.CurrentPlayer = 'O';
            else
                GameWinnerService.CurrentPlayer = 'X';

        }

    }
}
