using System.Collections.Generic;

namespace Day14
{
    internal sealed class Factory
    {
        private readonly IDictionary<Unit, long> _rest;

        public Factory(IDictionary<Unit, Reaction> reactionByUnit)
        {
            _rest = new Dictionary<Unit, long>();
            ReactionByUnit = reactionByUnit;
        }

        public IDictionary<Unit, Reaction> ReactionByUnit { get; }

        public long ProduceFuel(long amount)
        {
            var fuel = ReactionByUnit[Unit.Fuel];

            var result = 0L;
            foreach (var chemical in fuel.Input)
            {
                result += Produce(chemical.Amount * amount, chemical.Unit);
            }

            return result;
        }

        private long Produce(long amount, Unit unit)
        {
            if (unit == Unit.Ore)
            {
                return amount;
            }

            amount = RestMinus(amount, unit);
            if (amount == 0)
            {
                return 0;
            }

            var reaction = ReactionByUnit[unit];

            var factor = amount / reaction.Output.Amount;
            if (amount % reaction.Output.Amount != 0)
            {
                factor++;
            }

            var result = 0L;
            foreach (var chemical in reaction.Input)
            {
                result += Produce(chemical.Amount * factor, chemical.Unit);
            }

            var produced = factor * reaction.Output.Amount;
            if (produced == amount)
            {
                return result;
            }

            if (produced > amount)
            {
                RestPlus(produced - amount, unit);
            }
            else
            {
                result += Produce(amount - produced, unit);
            }

            return result;
        }

        private void RestPlus(long amount, Unit unit)
        {
            _rest.TryGetValue(unit, out var rest);
            _rest[unit] = rest + amount;
        }

        private long RestMinus(long amount, Unit unit)
        {
            if (!_rest.TryGetValue(unit, out var rest))
            {
                return amount;
            }

            if (rest > amount)
            {
                _rest[unit] = rest - amount;
                amount = 0;
            }
            else
            {
                _rest.Remove(unit);
                amount -= rest;
            }

            return amount;
        }
    }
}
