using System.Collections.Generic;
using System.Linq;

namespace Day15
{
    internal sealed partial class PathResolver
    {
        private readonly Map _map;

        public PathResolver(Map map)
        {
            _map = map;
        }

        public IList<Point> FindPath(Point from, Point target)
        {
            return GetNeighborLocations(target)
                .Where(CanBeOccupied)
                .AsParallel()
                .Select(i => ResolvePath(from, i))
                .Where(i => i != null)
                .OrderBy(i => i.Count)
                .FirstOrDefault();
        }

        private IList<Point> ResolvePath(Point from, Point to)
        {
            var initial = new Vertex(from, to, null);
            var vertexByLocation = new Dictionary<Point, Vertex>
            {
                { initial.Location, initial }
            };
            var queue = new List<Vertex> { initial };

            while (queue.Count > 0)
            {
                var current = queue[0];
                queue.RemoveAt(0);
                current.IsSealed = true;

                if (current.Location == to)
                {
                    return current.GetPath();
                }

                foreach (var nextLocation in GetNeighborLocations(current.Location).Where(CanBeOccupied))
                {
                    if (!vertexByLocation.TryGetValue(nextLocation, out var next))
                    {
                        next = new Vertex(nextLocation, to, current);
                        vertexByLocation.Add(nextLocation, next);
                        queue.Add(next);
                    }
                    else if (!next.IsSealed)
                    {
                        next.TryOtherPrevious(current);
                    }
                }
            }

            return null;
        }

        private bool CanBeOccupied(Point location)
        {
            return !_map.IsWall(location);
        }

        internal static IEnumerable<Point> GetNeighborLocations(Point location)
        {
            yield return new Point(location.X, location.Y - 1);
            yield return new Point(location.X - 1, location.Y);
            yield return new Point(location.X + 1, location.Y);
            yield return new Point(location.X, location.Y + 1);
        }
    }
}
