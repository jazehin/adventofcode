using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode.y2024
{
    public class Day01_2
    {
        public static int GetResult()
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
