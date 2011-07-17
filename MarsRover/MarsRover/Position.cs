namespace MarsRover
{
    public class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Direction Direction { get; private set; }

        public Position(int xCoordinate, int yCoordinate, Direction direction)
        {
            X = xCoordinate;
            Y = yCoordinate;
            Direction = direction;
        }
    }
}