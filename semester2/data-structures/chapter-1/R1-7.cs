public class R1_7
{
    public static void GetSum(int i)
    {
        if (i <= 0)
        {
            System.Console.WriteLine("Less than zero");
            return;
        }

        var target = 0;
        for (int k = 1; k <= i; k++)
        {
            target += k * k;
        }
        System.Console.WriteLine($"{target}");
    }
}