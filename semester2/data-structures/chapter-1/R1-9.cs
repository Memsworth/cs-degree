using System.Text;

public class R1_9
{
    private readonly string message = "Let’s try, Mike!";

    public static void BuildString()
    {
        var stringBuilder = new StringBuilder();

        foreach (var c in message)
        {
            if (!char.IsPunctuation(c))
            {
                stringBuilder.Append(c);
            }
        }
        System.Console.WriteLine(stringBuilder.ToString());
    }
}