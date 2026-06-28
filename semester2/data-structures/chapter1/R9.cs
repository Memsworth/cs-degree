using System.Text;


public class R9
{
    private readonly string message = "Let’s try, Mike!";

    private void BuildString()
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

    public void Run()
    {
        BuildString();
    }
}