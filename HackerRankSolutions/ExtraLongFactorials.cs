using System.Numerics;

namespace HackerRankSolutions.ExtraLongFactorials
{ 
    class ExtraLongFactorials
    {

        /*
         * Complete the 'extraLongFactorials' function below.
         *
         * The function accepts INTEGER n as parameter.
         */

        public static void Solve(int n)
        {
            var result = BigInteger.One;
            for (int i = 1; i <= n; i++)
            {
                var bigI = new BigInteger(i);
                result = BigInteger.Multiply(result, bigI);
            }
            Console.WriteLine(result);
        }

        public static void SolveInput()
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            Solve(n);
        }
    }

}