using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day13
{
    internal static class Task1
    {
        public static long Solve(IEnumerable<string> input)
        {
            var memory = input
                .First()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => long.Parse(i, CultureInfo.InvariantCulture))
                .ToArray();

            var screen = new Screen();

            var computer = new IntCodeComputer(memory)
            {
                OnOutput = (a, b, c) => screen.Draw(new Point((int) a, (int) b), (Tile) c)
            };

            computer.Run();

            //Console.WriteLine(screen);

            return screen.GetBlocksCount();
        }
    }
}