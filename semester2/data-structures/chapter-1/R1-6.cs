public class R1_6
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
        {
            if (k % 2 != 0)
                target++;
        }
        System.Console.WriteLine($"{target}");
    }
}