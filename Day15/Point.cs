using System;

namespace Day15
{
    internal readonly struct Point : IEquatable<Point>
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public static Point operator +(Point location, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return new Point(location.X, location.Y - 1);
                
                case Direction.Right:
                    return new Point(location.X + 1, location.Y);
                
                case Direction.Down:
                    return new Point(location.X, location.Y + 1);
                
                case Direction.Left:
                    return new Point(location.X - 1, location.Y);

                default:
                    throw new InvalidOperationException();
            }
        }

        public static bool operator ==(Point x, Point y) => x.Equals(y);

        public static bool operator !=(Point x, Point y) => !x.Equals(y);

        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj) => throw new NotSupportedException();

        public override int GetHashCode() => X * Y;

        public override string ToString() => string.Format("{0};{1}", X, Y);
    }
}