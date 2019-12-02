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

            // Setup 1202 program alarm
            input[1] = 12; input[2] = 2;

            var position = 0;
            int opcode, operand1, operand2, result;
            while (input[position] != 99)
            {
                opcode = input[position];
                operand1 = input[position + 1];
                operand2 = input[position + 2];
                result = input[position + 3];
                switch (opcode)
                {
                    case 1:
                        input[result] = input[operand1] + input[operand2];
                        break;
                    case 2:
                        input[result] = input[operand1] * input[operand2];
                        break;
                }
                position += 4;
            }
            Console.WriteLine("Part 1: {0}", input[0]);
        }
    }
}
