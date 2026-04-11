using System;

namespace CSFundamentals.Sedgewick.Chapter1.Section2;

public class Exercise2_2
{

    public Exercise2_2()
    {
    }

    public void Run(double args)
    {
        var cosVal = Math.Cos(args);
        var sinVal = Math.Sin(args);
        Console.WriteLine($"cos(θ): {cosVal}");
        Console.WriteLine($"sin(θ): {sinVal}");
        var finalVal = Math.Pow(cosVal, 2) + Math.Pow(sinVal, 2);
        Console.WriteLine($"cos²(θ) + sin²(θ) = {finalVal}");
    }
}