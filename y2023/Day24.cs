namespace adventofcode.y2023
{
    public class Day24
    {
        private static List<Function> _functions = [];
        private const long X1 = 7, Y1 = 7;
        private const long X2 = 27, Y2 = 27;
        public static int GetResult1() //INCOMPLETE
        {
            //basically each hailstone is an y=ax+b function and we need to see if they intesect
            string input = File.ReadAllText("./y2023/res/24.txt");
            foreach (string line in input.Split("\n"))
            {
                string[] d = line.Split(" @ ");
                _functions.Add(new(d[0], d[1]));
            }

            int c = 0;

            using StreamWriter writer = new("./y2023/res/24_out.txt");
            for (int i = 0; i < _functions.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    (double x, double y) intersection = Equation.Solve(_functions[i], _functions[j]);

                    writer.WriteLine($"{{{i}:{j}}}: x={intersection.x}, y={intersection.y}");
                    writer.WriteLine($"{i}: slope: {_functions[i].Slope}, x: {_functions[i].X}, y: {_functions[i].Y}");
                    writer.WriteLine($"{j}: slope: {_functions[j].Slope}, x: {_functions[j].X}, y: {_functions[j].Y}");

                    bool isIntersectionInThePast = false;
                    if (_functions[i].Y < intersection.y || _functions[j].Y < intersection.y) isIntersectionInThePast = true;
                    /*if (_functions[i].Slope > 0 && _functions[i].X < intersection.x) isIntersectionInThePast = true;
                    if (_functions[j].Slope < 0 && _functions[j].X > intersection.x) isIntersectionInThePast = true;
                    if (_functions[j].Slope > 0 && _functions[j].X < intersection.x) isIntersectionInThePast = true;*/

                    if (X1 <= intersection.x && intersection.x <= X2 &&
                        Y1 <= intersection.y && intersection.y <= Y2 &&
                        !isIntersectionInThePast)
                    {
                        c++;
                        writer.WriteLine("intersected inside!");
                    }

                    writer.WriteLine();
                }
            }

            return c;
        }
    }

    internal class Function
    {
        public long X { get; private set; }
        public long Y { get; private set; }
        public double Slope { get; private set; }

        public Function(string position, string velocity)
        {
            string[] positions  = position.Split(", ");
            string[] velocities = velocity.Split(", ");

            X = long.Parse(positions[0]);
            Y = long.Parse(positions[1]);
            Slope = double.Parse(velocities[1]) / double.Parse(velocities[0]);
        }
    }

    internal class Equation
    {
        public static (double x, double y) Solve(Function a, Function b)
        {
            // y = ax + b => a1*x + b1 = a2*x + b2
            double a1 = a.Slope;
            double b1 = a.Slope * -a.X + a.Y;

            double a2 = b.Slope;
            double b2 = b.Slope * -b.X + b.Y;

            // /-a2*x
            a1 -= a2;
            a2 = 0;

            // /-b1
            b2 -= b1;
            b1 = 0;

            // /:a1
            b2 /= a1;
            a1 = 1;

            double x = b2;

            //for y, we substitute back into the first half of the equation
            a1 = a.Slope * x;
            b1 = a.Slope * -a.X + a.Y;

            double y = a1 + b1;

            return (x, y);
        }
    }
}
