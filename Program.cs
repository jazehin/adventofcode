using adventofcode.y2024;
using System.Reflection;

namespace adventofcode
{
    internal class Program
    {
        static void Main()
        {
            //exit if AoC is not active (date is not between Dec 1 - Dec 25)
            if (DateTime.Today.Month != 12 || DateTime.Now.Day > 25)
            {
                Console.WriteLine("Advent of Code is inactive!");
                Console.ReadLine();
                Environment.Exit(0);
            }

            //dynamically get the class, and then the method to call
            Type? type = null;
            MethodInfo? methodInfo = null;

            type = Type.GetType($"adventofcode.y{DateTime.Now.Year}.Day{DateTime.Now.Day:00}_1");
            if (type is not null)
                methodInfo = type.GetMethod("GetResult");
            if (methodInfo is not null)
                Console.WriteLine($"Day {DateTime.Now.Day:00}, part 1: {methodInfo.Invoke(null, null)}");

            type = null;
            methodInfo = null;

            type = Type.GetType($"adventofcode.y{DateTime.Now.Year}.Day{DateTime.Now.Day:00}_2");
            if (type is not null)
                methodInfo = type.GetMethod("GetResult");
            if (methodInfo is not null)
                Console.WriteLine($"Day {DateTime.Now.Day:00}, part 2: {methodInfo.Invoke(null, null)}");

            Console.ReadLine();
        }
    }
}
