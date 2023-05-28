using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.CountStrings
{
    public class CountStrings
    {
        private static readonly char[] _parentheses = new char[2] { '(', ')' };
        public static int CountPossibleStrings(string r, int l)
        {
            var nForMod = new BigInteger(Math.Pow(10, 9) + 7);
            return (int)(CountPossibleRec(r, l) % nForMod);
        }
        
        public static BigInteger CountPossibleRec(string s, int maxLength)
        {
            string r = s[0] == '(' && s[^1] == ')' ? s[1..^1] : s[0..];            
            (Operation operation, int operationIndex) = FindOperationIndex(r);
            var result = operation switch
            {
                Operation.Repeat => CountRepeat(r, maxLength),
                Operation.Union => CountUnion(r, maxLength, operationIndex),
                Operation.Concat => CountConcat(r, maxLength, operationIndex),
                _ => 1,
            };
            return result;
        }

        private static BigInteger CountRepeat(string r, int maxLength)
        {
            return BigInteger.Pow(CountPossibleRec(r[..^1], maxLength), maxLength);
        }

        private static BigInteger CountUnion(string r, int maxLength, int operationIndex)
        {
            string r1 = r[0..operationIndex];
            string r2 = r[(operationIndex + 1)..];
            return CountPossibleRec(r1, maxLength) + CountPossibleRec(r2, maxLength);
        }

        private static BigInteger CountConcat(string r, int maxLength, int operationIndex)
        {
            string r1 = r[0..(operationIndex + 1)];
            string r2 = r[(operationIndex + 1)..];
            return CountPossibleRec(r1, maxLength) * CountPossibleRec(r2, maxLength);
        }

        private static (Operation operation, int index) FindOperationIndex(string r)
        {
            if (r[^1] == '*')
                return (Operation.Repeat, r.Length - 1);

            int currentLevel = 0;
            for (int i = 0; i < r.Length; i++)
            {
                char c = r[i];
                currentLevel += c switch
                {
                    '(' => 1,
                    ')' => -1,
                    _ => 0,
                };

                if (currentLevel == 0)
                {
                    if (c == '|')
                    {
                        return (Operation.Union, i);
                    }

                    if (i + 1 < r.Length && r[i] == ')' && r[i + 1] == '(')
                    {
                        return (Operation.Concat, i);
                    }
                }                
            }

            return (Operation.None, -1);
        }

        private enum Operation
        {
            Union, Concat, Repeat, None
        }
    }
}
