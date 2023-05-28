using HackerRankSolutions.Candies;

namespace HackerRankSolutionsTest
{
    public class CandiesTest
    {
        [Fact]
        public void Test1()
        {            
            var data = new List<int>() { 1, 2, 2 };
            var result = Candies.Solve(data.Count, data);
            Assert.Equal(4, result);
        }

        [Fact]
        public void Test2()
        {
            var data = new List<int>() { 2, 4, 2, 6, 1, 7, 8, 9, 2, 1 };
            var result = Candies.Solve(data.Count, data);
            Assert.Equal(19, result);
        }
    }
}