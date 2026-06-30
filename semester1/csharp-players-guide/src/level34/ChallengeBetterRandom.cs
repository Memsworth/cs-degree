namespace CSharpPlayersGuide.level34;


public class BetterRandom : IExercise
{
    public void Run()
    {
        var rand = new Random();

        var item = rand.CustomNextDobule();
        var item2 = rand.CustomNextString("hello", "test", "item");

        System.Console.WriteLine(item2);
        System.Console.WriteLine(rand.CustomCoinFlip());
    }
}


public static class Extentions
{
    public static double CustomNextDobule(this Random random) => random.Next() + random.NextDouble();
    public static string CustomNextString(this Random random, params string[] strings)
    {
        var key = random.Next(0, strings.Length);
        return strings[key];
    }

    public static bool CustomCoinFlip(this Random random) => random.NextDouble() > 0.49 ? true : false;
}