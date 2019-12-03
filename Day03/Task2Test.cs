using NUnit.Framework;

namespace Day03
{
    [TestFixture]
    public class Task2Test
    {
        [Test]
        [TestCase("R8,U5,L5,D3", "U7,R6,D4,L4", 30)]
        public void Solve(string line1, string line2, int distance)
        {
            Assert.AreEqual(distance, Task2.Solve(new[] { line1, line2 }));
        }
    }
}
