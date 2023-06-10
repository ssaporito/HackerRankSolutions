using HackerRankSolutions.KFactorization;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit.Abstractions;

namespace HackerRankSolutionsTest
{
    public class KFactorizationTest
    {
        private readonly ITestOutputHelper _output;
        public KFactorizationTest(ITestOutputHelper output) { 
            _output = output;            
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void TestSome(string inputString, string expectedString)
        {
            var input = ParseInput(inputString);
            Console.SetOut(new ConsoleWriter(_output));
            var actual = KFactorization.KFactorize(input.N, input.A);
            var actualString = actual != null ? string.Join(' ', actual) : "-1";
            Assert.Equal(expectedString, actualString);
        }

        private TestInput ParseInput(string inputString)
        {
            var lines = inputString.Split("\r\n");
            string[] firstMultipleInput = lines[0].TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            List<int> A = lines[1].TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList();
            return new TestInput(n, A);
        }         

        private record TestInput(int N, List<int> A);

        public static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { "12 3\r\n2 3 4", "1 3 12" },
                new object[] { "72 9\r\n2 4 6 9 3 7 16 10 5", "1 2 8 72" },
                new object[] { "231000000 8\r\n2 3 5 7 11 13 17 19", "1 2 4 8 16 32 64 192 960 4800 24000 120000 600000 3000000 21000000 231000000" },                
            };
    }
}
