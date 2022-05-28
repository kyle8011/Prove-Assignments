using System;
using System.Collections.Generic;

namespace unit03_jumper.Classes
{
    /// <summary>
    /// 
    /// </summary>
    public class GamePlay
    {
        string still_playing = "y";
        public bool letter_in_word = false;
        public string guess;
        public string new_word;
        private int i;
        private int letter_not_in;
        private int score;
        private List<char> letters = new List<char>();
        private List<bool> hidden = new List<bool>();

        ChooseWord word = new ChooseWord();
        Jumper player = new Jumper();
        TerminalService draw = new TerminalService();

        /// <summary>
        ///
        /// </summary>
        public GamePlay() {}

        /// <summary>
        ///
        /// </summary>
        public void StartGame()
        {
            new_word = word.choose_word();
            new_word.ToCharArray();
            foreach (char letter in new_word) {hidden.Add(true);}
            //foreach(char letter in new_word){Console.WriteLine(letter);}
            
            while (guess != "no")
            {
                player.draw_jumper();
                WriteWord();
                Guess();
                logic();
            }
        }

        /// <summary>
        ///
        /// </summary>
        public void Guess()
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
        public void WriteWord()
        {
            for (i = 0; i < new_word.Length; i++) {
                if (hidden[i] == true) {Console.Write("_");}
                else {Console.Write(new_word[i].ToString());}
            }
        }

        public void logic(){
            score = 0;
            for (i = 0; i < new_word.Length; i++)
            {
                if (hidden[i] == false) {score += 1;}
                if (score == new_word.Length) { 
                draw.WriteText("You Win!!"); 
                guess = "no";}
            }
                if (player.wrong_guesses > 5) {player.draw_jumper(); guess = "no";}
        }

    }
}