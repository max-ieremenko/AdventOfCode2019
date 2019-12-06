using System;
using System.Collections.Generic;

namespace Day06
{
    internal static class Map
    {
        public static IDictionary<string, SpaceObject> Build(IEnumerable<string> input)
        {
            var objectByName = new Dictionary<string, SpaceObject>(StringComparer.OrdinalIgnoreCase);

            foreach (var line in input)
            {
                var index = line.IndexOf(')');
                var planet = line.Substring(0, index);
                var satellite = line.Substring(index + 1);

                GetOrCreate(satellite, objectByName).Orbit = GetOrCreate(planet, objectByName);
            }

            return objectByName;
        }

        private static SpaceObject GetOrCreate(string name, IDictionary<string, SpaceObject> objectByName)
        {
            if (objectByName.TryGetValue(name, out var result))
            {
                return result;
            }

            result = new SpaceObject(name);
            objectByName.Add(name, result);
            return result;
        }
    }
}
