using System;

namespace unit02_hilo.Classes
{
    ///<summary>
    /// Keeps track of the next card and adds score
    ///</summary>
    public class Card
    {
        public int value = 0;
        public int new_value = 0;
        public int score = 300;
        
        /// <summary>
        /// Creates an instance of Card
        /// </summary>
        public Card() {}

        /// <summary>
        /// draws the current and next card
        /// </summary>
        public void Draw()
        {
            Random random = new Random();
            value = random.Next(1, 14);
            new_value = random.Next(1, 14);                
        }
        /// <summary>
        /// Calculates what score to add based on guess
        /// </summary>
        public void Calculate(string guess)
        {
            if (guess == "h" & new_value > value) {score += 100;}
            else if (guess == "l" & new_value < value) {score += 100;}
            else if (new_value == value) {}
            else {score -= 75;}
        }

    }
}