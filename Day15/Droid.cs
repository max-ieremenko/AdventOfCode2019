using System;

namespace Day15
{
    internal sealed class Droid
    {
        private readonly IntCodeComputer _computer;
        private Point _nextPoint;

        public Droid(long[] memory)
        {
            _computer = new IntCodeComputer(memory)
            {
                OnInput = Request,
                OnOutput = Response
            };

            Map = new Map();
            Map.SetVisited(Location);
        }

        public Map Map { get; }

        public Point Location { get; private set; }

        public Func<Direction> OnMove { get; set; }

        public void Run() => _computer.Run();

        public void Halt() => _computer.Halt();

        private void Response(int statusCode)
        {
            switch (statusCode)
            {
                case 0:
                    Map.SetWall(_nextPoint);
                    break;

                case 1:
                    Map.SetVisited(_nextPoint);
                    Location = _nextPoint;
                    break;

                case 2:
                    Map.SetOxygenSystem(_nextPoint);
                    Location = _nextPoint;
                    break;

                default:
                    throw new InvalidOperationException();
            }
        }

        private int Request()
        {
            var direction = OnMove();
            _nextPoint = Location + direction;
            return (int)direction;
        }
    }
}
