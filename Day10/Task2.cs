using System;
using System.Collections.Generic;
using System.Linq;

namespace Day10
{
    internal static class Task2
    {
        public static int Solve(IEnumerable<string> input, int bet = 200)
        {
            var map = Map.Parse(input);

            var result = FindWinner(map, bet);

            return result.X * 100 + result.Y;
        }

        private static Point FindWinner(Map map, int bet)
        {
            var asteroid = map
                .Asteroids
                .OrderByDescending(i => map.FindAsteroidsOnDirectLineOfSightWith(i).Count)
                .First();

            var vaporizedCount = 0;
            while (map.Asteroids.Count > 1)
            {
                var targets = map.FindAsteroidsOnDirectLineOfSightWith(asteroid);

                //Console.WriteLine();
                //Console.WriteLine("-------------------------");
                //Console.WriteLine(map.ToString(asteroid, targets));

                var orderedTargets = targets.OrderBy(i => Map.CalculateClockwiseAngle(asteroid, i));

                foreach (var target in orderedTargets)
                {
                    vaporizedCount++;
                    if (vaporizedCount == bet)
                    {
                        return target;
                    }

                    map.Asteroids.Remove(target);
                }
            }

            throw new InvalidOperationException();
        }
    }
}