public class C1_17
{
    private static readonly Random rand = new Random();

    public static void Run()
    {
        var testArray = new int[rand.Next(5, 10)];
        for (int i = 0; i < testArray; i++)
            testArray[i] = rand.Next(1, 10);

        var isTrue = false;

        for (int i = 0; i < testArray.Length - 1; i++)
        {
            if ((testArray[i] * testArray[i + 1]) % 2 == 0)
            {
                isTrue = true;
                break;
            }
        }

        if (isTrue)
            System.Console.WriteLine("There is a pair");
        else
            System.Console.WriteLine("There isn't a pair");
    }
}