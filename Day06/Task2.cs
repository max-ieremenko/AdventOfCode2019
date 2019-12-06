using System.Collections.Generic;
using System.Linq;

namespace Day06
{
    // 460
    internal static class Task2
    {
        public static int Solve(IEnumerable<string> input)
        {
            var objectByName = Map.Build(input);

            var you = objectByName["YOU"].Orbit;
            var san = objectByName["SAN"].Orbit;

            var youPath = BuildPathToCom(you).ToDictionary(i => i.point, i => i.length);
            var sanPoint = BuildPathToCom(san).First(i => youPath.ContainsKey(i.point));
            
            var youPointLength = youPath[sanPoint.point];

            return sanPoint.length + youPointLength;
        }

        private static IEnumerable<(SpaceObject point, int length)> BuildPathToCom(SpaceObject start)
        {
            var current = start;
            var length = 0;
            while (current != null)
            {
                yield return (current, length);
         
                current = current.Orbit;
                length++;
            }
        }
    }
}
