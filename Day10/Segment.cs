using System;

namespace Day10
{
    internal readonly struct Segment
    {
        public Segment(Point a, Point b)
        {
            A = a;
            B = b;
        }

        public Point A { get; }
        
        public Point B { get; }

        public bool TryIntersectWith(Segment other, out Point intersection)
        {
            intersection = default;

            var dx1 = B.X - A.X;
            var dy1 = B.Y - A.Y;
            var dx2 = other.B.X - other.A.X;
            var dy3 = other.B.Y - other.A.Y;

            float denominator = (dy1 * dx2) - (dx1 * dy3);

            var t1 = ((A.X - other.A.X) * dy3 + (other.A.Y - A.Y) * dx2) / denominator;
            if (float.IsInfinity(t1))
            {
                return false;
            }

            var t2 = ((other.A.X - A.X) * dy1 + (A.Y - other.A.Y) * dx1) / -denominator;

            var intersect = ((t1 >= 0) && (t1 <= 1) && (t2 >= 0) && (t2 <= 1));
            if (!intersect)
            {
                return false;
            }

            var x = A.X + dx1 * t1;
            var y = A.Y + dy1 * t1;
            intersection = new Point((int) x, (int) y);
            
            return Math.Abs(intersection.X - x) <= float.Epsilon
                   && Math.Abs(intersection.Y - y) <= float.Epsilon;
        }

        public override string ToString() => string.Format("{0} - {1}", A, B);
    }
}