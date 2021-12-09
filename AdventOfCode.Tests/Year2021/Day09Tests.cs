using System;
using System.Diagnostics;
using AdventOfCode.Year2021;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AdventOfCode.Tests.Year2021
{
    public class Day09Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        private static int[,] TestData => new[,]
        {
            {2,1,9,9,9,4,3,2,1,0, },
            {3,9,8,7,8,9,4,9,2,1, },
            {9,8,5,6,7,8,9,8,9,2, },
            {8,7,6,7,8,9,6,7,8,9, },
            {9,8,9,9,9,6,5,6,7,8, },
        };

        [Test]
        public void Year2021_Day9_Part1_ExampleIsCorrect()
        {
            var solution = new Day09.Solution1(TestData);

            Assert.AreEqual(15, solution.Solve());
        }

        [Test]
        public void Year2021_Day9_Part2_ExampleIsCorrect()
        {
            var solution = new Day09.Solution2(TestData);

            Assert.AreEqual(1134, solution.Solve());
        }
    }
}