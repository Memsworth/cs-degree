namespace data_structures.chapter1;

public class C16 : IExercise
{
    public void Run()
    {
        System.Console.WriteLine("enter 3 number: ");

        var userInput = Console.ReadLine();

        var tokens = userInput.Split(' ')
            .Select(x => int.Parse(x)).ToArray();


        var isTrue = false;

        if (tokens[0] + tokens[1] == tokens[2])
        {
            System.Console.WriteLine("a + b = c");
            isTrue = true;
        }

        if (tokens[1] - tokens[2] == tokens[0])
        {
            System.Console.WriteLine("a = b - c");
            isTrue = true;
        }

        if (tokens[0] * tokens[1] == tokens[2])
        {
            System.Console.WriteLine("a * b = c");
            isTrue = true;
        }
        if (!isTrue)
            System.Console.WriteLine("No formula is used");
    }
}