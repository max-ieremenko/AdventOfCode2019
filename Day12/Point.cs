using System;

namespace Day12
{
    internal readonly struct Point : IEquatable<Point>
    {
        public Point(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int X { get; }

        public int Y { get; }

        public int Z { get; }

        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public override bool Equals(object obj) => throw new NotSupportedException();

        public override int GetHashCode() => (int)(X * Y * Z);

        public override string ToString() => string.Format("{0};{1};{2}", X, Y, Z);
    }
}