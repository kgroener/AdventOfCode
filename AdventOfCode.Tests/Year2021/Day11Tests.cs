using AdventOfCode.Year2021;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2021
{
    public class Day11Tests
    {
        public static Dictionary<int, int[][]> TestCaseData = new Dictionary<int, int[][]>()
        {
            { 10, new int[][]
                {
                    new int[]{0, 4, 8, 1, 1, 1, 2, 9, 7, 6},
                    new int[]{0, 0, 3, 1, 1, 1, 2, 0, 0, 9},
                    new int[]{0, 0, 4, 1, 1, 1, 2, 5, 0, 4},
                    new int[]{0, 0, 8, 1, 1, 1, 1, 4, 0, 6},
                    new int[]{0, 0, 9, 9, 1, 1, 1, 3, 0, 6},
                    new int[]{0, 0, 9, 3, 5, 1, 1, 2, 3, 3},
                    new int[]{0, 4, 4, 2, 3, 6, 1, 1, 3, 0},
                    new int[]{5, 5, 3, 2, 2, 5, 2, 3, 5, 0},
                    new int[]{0, 5, 3, 2, 2, 5, 0, 6, 0, 0},
                    new int[]{0, 0, 3, 2, 2, 4, 0, 0, 0, 0},
                }
            },
            { 20, new int[][]
                {
                    new int[]{3, 9, 3, 6, 5, 5, 6, 4, 5, 2},
                    new int[]{5, 6, 8, 6, 5, 5, 6, 8, 0, 6},
                    new int[]{4, 4, 9, 6, 5, 5, 5, 6, 9, 0},
                    new int[]{4, 4, 4, 8, 6, 5, 5, 5, 8, 0},
                    new int[]{4, 4, 5, 6, 8, 6, 5, 5, 7, 0},
                    new int[]{5, 6, 8, 0, 0, 8, 6, 5, 7, 7},
                    new int[]{7, 0, 0, 0, 0, 0, 9, 8, 9, 6},
                    new int[]{0, 0, 0, 0, 0, 0, 0, 3, 4, 4},
                    new int[]{6, 0, 0, 0, 0, 0, 0, 3, 6, 4},
                    new int[]{4, 6, 0, 0, 0, 0, 9, 5, 4, 3},
                }
            },
            { 30, new int[][]
                {
                    new int[]{0, 6, 4, 3, 3, 3, 4, 1, 1, 8},
                    new int[]{4, 2, 5, 3, 3, 3, 4, 6, 1, 1},
                    new int[]{3, 3, 7, 4, 3, 3, 3, 4, 5, 8},
                    new int[]{2, 2, 2, 5, 3, 3, 3, 3, 3, 7},
                    new int[]{2, 2, 2, 9, 3, 3, 3, 3, 3, 8},
                    new int[]{2, 2, 7, 6, 7, 3, 3, 3, 3, 3},
                    new int[]{2, 7, 5, 4, 5, 7, 4, 5, 6, 5},
                    new int[]{5, 5, 4, 4, 4, 5, 8, 5, 1, 1},
                    new int[]{9, 4, 4, 4, 4, 4, 7, 1, 1, 1},
                    new int[]{7, 9, 4, 4, 4, 4, 6, 1, 1, 9},
                }
            },
            { 40, new int[][]
                {
                    new int[]{6, 2, 1, 1, 1, 1, 1, 9, 8, 1},
                    new int[]{0, 4, 2, 1, 1, 1, 1, 1, 1, 9},
                    new int[]{0, 0, 4, 2, 1, 1, 1, 1, 1, 5},
                    new int[]{0, 0, 0, 3, 1, 1, 1, 1, 1, 5},
                    new int[]{0, 0, 0, 3, 1, 1, 1, 1, 1, 6},
                    new int[]{0, 0, 6, 5, 6, 1, 1, 1, 1, 1},
                    new int[]{0, 5, 3, 2, 3, 5, 1, 1, 1, 1},
                    new int[]{3, 3, 2, 2, 2, 3, 4, 5, 9, 7},
                    new int[]{2, 2, 2, 2, 2, 2, 2, 9, 7, 6},
                    new int[]{2, 2, 2, 2, 2, 2, 2, 7, 6, 2},
                }
            },
            { 50, new int[][]
                {
                    new int[]{9, 6, 5, 5, 5, 5, 6, 4, 4, 7},
                    new int[]{4, 8, 6, 5, 5, 5, 6, 8, 0, 5},
                    new int[]{4, 4, 8, 6, 5, 5, 5, 6, 9, 0},
                    new int[]{4, 4, 5, 8, 6, 5, 5, 5, 8, 0},
                    new int[]{4, 5, 7, 4, 8, 6, 5, 5, 7, 0},
                    new int[]{5, 7, 0, 0, 0, 8, 6, 5, 6, 6},
                    new int[]{6, 0, 0, 0, 0, 0, 9, 8, 8, 7},
                    new int[]{8, 0, 0, 0, 0, 0, 0, 5, 3, 3},
                    new int[]{6, 8, 0, 0, 0, 0, 0, 6, 3, 3},
                    new int[]{5, 6, 8, 0, 0, 0, 0, 5, 3, 8},
                }
            },
            { 60, new int[][]
                {
                    new int[]{2, 5, 3, 3, 3, 3, 4, 2, 0, 0},
                    new int[]{2, 7, 4, 3, 3, 3, 4, 6, 4, 0},
                    new int[]{2, 2, 6, 4, 3, 3, 3, 4, 5, 8},
                    new int[]{2, 2, 2, 5, 3, 3, 3, 3, 3, 7},
                    new int[]{2, 2, 2, 5, 3, 3, 3, 3, 3, 8},
                    new int[]{2, 2, 8, 7, 8, 3, 3, 3, 3, 3},
                    new int[]{3, 8, 5, 4, 5, 7, 3, 4, 5, 5},
                    new int[]{1, 8, 5, 4, 4, 5, 8, 6, 1, 1},
                    new int[]{1, 1, 7, 5, 4, 4, 7, 1, 1, 1},
                    new int[]{1, 1, 1, 5, 4, 4, 6, 1, 1, 1},
                }
            },
            { 70, new int[][]
                {
                    new int[]{8, 2, 1, 1, 1, 1, 1, 1, 6, 4},
                    new int[]{0, 4, 2, 1, 1, 1, 1, 1, 6, 6},
                    new int[]{0, 0, 4, 2, 1, 1, 1, 1, 1, 4},
                    new int[]{0, 0, 0, 4, 2, 1, 1, 1, 1, 5},
                    new int[]{0, 0, 0, 0, 2, 1, 1, 1, 1, 6},
                    new int[]{0, 0, 6, 5, 6, 1, 1, 1, 1, 1},
                    new int[]{0, 5, 3, 2, 3, 5, 1, 1, 1, 1},
                    new int[]{7, 3, 2, 2, 2, 3, 5, 1, 1, 7},
                    new int[]{5, 7, 2, 2, 2, 2, 3, 4, 7, 5},
                    new int[]{4, 5, 7, 2, 2, 2, 2, 7, 5, 4},
                }
            },
            { 80, new int[][]
                {
                    new int[]{1, 7, 5, 5, 5, 5, 5, 6, 9, 7},
                    new int[]{5, 9, 6, 5, 5, 5, 5, 6, 0, 9},
                    new int[]{4, 4, 8, 6, 5, 5, 5, 6, 8, 0},
                    new int[]{4, 4, 5, 8, 6, 5, 5, 5, 8, 0},
                    new int[]{4, 5, 7, 0, 8, 6, 5, 5, 7, 0},
                    new int[]{5, 7, 0, 0, 0, 8, 6, 5, 6, 6},
                    new int[]{7, 0, 0, 0, 0, 0, 8, 6, 6, 6},
                    new int[]{0, 0, 0, 0, 0, 0, 0, 9, 9, 0},
                    new int[]{0, 0, 0, 0, 0, 0, 0, 8, 0, 0},
                    new int[]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                }
            },
            { 90, new int[][]
                {
                    new int[]{7, 4, 3, 3, 3, 3, 3, 5, 2, 2},
                    new int[]{2, 6, 4, 3, 3, 3, 3, 5, 2, 2},
                    new int[]{2, 2, 6, 4, 3, 3, 3, 4, 5, 8},
                    new int[]{2, 2, 2, 6, 4, 3, 3, 3, 3, 7},
                    new int[]{2, 2, 2, 2, 4, 3, 3, 3, 3, 8},
                    new int[]{2, 2, 8, 7, 8, 3, 3, 3, 3, 3},
                    new int[]{2, 8, 5, 4, 5, 7, 3, 3, 3, 3},
                    new int[]{4, 8, 5, 4, 4, 5, 8, 3, 3, 3},
                    new int[]{3, 3, 8, 7, 7, 7, 9, 3, 3, 3},
                    new int[]{3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                }
            },
            { 100, new int[][]
                {
                    new int[]{0, 3, 9, 7, 6, 6, 6, 8, 6, 6},
                    new int[]{0, 7, 4, 9, 7, 6, 6, 9, 1, 8},
                    new int[]{0, 0, 5, 3, 9, 7, 6, 9, 3, 3},
                    new int[]{0, 0, 0, 4, 2, 9, 7, 8, 2, 2},
                    new int[]{0, 0, 0, 4, 2, 2, 9, 8, 9, 2},
                    new int[]{0, 0, 5, 3, 2, 2, 2, 8, 7, 7},
                    new int[]{0, 5, 3, 2, 2, 2, 2, 9, 6, 6},
                    new int[]{9, 3, 2, 2, 2, 2, 8, 9, 6, 6},
                    new int[]{7, 9, 2, 2, 2, 8, 6, 8, 6, 6},
                    new int[]{6, 7, 8, 9, 9, 9, 8, 7, 6, 6},
                }
            },
        };

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