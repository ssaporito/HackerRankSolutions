using System.Globalization;
using System.Numerics;

namespace HackerRankSolutions.JourneyToMars
{
    public class JourneyToMars
    {        
        static readonly decimal _logTwoBaseTen = Convert.ToDecimal("0.30102999566398119521373889472449", CultureInfo.InvariantCulture);
        public static int Solve(int n, int k)
        {
            var firstK = FirstKPowerOfTwo(n - 1, k);
            var lastK = LastKPowerOfTwo(n - 1, k);
            return firstK + lastK;
        }

        private static int FirstKPowerOfTwo(int n, int k)
        {
            var logTen = _logTwoBaseTen * n;
            var nDigitCount = (int)Math.Ceiling(logTen);
            var expo = logTen - nDigitCount + k;
            var result = (int)Math.Pow(10, (double)expo);
            return result;
        }

        private static int LastKPowerOfTwo(int n, int k)
        {
            var result = (int)BigInteger.ModPow(2, n, BigInteger.Pow(10, k));            
            return result;
        }
    }
}
