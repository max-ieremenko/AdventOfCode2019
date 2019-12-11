using System;

namespace Day11
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

        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj) => throw new NotSupportedException();

        public override int GetHashCode() => X * Y;

        public override string ToString() => string.Format("{0};{1}", X, Y);
    }
}