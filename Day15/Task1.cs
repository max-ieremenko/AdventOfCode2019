using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day15
{
    internal static class Task1
    {
        public static int Solve(IEnumerable<string> input)
        {
            var memory = input
                .First()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => long.Parse(i, CultureInfo.InvariantCulture))
                .ToArray();

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

            var path = new PathResolver(droid.Map).FindPath(default, droid.Map.OxygenSystem);
            return path.Count;
        }
    }
}