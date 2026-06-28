using System.Text;


public class P26
{
    public void Run()
    {
        var userInput = Console.ReadLine();

        if (string.IsNullOrEmpty(userInput))
        {
            System.Console.WriteLine("no empty items");
            return;
        }

        var tokens = userInput.Split(" ");

        var stringBuilder = new StringBuilder();

        foreach (var item in tokens)
        {
            var itemToAppend = new string([.. item.Reverse()]);
            stringBuilder.Append(itemToAppend);
            stringBuilder.Append(" ");
        }
        stringBuilder.Remove(stringBuilder.Length - 1, 1);

        var toPrint = stringBuilder.ToString();

        System.Console.WriteLine(toPrint);
    }
}