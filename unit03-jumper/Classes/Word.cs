using System;
using System.Collections.Generic;

namespace unit03_jumper.Classes{
    /// <summary>
    /// A class that chooses a word to work with and checks if a letter is correct
    /// </summary>
    public class ChooseWord
    {
        public List<string> words = new List<string>();
        
        private int word_index;
        /// <summary>
        /// Creates an instance of ChooseWord
        /// </summary>
        public ChooseWord() {}

        /// <summary>
        /// Chooses a word to guess
        /// </summary>
        public string choose_word()
        {
            words.Add("apple");
            words.Add("pear");
            words.Add("banana");
            words.Add("koala");
            words.Add("bear");
            words.Add("dog");
            words.Add("kite");
            words.Add("math");
            words.Add("book");
            words.Add("chemical");
            words.Add("princess");
            words.Add("omega");
            words.Add("delta");
            words.Add("swan");
            words.Add("alpha");
            words.Add("microwave");
            words.Add("proclamation");

            
            Random random = new Random();
            word_index = random.Next(10);
            //word = words[word_index];
            //Console.WriteLine(words[word_index]);
            return words[word_index];
        }
    }
}