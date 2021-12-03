using AdventOfCode.Year2021;
using NUnit.Framework;

namespace AdventOfCode.Tests.Year2021
{
    public class Day03Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Year2021_Day3_Part1_ExampleIsCorrect()
        {
            var solution = new Day03.Solution1(new ushort[]
            {
                0b00100,
                0b11110,
                0b10110,
                0b10111,
                0b10101,
                0b01111,
                0b00111,
                0b11100,
                0b10000,
                0b11001,
                0b00010,
                0b01010,
            }, 5);

            Assert.AreEqual(198, solution.Solve());
        }

        [Test]
        public void Year2021_Day3_Part2_ExampleIsCorrect()
        {
            var solution = new Day03.Solution2(new ushort[]
            {
                0b00100,
                0b11110,
                0b10110,
                0b10111,
                0b10101,
                0b01111,
                0b00111,
                0b11100,
                0b10000,
                0b11001,
                0b00010,
                0b01010,
            }, 5);

            Assert.AreEqual(230, solution.Solve());
        }


    }
}