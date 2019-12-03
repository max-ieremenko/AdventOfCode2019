using NUnit.Framework;

namespace Day03
{
    [TestFixture]
    public class Task1Test
    {
        [Test]
        [TestCase("R8,U5,L5,D3", "U7,R6,D4,L4", 6)]
        public void Solve(string line1, string line2, int distance)
        {
            Assert.AreEqual(distance, Task1.Solve(new[] { line1, line2 }));
        }
    }
}
