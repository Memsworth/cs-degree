namespace CSFundamentals.Sedgewick.Chapter1.Section3;

public class Exercise3_35 : IExercise
{
    public void Run(string[] args)
    {
        if (args[0].Length != 9)
        {
            System.Console.WriteLine("No nine digits");
            return;
        }
        var numberInStringFormat = args[0];
        var ISBN = 0;
        var sum = 0;
        var count = 100000000;
        var multiCount = 10;
        for (int i = 0; i < 9; i++)
        {
            var firstDigit = int.Parse(numberInStringFormat[i].ToString());
            ISBN += firstDigit * count;
            count /= 10;
            sum += (firstDigit * (multiCount--));
        }

        var checkDigit = (11 - (sum % 11)) % 11;

        System.Console.WriteLine($"final val = {(checkDigit == 10 ? "X" : checkDigit.ToString())}");
        System.Console.WriteLine($"Full ISBN of the book: {ISBN}{(checkDigit == 10 ? "X" : checkDigit.ToString())}");
    }
}
