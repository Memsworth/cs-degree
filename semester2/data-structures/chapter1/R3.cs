namespace data_structures.chapter1;

public class R3 : IExercise
{
    private static bool IsMultiple(long n, long m)
    {
        return m != 0 && n % m == 0;
    }

    public void Run()
    {
        Console.WriteLine(IsMultiple(10, 5)); // True
        Console.WriteLine(IsMultiple(10, 3)); // False
    }
}