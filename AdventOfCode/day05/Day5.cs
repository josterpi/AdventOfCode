using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode.day02;

namespace AdventOfCode.day05
{
    enum OpCode
    {
        Add = 1,
        Mul = 2,
        In = 3,
        Out = 4,
        Jnz = 5,
        Jz = 6,
        Lt = 7,
        Eq = 8,
        Hlt = 99
    }

    class Day5
    {
        public static void Solve()
        {
            var rawInput = File.ReadAllText("day05/day5.txt");
            var input = rawInput.Split(",").ToList().Select(int.Parse).ToList();

            //Day2.Intcode(input, 225, 1);
            new IntCode(input).Execute();

        }
    }
    public class IntCode
    {
        private List<int> RAM { get; set; }
        private int Pointer { get; set; }

        public IntCode(List<int> prog)
        {
            RAM = new List<int>(prog); // Make a copy
            Pointer = 0;
        }

        private int Arg(int position)
        {
            if ((int)(RAM[Pointer] / Math.Pow(10, position + 1)) % 10 == 0)
            {
                return RAM[RAM[Pointer + position]];
            } else
            {
                return RAM[Pointer + position];
            }
        }

        public int Execute()
        {
            while (true)
            {
                OpCode opcode = (OpCode)(RAM[Pointer] % 100);
                switch (opcode)
                {
                    case OpCode.Add: RAM[RAM[Pointer + 3]] = Arg(1) + Arg(2); Pointer += 4; break;
                    case OpCode.Mul: RAM[RAM[Pointer + 3]] = Arg(1) * Arg(2); Pointer += 4; break;
                    case OpCode.In:
                        string input;
                        Console.Write("Input: ");
                        input = Console.ReadLine();
                        RAM[RAM[Pointer + 1]] = int.Parse(input);
                        Pointer += 2;
                        break;
                    case OpCode.Out:
                        Console.WriteLine("Ouput: {0}", Arg(1));
                        Pointer += 2;
                        break;
                    case OpCode.Jnz: Pointer = Arg(1) != 0 ? Arg(2) : Pointer + 3; break;
                    case OpCode.Jz: Pointer = Arg(1) == 0 ? Arg(2) : Pointer + 3; break;
                    case OpCode.Lt: RAM[RAM[Pointer + 3]] = Arg(1) < Arg(2) ? 1 : 0; Pointer += 4;  break;
                    case OpCode.Eq: RAM[RAM[Pointer + 3]] = Arg(1) == Arg(2) ? 1 : 0; Pointer += 4; break;
                    case OpCode.Hlt: return RAM[0];
                    default: throw new ArgumentException("Invalid opcode: " + opcode);
                }
            }
        }
    }
}
