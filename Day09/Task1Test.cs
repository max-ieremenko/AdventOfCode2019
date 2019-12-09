using NUnit.Framework;

namespace Day09
{
    [TestFixture]
    public class Task1Test
    {
        [Test]
        [TestCase("109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99", 109)]
        [TestCase("1102,34915192,34915192,7,4,7,99,0", 1219070632396864)]
        [TestCase("104,1125899906842624,99", 1125899906842624)]
        public void Solve(string input, long expected)
        {
            var actual = Task1.Solve(new[] { input });

            Assert.AreEqual(expected, actual);
        }
    }
}
