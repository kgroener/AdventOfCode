using AdventOfCode.Year2021;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2021
{
    public class Day11Tests
    {
        private static int[][] TestData = new int[][]
        {
            new int[]{5,4,8,3,1,4,3,2,2,3},
            new int[]{2,7,4,5,8,5,4,7,1,1},
            new int[]{5,2,6,4,5,5,6,1,7,3},
            new int[]{6,1,4,1,3,3,6,1,4,6},
            new int[]{6,3,5,7,3,8,5,4,7,8},
            new int[]{4,1,6,7,5,2,4,6,4,5},
            new int[]{2,1,7,6,8,4,1,7,2,1},
            new int[]{6,8,8,2,8,8,1,1,3,4},
            new int[]{4,8,4,6,8,4,8,5,5,4},
            new int[]{5,2,8,3,7,5,1,5,2,6},
        };

        [SetUp]
        public void Setup()
        {
        }

        [TestCase(10, ExpectedResult = 204)]
        [TestCase(100, ExpectedResult = 1656)]
        public object Year2021_Day11_Part1_ExampleIsCorrect(int steps)
        {
            var solution = new Day11.Solution1(TestData, steps);

            return solution.Solve();
        }

        [Test]
        public void Year2021_Day11_Part1_TinyExampleIsCorrect()
        {
            int[][] tinyData = new int[][]
            {
                new int[]{1,1,1,1,1},
                new int[]{1,9,9,9,1},
                new int[]{1,9,1,9,1},
                new int[]{1,9,9,9,1},
                new int[]{1,1,1,1,1},
            };

            var solution = new Day11.Solution1(tinyData, 2);

            Assert.AreEqual(9, solution.Solve());
        }

        [Test]
        public void Year2021_Day11_Part2_ExampleIsCorrect()
        {
            var solution = new Day11.Solution2(TestData);

            Assert.AreEqual(195, solution.Solve());
        }
    }
}