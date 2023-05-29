using HackerRankSolutions.NonDivisibleSubset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutionsTest
{
    public class NonDivisibleSubsetTest
    {
        [Theory]
        [PlainTextData(typeof(NonDivisibleSubsetCaseConverter))]
        public void TestByFiles(int k, string sString, int expected)
        {
            var s = sString.Split(' ').Select(x => Convert.ToInt32(x)).ToList();
            var actual = NonDivisibleSubset.LongestNonDivisibleSubset(k, s);
            Assert.Equal(expected, actual);
        }

        public class NonDivisibleSubsetCaseConverter : FileToTestCaseConverter
        {            
            public override object[] ConvertInput(StreamReader inputStream)
            {
                string[] firstMultipleInput = inputStream.ReadLine().TrimEnd().Split(' ');
                int k = Convert.ToInt32(firstMultipleInput[1]);

                var sString = inputStream.ReadLine().TrimEnd();
                return new object[] { k, sString };
            }

            public override object ConvertOutput(StreamReader outputStream)
            {
                int r = Convert.ToInt32(outputStream.ReadLine().TrimEnd());
                return r;
            }
        }
    }
}
