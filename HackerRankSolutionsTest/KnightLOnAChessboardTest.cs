using HackerRankSolutions.KnightLOnAChessboard;

namespace HackerRankSolutionsTest
{
    public class KnightLOnAChessboardTest
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void TestSome(int n, string expectedString)
        {
            var actual = KnightLOnAChessboard.SolveKnightLOnAChessboard(n);
            var expected = expectedString.Split("\r\n").Select(x => x.Split(' ').Select(u => Convert.ToInt32(u)).ToList()).ToList();
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { 5, "4 4 2 8\r\n4 2 4 4\r\n2 4 -1 -1\r\n8 4 -1 1" },
            };
    }
}
