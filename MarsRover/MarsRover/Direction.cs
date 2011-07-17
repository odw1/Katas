using System;

namespace MarsRover
{
    public class Direction
    {
        public static readonly Direction North;

        public static readonly Direction East;

        public static readonly Direction South;

        public static readonly Direction West;

        private readonly Func<Direction> _leftTurner;
        private readonly Func<Direction> _rightTurner; 


        public Direction TurnLeft()
        {
            return _leftTurner();
        }

        public Direction TurnRight()
        {
            return _rightTurner();
        }

        private Direction(Func<Direction> leftTurner, Func<Direction> rightTurner)
        {
            _leftTurner = leftTurner;
            _rightTurner = rightTurner;
        }

        static Direction()
        {
            North = new Direction(() => West, () => East);
            East = new Direction(() => North, () => South);
            South = new Direction(() => East, () => West);
            West = new Direction(() => South, () => North);
        }
    }
}