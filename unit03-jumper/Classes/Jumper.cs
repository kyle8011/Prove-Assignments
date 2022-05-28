using System;

namespace unit03_jumper.Classes
{
    ///<summary>
    ///
    ///</summary>
    public class Jumper{
        TerminalService draw = new TerminalService();
        public int wrong_guesses = 0;
        /// <summary>
        /// Creates an instance of Jumper
        /// </summary>
        public Jumper() {}

        /// <summary>
        /// Draws what is left of the parachute
        /// </summary>
        public void draw_jumper()
        {
            if (wrong_guesses < 1) {draw.WriteText(@"   -----   ");}
            if (wrong_guesses < 2) {draw.WriteText(@" /       \ ");}
            if (wrong_guesses < 3) {draw.WriteText(@"  -------  ");}
            if (wrong_guesses < 4) {draw.WriteText(@"  \     /  ");}
            if (wrong_guesses < 5) {draw.WriteText(@"   \   /   ");}
            if (wrong_guesses > 5) {draw.WriteText("You Lost!");
            draw.WriteText(@"     X ");}
            else {draw.WriteText(@"     O  ");}
                  draw.WriteText(@"    /|\");
                  draw.WriteText(@"    / \");
        }
    }
}