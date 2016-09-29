using System;

namespace TicTacToe.Game
{
    class Program
    {        
        static void Main(string[] args)
        {
            Console.Title = "Tic Tac Toe";

            MainGame mainGame = new MainGame();
            mainGame.GameLoop();
        }
    }
}
