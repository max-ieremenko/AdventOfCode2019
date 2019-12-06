using System.Collections.Generic;
using System.Linq;

namespace Day06
{
    // 273985
    internal static class Task1
    {
        public static int Solve(IEnumerable<string> input)
        {
            var objects = Map.Build(input).Values;

            return objects.Sum(GetOrbitsCountCheckSum);
        }

        private static int GetOrbitsCountCheckSum(SpaceObject start)
        {
            var result = 0;

            var orbit = start.Orbit;
            while (orbit != null)
            {
                result++;
                orbit = orbit.Orbit;
            }

            return result;
        }
    }
}
