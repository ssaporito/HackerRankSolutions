using HackerRankSolutions.ThePowerSum;

namespace HackerRankSolutionsTest
{
    public class ThePowerSumTest
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public static void TestSome(int x, int n, int result)
        {
            Assert.Equal(result, ThePowerSum.Solve(x, n));
        }

        public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { 10, 2, 1 },
            new object[] { 100, 2, 3 },
            new object[] { 100, 3, 1 },          
        };
    }
}
