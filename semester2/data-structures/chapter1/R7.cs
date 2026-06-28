
public class R7
{
    public void Run()
    {
        GetSum(5);
    }

    private static void GetSum(int i)
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