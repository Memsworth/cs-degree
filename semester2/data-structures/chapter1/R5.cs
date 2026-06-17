namespace data_structures.chapter1;

public class R5 : IExercise
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
            target++;

        System.Console.WriteLine($"{target}");
    }
}