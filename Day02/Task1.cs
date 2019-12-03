using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day02
{
    internal static class Task1
    {
        public static int Solve(IEnumerable<string> input, bool skipInitialStep = false)
        {
            var values = input
                .First()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => int.Parse(i, CultureInfo.InvariantCulture))
                .ToArray();

            return Solve(
                values,
                skipInitialStep ? values[1] : 12,
                skipInitialStep ? values[2] : 2);
        }

        internal static int Solve(int[] input, int noun, int verb)
        {
            input[1] = noun;
            input[2] = verb;

            var position = 0;
            int opCode;
            while ((opCode = input[position]) != 99)
            {
                var x = input[input[position + 1]];
                var y = input[input[position + 2]];
                var resultPosition = input[position + 3];

                int result;
                if (opCode == 1)
                {
                    result = x + y;
                }
                else if (opCode == 2)
                {
                    result = x * y;
                }
                else
                {
                    throw new NotSupportedException();
                }

                input[resultPosition] = result;
                position += 4;
            }

            return input[0];
        }
    }
}
