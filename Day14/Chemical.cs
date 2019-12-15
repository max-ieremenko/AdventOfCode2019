using System;

namespace Day14
{
    internal readonly struct Chemical
    {
        public Chemical(int amount, Unit unit)
        {
            Amount = amount;
            Unit = unit;
        }

        public int Amount { get; }
        
        public Unit Unit { get; }

        public static Chemical operator +(Chemical x, Chemical y)
        {
            if (x.Unit != y.Unit)
            {
                throw new InvalidOperationException();
            }

            return new Chemical(x.Amount + y.Amount, x.Unit);
        }

        public static Chemical operator *(Chemical input, int amount)
        {
            return new Chemical(input.Amount * amount, input.Unit);
        }

        public override string ToString() => string.Format("{0} {1}", Amount, Unit);
    }
}