using System.Linq;
using AdventOfCode.Year2021;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    public class Day2Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Year2021_Day2_Part1_ExampleIsCorrect()
        {
            var solution = new Day2.Solution1(new[]
            {
                ("forward", 5),
                ("down", 5),
                ("forward", 8),
                ("up", 3),
                ("down", 8),
                ("forward", 2)
            });

            Assert.AreEqual(150, solution.Solve());
        }

        [Test]
        public void Year2021_Day2_Part2_ExampleIsCorrect()
        {
            var solution = new Day2.Solution2(new[]
            {
                ("forward", 5),
                ("down", 5),
                ("forward", 8),
                ("up", 3),
                ("down", 8),
                ("forward", 2)
            });

            Assert.AreEqual(900, solution.Solve());
        }
    }
}