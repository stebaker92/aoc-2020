using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var days = new List<IDay>
            {
                new Day1(),
                new Day2(),
                new Day3(),
            };

            foreach (var day in days)
            {
                Console.WriteLine($"{day.GetType().Name}:");

                var answers = day.Run().ToList();

                for (int i = 0; i < answers.Count; i++)
                {
                    Console.WriteLine($"Part{i + 1} Answer: {answers[i]}");
                }

                System.Console.WriteLine();
            }
        }
    }
}
