using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class InstructionHandlerTests
    {
        private InstructionHandler _instructionHandler;

        [SetUp]
        public void SetUp()
        {
            _instructionHandler = new InstructionHandler();
        }

        [Test]
        public void when_the_rover_moves_when_facing_north()
        {
            var initialPosition = new Position { X = 1, Y = 2, Direction = Direction.North };

            var updatedPosition = _instructionHandler.Handle("M", initialPosition);

            "It should increment the Y coordinate".AssertThat(updatedPosition.Y, Is.EqualTo(3));
            "It should NOT change the X coordinate".AssertThat(updatedPosition.X, Is.EqualTo(1));
            "It should be facing north".AssertThat(updatedPosition.Direction, Is.EqualTo(Direction.North));
        }

        [Test]
        public void when_the_rover_moves_when_facing_east()
        {
            var initialPosition = new Position { X = 1, Y = 2, Direction = Direction.East };

            var updatedPosition = _instructionHandler.Handle("M", initialPosition);

            "It should NOT change the Y coordinate".AssertThat(updatedPosition.Y, Is.EqualTo(2));
            "It should increment the X coordinate".AssertThat(updatedPosition.X, Is.EqualTo(2));
            "It should be facing north".AssertThat(updatedPosition.Direction, Is.EqualTo(Direction.East));
        }

        [Test]
        public void when_the_rover_moves_when_facing_south()
        {
            var initialPosition = new Position { X = 1, Y = 2, Direction = Direction.South };

            var updatedPosition = _instructionHandler.Handle("M", initialPosition);

            "It should decrement the Y coordinate".AssertThat(updatedPosition.Y, Is.EqualTo(1));
            "It should NOT change the X coordinate".AssertThat(updatedPosition.X, Is.EqualTo(1));
            "It should be facing north".AssertThat(updatedPosition.Direction, Is.EqualTo(Direction.South));
        }

        [Test]
        public void when_the_rover_moves_when_facing_west()
        {
            var initialPosition = new Position { X = 1, Y = 2, Direction = Direction.West };

            var updatedPosition = _instructionHandler.Handle("M", initialPosition);

            "It should NOT change the Y coordinate".AssertThat(updatedPosition.Y, Is.EqualTo(2));
            "It should decrement the X coordinate".AssertThat(updatedPosition.X, Is.EqualTo(0));
            "It should be facing north".AssertThat(updatedPosition.Direction, Is.EqualTo(Direction.West));
        }

        [Test]
        public void when_the_rover_turns_left_when_facing_north()
        {
            var initialPosition = new Position { X = 1, Y = 2, Direction = Direction.North };

            var updatedPosition = _instructionHandler.Handle("L", initialPosition);

            "It should be facing west".AssertThat(updatedPosition.Direction, Is.EqualTo(Direction.West));
        }

        [Test]
        public void when_the_rover_turns_left_when_facing_east()
        {
            var initialPosition = new Position { X = 1, Y = 2, Direction = Direction.East };

            var updatedPosition = _instructionHandler.Handle("L", initialPosition);

            "It should be facing north".AssertThat(updatedPosition.Direction, Is.EqualTo(Direction.North));
        }

        [Test]
        public void when_the_rover_turns_left_when_facing_south()
        {
            var initialPosition = new Position { X = 1, Y = 2, Direction = Direction.South };

            var updatedPosition = _instructionHandler.Handle("L", initialPosition);

            "It should be facing east".AssertThat(updatedPosition.Direction, Is.EqualTo(Direction.East));
        }

        [Test]
        public void when_the_rover_turns_left_when_facing_west()
        {
            var initialPosition = new Position { X = 1, Y = 2, Direction = Direction.West };

            var updatedPosition = _instructionHandler.Handle("L", initialPosition);

            "It should be facing south".AssertThat(updatedPosition.Direction, Is.EqualTo(Direction.South));
        }

        [Test]
        public void when_the_rover_turns_right_when_facing_north()
        {
            var initialPosition = new Position { X = 1, Y = 2, Direction = Direction.North };

            var updatedPosition = _instructionHandler.Handle("R", initialPosition);

            "It should be facing east".AssertThat(updatedPosition.Direction, Is.EqualTo(Direction.East));
        }

        [Test]
        public void when_the_rover_turns_right_when_facing_east()
        {
            var initialPosition = new Position { X = 1, Y = 2, Direction = Direction.East };

            var updatedPosition = _instructionHandler.Handle("R", initialPosition);

            "It should be facing south".AssertThat(updatedPosition.Direction, Is.EqualTo(Direction.South));
        }

        [Test]
        public void when_the_rover_turns_right_when_facing_south()
        {
            var initialPosition = new Position { X = 1, Y = 2, Direction = Direction.South };

            var updatedPosition = _instructionHandler.Handle("R", initialPosition);

            "It should be facing west".AssertThat(updatedPosition.Direction, Is.EqualTo(Direction.West));
        }

        [Test]
        public void when_the_rover_turns_right_when_facing_west()
        {
            var initialPosition = new Position { X = 1, Y = 2, Direction = Direction.West };

            var updatedPosition = _instructionHandler.Handle("R", initialPosition);

            "It should be facing north".AssertThat(updatedPosition.Direction, Is.EqualTo(Direction.North));
        }
    }
}
