using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MarsRover.Specs
{
    [Binding]
    public class RoverSteps
    {
        private Rover _rover;

        [Given(@"The Rover is on coordinates (\d+),(\d+) facing (.*)")]
        public void GivenTheRoverIsInStartPosition(int x, int y, string facing)
        {
            var direction = GetDirection(facing);

            var plateau = new Plateau(5, 5);
            var initialPosition = new Position(x, y, direction);
            _rover = new Rover(initialPosition, plateau, new InstructionHandler());

            Assert.That(_rover.Position.X, Is.EqualTo(x));
            Assert.That(_rover.Position.Y, Is.EqualTo(y));
            Assert.That(_rover.Position.Direction, Is.EqualTo(direction));
        }

        [When("I send the Rover a turn (.*) instruction")]
        public void WhenISendTheRoverAnInstruction(string direction)
        {
            var instruction = string.Empty;

            if (direction.Equals("left"))
            {
                instruction = "L";
            }
            else if (direction.Equals("right"))
            {
                instruction = "R";
            }

            _rover.ProcessInstructions(instruction);
        }

        [Then("The Rover should be facing (.*)")]
        public void TheRoverShouldBeFacing(string facing)
        {
            var direction = GetDirection(facing);

            Assert.That(_rover.Position.X, Is.EqualTo(1));
            Assert.That(_rover.Position.Y, Is.EqualTo(2));
            Assert.That(_rover.Position.Direction, Is.EqualTo(direction));
        }

        [When(@"I send the Rover a series of instructions (.*)")]
        public void WhenISendTheRoverASeriesOfInstructions(string instructions)
        {
            _rover.ProcessInstructions(instructions);
        }

        [Then(@"The Rover should be at x coordinate (\d+), y coordinate (\d+) and facing (.*)")]
        public void ThenTheRoverShouldBeAtXCoordinateDYCoordinateDAndFacing(int x, int y, string facing)
        {
            var direction = GetDirection(facing);

            Assert.That(_rover.Position.X, Is.EqualTo(x));
            Assert.That(_rover.Position.Y, Is.EqualTo(y));
            Assert.That(_rover.Position.Direction, Is.EqualTo(direction));
        }

        private static Direction GetDirection(string facing)
        {
            Direction direction = null;

            if (facing == "west")
            {
                direction = Direction.West;
            }
            else if (facing == "east")
            {
                direction = Direction.East;
            }
            else if (facing == "north")
            {
                direction = Direction.North;
            }
            else if (facing == "south")
            {
                direction = Direction.South;
            }

            return direction;
        }
    }
}