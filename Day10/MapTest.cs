using NUnit.Framework;

namespace Day10
{
    [TestFixture]
    public class MapTest
    {
        [Test]
        [TestCase(8, 1, 0)]
        [TestCase(9, 2, 45)]
        [TestCase(10, 3, 90)]
        [TestCase(9, 4, 135)]
        [TestCase(8, 5, 180)]
        [TestCase(7, 4, 225)]
        [TestCase(6, 3, 270)]
        [TestCase(7, 2, 315)]
        public void CalculateClockwiseAngle(int targetX, int targetY, int angle)
        {
            var center = new Point(8, 3);

            var actual = Map.CalculateClockwiseAngle(center, new Point(targetX, targetY));

            Assert.AreEqual(angle, actual);
        }
    }
}
