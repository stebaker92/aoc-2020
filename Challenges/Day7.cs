using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc_2020
{
    class Day7 : IDay
    {
        public IEnumerable<string> Run()
        {
            var lines = File.ReadAllLines("./input/day7");

            var entries = lines.Select(x => (x));

            return new[]
            {
                Part1(entries).ToString(),
                Part2(entries).ToString()
            };
        }

        public int Part1(IEnumerable<string> entries)
        {
            Dictionary<string, Bag> bagCollection = entries
                .Select(e => Bag.Parse(e))
                .ToDictionary(bag => bag.Color, bag => bag);

            var canContainCount = 0;
            foreach (var bag in bagCollection.Keys)
            {
                var canContainShinyGold = BagCanContain("shiny gold", bag, bagCollection);
                if (canContainShinyGold)
                {
                    canContainCount++;
                }
            }

            return canContainCount;
        }

        private bool BagCanContain(string colorToFind, string bagToCheck, Dictionary<string, Bag> rules)
        {
            return rules[bagToCheck].CanHold
                .Where(bagColor => BagCanContain(colorToFind, rules[bagColor.Key].Color, rules) || bagColor.Key == colorToFind)
                .Any();
        }

        private int GetChildBagsCount(Bag bag, Dictionary<string, Bag> allBags)
        {
            var childBags = bag.CanHold;

            if (!childBags.Any())
            {
                return 0;
            }

            var count = 0;
            foreach (var childBag in childBags)
            {
                count += childBag.Value;
                count += GetChildBagsCount(allBags[childBag.Key], allBags) * childBag.Value;
            }

            return count;
        }

        public int Part2(IEnumerable<string> entries)
        {
            Dictionary<string, Bag> bagCollection = entries.Select(e => Bag.Parse(e)).ToDictionary(bag => bag.Color, bag => bag);

            var goldBag = bagCollection["shiny gold"];

            var count = GetChildBagsCount(goldBag, bagCollection);

            return count;
        }

    }
}
