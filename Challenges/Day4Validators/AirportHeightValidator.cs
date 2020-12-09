using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace aoc_2020
{
    internal class AirportHeightValidator : IValidator
    {
        private string key;

        public AirportHeightValidator(string key)
        {
            this.key = key;
        }

        public bool Validate(Dictionary<string, string> dict)
        {
            var rawHeight = dict.GetValueOrDefault(key);

            if (string.IsNullOrEmpty(rawHeight))
            {
                return false;
            }

            var units = Regex.Match(rawHeight, @"(cm|in)").Value;
            var height = Regex.Match(rawHeight, @"\d+").Value;

            switch (units)
            {
                case "cm": return new RangeValidator(key, 150, 193).Validate(height);
                case "in": return new RangeValidator(key, 59, 76).Validate(height);
                default: return false;
            }
        }
    }
}
