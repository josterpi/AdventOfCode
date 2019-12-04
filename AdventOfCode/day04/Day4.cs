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
        }

        static bool TestPassword(string pwd)
        {
            // password length must be 6
            if (pwd.Length != 6) return false;
            // two adjacent digits are the same
            var sameAdjecent = false;
            for (var i = 0; i < pwd.Length - 1; i++)
            {
                if (pwd[i] == pwd[i+1])
                {
                    sameAdjecent = true;
                    break;
                }
            }
            if (!sameAdjecent) return false;
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
