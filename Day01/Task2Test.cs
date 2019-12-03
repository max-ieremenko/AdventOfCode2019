using NUnit.Framework;

namespace Day01
{
    [TestFixture]
    public class Task2Test
    {
        [Test]
        [TestCase("12", 2)]
        [TestCase("1969", 966)]
        [TestCase("100756", 50346)]
        public void Solve(string input, int expected)
        {
            Assert.AreEqual(expected, Task2.Solve(new[] { input }));
        }
    }
}
