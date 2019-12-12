using System;
using System.Globalization;
using System.Linq;

namespace Day12
{
    internal static class Moon
    {
        public static Point Parse(string input)
        {
            // <x=-8, y=-10, z=0>
            var points = input
                .Substring(1, input.Length - 2)
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => i.Split('='))
                .ToArray();

            var x = 0;
            var y = 0;
            var z = 0;
            for (var i = 0; i < 3; i++)
            {
                var data = points[i];
                var value = int.Parse(data[1], CultureInfo.InvariantCulture);

                if ("x".Equals(data[0], StringComparison.OrdinalIgnoreCase))
                {
                    x = value;
                }
                else if ("y".Equals(data[0], StringComparison.OrdinalIgnoreCase))
                {
                    y = value;
                }
                else if ("z".Equals(data[0], StringComparison.OrdinalIgnoreCase))
                {
                    z = value;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }

            return new Point(x, y, z);
        }

        public static void ApplyGravity(int[] positions, int[] velocity)
        {
            for (var i = 0; i < positions.Length; i++)
            {
                for (var j = 0; j < positions.Length; j++)
                {
                    if (i != j)
                    {
                        if (positions[i] > positions[j])
                        {
                            velocity[i]--;
                        }
                        else if (positions[i] < positions[j])
                        {
                            velocity[i]++;
                        }
                    }
                }
            }
        }

        public static void ApplyVelocity(int[] positions, int[] velocity)
        {
            for (var i = 0; i < positions.Length; i++)
            {
                positions[i] += velocity[i];
            }
        }
    }
}
