using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day05
{
    internal static class Task2
    {
        public static int Solve(IEnumerable<string> input, int inputInstruction = 5)
        {
            var memory = input
                .First()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => int.Parse(i, CultureInfo.InvariantCulture))
                .ToArray();

            var output = Run(memory, inputInstruction);
            return output;
        }

        private static int Run(int[] memory, int inputInstruction)
        {
            var stack = new Stack(memory);

            var output = 0;
            while (true)
            {
                switch (stack.GetOpCode())
                {
                    case 1:
                        stack.Add();
                        break;

                    case 2:
                        stack.Multiply();
                        break;

                    case 3:
                        stack.InputInstruction(inputInstruction);
                        break;

                    case 4:
                        stack.Output(ref output);
                        break;

                    case 5:
                        stack.JumpIfTrue();
                        break;

                    case 6:
                        stack.JumpIfFalse();
                        break;

                    case 7:
                        stack.LessThan();
                        break;

                    case 8:
                        stack.Equal();
                        break;

                    case 99:
                        return output;

                    default:
                        throw new NotSupportedException();
                }
            }
        }
    }
}
