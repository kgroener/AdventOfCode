using AdventOfCode.Year2021;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace AdventOfCode.Tests.Year2021
{
    public class Day15Tests
    {
        private static string[] TestCave => new[]
        {
            "1163751742",
            "1381373672",
            "2136511328",
            "3694931569",
            "7463417111",
            "1319128137",
            "1359912421",
            "3125421639",
            "1293138521",
            "2311944581",
        };

        private static string[] TestCave2 => new[]
        {
            "1999999999",
            "1999999999",
            "1911119999",
            "1119919999",
            "9999119999",
            "9999199999",
            "9999199999",
            "9999111199",
            "9999999199",
            "9999999111",
        };

        [Test]
        public void Year2021_Day15_Part1_ExampleIsCorrect()
        {
            var solution = new Day15.Solution1(TestCave);

            Assert.AreEqual(40, solution.Solve());
        }

        [Test]
        public void Year2021_Day15_Part1_Example2IsCorrect()
        {
            var solution = new Day15.Solution1(TestCave2);

            Assert.AreEqual(22, solution.Solve());
        }

        [Test]
        public void Year2021_Day15_Part2_ExampleIsCorrect()
        {
            var solution = new Day15.Solution2(TestCave);

            Assert.AreEqual(315, solution.Solve());
        }

        [Test]
        public void Year2021_Day15_Part2_SolutionIsCorrect()
        {
            var solution = new Day15.Solution2(Day15.Cave);

            Assert.AreEqual(2829, solution.Solve());
        }
    }
}