using System;
using System.Diagnostics;
using AdventOfCode.Year2021;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AdventOfCode.Tests.Year2021
{
    public class Day10Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        private static string[] TestData = new string[]
        {
            "[({(<(())[]>[[{[]{<()<>>",
            "[(()[<>])]({[<{<<[]>>("  ,
            "{([(<{}[<>[]}>{[]{[(<()>",
            "(((({<>}<{<{<>}{[]{[]{}" ,
            "[[<[([]))<([[{}[[()]]]"  ,
            "[{[{({}]{}}([{[{{{}}([]" ,
            "{<[[]]>}<{[{[{[]{()[[[]" ,
            "[<(<(<(<{}))><([]([]()"  ,
            "<{([([[(<>()){}]>(<<{{"  ,
            "<{([{{}}[<[[[<>{}]]]>[]]",
        };

        [Test]
        public void Year2021_Day10_Part1_ExampleIsCorrect()
        {
            var solution = new Day10.Solution1(TestData);

            Assert.AreEqual(26397, solution.Solve());
        }

        [Test]
        public void Year2021_Day10_Part2_ExampleIsCorrect()
        {
            var solution = new Day10.Solution2(TestData);

            Assert.AreEqual(288957, solution.Solve());
        }

        [Test]
        public void Year2021_Day10_Part2_SolutionIsCorrect()
        {
            var solution = new Day10.Solution2(Day10.Chunks);

            Assert.AreEqual(1605968119, solution.Solve());
        }
    }
}