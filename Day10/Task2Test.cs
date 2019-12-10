using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Day10
{
    [TestFixture]
    public class Task2Test
    {
        [Test]
        [TestCaseSource(nameof(GetTestCases))]
        public void Solve(string input, int bet, int expected)
        {
            var lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var actual = Task2.Solve(lines, bet);

            Assert.AreEqual(expected, actual);
        }

        private static IEnumerable<TestCaseData> GetTestCases()
        {
            const string Input1 = @"
.#....#####...#..
##...##.#####..##
##...#...#.#####.
..#.....X...###..
..#.#.....#....##";

            const string Input2 = @"
.#..##.###...#######
##.############..##.
.#.######.########.#
.###.#######.####.#.
#####.##.#.##.###.##
..#####..#.#########
####################
#.####....###.#.#.##
##.#################
#####.##.###..####..
..######..##.#######
####.##.####...##..#
.#####..#.######.###
##...#.##########...
#.##########.#######
.####.#.###.###.#.##
....##.##.###..#####
.#.#.###########.###
#.#.#.#####.####.###
###.##.####.##.#..##";

            return new[]
            {
                new TestCaseData(Input1, 9, 15 * 100 + 1) { TestName = "case 1" },
                new TestCaseData(Input2, 200, 8 * 100 + 2) { TestName = "case 2" }
            };
        }
    }
}
