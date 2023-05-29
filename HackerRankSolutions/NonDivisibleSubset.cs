namespace HackerRankSolutions.NonDivisibleSubset
{
    public class NonDivisibleSubset
    {
        public static int LongestNonDivisibleSubset(int k, List<int> s)
        {
            var modValues = Enumerable.Repeat(0, k).ToList();

            for (int i = 0; i < s.Count; i++)
            {
                int m = s[i] % k;
                modValues[m] = m != k - m ? modValues[m] + 1 : 1;
            }

            int count = modValues[0] != 0 ? 1 : 0;
            for (int m = 1; m <= k / 2; m++)
            {                
                count += Math.Max(modValues[m], modValues[k - m]);
            }
            return count;
        }
    }
}
