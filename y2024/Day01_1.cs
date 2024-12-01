using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode.y2024
{
    public class Day01_1
    {
        public static int GetResult()
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
    }
}
