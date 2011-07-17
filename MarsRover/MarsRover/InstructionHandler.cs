using System;

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
            var xCoordinate = currentPosition.X;
            var yCoordinate = currentPosition.Y;
            var direction = currentPosition.Direction;

            if (instruction == "M")
            {
                if (direction == Direction.North)
                    yCoordinate++;
                else if (direction == Direction.East)
                    xCoordinate++;
                else if (direction == Direction.South)
                    yCoordinate--;
                else if (direction == Direction.West)
                    xCoordinate--;
            }
            else if (instruction == "L")
            {
                if (direction == Direction.North)
                    direction = Direction.West;
                else if (direction == Direction.East)
                    direction = Direction.North;
                else if (direction == Direction.South)
                    direction = Direction.East;
                else if (direction == Direction.West)
                    direction = Direction.South;
            }
            else if (instruction == "R")
            {
                if (direction == Direction.North)
                    direction = Direction.East;
                else if (direction == Direction.East)
                    direction = Direction.South;
                else if (direction == Direction.South)
                    direction = Direction.West;
                else if (direction == Direction.West)
                    direction = Direction.North;
            }
            else
            {
                throw new ArgumentException( "Invalid instruction", "instruction");
            }

            return new Position(xCoordinate, yCoordinate, direction);
        }
    }
}