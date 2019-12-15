using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Day14
{
    [DebuggerDisplay("{ToString()}")]
    internal readonly struct Reaction
    {
        public Reaction(IList<Chemical> input, Chemical output)
        {
            Output = output;
            Input = input;
        }

        public Chemical Output { get; }

        public IList<Chemical> Input { get; }

        public Reaction Simplify()
        {
            var input = Input.ToList();

            for (var i = 0; i < input.Count - 1; i++)
            {
                for (var j = i + 1; j < input.Count; j++)
                {
                    var x = input[i];
                    var y = input[j];
                    if (x.Unit == y.Unit)
                    {
                        input[i] = x + y;
                        input.RemoveAt(j);
                        j--;
                    }
                }
            }

            return new Reaction(input, Output);
        }

        public static Reaction Parse(string input)
        {
            // 7 A, 1 B => 1 C
            var sides = input.Split(new[] { "=>" }, StringSplitOptions.RemoveEmptyEntries);

            var output = ParseChemical(sides[1]);
            var raw = sides[0]
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(ParseChemical)
                .ToArray();

            return new Reaction(raw, output);
        }

        public override string ToString()
        {
            var text = new StringBuilder();

            for (var i = 0; i < Input.Count; i++)
            {
                if (i > 0)
                {
                    text.Append(", ");
                }

                text.Append(Input[i]);
            }

            text.Append(" => ").Append(Output);
            return text.ToString();
        }

        private static Chemical ParseChemical(string input)
        {
            var data = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return new Chemical(
                int.Parse(data[0], CultureInfo.InvariantCulture),
                new Unit(data[1]));
        }
    }
}
