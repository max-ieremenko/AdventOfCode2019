using System;

namespace Day06
{
    internal sealed class SpaceObject : IEquatable<SpaceObject>
    {
        public SpaceObject(string name)
        {
            Name = name;
        }

        public string Name { get; }
        
        public SpaceObject Orbit { get; set; }

        public bool Equals(SpaceObject other)
        {
            return other != null && Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj) => throw new NotSupportedException();

        public override int GetHashCode() => StringComparer.OrdinalIgnoreCase.GetHashCode(Name);

        public override string ToString() => Name;
    }
}
