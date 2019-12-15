using System;

namespace Day14
{
    internal readonly struct Unit : IEquatable<Unit>
    {
        public Unit(string name)
        {
            Name = name;
        }

        public static Unit Fuel => new Unit("FUEL");

        public static Unit Ore => new Unit("ORE");

        public string Name { get; }

        public static bool operator ==(Unit x, Unit y) => x.Equals(y);

        public static bool operator !=(Unit x, Unit y) => !x.Equals(y);

        public bool Equals(Unit other) => StringComparer.OrdinalIgnoreCase.Equals(Name, other.Name);

        public override bool Equals(object obj) => throw new NotSupportedException();

        public override int GetHashCode() => StringComparer.OrdinalIgnoreCase.GetHashCode(Name);

        public override string ToString() => Name;
    }
}