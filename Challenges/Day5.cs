using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_2020
{
    class Day5 : IDay
    {
        public IEnumerable<string> Run()
        {
            var lines = File.ReadAllLines("./input/day5");

            var entries = lines.Select(x => (x));

            return new[]
            {
                Part1(entries).ToString(),
                Part2(entries).ToString()
            };
        }

        public int Part1(IEnumerable<string> entries)
        {
            var highestSeatId = entries
                .Select(e => ParseRowAndColumn(e))
                .Select(kv => GetSeatId(kv.row, kv.column))
                .Max();

            return highestSeatId;
        }

        private (int row, int column) ParseRowAndColumn(string input)
        {
            var rowRaw = input.Substring(0, 7);
            var columnRaw = input.Substring(7, 3);

            var rowBinaryString = rowRaw
                .Replace('F', '0')
                .Replace('B', '1')
                .ToString();

            var row = Convert.ToInt32(rowBinaryString, fromBase: 2);

            var columnBinaryString = columnRaw
                .Replace('L', '0')
                .Replace('R', '1')
                .ToString();

            var column = Convert.ToInt32(columnBinaryString, fromBase: 2);

            return (row, column);
        }

        public int Part2(IEnumerable<string> entries)
        {
            var seatIds = entries
                .Select(e => ParseRowAndColumn(e))
                .Select(tuple => GetSeatId(tuple.row, tuple.column))
                .OrderBy(seatId => seatId)
                .ToList();

            var seatWithMissingNextId = seatIds
                .Where((id, index) => seatIds[index + 1] != id + 1)
                .First();

            return seatWithMissingNextId + 1;
        }

        private int GetSeatId(int row, int column)
        {
            return row * 8 + column;
        }
    }
}
