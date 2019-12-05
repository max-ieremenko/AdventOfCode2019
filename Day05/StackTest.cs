using NUnit.Framework;

namespace Day05
{
    [TestFixture]
    public class StackTest
    {
        [Test]
        public void GetImmediateParameterValue()
        {
            var stack = new Stack(new[] { 1101, 1, 238, 225 });

            Assert.AreEqual(1, stack.GetOpCode());
            Assert.AreEqual(1, stack.GetParameter1Value());
            Assert.AreEqual(238, stack.GetParameter2Value());
            Assert.AreEqual(225, stack.ReadParameter3());
        }
    }
}
