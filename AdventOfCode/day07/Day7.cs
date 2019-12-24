using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode.day05;

namespace AdventOfCode.day07
{
    class Day7
    {
        public static void Solve()
        {
            var rawInput = File.ReadAllText("day07/day7.txt");
            var input = rawInput.Split(",").ToList().Select(int.Parse).ToList();

            int Run(int input1, int input2) => new IntCode(input).Execute(input1, input2).Last();

            int maxSignal = 0;
            foreach (var phaseSetting in Combinations())
            {
                var signal = 0;
                for (var amp = 0; amp < 5; amp++)
                {
                    signal = Run(phaseSetting[amp], signal);
                }
                if (signal > maxSignal) maxSignal = signal;
            }
            
            Console.WriteLine("Final signal: {0}", maxSignal);
        }

        static IEnumerable<int[]> Combinations()
        {
            int[] S = new int[] { 0, 1, 2, 3, 4 };
            int kInt = 12345;
            int Extract(int k, int i) => ((int)(k / Math.Pow(10, i)) % 10) - 1;
            int[] kIndex(int k) => new int[] { Extract(k, 4), Extract(k, 3), Extract(k, 2), Extract(k, 1), Extract(k, 0) };
            int[] GetIndex(int[] k) => new int[] { S[k[0]], S[k[1]], S[k[2]], S[k[3]], S[k[4]] };
            for (var i = kInt; i <= 54321; i++)
            {
                var x = kIndex(i);
                if (x.Max() == 4 && x.Min() == 0 && x.Distinct().Count() == x.Count())
                {
                    yield return GetIndex(x);
                }
            }

        }

    }
}

