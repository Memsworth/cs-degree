namespace CSharpPlayersGuide.level13;

internal class ChallengeTakingNumber : IExercise
{
    public void Run()
    {
        var age = AskForNumber("Enter age");
        var age2 = AskForNumberInRange("Enter age2", 10, 15);
    }

    private int AskForNumber(string text)
    {
        var result = 0;
        while(true)
        {
            Console.WriteLine($"{text} ");
            if (!int.TryParse(Console.ReadLine(), out result))
                break;
        }
        return result;
    }

    private int AskForNumberInRange(string text, int min, int max)
    {
        var result = 0;
        while (true)
        {
            Console.WriteLine($"{text} ");
            if (!int.TryParse(Console.ReadLine(), out result))
                if (result > min && result < max)
                    break;
        }
        return result;
    }
}
