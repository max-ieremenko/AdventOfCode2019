using System;

namespace Day13
{
    internal sealed class BallPrediction
    {
        private Point _point0;
        private Point _point1;
        private int _historyLength;
        private Point _paddle;

        public void SetPaddle(Point location)
        {
            _paddle = location;
        }

        public void LogBall(Point location)
        {
            if (_historyLength == 0)
            {
                _point0 = location;
                _historyLength++;

                return;
            }

            if (_historyLength == 1)
            {
                if (!_point0.Equals(location))
                {
                    _point1 = location;
                    _historyLength++;
                }

                return;
            }

            if (!_point1.Equals(location))
            {
                _point0 = _point1;
                _point1 = location;
            }
        }

        public Joystick MovePaddleTo()
        {
            if (_historyLength < 2)
            {
                return Joystick.Neutral;
            }

            var shiftX = _point1.X - _point0.X;
            var ballTargetX = _point1.X + ((_paddle.Y - _point1.Y - 1) * shiftX);
            
            var gap = ballTargetX - _paddle.X;

            return (Joystick)Math.Sign(gap);
        }
    }
}
