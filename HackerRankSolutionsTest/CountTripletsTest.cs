using HackerRankSolutions.CountTriplets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutionsTest
{
    public class CountTripletsTest
    {
        [Theory]
        [PlainTextData(typeof(CountTripletsCaseConverter))]
        public void TestByFiles(string arrString, long r, long expected)
        {
            var arr = arrString.Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();                        
            var actual = CountTriplets.SolveCountTriplets(arr, r);
            Assert.Equal(expected, actual);
        }

        public class CountTripletsCaseConverter : FileToTestCaseConverter
        {
            public override object[] ConvertInput(StreamReader inputStream)
            {
                string[] nr = inputStream.ReadLine().TrimEnd().Split(' ');

                long r = Convert.ToInt64(nr[1]);
                var arrString = inputStream.ReadLine().TrimEnd();                

                return new object[] { arrString, r };
            }

            public override object ConvertOutput(StreamReader outputStream)
            {
                long result = Convert.ToInt64(outputStream.ReadLine().TrimEnd());
                return result;
            }
        }
    }
}
