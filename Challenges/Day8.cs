using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_2020
{
    partial class Day8 : IDay
    {
        public IEnumerable<string> Run()
        {
            var lines = File.ReadAllLines("./input/day8");

            var entries = lines.Select(x => (x));

            return new[]
            {
                Part1(entries).ToString(),
                // Part2(entries).ToString()
            };
        }

        public int Part1(IEnumerable<string> entries)
        {
            var instructions = entries.Select(x => new Instruction(x)).ToArray();

            var gameboy = new GameConsole()
            {
                Instructions = instructions
            };
            
            return gameboy.Run();
        }

        public int Part2(IEnumerable<string> entries)
        {

            throw new Exception("No answer found");
        }
    }
}
