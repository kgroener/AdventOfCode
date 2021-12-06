using AdventOfCode.Year2021;
using NUnit.Framework;

namespace AdventOfCode.Tests.Year2021
{
    public class Day06Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Year2021_Day6_Part1_ExampleIsCorrect()
        {
            var solution = new Day06.Solution1(new []{ 3, 4, 3, 1, 2 });

            Assert.AreEqual(5934, solution.Solve());
        }

        [TestCase(18, ExpectedResult = 26)]
        [TestCase(80, ExpectedResult = 5934)]
        [TestCase(256, ExpectedResult = 26984457539)]
        public object Year2021_Day6_Part2_ExampleIsCorrect(int days)
        {
            var solution = new Day06.Solution2(new[] { 3, 4, 3, 1, 2 }, days);

            return solution.Solve();
        }

    }
}