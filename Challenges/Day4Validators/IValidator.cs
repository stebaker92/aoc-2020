using System.Collections.Generic;

namespace aoc_2020
{
    internal interface IValidator
    {
        bool Validate(Dictionary<string, string> value);
    }
}