using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.day03
{
    class Day3
    {
        public static void Solve()
        {
            var rawInput = File.ReadAllLines("day03/day3.txt").ToList();
            var wire1Input = rawInput[0].Split(",").ToList();
            var wire2Input = rawInput[1].Split(",").ToList();

            // Key: x,y coordinates. Value: number of times each wire is on that point
            var grid = new Dictionary<(int x, int y), (int w1, int w2)>();
            int w1Inc = 1, w2Inc = 0;
            foreach (var wire in new List<List<string>>() { wire1Input, wire2Input })
            {
                (int x, int y) cursor = (0, 0);
                foreach (var segment in wire)
                {
                    var direction = segment[0];
                    var distance = int.Parse(segment.Substring(1));
                    IEnumerable<(int x, int y)> points = new List<(int x, int y)>();
                    switch (direction)
                    {
                        case 'R':
                            points = Enumerable.Repeat(cursor.y, distance).Zip(Enumerable.Range(cursor.x+1, distance), (y, x) => (x, y));
                            cursor.x += distance;
                            break;
                        case 'L':
                            points = Enumerable.Repeat(cursor.y, distance).Zip(Enumerable.Range(cursor.x - distance, distance), (y, x) => (x, y));
                            cursor.x -= distance;
                            break;
                        case 'U':
                            points = Enumerable.Repeat(cursor.x, distance).Zip(Enumerable.Range(cursor.y+1, distance), (x, y) => (x, y));
                            cursor.y += distance;
                            break;
                        case 'D':
                            points = Enumerable.Repeat(cursor.x, distance).Zip(Enumerable.Range(cursor.y - distance, distance), (x, y) => (x, y));
                            cursor.y -= distance;
                            break;
                    }
                    foreach (var point in points)
                    {
                        if (!grid.ContainsKey(point)) grid.Add(point, (w1: 0, w2: 0));
                        grid[point] = (w1: grid[point].w1 + w1Inc, w2: grid[point].w2 + w2Inc);
                    }
                }
                w1Inc = 0; w2Inc = 1;
            }

            var intersections = from keyValue in grid
                                where keyValue.Value.w1 > 0 && keyValue.Value.w2 > 0
                                select ManhDistanceToOrigin(keyValue.Key);

            Console.WriteLine("Part 1: {0}", intersections.Min());

        }
        private static int ManhDistanceToOrigin((int x, int y) p)
        {
            return Math.Abs(p.x) + Math.Abs(p.y);
        }
    }
}
