using System.Collections.Generic;

namespace aoc_2020
{
    internal class LengthValidator : IValidator
    {
        private string key;
        private int length;

        public LengthValidator(string key, int length)
        {
            this.key = key;
            this.length = length;
        }

        public bool Validate(Dictionary<string, string> passport)
        {
            var value = passport.GetValueOrDefault(key);

            return value?.Length == length;
        }
    }
}