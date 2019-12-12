using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode.day02
{
    class Day2
    {
        public static void Solve()
        {
            var rawInput = File.ReadAllText("day02/day2.txt");
            var input = rawInput.Split(",").ToList().Select(int.Parse).ToList();
                                  
            Console.WriteLine("Part 1: {0}", Intcode(input, 12, 2));

            // Which noun & verb result in 19690720?
            var searchResult = 19690720;
            
            // Search combination of small number and move larger, rather than testing (0, 0-99), (1, 0-99), etc.
            for (var box = 0; ; box++)
            {
                for (var noun = 0; noun <= box; noun++)
                {
                    //Console.WriteLine("{0} - {1}", noun, box);
                    if (TryPartTwo(input, noun, box, searchResult)) return;
                }
                for (var verb = 0; verb < box; verb++)
                {
                    //Console.WriteLine("{0} - {1}", box, verb);
                    if (TryPartTwo(input, box, verb, searchResult)) return;
                }
            }
            Console.WriteLine("No solution 2");
        }

        static bool TryPartTwo(List<int> prog, int noun, int verb, int searchResult)
        {
            try
            {
                var result = Intcode(prog, noun, verb);
                
                if (result == searchResult)
                {
                    Console.WriteLine("Part 2: {0}", 100 * noun + verb);
                    return true;
                }
            }
            catch (ArgumentOutOfRangeException)
            {

            }
            return false;
        }

        public static int Intcode(List<int> prog, int noun, int verb)
        {
            var mem = new List<int>(prog);
            
            mem[1] = noun; mem[2] = verb;

            var ops = new Dictionary<int, Operation> {
                { 1, new AddOp() },
                { 2, new MultiplyOp() },
                { 3, new InputOp() },
                { 4, new OutputOp() }
            };

            var position = 0;
            while (mem[position] != 99)
            {
                int opCode = (int)(mem[position] - Math.Floor(mem[position] / 100.0) * 100);
                var op = ops[opCode];
                op.Execute(mem, position);
                
                position += op.Length;
            }
            return mem[0];
        }
    }
    class Operation
    {
        const char IMMEDIATE_MODE = '0';
        const char VALUE_MODE = '1';

        public virtual int Length { get { return 4; } }
        public virtual void Execute(List<int> memory, int pointer)
        {
            throw new NotImplementedException();
        }
        protected string ProcessMode(int opcode)
        {
            // just pad some zeros to make it easier
            return String.Concat(opcode.ToString().Reverse().Skip(2)) + "000000";
        }
        protected int GetParameter(List<int> memory, int pointer, char mode)
        {
            switch (mode)
            {
                case IMMEDIATE_MODE:
                    return memory[memory[pointer]];
                case VALUE_MODE:
                    return memory[pointer];
            }
            throw new Exception("Parameter mode not recognized");
        }

    }
    class AddOp : Operation
    {
        override public void Execute(List<int> memory, int pointer)
        {
            var modes = ProcessMode(memory[pointer]);
            memory[memory[pointer + 3]] = GetParameter(memory, pointer + 1, modes[0]) + GetParameter(memory, pointer + 2, modes[1]);
        }
    }
    class MultiplyOp : Operation
    {
        override public void Execute(List<int> memory, int pointer)
        {
            var modes = ProcessMode(memory[pointer]);
            memory[memory[pointer + 3]] = GetParameter(memory, pointer + 1, modes[0]) * GetParameter(memory, pointer + 2, modes[1]);
        }
    }
    class InputOp : Operation
    {
        public override int Length { get { return 2; } }
        public override void Execute(List<int> memory, int pointer)
        {
            string input;
            Console.Write("Input: ");
            input = Console.ReadLine();
            memory[memory[pointer + 1]] = int.Parse(input);
        }
    }
    class OutputOp : Operation
    {
        public override int Length { get { return 2; } }
        public override void Execute(List<int> memory, int pointer)
        {
            var modes = ProcessMode(memory[pointer]);
            Console.WriteLine("Ouput: {0}", GetParameter(memory, pointer + 1, modes[0]));
        }
    }
}
