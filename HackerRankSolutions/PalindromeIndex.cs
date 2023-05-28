using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.PalindromeIndex
{
    public class PalindromeIndex
    {
        public static int Solve(string s)
        {
            int length = s.Length;
            int middle = (int)Math.Floor(length / (double)2);

            int result = -1;
            for (int i = 0; i <= middle; i++)
            {
                int iMirror = length - i - 1;
                if (s[i] != s[iMirror])
                {                    
                    var testIndices = new List<int> { i, iMirror};
                    foreach(int index in testIndices)
                    {
                        var sb = new StringBuilder(s);
                        sb.Remove(index, 1);
                        if (IsPalindrome(sb))
                        {
                            return index;
                        }
                    }
                    break;
                }
            }
            return result;
        }

        public static bool IsPalindrome(StringBuilder sb)
        {
            bool result = true;
            int middle = (int)Math.Floor(sb.Length / (double)2);
            for (int i = 0; i <= middle; i++)
            {
                result = result && sb[i] == sb[sb.Length - i - 1];
                if (!result) break;
            }
            return result;
        }

        public static void SolveInput()
        {
            string s = Console.ReadLine();
            int result = Solve(s);
            Console.WriteLine(result);
        }
    }
}
