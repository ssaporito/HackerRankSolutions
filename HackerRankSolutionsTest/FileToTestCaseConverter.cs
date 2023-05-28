namespace HackerRankSolutionsTest
{
    public abstract class FileToTestCaseConverter
    {
        public object[] ConvertToCase(StreamReader inputStream, StreamReader outputStream)
        {
            var testParams = new List<object>();
            var input = ConvertInput(inputStream);
            var output = ConvertOutput(outputStream);
            testParams.AddRange(input);
            testParams.Add(output);
            return testParams.ToArray();
        }
        public abstract object[] ConvertInput(StreamReader inputStream);
        public abstract object ConvertOutput(StreamReader outputStream);
    }
}
