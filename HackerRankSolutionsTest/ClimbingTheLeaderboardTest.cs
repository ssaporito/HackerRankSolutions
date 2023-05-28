using HackerRankSolutions.ClimbingTheLeaderboard;

namespace HackerRankSolutionsTest
{
    public class ClimbingTheLeaderboardTest
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public static void TestSome(string input, string expectedString)
        {
            (var ranked, var player) = ClimbingTheLeaderboard.ReadInput(input);
            var actual = ClimbingTheLeaderboard.ClimbingLeaderboard(ranked, player);
            //string actual = ClimbingTheLeaderboard.ResultToString(result);
            var expected = ClimbingTheLeaderboard.StringToResult(expectedString);
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { "7\r\n100 100 50 40 40 20 10\r\n4\r\n5 25 50 120", "6\r\n4\r\n2\r\n1" },
                new object[] { "6\r\n100 90 90 80 75 60\r\n5\r\n50 65 77 90 102", "6\r\n5\r\n4\r\n2\r\n1" },
            };
    }
}
