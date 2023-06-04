using HackerRankSolutions.SuperMaximumCostQueries;
using System.Text;

namespace HackerRankSolutionsTest
{
    public class SuperMaximumCostQueriesTest
    {
        [Theory]
        [PlainTextData(typeof(SuperMaximumCostQueriesCaseConverter))]
        public void TestByFiles(string treeString, string queriesString, string expectedString)
        {
            var tree = treeString.Split("\r\n").Select(line => line.Split(' ').Select(s => Convert.ToInt32(s)).ToList()).ToList();
            var queries = queriesString.Split("\r\n").Select(line => line.Split(' ').Select(s => Convert.ToInt32(s)).ToList()).ToList();
            var expectedList = expectedString.Split("\r\n").Select(line => Convert.ToInt32(line)).ToList();
            var actualList = SuperMaximumCostQueries.Solve(tree, queries);
            var range = Enumerable.Range(0, expectedList.Count);
            var checks = range.Select(i => (Action)(() => Assert.Equal(expectedList[i], actualList[i]))).ToArray(); 
            Assert.Multiple(checks);            
        }

        public class SuperMaximumCostQueriesCaseConverter : FileToTestCaseConverter
        {
            public override object[] ConvertInput(StreamReader inputStream)
            {
                string[] firstMultipleInput = inputStream.ReadLine().TrimEnd().Split(' ');
                int n = Convert.ToInt32(firstMultipleInput[0]);
                int q = Convert.ToInt32(firstMultipleInput[1]);

                var sbTree = new StringBuilder();                
                for (int i = 0; i < n - 1; i++)
                {
                    sbTree.Append((i != 0 ? "\r\n" : "") + inputStream.ReadLine().TrimEnd());                    
                }

                var sbQueries = new StringBuilder();
                for (int i = 0; i < q; i++)
                {
                    sbQueries.Append((i != 0 ? "\r\n" : "") + inputStream.ReadLine().TrimEnd());
                }

                return new object[] { sbTree.ToString(), sbQueries.ToString() };
            }

            public override object ConvertOutput(StreamReader outputStream)
            {                
                var sbExpected = new StringBuilder();
                string line;
                int i = 0;
                while ((line = outputStream.ReadLine()) != null) {
                    sbExpected.Append((i != 0 ? "\r\n" : "") + line.TrimEnd());
                    i++;
                }
                return sbExpected.ToString();
            }
        }
    }
}
