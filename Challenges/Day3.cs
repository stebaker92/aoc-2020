using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_2020
{
    class Day3 : IDay
    {
        public IEnumerable<string> Run()
        {
            var lines = File.ReadAllLines("./input/day3");

            var entries = lines.Select(x => x);

            return new[]
            {
                Part1(lines).ToString(),
                Part2(lines).ToString(),
            };
        }

        public int Part1(IEnumerable<string> lines)
        {
            return GetTreesInRoute(3, 1, lines);
        }

        public long Part2(IEnumerable<string> lines)
        {
            var results = new int[]
            {
                GetTreesInRoute(1, 1, lines),
                GetTreesInRoute(3, 1, lines),
                GetTreesInRoute(5, 1, lines),
                GetTreesInRoute(7, 1, lines),
                GetTreesInRoute(1, 2, lines),
            };

            long treesMultiplied = 1;
            foreach (int value in results)
            {
                treesMultiplied *= (long)value;
            }
            return treesMultiplied;
        }


        private int GetTreesInRoute(int right, int down, IEnumerable<string> lines)
        {
            var trees = 0;
            var treeSymbol = '#';

            for (int y = 0; y < lines.Count(); y += down)
            {
                var currentLine = lines.ElementAt(y);
                var slopeItemOnCurrentLine = currentLine[((y * right) / down) % currentLine.Length];

                if (slopeItemOnCurrentLine == treeSymbol)
                {
                    trees++;
                }
            }

            return trees;
        }
    }
}
