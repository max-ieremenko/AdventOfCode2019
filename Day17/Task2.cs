using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Day17
{
    internal static class Task2
    {
        public static int Solve(IEnumerable<string> input)
        {
            var memory = input
                .First()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => long.Parse(i, CultureInfo.InvariantCulture))
                .ToArray();

            var routine = new InstructionBuilder()
                .A()
                .B()
                .A()
                .C()
                .Build();

            var programA = new InstructionBuilder()
                .TurnRight()
                .Move(12)
                .TurnLeft()
                .Move(10)
                .TurnRight()
                .Move(12)
                .Build();

            var programB = new InstructionBuilder()
                .TurnLeft()
                .Move(8)
                .TurnRight()
                .Move(10)
                .TurnRight()
                .Move(6)
                .Build();

            var programC = new InstructionBuilder()
                .TurnRight()
                .Move(0)
                .TurnRight()
                .Move(0)
                .Build();

            var program = routine.Concat(programA).Concat(programB).Concat(programC).Concat(new byte[] { 110, 10 }).ToList();

            memory[0] = 2;
            var computer = new IntCodeComputer(memory)
            {
                OnOutput = i => Console.Write(Encoding.ASCII.GetString(new[] { i })),
                OnInput = () =>
                {
                    var value = program[0];
                    program.RemoveAt(0);
                    return value;
                }
            };

            computer.Run();

            throw new NotImplementedException();
        }
    }
}