using NUnit.Framework;

namespace Day08
{
    [TestFixture]
    public class Task1Test
    {
        [Test]
        [TestCase("123456789012", 1)]
        public void Solve(string input, int expected)
        {
            var actual = Task1.Solve(new[] { input }, 3, 2);

            Assert.AreEqual(expected, actual);
        }
    }
}
