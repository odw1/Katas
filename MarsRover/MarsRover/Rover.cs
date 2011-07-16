using System;

namespace MarsRover
{
    public class Rover
    {
        private readonly IInstructionHandler _instructionHandler;
        public Plateau Plateau { get; private set; }
        public Position Position { get; private set; }

        public Rover(Position initialPosition, Plateau plateau, IInstructionHandler instructionHandler)
        {
            _instructionHandler = instructionHandler;
            Position = initialPosition;
            Plateau = plateau;
        }

        public void ProcessInstructions(string instructions)
        {
            for (int i = 0; i < instructions.Length; i++ )
            {
                var instruction = instructions[i].ToString();
                var updatedPosition = _instructionHandler.Handle(instruction, Position);
                Position = updatedPosition;
            }
        }
    }
}