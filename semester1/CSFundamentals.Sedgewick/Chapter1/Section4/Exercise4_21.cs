
namespace CSFundamentals.Sedgewick.Chapter1.Section4;

internal class Exercise4_21 : IExercise
{
    public void Run(string[] args)
    {
        int n = int.Parse(args[0]);
        int trials = int.Parse(args[1]);

        int deadEnds = 0;

        double totalDeadLen = 0.0;
        double totalEscapeLen = 0.0;
        double totalLen = 0.0;
        double totalArea = 0.0;

        Random rand = new Random();

        for (int t = 0; t < trials; t++)
        {
            bool[,] a = new bool[n, n];
            int x = n / 2, y = n / 2;
            int steps = 0;
            int minX = x;
            int maxX = x;
            int minY = y;
            int maxY = y;

            while (x > 0 && x < n - 1 && y > 0 && y < n - 1)
            {
                a[x, y] = true;

                if (a[x - 1, y] && a[x + 1, y] &&
                    a[x, y - 1] && a[x, y + 1])
                {
                    deadEnds++;
                    totalDeadLen += steps;
                    totalLen += steps;
                    var xVal = maxX - minX + 1;
                    var yVal = maxY - minY + 1;
                    var failArea = xVal * yVal;
                    totalArea += failArea;
                    break;
                }

                double r = rand.NextDouble();

                if (r < 0.25)
                {
                    if (!a[x + 1, y]) { x++; steps++; }
                }
                else if (r < 0.50)
                {
                    if (!a[x - 1, y]) { x--; steps++; }
                }
                else if (r < 0.75)
                {
                    if (!a[x, y + 1]) { y++; steps++; }
                }
                else
                {
                    if (!a[x, y - 1]) { y--; steps++; }
                }

                minX = Math.Min(minX, x);
                maxX = Math.Max(maxX, x);
                minY = Math.Min(minY, y);
                maxY = Math.Max(maxY, y);
            }

            if (!(x > 0 && x < n - 1 && y > 0 && y < n - 1))
            {
                totalEscapeLen += steps;
                totalLen += steps;
            }
        }

        Console.WriteLine($"{100.0 * deadEnds / trials:F2}% dead ends");
        Console.WriteLine($"Average length (all paths): {totalLen / trials:F2}");

        if (deadEnds > 0)
            Console.WriteLine($"Average length (dead-end paths): {totalDeadLen / deadEnds:F2}");

        if (deadEnds < trials)
            Console.WriteLine($"Average length (escape paths): {totalEscapeLen / (trials - deadEnds):F2}");

        if (deadEnds > 0)
        {
            double avgArea = totalArea / deadEnds;
            Console.WriteLine($"Average area of dead-end rectangle: {avgArea:F2}");
        }
    }
}
