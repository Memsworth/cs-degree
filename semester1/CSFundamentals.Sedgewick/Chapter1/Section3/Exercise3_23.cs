namespace CSFundamentals.Sedgewick.Chapter1.Section3;

public class Exercise3_23 : IExercise
{
    public void Run(string[] args)
    {
        var stake = int.Parse(args[0]);
        var goal = int.Parse(args[1]);
        var trials = int.Parse(args[2]);
        var bets = 0;
        var wins = 0;
        var rand = new Random();
        var currentTrails = 0;

        while(currentTrails < trials)
        {
            int cash = stake;
            while (cash > 0 && cash < goal)
            {
                bets++;
                Console.WriteLine(new string('*', cash));
                if (rand.NextDouble() < 0.5)
                    cash++;
                else
                    cash--;

            }

            if (cash == goal)
                wins++;
            currentTrails++;
        } 
        Console.WriteLine(100*wins/trials + "% wins"); 
        Console.WriteLine("Avg # bets: " + bets/trials);
    }
}