using System;
using System.Collections.Generic;
using System.Linq;

namespace Day08
{
    internal static class Task2
    {
        public static void Solve(IEnumerable<string> input, int width = 25, int height = 6)
        {
            var rows = ParseRows(input.First(), width);
            
            var image = rows.Take(height).ToList();

            var layersCount = rows.Count / height;
            for (var layerIndex = 1; layerIndex < layersCount; layerIndex++)
            {
                for (var i = 0; i < height; i++)
                {
                    var baseLayer = image[i];
                    var nextLayer = rows[layerIndex * height + i];
                    MergeLayers(baseLayer, nextLayer);
                }
            }

            Print(image);
        }

        private static void Print(IList<int[]> image)
        {
            foreach (var layer in image)
            {
                foreach (var pixel in layer)
                {
                    var backColor = Console.ForegroundColor;

                    switch (pixel)
                    {
                        case Color.Transparent:
                            break;
                        case Color.Black:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("X");
                            break;
                        case Color.White:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("X");
                            break;
                        default:
                            throw new NotSupportedException();
                    }

                    Console.ForegroundColor = backColor;
                }

                Console.WriteLine();
            }
        }

        private static void MergeLayers(int[] target, int[] source)
        {
            for (var i = 0; i < target.Length; i++)
            {
                if (target[i] == Color.Transparent)
                {
                    target[i] = source[i];
                }
            }
        }

        private static IList<int[]> ParseRows(string input, int width)
        {
            var rows = new List<int[]>();

            var position = 0;
            while (position != input.Length)
            {
                var row = new int[width];

                for (var i = 0; i < row.Length; i++)
                {
                    var c = input[position + i];
                    row[i] = c - 48;
                }

                rows.Add(row);
                position += row.Length;
            }

            return rows;
        }
    }
}
