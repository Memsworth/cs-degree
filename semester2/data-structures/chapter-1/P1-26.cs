#!
using System.Text;


System.Console.WriteLine("Hello");

var test = new P1_26();
test.Run();


public class P1_26
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