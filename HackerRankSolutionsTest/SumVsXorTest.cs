using HackerRankSolutions.SumVsXor;

namespace HackerRankSolutionsTest
{
    public class SumVsXorTest
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public static void TestSome(long n, long expected)
        {
            long actual = SumVsXor.SumXor(n);            
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public static void PrintDigits(long n, long expected)
        {
            var actual = SumVsXor.GetDigits(n);
            var s = new string(actual.Reverse().Select(x => x == true ? '1' : '0').ToArray());
            Console.WriteLine(s);
        }

        public static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { 5, 2 },
                new object[] { 10, 4 },
                new object[] { 1000000000000000, 1073741824 },
            };
    }
}
