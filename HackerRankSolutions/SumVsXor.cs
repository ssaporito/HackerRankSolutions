using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.SumVsXor
{
    public class SumVsXor
    {
        public static long SumXor(long n)
        {
            return SumXorRec(n, 1);
        }

        public static long SumXorRec(long n, long count)
        {
            if (n < 1) return count;
            long d = n % 2;
            n = (n - d) / 2;
            count *= d == 1 ? 1 : 2;
            return SumXorRec(n, count);
        }

        public static long SumXorProc(long n)
        {
            long count = 1;
            for (int i = 0; n >= 1; i++)
            {
                long d = n % 2;
                n = (n - d) / 2;
                count *= d == 1 ? 1 : 2;
            }
            return count;
        }

        public static bool[] GetDigits(long n)
        {
            bool[] digits = new bool[64];
            for (int i = 0; n >= 1; i++)
            {
                long r = n % 2;
                n -= r;
                n /= 2;
                digits[i] = r == 1;
            }
            return digits;
        }
    }
}
