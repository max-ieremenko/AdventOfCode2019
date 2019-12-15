using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day15
{
    internal sealed class Map
    {
        private readonly IDictionary<Point, CellValue> _cellByLocation = new Dictionary<Point, CellValue>();

        public Point OxygenSystem { get; private set; }

        public void SetWall(Point point)
        {
            if (_cellByLocation.TryGetValue(point, out var cell))
            {
                if (cell.Cell == Cell.Visited)
                {
                    throw new InvalidOperationException();
                }
            }

            _cellByLocation[point] = cell.Mark(Cell.Wall);
        }

        public void SetVisited(Point point)
        {
            if (_cellByLocation.TryGetValue(point, out var cell))
            {
                if (cell.Cell == Cell.Wall)
                {
                    throw new InvalidOperationException();
                }
            }

            _cellByLocation[point] = cell.Mark(Cell.Visited);
        }

        public void SetOxygenSystem(Point point)
        {
            SetVisited(point);
            OxygenSystem = point;
        }

        public int GetVisitedCount(Point point)
        {
            _cellByLocation.TryGetValue(point, out var cell);
            return cell.Cell == Cell.Visited ? cell.VisitedCount : 0;
        }

        public bool IsVisitedOrWall(Point point)
        {
            _cellByLocation.TryGetValue(point, out var cell);
            return cell.Cell != Cell.Unknown;
        }

        public bool IsWall(Point point)
        {
            _cellByLocation.TryGetValue(point, out var cell);
            return cell.Cell == Cell.Wall;
        }

        public bool IsOxygenPathInvestigated()
        {
            if (OxygenSystem == default)
            {
                return false;
            }

            var leftTop = new Point(Math.Min(0, OxygenSystem.X), Math.Min(0, OxygenSystem.X));
            var rightBottom = new Point(Math.Max(0, OxygenSystem.X), Math.Max(0, OxygenSystem.Y));

            for (var x = leftTop.X; x <= rightBottom.X; x++)
            {
                for (var y = leftTop.Y; y <= rightBottom.Y; y++)
                {
                    _cellByLocation.TryGetValue(new Point(x, y), out var cell);
                    if (cell.Cell == Cell.Unknown)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public string ToString(Point droid, IList<Point> path)
        {
            var leftTop = new Point();
            var rightBottom = new Point();
            foreach (var point in _cellByLocation.Keys.Concat(path))
            {
                leftTop = new Point(Math.Min(leftTop.X, point.X), Math.Min(leftTop.Y, point.Y));
                rightBottom = new Point(Math.Max(rightBottom.X, point.X), Math.Max(rightBottom.Y, point.Y));
            }

            var text = new StringBuilder();
            for (var y = leftTop.Y; y <= rightBottom.Y; y++)
            {
                for (var x = leftTop.X; x <= rightBottom.X; x++)
                {
                    var point = new Point(x, y);
                    _cellByLocation.TryGetValue(point, out var cell);
                    var marker = ' ';

                    if (OxygenSystem != default && OxygenSystem == point)
                    {
                        marker = '0';
                    }
                    else if (droid == point)
                    {
                        marker = 'D';
                    }
                    else if (point == default)
                    {
                        marker = 'X';
                    }
                    else if (path.Contains(point))
                    {
                        marker = '+';
                    }
                    else if (cell.Cell == Cell.Wall)
                    {
                        marker = '#';
                    }
                    else if (cell.Cell == Cell.Visited)
                    {
                        marker = '.';
                    }

                    text.Append(marker);
                }

                text.AppendLine();
            }

            return text.ToString();
        }

        private readonly struct CellValue
        {
            public CellValue(Cell cell, int visitedCount)
            {
                Cell = cell;
                VisitedCount = visitedCount;
            }

            public Cell Cell { get; }
            
            public int VisitedCount { get; }
            
            public CellValue Mark(Cell cell)
            {
                return new CellValue(cell, VisitedCount + 1);
            }
        }

        private enum Cell
        {
            Unknown,
            Wall,
            Visited
        }
    }
}
