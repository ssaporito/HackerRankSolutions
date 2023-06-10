using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.KFactorization
{
    public class KFactorization
    {
        public static List<int>? KFactorize(int n, List<int> A)
        {
            A.Sort();
            var chosen = ChosenFactors(A, new List<int>(), A.Count - 1, n);
            if (chosen != null)
            {
                chosen.Reverse();
                int curr = 1;
                var result = new List<int>() { curr };
                foreach (var num in chosen)
                {
                    curr *= num;
                    result.Add(curr);
                }
                return result;
            }
            return null;
        }

        private static List<int>? ChosenFactors(List<int> A, List<int> chosen, int upperBound, int n)
        {
            Console.WriteLine($"n: {n}");
            if (n == 1)
                return chosen;

            if (upperBound < 0)
                return null;

            for (int i = upperBound; i >= 0; i--)
            {
                var num = A[i];
                if (n % num == 0)
                {
                    Console.WriteLine($"{num} is compatible");
                    var newChosen = new List<int>(chosen)
                    {
                        num
                    };
                    var result = ChosenFactors(A, newChosen, i, n / num);
                    if (result != null)
                    {
                        Console.WriteLine($"result: {string.Join(' ', result)}");
                        return result;
                    }
                }
                else
                {
                    Console.WriteLine($"{num} is incompatible");
                }

            }

            return null;
        }
    }
}
