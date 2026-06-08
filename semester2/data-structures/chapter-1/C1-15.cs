public class C1_15
{
    private static readonly Random rand = new Random();

    public static void Run()
    {
        var testArray = new int[rand.Next(5, 10)];
        for (int i = 0; i < testArray; i++)
            testArray[i] = rand.Next(10);


        var minNum = int.Max;
        var maxNum = int.Min;

        for (int i = 0; i < testArray.Length; i++)
        {
            if (testArray[i] > maxNum)
                maxNum = testArray[i];

            if (testArray[i] < minNum)
                minNum = testArray[i];
        }
    }
}