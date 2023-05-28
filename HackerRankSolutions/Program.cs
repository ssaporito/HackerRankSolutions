using HackerRankSolutions;
using System.Reflection;
using System.Runtime.CompilerServices;

class Program
{
    public static void Main()
    {
        while(true)
        {
            Console.WriteLine("Choose the problem:");

            var problems = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass
                    && t.Namespace != null && t.Namespace.StartsWith("HackerRankSolutions")
                    && !t.GetTypeInfo().IsDefined(typeof(CompilerGeneratedAttribute), true)
                    && !t.IsNestedPrivate)
                .ToList();

            for (int i = 0; i < problems.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {problems[i].Name}");
            }

            var val = Console.ReadLine();
            int choice = Convert.ToInt32(val?.TrimEnd()) - 1;
            
            while(true)
            {
                Console.WriteLine($"Write the input for problem " + problems[choice].Name + ":");
                var inputMethod = problems[choice].GetMethod("SolveInput");
                if (inputMethod == null)
                {
                    Console.WriteLine("Missing SolveInput method.");
                    Console.ReadLine();
                    break;
                }

                inputMethod.Invoke(null, new object[] {});
            }            
        }        
    }
}
