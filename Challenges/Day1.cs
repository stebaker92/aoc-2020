using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_2020
{
    class Day1 : IDay
    {
        public IEnumerable<string> Run()
        {
            var lines = File.ReadAllLines("./input/day1");

            var entries = lines.Select(x => int.Parse(x));

            return new[]
            {
                Part1(entries).ToString(),
                Part2(entries).ToString()
            };
        }

        public int Part1(IEnumerable<int> entries)
        {
            foreach (var x in entries)
            {
                foreach (var y in entries)
                {
                    if (x + y == 2020)
                    {
                        Console.WriteLine($"Found numbers that add to 2020: {x} + {y}");
                        Console.WriteLine($"Numbers multiplied are: {x * y}");
                        return x * y;
                    }
                }
            }

            throw new Exception("No answer found");
        }

        public int Part2(IEnumerable<int> entries)
        {
            foreach (var x in entries)
            {
                foreach (var y in entries)
                {
                    foreach (var z in entries)
                    {
                        if (x + y + z == 2020)
                        {
                            Console.WriteLine($"Found numbers that add to 2020: {x} + {y} + {z}");
                            Console.WriteLine($"Numbers multiplied are: {x * y * z}");
                            return x * y * z;
                        }
                    }
                }
            }
            throw new Exception("No answer found");
        }
    }
}
