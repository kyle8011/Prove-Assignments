using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unit04_greed.Classes.Casting;
using Unit04_greed.Classes;
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
        private static int FONT_SIZE = 20;
        private static int COLS = 60;
        private static int ROWS = 40;
        private static string CAPTION = "Greed";
        private static Color BLACK = new Color(0, 0, 0);
        private static int DEFAULT_COLLECTIBLES = 100;
        


        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();

            // create the player
            Actor player = new Actor();
            player.SetText("U");
            player.SetFontSize(FONT_SIZE+5);
            player.SetColor(BLACK);
            player.SetPosition(new Point(MAX_X / 2, 580));
            cast.AddActor("player", player);


            // create the collectibles
            Random random = new Random();
            for (int i = 0; i < DEFAULT_COLLECTIBLES; i++)
            {
                Collectible collectible = new Collectible();
                int value = collectible.GetValue();
                string text = "blank";
                int r = 0;
                int g = 0;
                int b = 0;
                
                if (value == -3) {
                    text = "O";
                    r = 255; g = 255; // yellow
                }
                if (value == -2) {
                    text = "O";
                    r = 255;} //red
                else if (value == -1) {
                    text = "O";
                    r = 255; g = 255; b = 255;} //white
                else if (value == 0) {
                    text = "O";
                    } //black
                else if (value == 1) {
                    text = "*";
                    b = 255;}  //blue
                else if (value == 2) {
                    text = "*";
                    b = 255; r = 255;}  //purple
                else if (value == 3) {
                    text = "*";
                    g = 255;} //green    
                
                
                Color color = new Color(r, g, b);
                Point position = new Point(900, 0);
                position = position.Scale(CELL_SIZE);

                collectible.SetText(text);
                collectible.SetFontSize(FONT_SIZE);
                collectible.SetColor(color);
                collectible.SetPosition(position);
                collectible.SetValue(value);
                cast.AddActor("collectibles", collectible);

            }
            // create the banner
            Actor banner = new Actor();
            banner.SetText("");
            banner.SetFontSize(FONT_SIZE);
            banner.SetColor(BLACK);
            banner.SetPosition(new Point(CELL_SIZE, 0));
            cast.AddActor("banner", banner);

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