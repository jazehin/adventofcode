using System.Text.RegularExpressions;

namespace adventofcode.y2024
{
    public class Day03
    {
        public static int GetResult1()
        {
            string input = File.ReadAllText("./y2024/res/03.txt");
            int sum = 0;

            MatchCollection res = Regex.Matches(input, "mul\\([\\d]{1,3},[\\d]{1,3}\\)");

            foreach (Match match in res)
            {
                string str = match.Value.Replace("mul(", "").Replace(")", "");
                string[] d = str.Split(',');
                int a = int.Parse(d[0]);
                int b = int.Parse(d[1]);
                sum += a * b;
            }

            return sum;
        }

        public static int GetResult2()
        {
            string input = File.ReadAllText("./y2024/res/03.txt");
            int sum = 0;

            MatchCollection res = Regex.Matches(input, "(mul\\([\\d]{1,3},[\\d]{1,3}\\))|do\\(\\)|don\'t\\(\\)");
            bool noExec = false;

            foreach (Match match in res)
            {
                string str = match.Value;
                switch (str)
                {
                    case "don't()": noExec = true; break;
                    case "do()": noExec = false; break;
                    default:
                        if (noExec) continue;
                        str = str.Replace("mul(", "").Replace(")", "");
                        string[] d = str.Split(',');
                        int a = int.Parse(d[0]);
                        int b = int.Parse(d[1]);
                        sum += a * b;
                        break;
                }
            }

            return sum;
        }
    }
}
