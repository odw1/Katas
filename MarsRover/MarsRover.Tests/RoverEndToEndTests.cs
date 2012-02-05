using NUnit.Framework;

namespace MarsRover.Tests
{
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
            var initialPosition = new Position(1, 2, Direction.North);
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
            var initialPosition = new Position(3, 3, Direction.East);
            var rover = new Rover(initialPosition, plateau, new InstructionHandler());
            rover.ProcessInstructions("MMRMMRMRRM");

            var position = rover.Position;

            "It should be at x coordinate".AssertThat(position.X, Is.EqualTo(5));
            "It should be at y coordinate".AssertThat(position.Y, Is.EqualTo(1));
            "It should be facing north".AssertThat(position.Direction, Is.EqualTo(Direction.East));
        }
    }
}