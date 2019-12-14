using System;
using System.Threading;

namespace Day13
{
    internal sealed class ArcadeCabinet
    {
        private readonly IntCodeComputer _computer;
        private readonly BallPrediction _ballPrediction;

        public ArcadeCabinet(long[] memory)
        {
            Screen = new Screen();

            _ballPrediction = new BallPrediction();
            _computer = new IntCodeComputer(memory)
            {
                OnOutput = OnComputerOutput
            };
        }

        public Screen Screen { get; }

        public void RobotPlay()
        {
            _computer.OnInput = RobotInput;
            _computer.Run();
        }

        public void RobotSlideShow()
        {
            _computer.OnInput = RobotSlideShowInput;
            _computer.Run();
        }

        public void UserPlay()
        {
            _computer.OnInput = UserInput;
            _computer.Run();
        }

        private int RobotSlideShowInput()
        {
            Console.Clear();
            Console.WriteLine(Screen);

            Thread.Sleep(100);

            var joystick = _ballPrediction.MovePaddleTo();
            return (int)joystick;
        }

        private int RobotInput()
        {
            var joystick = _ballPrediction.MovePaddleTo();
            return (int)joystick;
        }

        private int UserInput()
        {
            Console.Clear();
            Console.WriteLine(Screen);

            var joystick = Joystick.Neutral;
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    joystick = Joystick.Left;
                    break;

                case ConsoleKey.RightArrow:
                    joystick = Joystick.Right;
                    break;
            }

            return (int)joystick;
        }

        private void OnComputerOutput(long a, long b, long c)
        {
            if (a == -1 && b == 0)
            {
                Screen.Score = (int)c;
            }
            else
            {
                var tile = (Tile)c;
                var location = new Point((int)a, (int)b);

                Screen.Draw(location, tile);

                if (tile == Tile.Ball)
                {
                    _ballPrediction.LogBall(location);
                }
                else if (tile == Tile.Paddle)
                {
                    _ballPrediction.SetPaddle(location);
                }
            }
        }
    }
}
