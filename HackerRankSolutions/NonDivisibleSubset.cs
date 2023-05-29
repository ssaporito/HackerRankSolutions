namespace HackerRankSolutions.NonDivisibleSubset
{
    public class NonDivisibleSubset
    {
        static Dictionary<int, int> _modKValues;        
        static Dictionary<int, List<int>> _nextCompatible;
        static List<int> _mods;
        static int _k;

        public static int LongestNonDivisibleSubset(int k, List<int> s)
        {
            _k = k;
            _modKValues = new Dictionary<int, int>();
            _nextCompatible = new Dictionary<int, List<int>>();

            for (int i = 0; i < s.Count; i++)
            {
                int m = s[i] % k;
                if (!_modKValues.ContainsKey(m))
                {
                    _modKValues[m] = 0;
                }
                _modKValues[m]++;
            }

            _mods = _modKValues.Keys.OrderBy(m => m).ToList();
            for (int i = 0; i < _mods.Count - 1; i++)
            {
                int m = _mods[i];
                for (int j = i + 1; j < _mods.Count; j++)
                {
                    int n = _mods[j];
                    if ((m + n) % k != 0)
                    {
                        if (!_nextCompatible.ContainsKey(m))
                        {
                            _nextCompatible[m] = new List<int>();
                        }
                        _nextCompatible[m].Add(n);
                    }
                }

                if ((m + m) % k == 0)
                {
                    _modKValues[m] = 1;
                }
            }

            return LongestNonDivisibleSubsetRecurse(_mods, 0);
        }

        public static int LongestNonDivisibleSubsetRecurse(IEnumerable<int> availableMods, int count)
        {                        
            if (!availableMods.Any())
                return count;

            int m = availableMods.First();
            int nextWithoutM = LongestNonDivisibleSubsetRecurse(availableMods.Skip(1), count);

            if (!_modKValues.ContainsKey(m))
                return nextWithoutM;

            var nextCompatibleWithM = availableMods.Skip(1).Where(n => (n + m) % _k != 0);
            int nextWithM = LongestNonDivisibleSubsetRecurse(nextCompatibleWithM, count + _modKValues[m]);
            return Math.Max(nextWithM, nextWithoutM);
        }
    }
}
