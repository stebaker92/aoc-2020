using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_2020
{
    class Day6 : IDay
    {
        public IEnumerable<string> Run()
        {
            var rawInput = File.ReadAllText("./input/day6");

            return new[]
            {
                Part1(rawInput).ToString(),
                Part2(rawInput).ToString()
            };
        }

        public int Part1(string rawInput)
        {
            var sum = rawInput
                .Split(Environment.NewLine + Environment.NewLine)
                .Select(group => group.Replace(Environment.NewLine, ""))
                .Select(group => group.Distinct().Count())
                .Sum();

            return sum;
        }

        public int Part2(string rawInput)
        {
            var groups = rawInput
                .Split(Environment.NewLine + Environment.NewLine)
                .Select(groupRaw => groupRaw.Split(Environment.NewLine));

            var distinctAnswerCountPerGroup = new List<int>();

            foreach (var group in groups)
            {
                var distinctAnswersForGroup = group.SelectMany(person => person.ToCharArray()).Distinct().ToList();

                var answeredByAllInGroup = distinctAnswersForGroup.Count(answer => group.All(person => person.Contains(answer)));

                distinctAnswerCountPerGroup.Add(answeredByAllInGroup);
            }

            return distinctAnswerCountPerGroup.Sum();
        }
    }
}
