using NUnit.Framework;

namespace Day16
{
    [TestFixture]
    public class Task2Test
    {
        [Test]
        [TestCase("03036732577212944063491565474664", "84462026")]
        [TestCase("02935109699940807407585447034323", "78725270")]
        [TestCase("03081770884921959731165446850517", "53553731")]
        public void Solve(string input, string expected)
        {
            var actual = Task2.Solve(new[] { input });

            Assert.AreEqual(expected, actual);
        }
    }
}
