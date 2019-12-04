using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

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

        static int Intcode(List<int> prog, int noun, int verb)
        {
            var mem = new List<int>(prog);
            
            mem[1] = noun; mem[2] = verb;

            var position = 0;
            int opcode, operand1, operand2, result;
            while (mem[position] != 99)
            {
                opcode = mem[position];
                operand1 = mem[position + 1];
                operand2 = mem[position + 2];
                result = mem[position + 3];
                switch (opcode)
                {
                    case 1:
                        mem[result] = mem[operand1] + mem[operand2];
                        break;
                    case 2:
                        mem[result] = mem[operand1] * mem[operand2];
                        break;
                }
                position += 4;
            }
            return mem[0];
        }
    }
}
