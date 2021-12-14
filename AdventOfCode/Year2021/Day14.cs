using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode.Contracts;

namespace AdventOfCode.Year2021
{
    internal class Day14 : IAdventDayPuzzle
    {
        public string Description => @"The submarine manual contains instructions for finding the optimal polymer formula; specifically, it offers a polymer template and a list of pair insertion rules (your puzzle input). You just need to work out what polymer would result after repeating the pair insertion process a few times.";
        public DateTime Date => new DateTime(2021, 12, 14);
        public IEnumerable<IAdventDaySolution> GetSolutions()
        {
            return new IAdventDaySolution[] { new Solution1(PolymerTemplate, PairInsertions), new Solution2(PolymerTemplate, PairInsertions) };
        }

        internal class Solution1 : IAdventDaySolution
        {
            private readonly string _polymerTemplate;
            private readonly IReadOnlyDictionary<string, string> _insertions;

            public Solution1(string polymerTemplate, IReadOnlyDictionary<string, string> pairInsertions)
            {
                _polymerTemplate = polymerTemplate;
                _insertions = pairInsertions;
            }

            public string Description => @"Apply 10 steps of pair insertion to the polymer template and find the most and least common elements in the result. What do you get if you take the quantity of the most common element and subtract the quantity of the least common element?";
            public int Part => 1;
            public object Solve()
            {
                var characters = Enumerable.Range(0, 10)
                    .Aggregate(_polymerTemplate, (polymer, i) =>
                    {
                        return polymer
                            .Skip(1)
                            .Aggregate(
                                polymer[0].ToString(),
                                (a, b) => _insertions.TryGetValue($"{a[^1]}{b}", out string insertion) ? $"{a}{insertion}{b}" : $"{a}{b}");
                    })
                    .GroupBy(c => c, s => s, (c, s) => s.Count())
                    .ToArray();

                return characters.Max() - characters.Min();
            }
        }

        internal class Solution2 : IAdventDaySolution
        {
            private readonly string _polymerTemplate;
            private readonly IReadOnlyDictionary<string, string> _insertions;

            public Solution2(string polymerTemplate, IReadOnlyDictionary<string, string> pairInsertions)
            {
                _polymerTemplate = polymerTemplate;
                _insertions = pairInsertions;
            }

            public string Description => @"Apply 10 steps of pair insertion to the polymer template and find the most and least common elements in the result. What do you get if you take the quantity of the most common element and subtract the quantity of the least common element?";
            public int Part => 1;
            public object Solve()
            {
                var pairs = _polymerTemplate
                    .Skip(1)
                    .Select((c, i) => $"{_polymerTemplate[i]}{c}")
                    .GroupBy(s => s)
                    .ToDictionary(s => s.Key, s => s.LongCount());

                var characterCounts = _polymerTemplate.GroupBy(c => c).ToDictionary(k => k.Key.ToString(), v => v.LongCount());

                for (var i = 0; i < 40; i++)
                {
                    var newPairs = new Dictionary<string, long>();

                    foreach ((string key, long value) in pairs)
                    {
                        if (!_insertions.TryGetValue(key, out var insertionCharacter))
                        {
                            newPairs[key] = value;
                            continue;
                        }

                        var key1 = $"{key[0]}{insertionCharacter}";
                        var key2 = $"{insertionCharacter}{key[1]}";

                        newPairs[key1] = (newPairs.TryGetValue(key1, out var v1) ? v1 + value : value);
                        newPairs[key2] = (newPairs.TryGetValue(key2, out var v2) ? v2 + value : value);

                        characterCounts[insertionCharacter] = characterCounts.TryGetValue(insertionCharacter, out var count) ? count + value : value;
                    }

                    pairs = newPairs;
                }

                return characterCounts.Max(c => c.Value) - characterCounts.Min(c => c.Value);
            }
        }


        internal static string PolymerTemplate => @"PPFCHPFNCKOKOSBVCFPP";

        internal static Dictionary<string, string> PairInsertions => new Dictionary<string, string>()
        {
            { "VC", "N" },
            { "SC", "H" },
            { "CK", "P" },
            { "OK", "O" },
            { "KV", "O" },
            { "HS", "B" },
            { "OH", "O" },
            { "VN", "F" },
            { "FS", "S" },
            { "ON", "B" },
            { "OS", "H" },
            { "PC", "B" },
            { "BP", "O" },
            { "OO", "N" },
            { "BF", "K" },
            { "CN", "B" },
            { "FK", "F" },
            { "NP", "K" },
            { "KK", "H" },
            { "CB", "S" },
            { "CV", "K" },
            { "VS", "F" },
            { "SF", "N" },
            { "KB", "H" },
            { "KN", "F" },
            { "CP", "V" },
            { "BO", "N" },
            { "SS", "O" },
            { "HF", "H" },
            { "NN", "F" },
            { "PP", "O" },
            { "VP", "H" },
            { "BB", "K" },
            { "VB", "N" },
            { "OF", "N" },
            { "SH", "S" },
            { "PO", "F" },
            { "OC", "S" },
            { "NS", "C" },
            { "FH", "N" },
            { "FP", "C" },
            { "SO", "P" },
            { "VK", "C" },
            { "HP", "O" },
            { "PV", "S" },
            { "HN", "K" },
            { "NB", "C" },
            { "NV", "K" },
            { "NK", "B" },
            { "FN", "C" },
            { "VV", "N" },
            { "BN", "N" },
            { "BH", "S" },
            { "FO", "V" },
            { "PK", "N" },
            { "PS", "O" },
            { "CO", "K" },
            { "NO", "K" },
            { "SV", "C" },
            { "KO", "V" },
            { "HC", "B" },
            { "BC", "N" },
            { "PB", "C" },
            { "SK", "S" },
            { "FV", "K" },
            { "HO", "O" },
            { "CF", "O" },
            { "HB", "P" },
            { "SP", "N" },
            { "VH", "P" },
            { "NC", "K" },
            { "KC", "B" },
            { "OV", "P" },
            { "BK", "F" },
            { "FB", "F" },
            { "FF", "V" },
            { "CS", "F" },
            { "CC", "H" },
            { "SB", "C" },
            { "VO", "V" },
            { "VF", "O" },
            { "KP", "N" },
            { "HV", "H" },
            { "PF", "H" },
            { "KH", "P" },
            { "KS", "S" },
            { "BS", "H" },
            { "PH", "S" },
            { "SN", "K" },
            { "HK", "P" },
            { "FC", "N" },
            { "PN", "S" },
            { "HH", "N" },
            { "OB", "P" },
            { "BV", "S" },
            { "KF", "N" },
            { "OP", "H" },
            { "NF", "V" },
            { "CH", "K" },
            { "NH", "P" },
        };
    }
}
