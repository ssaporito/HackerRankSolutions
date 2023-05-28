using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.RecursiveDigitSum
{
    public class RecursiveDigitSum
    {
        private static Dictionary<(string n, int k), int> memo = new();
        public static int Solve(string n, int k)
        {
            if (memo.ContainsKey((n, k))) return memo[(n, k)];
            if (n.Length == 1)
            {
                int prod = Convert.ToInt32(n) * k; 
                if (prod < 10) return memo[(n, k)] = prod;
            }

            long nSum = n.Select(d => (long)(d - '0')).Sum(); // subtracting '0' yields digit numeric value
            long p = nSum * k;
            int result = Solve(p.ToString(), 1);
            return memo[(n, k)] = result;
        }

        public static void SolveInput()
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            string n = firstMultipleInput[0];

            int k = Convert.ToInt32(firstMultipleInput[1]);

            int result = Solve(n, k);
            Console.WriteLine(result);
        }
    }
}
