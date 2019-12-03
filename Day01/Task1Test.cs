using NUnit.Framework;

namespace Day01
{
    [TestFixture]
    public class Task1Test
    {
        [Test]
        [TestCase("12", 2)]
        [TestCase("14", 2)]
        [TestCase("1969", 654)]
        [TestCase("100756", 33583)]
        public void Solve(string input, int expected)
        {
            Assert.AreEqual(expected, Task1.Solve(new[] { input }));
        }
    }
}
