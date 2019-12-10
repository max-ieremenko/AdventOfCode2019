using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day10
{
    internal sealed class Map
    {
        public Point LeftTop { get; }

        public Point RightDown { get; private set; }

        public ICollection<Point> Asteroids { get; } = new HashSet<Point>();

        public static Map Parse(IEnumerable<string> lines)
        {
            var map = new Map();

            var y = 0;
            var maxX = 0;
            foreach (var line in lines)
            {
                maxX = line.Length - 1;
                for (var x = 0; x < line.Length; x++)
                {
                    switch (line[x])
                    {
                        case '.':
                            break;

                        case '#':
                        case 'X':
                            map.Asteroids.Add(new Point(x, y));
                            break;

                        default:
                            throw new NotSupportedException();
                    }
                }

                y++;
            }

            map.RightDown = new Point(maxX, y - 1);
            return map;
        }

        public static double CalculateClockwiseAngle(Point center, Point target)
        {
            var x = target.X - center.X;
            var y = center.Y - target.Y;

            var offset = 0;
            if (x < 0) // III or IV
            {
                offset = 180;

                x = -x;
                y = -y;
            }

            var radians = Math.Atan2(x, y);
            var result = radians * (180 / Math.PI);
            return result + offset;
        }

        public ICollection<Point> FindAsteroidsOnDirectLineOfSightWith(Point asteroid)
        {
            var targets = new HashSet<Point>();

            foreach (var b in Asteroids)
            {
                if (!asteroid.Equals(b) && AreOnDirectLineOfSight(asteroid, b))
                {
                    targets.Add(b);
                }
            }

            return targets;
        }

        public string ToString(Point asteroid, ICollection<Point> targets)
        {
            var orderedTargets = targets.OrderBy(i => CalculateClockwiseAngle(asteroid, i)).ToList();

            var text = new StringBuilder();
            for (var y = LeftTop.Y; y <= RightDown.Y; y++)
            {
                for (var x = LeftTop.X; x <= RightDown.X; x++)
                {
                    var a = new Point(x, y);
                    if (asteroid.Equals(a))
                    {
                        text.Append("X");
                        continue;
                    }

                    var index = orderedTargets.IndexOf(a);
                    if (index >= 0)
                    {
                        text.AppendFormat("'{0}'", index + 1);
                        continue;
                    }
                    
                    if (Asteroids.Contains(a))
                    {
                        text.Append("#");
                        continue;
                    }

                    text.Append(".");
                }

                text.AppendLine();
            }

            return text.ToString();
        }

        private bool AreOnDirectLineOfSight(Point a, Point b)
        {
            if (Math.Abs(a.X - b.X) == 1 || Math.Abs(a.Y - b.Y) == 1)
            {
                return true;
            }

            IEnumerable<Point> testList;
            if (a.X == b.X)
            {
                testList = GetBetweenOnVerticalSegment(a.X, a.Y, b.Y);
            }
            else if (a.Y == b.Y)
            {
                testList = GetBetweenOnHorizontalSegment(a.X, b.X, a.Y);
            }
            else
            {
                testList = GetBetweenOnSquare(a, b);
            }

            return !testList.Any(Asteroids.Contains);
        }

        private static IEnumerable<Point> GetBetweenOnVerticalSegment(int x, int y1, int y2)
        {
            var minY = Math.Min(y1, y2);
            var maxY = Math.Max(y1, y2);

            for (var y = minY + 1; y < maxY; y++)
            {
                yield return new Point(x, y);
            }
        }

        private static IEnumerable<Point> GetBetweenOnHorizontalSegment(int x1, int x2, int y)
        {
            var minX = Math.Min(x1, x2);
            var maxX = Math.Max(x1, x2);

            for (var x = minX + 1; x < maxX; x++)
            {
                yield return new Point(x, y);
            }
        }

        private static IEnumerable<Point> GetBetweenOnSquare(Point a, Point b)
        {
            var width = Math.Abs(a.X - b.X);
            var height = Math.Abs(a.Y - b.Y);

            var segment = new Segment(a, b);

            if (width < height)
            {
                var minX = Math.Min(a.X, b.X);
                var maxX = Math.Max(a.X, b.X);

                for (var x = minX + 1; x < maxX; x++)
                {
                    var test = new Segment(new Point(x, a.Y), new Point(x, b.Y));
                    if (segment.TryIntersectWith(test, out var intersection))
                    {
                        yield return intersection;
                    }
                }
            }
            else
            {
                var minY = Math.Min(a.Y, b.Y);
                var maxY = Math.Max(a.Y, b.Y);

                for (var y = minY + 1; y < maxY; y++)
                {
                    var test = new Segment(new Point(a.X, y), new Point(b.X, y));
                    if (segment.TryIntersectWith(test, out var intersection))
                    {
                        yield return intersection;
                    }
                }
            }
        }
    }
}
