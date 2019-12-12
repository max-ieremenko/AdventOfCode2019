using System;
using System.Collections.Generic;
using System.Linq;

namespace Day12
{
    internal static class Task1
    {
        public static long Solve(IEnumerable<string> input, int stepsCount = 1000)
        {
            var moons = input.Select(Moon.Parse).ToArray();
            
            var positionX = moons.Select(i => i.X).ToArray();
            var positionY = moons.Select(i => i.Y).ToArray();
            var positionZ = moons.Select(i => i.Z).ToArray();
            var velocityX = new int[moons.Length];
            var velocityY = new int[moons.Length];
            var velocityZ = new int[moons.Length];

            for (var i = 0; i < stepsCount; i++)
            {
                Moon.ApplyGravity(positionX, velocityX);
                Moon.ApplyGravity(positionY, velocityY);
                Moon.ApplyGravity(positionZ, velocityZ);

                Moon.ApplyVelocity(positionX, velocityX);
                Moon.ApplyVelocity(positionY, velocityY);
                Moon.ApplyVelocity(positionZ, velocityZ);
            }

            var result = 0L;
            for (var i = 0; i < positionX.Length; i++)
            {
                long potential = Math.Abs(positionX[i]) + Math.Abs(positionY[i]) + Math.Abs(positionZ[i]);
                long kinetic = Math.Abs(velocityX[i]) + Math.Abs(velocityY[i]) + Math.Abs(velocityZ[i]);
                result += (potential * kinetic);
            }

            return result;
        }
    }
}