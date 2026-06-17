namespace data_structures.chapter1;

public class C23 : IExercise
{
    private static readonly Random rand = new Random();

    public void Run()
    {
        var randArray = new int[rand.Next(5, 15)];
        var randArray2 = new int[rand.Next(5, 15)];
        var resultArray = new int[rand.Next(5, 15)];

        for (int i = 0; i < randArray.Length; i++)
        {
            randArray[i] = rand.Next(0, 10);
            randArray2[i] = rand.Next(0, 10);
        }

        for (int i = 0; i < randArray.Length; i++)
            resultArray[i] = randArray[i] * randArray2[i];

    }
}