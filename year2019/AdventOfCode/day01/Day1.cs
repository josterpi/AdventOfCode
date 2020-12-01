using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.day01
{
    class Day1
    {
        public static void Solve()
        {
            var input = File.ReadAllLines("day01/day1.txt").ToList();
            var numInput = input.Select(double.Parse);
            double sum = 0;
            double sum2 = 0;
            foreach (var line in numInput)
            {
                sum += Math.Floor(line / 3) - 2;
            }
            Console.WriteLine("Part 1: {0}", sum);

            foreach (var line in numInput)
            {
                sum2 += CalculateFuel(line);
            }
            Console.WriteLine("Part 2: {0}", sum2);
        }
        static double CalculateFuel(double weight, double total = 0)
        {
            var result = Math.Floor(weight / 3) - 2;
            if (result > 0)
            {
                return CalculateFuel(result, total + result);
            }
            return total;
        }
    }
}
