Console.WriteLine(R1_3.IsMultiple(10, 5)); // True
Console.WriteLine(R1_3.IsMultiple(10, 3)); // False
public class R1_3
{
    public static bool IsMultiple(long n, long m)
    {
        return m != 0 && n % m == 0;
    }
}