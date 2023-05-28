using System.Xml.Linq;

namespace HackerRankSolutions.ThePowerSum
{
    public class ThePowerSum
    {
        public static int Solve(int x, int n)
        {
            solutions = new();
            var chosen = new HashSet<int>();
            int result = PowerSum(x, n, chosen, 1);
            return result;
        }

        private static List<HashSet<int>> solutions = new();
        public static int PowerSum(int x, int n, HashSet<int> chosen, int lowerBound)
        {        
            if (x == 0) 
            {
                if (!solutions.Any(s => s.SetEquals(chosen))) 
                { 
                    solutions.Add(chosen); 
                }                
                return 1;
            }

            if (x < 0) return 0;

            int count = 0;
            double upperBound = Math.Ceiling(NthRoot(x, n));
            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (!chosen.Contains(i))
                {
                    var chosenPlus = new HashSet<int>(chosen) { i };
                    int iToN = (int)Math.Pow(i, n);
                    count += PowerSum(x - iToN, n, chosenPlus, i + 1);          
                }                
            }
            return count;
        }

        private static double NthRoot(int x, int n)
        {
            return Math.Pow(x, 1 / (double)n);
        }

        public static void SolveInput()
        {
            int x = Convert.ToInt32(Console.ReadLine().Trim());

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            int result = Solve(x, n);
            Console.WriteLine(result);
        }
    }
}
