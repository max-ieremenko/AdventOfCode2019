using System.Collections.Generic;
using System.Linq;

namespace Day08
{
    internal static class Task1
    {
        public static int Solve(IEnumerable<string> input, int width = 25, int height = 6)
        {
            var data = input.First();

            var layers = new List<int[]>();
            
            var position = 0;
            while (position != data.Length)
            {
                var layer = new int[width * height];
                for (var i = 0; i < layer.Length; i++)
                {
                    var c = data[position + i];
                    layer[i] = c - 48;
                }

                layers.Add(layer);
                position += layer.Length;
            }

            var target = layers
                .OrderBy(i => i.Count(c => c == 0))
                .First();

            var digit1Count = target.Count(i => i == 1);
            var digit2Count = target.Count(i => i == 2);
            return digit1Count * digit2Count;
        }
    }
}
