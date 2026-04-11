namespace CSFundamentals.Sedgewick.Chapter1.Section3;

public class Exercise3_20 : IExercise
{
    public void Run(string[] args)
    {
        var n = int.Parse(args[0]);
        var k = int.Parse(args[1]);
        double epsilon = 1e-15;
        double t = n;

        while (Math.Abs(t - n / Math.Pow(t, k-1)) > epsilon * t)
        {
           t = (((k - 1) * t) + (n / Math.Pow(t, k - 1))) / k;
        }

        Console.WriteLine($"{t:F6}");
    }
}