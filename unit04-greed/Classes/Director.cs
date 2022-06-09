using System;
using System.Collections.Generic;
using Unit04_greed.Classes.Casting;
using Unit04_greed.Classes.Services;


namespace Unit04_greed.Classes
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private KeyboardService keyboardService = null;
        private VideoService videoService = null; 
                    
        private int points;
        private int new_x;

        /// <summary>
        /// Constructs a new instance of Director using the given KeyboardService and VideoService.
        /// </summary>
        /// <param name="keyboardService">The given KeyboardService.</param>
        /// <param name="videoService">The given VideoService.</param>
        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this.keyboardService = keyboardService;
            this.videoService = videoService;
        }

        /// <summary>
        /// Starts the game by running the main game loop for the given cast.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void StartGame(Cast cast)
        {
            videoService.OpenWindow();
            while (videoService.IsWindowOpen())
            {
                GetInputs(cast);
                DoUpdates(cast);
                DoOutputs(cast);
            }
            videoService.CloseWindow();
        }

        /// <summary>
        /// Gets directional input from the keyboard and applies it to the player.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void GetInputs(Cast cast)
        {
            Actor player = cast.GetFirstActor("player");
            Point velocity = keyboardService.GetDirection();
            player.SetVelocity(velocity);     
        }
        
        /// <summary>
        /// Updates the player's position and resolves any collisions with collectibles.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void DoUpdates(Cast cast)
        {
            Random random = new Random();
            int i;
            Actor banner = cast.GetFirstActor("banner");
            Actor player = cast.GetFirstActor("player");
            List<Actor> collectibles = cast.GetActors("collectibles");

            banner.SetText("");
            int maxX = videoService.GetWidth();
            int maxY = videoService.GetHeight();
            player.MoveNext(maxX, maxY);
           
            int speed = random.Next(3, 9);
            Point direction = new Point(0, speed/3);
            direction = direction.Scale(5);

            int x = random.Next(1, 900);
            i = random.Next(0, collectibles.Count);
            if (collectibles[i].GetPosition().GetY() <= 10)
            {
            Point position = new Point(x, 0);
            collectibles[i].SetPosition(position);
            }
            collectibles[i].SetVelocity(direction);
            for(i = 0; i < collectibles.Count; i++)
            {collectibles[i].MoveNext(maxX, maxY);}
        
            
            
            
            foreach (Actor actor in collectibles)
            {
                
                if (player.GetPosition().Equals(actor.GetPosition()))
                {
                    Collectible collectible = (Collectible) actor;
                    points = points + collectible.GetValue(); 
                    new_x = random.Next(maxX);
                    Point new_position = new Point(new_x, -10);
                    actor.SetPosition(new_position);
                    
                }
            } 
            banner.SetText($"Score: {points}");
        }

        /// <summary>
        /// Draws the actors on the screen.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void DoOutputs(Cast cast)
        {
            List<Actor> actors = cast.GetAllActors();
            videoService.ClearBuffer();
            videoService.DrawActors(actors);
            videoService.FlushBuffer();
        }

    }
}