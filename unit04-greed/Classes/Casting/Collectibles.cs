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
            private int points;
        

    // 2) Create the class constructor. Use the following method comment.
        
        /// <summary>
        /// Constructs a new instance of Collectible.
        /// </summary>
        public Collectible() {
            this.points = 0;
        }       

    // 3) Create the GetMessage() method. Use the following method comment.
        
        /// <summary>
        /// Gets the Collectible's message.
        /// </summary>
        /// <returns>The points as an integer.</returns>
        public int GetPoints() {
            return points;
        }

    // 4) Create the SetMessage(string message) method. Use the following method comment.
        
        /// <summary>
        /// Sets the Collectible's message to the given value.
        /// </summary>
        /// <param name="points">The given message.</param>
        public void SetPoints(int points) {
            this.points = points;
        }
}}