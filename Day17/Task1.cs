using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day17
{
    // 12512
    internal static class Task1
    {
        public static int Solve(IEnumerable<string> input)
        {
            var memory = input
                .First()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => long.Parse(i, CultureInfo.InvariantCulture))
                .ToArray();

            var map = BuildMap(memory);

            var intersections = map
                .GetScaffolds()
                .Where(i => i.X > map.LeftTop.X && i.X < map.RightBottom.X)
                .Where(i => i.Y > map.LeftTop.Y && i.Y < map.RightBottom.Y)
                .Where(i => map.IsScaffold(new Point(i.X, i.Y - 1)))
                .Where(i => map.IsScaffold(new Point(i.X, i.Y + 1)))
                .Where(i => map.IsScaffold(new Point(i.X - 1, i.Y)))
                .Where(i => map.IsScaffold(new Point(i.X + 1, i.Y)))
                .ToHashSet();
            
            ////Console.WriteLine(map.ToString(intersections));

            var sum = 0;
            foreach (var intersection in intersections)
            {
                var x = intersection.X;
                var y = intersection.Y;
                sum += x * y;
            }

            return sum;
        }

        private static Map BuildMap(long[] memory)
        {
            var mapInput = new List<byte>();
            var computer = new IntCodeComputer(memory)
            {
                OnOutput = mapInput.Add
            };

            computer.Run();
            return Map.Parse(mapInput);
        }
    }
}