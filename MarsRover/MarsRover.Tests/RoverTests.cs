using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverTests
    {
        private Plateau _plateau = new Plateau(5, 5);

        [Test]
        public void when_the_rover_is_created()
        {
            var initialPosition = new Position { X = 1, Y = 2, Direction = Direction.North };
            var rover = new Rover(initialPosition, _plateau);

            "It should set the plateau".AssertThat(rover.Plateau, Is.EqualTo(_plateau));
            "It should set the position".AssertThat(rover.Position, Is.EqualTo(initialPosition));
        }

        [Test]
        public void when_the_rover_moves_when_facing_north()
        {
            var initialPosition = new Position { X = 1, Y = 2, Direction = Direction.North };
            var rover = new Rover(initialPosition, _plateau);

            rover.ProcessInstructions("M");

            "It should increment the Y coordinate".AssertThat(rover.Position.Y, Is.EqualTo(3));
            "It should NOT change the X coordinate".AssertThat(rover.Position.X, Is.EqualTo(1));
            "It should be facing north".AssertThat(rover.Position.Direction, Is.EqualTo(Direction.North));
        }

        [Test]
        public void when_the_rover_moves_when_facing_east()
        {
            var initialPosition = new Position { X = 1, Y = 2, Direction = Direction.East };
            var rover = new Rover(initialPosition, _plateau);

            rover.ProcessInstructions("M");

            "It should NOT change the Y coordinate".AssertThat(rover.Position.Y, Is.EqualTo(2));
            "It should increment the X coordinate".AssertThat(rover.Position.X, Is.EqualTo(2));
            "It should be facing north".AssertThat(rover.Position.Direction, Is.EqualTo(Direction.East));
        }

        [Test]
        public void when_the_rover_moves_when_facing_south()
        {
            var initialPosition = new Position { X = 1, Y = 2, Direction = Direction.South };
            var rover = new Rover(initialPosition, _plateau);

            rover.ProcessInstructions("M");

            "It should decrement the Y coordinate".AssertThat(rover.Position.Y, Is.EqualTo(1));
            "It should NOT change the X coordinate".AssertThat(rover.Position.X, Is.EqualTo(1));
            "It should be facing north".AssertThat(rover.Position.Direction, Is.EqualTo(Direction.South));
        }

        [Test]
        public void when_the_rover_moves_when_facing_west()
        {
            var initialPosition = new Position { X = 1, Y = 2, Direction = Direction.West };
            var rover = new Rover(initialPosition, _plateau);

            rover.ProcessInstructions("M");

            "It should NOT change the Y coordinate".AssertThat(rover.Position.Y, Is.EqualTo(2));
            "It should decrement the X coordinate".AssertThat(rover.Position.X, Is.EqualTo(0));
            "It should be facing north".AssertThat(rover.Position.Direction, Is.EqualTo(Direction.West));
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
            var rover = new Rover(initialPosition, plateau);
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
            var rover = new Rover(initialPosition, plateau);
            rover.ProcessInstructions("MMRMMRMRRM");

            var position = rover.Position;

            "It should be at x coordinate".AssertThat(position.X, Is.EqualTo(5));
            "It should be at y coordinate".AssertThat(position.Y, Is.EqualTo(1));
            "It should be facing north".AssertThat(position.Direction, Is.EqualTo(Direction.East));
        }
    }
}
