using System.Collections.Generic;

namespace aoc_2020
{
    internal class RangeValidator : IValidator
    {
        private string key;
        private int min;
        private int max;

        public RangeValidator(string key, int min, int max)
        {
            this.key = key;
            this.min = min;
            this.max = max;
        }

        public bool Validate(Dictionary<string, string> dict)
        {
            var value = dict.GetValueOrDefault(key);

            return Validate(value);
        }

        public bool Validate(string value)
        {
            int.TryParse(value, out var parsed);
            
            return parsed >= min && parsed <= max;
        }
    }
}
