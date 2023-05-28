using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System.Numerics;
using System;

namespace HackerRankSolutions.GameOfThrones2
{
    public class GameOfThrones2
    {
        public static int Solve(string s)
        {
            Dictionary<char, int> letterCount = new();
            foreach (char c in s)
            {
                if (!letterCount.ContainsKey(c))
                    letterCount[c] = 0;
                letterCount[c]++;
            }

            int length = s.Length;
            if (s.Length % 2 == 1)
            {
                char c = letterCount.First(c => c.Value % 2 == 1).Key;
                length--;
                if (letterCount[c] == 1)
                {
                    letterCount.Remove(c);
                }
                else
                {
                    letterCount[c]--;
                }
            }
            int halfLength = length / 2;
            int letterOptions = letterCount.Values.Sum();
            var count = PalindromeCount(halfLength, letterCount);
            var denominator = new BigInteger(Math.Pow(10, 9) + 7);
            int result = (int)(count % denominator);
            Console.WriteLine(_highestN);
            return result;
        }

        public static BigInteger PalindromeCount(int halfLength, Dictionary<char, int> letterCount)
        {
            var denominator = new BigInteger(1);
            foreach (int count in letterCount.Values)
            {
                denominator *= Factorial(count / 2);
            }
            var result = Factorial(halfLength) / denominator;
            return result;
        }

        static readonly List<BigInteger> _factorialMemo = new() { new BigInteger(1) };
        static int _highestN = 0;
        public static BigInteger Factorial(int n)
        {
            if (n <= _highestN)
                return _factorialMemo[n];
            var r = _factorialMemo[_highestN];
            var bigN = new BigInteger(n);
            for (var i = new BigInteger(_highestN + 1); i <= bigN; i++)
            {
                r *= i;
                _factorialMemo.Add(r);
            }

            _highestN = n;
            return r;
        }
    }
}
