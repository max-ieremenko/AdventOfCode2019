using System;

namespace Day05
{
    internal static class OpCodes
    {
        public static void Add(this Stack stack)
        {
            var parameter1 = stack.GetParameter1Value();
            var parameter2 = stack.GetParameter2Value();
            var parameter3 = stack.ReadParameter3();
            stack.Memory[parameter3] = parameter1 + parameter2;
            stack.Shift(3);
        }

        public static void Multiply(this Stack stack)
        {
            var parameter1 = stack.GetParameter1Value();
            var parameter2 = stack.GetParameter2Value();
            var parameter3 = stack.ReadParameter3();
            stack.Memory[parameter3] = parameter1 * parameter2;
            stack.Shift(3);
        }

        public static void InputInstruction(this Stack stack, int systemId)
        {
            var parameter = stack.ReadParameter1();
            stack.Memory[parameter] = systemId;
            stack.Shift(1);
        }

        public static void Output(this Stack stack, ref int value)
        {
            if (value != 0)
            {
                throw new InvalidOperationException();
            }

            value = stack.GetParameter1Value();
            stack.Shift(1);
        }

        public static void JumpIfTrue(this Stack stack)
        {
            var parameter1 = stack.GetParameter1Value();
            if (parameter1 != 0)
            {
                var parameter2 = stack.GetParameter2Value();
                stack.SetPointer(parameter2);
            }
            else
            {
                stack.Shift(2);
            }
        }

        public static void JumpIfFalse(this Stack stack)
        {
            var parameter1 = stack.GetParameter1Value();
            if (parameter1 == 0)
            {
                var parameter2 = stack.GetParameter2Value();
                stack.SetPointer(parameter2);
            }
            else
            {
                stack.Shift(2);
            }
        }

        public static void LessThan(this Stack stack)
        {
            var parameter1 = stack.GetParameter1Value();
            var parameter2 = stack.GetParameter2Value();
            var parameter3 = stack.ReadParameter3();
            stack.Memory[parameter3] = parameter1 < parameter2 ? 1 : 0;
            stack.Shift(3);
        }

        public static void Equal(this Stack stack)
        {
            var parameter1 = stack.GetParameter1Value();
            var parameter2 = stack.GetParameter2Value();
            var parameter3 = stack.ReadParameter3();
            stack.Memory[parameter3] = parameter1 == parameter2 ? 1 : 0;
            stack.Shift(3);
        }
    }
}
