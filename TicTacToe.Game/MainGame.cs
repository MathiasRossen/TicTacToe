using System;
using TicTacToe.Services;

namespace TicTacToe.Game
{
    internal class MainGame
    {
        IGameWinnerService gameWinnerService;
        private char[,] gameBoard;
        private string input;

        internal void GameLoop()
        {
            bool gameRunning = true;
            gameBoard = new char[3, 3] 
                {
                    { ' ', ' ', ' ' },
                    { ' ', ' ', ' ' },
                    { ' ', ' ', ' '}
                };
            gameWinnerService = new GameWinnerService();

            do
            {
                Console.Clear();
                Console.WriteLine();
                DrawGameBoard();
                input = Console.ReadLine();
                PlaceXAtPos(Int32.Parse(input));

                if(gameWinnerService.Validate(gameBoard) != ' ')
                {
                    Console.Clear();
                    Console.WriteLine();
                    DrawGameBoard();
                    Console.WriteLine("YOU WON!");
                    Console.ReadLine();
                }
            }
            while (gameRunning);
        }

        internal void DrawGameBoard()
        {
            for(int y = 0; y < 3; y++)
            {
                for(int x = 0; x < 3; x++)
                {
                    Console.Write("[" + gameBoard[y, x] + "] ");
                }
                Console.WriteLine();
            }
        }

        internal void PlaceXAtPos(int pos)
        {
            switch (pos)
            {
                case 1:
                    gameBoard[0, 0] = 'X';
                    break;
                case 2:
                    gameBoard[0, 1] = 'X';
                    break;
                case 3:
                    gameBoard[0, 2] = 'X';
                    break;
                case 4:
                    gameBoard[1, 0] = 'X';
                    break;
                case 5:
                    gameBoard[1, 1] = 'X';
                    break;
                case 6:
                    gameBoard[1, 2] = 'X';
                    break;
                case 7:
                    gameBoard[2, 0] = 'X';
                    break;
                case 8:
                    gameBoard[2, 1] = 'X';
                    break;
                case 9:
                    gameBoard[2, 2] = 'X';
                    break;
            }
        }
    }
}