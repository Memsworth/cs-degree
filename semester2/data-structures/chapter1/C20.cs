namespace data_structures.chapter1;

public class C20 : IExercise
{
    private static readonly Random rand = new Random();

    public void Run()
    {
        var randArray = new double[rand.Next(5, 15)];
        for (int i = 0; i < randArray.Length; i++)
        {
            randArray[i] = rand.Next(0, 10) + rand.NextDouble();
        }

        var isCopy = false;

        //come back and fix this O(n^2)
        for (int i = 0; i < randArray.Length; i++)
        {
            for (int k = 0; k < randArray.Length; k++)
            {
                if (i == k)
                    continue;

                isCopy = randArray[i] == randArray[k];

                if (isCopy)
                {
                    System.Console.WriteLine($"found: {randArray[i]}");
                    return;
                }
            }
        }

    }
}