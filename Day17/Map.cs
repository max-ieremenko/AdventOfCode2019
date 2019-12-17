using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day17
{
    internal sealed class Map
    {
        private readonly IDictionary<Point, char> _tileByLocation = new Dictionary<Point, char>();

        public Point LeftTop { get; }

        public Point RightBottom { get; private set; }

        public static Map Parse(IEnumerable<byte> input)
        {
            var map = new Map();

            var x = 0;
            var y = 0;
            foreach (var value in input)
            {
                char tile;
                switch (value)
                {
                    case 35:
                        tile = MapTile.Scaffold;
                        break;
                    case 46:
                        tile = MapTile.Space;
                        break;
                    case 94:
                        tile = MapTile.RobotUp;
                        break;
                    case 62:
                        tile = MapTile.RobotRight;
                        break;
                    case 60:
                        tile = MapTile.RobotLeft;
                        break;

                    case 10:
                        x = 0;
                        y++;
                        continue;

                    default:
                        throw new NotSupportedException();
                }

                var location = new Point(x, y);
                map._tileByLocation.Add(location, tile);
                map.RightBottom = location;
                x++;
            }

            return map;
        }

        public IEnumerable<Point> GetScaffolds() => _tileByLocation.Where(i => i.Value != MapTile.Space).Select(i => i.Key);

        public bool IsScaffold(Point point) => _tileByLocation[point] != MapTile.Space;

        public string ToString(ICollection<Point> intersections = null)
        {
            var text = new StringBuilder();

            for (var y = LeftTop.Y; y < RightBottom.Y; y++)
            {
                for (var x = LeftTop.X; x < RightBottom.X; x++)
                {
                    var location = new Point(x, y);
                    if (intersections?.Contains(location) == true)
                    {
                        text.Append('0');
                    }
                    else
                    {
                        var value = _tileByLocation[location];
                        text.Append(value);
                    }
                }

                text.AppendLine();
            }
            
            return text.ToString();
        }
    }
}
