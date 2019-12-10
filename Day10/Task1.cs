using System.Collections.Generic;
using System.Linq;

namespace Day10
{
    internal static class Task1
    {
        public static int Solve(IEnumerable<string> input)
        {
            var map = Map.Parse(input);

            var result = map
                .Asteroids
                .Select(i =>new
                {
                    Center = i,
                    Targets = map.FindAsteroidsOnDirectLineOfSightWith(i)
                })
                .OrderByDescending(i => i.Targets.Count)
                .First();

            //Console.WriteLine("{0} - {1}", result.Center, result.Targets.Count);
            //Console.WriteLine(map.ToString(result.Center, result.Targets));

            return result.Targets.Count;
        }
    }
}