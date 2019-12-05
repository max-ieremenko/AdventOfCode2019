using System;
using System.Diagnostics;

namespace Day05
{
    internal sealed class Stack
    {
        public Stack(int[] memory)
        {
            Memory = memory;
        }

        public int[] Memory { get; }

        public int Pointer { get; private set; }

        public int GetOpCode()
        {
            var value = Memory[Pointer];
            value %= 100;

            return value;
        }

        public void SetPointer(int value)
        {
            Pointer = value;
        }

        public void Shift(int parameterCount)
        {
            Pointer += 1 + parameterCount;
        }

        public int ReadParameter1() => Memory[Pointer + 1];

        [DebuggerStepThrough]
        public int GetParameter1Value() => GetParameterValue(1);

        [DebuggerStepThrough]
        public int GetParameter2Value() => GetParameterValue(2);

        public int ReadParameter3() => Memory[Pointer + 3];

        private int GetParameterValue(int offset)
        {
            var opCode = Memory[Pointer];
            var mask = 100 * (int)Math.Pow(10, offset - 1);
            
            var mode = opCode / mask;
            mode %= 10;

            var value = Memory[Pointer + offset];
            if (mode == 0)
            {
                value = Memory[value];
            }
            else if (mode != 1)
            {
                throw new NotSupportedException();
            }

            return value;
        }
    }
}
