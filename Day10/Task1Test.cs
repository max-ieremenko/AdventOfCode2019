using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Day10
{
    [TestFixture]
    public class Task1Test
    {
        [Test]
        [TestCaseSource(nameof(GetTestCases))]
        public void Solve(string input, int expected)
        {
            var lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var actual = Task1.Solve(lines);

            Assert.AreEqual(expected, actual);
        }

        private static IEnumerable<TestCaseData> GetTestCases()
        {
            // 3,4; 8
            const string Input1 = @"
.#..#
.....
#####
....#
...##";

            // Best is 5,8 with 33 other asteroids detected
            const string Input2 = @"
......#.#.
#..#.#....
..#######.
.#.#.###..
.#..#.....
..#....#.#
#..#....#.
.##.#..###
##...#..#.
.#....####";

            // Best is 1,2 with 35 other asteroids detected
            const string Input3 = @"
#.#...#.#.
.###....#.
.#....#...
##.#.#.#.#
....#.#.#.
.##..###.#
..#...##..
..##....##
......#...
.####.###.";

            // Best is 6,3 with 41 other asteroids detected
            const string Input4 = @"
.#..#..###
####.###.#
....###.#.
..###.##.#
##.##.#.#.
....###..#
..#.#..#.#
#..#.#.###
.##...##.#
.....#.#..";

            // Best is 11,13 with 210 other asteroids detected
            const string Input5 = @"
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
                new TestCaseData(Input1, 8) { TestName = "case 1" },
                new TestCaseData(Input2, 33) { TestName = "case 2" },
                new TestCaseData(Input3, 35) { TestName = "case 3" },
                new TestCaseData(Input4, 41) { TestName = "case 4" },
                new TestCaseData(Input5, 210) { TestName = "case 5" }
            };
        }
    }
}
