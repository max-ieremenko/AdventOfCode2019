using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day07
{
    internal static class Task1
    {
        public static (int output, int[] phaseSetting) Solve(IEnumerable<string> input)
        {
            var memory = input
                .First()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => int.Parse(i, CultureInfo.InvariantCulture))
                .ToArray();

            var resultOutput = 0;
            int[] resultPhaseSetting = null;

            foreach (var phaseSetting in IntCodeComputer.GetPhaseSettings(0, 4))
            {
                var output = 0;

                var amplifiers = new IntCodeComputer[5];
                for (var i = 0; i < amplifiers.Length; i++)
                {
                    amplifiers[i] = new IntCodeComputer((int[])memory.Clone(), phaseSetting[i]);
                }

                for (var i = 0; i < amplifiers.Length - 1; i++)
                {
                    var next = amplifiers[i + 1];
                    amplifiers[i].OnOutput += value => next.Run(value);
                }

                amplifiers[amplifiers.Length - 1].OnOutput += value => output = value;
                amplifiers[0].Run(0);

                if (output > resultOutput)
                {
                    resultOutput = output;
                    resultPhaseSetting = phaseSetting;
                }
            }

            return (resultOutput, resultPhaseSetting);
        }
    }
}
