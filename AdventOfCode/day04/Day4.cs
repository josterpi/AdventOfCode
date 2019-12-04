using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.day04
{
    class Day4
    {
        public static void Solve()
        {
            var inputMin = 353096;
            var inputMax = 843212;

            var passwordCandidates = new List<string>();
            
            for (var i = inputMin; i <= inputMax; i++)
            {
                var pwdCandidate = i.ToString();
                if (TestPassword(pwdCandidate))
                {
                    passwordCandidates.Add(pwdCandidate);
                }
            }
            Console.WriteLine("Part 1: {0}", passwordCandidates.Count);
            var part2Count = 0;
            foreach (var candidate in passwordCandidates)
            {
                if (TestPassword(candidate, part2: true)) part2Count++;
            }
            Console.WriteLine("Part 2: {0}", part2Count);
            /*
            Console.WriteLine("111111: {0}", TestPassword("111111"));
            Console.WriteLine("223450: {0}", TestPassword("223450"));
            Console.WriteLine("123789: {0}", TestPassword("123789"));
            Console.WriteLine("112233: {0}", TestPassword("112233", true));
            Console.WriteLine("123444: {0}", TestPassword("123444", true));
            Console.WriteLine("111122: {0}", TestPassword("111122", true));
            */
        }

        static bool TestPassword(string pwd, bool part2 = false)
        {
            // password length must be 6
            if (pwd.Length != 6) return false;
            // two adjacent digits are the same
            var adjacentLengths = new List<int>();
            var lengthAdjacent = 1;
            for (var i = 0; i < pwd.Length - 1; i++)
            {
                if (pwd[i] == pwd[i+1])
                {
                    lengthAdjacent++;
                } else
                {
                    if (lengthAdjacent > 1) adjacentLengths.Add(lengthAdjacent);
                    lengthAdjacent = 1;
                }
            }
            // For when all digits are the same
            if (lengthAdjacent > 1) adjacentLengths.Add(lengthAdjacent);
            if (part2)
            {
                if (!adjacentLengths.Contains(2)) return false;
            } else
            {
                if (adjacentLengths.Count == 0) return false;
            }
            // digits never decrease
            var neverDecrease = true;
            for (var i = 0; i < pwd.Length - 1; i++)
            {
                if (pwd[i] > pwd[i+1])
                {
                    neverDecrease = false;
                    break;
                }
            }
            if (!neverDecrease) return false;

            return true;
        }
    }
}
