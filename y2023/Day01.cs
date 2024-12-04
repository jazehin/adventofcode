namespace adventofcode.y2023
{
    public class Day01
    {
        public static int GetResult1()
        {
            string input = File.ReadAllText("./y2023/res/01.txt");
            int sum = 0;

            foreach (string line in input.Split('\n'))
            {
                int num = 0;
                bool success = false;

                for (int i = 0; i < line.Length && !success; i++)
                {
                    success = int.TryParse(line.AsSpan(i, 1), out int digit);

                    if (success)
                    {
                        num = digit * 10;
                    }
                }

                success = false;

                for (int i = line.Length - 1; i >= 0 && !success; i--)
                {
                    success = int.TryParse(line.AsSpan(i, 1), out int digit);

                    if (success)
                    {
                        num += digit;
                    }
                }

                sum += num;
            }

            return sum;
        }

        public static int GetResult2() //INCOMPLETE
        {
            string input = File.ReadAllText("./y2023/res/01.txt");
            int sum = 0;

            foreach (string line in input.Split('\n'))
            {
                int num = 0;
                bool success = false;
                string t = line;
                Dictionary<int, string> d = [];
                d.Add(1, "one");
                d.Add(2, "two");
                d.Add(3, "three");
                d.Add(4, "four");
                d.Add(5, "five");
                d.Add(6, "six");
                d.Add(7, "seven");
                d.Add(8, "eight");
                d.Add(9, "nine");

                while (t.Length > 0 && !success) 
                {
                    int digit = 0;

                    foreach (var kvp in d)
                    {
                        success = t.StartsWith($"{kvp.Key}") || t.StartsWith(kvp.Value);
                        if (success) digit = kvp.Key;
                    }

                    if (success)
                    {
                        num = digit * 10;
                    }

                    t = t.Substring(1);
                }

                t = line;
                success = false;

                while (t.Length > 0 && !success)
                {
                    int digit = 0;

                    foreach (var kvp in d)
                    {
                        success = t.EndsWith($"{kvp.Key}") || t.EndsWith(kvp.Value);
                        if (success) digit = kvp.Key;
                    }

                    if (success)
                    {
                        num += digit;
                    }

                    t = t.Substring(0, t.Length - 1);
                }

                Console.WriteLine(num);

                sum += num;
            }

            return sum;
        }
    }
}
