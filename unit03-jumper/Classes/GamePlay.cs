using System;
using System.Collections.Generic;

namespace unit03_jumper.Classes
{
    /// <summary>
    /// This class runs the game, using instances of each other class.
    /// </summary>
    public class GamePlay
    {
        private string guess;
        private string new_word;
        private int i;
        private int letter_not_in;
        private int score;
        private List<bool> hidden = new List<bool>();

        private ChooseWord word = new ChooseWord();
        private Jumper player = new Jumper();
        private TerminalService draw = new TerminalService();

        /// <summary>
        /// Creates an instance of gameplay
        /// </summary>
        public GamePlay() {}

        /// <summary>
        /// The game loop
        /// </summary>
        public void StartGame()
        {
            new_word = word.choose_word();
            new_word.ToCharArray();
            foreach (char letter in new_word) {hidden.Add(true);}
            while (guess != "no")
            {
                player.draw_jumper();
                WriteWord();
                Guess();
                logic();
            }
        }

        /// <summary>
        /// Logic after the user makes a guess
        /// </summary>
        private void Guess()
        {
            letter_not_in = 0;
            guess = draw.ReadText("\nChoose a letter: ");
            if (guess.Length < 2){
            for (i = 0; i < new_word.Length; i++){
                if (char.Parse(guess) == new_word[i] && hidden[i] != false) {
                    hidden[i] = false;
                    Console.WriteLine("Correct!");}
                else if (char.Parse(guess) == new_word[i] && hidden[i] == false) {
                    Console.WriteLine("You already guessed that.");}
                else {
                    letter_not_in += 1;
                    if (letter_not_in == new_word.Length) {
                        draw.WriteText("Wrong!"); player.wrong_guesses += 1;}
                }
            }
            }
        }
        /// <summary>
        /// Draws the according dashes or letters
        /// </summary>
        private void WriteWord()
        {
            for (i = 0; i < new_word.Length; i++) {
                if (hidden[i] == true) {Console.Write("_");}
                else {Console.Write(new_word[i].ToString());}
            }
        }
        /// <summary>
        /// Keeps track of if the game is over or not
        /// </summary>
        private void logic(){
            score = 0;
            for (i = 0; i < new_word.Length; i++)
            {
                if (hidden[i] == false) {score += 1;}
                if (score == new_word.Length) { 
                    WriteWord();
                    Console.WriteLine("");
                    draw.WriteText("You Win!!"); 
                    guess = "no";}
            }
                if (player.wrong_guesses > 5) {player.draw_jumper(); guess = "no";}
        }
    }
}