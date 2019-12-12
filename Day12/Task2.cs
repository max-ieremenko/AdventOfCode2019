using System;
using System.Collections.Generic;
using System.Linq;

namespace Day12
{
    internal static class Task2
    {
        public static long Solve(IEnumerable<string> input)
        {
            var moons = input.Select(Moon.Parse).ToArray();

            var x = FindLoopLength(moons.Select(i => i.X).ToArray());
            var y = FindLoopLength(moons.Select(i => i.Y).ToArray());
            var z = FindLoopLength(moons.Select(i => i.Z).ToArray());

            return FindLeastCommonMultiple(FindLeastCommonMultiple(x, y), z);
        }

        private static int FindLoopLength(int[] positions)
        {
            var velocity = new int[positions.Length];
            var originalPositions = positions.ToArray();

            var stepsCount = 0;
            var finish = false;
            while (!finish)
            {
                stepsCount++;

                Moon.ApplyGravity(positions, velocity);
                Moon.ApplyVelocity(positions, velocity);

                finish = true;
                for (var i = 0; i < positions.Length; i++)
                {
                    if (positions[i] != originalPositions[i] || velocity[i] != 0)
                    {
                        finish = false;
                        break;
                    }
                }
            }

            return stepsCount;
        }

        private static long FindLeastCommonMultiple(long a, long b)
        {
            var max = Math.Max(a, b);
            var min = Math.Min(a, b);

            for (var i = 1; i < min; i++)
            {
                var result = max * i;
                if (result % min == 0)
                {
                    return result;
                }
            }

            return max * min;
        }
    }
}