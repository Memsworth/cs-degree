
public class C17
{
    private static readonly Random rand = new Random();

    public void Run()
    {
        var testArray = new int[rand.Next(5, 10)];
        for (int i = 0; i < testArray.Length; i++)
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

        System.Console.WriteLine(isTrue ? "There is a pair" : "There isn't a pair");
    }
}