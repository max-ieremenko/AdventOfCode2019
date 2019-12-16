using System;
using System.Collections.Generic;
using System.Linq;

namespace Day16
{
    internal static class Task1
    {
        public static string Solve(IEnumerable<string> input, int phases = 100)
        {
            var inputLine = input.First();

            var signal = new int[inputLine.Length];
            for (var i = 0; i < inputLine.Length; i++)
            {
                signal[i] = inputLine[i] - 48;
            }

            var pattern = new[] { 0, 1, 0, -1 };

            for (var phaseNum = 0; phaseNum < phases; phaseNum++)
            {
                var phaseResult = new int[signal.Length];

                for (var y = 0; y < signal.Length; y++)
                {
                    var value = 0;
                    for (var x = 0; x < signal.Length; x++)
                    {
                        var patternIndex = ((x + 1) / (y + 1)) % pattern.Length;
                        value += signal[x] * pattern[patternIndex];
                    }

                    phaseResult[y] = Math.Abs(value) % 10;
                }

                signal = phaseResult;
            }

            return string.Join(string.Empty, signal.Take(8));
        }
    }
}