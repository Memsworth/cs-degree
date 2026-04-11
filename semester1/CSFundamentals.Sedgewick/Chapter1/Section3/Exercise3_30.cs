namespace CSFundamentals.Sedgewick.Chapter1.Section3;

public class Exercise3_30 : IExercise
{
    public void Run(string[] ars)
    {
        var x = int.Parse(ars[0]);
        var y = int.Parse(ars[1]);
        while(y != 0)
        {
            var temp = y;
            y = x % y;
            x = temp;
        }
        
        System.Console.WriteLine($"gcd: {x}");
    }
}