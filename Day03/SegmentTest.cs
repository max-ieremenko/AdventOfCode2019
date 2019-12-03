using NUnit.Framework;

namespace Day03
{
    [TestFixture]
    public class SegmentTest
    {
        [Test]
        [TestCase(1, 5, 5, 5, 3, 6, 3, 0, 3, 5)] // I
        [TestCase(1, -5, 5, -5, 3, -6, 3, 0, 3, -5)] // II
        [TestCase(-1, -5, -5, -5, -3, -6, -3, 0, -3, -5)] // III
        [TestCase(-1, 5, -5, 5, -3, 6, -3, 0, -3, 5)] // IV
        public void IntersectWith(int a1X, int a1Y, int a2X, int a2Y, int b1X, int b1Y, int b2X, int b2Y, int intersectionX, int intersectionY)
        {
            var segment1 = new Segment(new Point(a1X, a1Y), new Point(a2X, a2Y));
            var segment2 = new Segment(new Point(b1X, b1Y), new Point(b2X, b2Y));

            Assert.IsTrue(segment1.TryIntersectWith(segment2, out var actual));
            Assert.AreEqual(new Point(intersectionX, intersectionY), actual);
        }

        [Test]
        [TestCase(1, 5, 5, 5, 1, 5, 5, 5)] // one line
        public void NotIntersectWith(int a1X, int a1Y, int a2X, int a2Y, int b1X, int b1Y, int b2X, int b2Y)
        {
            var segment1 = new Segment(new Point(a1X, a1Y), new Point(a2X, a2Y));
            var segment2 = new Segment(new Point(b1X, b1Y), new Point(b2X, b2Y));

            Assert.IsFalse(segment1.TryIntersectWith(segment2, out _));
        }
    }
}
