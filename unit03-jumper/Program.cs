using System;

namespace unit03_jumper.Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// Makes an instance of gameplay and calls it's startgame function
            /// </summary>
            /// <param name="args">The given arguments.</param>
            GamePlay game = new GamePlay();
            game.StartGame();
        }
    }
}
