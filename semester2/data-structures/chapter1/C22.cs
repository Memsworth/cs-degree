public class C22
{
    private readonly string items = "catdog";

    public void Run()
    {
        var charArray = items.ToArray();

        Permuate(charArray, 0);
    }

    private void Permuate(char[] chars, int start)
    {
        if (start == chars.Length - 1)
        {
            System.Console.WriteLine();
        }
    }
}