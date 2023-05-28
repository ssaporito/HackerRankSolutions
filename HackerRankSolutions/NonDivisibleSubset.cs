namespace HackerRankSolutions.NonDivisibleSubset
{
    public class NonDivisibleSubset
    {
        public static int FindLongestSubset(int k, List<int> s)
        {
            var modKCounts = Enumerable.Repeat(0, k).ToList();
            for (int i = 0; i < s.Count; i++)
            {
                int modK = s[i] % k;
                modKCounts[modK]++;
            }

            var allowedCombinations = GetAllowedCombinations(modKCounts);
            var longestCount = FindLongestModPathCount(allowedCombinations, modKCounts);

            return longestCount;
        }

        static int FindLongestModPathCount(List<HashSet<int>> allowedCombinations, List<int> modKCounts)
        {
            int k = modKCounts.Count;
            int longestCount = 0;
            var basePath = new ModPath(allowedCombinations, modKCounts);
            var exploredPaths = new HashSet<string>();
            for (int m = 0; m < modKCounts.Count; m++)
            {
                if (modKCounts[m] == 0) continue;
                var mPath = new ModPath(basePath) { m };                
                var range = Enumerable.Range(m, k - m);
                var modStack = new Stack<ModPath>();
                modStack.Push(mPath);
                while (modStack.Any())
                {
                    var path = modStack.Pop();
                    if (exploredPaths.Contains(path.ToString()))
                    {
                        Console.WriteLine("set already explored: " + path.ToString());
                        continue;
                    }
                    Console.WriteLine("continuing path: " + path.ToString());
                    var nextMods = range.Where(v => !path.Contains(v) && path.All(i => allowedCombinations[v].Contains(i)));

                    foreach (var nextMod in nextMods)
                    {
                        var newPath = new ModPath(path) { nextMod };                        
                        if (!exploredPaths.Contains(newPath.ToString()))
                        {
                            modStack.Push(newPath);
                        }
                    }

                    if (!nextMods.Any())
                    {
                        Console.WriteLine("finishing path: " + path.ToString());
                        longestCount = Math.Max(path.Value, longestCount);
                    }
                    exploredPaths.Add(path.ToString());
                }
            }
            return longestCount;
        }

        static List<HashSet<int>> GetAllowedCombinations(List<int> modKCounts)
        {
            int k = modKCounts.Count;
            var result = Enumerable.Range(0, k).Select(x => new HashSet<int>()).ToList();
            for (int i = 0; i < k; i++)
            {
                if (modKCounts[i] == 0) continue;
                for (int j = i; j < k; j++)
                {
                    if (modKCounts[j] == 0) continue;
                    if ((i + j) % k != 0)
                    {
                        result[i].Add(j);
                        result[j].Add(i);
                    }
                }
                Console.WriteLine("allowed for " + i + ": " + string.Join(' ', result[i]));
            }
            return result;
        }

        private class ModPath : SortedSet<int>
        {
            public int Value { get; set; }
            private readonly List<HashSet<int>> _allowedCombinations;
            private List<int> _modKCounts;

            public ModPath(List<HashSet<int>> allowedCombinations, List<int> modKCounts) : base()
            {
                _allowedCombinations = allowedCombinations;
                _modKCounts = modKCounts;
            }

            public ModPath(ModPath path) : base(path)
            {
                Value = path.Value;
                _allowedCombinations = path._allowedCombinations;
                _modKCounts = path._modKCounts;
            }

            public override string ToString()
            {
                return string.Join(' ', this);
            }

            public new bool Add(int m)
            {
                Value += _allowedCombinations[m].Contains(m) ? _modKCounts[m] : 1;
                bool r = base.Add(m);
                return r;
            }
        }
    }
}
