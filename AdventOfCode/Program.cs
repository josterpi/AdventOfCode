using System;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("day1.txt").ToList();
            var numInput = input.Select(double.Parse);
            double sum = 0;
            foreach (var line in numInput)
            {
                sum += Math.Floor(line / 3) - 2;
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
