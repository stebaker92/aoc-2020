namespace aoc_2020
{
    class GameConsole
    {
        public int Accumulator { get; private set; }
        public Instruction[] Instructions { get; init; }

        internal int Run()
        {
            var instructionToRun = 0;

            while (true)
            {
                var instruction = Instructions[instructionToRun];

                if (instruction.Executed)
                {
                    return Accumulator;
                }

                switch (instruction.Operation)
                {
                    case "nop":
                        instructionToRun++;
                        break;
                    case "acc":
                        Accumulator += instruction.Argument;
                        instructionToRun++;
                        break;
                    case "jmp":
                        instructionToRun += instruction.Argument;
                        break;
                }

                instruction.Executed = true;

                if (instructionToRun >= Instructions.Length)
                {
                    break;
                }
            }

            return 0;
        }
    }
}
