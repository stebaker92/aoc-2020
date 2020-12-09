using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_2020
{
    class Day4 : IDay
    {
        public IEnumerable<string> Run()
        {
            var rawInput = File.ReadAllText("./input/day4");

            return new[]
            {
                Part1(rawInput).ToString(),
                Part2(rawInput).ToString()
            };
        }

        public int Part1(string raw)
        {
            var entries = ParseEntries(raw);

            var requiredFields = new[]{
                "byr",
                "iyr",
                "eyr",
                "hgt",
                "hcl",
                "ecl",
                "pid",
                // "cid", // cid is optional
            };

            var validEntries = entries.Where(passport =>
            {
                return requiredFields.All(key => passport.ContainsKey(key));
            });

            return validEntries.Count();
        }

        public int Part2(string raw)
        {
            var entries = ParseEntries(raw);

            var validators = new IValidator[]
            {
                new RangeValidator("byr", 1920, 2002),
                new RangeValidator("iyr", 2010, 2020),
                new RangeValidator("eyr", 2020, 2030),
                new AirportHeightValidator("hgt"),
                new RegexValidator("hcl", "^#[0-9a-fA-F]{6}$"), // # followed by exactly 6 chars that are 0-9,a-f or A-F, with no characters after the hexcode
                new EnumValidator("ecl", "amb blu brn gry grn hzl oth".Split(' ')),
                new LengthValidator("pid", 9),
            };

            var validEntries = entries.Where(passport =>
            {
                return validators.All(v => v.Validate(passport));
            });

            return validEntries.Count();
        }

        private List<Dictionary<string, string>> ParseEntries(string raw)
        {
            var users = new List<Dictionary<string, string>>();

            foreach (var passport in raw.Split(Environment.NewLine + Environment.NewLine))
            {
                var passportAsDictionary = passport.Replace(Environment.NewLine, " ")
                    .Split(' ')
                    .Select(x => x.Split(':')).ToDictionary(key => key[0], v => v[1]);

                users.Add(passportAsDictionary);
            }

            return users;
        }

    }
}
