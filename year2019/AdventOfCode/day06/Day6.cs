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
            // Part 1
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
            Console.WriteLine("Part 1: {0}", directOrbits + indirectOrbits);

            // Part 2
            List<string> you = new List<string>(), santa = new List<string>();
            var youOrbit = input.Find(x => x[1] == "YOU");
            var santaOrbit = input.Find(x => x[1] == "SAN");
            while (youOrbit != null)
            {
                you.Add(youOrbit[0]);
                youOrbit = input.Find(x => x[1] == youOrbit[0]);
            }
            while (santaOrbit != null)
            {
                santa.Add(santaOrbit[0]);
                santaOrbit = input.Find(x => x[1] == santaOrbit[0]);
            }
            var intersections = you.Intersect(santa);
            Console.WriteLine("Part 2: {0}", you.FindIndex(x => intersections.First() == x) + santa.FindIndex(x => intersections.First() == x));
        }
    }
}
