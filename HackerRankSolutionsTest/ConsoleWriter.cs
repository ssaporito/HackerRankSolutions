using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace HackerRankSolutionsTest
{
    public class ConsoleWriter : StringWriter
    {
        private readonly ITestOutputHelper _output;
        public ConsoleWriter(ITestOutputHelper output)
        {
            _output = output;
        }

        public override void WriteLine(string m)
        {
            _output.WriteLine(m);
        }
    }
}
