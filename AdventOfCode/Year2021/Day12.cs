using AdventOfCode.Contracts;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2021
{
    internal class Day12 : IAdventDayPuzzle
    {
        public string Description => @"Your goal is to find the number of distinct paths that start at start, end at end, and don't visit small caves more than once.";

        public DateTime Date => new DateTime(2021, 12, 12);

        public IEnumerable<IAdventDaySolution> GetSolutions()
        {
            return new IAdventDaySolution[] { new Solution1(Connections), new Solution2(Connections)};
        }

        internal class Solution1 : IAdventDaySolution
        {
            private readonly string[] _connections;

            public Solution1(string[] connections)
            {
                _connections = connections;
            }
            public string Description => @"How many paths through this cave system are there that visit small caves at most once?";

            public int Part => 1;

            public object Solve()
            {
                ConcurrentDictionary<string, HashSet<string>> connectionMapping = new ConcurrentDictionary<string, HashSet<string>>();
                foreach (var connection in _connections)
                {
                    var splittedConnection = connection.Split('-');
                    connectionMapping.GetOrAdd(splittedConnection[0], (s) => new HashSet<string>()).Add(splittedConnection[1]);
                    connectionMapping.GetOrAdd(splittedConnection[1], (s) => new HashSet<string>()).Add(splittedConnection[0]);
                }

                var paths = GeneratePaths(connectionMapping, new List<string>() { "start" }, "start");

                return paths.Count();
            }

            private IEnumerable<IEnumerable<string>> GeneratePaths(IDictionary<string, HashSet<string>> connections, IEnumerable<string> path, string node)
            {
                if (node == "end")
                {
                    return new[] { path.ToArray() };
                }

                List<IEnumerable<string>> paths = new List<IEnumerable<string>>();

                foreach (var c in connections[node])
                {
                    if (char.IsLower(c[0]) && path.Contains(c))
                    {
                        continue;
                    }

                    paths.AddRange(GeneratePaths(connections, path.Append(c), c));
                }

                return paths;
            }
        }

        internal class Solution2 : IAdventDaySolution
        {
            private readonly string[] _connections;

            public Solution2(string[] connections)
            {
                _connections = connections;
            }
            public string Description => @"Given these new rules, how many paths through this cave system are there?";

            public int Part => 2;

            public object Solve()
            {
                ConcurrentDictionary<string, HashSet<string>> connectionMapping = new ConcurrentDictionary<string, HashSet<string>>();
                foreach (var connection in _connections)
                {
                    var splittedConnection = connection.Split('-');
                    connectionMapping.GetOrAdd(splittedConnection[0], (s) => new HashSet<string>()).Add(splittedConnection[1]);
                    connectionMapping.GetOrAdd(splittedConnection[1], (s) => new HashSet<string>()).Add(splittedConnection[0]);
                }

                var paths = GeneratePaths(connectionMapping, new List<string>() { "start" }, "start");

                return paths.Count();
            }

            private IEnumerable<IEnumerable<string>> GeneratePaths(IDictionary<string, HashSet<string>> connections, IEnumerable<string> path, string node, bool hasVisitedDuplicateSmallCave = false)
            {
                if (node == "end")
                {
                    return new[] { path.ToArray() };
                }

                List<IEnumerable<string>> paths = new List<IEnumerable<string>>();

                foreach (var c in connections[node])
                {
                    if (char.IsLower(c[0]) && path.Contains(c))
                    {
                        if (!hasVisitedDuplicateSmallCave && c != "start")
                        {
                            paths.AddRange(GeneratePaths(connections, path.Append(c), c, true));
                        }

                        continue;
                    }

                    paths.AddRange(GeneratePaths(connections, path.Append(c), c, hasVisitedDuplicateSmallCave));
                }

                return paths;
            }
        }

        private static string[] Connections => new[]
        {
            "start-qs",
            "qs-jz",
            "start-lm",
            "qb-QV",
            "QV-dr",
            "QV-end",
            "ni-qb",
            "VH-jz",
            "qs-lm",
            "qb-end",
            "dr-fu",
            "jz-lm",
            "start-VH",
            "QV-jz",
            "VH-qs",
            "lm-dr",
            "dr-ni",
            "ni-jz",
            "lm-QV",
            "jz-dr",
            "ni-end",
            "VH-dr",
            "VH-ni",
            "qb-HE"
        };
    }
}
