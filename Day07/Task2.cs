using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day07
{
    internal static class Task2
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

            foreach (var phaseSetting in IntCodeComputer.GetPhaseSettings(5, 9))
            {
                var lastOutput = 0;

                var amplifiers = new IntCodeComputer[5];
                for (var i = 0; i < amplifiers.Length; i++)
                {
                    amplifiers[i] = new IntCodeComputer((int[])memory.Clone(), phaseSetting[i]);
                }

                amplifiers[amplifiers.Length - 1].OnOutput += value => lastOutput = value;

                for (var i = 0; i < amplifiers.Length; i++)
                {
                    var next = i == amplifiers.Length - 1 ? amplifiers[0] : amplifiers[i + 1];
                    amplifiers[i].OnOutput += value => next.Run(value);
                }

                amplifiers[0].Run(0);

                if (lastOutput > resultOutput)
                {
                    resultOutput = lastOutput;
                    resultPhaseSetting = phaseSetting;
                }
            }

            return (resultOutput, resultPhaseSetting);
        }
    }
}
