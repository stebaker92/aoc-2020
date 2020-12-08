using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_2020
{
    class Day0 : IDay
    {
        public IEnumerable<string> Run()
        {
            var lines = File.ReadAllLines("./input/day0");

            var entries = lines.Select(x => int.Parse(x));

            return new[]
            {
                Part1(entries).ToString(),
                Part2(entries).ToString()
            };
        }

        public int Part1(IEnumerable<int> entries)
        {

            throw new Exception("No answer found");
        }

        public int Part2(IEnumerable<int> entries)
        {

            throw new Exception("No answer found");
        }
    }
}
