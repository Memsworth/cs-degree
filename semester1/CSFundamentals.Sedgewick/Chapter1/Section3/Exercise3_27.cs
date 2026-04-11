namespace CSFundamentals.Sedgewick.Chapter1.Section3;

public class Exercise3_27 : IExercise
{
    public void Run(string[] args)
    {
        var n = long.Parse(args[0]);
        var set = new HashSet<long>();

        //optimized route

        if(n % 2 == 0)
        {
            set.Add(2);
            while(n % 2 ==0)
                n /= 2;
        }

        for (long factor = 3; (int)Math.Pow(factor,2) <= n; factor+=2)
        {
            if (n % factor != 0) continue;
            set.Add(factor);
            while (n % factor == 0)
                n /= factor;
        }

        if (n > 1)
            set.Add(n);
        
        foreach (var factor in set)
            System.Console.WriteLine(factor);
    }
}