using NUnit.Framework;

namespace Day04
{
    [TestFixture]
    public class NumbersTest
    {
        [Test]
        [TestCase(321, 4, new[] { 0, 3, 2, 1 })]
        [TestCase(321, 3, new[] { 3, 2, 1 })]
        public void Split(int value, int maxSize, int[] expected)
        {
            Assert.AreEqual(expected, Numbers.Split(value, maxSize));
        }

        [Test]
        [TestCase(new[] { 1, 1, 1 }, new[] { 1, 1, 1 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
        [TestCase(new[] { 8, 2, 2 }, new[] { 8, 8, 8 })]
        [TestCase(new[] { 8, 2, 8 }, new[] { 8, 8, 8 })]
        [TestCase(new[] { 8, 2, 9 }, new[] { 8, 8, 8 })]
        [TestCase(new[] { 8, 8, 9 }, new[] { 8, 8, 9 })]
        [TestCase(new[] { 9, 8, 9 }, new[] { 9, 9, 9 })]
        public void Normalize(int[] value, int[] expected)
        {
            Numbers.Normalize(value);
            Assert.AreEqual(expected, value);
        }

        [Test]
        [TestCase(new[] { 1, 2 }, new[] { 1, 2 }, true)]
        [TestCase(new[] { 1, 1 }, new[] { 1, 2 }, true)]
        [TestCase(new[] { 1, 1 }, new[] { 0, 2 }, false)]
        [TestCase(new[] { 1, 3 }, new[] { 1, 2 }, false)]
        [TestCase(new[] { 2, 0 }, new[] { 1, 2 }, false)]
        public void LessOrEqual(int[] x, int[] y, bool expected)
        {
            Assert.LessOrEqual(expected, Numbers.LessOrEqual(x, y));
        }

        [Test]
        [TestCase(new[] { 5, 5, 5, 5 }, new[] { 5, 5, 5, 6 })]
        [TestCase(new[] { 5, 5, 5, 9 }, new[] { 5, 5, 6, 6 })]
        [TestCase(new[] { 5, 5, 9, 9 }, new[] { 5, 6, 6, 6 })]
        [TestCase(new[] { 5, 9, 9, 9 }, new[] { 6, 6, 6, 6 })]
        [TestCase(new[] { 9, 9, 9, 9 }, new[] { 10, 9, 9, 9 })]
        public void FindNext(int[] normalizedValue, int[] expected)
        {
            Numbers.FindNext(normalizedValue);
            Assert.AreEqual(expected, normalizedValue);
        }
    }
}
