using System;
namespace Unit04_greed.Classes.Casting
{
    
    // TODO: Implement the Collectible class here

    // 1) Add the class declaration. Use the following class comment. Make sure you
    //    inherit from the Actor class.

        /// <summary>
        /// <para>An item of cultural or historical interest.</para>
        /// <para>
        /// The responsibility of an Collectible is to provide a message about itself.
        /// </para>
        /// </summary>
        public class Collectible : Actor
        {
            private int value;
            private int new_value;
        
            Random random = new Random();
    // 2) Create the class constructor. Use the following method comment.
        
        /// <summary>
        /// Constructs a new instance of Collectible.
        /// </summary>
        public Collectible() {
            new_value = random.Next(-3, 4);
            if (new_value == 0) {new_value = -1;}
            this.value = new_value;
        }       

    // 3) Create the GetMessage() method. Use the following method comment.
        
        /// <summary>
        /// Gets the Collectible's message.
        /// </summary>
        /// <returns>The points as an integer.</returns>
        public int GetValue() {
            return value;
        }

    // 4) Create the SetMessage(string message) method. Use the following method comment.
        
        /// <summary>
        /// Sets the Collectible's message to the given value.
        /// </summary>
        /// <param name="points">The given message.</param>
        public void SetValue(int value) {
            this.value = value;
        }
}}