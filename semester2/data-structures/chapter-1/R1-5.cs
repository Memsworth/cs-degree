public class R1_5
{
    public static void GetSum(int i)
    {
        if (i <= 0)
        {
            System.Console.WriteLine("Less than zero");
            return;
        }

        var target = 0;
        for (int k = 0; k < i; k++)
            target++;

        System.Console.WriteLine($"{target}");
    }
}