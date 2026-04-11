namespace CSFundamentals.Sedgewick.Chapter1.Section3;

public class Exercise3_41 : IExercise
{
    public void Run(string[] args)
    {
        var random = new Random();
        var trial = 1_000_000;
        var possibilityA = 0;
        var possibilityB = 0;
        
        for (var i = 0; i < trial; i++)
        {
            if (AtLeastOneOneInSix(random))
                possibilityA++;
            if (AtLeastTwoOnesInTwelve(random))
                possibilityB++;
        }

        Console.WriteLine($"Probability A ≈ {(double)possibilityA / trial:F5}");
        Console.WriteLine($"Probability B ≈ {(double)possibilityB / trial:F5}");
    }

    private bool AtLeastOneOneInSix(Random random)
    {
        for (var i = 0; i < 6; i++)
        {
            if (random.Next(1, 7) == 1)
                return true;
        }
        return false;
    }
    
    
    private bool AtLeastTwoOnesInTwelve(Random random)
    {
        var count = 0;
        for (var i = 0; i < 12; i++)
        {
            if (random.Next(1, 7) != 1) continue;
            count++;
            if (count >= 2)
                return true;
        }
        return false;
    }
}