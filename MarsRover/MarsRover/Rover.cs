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
            else if (instructions == "L")
            {
                if (Position.Direction == Direction.North)
                    Position.Direction = Direction.West;
                else if (Position.Direction == Direction.East)
                    Position.Direction = Direction.North;
                else if (Position.Direction == Direction.South)
                    Position.Direction = Direction.East;
                else if (Position.Direction == Direction.West)
                    Position.Direction = Direction.South;
            }
            else if (instructions == "R")
            {
                if (Position.Direction == Direction.North)
                    Position.Direction = Direction.East;
                else if (Position.Direction == Direction.East)
                    Position.Direction = Direction.South;
                else if (Position.Direction == Direction.South)
                    Position.Direction = Direction.West;
                else if (Position.Direction == Direction.West)
                    Position.Direction = Direction.North;
            }
        }
    }
}