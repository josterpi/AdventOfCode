using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode.day02;

namespace AdventOfCode.day05
{
    class Day5
    {
        public static void Solve()
        {
            var rawInput = File.ReadAllText("day05/day5.txt");
            var input = rawInput.Split(",").ToList().Select(int.Parse).ToList();

            Day2.Intcode(input, 225, 1);

        }
    }
}
