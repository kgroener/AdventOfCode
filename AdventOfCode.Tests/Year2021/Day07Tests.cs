using AdventOfCode.Year2021;
using NUnit.Framework;

namespace AdventOfCode.Tests.Year2021
{
    public class Day07Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Year2021_Day7_Part1_ExampleIsCorrect()
        {
            var solution = new Day07.Solution1(new []{ 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 });

            Assert.AreEqual(37, solution.Solve());
        }


        [Test]
        public void Year2021_Day7_Part1_PuzzleIsCorrect()
        {
            var solution = new Day07.Solution1(Day07.Positions);

            Assert.AreEqual(329389, solution.Solve());
        }

        [Test]
        public void Year2021_Day7_Part2_ExampleIsCorrect()
        {
            var solution = new Day07.Solution2(new[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 });

            Assert.AreEqual(168, solution.Solve());
        }

        [Test]
        public void Year2021_Day7_Part2_PuzzleIsCorrect()
        {
            var solution = new Day07.Solution2(Day07.Positions);

            Assert.AreEqual(86397080, solution.Solve());
        }
    }
}