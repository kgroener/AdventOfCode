using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Helpers
{
    internal static class TextInterpreter
    {
        public static char GetCharFrom4x6PixelMapping(this IEnumerable<(int X, int Y)> dots)
        {
            return Letters[dots.Sum(d => 1 << d.Y << ((3-d.X) * 8))];
        }

        private static readonly IReadOnlyDictionary<int, char> Letters = new Dictionary<int, char>()
        {
            {0x3E09093E, 'A'},
            {0x3F25251A, 'B'},
            {0x1E212112, 'C'},
            {0x3F21211E, 'D'},
            {0x3F252521, 'E'},
            {0x3F050501, 'F'},
            {0x1E21293A, 'G'},
            {0x3F04043F, 'H'},
            {0x213F2100, 'I'},
            {0x1021211F, 'J'},
            {0x3F040A31, 'K'},
            {0x3F202020, 'L'},
            {0x3F02023F, 'M'},
            {0x3F02043F, 'N'},
            {0x1E21211E, 'O'},
            {0x3F090906, 'P'},
            {0x1E21112E, 'Q'},
            {0x3F091926, 'R'},
            {0x22252519, 'S'},
            {0x013F0101, 'T'},
            {0x1F20201F, 'U'},
            {0x0F10201F, 'V'},
            {0x3F10103F, 'W'},
            {0x3B04043B, 'X'},
            {0x03043807, 'Y'},
            {0x31292523, 'Z'},
        };
    }
}
