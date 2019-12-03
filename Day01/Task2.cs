using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day01
{
    internal static class Task2
    {
        public static int Solve(IEnumerable<string> input)
        {
            return input
                .Select(i => int.Parse(i, CultureInfo.InvariantCulture))
                .Select(CalculateFuel)
                .Sum();
        }

        private static int CalculateFuel(int mass)
        {
            var result = (mass / 3) - 2;
            if (result > 8)
            {
                result += CalculateFuel(result);
            }

            return result;
        }
    }
}
