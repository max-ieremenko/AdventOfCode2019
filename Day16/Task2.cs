using System;
using System.Collections.Generic;
using System.Linq;

namespace Day16
{
    internal static class Task2
    {
        public static string Solve(IEnumerable<string> input, int phases = 100)
        {
            var signal = ParseInput(input.First());

            for (var phaseNum = 0; phaseNum < phases; phaseNum++)
            {
                var phaseResult = new int[signal.Length];
                
                for (var i = signal.Length - 1; i >= 0; i--)
                {
                    var value = signal[i];
                    if (i < signal.Length - 1)
                    {
                        value += phaseResult[i + 1];
                    }

                    phaseResult[i] = Math.Abs(value) % 10;
                }

                signal = phaseResult;
            }

            return string.Join(string.Empty, signal.Take(8));
        }

        private static int[] ParseInput(string inputLine)
        {
            const int Repeated = 10_000;

            var signal = new int[inputLine.Length * Repeated];
            for (var i = 0; i < inputLine.Length; i++)
            {
                signal[i] = inputLine[i] - 48;
            }

            for (var i = 1; i < Repeated; i++)
            {
                Array.Copy(signal, 0, signal, i * inputLine.Length, inputLine.Length);
            }

            var offset = 0;
            for (var i = 0; i < 7; i++)
            {
                offset += signal[i] * (int)Math.Pow(10, 6 - i);
            }

            var result = new int[signal.Length - offset];
            Array.Copy(signal, offset, result, 0, result.Length);
            return result;
        }
    }
}