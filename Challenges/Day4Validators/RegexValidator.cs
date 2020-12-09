using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace aoc_2020
{
    internal class RegexValidator : IValidator
    {
        private string key;
        private string regex;

        public RegexValidator(string key, string regex)
        {
            this.key = key;
            this.regex = regex;
        }

        public bool Validate(Dictionary<string, string> dict)
        {
            var value = dict.GetValueOrDefault(key);

            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            return Regex.IsMatch(value, regex);
        }
    }
}