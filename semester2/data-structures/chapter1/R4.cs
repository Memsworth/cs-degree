namespace data_structures.chapter1;

public class R4 : IExercise
{
    public void Run()
    {
        var result = IsEven(2);
        Console.WriteLine(result);
    }
    
    private static bool IsEven(int i)
    {
        if (i == 0)
            return true;

        i = Math.Abs(i);

        int target = 0;
        while (target < i)
            target += 2;

        return target == i;
    }
}