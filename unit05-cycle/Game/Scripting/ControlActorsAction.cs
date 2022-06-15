using unit05_cycle.Game.Casting;
using unit05_cycle.Game.Services;


namespace unit05_cycle.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the snake.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the snake's head.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Action
    {
        private KeyboardService keyboardService;
        private Point direction1 = new Point(Constants.CELL_SIZE, 0);
        private Point direction2 = new Point(Constants.CELL_SIZE, 0);
        private bool initial = true;
        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            while (initial == true)
            {
                direction1 = new Point(0, -Constants.CELL_SIZE);
                direction2 = new Point(0, -Constants.CELL_SIZE);
                initial = false;
            }
            Time time = (Time)cast.GetFirstActor("time");
            time.AddTime(cast);
            // left
            if (keyboardService.IsKeyDown("a"))
            {   
                if (direction1.GetX() != Constants.CELL_SIZE){
                direction1 = new Point(-Constants.CELL_SIZE, 0);}
            }
            if (keyboardService.IsKeyDown("j"))
            {
                if (direction2.GetX() != Constants.CELL_SIZE){
                direction2 = new Point(-Constants.CELL_SIZE, 0);}
            }

            // right
            if (keyboardService.IsKeyDown("d"))
            {
                if (direction1.GetX() != -Constants.CELL_SIZE){
                direction1 = new Point(Constants.CELL_SIZE, 0);}
            }
            if (keyboardService.IsKeyDown("l"))
            {
                if (direction2.GetX() != -Constants.CELL_SIZE){
                direction2 = new Point(Constants.CELL_SIZE, 0);}
            }

            // up
            if (keyboardService.IsKeyDown("w"))
            {
                if (direction1.GetY() != Constants.CELL_SIZE){
                direction1 = new Point(0, -Constants.CELL_SIZE);}
            }
            if (keyboardService.IsKeyDown("i"))
            {
                if (direction2.GetY() != Constants.CELL_SIZE){
                direction2 = new Point(0, -Constants.CELL_SIZE);}
            }

            // down
            if (keyboardService.IsKeyDown("s"))
            {
                if (direction1.GetY() != -Constants.CELL_SIZE){
                direction1 = new Point(0, Constants.CELL_SIZE);}
            }
            if (keyboardService.IsKeyDown("k"))
            {
                if (direction2.GetY() != -Constants.CELL_SIZE){
                direction2 = new Point(0, Constants.CELL_SIZE);}
            }

            Snake snake1 = (Snake)cast.GetFirstActor("snake");
            snake1.TurnHead(direction1);
            Snake snake2 = (Snake)cast.GetSecondActor("snake");
            snake2.TurnHead(direction2);

        }
    }
}