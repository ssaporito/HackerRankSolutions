using System.Linq;
using Xunit;

namespace HackerRankSolutions.Candies
{
    public class Candies
    {
        public static long Solve(int n, List<int> arr)
        {
            _arr = arr;
            var candies = Enumerable.Repeat<long>(1, n).ToList();
            
            for (int i = 0; i < n; i++)
            {
                candies[i] = CandiesCount(i);
            }         
            Console.WriteLine(string.Join(" ", candies));
            return candies.Sum();
        }

        private static List<int> _arr = new List<int>();
        private static Dictionary<int, long> candiesMemo = new Dictionary<int, long>();
        public static long CandiesCount(int i)
        {
            if (candiesMemo.ContainsKey(i)) return candiesMemo[i];

            var diffs = new List<(int direction,int value)>();
            if (i > 0)
            {
                int diffLeft = _arr[i].CompareTo(_arr[i - 1]);
                diffs.Add((-1, diffLeft));
            }
            
            if (i < _arr.Count - 1)
            {
                int diffRight = _arr[i].CompareTo(_arr[i + 1]);
                diffs.Add((1, diffRight));
            }
                        
            var highs = diffs.Where(d => d.value == 1).ToList();
            long result;
            if (diffs.All(d => d.value == 0) || !highs.Any())
            {
                result = 1;
            }
            else
            {
                long highCount = highs.Max(p => CandiesCount(i + p.direction)) + 1;
                result = highCount;                
            }

            candiesMemo[i] = result;
            return result;
        }

        public static void SolveInput()
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int arrItem = Convert.ToInt32(Console.ReadLine().Trim());
                arr.Add(arrItem);
            }
            
            long result = Solve(n, arr);
            Console.WriteLine(result);
        }
    }
}
