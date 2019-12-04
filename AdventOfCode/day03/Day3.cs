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

            //var wire1 = new HashSet<WireSegment>(new WireSegmentEqual());

        }
    }

    class WireSegment: IEquatable<WireSegment>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public WireSegment(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(WireSegment other)
        {
            if (X == other.X && Y == other.Y) return true;
            return false;
        }
        public override int GetHashCode()
        {
            int hCode = X ^ Y;
            return hCode.GetHashCode();
        }
    }
    /*
    class WireSegmentEqual : EqualityComparer<WireSegment>
    {
        public override bool Equals(WireSegment w1, WireSegment w2)
        {
            if (w1.X == w2.X && w1.Y == w2.Y) return true;
            return false;
        }

        public override int GetHashCode(WireSegment obj)
        {
            int hCode = obj.X ^ obj.Y;
            return hCode.GetHashCode();
        }
    }*/
    class WireGrid : HashSet<WireSegment>
    {

    }
}
