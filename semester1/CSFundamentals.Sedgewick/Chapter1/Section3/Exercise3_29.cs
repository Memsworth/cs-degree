namespace CSFundamentals.Sedgewick.Chapter1.Section3;

public class Exercise3_29 : IExercise
{
    public void Run(string[] args)
    {
        var n = int.Parse(args[0]);
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                System.Console.Write((i + j) % 2 == 0 ? "#" : " ");
            }
            System.Console.WriteLine();
        }
    }
}