using System.Collections.Generic;
using System.Linq;

internal class Bag
{
    internal string Color { get; init; }

    internal Dictionary<string, int> CanHold { get; init; }

    internal static Bag Parse(string input)
    {
        // More string splitting non-sense.
        // TODO - use regex
        var bagColor = input.Split("contain")[0].Replace("bags", "").Trim();

        var rulesRaw = input.Split("contain")[1]
            .Split(",")
            .Select(rule => rule.Trim().TrimEnd('.'));

        var canHoldColors = new Dictionary<string, int>();

        foreach (var rule in rulesRaw)
        {
            // rule should be formatted like '2 bright white bags'
            // or 'no other bags'

            int.TryParse(rule.Split(" ")[0], out var ruleAmount);

            if (ruleAmount == 0)
            {
                continue;
            }
            var ruleColor = rule
                .Replace("bags", "")
                .Replace("bag", "")
                .Replace(ruleAmount.ToString(), "")
                .Trim();

            canHoldColors.Add(ruleColor, ruleAmount);
        }

        return new Bag
        {
            Color = bagColor,
            CanHold = canHoldColors
        };
    }
}