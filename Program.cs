using System.Reflection;

namespace adventofcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int year = DateTime.Now.Year;
            int day = DateTime.Now.Day;

            if (args.Length > 0)
            {
                year = int.Parse(args[0]);
                day = int.Parse(args[1]);
            }

            if (year < 2015 || year > DateTime.Now.Year || day < 1 || day > 25)
            {
                Console.WriteLine("Advent of Code is inactive!");
                Console.ReadLine();
                Environment.Exit(0);
            }

            PrintResults(year, day);

            Console.ReadLine();
        }

        public static void PrintResults(int year, int day)
        {
            //dynamically get the class, and then the method to call
            Type? type = Type.GetType($"adventofcode.y{year}.Day{day:00}");
            MethodInfo? methodInfo = null;

            //first problem of the day
            if (type is not null)
                methodInfo = type.GetMethod("GetResult1");
            if (methodInfo is not null)
                Console.WriteLine($"{year} December {day}, part 1: {methodInfo.Invoke(null, null)}");
            else
                Console.WriteLine($"{year} December {day}, part 1: #Problem not solved#");

            //second problem of the day
            if (type is not null)
                methodInfo = type.GetMethod("GetResult2");
            if (methodInfo is not null)
                Console.WriteLine($"{year} December {day}, part 2: {methodInfo.Invoke(null, null)}");
            else
                Console.WriteLine($"{year} December {day}, part 2: #Problem not solved#");
        }
    }
}
