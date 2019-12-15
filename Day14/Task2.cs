using System.Collections.Generic;
using System.Linq;

namespace Day14
{
    internal static class Task2
    {
        public static long Solve(IEnumerable<string> input, long oreAmount = 1000_000_000_000)
        {
            var reactionByUnit = input
                .Select(Reaction.Parse)
                .ToDictionary(i => i.Output.Unit);

            var factory = new Factory(reactionByUnit);
            var fuelRequest = 1_000_000L;
            var totalFuel = 0L;

            while (oreAmount > 0)
            {
                if (fuelRequest > 1)
                {
                    fuelRequest = TestFuelRequest(fuelRequest, oreAmount, reactionByUnit);
                }

                var ore = factory.ProduceFuel(fuelRequest);
                oreAmount -= ore;
                if (oreAmount >= 0)
                {
                    totalFuel += fuelRequest;
                }
            }

            return totalFuel;
        }

        private static long TestFuelRequest(
            long lastValue,
            long oreAmount,
            IDictionary<Unit, Reaction> reactionByUnit)
        {
            while (lastValue > 1)
            {
                var factory = new Factory(reactionByUnit);
                var ore = factory.ProduceFuel(lastValue);
                if (ore <= oreAmount)
                {
                    return lastValue;
                }

                lastValue /= 10;
            }

            return 1;
        }
    }
}