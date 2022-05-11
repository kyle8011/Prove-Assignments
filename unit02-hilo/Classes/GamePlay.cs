using System;

namespace unit02_hilo.Classes
{
    /// <summary>
    /// This class holds all the instructions for running the game
    /// </summary>
    public class GamePlay
    {
        public string guess;
        string play_again = "y";
        public int score = 300;
        Card card = new Card();

        /// <summary>
        /// Constructs an instance of GamePlay
        /// </summary>
        public GamePlay() {}

        /// <summary>
        /// Runs the game loop
        /// </summary>
        public void StartGame()
        {
            while (play_again == "y")
            {
                Guess();
                Points();
                PlayAgain();
            }
            Console.WriteLine("Thanks for playing");
        }

        /// <summary>
        /// Allows the user to make a guess based on the card drawn
        /// </summary>
        public void Guess()
        {
            card.Draw();
            Console.WriteLine($"\nThe card is: {card.value}");
            Console.Write("Higher or Lower? [h/l]: ");
            guess = Console.ReadLine();
        }

        /// <summary>
        /// Calculates the points based on the new draw.
        /// </summary>
        public void Points()
        {
            card.Calculate(guess);
            Console.WriteLine($"Next card was: {card.new_value}");
            Console.WriteLine($"Your score is: {card.score}");
        }

        /// <summary>
        /// Asks if the user want to play again.
        /// </summary>
        public void PlayAgain()
        {
            if (card.score > 0) {
            Console.Write("Play Again? [y/n]");
            play_again = Console.ReadLine();
            }
            else {
                Console.WriteLine("Game Over");
                play_again = "n";
            }
        }
    }
}