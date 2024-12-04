namespace adventofcode.y2024
{
    public class Day04
    {
        public static int GetResult1()
        {
            string input = File.ReadAllText("./y2024/res/04.txt");
            string[] data = input.Split('\n');
            return CountXMAS(data);
        }

        public static int GetResult2()
        {
            string input = File.ReadAllText("./y2024/res/04.txt");
            string[] data = input.Split('\n');
            return CountMAS(data);
        }

        private static bool CharExists(string[] data, int x, int y)
        {
            return x >= 0 && y >= 0 &&
                x < data.Length && y < data[0].Length;
        }

        private static int CountXMAS(string[] data)
        {
            int counter = 0;

            for (int x = 0; x < data.Length; x++)
            {
                for (int y = 0; y < data[x].Length; y++)
                {
                    if (data[x][y] != 'X') continue;

                    //up left
                    if (CharExists(data, x - 3, y - 3)) {
                        if (data[x - 1][y - 1] == 'M' &&
                            data[x - 2][y - 2] == 'A' &&
                            data[x - 3][y - 3] == 'S')
                            counter++;
                    }

                    //up
                    if (CharExists(data, x - 3, y))
                    {
                        if (data[x - 1][y] == 'M' &&
                            data[x - 2][y] == 'A' &&
                            data[x - 3][y] == 'S')
                            counter++;
                    }

                    //up right
                    if (CharExists(data, x - 3, y + 3))
                    {
                        if (data[x - 1][y + 1] == 'M' &&
                            data[x - 2][y + 2] == 'A' &&
                            data[x - 3][y + 3] == 'S')
                            counter++;
                    }

                    //left
                    if (CharExists(data, x, y - 3))
                    {
                        if (data[x][y - 1] == 'M' &&
                            data[x][y - 2] == 'A' &&
                            data[x][y - 3] == 'S')
                            counter++;
                    }

                    //right
                    if (CharExists(data, x, y + 3))
                    {
                        if (data[x][y + 1] == 'M' &&
                            data[x][y + 2] == 'A' &&
                            data[x][y + 3] == 'S')
                            counter++;
                    }

                    //down left
                    if (CharExists(data, x + 3, y - 3))
                    {
                        if (data[x + 1][y - 1] == 'M' &&
                            data[x + 2][y - 2] == 'A' &&
                            data[x + 3][y - 3] == 'S')
                            counter++;
                    }

                    //down
                    if (CharExists(data, x + 3, y))
                    {
                        if (data[x + 1][y] == 'M' &&
                            data[x + 2][y] == 'A' &&
                            data[x + 3][y] == 'S')
                            counter++;
                    }

                    //down right
                    if (CharExists(data, x + 3, y + 3))
                    {
                        if (data[x + 1][y + 1] == 'M' &&
                            data[x + 2][y + 2] == 'A' &&
                            data[x + 3][y + 3] == 'S')
                            counter++;
                    }
                }
            }

            return counter;
        }

        private static int CountMAS(string[] data)
        {
            int counter = 0;

            for (int x = 1; x < data.Length - 1; x++)
            {
                for (int y = 1; y < data[x].Length - 1; y++)
                {
                    if (data[x][y] != 'A') continue;

                    if (((data[x - 1][y - 1] == 'M' &&
                          data[x + 1][y + 1] == 'S') ||
                         (data[x - 1][y - 1] == 'S' &&
                          data[x + 1][y + 1] == 'M')) 
                          &&
                        ((data[x - 1][y + 1] == 'M' &&
                          data[x + 1][y - 1] == 'S') ||
                         (data[x - 1][y + 1] == 'S' &&
                          data[x + 1][y - 1] == 'M')))
                        counter++;
                }
            }

            return counter;
        }
    }
}
