using NUnit.Framework;

namespace Day16
{
    [TestFixture]
    public class Task1Test
    {
        [Test]
        [TestCase("12345678", 4, "01029498")]
        [TestCase("80871224585914546619083218645595", 100, "24176176")]
        [TestCase("19617804207202209144916044189917", 100, "73745418")]
        [TestCase("69317163492948606335995924319873", 100, "52432133")]
        public void Solve(string input, int phases, string expected)
        {
            var actual = Task1.Solve(new[] { input }, phases);

            Assert.AreEqual(expected, actual);
        }
    }
}
