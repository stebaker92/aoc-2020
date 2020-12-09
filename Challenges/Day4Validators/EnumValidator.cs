using System.Collections.Generic;
using System.Linq;

namespace aoc_2020
{
    internal class EnumValidator : IValidator
    {
        private string key;
        private string[] validValues;

        public EnumValidator(string key, string[] acceptedValues)
        {
            this.key = key;
            this.validValues = acceptedValues;
        }

        public bool Validate(Dictionary<string, string> passport)
        {
            return validValues.Contains(passport.GetValueOrDefault(key));
        }
    }
}