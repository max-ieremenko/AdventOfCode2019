using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day03
{
    internal static class Task1
    {
        public static int Solve(IEnumerable<string> input)
        {
            var lines = input.Select(ParseLine).Take(2).ToArray();
            var line1 = lines[0];
            var line2 = lines[1];

            var result = 0;

            foreach (var segment1 in line1)
            {
                foreach (var segment2 in line2)
                {
                    if (segment1.TryIntersectWith(segment2, out var intersection) && !intersection.Equals(default))
                    {
                        var d = intersection.GetDistance(default);
                        if (result == 0 || result > d)
                        {
                            result = d;
                        }
                    }
                }
            }

            return result;
        }

        private static IList<Segment> ParseLine(string input)
        {
            var steps = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            var result = new List<Segment>(steps.Length);

            var position = new Point(0, 0);
            foreach (var step in steps)
            {
                var direction = step[0];
                var length = int.Parse(step.Substring(1), CultureInfo.InvariantCulture);

                Point nextPosition;
                switch (direction)
                {
                    case 'U':
                        nextPosition = new Point(position.X, position.Y + length);
                        break;
                    case 'D':
                        nextPosition = new Point(position.X, position.Y - length);
                        break;
                    case 'R':
                        nextPosition = new Point(position.X + length, position.Y);
                        break;
                    case 'L':
                        nextPosition = new Point(position.X - length, position.Y);
                        break;
                    default:
                        throw new NotSupportedException();
                }

                result.Add(new Segment(position, nextPosition));
                position = nextPosition;
            }

            return result;
        }
    }
}
