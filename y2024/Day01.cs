namespace adventofcode.y2024
{
    public class Day01
    {
        public static int GetResult1()
        {
            string input = File.ReadAllText("./y2024/res/01.txt");
            List<int> a = [], b = [], c = [];
            foreach (string line in input.Split('\n'))
            {
                string[] s = line.Split("   ");
                a.Add(int.Parse(s[0]));
                b.Add(int.Parse(s[1]));
            }

            a.Sort();
            b.Sort();

            for (int i = 0; i < a.Count; i++)
            {
                c.Add(Math.Abs(a[i] - b[i]));
            }

            return c.Sum();
        }

        public static int GetResult2()
        {
            string input = File.ReadAllText("./y2024/res/01.txt");
            List<int> a = [], b = [];
            int c = 0;
            foreach (string line in input.Split('\n'))
            {
                string[] s = line.Split("   ");
                a.Add(int.Parse(s[0]));
                b.Add(int.Parse(s[1]));
            }

            a = a.Distinct().ToList();
            b.Sort();

            foreach (int n in a)
            {
                c += n * b.Count(num => num == n);
            }

            return c;
        }
    }
}
