using AdventOfCode.Year2021;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace AdventOfCode.Tests.Year2021
{
    public class Day14Tests
    {
        private static string TestPolymerTemplate => "NNCB";

        private static Dictionary<string, string> TestPairInsertions => new Dictionary<string, string>()
        {
            { "CH", "B" },
            { "HH", "N" },
            { "CB", "H" },
            { "NH", "C" },
            { "HB", "C" },
            { "HC", "B" },
            { "HN", "C" },
            { "NN", "C" },
            { "BH", "H" },
            { "NC", "B" },
            { "NB", "B" },
            { "BN", "B" },
            { "BB", "N" },
            { "BC", "B" },
            { "CC", "N" },
            { "CN", "C" },
        };

        [Test]
        public void Year2021_Day14_Part1_ExampleIsCorrect()
        {
            var solution = new Day14.Solution1(TestPolymerTemplate, TestPairInsertions);

            Assert.AreEqual(1588, solution.Solve());
        }

        [Test]
        public void Year2021_Day14_Part2_ExampleIsCorrect()
        {
            var solution = new Day14.Solution2(TestPolymerTemplate, TestPairInsertions);

            Assert.AreEqual(2188189693529, solution.Solve());
        }

    }
}