﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day09
{
    internal static class Task2
    {
        public static long Solve(IEnumerable<string> input, int inputInstruction = 2)
        {
            var memory = input
                .First()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => long.Parse(i, CultureInfo.InvariantCulture))
                .ToArray();

            var computer = new IntCodeComputer(memory);
            return computer.Run(memory, inputInstruction);
        }
    }
}