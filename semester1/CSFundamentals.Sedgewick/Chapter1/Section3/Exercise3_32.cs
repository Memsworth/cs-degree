namespace CSFundamentals.Sedgewick.Chapter1.Section3;

public class Exercise3_32 : IExercise
{
    public void Run(string[] args)
    {
        var k = int.Parse(args[0]);
        long currentVal = 1;
        int ithPower = 0;
        for (int i = 0; ; i++)
        {
            if (long.MaxValue / k < currentVal)
            {
                ithPower = i;
                break;
            }
            currentVal *= k;
        }

        System.Console.WriteLine($"The {k} stopped at {ithPower}");
        System.Console.WriteLine($"With the value of {currentVal}");
    }
}