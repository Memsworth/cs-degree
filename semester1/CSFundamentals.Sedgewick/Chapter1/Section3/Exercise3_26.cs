namespace CSFundamentals.Sedgewick.Chapter1.Section3;

public class Exercise3_26 : IExercise
{
    public void Run(string[] args)
    {
        int stake = int.Parse(args[0]);      
        int goal = int.Parse(args[1]);       
        int trials = int.Parse(args[2]);     
        double p = double.Parse(args[3]);    
        int maxBets = int.Parse(args[4]);    

        int wins = 0;
        int timeouts = 0;
        int totalBets = 0;
        double totalCashAtEnd = 0;

        Random rand = new Random();

        for (int t = 0; t < trials; t++)
        {
            int cash = stake;
            int trialBets = 0;

            while (cash > 0 && cash < goal && trialBets < maxBets)
            {
                trialBets++;
                if (rand.NextDouble() < p)
                    cash++;
                else
                    cash--;
            }

            if (cash == goal)
                wins++;
            else if (trialBets == maxBets && cash > 0 && cash < goal)
                timeouts++;

            totalCashAtEnd += cash;
            totalBets += trialBets;
        }

        double winPercentage = 100.0 * wins / trials;
        double avgBets = (double)totalBets / trials;
        double expectedCash = totalCashAtEnd / trials;

        Console.WriteLine($"{winPercentage:F2}% wins");
        Console.WriteLine($"{100.0 * timeouts / trials:F2}% ran out of time");
        Console.WriteLine($"Avg # bets: {avgBets:F2}");
        Console.WriteLine($"Expected final cash: ${expectedCash:F2}");
    }
}