namespace data_structures.chapter1;

public class C19 : IExercise
{
    public void Run()
    {
        var target = 0;

        var userInput = int.Parse(Console.ReadLine());

        if (userInput < 2)
        {
            System.Console.WriteLine("less than 2");
            return;
        }

        while (userInput >= 0)
        {
            userInput /= 2;
            target++;
        }

        System.Console.WriteLine($"Amount of times: {target}");
    }
}