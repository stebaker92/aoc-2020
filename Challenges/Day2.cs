using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_2020
{
    class Day2 : IDay
    {
        public IEnumerable<string> Run()
        {
            var lines = File.ReadAllLines("./input/day2");

            var entries = lines.Select(x => x);

            return new[]
            {
                Part1(lines).ToString(),
                Part2(lines).ToString(),
            };
        }

        public int Part1(IEnumerable<string> lines)
        {
            var validPasswordsCount = lines
                .Where(line => IsSledPasswordValid(line))
                .Count();

            return validPasswordsCount;

            throw new Exception("No answer found");
        }

        public int Part2(IEnumerable<string> lines)
        {
            var validPasswordsCount = lines
                .Where(line => IsTobogganPasswordValid(line))
                .Count();

            return validPasswordsCount;
        }

        private bool IsSledPasswordValid(string line)
        {
            // Yes, this could be improved but it works for this kata :shrug:

            var password = line.Split(":")[1].TrimStart();
            var requiredChar = Char.Parse(line.Split(":")[0].Split(' ')[1]);
            var requiredLength = line.Split(":")[0].Split(' ')[0];
            var minLength = int.Parse(requiredLength.Split('-')[0]);
            var maxLength = int.Parse(requiredLength.Split('-')[1]);

            var requiredCharCount = password.ToCharArray().Count(x => x == requiredChar);

            return requiredCharCount >= minLength && requiredCharCount <= maxLength;
        }

        private bool IsTobogganPasswordValid(string line)
        {
            // Yes, this could be improved but it works for this kata :shrug:

            var password = line.Split(":")[1].TrimStart();
            var requiredChar = Char.Parse(line.Split(":")[0].Split(' ')[1]);
            var requiredLength = line.Split(":")[0].Split(' ')[0];
            
            var firstIndex = int.Parse(requiredLength.Split('-')[0]);
            var secondIndex = int.Parse(requiredLength.Split('-')[1]);

            var requiredCharCount = password.ToCharArray().Count(x => x == requiredChar);

            // Index's aren't 0 based in Toboggan
            var firstRequirementMet = password[firstIndex - 1] == requiredChar;
            var secondRequirementMet = password[secondIndex - 1] == requiredChar;

            return (firstRequirementMet && !secondRequirementMet) || (!firstRequirementMet && secondRequirementMet);
        }
    }
}
