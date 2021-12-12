using AdventOfCode.Year2021;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2021
{
    public class Day12Tests
    {

        private static string[] TestData1 = new[]
        {
            "start-A",
            "start-b",
            "A-c",
            "A-b",
            "b-d",
            "A-end",
            "b-end"
        };

        private static string[] TestData2 = new[]
        {
            "dc-end",
            "HN-start",
            "start-kj",
            "dc-start",
            "dc-HN",
            "LN-dc",
            "HN-end",
            "kj-sa",
            "kj-HN",
            "kj-dc"
        };

        private static string[] TestData3 = new[]
        {
            "fs-end",
            "he-DX",
            "fs-he",
            "start-DX",
            "pj-DX",
            "end-zg",
            "zg-sl",
            "zg-pj",
            "pj-he",
            "RW-he",
            "fs-DX",
            "pj-RW",
            "zg-RW",
            "start-pj",
            "he-WI",
            "zg-he",
            "pj-fs",
            "start-RW"
        };

        [Test]
        public void Year2021_Day12_Part1_Example1IsCorrect()
        {
            var solution = new Day12.Solution1(TestData1);

            Assert.AreEqual(10, solution.Solve());
        }

        [Test]
        public void Year2021_Day12_Part1_Example2IsCorrect()
        {
            var solution = new Day12.Solution1(TestData2);

            Assert.AreEqual(19, solution.Solve());
        }

        [Test]
        public void Year2021_Day12_Part1_Example3IsCorrect()
        {
            var solution = new Day12.Solution1(TestData3);

            Assert.AreEqual(226, solution.Solve());
        }

        [Test]
        public void Year2021_Day12_Part2_Example1IsCorrect()
        {
            var solution = new Day12.Solution2(TestData1);

            Assert.AreEqual(36, solution.Solve());
        }

        [Test]
        public void Year2021_Day12_Part2_Example2IsCorrect()
        {
            var solution = new Day12.Solution2(TestData2);

            Assert.AreEqual(103, solution.Solve());
        }

        [Test]
        public void Year2021_Day12_Part2_Example3IsCorrect()
        {
            var solution = new Day12.Solution2(TestData3);

            Assert.AreEqual(3509, solution.Solve());
        }
    }
}