

public class C1_18
{
    private static readonly Random rand = new Random();
    public static void Run()
    {
        var randArray = new Point[rand.Next(5, 15)];
        var powOf = rand.Next(2, 5);

        for (int i = 0; i < randArray.Length; i++)
        {
            randArray[i] = new Point(rand.Next(0, 10), rand.Next(0, 10));
        }

        double fullVal = 0;

        foreach (var item in randArray)
            fullVal += Math.Pow(Math.Pow(item.x, powOf) + Math.Pow(item.y, powOf), 1.0 / powOf);


        System.Console.WriteLine(fullVal);

    }

    public record Point(int x, int y);
}
