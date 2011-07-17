using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class PlateauTests
    {
        [Test]
        public void when_validation_a_position()
        {
            var plateau = new Plateau(5, 5);
            var position = new Position(2, 2, Direction.North);

            var isValidPosition = plateau.IsPositionOnPlateau(position);

            "It should successfully validate the position".AssertThat(isValidPosition, Is.True);
        }

        [Test]
        public void when_validation_a_position_and_the_X_coordinate_is_to_low()
        {
            var plateau = new Plateau(5, 5);
            var position = new Position(-1, 2, Direction.North);

            var isValidPosition = plateau.IsPositionOnPlateau(position);

            "It should NOT successfullt validate the position".AssertThat(isValidPosition, Is.False);
        }

        [Test]
        public void when_validation_a_position_and_the_X_coordinate_is_to_high()
        {
            var plateau = new Plateau(5, 5);
            var position = new Position(12, 2, Direction.North);

            var isValidPosition = plateau.IsPositionOnPlateau(position);

            "It should NOT successfullt validate the position".AssertThat(isValidPosition, Is.False);
        }

        [Test]
        public void when_validation_a_position_and_the_Y_coordinate_is_to_low()
        {
            var plateau = new Plateau(5, 5);
            var position = new Position(2, -2, Direction.North);

            var isValidPosition = plateau.IsPositionOnPlateau(position);

            "It should NOT successfullt validate the position".AssertThat(isValidPosition, Is.False);
        }

        [Test]
        public void when_validation_a_position_and_the_Y_coordinate_is_to_high()
        {
            var plateau = new Plateau(5, 5);
            var position = new Position(2, 22, Direction.North);

            var isValidPosition = plateau.IsPositionOnPlateau(position);

            "It should NOT successfullt validate the position".AssertThat(isValidPosition, Is.False);
        }
    }
}
