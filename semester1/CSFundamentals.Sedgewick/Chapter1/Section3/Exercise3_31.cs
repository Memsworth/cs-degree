namespace CSFundamentals.Sedgewick.Chapter1.Section3;

public class Exercise3_31 : IExercise
{
    public void Run(string[] args)
    {
        var x = int.Parse(args[0]);

        for (int i = 1; i <= x; i++)
        {
            for (int j = 1; j <= x; j++)
                System.Console.Write(AreRelative(i, j) ? "*" : " ");
            System.Console.WriteLine();
        }
    }

    private bool AreRelative(int a, int b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }

        return a == 1;
    }
}