using System.Numerics;
using System.Text;

namespace HackerRankSolutions.SherlockAndAnagrams
{
    public class SherlockAndAnagrams
    {
        public static int CountPairs(string s)
        {
            var relevantCounts = new List<int>();
            for (int i = 1; i <= s.Length; i++)
            {
                var anagramDict = new Dictionary<Anagram, int>();
                for (int j = 0; j + i - 1 < s.Length; j++)
                {
                    var anagram = new Anagram(s.Substring(j, i));
                    if (!anagramDict.ContainsKey(anagram))
                    {
                        anagramDict[anagram] = 0;
                    }
                    anagramDict[anagram]++;
                }
                relevantCounts.AddRange(anagramDict.Values.Where(x => x > 1));
                //Console.WriteLine(string.Join(' ', anagramDict.Keys.Select(x => x.ToString())));
            }

            int totalCount = 0;
            foreach (int count in relevantCounts)
            {
                totalCount += (int)Combination(count, 2);
            }
            
            return totalCount;
        }

        private static BigInteger Combination(int n, int k)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        static readonly List<BigInteger> _factorialMemo = new() { new BigInteger(1) };
        static int _highestN = 0;
        public static BigInteger Factorial(int n)
        {
            if (n <= _highestN)
                return _factorialMemo[n];
            var r = _factorialMemo[_highestN];
            var bigN = new BigInteger(n);
            for (var i = new BigInteger(_highestN + 1); i <= bigN; i++)
            {
                r *= i;
                _factorialMemo.Add(r);
            }

            _highestN = n;
            return r;
        }

        public struct Anagram
        {
            private int _size = 26;
            private int[] _letterCounts;
            public Anagram(string s)
            {
                _letterCounts = Enumerable.Repeat(0, _size).ToArray();
                foreach (char c in s)
                {
                    _letterCounts[c - 'a']++;
                }
            }

            public override int GetHashCode() { return base.GetHashCode(); }
            public override bool Equals(object obj)
            {
                var objAnagram = (Anagram)obj;
                for (int i = 0; i < _size; i++)
                {
                    if (this._letterCounts[i] != objAnagram._letterCounts[i])
                        return false;
                }
                return true;
            }

            public override string ToString()
            {
                var sb = new StringBuilder();
                for (var c = 'a'; c < 'z'; c++)
                {
                    sb.Append(c, _letterCounts[c - 'a']);
                }
                return sb.ToString();
            }
        }
    }    
}
