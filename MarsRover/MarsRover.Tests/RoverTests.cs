using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    [Category("endtoend")]
    public class RoverTests
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
            rover.Move("LMLMLMLMM");

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
            rover.Move("MMRMMRMRRM");

            var position = rover.Position;

            "It should be at x coordinate".AssertThat(position.X, Is.EqualTo(5));
            "It should be at y coordinate".AssertThat(position.Y, Is.EqualTo(1));
            "It should be facing north".AssertThat(position.Direction, Is.EqualTo(Direction.East));
        }
    }
    
    public enum Direction
    {
        North,
        East,
        South,
        West
    }

    public class Plateau
    {
        public Plateau(int x, int y)
        {
            
        }
    }

    public class Rover
    {
        public Rover(Position initialPosition, Plateau plateau)
        {
            
        }

        public Position Position
        {
            get { return null; }
            set {  }
        }

        public void Move(string instructions)
        {
            
        }
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
    }
}
