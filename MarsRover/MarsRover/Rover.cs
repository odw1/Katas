using System;

namespace MarsRover
{
    public class Rover
    {
        private readonly IInstructionHandler _instructionHandler;
        private readonly Plateau _plateau;
        public Position Position { get; private set; }

        public Rover(Position initialPosition, Plateau plateau, IInstructionHandler instructionHandler)
        {
            Position = initialPosition;
            _plateau = plateau;
            _instructionHandler = instructionHandler;
        }

        public void ProcessInstructions(string instructions)
        {
            for (int i = 0; i < instructions.Length; i++ )
            {
                var instruction = instructions[i].ToString();
                var updatedPosition = _instructionHandler.Handle(instruction, Position);

                var isUpdatdPositionValid = _plateau.IsPositionOnPlateau(updatedPosition);

                if (!isUpdatdPositionValid)
                    throw new InvalidOperationException("The rover cannot move outside of the plateau");

                Position = updatedPosition;
            }
        }
    }
}