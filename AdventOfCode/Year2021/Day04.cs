using AdventOfCode.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2021
{
    internal class Day04 : IAdventDayPuzzle
    {
        public string Description => @"You're already almost 1.5km (almost a mile) below the surface of the ocean, already so deep that you can't see any sunlight. What you can see, however, is a giant squid that has attached itself to the outside of your submarine.

Maybe it wants to play bingo?";

        public DateTime Date => new DateTime(2021, 12, 4);

        public IEnumerable<IAdventDaySolution> GetSolutions()
        {
            return new IAdventDaySolution[] { new Solution1(Boards, Numbers), new Solution2(Boards, Numbers) };
        }

        internal class Solution1 : IAdventDaySolution
        {
            private readonly int[][][] _boards;
            private readonly int[] _numbers;

            public Solution1(int[][][] boards, int[] numbers)
            {
                _boards = boards;
                _numbers = numbers;
            }

            public string Description => @"To guarantee victory against the giant squid, figure out which board will win first. What will your final score be if you choose that board?";

            public int Part => 1;

            public object Solve()
            {
                var numberIndexes = _numbers.Select((v,i) => (Index: i, Value: v)).ToDictionary(kv => kv.Value, kv => kv.Index);

                var fastestBoard = _boards.Select((b) => (
                    Board: b,
                    NumberIndexForWin: Math.Min(
                        // Get first win for rows
                        b
                        .Where(r => r.Intersect(_numbers).Count() == r.Length)
                        .Min(r => r.Max(v => numberIndexes[v])),
                        // Get first win for columns
                        Enumerable
                        .Range(0, b.Length)
                        .Select(i => b.Select(r => r[i]).ToArray())
                        .Where(c => c.Intersect(_numbers).Count() == c.Length)
                        .Min(r => r.Max(v => numberIndexes[v])))
                    ))
                    .Aggregate((a,b) => a.NumberIndexForWin < b.NumberIndexForWin ? a: b);

                return fastestBoard.Board.SelectMany(b => b).Except(_numbers.Take(fastestBoard.NumberIndexForWin+1)).Sum() * _numbers.ElementAt(fastestBoard.NumberIndexForWin);
            }
        }

        internal class Solution2 : IAdventDaySolution
        {
            private readonly int[][][] _boards;
            private readonly int[] _numbers;

            public Solution2(int[][][] boards, int[] numbers)
            {
                _boards = boards;
                _numbers = numbers;
            }

            public string Description => @"You aren't sure how many bingo boards a giant squid could play at once, so rather than waste time counting its arms, the safe thing to do is to figure out which board will win last and choose that one. That way, no matter which boards it picks, it will win for sure.";

            public int Part => 2;

            public object Solve()
            {
                var numberIndexes = _numbers.Select((v, i) => (Index: i, Value: v)).ToDictionary(kv => kv.Value, kv => kv.Index);

                var fastestBoard = _boards.Select((b) => (
                    Board: b,
                    NumberIndexForWin: Math.Min(
                        // Get first win for rows
                        b
                        .Where(r => r.Intersect(_numbers).Count() == r.Length)
                        .Min(r => r.Max(v => numberIndexes[v])),
                        // Get first win for columns
                        Enumerable
                        .Range(0, b.Length)
                        .Select(i => b.Select(r => r[i]).ToArray())
                        .Where(c => c.Intersect(_numbers).Count() == c.Length)
                        .Min(r => r.Max(v => numberIndexes[v])))
                    ))
                    .Aggregate((a, b) => a.NumberIndexForWin > b.NumberIndexForWin ? a : b);

                return fastestBoard.Board.SelectMany(b => b).Except(_numbers.Take(fastestBoard.NumberIndexForWin + 1)).Sum() * _numbers.ElementAt(fastestBoard.NumberIndexForWin);
            }
        }

        private readonly int[] Numbers = { 28, 82, 77, 88, 95, 55, 62, 21, 99, 14, 30, 9, 97, 92, 94, 3, 60, 22, 18, 86, 78, 71, 61, 43, 79, 33, 65, 81, 26, 49, 47, 51, 0, 89, 57, 75, 42, 35, 80, 1, 46, 83, 39, 53, 40, 36, 54, 70, 76, 38, 50, 23, 67, 2, 20, 87, 37, 66, 84, 24, 98, 4, 7, 12, 44, 10, 29, 5, 48, 59, 32, 41, 90, 17, 56, 85, 96, 93, 27, 74, 45, 25, 15, 6, 69, 16, 19, 8, 31, 13, 64, 63, 34, 73, 58, 91, 11, 68, 72, 52 };

        private readonly int[][][] Boards =
        {
            new int[][] {
                new int[] { 31, 88, 71, 23, 61 },
                new int[] { 4, 9, 14, 93, 51 },
                new int[] { 52, 50, 6, 34, 55 },
                new int[] { 70, 64, 78, 65, 95 },
                new int[] { 12, 22, 41, 60, 57 },
            },
            new int[][] {
                new int[] { 44, 54, 26, 63, 18 },
                new int[] { 32, 74, 99, 52, 2 },
                new int[] { 5, 29, 13, 28, 41 },
                new int[] { 60, 69, 53, 61, 25 },
                new int[] { 49, 59, 70, 46, 48 },

            },
            new int[][] {
                new int[] { 26, 91, 1, 23, 6 },
                new int[] { 51, 58, 79, 57, 33 },
                new int[] { 67, 50, 14, 81, 48 },
                new int[] { 64, 66, 49, 46, 9 },
                new int[] { 16, 73, 39, 74, 68 },

            },
            new int[][] {
                new int[] { 41, 31, 12, 14, 82 },
                new int[] { 4, 97, 76, 49, 15 },
                new int[] { 50, 43, 72, 22, 24 },
                new int[] { 53, 56, 78, 33, 52 },
                new int[] { 65, 68, 26, 0, 94 },

            },
            new int[][] {
                new int[] { 73, 21, 23, 33, 57 },
                new int[] { 53, 10, 40, 35, 0 },
                new int[] { 41, 12, 71, 19, 47 },
                new int[] { 49, 25, 76, 78, 13 },
                new int[] { 80, 92, 22, 26, 29 },
            },
            new int[][] {

                new int[] { 97, 11, 43, 46, 52 },
                new int[] { 51, 58, 36, 47, 84 },
                new int[] { 75, 69, 88, 85, 57 },
                new int[] { 67, 94, 61, 0, 70 },
                new int[] { 65, 42, 16, 44, 1 },
            },
            new int[][] {

                new int[] { 64, 70, 99, 58, 56 },
                new int[] { 18, 81, 34, 59, 45 },
                new int[] { 26, 71, 67, 47, 68 },
                new int[] { 78, 17, 87, 91, 0 },
                new int[] { 49, 98, 53, 35, 9 },
            },
            new int[][] {

                new int[] { 76, 75, 5, 27, 25 },
                new int[] { 17, 92, 42, 49, 28 },
                new int[] { 34, 78, 26, 71, 30 },
                new int[] { 11, 31, 41, 14, 8 },
                new int[] { 50, 59, 62, 93, 80 },
            },
            new int[][] {

                new int[] { 3, 27, 23, 11, 49 },
                new int[] { 56, 93, 22, 70, 94 },
                new int[] { 24, 74, 43, 21, 7 },
                new int[] { 33, 28, 41, 96, 9 },
                new int[] { 42, 10, 80, 78, 5 },
            },
            new int[][] {

                new int[] { 51, 64, 12, 79, 31 },
                new int[] { 73, 66, 43, 70, 84 },
                new int[] { 86, 44, 81, 60, 85 },
                new int[] { 16, 48, 6, 83, 34 },
                new int[] { 25, 98, 36, 50, 19 },
            },
            new int[][] {

                new int[] { 28, 15, 30, 79, 59 },
                new int[] { 40, 76, 39, 98, 12 },
                new int[] { 4, 96, 93, 91, 47 },
                new int[] { 19, 75, 89, 73, 17 },
                new int[] { 72, 64, 92, 58, 74 },
            },
            new int[][] {

                new int[] { 24, 32, 84, 57, 55 },
                new int[] { 91, 33, 92, 71, 8 },
                new int[] { 30, 40, 78, 61, 70 },
                new int[] { 79, 35, 34, 75, 23 },
                new int[] { 38, 7, 81, 27, 76 },
            },
            new int[][] {

                new int[] { 8, 93, 11, 94, 39 },
                new int[] { 21, 13, 98, 83, 10 },
                new int[] { 38, 59, 46, 24, 75 },
                new int[] { 74, 60, 34, 89, 42 },
                new int[] { 36, 69, 0, 40, 67 },
            },
            new int[][] {

                new int[] { 21, 69, 28, 98, 13 },
                new int[] { 44, 79, 7, 3, 20 },
                new int[] { 19, 36, 82, 9, 43 },
                new int[] { 45, 11, 99, 97, 76 },
                new int[] { 2, 17, 16, 46, 66 },
            },
            new int[][] {

                new int[] { 73, 20, 2, 63, 47 },
                new int[] { 6, 96, 16, 46, 17 },
                new int[] { 66, 82, 14, 29, 41 },
                new int[] { 49, 30, 71, 8, 68 },
                new int[] { 44, 18, 56, 26, 74 },
            },
            new int[][] {

                new int[] { 42, 32, 40, 2, 9 },
                new int[] { 20, 10, 95, 31, 67 },
                new int[] { 98, 96, 15, 39, 58 },
                new int[] { 13, 52, 99, 82, 89 },
                new int[] { 23, 18, 87, 60, 5 },
            },
            new int[][] {

                new int[] { 92, 32, 45, 26, 80 },
                new int[] { 59, 22, 23, 98, 24 },
                new int[] { 79, 65, 99, 15, 58 },
                new int[] { 83, 86, 70, 17, 63 },
                new int[] { 51, 46, 82, 78, 52 },
            },
            new int[][] {

                new int[] { 3, 73, 20, 53, 63 },
                new int[] { 26, 97, 39, 94, 55 },
                new int[] { 1, 27, 98, 62, 15 },
                new int[] { 75, 78, 99, 87, 43 },
                new int[] { 90, 96, 0, 89, 67 },
            },
            new int[][] {

                new int[] { 85, 76, 48, 16, 49 },
                new int[] { 51, 67, 79, 68, 18 },
                new int[] { 20, 38, 44, 57, 46 },
                new int[] { 19, 29, 39, 60, 23 },
                new int[] { 26, 47, 78, 17, 83 },
            },
            new int[][] {

                new int[] { 32, 11, 47, 56, 84 },
                new int[] { 54, 66, 38, 77, 74 },
                new int[] { 72, 0, 30, 71, 80 },
                new int[] { 10, 86, 94, 23, 65 },
                new int[] { 81, 99, 60, 43, 83 },
            },
            new int[][] {

                new int[] { 7, 78, 69, 75, 41 },
                new int[] { 0, 70, 21, 45, 29 },
                new int[] { 40, 51, 88, 28, 35 },
                new int[] { 97, 46, 44, 98, 37 },
                new int[] { 93, 36, 89, 81, 18 },
            },
            new int[][] {

                new int[] { 33, 13, 84, 68, 72 },
                new int[] { 92, 76, 1, 40, 19 },
                new int[] { 86, 75, 34, 98, 82 },
                new int[] { 8, 3, 4, 28, 0 },
                new int[] { 91, 60, 27, 81, 39 },
            },
            new int[][] {

                new int[] { 76, 32, 92, 65, 70 },
                new int[] { 88, 45, 37, 44, 99 },
                new int[] { 38, 95, 72, 6, 19 },
                new int[] { 34, 71, 54, 41, 33 },
                new int[] { 47, 20, 84, 98, 73 },
            },
            new int[][] {

                new int[] { 85, 46, 4, 89, 69 },
                new int[] { 50, 62, 30, 64, 59 },
                new int[] { 9, 21, 54, 55, 13 },
                new int[] { 66, 29, 17, 96, 6 },
                new int[] { 22, 97, 44, 87, 90 },
            },
            new int[][] {

                new int[] { 72, 53, 96, 87, 35 },
                new int[] { 81, 14, 77, 17, 12 },
                new int[] { 82, 47, 2, 95, 59 },
                new int[] { 24, 92, 54, 90, 48 },
                new int[] { 70, 4, 85, 99, 13 },
            },
            new int[][] {

                new int[] { 32, 22, 3, 54, 18 },
                new int[] { 4, 2, 94, 38, 77 },
                new int[] { 46, 59, 11, 67, 37 },
                new int[] { 61, 80, 45, 51, 95 },
                new int[] { 13, 81, 42, 15, 64 },
            },
            new int[][] {

                new int[] { 24, 51, 56, 36, 55 },
                new int[] { 84, 81, 78, 1, 98 },
                new int[] { 33, 14, 3, 97, 64 },
                new int[] { 34, 39, 11, 18, 59 },
                new int[] { 44, 62, 99, 83, 82 },
            },
            new int[][] {

                new int[] { 73, 21, 47, 83, 10 },
                new int[] { 11, 5, 16, 20, 54 },
                new int[] { 36, 98, 4, 89, 38 },
                new int[] { 56, 72, 6, 32, 80 },
                new int[] { 29, 91, 61, 40, 69 },
            },
            new int[][] {

                new int[] { 19, 22, 53, 67, 34 },
                new int[] { 59, 94, 5, 47, 61 },
                new int[] { 77, 55, 91, 69, 63 },
                new int[] { 92, 68, 65, 40, 97 },
                new int[] { 64, 20, 18, 39, 49 },
            },
            new int[][] {

                new int[] { 0, 36, 23, 26, 30 },
                new int[] { 76, 21, 81, 64, 7 },
                new int[] { 3, 61, 93, 79, 70 },
                new int[] { 96, 8, 47, 48, 54 },
                new int[] { 51, 55, 44, 62, 59 },
            },
            new int[][] {

                new int[] { 70, 69, 89, 91, 55 },
                new int[] { 19, 8, 29, 59, 54 },
                new int[] { 64, 56, 51, 34, 60 },
                new int[] { 32, 16, 37, 44, 83 },
                new int[] { 40, 21, 50, 66, 76 },
            },
            new int[][] {

                new int[] { 54, 1, 83, 64, 26 },
                new int[] { 27, 9, 52, 6, 50 },
                new int[] { 68, 4, 45, 30, 2 },
                new int[] { 93, 42, 89, 70, 99 },
                new int[] { 67, 19, 7, 59, 0 },
            },
            new int[][] {

                new int[] { 75, 28, 98, 83, 18 },
                new int[] { 82, 71, 96, 40, 24 },
                new int[] { 47, 52, 73, 69, 34 },
                new int[] { 4, 78, 89, 32, 11 },
                new int[] { 53, 39, 37, 93, 67 },
            },
            new int[][] {

                new int[] { 96, 54, 5, 26, 74 },
                new int[] { 91, 65, 70, 21, 6 },
                new int[] { 4, 80, 89, 30, 51 },
                new int[] { 63, 99, 73, 11, 49 },
                new int[] { 10, 29, 18, 98, 34 },
            },
            new int[][] {

                new int[] { 0, 98, 16, 32, 66 },
                new int[] { 82, 44, 22, 25, 42 },
                new int[] { 62, 45, 90, 36, 47 },
                new int[] { 10, 43, 15, 12, 6 },
                new int[] { 1, 86, 20, 27, 28 },
            },
            new int[][] {

                new int[] { 83, 68, 61, 16, 60 },
                new int[] { 7, 22, 14, 56, 72 },
                new int[] { 41, 24, 43, 20, 51 },
                new int[] { 13, 15, 53, 87, 84 },
                new int[] { 66, 91, 1, 42, 80 },
            },
            new int[][] {

                new int[] { 19, 9, 73, 51, 13 },
                new int[] { 0, 52, 43, 26, 59 },
                new int[] { 20, 2, 12, 78, 56 },
                new int[] { 42, 64, 6, 65, 85 },
                new int[] { 61, 11, 35, 44, 84 },
            },
            new int[][] {

                new int[] { 28, 30, 96, 67, 38 },
                new int[] { 89, 50, 20, 92, 40 },
                new int[] { 0, 57, 9, 49, 95 },
                new int[] { 26, 39, 66, 7, 25 },
                new int[] { 74, 72, 76, 54, 16 },
            },
            new int[][] {

                new int[] { 57, 50, 29, 88, 80 },
                new int[] { 27, 23, 3, 83, 52 },
                new int[] { 33, 45, 5, 4, 58 },
                new int[] { 67, 48, 16, 82, 55 },
                new int[] { 75, 92, 63, 40, 30 },
            },
            new int[][] {

                new int[] { 59, 66, 39, 36, 68 },
                new int[] { 34, 95, 88, 70, 60 },
                new int[] { 44, 6, 81, 2, 13 },
                new int[] { 5, 83, 33, 0, 37 },
                new int[] { 17, 97, 46, 82, 84 },
            },
            new int[][] {

                new int[] { 98, 87, 20, 49, 22 },
                new int[] { 9, 37, 81, 11, 71 },
                new int[] { 24, 64, 13, 25, 82 },
                new int[] { 8, 34, 3, 94, 36 },
                new int[] { 16, 45, 73, 85, 23 },
            },
            new int[][] {

                new int[] { 3, 12, 28, 54, 16 },
                new int[] { 86, 92, 10, 74, 75 },
                new int[] { 43, 5, 98, 24, 34 },
                new int[] { 52, 32, 48, 18, 17 },
                new int[] { 33, 26, 99, 25, 63 },
            },
            new int[][] {

                new int[] { 67, 1, 27, 91, 6 },
                new int[] { 98, 94, 18, 21, 65 },
                new int[] { 9, 17, 80, 82, 70 },
                new int[] { 84, 47, 26, 96, 46 },
                new int[] { 38, 89, 57, 78, 22 },
            },
            new int[][] {

                new int[] { 89, 86, 51, 84, 27 },
                new int[] { 47, 61, 35, 26, 18 },
                new int[] { 22, 79, 28, 78, 21 },
                new int[] { 15, 77, 65, 46, 64 },
                new int[] { 1, 99, 16, 80, 95 },
            },
            new int[][] {

                new int[] { 24, 84, 3, 23, 81 },
                new int[] { 1, 57, 25, 30, 48 },
                new int[] { 67, 91, 68, 15, 2 },
                new int[] { 31, 73, 50, 4, 16 },
                new int[] { 61, 99, 47, 96, 34 },
            },
            new int[][] {

                new int[] { 41, 86, 47, 15, 93 },
                new int[] { 31, 88, 80, 6, 16 },
                new int[] { 54, 55, 24, 81, 77 },
                new int[] { 84, 97, 91, 42, 37 },
                new int[] { 48, 7, 94, 98, 34 },
            },
            new int[][] {

                new int[] { 35, 51, 30, 68, 59 },
                new int[] { 16, 27, 34, 0, 84 },
                new int[] { 90, 47, 28, 96, 72 },
                new int[] { 33, 76, 74, 64, 52 },
                new int[] { 32, 46, 3, 26, 83 },
            },
            new int[][] {

                new int[] { 7, 83, 88, 17, 46 },
                new int[] { 14, 64, 80, 27, 57 },
                new int[] { 58, 44, 55, 86, 61 },
                new int[] { 38, 3, 96, 32, 71 },
                new int[] { 26, 78, 22, 70, 33 },
            },
            new int[][] {

                new int[] { 29, 36, 59, 90, 95 },
                new int[] { 87, 42, 75, 89, 9 },
                new int[] { 96, 1, 58, 48, 10 },
                new int[] { 16, 6, 35, 85, 4 },
                new int[] { 66, 62, 22, 30, 91 },
            },
            new int[][] {

                new int[] { 23, 46, 36, 53, 63 },
                new int[] { 17, 98, 72, 33, 50 },
                new int[] { 39, 96, 95, 67, 19 },
                new int[] { 56, 84, 73, 88, 79 },
                new int[] { 86, 58, 28, 91, 15 },
            },
            new int[][] {

                new int[] { 67, 48, 31, 82, 57 },
                new int[] { 65, 32, 41, 84, 30 },
                new int[] { 3, 87, 94, 68, 35 },
                new int[] { 56, 9, 28, 50, 27 },
                new int[] { 36, 21, 72, 81, 55 },

            },
            new int[][] {
                new int[] { 21, 8, 99, 15, 75 },
                new int[] { 85, 5, 12, 0, 53 },
                new int[] { 82, 45, 4, 11, 43 },
                new int[] { 88, 95, 69, 44, 81 },
                new int[] { 1, 56, 22, 83, 73 },
            },
            new int[][] {

                new int[] { 68, 84, 83, 27, 64 },
                new int[] { 94, 70, 90, 97, 79 },
                new int[] { 12, 35, 45, 76, 22 },
                new int[] { 18, 14, 41, 1, 10 },
                new int[] { 15, 9, 87, 32, 17 },
            },
            new int[][] {

                new int[] { 53, 69, 77, 19, 96 },
                new int[] { 5, 47, 64, 57, 23 },
                new int[] { 26, 28, 88, 6, 41 },
                new int[] { 16, 52, 51, 93, 30 },
                new int[] { 95, 33, 98, 46, 42 },
            },
            new int[][] {

                new int[] { 34, 85, 39, 82, 0 },
                new int[] { 17, 60, 40, 12, 93 },
                new int[] { 56, 72, 58, 31, 3 },
                new int[] { 78, 47, 63, 20, 1 },
                new int[] { 80, 54, 8, 94, 24 },
            },
            new int[][] {

                new int[] { 12, 90, 86, 33, 56 },
                new int[] { 55, 16, 24, 65, 72 },
                new int[] { 82, 28, 53, 1, 93 },
                new int[] { 14, 69, 11, 41, 29 },
                new int[] { 92, 37, 48, 57, 15 },
            },
            new int[][] {

                new int[] { 8, 45, 89, 90, 41 },
                new int[] { 52, 86, 60, 62, 72 },
                new int[] { 47, 80, 82, 13, 56 },
                new int[] { 22, 46, 91, 57, 50 },
                new int[] { 9, 67, 43, 6, 16 },
            },
            new int[][] {

                new int[] { 6, 51, 99, 17, 20 },
                new int[] { 84, 75, 73, 97, 13 },
                new int[] { 89, 31, 80, 1, 61 },
                new int[] { 88, 82, 50, 96, 83 },
                new int[] { 32, 35, 53, 68, 26 },
            },
            new int[][] {

                new int[] { 21, 9, 63, 62, 82 },
                new int[] { 55, 45, 86, 75, 14 },
                new int[] { 19, 15, 88, 43, 53 },
                new int[] { 79, 36, 97, 71, 33 },
                new int[] { 4, 85, 52, 47, 12 },
            },
            new int[][] {

                new int[] { 81, 77, 12, 1, 28 },
                new int[] { 32, 38, 16, 41, 91 },
                new int[] { 64, 8, 63, 78, 54 },
                new int[] { 87, 24, 23, 0, 22 },
                new int[] { 99, 75, 18, 15, 65 },
            },
            new int[][] {

                new int[] { 22, 82, 41, 54, 89 },
                new int[] { 68, 5, 70, 11, 81 },
                new int[] { 17, 94, 73, 24, 77 },
                new int[] { 99, 56, 21, 75, 14 },
                new int[] { 48, 67, 76, 64, 95 },
            },
            new int[][] {

                new int[] { 85, 5, 54, 31, 37 },
                new int[] { 38, 74, 69, 52, 53 },
                new int[] { 86, 89, 6, 81, 40 },
                new int[] { 26, 84, 56, 72, 65 },
                new int[] { 67, 7, 32, 87, 95 },
            },
            new int[][] {

                new int[] { 45, 49, 86, 53, 94 },
                new int[] { 20, 40, 28, 26, 98 },
                new int[] { 36, 4, 67, 29, 87 },
                new int[] { 70, 1, 96, 55, 48 },
                new int[] { 37, 92, 23, 85, 91 },
            },
            new int[][] {

                new int[] { 77, 85, 32, 21, 62 },
                new int[] { 46, 69, 16, 98, 71 },
                new int[] { 3, 88, 38, 36, 8 },
                new int[] { 79, 12, 74, 76, 84 },
                new int[] { 72, 41, 92, 39, 67 },
            },
            new int[][] {

                new int[] { 50, 69, 2, 38, 15 },
                new int[] { 67, 28, 78, 30, 40 },
                new int[] { 33, 92, 88, 85, 24 },
                new int[] { 18, 6, 34, 16, 61 },
                new int[] { 36, 29, 56, 63, 90 },
            },
            new int[][] {

                new int[] { 90, 92, 13, 32, 56 },
                new int[] { 72, 89, 51, 43, 40 },
                new int[] { 18, 4, 81, 23, 77 },
                new int[] { 57, 62, 85, 55, 86 },
                new int[] { 27, 65, 31, 94, 91 },
            },
            new int[][] {

                new int[] { 80, 45, 14, 90, 32 },
                new int[] { 74, 53, 34, 9, 83 },
                new int[] { 51, 97, 56, 30, 69 },
                new int[] { 11, 15, 17, 41, 4 },
                new int[] { 54, 24, 85, 67, 66 },
            },
            new int[][] {

                new int[] { 52, 10, 39, 61, 97 },
                new int[] { 4, 49, 73, 58, 74 },
                new int[] { 19, 45, 92, 27, 32 },
                new int[] { 41, 11, 75, 37, 70 },
                new int[] { 95, 53, 88, 86, 82 },
            },
            new int[][] {

                new int[] { 19, 35, 77, 73, 11 },
                new int[] { 97, 54, 24, 50, 39 },
                new int[] { 68, 59, 56, 80, 75 },
                new int[] { 72, 85, 38, 67, 40 },
                new int[] { 49, 25, 98, 94, 26 },
            },
            new int[][] {

                new int[] { 63, 37, 58, 7, 81 },
                new int[] { 69, 65, 44, 86, 22 },
                new int[] { 38, 66, 82, 93, 64 },
                new int[] { 36, 15, 61, 88, 45 },
                new int[] { 25, 91, 6, 60, 87 },
            },
            new int[][] {

                new int[] { 6, 4, 90, 10, 89 },
                new int[] { 12, 2, 30, 94, 59 },
                new int[] { 41, 13, 51, 63, 0 },
                new int[] { 34, 73, 87, 79, 61 },
                new int[] { 38, 77, 88, 53, 72 },
            },
            new int[][] {

                new int[] { 49, 57, 27, 50, 74 },
                new int[] { 60, 99, 90, 34, 0 },
                new int[] { 7, 80, 43, 24, 65 },
                new int[] { 82, 67, 2, 69, 20 },
                new int[] { 72, 75, 47, 18, 91 },
            },
            new int[][] {

                new int[] { 12, 55, 65, 36, 92 },
                new int[] { 40, 99, 15, 7, 82 },
                new int[] { 9, 46, 32, 52, 83 },
                new int[] { 73, 20, 61, 18, 69 },
                new int[] { 78, 34, 41, 98, 96 },
            },
            new int[][] {

                new int[] { 60, 53, 76, 19, 57 },
                new int[] { 82, 13, 30, 51, 41 },
                new int[] { 45, 87, 95, 25, 39 },
                new int[] { 96, 66, 72, 62, 59 },
                new int[] { 71, 5, 17, 77, 75 },
            },
            new int[][] {

                new int[] { 60, 14, 5, 38, 62 },
                new int[] { 85, 68, 69, 83, 92 },
                new int[] { 24, 82, 93, 61, 11 },
                new int[] { 65, 19, 75, 47, 94 },
                new int[] { 45, 21, 13, 76, 59 },
            },
            new int[][] {

                new int[] { 50, 43, 83, 15, 18 },
                new int[] { 35, 37, 47, 96, 51 },
                new int[] { 91, 7, 19, 38, 9 },
                new int[] { 87, 76, 46, 61, 82 },
                new int[] { 85, 20, 59, 39, 31 },
            },
            new int[][] {

                new int[] { 91, 42, 83, 63, 54 },
                new int[] { 35, 89, 33, 37, 88 },
                new int[] { 19, 67, 71, 49, 48 },
                new int[] { 34, 65, 7, 1, 80 },
                new int[] { 70, 9, 98, 10, 44 },
            },
            new int[][] {

                new int[] { 65, 89, 1, 76, 86 },
                new int[] { 81, 35, 93, 69, 26 },
                new int[] { 15, 17, 16, 67, 0 },
                new int[] { 97, 38, 23, 50, 78 },
                new int[] { 96, 54, 70, 45, 42 },
            },
            new int[][] {

                new int[] { 20, 50, 64, 29, 75 },
                new int[] { 87, 69, 27, 92, 52 },
                new int[] { 32, 88, 93, 67, 9 },
                new int[] { 35, 15, 17, 89, 40 },
                new int[] { 37, 11, 21, 3, 86 },
            },
            new int[][] {

                new int[] { 20, 8, 68, 75, 65 },
                new int[] { 47, 56, 2, 23, 49 },
                new int[] { 88, 26, 5, 18, 7 },
                new int[] { 29, 57, 19, 92, 84 },
                new int[] { 87, 67, 53, 90, 96 },
            },
            new int[][] {

                new int[] { 68, 59, 97, 34, 56 },
                new int[] { 82, 83, 90, 94, 69 },
                new int[] { 37, 60, 76, 35, 1 },
                new int[] { 29, 95, 58, 40, 53 },
                new int[] { 22, 84, 12, 21, 99 },
            },
            new int[][] {

                new int[] { 63, 32, 79, 62, 17 },
                new int[] { 8, 18, 40, 74, 57 },
                new int[] { 71, 91, 70, 30, 3 },
                new int[] { 46, 33, 39, 61, 76 },
                new int[] { 27, 54, 12, 98, 77 },
            },
            new int[][] {

                new int[] { 73, 66, 24, 65, 76 },
                new int[] { 88, 42, 52, 11, 32 },
                new int[] { 41, 15, 81, 89, 33 },
                new int[] { 74, 3, 25, 75, 83 },
                new int[] { 29, 14, 96, 35, 27 },
            },
            new int[][] {

                new int[] { 23, 36, 57, 53, 93 },
                new int[] { 43, 50, 83, 97, 91 },
                new int[] { 63, 69, 55, 90, 11 },
                new int[] { 18, 94, 59, 85, 73 },
                new int[] { 81, 60, 30, 46, 80 },
            },
            new int[][] {

                new int[] { 32, 13, 51, 86, 39 },
                new int[] { 74, 46, 11, 25, 9 },
                new int[] { 44, 89, 26, 54, 71 },
                new int[] { 93, 98, 29, 75, 85 },
                new int[] { 38, 70, 79, 0, 30 },
            },
            new int[][] {

                new int[] { 68, 4, 55, 3, 96 },
                new int[] { 41, 7, 64, 21, 86 },
                new int[] { 27, 69, 93, 80, 90 },
                new int[] { 73, 75, 26, 25, 50 },
                new int[] { 49, 32, 45, 24, 61 },
            },
            new int[][] {

                new int[] { 90, 14, 43, 4, 87 },
                new int[] { 11, 16, 33, 79, 28 },
                new int[] { 36, 31, 2, 34, 50 },
                new int[] { 67, 10, 24, 92, 99 },
                new int[] { 26, 80, 1, 12, 51 },
            },
            new int[][] {

                new int[] { 56, 21, 79, 36, 93 },
                new int[] { 26, 63, 35, 5, 76 },
                new int[] { 85, 94, 69, 18, 28 },
                new int[] { 52, 55, 90, 83, 12 },
                new int[] { 10, 23, 95, 15, 19 },
            },
            new int[][] {

                new int[] { 34, 85, 32, 89, 16 },
                new int[] { 7, 12, 40, 23, 47 },
                new int[] { 79, 10, 93, 59, 29 },
                new int[] { 99, 22, 21, 38, 9 },
                new int[] { 76, 4, 70, 53, 35 },
            },
            new int[][] {

                new int[] { 51, 33, 22, 56, 97 },
                new int[] { 88, 26, 47, 19, 40 },
                new int[] { 45, 0, 3, 25, 76 },
                new int[] { 8, 42, 61, 57, 5 },
                new int[] { 83, 20, 53, 29, 70 },
            },
            new int[][] {

                new int[] { 2, 41, 94, 98, 33 },
                new int[] { 61, 77, 84, 34, 0 },
                new int[] { 49, 40, 86, 74, 43 },
                new int[] { 35, 27, 38, 25, 8 },
                new int[] { 90, 80, 57, 97, 46 },
            },
            new int[][] {

                new int[] { 60, 1, 83, 31, 77 },
                new int[] { 94, 49, 64, 6, 24 },
                new int[] { 51, 95, 36, 72, 76 },
                new int[] { 8, 7, 59, 45, 34 },
                new int[] { 26, 87, 41, 97, 82 },
            },
            new int[][] {

                new int[] { 13, 7, 69, 28, 78 },
                new int[] { 39, 62, 45, 77, 53 },
                new int[] { 90, 85, 23, 17, 38 },
                new int[] { 60, 33, 19, 89, 24 },
                new int[] { 97, 30, 16, 64, 42 },
            },
            new int[][] {

                new int[] { 23, 73, 59, 52, 70 },
                new int[] { 20, 38, 81, 78, 47 },
                new int[] { 58, 0, 79, 19, 95 },
                new int[] { 39, 42, 8, 17, 53 },
                new int[] { 24, 57, 37, 13, 10 },
            },
            new int[][] {

                new int[] { 36, 60, 3, 98, 41 },
                new int[] { 30, 27, 0, 74, 81 },
                new int[] { 49, 23, 48, 69, 4 },
                new int[] { 22, 86, 73, 96, 95 },
                new int[] { 80, 14, 92, 83, 91 },
            },
            new int[][] {

                new int[] { 86, 61, 22, 77, 57 },
                new int[] { 34, 4, 71, 55, 27 },
                new int[] { 25, 24, 7, 6, 16 },
                new int[] { 81, 75, 38, 96, 35 },
                new int[] { 64, 15, 29, 98, 79 },
            },
            new int[][] {

                new int[] { 82, 85, 80, 52, 56 },
                new int[] { 72, 58, 89, 8, 92 },
                new int[] { 43, 5, 77, 2, 83 },
                new int[] { 53, 12, 39, 21, 6 },
                new int[] { 16, 31, 47, 10, 74 },
            },
            new int[][] {

                new int[] { 43, 17, 37, 53, 48 },
                new int[] { 60, 77, 80, 36, 25 },
                new int[] { 58, 20, 91, 95, 71 },
                new int[] { 90, 4, 9, 83, 66 },
                new int[] { 28, 15, 62, 6, 11 },
            },
            new int[][] {

                new int[] { 51, 46, 2, 26, 79 },
                new int[] { 83, 52, 11, 64, 22 },
                new int[] { 66, 49, 61, 78, 69 },
                new int[] { 70, 67, 91, 10, 24 },
                new int[] { 68, 63, 23, 93, 35 },
            },
            new int[][] {

                new int[] { 42, 9, 63, 56, 93 },
                new int[] { 79, 59, 38, 36, 7 },
                new int[] { 6, 23, 48, 0, 55 },
                new int[] { 82, 45, 13, 27, 83 },
                new int[] { 1, 32, 8, 40, 46 },
            }
        };
    }
}
