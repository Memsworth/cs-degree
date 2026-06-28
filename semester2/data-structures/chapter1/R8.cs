public class R8
{
    private readonly string vowels = "aeiou";

    public void Run()
    {
        IsVowel(Console.ReadLine());
    }


    private void IsVowel(string userInput)
    {
        if (string.IsNullOrEmpty(userInput))
        {
            System.Console.WriteLine("Empty string");
            return;
        }

        var target = 0;
        foreach (var item in userInput)
        {
            var containResult = vowels.Contains(item);
            if (containResult)
                target++;
        }

        System.Console.WriteLine(target);
    }
}