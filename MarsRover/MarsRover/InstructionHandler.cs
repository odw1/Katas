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
                direction = direction.TurnLeft();
            }
            else if (instruction == "R")
            {
                direction = direction.TurnRight();
            }
            else
            {
                throw new ArgumentException( "Invalid instruction", "instruction");
            }

            return new Position(xCoordinate, yCoordinate, direction);
        }
    }
}