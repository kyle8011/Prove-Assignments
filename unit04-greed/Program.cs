using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unit04_greed.Classes.Casting;
using Unit04_greed.Classes.Directing;
using Unit04_greed.Classes.Services;


namespace Unit04
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        private static int FRAME_RATE = 12;
        private static int MAX_X = 900;
        private static int MAX_Y = 600;
        private static int CELL_SIZE = 15;
        private static int FONT_SIZE = 15;
        private static int COLS = 60;
        private static int ROWS = 40;
        private static string CAPTION = "player Finds Kitten";
        private static string DATA_PATH = "Data/messages.txt";
        private static Color WHITE = new Color(255, 255, 255);
        private static int DEFAULT_COLLECTIBLES = 40;
        


        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();

            // create the banner
            Actor banner = new Actor();
            banner.SetText("");
            banner.SetFontSize(FONT_SIZE);
            banner.SetColor(WHITE);
            banner.SetPosition(new Point(CELL_SIZE, 0));
            cast.AddActor("banner", banner);

            // create the player
            Actor player = new Actor();
            player.SetText("#");
            player.SetFontSize(FONT_SIZE+5);
            player.SetColor(WHITE);
            player.SetPosition(new Point(MAX_X / 2, 580));
            cast.AddActor("player", player);

            // load the messages
            List<string> messages = File.ReadAllLines(DATA_PATH).ToList<string>();

            // create the collectibles
            Random random = new Random();
            for (int i = 0; i < DEFAULT_COLLECTIBLES; i++)
            {
                string text = "blank";
                string message = "nothing";
                var list = new List<string>{"rock","gem"};
                int index = random.Next(list.Count);
                
                if (list[index] == "rock") {text = "O";}
                else if (list[index] == "gem") {text = "*";}

                int x = random.Next(1, COLS);
                int y = 0;
                Point position = new Point(x, y);
                position = position.Scale(CELL_SIZE);

                int r = random.Next(0, 256);
                int g = random.Next(0, 256);
                int b = random.Next(0, 256);
                Color color = new Color(r, g, b);

                Collectible collectible = new Collectible();
                collectible.SetText(text);
                collectible.SetFontSize(FONT_SIZE);
                collectible.SetColor(color);
                collectible.SetPosition(position);
                collectible.SetMessage(message);
                cast.AddActor("collectibles", collectible);
            }

            // start the game
            KeyboardService keyboardService = new KeyboardService(CELL_SIZE);
            VideoService videoService 
                = new VideoService(CAPTION, MAX_X, MAX_Y, CELL_SIZE, FRAME_RATE, false);
            Director director = new Director(keyboardService, videoService);
            director.StartGame(cast);

            // test comment
        }
    }
}