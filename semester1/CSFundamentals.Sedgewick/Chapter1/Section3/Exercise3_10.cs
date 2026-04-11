namespace CSFundamentals.Sedgewick.Chapter1.Section3;

public class Exercise3_10 : IExercise
{
    public void Run(string[] args)
    {
        var iterator = int.Parse(args[0]);
        var random = new Random();
        var average = 0.0;
        var epsilon = 1e-12;

        for (int i = 0; i < iterator; i++)
        {
            var valToAdd = random.NextDouble();
            Console.WriteLine($"{valToAdd:F3}");
            average += valToAdd;
        }

        Console.WriteLine($"Average: {average:F3}");
    }
}