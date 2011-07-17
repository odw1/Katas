using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class DirectionTests
    {
        [Test]
        public void when_facing_north_and_turning_left()
        {
            var newDirection = Direction.North.TurnLeft();

            "The new direction should be west".AssertThat(newDirection, Is.EqualTo(Direction.West));
        }

        [Test]
        public void when_facing_north_and_turning_right()
        {
            var newDirection = Direction.North.TurnRight();

            "The new direction should be east".AssertThat(newDirection, Is.EqualTo(Direction.East));
        }

        [Test]
        public void when_facing_east_and_turning_left()
        {
            var newDirection = Direction.East.TurnLeft();

            "The new direction should be north".AssertThat(newDirection, Is.EqualTo(Direction.North));
        }

        [Test]
        public void when_facing_east_and_turning_right()
        {
            var newDirection = Direction.East.TurnRight();

            "The new direction should be south".AssertThat(newDirection, Is.EqualTo(Direction.South));
        }

        [Test]
        public void when_facing_south_and_turning_left()
        {
            var newDirection = Direction.South.TurnLeft();

            "The new direction should be east".AssertThat(newDirection, Is.EqualTo(Direction.East));
        }

        [Test]
        public void when_facing_south_and_turning_right()
        {
            var newDirection = Direction.South.TurnRight();

            "The new direction should be west".AssertThat(newDirection, Is.EqualTo(Direction.West));
        }

        [Test]
        public void when_facing_west_and_turning_left()
        {
            var newDirection = Direction.West.TurnLeft();

            "The new direction should be south".AssertThat(newDirection, Is.EqualTo(Direction.South));
        }

        [Test]
        public void when_facing_west_and_turning_right()
        {
            var newDirection = Direction.West.TurnRight();

            "The new direction should be north".AssertThat(newDirection, Is.EqualTo(Direction.North));
        }
    }
}
