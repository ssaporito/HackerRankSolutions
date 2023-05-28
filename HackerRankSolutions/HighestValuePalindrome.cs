using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.HighestValuePalindrome
{
    public class HighestValuePalindrome
    {
        public static string FindHighestValuePalindrome(string s, int k)
        {
            int n = s.Length;
            int middle = (int)Math.Ceiling(n / (double)2) - 1;
            int countChanges = 0;
            var changedIndices = new HashSet<int>();
            var sb = new StringBuilder(s);
            for (int i = 0; i <= middle; i++)
            {
                int iMirror = n - i - 1;
                if (sb[i] != sb[iMirror])
                {
                    int sNum = (int)char.GetNumericValue(sb[i]);
                    int sMirrorNum = (int)char.GetNumericValue(sb[iMirror]);
                    if (sNum > sMirrorNum)
                    {
                        sb[iMirror] = sb[i];
                    }
                    else
                    {
                        sb[i] = sb[iMirror];
                    }
                    changedIndices.Add(i);
                    countChanges++;
                }
            }

            int maxExtraChanges = k - countChanges;
            if (maxExtraChanges < 0) return "-1";

            AssertPalindrome(sb.ToString());

            for (int i = 0; i <= middle && countChanges < k; i++)
            {                
                if (sb[i] != '9')
                {
                    int iMirror = n - i - 1;
                    int upperBound = changedIndices.Contains(i) ? k : k - 1;
                    
                    if (countChanges < upperBound)
                    {                        
                        sb[i] = '9';
                        sb[iMirror] = '9';
                        countChanges += changedIndices.Contains(i) ? 1 : 2;
                    } 
                    else if (countChanges == k - 1)
                    {
                        sb[middle] = '9';
                        countChanges++;
                        break;
                    }                   
                }
            }

            string result = sb.ToString();
            AssertPalindrome(result);
            return result;
        }

        public static void AssertPalindrome(string s)
        {
            int n = s.Length;
            int halfLength = (int)Math.Floor(n / (double)2);
            int middle = (int)Math.Ceiling(n / (double)2) - 1;
            var firstHalf = s.Substring(0, halfLength);
            var secondHalf = new string(s.Substring(middle + 1, halfLength).Reverse().ToArray());
            Debug.Assert(firstHalf == secondHalf);
        }
        public static void SolveInput()
        {
            int k = Convert.ToInt32(Console.ReadLine().TrimEnd());
            string s = Console.ReadLine();

            string result = FindHighestValuePalindrome(s, k);
            Console.WriteLine(result);
        }
    }
}
