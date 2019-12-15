using System;
using System.Diagnostics;

namespace Day15
{
    internal sealed class Stack
    {
        private long[] _memory;

        public Stack(long[] memory)
        {
            _memory = memory;
        }

        public long Pointer { get; private set; }

        public int GetOpCode()
        {
            var value = _memory[Pointer];
            value %= 100;

            return (int)value;
        }

        public void SetPointer(long value)
        {
            EnsureCapacity(value);
            Pointer = value;
        }

        public void Shift(int parameterCount)
        {
            var value = Pointer + 1 + parameterCount;
            EnsureCapacity(value);

            Pointer = value;
        }

        public void WriteParameter1Value(long relativeBase, long value) => WriteParameterValue(1, relativeBase, value);

        public void WriteParameter3Value(long relativeBase, long value) => WriteParameterValue(3, relativeBase, value);

        [DebuggerStepThrough]
        public long GetParameter1Value(long relativeBase) => GetParameterValue(1, relativeBase);

        [DebuggerStepThrough]
        public long GetParameter2Value(long relativeBase) => GetParameterValue(2, relativeBase);

        private int GetParameterMode(int offset)
        {
            var opCode = (int)_memory[Pointer];
            var mask = 100 * (int)Math.Pow(10, offset - 1);

            return (opCode / mask) % 10;
        }

        private void WriteParameterValue(int offset, long relativeBase, long value)
        {
            var mode = GetParameterMode(offset);

            var index = _memory[Pointer + offset];
            if (mode == 2)
            {
                index += relativeBase;
            }
            else if (mode != 0)
            {
                throw new InvalidOperationException();
            }

            EnsureCapacity(index);
            _memory[index] = value;
        }

        private long GetParameterValue(int offset, long relativeBase)
        {
            var mode = GetParameterMode(offset);
            var value = _memory[Pointer + offset];

            if (mode == 0)
            {
                EnsureCapacity(value);
                value = _memory[value];
            }
            else if (mode == 2)
            {
                EnsureCapacity(relativeBase + value);
                value = _memory[relativeBase + value];
            }
            else if (mode != 1)
            {
                throw new NotSupportedException();
            }

            return value;
        }

        private void EnsureCapacity(long position)
        {
            if (position < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(position));
            }

            if (position < _memory.Length)
            {
                return;
            }

            var length = position + 1;
            if (length != (int)length)
            {
            }

            Array.Resize(ref _memory, (int)length);
        }
    }
}
