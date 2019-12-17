using System;

namespace Day17
{
    internal sealed class IntCodeComputer
    {
        public Stack Stack { get; }

        public IntCodeComputer(long[] memory)
        {
            Stack = new Stack(memory);
        }

        public Action<byte> OnOutput { get; set; }

        public Func<int> OnInput { get; set; }

        public void Run()
        {
            var relativeBase = 0L;
            while (true)
            {
                switch (Stack.GetOpCode())
                {
                    case 1:
                        Add(relativeBase);
                        break;

                    case 2:
                        Multiply(relativeBase);
                        break;

                    case 3:
                    {
                        var value = OnInput();
                        InputInstruction(relativeBase, value);
                    }
                        break;

                    case 4:
                    {
                        var value = Output(relativeBase);
                        OnOutput((byte)value);
                    }
                        break;

                    case 5:
                        JumpIfTrue(relativeBase);
                        break;

                    case 6:
                        JumpIfFalse(relativeBase);
                        break;

                    case 7:
                        LessThan(relativeBase);
                        break;

                    case 8:
                        Equal(relativeBase);
                        break;

                    case 9:
                        RelativeBase(ref relativeBase);
                        break;

                    case 99:
                        return;

                    default:
                        throw new NotSupportedException();
                }
            }
        }

        private void Add(long relativeBase)
        {
            var parameter1 = Stack.GetParameter1Value(relativeBase);
            var parameter2 = Stack.GetParameter2Value(relativeBase);
            Stack.WriteParameter3Value(relativeBase, parameter1 + parameter2);
            Stack.Shift(3);
        }

        private void Multiply(long relativeBase)
        {
            var parameter1 = Stack.GetParameter1Value(relativeBase);
            var parameter2 = Stack.GetParameter2Value(relativeBase);
            Stack.WriteParameter3Value(relativeBase, parameter1 * parameter2);
            Stack.Shift(3);
        }

        private void InputInstruction(long relativeBase, int systemId)
        {
            Stack.WriteParameter1Value(relativeBase, systemId);
            Stack.Shift(1);
        }

        private long Output(long relativeBase)
        {
            var value = Stack.GetParameter1Value(relativeBase);
            Stack.Shift(1);

            return value;
        }

        private void JumpIfTrue(long relativeBase)
        {
            var parameter1 = Stack.GetParameter1Value(relativeBase);
            if (parameter1 != 0)
            {
                var parameter2 = Stack.GetParameter2Value(relativeBase);
                Stack.SetPointer(parameter2);
            }
            else
            {
                Stack.Shift(2);
            }
        }

        private void JumpIfFalse(long relativeBase)
        {
            var parameter1 = Stack.GetParameter1Value(relativeBase);
            if (parameter1 == 0)
            {
                var parameter2 = Stack.GetParameter2Value(relativeBase);
                Stack.SetPointer(parameter2);
            }
            else
            {
                Stack.Shift(2);
            }
        }

        private void LessThan(long relativeBase)
        {
            var parameter1 = Stack.GetParameter1Value(relativeBase);
            var parameter2 = Stack.GetParameter2Value(relativeBase);
            Stack.WriteParameter3Value(relativeBase, parameter1 < parameter2 ? 1 : 0);
            Stack.Shift(3);
        }

        private void Equal(long relativeBase)
        {
            var parameter1 = Stack.GetParameter1Value(relativeBase);
            var parameter2 = Stack.GetParameter2Value(relativeBase);
            Stack.WriteParameter3Value(relativeBase, parameter1 == parameter2 ? 1 : 0);
            Stack.Shift(3);
        }

        private void RelativeBase(ref long value)
        {
            var parameter1 = Stack.GetParameter1Value(value);
            value = value + parameter1;
            Stack.Shift(1);
        }
    }
}
