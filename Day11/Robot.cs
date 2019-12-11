using System;
using System.Collections.Generic;
using System.Text;

namespace Day11
{
    internal sealed class Robot
    {
        private readonly IDictionary<Point, Color> _panelByPosition;
        private readonly Color _startColor;
        
        private Point _position;
        private Direction _direction;

        public Robot(Color startColor = Color.Black)
        {
            ValidateColor(startColor);

            _startColor = startColor;
            _panelByPosition = new Dictionary<Point, Color>();
        }

        public int NumberOfPanelsPaintedAtLeastOnce { get; private set; }

        public Color GetCurrentPanelColor() => GetPanelColor(_position);

        public void PaintAndMove(Color color, int direction)
        {
            ValidateColor(color);

            if (!_panelByPosition.ContainsKey(_position))
            {
                NumberOfPanelsPaintedAtLeastOnce++;
            }

            _panelByPosition[_position] = color;

            _direction = ChangeDirection(direction, _direction);
            switch (_direction)
            {
                case Direction.Up:
                    _position = new Point(_position.X, _position.Y - 1);
                    break;

                case Direction.Right:
                    _position = new Point(_position.X + 1, _position.Y);
                    break;

                case Direction.Down:
                    _position = new Point(_position.X, _position.Y + 1);
                    break;

                case Direction.Left:
                    _position = new Point(_position.X - 1, _position.Y);
                    break;
                
                default:
                    throw new InvalidOperationException();
            }
        }

        public string GetRegistrationIdentifier()
        {
            var leftTop = default(Point);
            var rightBottom = default(Point);
            foreach (var point in _panelByPosition.Keys)
            {
                leftTop = new Point(Math.Min(leftTop.X, point.X), Math.Min(leftTop.Y, point.Y));
                rightBottom = new Point(Math.Max(rightBottom.X, point.X), Math.Max(rightBottom.Y, point.Y));
            }

            var text = new StringBuilder();
            for (var y = leftTop.Y; y <= rightBottom.Y; y++)
            {
                for (var x = leftTop.X; x <= rightBottom.X; x++)
                {
                    var color = GetPanelColor(new Point(x, y));
                    text.Append(color == Color.White ? "#" : " ");
                }

                text.AppendLine();
            }

            return text.ToString();
        }

        private static void ValidateColor(Color color)
        {
            if (color < Color.Black || color > Color.White)
            {
                throw new ArgumentOutOfRangeException(nameof(color));
            }
        }

        private static Direction ChangeDirection(int input, Direction current)
        {
            switch (input)
            {
                // left
                case 0:
                    current -= 1;
                    if (current < 0)
                    {
                        current = Direction.Left;
                    }

                    break;

                // right
                case 1:
                    current += 1;
                    if (current > Direction.Left)
                    {
                        current = Direction.Up;
                    }

                    break;

                default:
                    throw new NotSupportedException();
            }

            return current;
        }

        public Color GetPanelColor(Point position)
        {
            if (!_panelByPosition.TryGetValue(position, out var color))
            {
                return position.Equals(default) ? _startColor : Color.Black;
            }

            return color;
        }

        private enum Direction
        {
            Up,
            Right,
            Down,
            Left
        }
    }
}
