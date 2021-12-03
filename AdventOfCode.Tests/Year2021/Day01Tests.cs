using AdventOfCode.Year2021;
using NUnit.Framework;

namespace AdventOfCode.Tests.Year2021
{
    public class Day01Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Year2021_Day1_Part1_ExampleIsCorrect()
        {
            var day1 = new Day01.Solution1(new[]
            {
                199,
                200,
                208,
                210,
                200,
                207,
                240,
                269,
                260,
                263
            });

            Assert.AreEqual(7, day1.Solve());
        }

        [Test]
        public void Year2021_Day1_Part2_ExampleIsCorrect()
        {
            var day1 = new Day01.Solution2(new[]
            {
                199,
                200,
                208,
                210,
                200,
                207,
                240,
                269,
                260,
                263
            });

            Assert.AreEqual(5, day1.Solve());
        }
    }
}