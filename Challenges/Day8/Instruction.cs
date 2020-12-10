namespace aoc_2020
{
    class Instruction
    {
        internal int Argument;
        internal string Operation;
        public bool Executed { get; set; }

        internal Instruction(string input)
        {
            Operation = input.Split(" ")[0];
            Argument = int.Parse(input.Split(" ")[1]);
        }
    }
}
