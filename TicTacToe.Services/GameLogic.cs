﻿using System;
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

        public static bool SetPosition(int pos)
        {

            switch (pos)
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

    }
}
