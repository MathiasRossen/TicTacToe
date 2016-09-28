using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Services;

namespace TicTacToe.Game
{
    class Program
    {        
        static void Main(string[] args)
        {
            MainGame mainGame = new MainGame();
            mainGame.GameLoop();
        }
    }
}
