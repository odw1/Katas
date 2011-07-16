namespace MarsRover
{
    public interface IInstructionHandler
    {
        Position Handle(string instruction, Position currentPosition);
    }

    public class InstructionHandler : IInstructionHandler
    {
        public Position Handle(string instruction, Position currentPosition)
        {
            var newPosition = new Position { Direction = currentPosition.Direction, X = currentPosition.X, Y = currentPosition.Y };

            if (instruction == "M")
            {
                if (newPosition.Direction == Direction.North)
                    newPosition.Y++;
                else if (newPosition.Direction == Direction.East)
                    newPosition.X++;
                else if (newPosition.Direction == Direction.South)
                    newPosition.Y--;
                else if (newPosition.Direction == Direction.West)
                    newPosition.X--;
            }
            else if (instruction == "L")
            {
                if (newPosition.Direction == Direction.North)
                    newPosition.Direction = Direction.West;
                else if (newPosition.Direction == Direction.East)
                    newPosition.Direction = Direction.North;
                else if (newPosition.Direction == Direction.South)
                    newPosition.Direction = Direction.East;
                else if (newPosition.Direction == Direction.West)
                    newPosition.Direction = Direction.South;
            }
            else if (instruction == "R")
            {
                if (newPosition.Direction == Direction.North)
                    newPosition.Direction = Direction.East;
                else if (newPosition.Direction == Direction.East)
                    newPosition.Direction = Direction.South;
                else if (newPosition.Direction == Direction.South)
                    newPosition.Direction = Direction.West;
                else if (newPosition.Direction == Direction.West)
                    newPosition.Direction = Direction.North;
            }

            return newPosition;
        }
    }
}