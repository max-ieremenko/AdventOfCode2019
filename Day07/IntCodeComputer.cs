using System;
using System.Collections.Generic;

namespace Day07
{
    internal sealed class IntCodeComputer
    {
        private readonly int _phaseSetting;
        private readonly Stack _stack;

        private int _instructionIndex;

        public IntCodeComputer(int[] memory, int phaseSetting)
        {
            _phaseSetting = phaseSetting;
            _stack = new Stack(memory);
        }

        public Action<int> OnOutput { get; set; }

        public static IEnumerable<int[]> GetPhaseSettings(int min, int max)
        {
            for (var i1 = min; i1 <= max; i1++)
            for (var i2 = min; i2 <= max; i2++)
            {
                if (i1 == i2)
                {
                    continue;
                }

                for (var i3 = min; i3 <= max; i3++)
                {
                    if (i1 == i3 || i2 == i3)
                    {
                        continue;
                    }

                    for (var i4 = min; i4 <= max; i4++)
                    {
                        if (i1 == i4 || i2 == i4 || i3 == i4)
                        {
                            continue;
                        }

                        for (var i5 = min; i5 <= max; i5++)
                        {
                            if (i1 == i5 || i2 == i5 || i3 == i5 || i4 == i5)
                            {
                                continue;
                            }

                            yield return new[] { i1, i2, i3, i4, i5 };
                        }
                    }
                }
            }
        }

        public void Run(int input)
        {
            if (_instructionIndex != 0)
            {
                _instructionIndex = 1;
            }

            while (true)
            {
                switch (_stack.GetOpCode())
                {
                    case 1:
                        Add();
                        break;

                    case 2:
                        Multiply();
                        break;

                    case 3:
                        if (_instructionIndex == 0)
                        {
                            InputInstruction(_phaseSetting);
                        }
                        else if (_instructionIndex == 1)
                        {
                            InputInstruction(input);
                        }
                        else
                        {
                            throw new InvalidOperationException();
                        }

                        _instructionIndex++;
                        break;

                    case 4:
                        OnOutput(Output());
                        break;

                    case 5:
                        JumpIfTrue();
                        break;

                    case 6:
                        JumpIfFalse();
                        break;

                    case 7:
                        LessThan();
                        break;

                    case 8:
                        Equal();
                        break;

                    case 99:
                        return;

                    default:
                        throw new NotSupportedException(string.Format("OpCode {0} is not supported.", _stack.GetOpCode()));
                }
            }
        }

        private void Add()
        {
            var parameter1 = _stack.GetParameter1Value();
            var parameter2 = _stack.GetParameter2Value();
            var parameter3 = _stack.ReadParameter3();
            _stack.Memory[parameter3] = parameter1 + parameter2;
            _stack.Shift(3);
        }

        private void Multiply()
        {
            var parameter1 = _stack.GetParameter1Value();
            var parameter2 = _stack.GetParameter2Value();
            var parameter3 = _stack.ReadParameter3();
            _stack.Memory[parameter3] = parameter1 * parameter2;
            _stack.Shift(3);
        }

        private void InputInstruction(int systemId)
        {
            var parameter = _stack.ReadParameter1();
            _stack.Memory[parameter] = systemId;
            _stack.Shift(1);
        }

        private int Output()
        {
            var value = _stack.GetParameter1Value();
            _stack.Shift(1);
            return value;
        }

        private void JumpIfTrue()
        {
            var parameter1 = _stack.GetParameter1Value();
            if (parameter1 != 0)
            {
                var parameter2 = _stack.GetParameter2Value();
                _stack.SetPointer(parameter2);
            }
            else
            {
                _stack.Shift(2);
            }
        }

        private void JumpIfFalse()
        {
            var parameter1 = _stack.GetParameter1Value();
            if (parameter1 == 0)
            {
                var parameter2 = _stack.GetParameter2Value();
                _stack.SetPointer(parameter2);
            }
            else
            {
                _stack.Shift(2);
            }
        }

        private void LessThan()
        {
            var parameter1 = _stack.GetParameter1Value();
            var parameter2 = _stack.GetParameter2Value();
            var parameter3 = _stack.ReadParameter3();
            _stack.Memory[parameter3] = parameter1 < parameter2 ? 1 : 0;
            _stack.Shift(3);
        }

        private void Equal()
        {
            var parameter1 = _stack.GetParameter1Value();
            var parameter2 = _stack.GetParameter2Value();
            var parameter3 = _stack.ReadParameter3();
            _stack.Memory[parameter3] = parameter1 == parameter2 ? 1 : 0;
            _stack.Shift(3);
        }
    }
}
