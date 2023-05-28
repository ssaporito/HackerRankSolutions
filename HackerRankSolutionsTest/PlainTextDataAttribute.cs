using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;
using System.Configuration;

namespace HackerRankSolutionsTest
{
    public class PlainTextDataAttribute : DataAttribute
    {
        private readonly FileToTestCaseConverter _ioConverter;
        public PlainTextDataAttribute(Type ioConverterType)
        {
            _ioConverter = (FileToTestCaseConverter)Activator.CreateInstance(ioConverterType);
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {            
            if (testMethod == null) { throw new ArgumentNullException(nameof(testMethod)); }
            if (testMethod.DeclaringType == null) { throw new ArgumentNullException(nameof(testMethod.DeclaringType)); }

            var problemName = testMethod.DeclaringType.Name[..^4];
            var caseFiles = Helpers.GetCaseFiles(problemName);
            var cases = caseFiles.Select(f => _ioConverter.ConvertToCase(f.inputFile.OpenText(), f.outputFile.OpenText()));
            return cases;
        }
    }
}
