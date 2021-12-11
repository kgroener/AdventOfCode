using AdventOfCode.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2021
{
    internal class Day11 : IAdventDayPuzzle
    {
        public string Description => @"There are 100 octopuses arranged neatly in a 10 by 10 grid. Each octopus slowly gains energy over time and flashes brightly for a moment when its energy is full. Although your lights are off, maybe you could navigate through the cave without disturbing the octopuses if you could predict when the flashes of light will happen.";

        public DateTime Date => new DateTime(2021, 12, 11);

        private static int[][] Grid => new int[][]
        {
            new int[]{4,7,8,1,6,2,3,8,8,8},
            new int[]{1,7,8,4,1,5,6,1,1,4},
            new int[]{3,2,6,5,6,4,5,1,2,2},
            new int[]{4,3,7,1,5,5,1,4,1,4},
            new int[]{3,3,7,7,1,5,4,8,8,6},
            new int[]{7,8,8,2,3,1,4,4,5,5},
            new int[]{6,4,2,1,3,4,8,6,8,1},
            new int[]{7,1,7,5,4,2,4,2,8,7},
            new int[]{5,4,8,8,2,4,2,1,8,4},
            new int[]{2,4,4,8,5,6,8,2,6,1},
        };

        public IEnumerable<IAdventDaySolution> GetSolutions()
        {
            return new IAdventDaySolution[] { new Solution1(Grid, 100), new Solution2(Grid) };
        }

        internal class Solution1 : IAdventDaySolution
        {
            private int[][] _grid;
            private int _steps;

            public Solution1(int[][] grid, int steps)
            {
                _grid = grid;
                _steps = steps;
            }

            public string Description => @"Given the starting energy levels of the dumbo octopuses in your cavern, simulate 100 steps. How many total flashes are there after 100 steps?";

            public int Part => 1;

            public object Solve()
            {
                var currentStep = _grid.SelectMany((c, row) => c.Select((v, column) => (Value: v, Row: row, Column: column))).ToDictionary(k => (Row: k.Row, Column: k.Column), v => v.Value);
                int numberOfFlashes = 0;

                for (int step = 0; step < _steps; step++)
                {
                    bool newFlash = true;
                    HashSet<(int Row, int Column)> hasFlashed = new HashSet<(int Row, int Column)>();
                    bool ExecuteStepAtCoodinate((int Row, int Column) c) => !hasFlashed.Contains(c) && (currentStep.ContainsKey(c) ? ++currentStep[c] : 0) >= 9;

                    while (newFlash)
                    {
                        newFlash = false;

                        foreach (var c in currentStep.Where(kv => kv.Value >= 9 && !hasFlashed.Contains(kv.Key)).Select(kv => kv.Key).ToArray())
                        {
                            newFlash |= ExecuteStepAtCoodinate((c.Row - 1, c.Column - 1));
                            newFlash |= ExecuteStepAtCoodinate((c.Row - 1, c.Column - 0));
                            newFlash |= ExecuteStepAtCoodinate((c.Row - 1, c.Column + 1));
                            newFlash |= ExecuteStepAtCoodinate((c.Row - 0, c.Column - 1));
                            newFlash |= ExecuteStepAtCoodinate((c.Row - 0, c.Column + 1));
                            newFlash |= ExecuteStepAtCoodinate((c.Row + 1, c.Column - 1));
                            newFlash |= ExecuteStepAtCoodinate((c.Row + 1, c.Column - 0));
                            newFlash |= ExecuteStepAtCoodinate((c.Row + 1, c.Column + 1));
                            hasFlashed.Add(c);
                        }
                    }

                    currentStep = currentStep.ToDictionary(kv => kv.Key, kv => kv.Value >= 9 && ++numberOfFlashes > 0 ? 0 : kv.Value + 1);
                }

                return numberOfFlashes;
            }
        }

        internal class Solution2 : IAdventDaySolution
        {
            private int[][] _grid;

            public Solution2(int[][] grid)
            {
                _grid = grid;
            }

            public string Description => @"If you can calculate the exact moments when the octopuses will all flash simultaneously, you should be able to navigate through the cavern. What is the first step during which all octopuses flash?";

            public int Part => 1;

            public object Solve()
            {
                var currentStep = _grid.SelectMany((c, row) => c.Select((v, column) => (Value: v, Row: row, Column: column))).ToDictionary(k => (Row: k.Row, Column: k.Column), v => v.Value);

                int step = 0;
                while (true)
                {
                    step++;
                    bool newFlash = true;
                    HashSet<(int Row, int Column)> hasFlashed = new HashSet<(int Row, int Column)>();
                    bool ExecuteStepAtCoodinate((int Row, int Column) c) => !hasFlashed.Contains(c) && (currentStep.ContainsKey(c) ? ++currentStep[c] : 0) >= 9;

                    while (newFlash)
                    {
                        newFlash = false;

                        foreach (var c in currentStep.Where(kv => kv.Value >= 9 && !hasFlashed.Contains(kv.Key)).Select(kv => kv.Key).ToArray())
                        {
                            newFlash |= ExecuteStepAtCoodinate((c.Row - 1, c.Column - 1));
                            newFlash |= ExecuteStepAtCoodinate((c.Row - 1, c.Column - 0));
                            newFlash |= ExecuteStepAtCoodinate((c.Row - 1, c.Column + 1));
                            newFlash |= ExecuteStepAtCoodinate((c.Row - 0, c.Column - 1));
                            newFlash |= ExecuteStepAtCoodinate((c.Row - 0, c.Column + 1));
                            newFlash |= ExecuteStepAtCoodinate((c.Row + 1, c.Column - 1));
                            newFlash |= ExecuteStepAtCoodinate((c.Row + 1, c.Column - 0));
                            newFlash |= ExecuteStepAtCoodinate((c.Row + 1, c.Column + 1));
                            hasFlashed.Add(c);
                        }
                    }

                    currentStep = currentStep.ToDictionary(kv => kv.Key, kv => kv.Value >= 9 ? 0 : kv.Value + 1);

                    if (hasFlashed.Count == currentStep.Count)
                    {
                        break;
                    }
                }

                return step;
            }
        }
    }
}