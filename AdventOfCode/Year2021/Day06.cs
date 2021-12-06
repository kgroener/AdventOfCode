using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Contracts;

namespace AdventOfCode.Year2021
{
    class Day06 : IAdventDayPuzzle
    {
        private const int TIME_TO_MATURE = 9;
        private const int OFFSPRING_INTERVAL = 7;

        public string Description =>
            @"A massive school of glowing lanternfish swims past. They must spawn quickly to reach such large numbers - maybe exponentially quickly? You should model their growth rate to be sure.";

        public DateTime Date => new DateTime(2021, 12, 6);
        public IEnumerable<IAdventDaySolution> GetSolutions()
        {
            return new IAdventDaySolution[] { new Solution1(Population), new Solution2(Population) };
        }

        internal class Solution1 : IAdventDaySolution
        {
            private readonly int[] _population;

            public Solution1(int[] population)
            {
                _population = population;
            }

            public string Description => @"Find a way to simulate lanternfish. How many lanternfish would there be after 80 days?";
            public int Part => 1;
            public object Solve()
            {
                return Enumerable.Range(0, 80)
                    .Aggregate(_population, (p, i) => p.SelectMany(f => f == 0 ? new[] { OFFSPRING_INTERVAL-1, TIME_TO_MATURE-1 } : new[] { f - 1 }).ToArray())
                    .Length;
            }
        }

        internal class Solution2 : IAdventDaySolution
        {
            private readonly int[] _population;
            private readonly ConcurrentDictionary<int, long> _offspringMapping = new ConcurrentDictionary<int, long>();
            private readonly int _days;

            public Solution2(int[] population, int days = 256)
            {
                _population = population;
                _days = days;
            }

            public string Description => @"Find a way to simulate lanternfish. How many lanternfish would there be after 256 days?";
            public int Part => 2;
            public object Solve()
            {
                return _population.AsParallel().Sum(GetAmountOfOffspring) + _population.Length;
            }

            private long GetAmountOfOffspring(int days)
            {
                return _offspringMapping.GetOrAdd(days, (d) =>
                {
                    long offspring = 1 + ((_days - (d + 1)) / OFFSPRING_INTERVAL);
                    for (int day = d + TIME_TO_MATURE; day < _days; day += OFFSPRING_INTERVAL)
                    {
                        offspring += GetAmountOfOffspring(day);
                    }

                    return offspring;
                });
            }
        }

        private static int[] Population => new[]
        {
            1, 2, 4, 5, 5, 5, 2, 1, 3, 1, 4, 3, 2, 1, 5, 5, 1, 2, 3, 4, 4, 1, 2, 3, 2, 1, 4, 4, 1, 5, 5, 1, 3, 4, 4, 4, 1, 2, 2, 5, 1, 5, 5, 3, 2, 3, 1, 1, 3, 5, 1, 1, 2, 4, 2, 3,
            1, 1, 2, 1, 3, 1, 2, 1, 1, 2, 1, 2, 2, 1, 1, 1, 1, 5, 4, 5, 2, 1, 3, 2, 4, 1, 1, 3, 4, 1, 4, 1, 5, 1, 4, 1, 5, 3, 2, 3, 2, 2, 4, 4, 3, 3, 4, 3, 4, 4, 3, 4, 5, 1, 2, 5,
            2, 1, 5, 5, 1, 3, 4, 2, 2, 4, 2, 2, 1, 3, 2, 5, 5, 1, 3, 3, 4, 3, 5, 3, 5, 5, 4, 5, 1, 1, 4, 1, 4, 5, 1, 1, 1, 4, 1, 1, 4, 2, 1, 4, 1, 3, 4, 4, 3, 1, 2, 2, 4, 3, 3, 2,
            2, 2, 3, 5, 5, 2, 3, 1, 5, 1, 1, 1, 1, 3, 1, 4, 1, 4, 1, 2, 5, 3, 2, 4, 4, 1, 3, 1, 1, 1, 3, 4, 4, 1, 1, 2, 1, 4, 3, 4, 2, 2, 3, 2, 4, 3, 1, 5, 1, 3, 1, 4, 5, 5, 3, 5,
            1, 3, 5, 5, 4, 2, 3, 2, 4, 1, 3, 2, 2, 2, 1, 3, 4, 2, 5, 2, 5, 3, 5, 5, 1, 1, 1, 2, 2, 3, 1, 4, 4, 4, 5, 4, 5, 5, 1, 4, 5, 5, 4, 1, 1, 5, 3, 3, 1, 4, 1, 3, 1, 1, 4, 1,
            5, 2, 3, 2, 3, 1, 2, 2, 2, 1, 1, 5, 1, 4, 5, 2, 4, 2, 2, 3
        };
    }
}
