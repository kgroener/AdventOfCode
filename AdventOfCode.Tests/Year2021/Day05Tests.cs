using AdventOfCode.Year2021;
using NUnit.Framework;

namespace AdventOfCode.Tests.Year2021
{
    public class Day05Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Year2021_Day5_Part1_ExampleIsCorrect()
        {
            var solution = new Day05.Solution1(new (int X1, int Y1, int X2, int Y2)[] {
                (0,9,5,9),
                (8,0,0,8),
                (9,4,3,4),
                (2,2,2,1),
                (7,0,7,4),
                (6,4,2,0),
                (0,9,2,9),
                (3,4,1,4),
                (0,0,8,8),
                (5,5,8,2),
            });

            Assert.AreEqual(5, solution.Solve());
        }

        [Test]
        public void Year2021_Day5_Part2_ExampleIsCorrect()
        {
            var solution = new Day05.Solution2(new (int X1, int Y1, int X2, int Y2)[] {
                (0,9,5,9),
                (8,0,0,8),
                (9,4,3,4),
                (2,2,2,1),
                (7,0,7,4),
                (6,4,2,0),
                (0,9,2,9),
                (3,4,1,4),
                (0,0,8,8),
                (5,5,8,2),
            });

            Assert.AreEqual(12, solution.Solve());
        }

    }
}