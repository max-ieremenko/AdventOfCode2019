using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day13
{
    internal sealed class Screen
    {
        private readonly IDictionary<Point, Tile> _tileByLocation = new Dictionary<Point, Tile>();
        
        public int Score { get; set; }

        public void Draw(Point location, Tile tile)
        {
            if (location.X < 0 || location.Y < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (tile < Tile.Empty || tile > Tile.Ball)
            {
                throw new ArgumentOutOfRangeException(nameof(tile));
            }

            if (tile == Tile.Empty)
            {
                _tileByLocation.Remove(location);
            }
            else
            {
                _tileByLocation[location] = tile;
            }
        }

        public int GetBlocksCount() => _tileByLocation.Values.Count(i => i == Tile.Block);

        public override string ToString()
        {
            var leftTop = default(Point);
            var rightBottom = default(Point);
            foreach (var point in _tileByLocation.Keys)
            {
                leftTop = new Point(Math.Min(leftTop.X, point.X), Math.Min(leftTop.Y, point.Y));
                rightBottom = new Point(Math.Max(rightBottom.X, point.X), Math.Max(rightBottom.Y, point.Y));
            }

            var text = new StringBuilder();

            for (var y = leftTop.Y; y <= rightBottom.Y; y++)
            {
                for (var x = leftTop.X; x <= rightBottom.X; x++)
                {
                    var tile = GetTile(new Point(x, y));
                    
                    char pixel;
                    switch (tile)
                    {
                        case Tile.Empty:
                            pixel = ' ';
                            break;

                        case Tile.Wall:
                            pixel = '#';
                            break;

                        case Tile.Block:
                            pixel = 'B';
                            break;

                        case Tile.Paddle:
                            pixel = '^';
                            break;

                        case Tile.Ball:
                            pixel = '0';
                            break;

                        default:
                            throw new NotSupportedException();
                    }

                    text.Append(pixel);
                }

                text.AppendLine();
            }

            text
                .AppendLine()
                .AppendFormat("Score: {0}", Score)
                .AppendLine();

            return text.ToString();
        }

        private Tile GetTile(Point location)
        {
            if (_tileByLocation.TryGetValue(location, out var result))
            {
                return result;
            }

            return Tile.Empty;
        }
    }
}
