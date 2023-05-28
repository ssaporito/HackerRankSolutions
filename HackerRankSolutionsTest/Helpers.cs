using System.Configuration;

namespace HackerRankSolutionsTest
{
    public static class Helpers
    {
        public static List<(FileInfo inputFile, FileInfo outputFile)> GetCaseFiles(string className)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(ConfigurationManager.AppSettings["TestCasesFolder"] + className);
            var inputFiles = directoryInfo.GetFiles("input*.txt").ToDictionary(f => f.Name[^6..^3]);
            var outputFiles = directoryInfo.GetFiles("output*.txt").ToDictionary(f => f.Name[^6..^3]);
            var result = inputFiles.Keys.Select(num => (inputFiles[num], outputFiles[num])).ToList();
            return result;
        }
    }
}
