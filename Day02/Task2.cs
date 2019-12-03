using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day02
{
    internal static class Task2
    {
        private const int Output = 19690720;

        public static string Solve(IEnumerable<string> input)
        {
            var values = input
                .First()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => int.Parse(i, CultureInfo.InvariantCulture))
                .ToArray();

            int noun, verb;
            for (noun = 0; noun < values.Length; noun++)
            for (verb = 0; verb < values.Length; verb++)
            {
                var test = Task1.Solve((int[])values.Clone(), noun, verb);
                if (test == Output)
                {
                    return string.Format("noun={0}; verb={1}; answer={2}", noun, verb, 100 * noun + verb);
                }
            }

            throw new NotImplementedException();
        }

        public static string BuildFormula(IEnumerable<string> input)
        {
            var values = input
                .First()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            values[1] = "noun";
            values[2] = "verb";

            var position = 0;
            string opCode;
            while ((opCode = values[position]) != "99")
            {
                var positionX = values[position + 1];
                var positionY = values[position + 2];

                var x = GetValue(values, positionX);
                var y = GetValue(values, positionY);
                var resultPosition = int.Parse(values[position + 3], CultureInfo.InvariantCulture);

                string result;
                if (opCode == "1")
                {
                    result = string.Format("({0} + {1})", x, y);
                }
                else if (opCode == "2")
                {
                    result = string.Format("({0} * {1})", x, y);
                }
                else
                {
                    throw new NotSupportedException();
                }

                values[resultPosition] = result;
                position += 4;
            }

            return values[0] + " = " + Output;
        }

        private static string GetValue(string[] values, string position)
        {
            if (position == "noun" || position == "verb")
            {
                return position;
            }

            var index = int.Parse(position, CultureInfo.InvariantCulture);
            return values[index];
        }
    }
}
