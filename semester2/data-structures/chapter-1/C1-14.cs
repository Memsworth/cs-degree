public class C1_14
{
    private static readonly Random rand = new Random();

    public static void Run()
    {
        var testArray = new int[rand.Next(5, 10)];
        for (int i = 0; i < testArray; i++)
            testArray[i] = rand.Next(10);


        var copyArray = new int[testArray.Length];

        for (int i = 0; i < testArray.Length; i++)
            copyArray[i] = testArray[testArray.Length - 1 - i];

    }
}