using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.day06
{
    class Day6
    {
        public static void Solve()
        {
            var rawInput = File.ReadAllLines("day06/day6.txt").ToList();
            var input = rawInput.Select(x => x.Split(')')).ToList();
            int directOrbits = 0, indirectOrbits = 0;

            var spaceObjects = new HashSet<string>();
            foreach (var orbit in input)
            {
                spaceObjects.Add(orbit[0]);
                spaceObjects.Add(orbit[1]);
            }
            foreach (var obj in spaceObjects)
            {
                var orbit = input.Find(x => x[1] == obj);
                if (orbit != null) directOrbits++; else continue;
                orbit = input.Find(x => x[1] == orbit[0]);
                while (orbit != null)
                {
                    indirectOrbits++;
                    orbit = input.Find(x => x[1] == orbit[0]);
                }
            }
            Console.WriteLine("Output: {0}", directOrbits + indirectOrbits);
        }
    }
}
