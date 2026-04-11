using System.Globalization;

namespace CSFundamentals.Sedgewick.Chapter1.Section3;

public class Exercise3_17 : IExercise
{
    public void Run(string[] args)
    {
        var culture = new CultureInfo("en-US");
        var principal = decimal.Parse(args[0]);
        var interest = double.Parse(args[1]);
        
        var amountPerPeriod = new List<decimal>();

        for (int i = 0; i < 25; i++)
        {
            var appendToEuler = (interest/100) * (i+1);
            var RoI = principal * (decimal)Math.Pow(Math.E, appendToEuler);
            amountPerPeriod.Add(RoI);
        }

        var year = 1990;
        foreach (var amount in amountPerPeriod)
        {
            Console.WriteLine($"Payment at the end of {year}: {amount.ToString("C", culture)}");
            year++;
        }
    }
}