namespace CSharpPlayersGuide.level13;

internal class ChallengeCountdown : IExercise
{
    public void Run()
    {
        Kaboom(10);
    }



    public void Kaboom(int num)
    {
        if (num == 0)
            Console.WriteLine("Kaboom!");
        else
        {
            Console.WriteLine($"{num}");
            Kaboom(num - 1);
        }
    }
}
