using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AdventOfCode.Contracts;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var originalForegroundColor = Console.ForegroundColor;

            foreach (var puzzle in GetAdventDayPuzzles().OrderBy(a => a.Date))
            {
                Console.WriteLine($"==================================================");
                Console.WriteLine($"Puzzle of day {puzzle.Date.Day} {puzzle.Date.Year}");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(puzzle.Description);
                Console.ForegroundColor = originalForegroundColor;
                Console.WriteLine();
                Console.WriteLine();

                foreach (var solution in puzzle.GetSolutions().OrderBy(s => s.Part))
                {
                    var result = solution.Solve();

                    Console.WriteLine($"Part {solution.Part}:");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(solution.Description);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Solution: {result}");
                    Console.ForegroundColor = originalForegroundColor;
                    Console.WriteLine();
                }


                Console.WriteLine();
            }
        }

        private static IEnumerable<IAdventDayPuzzle> GetAdventDayPuzzles()
        {
            return Assembly.GetExecutingAssembly().DefinedTypes.Where(t => !t.IsInterface && typeof(IAdventDayPuzzle).IsAssignableFrom(t)).Select(Activator.CreateInstance)
                .Cast<IAdventDayPuzzle>();
        }
    }
}
