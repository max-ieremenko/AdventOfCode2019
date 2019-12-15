using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day15
{
    internal static class Task2
    {
        public static int Solve(IEnumerable<string> input)
        {
            var memory = input
                .First()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => long.Parse(i, CultureInfo.InvariantCulture))
                .ToArray();

            var map = Investigate(memory);
            var filledWithOxygen = new HashSet<Point> { map.OxygenSystem };

            var timer = 0;
            while (true)
            {
                var nextPoints = filledWithOxygen
                    .SelectMany(PathResolver.GetNeighborLocations)
                    .Where(i => !filledWithOxygen.Contains(i))
                    .Where(i => !map.IsWall(i))
                    .ToList();

                if (nextPoints.Count == 0)
                {
                    break;
                }

                timer++;
                foreach (var point in nextPoints)
                {
                    filledWithOxygen.Add(point);
                }
            }

            return timer;
        }

        private static Map Investigate(long[] memory)
        {
            var droid = new Droid(memory);

            droid.OnMove = () =>
            {
                if (droid.Map.IsOxygenPathInvestigated())
                {
                    droid.Halt();
                }

                foreach (var direction in new[] { Direction.Up, Direction.Right, Direction.Left, Direction.Down })
                {
                    var next = droid.Location + direction;
                    if (!droid.Map.IsVisitedOrWall(next))
                    {
                        return direction;
                    }
                }

                return new[] { Direction.Down, Direction.Left, Direction.Right, Direction.Up }
                    .Where(i => !droid.Map.IsWall(droid.Location + i))
                    .OrderBy(i => droid.Map.GetVisitedCount(droid.Location + i))
                    .First();
            };

            droid.Run();
            return droid.Map;
        }
    }
}