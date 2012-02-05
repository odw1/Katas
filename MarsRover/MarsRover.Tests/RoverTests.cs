using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverTests
    {
        private Plateau _plateau;
        private IInstructionHandler _instructionHandler;

        [SetUp]
        public void SetUp()
        {
            _plateau = new Plateau(5, 5);
            _instructionHandler = MockRepository.GenerateMock<IInstructionHandler>();            
        }

        [Test]
        public void when_the_rover_is_created()
        {
            var initialPosition = new Position(1, 2, Direction.North);
            var rover = new Rover(initialPosition, _plateau, _instructionHandler);

            "It should set the position".AssertThat(rover.Position, Is.EqualTo(initialPosition));
        }

        [Test]
        public void when_processing_instructions()
        {
            var initialPosition = new Position(1, 2, Direction.North);
            var updatedPosition = new Position(4, 4, Direction.South);

            _instructionHandler.Stub(x => x.Handle("L", initialPosition)).Return(updatedPosition);

            var rover = new Rover(initialPosition, _plateau, _instructionHandler);

            rover.ProcessInstructions("L");

            "It should update the rovers position".AssertThat(rover.Position, Is.EqualTo(updatedPosition));
        }

        [Test]
        public void when_processing_multiple_instructions()
        {
            var initialPosition = new Position(1, 2, Direction.North);
            var position = new Position(1, 2, Direction.North);

            _instructionHandler.Stub(x => x.Handle(null, null)).IgnoreArguments().Repeat.Times(3).Return(position);

            var rover = new Rover(initialPosition, _plateau, _instructionHandler);

            rover.ProcessInstructions("LMR");

            "It should ask the handler to turn the rover left".AssertWasCalled(_instructionHandler, x => x.Handle("L", initialPosition));
            "It should ask the handler to move the rover fowards".AssertWasCalled(_instructionHandler, x => x.Handle("M", position));
            "It should ask the handler to turn the rover right".AssertWasCalled(_instructionHandler, x => x.Handle("R", position));
        }

        [Test]
        public void when_updated_position_is_outside_the_plateau()
        {
            var initialPosition = new Position(1, 2, Direction.North);
            var updatedPosition = new Position(10, 20, Direction.South);

            _instructionHandler.Stub(x => x.Handle("L", initialPosition)).Return(updatedPosition);

            var rover = new Rover(initialPosition, _plateau, _instructionHandler);

            "It should throw an exception".AssertThrows<InvalidOperationException>(() => rover.ProcessInstructions("L"));
        }
    }
}
