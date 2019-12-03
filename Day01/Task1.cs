using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day01
{
    internal static class Task1
    {
        public static int Solve(IEnumerable<string> input)
        {
            var result = 0;
            foreach (var mass in input.Select(i => int.Parse(i, CultureInfo.InvariantCulture)))
            {
                var fuel = (mass / 3) - 2;
                result += fuel;
            }

            return result;
        }
    }
}
