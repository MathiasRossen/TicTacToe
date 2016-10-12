using System;
using TicTacToe.Services;

namespace TicTacToe.Game
{
    enum PlayerType { Human, AI };
    internal class MainGame
    {
        private bool gameRunning = true;
        private string input;
        private PlayerType playerOne, playerTwo;

        public void GameLoop()
        {
            DrawGameRules();
            GameLogic.ResetGame();

            ChoosePlayers();

            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("X Points: {0} \nY Points: {1}", GameWinnerService.PlayerScoreX, GameWinnerService.PlayerScoreY);
                    DrawGameBoard();
                    Console.WriteLine();
                    Console.WriteLine("Current player: {0}", GameWinnerService.CurrentPlayer);
                    Console.Write("Insert a number from 1-9: ");

                    if (GameWinnerService.CurrentPlayer == 'O')
                    {
                        AI.Symbol = GameWinnerService.CurrentPlayer;
                        input = AI.TakeTurn(GameLogic.GameBoard);
                    }
                    else
                        input = Console.ReadLine();
                }
                while (!GameLogic.SetPosition(input));

                if (GameWinnerService.CheckWinner())
                {
                    Console.Clear();
                    DrawGameBoard();
                    Console.WriteLine();
                    Console.WriteLine("Player {0} has won!", GameWinnerService.CurrentPlayer);
                    GameLogic.AddScore(GameWinnerService.CurrentPlayer);
                    Console.ReadLine();
                    GameLogic.ResetGame();
                }

                if (GameLogic.CheckFullBoard())
                {
                    Console.Clear();
                    DrawGameBoard();
                    Console.WriteLine();
                    Console.WriteLine("This match is a draw.");
                    Console.ReadLine();
                    GameLogic.ResetGame();
                }

                GameLogic.NextPlayer();
            }
            while (gameRunning);
        }

        public void DrawGameBoard()
        {
            for(int y = 0; y < 3; y++)
            {
                for(int x = 0; x < 3; x++)
                {
                    Console.Write("[" + GameLogic.GameBoard[y, x] + "]");
                }
                Console.WriteLine();
            }
        }

        public void DrawGameRules()
        {
            Console.Clear();
            Console.WriteLine("This is the standard Tic Tac Toe game.");
            Console.WriteLine("The rules are simple; if a player has 3 game pieces lined up in a row, column or diagonally wins.");
            Console.WriteLine("To play you have to insert a number 1-9 and the current player's game piece will be placed on the corresponding square.");
            Console.WriteLine();
            Console.WriteLine("[1][2][3]");
            Console.WriteLine("[4][5][6]");
            Console.WriteLine("[7][8][9]");
            Console.WriteLine();
            Console.Write("Press Enter to start playing!");
            Console.ReadLine();
        }

        public void ChoosePlayers()
        {
            bool inputErr = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Choose the type of player X:");
                Console.WriteLine(" 1. Human");
                Console.WriteLine(" 2. AI");
                Console.Write("Choice: ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        playerOne = PlayerType.Human;
                        inputErr = false;
                        break;
                    case "2":
                        playerOne = PlayerType.AI;
                        inputErr = false;
                        break;
                    default:
                        inputErr = true;
                        break;
                }
            }
            while (inputErr);

            do
            {
                Console.Clear();
                Console.WriteLine("Choose the type of player O:");
                Console.WriteLine(" 1. Human");
                Console.WriteLine(" 2. AI");
                Console.Write("Choice: ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        playerTwo = PlayerType.Human;
                        inputErr = false;
                        break;
                    case "2":
                        playerTwo = PlayerType.AI;
                        inputErr = false;
                        break;
                    default:
                        inputErr = true;
                        break;
                }
            }
            while (inputErr);
        }
    }
}