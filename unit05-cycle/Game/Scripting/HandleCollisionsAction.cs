using System;
using System.Collections.Generic;
using System.Data;
using unit05_cycle.Game.Casting;
using unit05_cycle.Game.Services;


namespace unit05_cycle.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;
        public bool OneIsAlive = true;
        public bool TwoIsAlive = true;
        private int death_time1 = 0;
        private int death_time2 = 0;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            HandleSegmentCollisions(cast);
            HandleGameOver(cast);
            
        }


        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Snake snake1 = (Snake)cast.GetFirstActor("snake");
            Actor head1 = snake1.GetHead();
            List<Actor> body1 = snake1.GetBody();
            Snake snake2 = (Snake)cast.GetSecondActor("snake");
            Actor head2 = snake2.GetHead();
            List<Actor> body2 = snake2.GetBody();

            foreach (Actor segment in body1)
            {
                if (segment.GetPosition().Equals(head1.GetPosition()) && OneIsAlive)
                {
                    OneIsAlive = false;
                    isGameOver = true;
                }
                else if (segment.GetPosition().Equals(head2.GetPosition()) && OneIsAlive) 
                {
                    TwoIsAlive = false;
                    isGameOver = true;
                }
            }
            foreach (Actor segment in body2)
            {
                if (segment.GetPosition().Equals(head1.GetPosition()) && TwoIsAlive)
                {
                    OneIsAlive = false;
                    isGameOver = true;
                }
                else if (segment.GetPosition().Equals(head2.GetPosition()) && TwoIsAlive)
                {
                    TwoIsAlive = false;
                    isGameOver = true;
                }
            }
        }

        private void HandleGameOver(Cast cast)
        {
            Time time = (Time)cast.GetFirstActor("time");
            if (OneIsAlive) {death_time1 = time.GetTime();}
            if (TwoIsAlive) {death_time2 = time.GetTime();}
            if (isGameOver == true)
            {
                Snake snake1 = (Snake)cast.GetFirstActor("snake");
                List<Actor> segments1 = snake1.GetSegments();
                Snake snake2 = (Snake)cast.GetSecondActor("snake");
                List<Actor> segments2 = snake2.GetSegments();
                

                
                if (!OneIsAlive)
                {
                    // create a "game over" message
                    int x = Constants.MAX_X / 2;
                    int y = (Constants.MAX_Y / 2)-20;
                    Point position1 = new Point(x, y);

                    Actor message1 = new Actor();
                    
                    message1.SetText($"Player 1 Died at {death_time1}");
                    message1.SetPosition(position1);
                    cast.AddActor("messages", message1);

                    // make everything white
                    foreach (Actor segment in segments1)
                    {
                        segment.SetColor(Constants.WHITE);
                    }
                }
                if (TwoIsAlive == false) {
                    // create a "game over" message
                    int x = Constants.MAX_X / 2;
                    int y = (Constants.MAX_Y / 2)+20;
                    Point position2 = new Point(x, y);
                    Actor message2 = new Actor();
                    message2.SetText($"Player 2 Died at {death_time2}");
                    message2.SetPosition(position2);
                    cast.AddActor("messages", message2);
                    // make everything white
                    foreach (Actor segment in segments2)
                    {
                        segment.SetColor(Constants.WHITE);
                    }
                }
            }
        }
    }
}