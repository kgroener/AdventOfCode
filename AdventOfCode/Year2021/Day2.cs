﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using AdventOfCode.Contracts;

namespace AdventOfCode.Year2021
{
    internal class Day2 : IAdventDayPuzzle
    {
        public string Description => @"The submarine seems to already have a planned course (your puzzle input). You should probably figure out where it's going.";

        public DateTime Date => new DateTime(2021, 12, 2);
        public IEnumerable<IAdventDaySolution> GetSolutions()
        {
            return new IAdventDaySolution[] { new Solution1(PlottedPath), new Solution2(PlottedPath) };
        }

        internal class Solution1 : IAdventDaySolution
        {
            private readonly (string instruction, int value)[] _steps;

            public Solution1((string instruction, int value)[] steps)
            {
                _steps = steps;
            }

            public string Description =>
                @"Calculate the horizontal position and depth you would have after following the planned course. What do you get if you multiply your final horizontal position by your final depth?";
            public int Part => 1;
            public object Solve()
            {
                var finalPosition = new[] { (instruction: "START", value: 0) }
                    .Concat(_steps)
                    .Select(s => (
                        Instruction: s.instruction,
                        Value: s.value,
                        Depth: 0,
                        HorizontalPosition: 0))
                    .Aggregate((a, b) =>
                    {
                        return b.Instruction switch
                        {
                            "forward" => ("DONE", 0, a.Depth, a.HorizontalPosition + b.Value),
                            "up" => ("DONE", 0, a.Depth - b.Value, a.HorizontalPosition),
                            "down" => ("DONE", 0, a.Depth + b.Value, a.HorizontalPosition),
                            _ => throw new ArgumentException("Invalid instruction")
                        };
                    });

                return finalPosition.Depth * finalPosition.HorizontalPosition;
            }
        }

        internal class Solution2 : IAdventDaySolution
        {
            private readonly (string instruction, int value)[] _steps;

            public Solution2((string instruction, int value)[] steps)
            {
                _steps = steps;
            }

            public string Description =>
                @"In addition to horizontal position and depth, you'll also need to track a third value, aim. Calculate the horizontal position and depth you would have after following the planned course. What do you get if you multiply your final horizontal position by your final depth?";
            public int Part => 2;
            public object Solve()
            {
                var finalPosition = new[] { (instruction: "START", value: 0) }
                    .Concat(_steps)
                    .Select(s => (
                        Instruction: s.instruction,
                        Value: s.value,
                        Depth: 0,
                        HorizontalPosition: 0,
                        Aim: 0))
                    .Aggregate((a, b) =>
                    {
                        return b.Instruction switch
                        {
                            "forward" => ("DONE", 0, a.Depth + (a.Aim * b.Value), a.HorizontalPosition + b.Value, a.Aim),
                            "up" => ("DONE", 0, a.Depth, a.HorizontalPosition, a.Aim - b.Value),
                            "down" => ("DONE", 0, a.Depth, a.HorizontalPosition, a.Aim + b.Value),
                            _ => throw new ArgumentException("Invalid instruction")
                        };
                    });

                return finalPosition.Depth * finalPosition.HorizontalPosition;
            }
        }

        private static (string, int)[] PlottedPath => new[]
        {
            ("forward", 9),
            ("down", 9),
            ("up", 4),
            ("down", 5),
            ("down", 6),
            ("up", 6),
            ("down", 7),
            ("down", 1),
            ("forward", 6),
            ("down", 4),
            ("forward", 8),
            ("up", 5),
            ("forward", 9),
            ("down", 1),
            ("down", 4),
            ("up", 4),
            ("up", 5),
            ("up", 4),
            ("down", 1),
            ("forward", 8),
            ("down", 1),
            ("forward", 2),
            ("forward", 8),
            ("down", 9),
            ("forward", 2),
            ("down", 6),
            ("down", 2),
            ("up", 8),
            ("down", 6),
            ("forward", 9),
            ("forward", 7),
            ("down", 6),
            ("forward", 3),
            ("down", 2),
            ("forward", 4),
            ("down", 5),
            ("up", 2),
            ("down", 9),
            ("down", 8),
            ("up", 5),
            ("forward", 5),
            ("forward", 4),
            ("up", 9),
            ("forward", 9),
            ("down", 8),
            ("forward", 8),
            ("forward", 2),
            ("up", 8),
            ("down", 7),
            ("forward", 8),
            ("down", 3),
            ("forward", 6),
            ("up", 9),
            ("forward", 9),
            ("forward", 4),
            ("forward", 9),
            ("forward", 6),
            ("down", 4),
            ("up", 2),
            ("forward", 4),
            ("up", 5),
            ("up", 6),
            ("forward", 9),
            ("down", 3),
            ("forward", 4),
            ("forward", 9),
            ("down", 1),
            ("forward", 1),
            ("up", 6),
            ("up", 4),
            ("forward", 7),
            ("up", 7),
            ("up", 3),
            ("forward", 2),
            ("forward", 8),
            ("forward", 6),
            ("down", 4),
            ("forward", 2),
            ("forward", 3),
            ("down", 7),
            ("down", 5),
            ("down", 8),
            ("down", 5),
            ("forward", 1),
            ("down", 8),
            ("down", 2),
            ("down", 8),
            ("down", 3),
            ("forward", 4),
            ("forward", 8),
            ("forward", 9),
            ("down", 1),
            ("forward", 8),
            ("down", 1),
            ("down", 6),
            ("down", 7),
            ("down", 7),
            ("forward", 5),
            ("forward", 3),
            ("down", 2),
            ("down", 1),
            ("forward", 2),
            ("forward", 1),
            ("down", 6),
            ("down", 4),
            ("up", 5),
            ("up", 9),
            ("down", 4),
            ("forward", 9),
            ("down", 2),
            ("down", 5),
            ("down", 4),
            ("down", 2),
            ("forward", 2),
            ("forward", 4),
            ("forward", 6),
            ("forward", 6),
            ("forward", 3),
            ("down", 6),
            ("up", 5),
            ("forward", 8),
            ("forward", 3),
            ("down", 9),
            ("down", 3),
            ("forward", 4),
            ("forward", 2),
            ("down", 9),
            ("down", 8),
            ("down", 7),
            ("down", 3),
            ("forward", 2),
            ("down", 7),
            ("down", 3),
            ("down", 5),
            ("forward", 6),
            ("up", 9),
            ("up", 8),
            ("forward", 5),
            ("down", 6),
            ("down", 1),
            ("down", 6),
            ("down", 5),
            ("forward", 7),
            ("down", 2),
            ("forward", 8),
            ("forward", 7),
            ("forward", 2),
            ("forward", 8),
            ("up", 6),
            ("forward", 5),
            ("down", 2),
            ("down", 5),
            ("up", 8),
            ("up", 6),
            ("forward", 1),
            ("down", 4),
            ("up", 5),
            ("up", 5),
            ("up", 5),
            ("forward", 4),
            ("up", 1),
            ("forward", 3),
            ("down", 9),
            ("down", 6),
            ("up", 1),
            ("forward", 1),
            ("forward", 2),
            ("forward", 1),
            ("forward", 4),
            ("forward", 6),
            ("forward", 6),
            ("up", 7),
            ("down", 7),
            ("down", 7),
            ("down", 9),
            ("forward", 9),
            ("down", 1),
            ("down", 5),
            ("down", 1),
            ("down", 7),
            ("down", 1),
            ("up", 6),
            ("forward", 2),
            ("down", 4),
            ("up", 3),
            ("up", 2),
            ("forward", 6),
            ("up", 4),
            ("down", 1),
            ("down", 5),
            ("forward", 9),
            ("up", 4),
            ("up", 3),
            ("forward", 3),
            ("up", 7),
            ("forward", 2),
            ("forward", 5),
            ("down", 9),
            ("forward", 7),
            ("forward", 4),
            ("down", 1),
            ("up", 2),
            ("forward", 4),
            ("up", 4),
            ("down", 2),
            ("forward", 4),
            ("up", 5),
            ("up", 1),
            ("down", 9),
            ("down", 3),
            ("up", 6),
            ("forward", 7),
            ("up", 7),
            ("forward", 2),
            ("down", 4),
            ("up", 3),
            ("up", 3),
            ("forward", 4),
            ("up", 5),
            ("down", 3),
            ("up", 8),
            ("forward", 6),
            ("forward", 8),
            ("down", 1),
            ("down", 9),
            ("down", 7),
            ("forward", 7),
            ("forward", 5),
            ("forward", 2),
            ("up", 9),
            ("forward", 3),
            ("forward", 1),
            ("down", 7),
            ("down", 6),
            ("forward", 5),
            ("up", 3),
            ("forward", 6),
            ("down", 4),
            ("forward", 9),
            ("down", 7),
            ("forward", 9),
            ("down", 9),
            ("down", 5),
            ("down", 6),
            ("down", 2),
            ("down", 2),
            ("down", 8),
            ("down", 3),
            ("down", 9),
            ("forward", 5),
            ("up", 6),
            ("forward", 1),
            ("down", 3),
            ("down", 2),
            ("up", 1),
            ("up", 6),
            ("forward", 3),
            ("down", 6),
            ("down", 6),
            ("up", 9),
            ("up", 8),
            ("forward", 2),
            ("down", 7),
            ("forward", 5),
            ("up", 9),
            ("down", 7),
            ("down", 3),
            ("forward", 2),
            ("forward", 2),
            ("up", 9),
            ("forward", 1),
            ("forward", 7),
            ("down", 9),
            ("forward", 6),
            ("forward", 7),
            ("up", 8),
            ("down", 7),
            ("down", 5),
            ("down", 3),
            ("up", 6),
            ("down", 5),
            ("forward", 6),
            ("down", 9),
            ("down", 6),
            ("up", 9),
            ("down", 7),
            ("forward", 2),
            ("down", 5),
            ("up", 4),
            ("down", 4),
            ("down", 8),
            ("forward", 7),
            ("down", 9),
            ("forward", 8),
            ("forward", 6),
            ("down", 7),
            ("down", 1),
            ("forward", 5),
            ("up", 6),
            ("forward", 4),
            ("up", 7),
            ("up", 4),
            ("up", 5),
            ("forward", 9),
            ("forward", 5),
            ("forward", 4),
            ("down", 6),
            ("down", 5),
            ("forward", 2),
            ("forward", 7),
            ("down", 8),
            ("forward", 3),
            ("up", 5),
            ("down", 2),
            ("up", 3),
            ("forward", 4),
            ("up", 5),
            ("up", 2),
            ("forward", 4),
            ("forward", 1),
            ("forward", 1),
            ("forward", 4),
            ("forward", 4),
            ("down", 2),
            ("forward", 1),
            ("forward", 1),
            ("up", 5),
            ("up", 7),
            ("down", 8),
            ("down", 4),
            ("forward", 2),
            ("forward", 2),
            ("down", 3),
            ("forward", 7),
            ("down", 8),
            ("up", 3),
            ("forward", 2),
            ("down", 2),
            ("forward", 3),
            ("up", 2),
            ("forward", 3),
            ("up", 6),
            ("down", 7),
            ("up", 7),
            ("down", 3),
            ("up", 9),
            ("forward", 3),
            ("forward", 7),
            ("down", 7),
            ("up", 9),
            ("down", 6),
            ("down", 2),
            ("forward", 8),
            ("forward", 8),
            ("up", 7),
            ("down", 6),
            ("forward", 2),
            ("forward", 1),
            ("down", 4),
            ("up", 2),
            ("forward", 6),
            ("up", 7),
            ("down", 5),
            ("up", 1),
            ("forward", 3),
            ("forward", 9),
            ("up", 4),
            ("forward", 5),
            ("forward", 8),
            ("down", 3),
            ("up", 5),
            ("forward", 9),
            ("down", 6),
            ("up", 9),
            ("forward", 5),
            ("down", 4),
            ("down", 1),
            ("down", 6),
            ("up", 9),
            ("up", 2),
            ("forward", 5),
            ("down", 1),
            ("up", 3),
            ("down", 5),
            ("forward", 2),
            ("down", 4),
            ("forward", 5),
            ("down", 6),
            ("down", 4),
            ("down", 4),
            ("forward", 1),
            ("down", 7),
            ("down", 2),
            ("forward", 4),
            ("forward", 5),
            ("up", 9),
            ("down", 6),
            ("down", 2),
            ("forward", 7),
            ("up", 8),
            ("down", 9),
            ("forward", 7),
            ("down", 5),
            ("down", 2),
            ("down", 8),
            ("down", 8),
            ("up", 4),
            ("up", 3),
            ("down", 3),
            ("down", 7),
            ("forward", 4),
            ("forward", 6),
            ("down", 4),
            ("up", 7),
            ("forward", 4),
            ("forward", 4),
            ("forward", 1),
            ("down", 3),
            ("down", 2),
            ("forward", 7),
            ("forward", 2),
            ("up", 9),
            ("down", 7),
            ("up", 7),
            ("forward", 2),
            ("forward", 6),
            ("forward", 9),
            ("down", 3),
            ("forward", 7),
            ("forward", 5),
            ("up", 5),
            ("up", 1),
            ("forward", 6),
            ("forward", 4),
            ("down", 2),
            ("forward", 3),
            ("forward", 9),
            ("down", 1),
            ("forward", 6),
            ("forward", 7),
            ("forward", 1),
            ("up", 7),
            ("up", 4),
            ("forward", 7),
            ("forward", 8),
            ("down", 7),
            ("down", 8),
            ("down", 9),
            ("forward", 7),
            ("down", 9),
            ("up", 6),
            ("down", 7),
            ("up", 3),
            ("down", 7),
            ("forward", 4),
            ("forward", 9),
            ("forward", 1),
            ("down", 4),
            ("forward", 1),
            ("up", 4),
            ("up", 4),
            ("forward", 9),
            ("forward", 8),
            ("up", 4),
            ("down", 2),
            ("forward", 4),
            ("forward", 2),
            ("forward", 8),
            ("down", 2),
            ("up", 6),
            ("down", 4),
            ("forward", 6),
            ("forward", 5),
            ("down", 2),
            ("forward", 9),
            ("down", 5),
            ("forward", 5),
            ("down", 3),
            ("down", 2),
            ("up", 9),
            ("down", 3),
            ("forward", 6),
            ("forward", 6),
            ("up", 9),
            ("down", 1),
            ("forward", 4),
            ("up", 3),
            ("forward", 1),
            ("forward", 3),
            ("forward", 3),
            ("down", 6),
            ("down", 2),
            ("forward", 8),
            ("down", 4),
            ("forward", 8),
            ("forward", 8),
            ("forward", 5),
            ("up", 6),
            ("forward", 3),
            ("down", 1),
            ("down", 8),
            ("forward", 3),
            ("forward", 4),
            ("down", 2),
            ("down", 7),
            ("up", 8),
            ("forward", 3),
            ("forward", 8),
            ("up", 2),
            ("forward", 6),
            ("down", 4),
            ("forward", 9),
            ("forward", 5),
            ("down", 1),
            ("forward", 6),
            ("forward", 2),
            ("down", 3),
            ("up", 4),
            ("down", 7),
            ("down", 2),
            ("up", 2),
            ("forward", 7),
            ("down", 6),
            ("down", 2),
            ("up", 5),
            ("up", 5),
            ("down", 9),
            ("down", 7),
            ("down", 3),
            ("down", 1),
            ("down", 9),
            ("forward", 4),
            ("down", 4),
            ("forward", 7),
            ("forward", 8),
            ("forward", 4),
            ("up", 6),
            ("forward", 6),
            ("forward", 9),
            ("down", 2),
            ("forward", 4),
            ("down", 8),
            ("down", 4),
            ("forward", 5),
            ("forward", 2),
            ("up", 4),
            ("down", 3),
            ("up", 8),
            ("up", 1),
            ("down", 1),
            ("forward", 9),
            ("up", 3),
            ("up", 1),
            ("forward", 1),
            ("forward", 7),
            ("forward", 1),
            ("down", 7),
            ("forward", 7),
            ("forward", 7),
            ("down", 7),
            ("forward", 4),
            ("up", 6),
            ("forward", 3),
            ("down", 1),
            ("up", 1),
            ("up", 8),
            ("forward", 5),
            ("forward", 2),
            ("up", 4),
            ("forward", 7),
            ("down", 2),
            ("down", 3),
            ("down", 8),
            ("up", 7),
            ("up", 5),
            ("forward", 8),
            ("down", 5),
            ("down", 3),
            ("down", 9),
            ("forward", 6),
            ("forward", 4),
            ("down", 9),
            ("up", 5),
            ("forward", 3),
            ("up", 7),
            ("up", 9),
            ("up", 1),
            ("forward", 1),
            ("forward", 3),
            ("forward", 1),
            ("up", 8),
            ("up", 4),
            ("down", 1),
            ("down", 8),
            ("down", 3),
            ("down", 1),
            ("down", 1),
            ("down", 9),
            ("forward", 4),
            ("down", 3),
            ("forward", 9),
            ("forward", 2),
            ("down", 1),
            ("forward", 9),
            ("up", 7),
            ("forward", 6),
            ("up", 4),
            ("forward", 8),
            ("forward", 3),
            ("down", 2),
            ("down", 2),
            ("down", 2),
            ("up", 5),
            ("forward", 1),
            ("up", 1),
            ("forward", 7),
            ("down", 1),
            ("forward", 1),
            ("down", 8),
            ("up", 4),
            ("up", 1),
            ("forward", 7),
            ("down", 8),
            ("down", 9),
            ("forward", 2),
            ("forward", 1),
            ("up", 3),
            ("forward", 4),
            ("up", 8),
            ("forward", 5),
            ("down", 2),
            ("forward", 6),
            ("forward", 8),
            ("up", 9),
            ("forward", 2),
            ("down", 7),
            ("down", 4),
            ("up", 3),
            ("forward", 1),
            ("forward", 6),
            ("forward", 9),
            ("down", 1),
            ("down", 8),
            ("down", 1),
            ("down", 2),
            ("forward", 3),
            ("forward", 9),
            ("forward", 2),
            ("forward", 4),
            ("forward", 7),
            ("forward", 3),
            ("up", 8),
            ("up", 9),
            ("forward", 3),
            ("forward", 6),
            ("down", 5),
            ("up", 6),
            ("down", 8),
            ("forward", 5),
            ("up", 4),
            ("up", 9),
            ("forward", 6),
            ("forward", 3),
            ("up", 9),
            ("forward", 8),
            ("forward", 5),
            ("forward", 9),
            ("forward", 7),
            ("up", 6),
            ("forward", 3),
            ("forward", 1),
            ("up", 4),
            ("forward", 9),
            ("forward", 8),
            ("up", 1),
            ("up", 2),
            ("down", 3),
            ("down", 4),
            ("down", 9),
            ("down", 4),
            ("down", 5),
            ("down", 6),
            ("down", 2),
            ("down", 5),
            ("forward", 6),
            ("forward", 4),
            ("up", 2),
            ("up", 7),
            ("down", 5),
            ("down", 9),
            ("forward", 3),
            ("down", 5),
            ("forward", 6),
            ("down", 7),
            ("forward", 1),
            ("forward", 7),
            ("forward", 9),
            ("forward", 7),
            ("forward", 4),
            ("forward", 4),
            ("up", 1),
            ("up", 4),
            ("down", 6),
            ("up", 2),
            ("up", 1),
            ("down", 4),
            ("forward", 2),
            ("down", 4),
            ("forward", 6),
            ("down", 3),
            ("up", 6),
            ("down", 2),
            ("up", 3),
            ("forward", 1),
            ("forward", 9),
            ("forward", 3),
            ("up", 9),
            ("forward", 7),
            ("forward", 5),
            ("forward", 4),
            ("down", 5),
            ("down", 9),
            ("forward", 6),
            ("forward", 7),
            ("up", 1),
            ("forward", 7),
            ("forward", 2),
            ("forward", 2),
            ("forward", 5),
            ("forward", 6),
            ("down", 3),
            ("down", 7),
            ("down", 3),
            ("down", 4),
            ("down", 6),
            ("down", 1),
            ("forward", 2),
            ("down", 8),
            ("forward", 4),
            ("forward", 7),
            ("up", 1),
            ("down", 4),
            ("down", 1),
            ("down", 2),
            ("down", 3),
            ("up", 3),
            ("forward", 9),
            ("forward", 2),
            ("down", 8),
            ("up", 3),
            ("forward", 8),
            ("forward", 7),
            ("up", 8),
            ("down", 8),
            ("forward", 2),
            ("down", 9),
            ("down", 9),
            ("down", 5),
            ("forward", 1),
            ("forward", 3),
            ("forward", 6),
            ("up", 1),
            ("up", 2),
            ("forward", 1),
            ("down", 3),
            ("up", 6),
            ("forward", 2),
            ("forward", 8),
            ("forward", 2),
            ("down", 3),
            ("forward", 8),
            ("forward", 9),
            ("down", 7),
            ("down", 3),
            ("down", 2),
            ("down", 9),
            ("down", 3),
            ("up", 6),
            ("forward", 9),
            ("forward", 5),
            ("forward", 1),
            ("forward", 9),
            ("down", 9),
            ("up", 2),
            ("down", 1),
            ("up", 6),
            ("forward", 6),
            ("down", 3),
            ("forward", 6),
            ("forward", 3),
            ("forward", 5),
            ("forward", 4),
            ("up", 2),
            ("up", 4),
            ("up", 6),
            ("forward", 1),
            ("forward", 6),
            ("up", 6),
            ("up", 4),
            ("up", 7),
            ("down", 8),
            ("down", 5),
            ("up", 1),
            ("up", 1),
            ("down", 5),
            ("forward", 5),
            ("down", 9),
            ("forward", 8),
            ("down", 3),
            ("up", 4),
            ("down", 9),
            ("down", 1),
            ("forward", 2),
            ("forward", 9),
            ("down", 3),
            ("down", 8),
            ("down", 5),
            ("down", 6),
            ("forward", 7),
            ("forward", 1),
            ("down", 9),
            ("down", 7),
            ("forward", 8),
            ("forward", 2),
            ("up", 1),
            ("up", 1),
            ("forward", 7),
            ("up", 1),
            ("forward", 2),
            ("down", 9),
            ("up", 4),
            ("forward", 5),
            ("down", 1),
            ("up", 1),
            ("down", 8),
            ("down", 3),
            ("up", 1),
            ("down", 8),
            ("down", 7),
            ("down", 2),
            ("forward", 9),
            ("down", 5),
            ("forward", 2),
            ("up", 2),
            ("up", 6),
            ("up", 4),
            ("forward", 6),
            ("up", 5),
            ("forward", 5),
            ("forward", 4),
            ("forward", 8),
            ("down", 8),
            ("down", 6),
            ("down", 1),
            ("down", 3),
            ("down", 6),
            ("forward", 8),
            ("up", 1),
            ("up", 5),
            ("down", 4),
            ("forward", 4),
            ("down", 9),
            ("forward", 4),
            ("up", 6),
            ("down", 7),
            ("forward", 4),
            ("down", 3),
            ("down", 4),
            ("forward", 1),
            ("forward", 3),
            ("down", 1),
            ("down", 7),
            ("up", 8),
            ("down", 3),
            ("down", 4),
            ("down", 3),
            ("forward", 3),
            ("down", 8),
            ("forward", 8),
            ("down", 3),
            ("down", 7),
            ("forward", 2),
            ("up", 2),
            ("forward", 7),
            ("down", 9),
            ("up", 7),
            ("forward", 5),
            ("down", 2),
            ("down", 5),
            ("up", 4),
            ("up", 8),
            ("forward", 8),
            ("forward", 9),
            ("forward", 8),
            ("down", 8),
            ("forward", 6),
            ("forward", 9),
            ("forward", 6),
            ("forward", 8),
            ("forward", 6),
            ("forward", 8),
            ("forward", 2),
            ("down", 7),
            ("down", 3),
            ("forward", 7),
            ("down", 4),
            ("down", 5),
            ("up", 1),
            ("forward", 5),
            ("down", 3),
            ("down", 7),
            ("up", 4),
            ("forward", 9),
            ("down", 2),
            ("down", 3),
            ("forward", 1),
            ("up", 6),
            ("down", 1),
            ("down", 9),
            ("forward", 8),
            ("forward", 9),
            ("forward", 2),
            ("down", 6),
            ("down", 4),
            ("up", 3),
            ("up", 8),
            ("forward", 1),
            ("down", 3),
            ("up", 8),
            ("up", 7),
            ("down", 4),
            ("up", 3),
            ("down", 7),
            ("down", 2),
            ("down", 5),
            ("down", 7),
            ("down", 2),
            ("forward", 2),
            ("down", 3),
            ("up", 2),
            ("forward", 8),
            ("up", 1),
            ("forward", 2),
            ("up", 4),
            ("forward", 1),
            ("forward", 8),
            ("forward", 6),
            ("forward", 2),
            ("down", 2),
            ("forward", 5),
            ("up", 4),
            ("down", 9),
            ("down", 7),
            ("forward", 2),
            ("down", 9),
            ("down", 9),
            ("forward", 6),
            ("down", 8),
            ("down", 4),
            ("down", 7),
            ("down", 9),
            ("forward", 7),
            ("forward", 7),
            ("up", 6),
            ("forward", 3),
            ("forward", 5),
            ("forward", 6),
            ("down", 8),
            ("up", 1),
            ("forward", 2),
            ("up", 4),
            ("up", 2),
            ("down", 8),
            ("down", 9),
            ("down", 1),
            ("down", 3),
            ("forward", 7),
            ("forward", 5),
            ("forward", 6),
            ("up", 6),
            ("down", 7),
            ("up", 8),
            ("up", 1),
            ("forward", 8),
            ("down", 5),
            ("up", 1),
            ("down", 2),
            ("down", 5),
            ("forward", 6),
            ("down", 4),
            ("forward", 5),
            ("down", 4),
            ("forward", 3),
            ("down", 5),
            ("up", 4),
            ("up", 7),
            ("forward", 2),
            ("up", 2),
            ("down", 8),
            ("forward", 6),
        };
    }
}
