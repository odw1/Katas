using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var initialPosition = new Position { X = 1, Y = 2, Direction = Direction.North };
            var rover = new Rover(initialPosition, _plateau, _instructionHandler);

            "It should set the plateau".AssertThat(rover.Plateau, Is.EqualTo(_plateau));
            "It should set the position".AssertThat(rover.Position, Is.EqualTo(initialPosition));
        }

        [Test]
        public void when_processing_instructions()
        {
            var initialPosition = new Position { X = 1, Y = 2, Direction = Direction.North };
            var updatedPosition = new Position { X = 10, Y = 20, Direction = Direction.South };

            _instructionHandler.Stub(x => x.Handle("L", initialPosition)).Return(updatedPosition);

            var rover = new Rover(initialPosition, _plateau, _instructionHandler);

            rover.ProcessInstructions("L");

            "It should update the rovers position".AssertThat(rover.Position, Is.EqualTo(updatedPosition));
        }

        [Test]
        public void when_processing_multiple_instructions()
        {
            var initialPosition = new Position { X = 1, Y = 2, Direction = Direction.North };
            var position = new Position { X = 1, Y = 2, Direction = Direction.North };

            _instructionHandler.Stub(x => x.Handle(null, null)).IgnoreArguments().Repeat.Times(3).Return(position);

            var rover = new Rover(initialPosition, _plateau, _instructionHandler);

            rover.ProcessInstructions("LMR");

            "It should ask the handler to turn the rover left".AssertWasCalled(_instructionHandler, x => x.Handle("L", initialPosition));
            "It should ask the handler to move the rover fowards".AssertWasCalled(_instructionHandler, x => x.Handle("M", position));
            "It should ask the handler to turn the rover right".AssertWasCalled(_instructionHandler, x => x.Handle("R", position));
        }
    }

    [TestFixture]
    [Category("endtoend")]
    public class RoverEndToEndTests
    {
        //Test Input:
        //5 5
        //1 2 N
        //LMLMLMLMM
        //3 3 E
        //MMRMMRMRRM

        //Expected Output:
        //1 3 N
        //5 1 E

        [Test]
        public void when_moving_the_first_rover()
        {
            var plateau = new Plateau(5, 5);
            var initialPosition = new Position {X = 1, Y = 2, Direction = Direction.North};
            var rover = new Rover(initialPosition, plateau, new InstructionHandler());
            rover.ProcessInstructions("LMLMLMLMM");

            var position = rover.Position;

            "It should be at x coordinate".AssertThat(position.X, Is.EqualTo(1));
            "It should be at y coordinate".AssertThat(position.Y, Is.EqualTo(3));
            "It should be facing north".AssertThat(position.Direction, Is.EqualTo(Direction.North));
        }

        [Test]
        public void when_moving_the_second_rover()
        {
            var plateau = new Plateau(5, 5);
            var initialPosition = new Position { X = 3, Y = 3, Direction = Direction.East };
            var rover = new Rover(initialPosition, plateau, new InstructionHandler());
            rover.ProcessInstructions("MMRMMRMRRM");

            var position = rover.Position;

            "It should be at x coordinate".AssertThat(position.X, Is.EqualTo(5));
            "It should be at y coordinate".AssertThat(position.Y, Is.EqualTo(1));
            "It should be facing north".AssertThat(position.Direction, Is.EqualTo(Direction.East));
        }
    }
}
