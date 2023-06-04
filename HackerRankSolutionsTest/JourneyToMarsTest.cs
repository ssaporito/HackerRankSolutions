using HackerRankSolutions.BiggerIsGreater;
using HackerRankSolutions.JourneyToMars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutionsTest
{
    public class JourneyToMarsTest
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public static void TestSome(int n, int k, int expected)
        {
            var actual = JourneyToMars.Solve(n, k);
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { 10, 2, 63 },
                new object[] { 12, 1, 10 },
                new object[] { 10000, 1, 17 },
                new object[] { 10000, 2, 187 },
                new object[] { 10000, 3, 1685 },
                new object[] { 10000, 4, 14663 },
                new object[] { 10000, 5, 154441 },
                new object[] { 846930986, 2, 87 },
                new object[] { 814637015, 1, 10 },
                new object[] { 424238435, 6, 1731348 },
                new object[] { 683276288, 8, 78277603 }
            };
    }
}
