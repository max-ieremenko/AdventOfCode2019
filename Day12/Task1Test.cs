using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Day12
{
    [TestFixture]
    public class Task1Test
    {
        [Test]
        [TestCaseSource(nameof(GetSolveTestCases))]
        public static void Solve(IEnumerable<string> input, int stepsCount, int expected)
        {
            var actual = Task1.Solve(input, stepsCount);

            Assert.AreEqual(expected, actual);
        }

        private static IEnumerable<TestCaseData> GetSolveTestCases()
        {
            const string Input1 = @"
<x=-1, y=0, z=2>
<x=2, y=-10, z=-7>
<x=4, y=-8, z=8>
<x=3, y=5, z=-1>";

            yield return new TestCaseData(Input1.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries), 10, 179)
            {
                TestName = "case 1"
            };

            const string Input2 = @"
<x=-8, y=-10, z=0>
<x=5, y=5, z=10>
<x=2, y=-7, z=3>
<x=9, y=-8, z=-3>";

            yield return new TestCaseData(Input2.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries), 100, 1940)
            {
                TestName = "case 2"
            };
        }
    }
}
