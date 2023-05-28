using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.ArithmeticExpressions
{
    public class ArithmeticExpressions
    {
        static readonly char[] _operators = new char[3] { '+', '-', '*' };
        public static string arithmeticExpressions(List<int> a)
        {
            return FindDivisibleBy101(a.ToArray(), 0, null).ToString();
        }

        static readonly HashSet<(int acc, char? op)> _triedInputs = new();
        public static StringBuilder FindDivisibleBy101(int[] remaining, int acc, char? currOp)
        {
            var tuple = (acc, currOp);
            if (_triedInputs.Contains(tuple))
            {
                return null;
            }

            if (!remaining.Any())
            {
                return acc % 101 == 0 ? new StringBuilder() : null;
            }                

            int newCount = remaining.Length - 1;
            var newRemaining = new int[newCount];            
            int operand = remaining[0];
            Array.Copy(remaining, 1, newRemaining, 0, newCount);

            int newAcc = currOp switch
            {
                '+' => acc + operand,
                '-' => acc - operand,
                '*' => acc * operand,
                null => operand
            } % 101;

            string partialResult = (currOp.HasValue ? currOp.ToString() : "") + operand.ToString();
            StringBuilder result = null;
            foreach (char op in _operators)
            {
                result = FindDivisibleBy101(newRemaining.ToArray(), newAcc, op);
                if (result != null)
                {                    
                    result.Insert(0, partialResult);
                    break;
                } 
            }     

            if (result == null)
            {
                _triedInputs.Add(tuple);
            }
            return result;
        }

        public static List<int> StringToParam(string s)
        {
            List<int> arr = s.Trim().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
            return arr;
        }

        public static BigInteger Evaluate(string s)
        {
            var opIndices = new List<int>();
            for(int i = 0; i < s.Length; i++)
            {
                if (_operators.Contains(s[i]))
                {
                    opIndices.Add(i);
                }
            }

            int firstNum = Convert.ToInt32(s[0..opIndices[0]]);
            var acc = new BigInteger(firstNum);
            for (int i = 0; i < opIndices.Count; i++)
            {
                char op = s[opIndices[i]];
                int numStart = opIndices[i] + 1;
                int numEnd = i != opIndices.Count - 1 ? opIndices[i + 1] : s.Length;
                var numString = s[numStart..numEnd];
                int num = Convert.ToInt32(numString);
                acc = op switch
                {
                    '+' => acc + num,
                    '-' => acc - num,
                    '*' => acc * num,
                };              
            }
            return acc;
        }
    }
}
