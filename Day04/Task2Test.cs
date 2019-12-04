using NUnit.Framework;

namespace Day04
{
    [TestFixture]
    public class Task2Test
    {
        [Test]
        [TestCase(new[] { 1, 1, 2, 2, 3, 3 }, true)]
        [TestCase(new[] { 1, 2, 3, 4, 4, 4 }, false)]
        [TestCase(new[] { 1, 1, 1, 1, 2, 2 }, true)]
        [TestCase(new[] { 1, 2, 3 }, false)]
        [TestCase(new[] { 1, 2, 2 }, true)]
        public void MeetsCriteria(int[] value, bool expected)
        {
            Assert.AreEqual(expected, Task2.MeetsCriteria(value));
        }
    }
}
