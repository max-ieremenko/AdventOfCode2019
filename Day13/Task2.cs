using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day13
{
    internal static class Task2
    {
        public static long Solve(IEnumerable<string> input, int quarters = 2)
        {
            var memory = input
                .First()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => long.Parse(i, CultureInfo.InvariantCulture))
                .ToArray();

            memory[0] = quarters;
            
            var cabinet = new ArcadeCabinet(memory);
            cabinet.RobotSlideShow();
            //cabinet.RobotPlay();
            //cabinet.UserPlay();

            return cabinet.Screen.Score;
        }
    }
}