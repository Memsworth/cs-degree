namespace data_structures.chapter1;

public class R6 : IExercise
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
        for (int k = 0; k < i; k++)
        {
            if (k % 2 != 0)
                target++;
        }
        System.Console.WriteLine($"{target}");
    }
}