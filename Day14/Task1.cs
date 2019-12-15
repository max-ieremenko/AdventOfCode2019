using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14
{
    internal static class Task1
    {
        public static long Solve(IEnumerable<string> input)
        {
            var reactionByUnit = input
                .Select(Reaction.Parse)
                .ToDictionary(i => i.Output.Unit);

            var fuel = reactionByUnit[Unit.Fuel];
            reactionByUnit.Remove(Unit.Fuel);

            while (reactionByUnit.Count > 0)
            {
                var newInput = new List<Chemical>();
                var toRemove = new List<Unit>();

                foreach (var chemical in fuel.Input)
                {
                    var skip = reactionByUnit.Values.SelectMany(i => i.Input).Any(i => i.Unit == chemical.Unit);
                    if (skip)
                    {
                        newInput.Add(chemical);
                        continue;
                    }

                    var reaction = reactionByUnit[chemical.Unit];
                    toRemove.Add(chemical.Unit);

                    var factor = chemical.Amount / reaction.Output.Amount;
                    if (chemical.Amount % reaction.Output.Amount != 0)
                    {
                        factor++;
                    }

                    newInput.AddRange(reaction.Input.Select(i => i * factor));
                }

                fuel = new Reaction(newInput, fuel.Output).Simplify();
                foreach (var i in toRemove)
                {
                    reactionByUnit.Remove(i);
                }
            }

            if (fuel.Input.Count != 1)
            {
                throw new InvalidOperationException();
            }

            return fuel.Input[0].Amount;
        }
    }
}