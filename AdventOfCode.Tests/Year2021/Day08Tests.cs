using System;
using System.Diagnostics;
using AdventOfCode.Year2021;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AdventOfCode.Tests.Year2021
{
    public class Day08Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        private static string[] TestData => new[]
        {
            @"be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
            @"edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
            @"fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
            @"fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
            @"aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
            @"fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
            @"dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
            @"bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
            @"egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
            @"gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce",
        };

        [Test]
        public void Year2021_Day8_Part1_ExampleIsCorrect()
        {
            var solution = new Day08.Solution1(TestData);

            Assert.AreEqual(26, solution.Solve());
        }

        [Test]
        public void Year2021_Day8_Part2_ExampleIsCorrect()
        {
            var solution = new Day08.Solution2(TestData);

            Assert.AreEqual(61229, solution.Solve());
        }

        [Test]
        public void Year2021_Day8_Part2_SolutionIsCorrect()
        {
            var solution = new Day08.Solution2(Day08.Segments);

            Assert.AreEqual(1023686, solution.Solve());
        }

        [Test]
        [Ignore("Only for benchmark purposes")]
        public void Year2021_Day8_Part2_Benchmark()
        {
            var solution = new Day08.Solution2(Day08.Segments);

            var sw = Stopwatch.StartNew();
            for (int i = 0; i <= 1000; i++)
            {
                solution.Solve();
            }
            sw.Stop();

            Console.WriteLine($"Solution took an avg of {sw.Elapsed.TotalMilliseconds/1000} ms");
        }

    }
}