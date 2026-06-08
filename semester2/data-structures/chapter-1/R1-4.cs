public class R1_4
{
    public static bool IsEven(int i)
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