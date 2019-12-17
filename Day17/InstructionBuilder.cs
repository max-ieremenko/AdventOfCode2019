using System;
using System.Collections.Generic;

namespace Day17
{
    internal sealed class InstructionBuilder
    {
        private readonly IList<byte> _instructions = new List<byte>();

        public InstructionBuilder A()
        {
            _instructions.Add(65);
            _instructions.Add(44);
            return this;
        }

        public InstructionBuilder B()
        {
            _instructions.Add(66);
            _instructions.Add(44);
            return this;
        }

        public InstructionBuilder C()
        {
            _instructions.Add(67);
            _instructions.Add(44);
            return this;
        }

        public InstructionBuilder TurnRight()
        {
            _instructions.Add(82);
            _instructions.Add(44);
            return this;
        }

        public InstructionBuilder TurnLeft()
        {
            _instructions.Add(76);
            _instructions.Add(44);
            return this;
        }

        public InstructionBuilder Move(byte steps)
        {
            foreach (var i in steps.ToString())
            {
                _instructions.Add((byte)i);
            }

            _instructions.Add(44);
            return this;
        }

        public IList<byte> Build()
        {
            _instructions.RemoveAt(_instructions.Count - 1);
            
            if (_instructions.Count > 20)
            {
               throw new NotSupportedException();
            }

            _instructions.Add(10);
            return _instructions;
        }
    }
}
