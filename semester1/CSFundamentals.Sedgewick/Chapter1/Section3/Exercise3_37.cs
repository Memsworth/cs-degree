namespace CSFundamentals.Sedgewick.Chapter1.Section3;

public class Exercise3_37 : IExercise
{
    //Using Monte Carlo, the AVG is and will always will be n^2 + 2n
    public void Run(string[] args)
    {
        if(!int.TryParse(args[0], out var number))
            return;

        var trials = 10_000;
        ulong stepsWalkedInTheSimulation = 0;

        for (int i = 0; i < trials; i++)
        {
            stepsWalkedInTheSimulation+= (ulong)SimulateWalk(number);
        }

        var average = stepsWalkedInTheSimulation / (double)trials;

        Console.WriteLine($"For n = {number}" +
                          $"\ntrials = {trials}" +
                          $"\naverage = {average:F2}");
    }


    private int SimulateWalk(int number)
    {
        var random = new Random();
        var tries = 0;

        var X = 0;
        var Y = 0;
        while (Math.Abs(X) < number && Math.Abs(Y) < number)
        {
            switch (random.Next(1, 5))
            {
                case 1:
                    Y++;
                    break;
                case 2:
                    X++;
                    break;
                case 3:
                    Y--;
                    break;
                case 4:
                    X--;
                    break;
            }
            tries++;
        }
        return tries;
    }
}