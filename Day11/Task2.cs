using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day11
{
    internal static class Task2
    {
        public static void Solve(IEnumerable<string> input)
        {
            var memory = input
                .First()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => long.Parse(i, CultureInfo.InvariantCulture))
                .ToArray();

            var robot = new Robot(Color.White);
            var computer = new IntCodeComputer(memory)
            {
                OnInput = () => (int)robot.GetCurrentPanelColor(),
                OnOutput = (color, direction) => robot.PaintAndMove((Color)color, direction)
            };

            computer.Run();

            Console.WriteLine(robot.GetRegistrationIdentifier());
        }
    }
}