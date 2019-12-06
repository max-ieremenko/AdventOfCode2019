using System.Collections.Generic;
using NUnit.Framework;

namespace Day06
{
    [TestFixture]
    public class Task1Test
    {
        [Test]
        [TestCase(new[] { "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L" }, 42)]
        public void Solve(IEnumerable<string> input, int expected)
        {
            Assert.AreEqual(expected, Task1.Solve(input));
        }
    }
}
