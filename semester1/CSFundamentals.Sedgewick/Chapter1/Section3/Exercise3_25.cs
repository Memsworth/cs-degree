namespace CSFundamentals.Sedgewick.Chapter1.Section3;

public class Exercise3_25 : IExercise
{
    public void Run(string[] args)
    {
        var stake = int.Parse(args[0]);
        var goal = int.Parse(args[1]);
        var trials = int.Parse(args[2]);
        double p = double.Parse(args[3]);
        var bets = 0;
        var wins = 0;
        var rand = new Random();
        var currentTrails = 0;

        while (currentTrails < trials)
        {
            int cash = stake;
            while (cash > 0 && cash < goal)
            {
                bets++;
                if (rand.NextDouble() < p)
                    cash++;
                else
                    cash--;

            }

            if (cash == goal)
                wins++;
            currentTrails++;
        }

        double winPercentage = 100.0 * wins / trials;
        double avgBets = 1.0 * bets / trials;

        Console.WriteLine($"{winPercentage:F2}% wins");
        Console.WriteLine($"Avg # bets: {avgBets:F2}"); 
        
    }
}