namespace adventofcode.y2024
{
    public class Day02
    {
        public static int GetResult1()
        {
            string input = File.ReadAllText("./y2024/res/02.txt");
            int c = 0;

            foreach (string line in input.Split("\n"))
            {
                string[] d = line.Split(' ');
                List<int> nums = [];
                foreach (string n in d) nums.Add(int.Parse(n));
                if (IsLevelValid(nums)) c++;
            }

            return c;
        }

        private static bool IsLevelValid(List<int> nums)
        {
            if (nums.Count < 2) return true;
            if (nums[0] < nums[1])
            {
                int i = 0;
                while (i < nums.Count - 1 && nums[i] < nums[i + 1] && Math.Abs(nums[i] - nums[i + 1]) <= 3) i++;
                return i == nums.Count - 1;
            }
            else
            {
                int i = 0;
                while (i < nums.Count - 1 && nums[i] > nums[i + 1] && Math.Abs(nums[i] - nums[i + 1]) <= 3) i++;
                return i == nums.Count - 1;
            }
        }

        public static int GetResult2()
        {
            string input = File.ReadAllText("./y2024/res/02.txt");
            int c = 0;

            foreach (string line in input.Split("\n"))
            {
                string[] d = line.Split(' ');
                List<int> nums = [];

                foreach (string n in d)
                    nums.Add(int.Parse(n));

                if (IsLevelValid2(nums)) c++;
            }

            return c;
        }

        private static bool IsLevelValid2(List<int> nums)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                List<int> list = [];
                for (int j = 0; j < nums.Count; j++)
                    if (i != j)
                        list.Add(nums[j]);
                if (IsLevelValid(list)) return true;
            }
            return false;
        }
    }
}
