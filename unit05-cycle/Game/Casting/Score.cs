using System;
using System.Collections.Generic;


namespace unit05_cycle.Game.Casting
{
    /// <summary>
    /// <para>Keeps track of how long the game has run</para>
    /// <para>
    /// The responsibility of Food is to select a random position and points that it's worth.
    /// </para>
    /// </summary>
    public class Time : Actor
    {
        private int time = 0;

        /// <summary>
        /// Constructs a new instance of Score, starting at 0.
        /// </summary>
        public Time(Cast cast)
        {
            AddTime(cast);
        }

        /// <summary>
        /// Increments time by 1 and sets the text
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddTime(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            List<Actor> body = snake.GetBody(); 
            time++;
            SetText($"Time: {this.time}");
        }
        public int GetTime() 
        {
            return time;
        }
    }
}