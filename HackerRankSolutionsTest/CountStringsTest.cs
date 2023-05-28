using HackerRankSolutions.CountStrings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutionsTest
{
    public class CountStringsTest
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public static void TestSome(string input, string expectedString)
        {
            var cases = ReadInput(input);
            var expectedResults = StringToResult(expectedString);
            Assert.Multiple(() =>
            {
                for (int i = 0; i < cases.Count; i++)
                {
                    (string r, int l) = cases[i];
                    var actualResult = CountStrings.CountPossibleStrings(r, l);
                    Assert.Equal(expectedResults[i], actualResult);
                }
            });
        }
        public static List<(string r, int l)> ReadInput(string input)
        {
            var lines = input.Split("\r\n").Skip(1).Select(l => l.Trim().Split(" ")).Select(l => (l[0], Convert.ToInt32(l[1]))).ToList();            
            return lines;
        }

        public static List<int> StringToResult(string resultString)
        {
            return resultString.Split("\r\n").Select(l => Convert.ToInt32(l.Trim())).ToList();
        }

        public static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { "3  \r\n((ab)|(ba)) 2  \r\n((a|b)*) 5  \r\n((a*)(b(a*))) 100", "2  \r\n32  \r\n100" }, 
                new object[] { "37\r\n((a*)|a) 1\r\n((((ab)|a)*)|(((aa)|(bb))*)) 1\r\n((((ab)|a)*)|(((aa)|(bb))*)) 3\r\n((((ab)|a)*)|(((aa)|(bb))*)) 4\r\n((((ab)|a)*)|(((aa)|(bb))*)) 5\r\n((((ab)|b)*)|(((aa)|(bb))*)) 6\r\n((((ab)|b)*)|(((aa)|(bb))*)) 7\r\n((((ab)|b)*)|(((aa)|(bb))*)) 8\r\n((((ab)|b)*)|(((aa)|(bb))*)) 9\r\n((((ab)|a)*)|(((aa)|(bb))*)) 10\r\n(((ab)*)((ba)*)) 13\r\n((((((((((((((((ba)b)b)a)b)b)a)a)a)a)b)b)a)a)b)a) 17\r\n(((ab)*)((ba)*)) 12\r\n(((((((((((ba)b)b)a)b)b)a)a)a)a)(((ab)*)((ba)*))) 14\r\n((((ab)*)((ba)*))*) 15\r\n(((((((((((ba)b)b)a)b)b)a)a)a)a)(((ab)*)((ba)*))) 15\r\n((((((ab)*)((ba)*))*)*)*) 11\r\n(((((((((((ba)b)b)a)b)b)a)a)a)a)(((ab)*)((ba)*))) 13\r\n((((ab)*)|((ba)*))*) 14\r\n(((((((((((ba)b)b)a)b)b)a)a)a)a)(((ab)*)((ba)*))) 14\r\n((((ab)|(ba))*)|(((aa)|(bb))*)) 14\r\n(((((ab)|(ba))*)|(((aa)|(bb))*))*) 10\r\n(((((ab)|(ba))*)|(((aa)|(bb))*))*) 15\r\n((a(b(bb)))*) 12\r\n((b((a(aa))*))b) 14\r\n((b((a(a(aa)))*))b) 13\r\n(b(a(a(a(a(a(a(a(ab))))))))) 10\r\n(b(a(a(a(a(a(a(a(ab))))))))) 9\r\n(b(a(a(a(a(a(a(a(ab))))))))) 11\r\n(a*) 10\r\n(a(a*)) 4\r\n(b(a(a(a(a(a(a(a(ab))))))))) 10\r\n((ab)|((a*)(b*))) 2\r\n(((a(ba))((ba)*))|((a|b)*)) 15\r\n(((a(ba))((ba)*))|((a|b)*)) 16\r\n(((a(ba))((ba)*))|(((ab)|(ba))*)) 16\r\n(a(((b|(a(ba)))*)b)) 18", "1\r\n1\r\n3\r\n8\r\n8\r\n20\r\n21\r\n49\r\n55\r\n120\r\n0\r\n1\r\n7\r\n0\r\n0\r\n3\r\n0\r\n2\r\n128\r\n0\r\n256\r\n1024\r\n0\r\n1\r\n1\r\n0\r\n1\r\n0\r\n0\r\n1\r\n1\r\n1\r\n3\r\n32768\r\n65536\r\n256\r\n277" }
            };
    }
}
