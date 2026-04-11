namespace CSFundamentals.Sedgewick.Chapter1.Section3;

public class Exercise3_33 : IExercise
{
    public void Run(string[] args)
    {
        var rand = new Random();
        double x;
        double y;

        do
        {
            x = 2 * rand.NextDouble() - 1;
            y = 2 * rand.NextDouble() - 1;
        } while(Math.Pow(x,2) + Math.Pow(y,2) >= 1);

        System.Console.WriteLine($"x={x:F3}\ny={y:F3}");

        double a = 2 * x * Math.Sqrt(1.0 - Math.Pow(x, 2) - Math.Pow(y, 2));
        double b = 2 * y * Math.Sqrt(1.0 - Math.Pow(x, 2) - Math.Pow(y, 2));
        double c = 1.0 - (2.0 * (Math.Pow(x, 2) + Math.Pow(y, 2)));

        System.Console.WriteLine($"a={a:F3}\nb={b:F3}\nc={c:F3}");
    }
}