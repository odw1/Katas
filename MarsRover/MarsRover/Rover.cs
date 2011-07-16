namespace MarsRover
{
    public class Rover
    {
        public Plateau Plateau { get; private set; }
        public Position Position { get; private set; }

        public Rover(Position initialPosition, Plateau plateau)
        {
            Position = initialPosition;
            Plateau = plateau;
        }

        public void ProcessInstructions(string instructions)
        {
            if (instructions == "M")
            {
                if (Position.Direction == Direction.North)
                    Position.Y++;
                else if (Position.Direction == Direction.East)
                    Position.X++;
                else if (Position.Direction == Direction.South)
                    Position.Y--;
                else if (Position.Direction == Direction.West)
                    Position.X--;
            }
        }
    }
}