using AdventOfCode.Year2021;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace AdventOfCode.Tests.Year2021
{
    public class Day13Tests
    {
        private static (int X, int Y)[] TestDots => new (int X, int Y)[]
        {
            (6, 10),
            (0, 14),
            (9, 10),
            (0, 3),
            (10, 4),
            (4, 11),
            (6, 0),
            (6, 12),
            (4, 1),
            (0, 13),
            (10, 12),
            (3, 4),
            (3, 0),
            (8, 4),
            (1, 10),
            (2, 14),
            (8, 10),
            (9, 0),
        };

        private static (int X, int Y)[] TestInstructions => new (int X, int Y)[]
        {
            (0, 7),
            (5, 0),
        };

        [Test]
        public void Year2021_Day13_Part1_ExampleIsCorrect()
        {
            var solution = new Day13.Solution1(TestDots, TestInstructions[0]);

            Assert.AreEqual(17, solution.Solve());
        }

        [Test]
        public void Year2021_Day13_Part2_ExampleIsCorrect()
        {
            var solution = new Day13.Solution2(Day13.Dots, Day13.FoldInstructions);

            Assert.AreEqual("PZEHRAER", solution.Solve());
        }
    }
}