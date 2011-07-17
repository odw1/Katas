using System;

namespace MarsRover
{
    public class Plateau
    {
        private readonly int _xMin;
        private readonly int _yMin;
        private readonly int _xMax;
        private readonly int _yMax;

        public Plateau(int maxXCoordinate, int maxYCoordinate)
        {
            _xMin = 0;
            _yMin = 0;
            _xMax = maxXCoordinate;
            _yMax = maxYCoordinate;
        }

        public bool IsPositionOnPlateau(Position position)
        {
            if (position.X > _xMax || position.X < _xMin
                || position.Y > _yMax || position.Y < _yMin)
            {
                return false;
            }

            return true;
        }
    }
}