using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day03
{
    internal static class Task2
    {
        public static int Solve(IEnumerable<string> input)
        {
            var lines = input.Select(ParseLine).Take(2).ToArray();
            var line1 = lines[0];
            var line2 = lines[1];

            var result = 0;

            var line1Steps = 0;
            for (var step1 = 0; step1 < line1.Count; step1++)
            {
                var segment1 = line1[step1];
                var line2Steps = 0;

                for (var step2 = 0; step2 < line2.Count; step2++)
                {
                    var segment2 = line2[step2];

                    if (segment1.TryIntersectWith(segment2, out var intersection) && !intersection.Equals(default))
                    {
                        var d = line1Steps + new Segment(segment1.A, intersection).GetLength() + line2Steps + new Segment(segment2.A, intersection).GetLength();
                        if (result == 0 || result > d)
                        {
                            result = d;
                        }
                    }

                    line2Steps += segment2.GetLength();
                }

                line1Steps += segment1.GetLength();
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
