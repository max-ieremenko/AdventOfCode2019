using NUnit.Framework;

namespace Day02
{
    [TestFixture]
    public class Task1Test
    {
        [Test]
        [TestCase("1,9,10,3,2,3,11,0,99,30,40,50", 3500)]
        [TestCase("1,0,0,0,99", 2)]
        [TestCase("2,3,0,3,99", 2)]
        [TestCase("2,4,4,5,99,0", 2)]
        [TestCase("1,1,1,4,99,5,6,0,99", 30)]
        public void Solve(string input, int expected)
        {
            Assert.AreEqual(expected, Task1.Solve(new[] { input }, true));
        }
    }
}
