namespace CSFundamentals.Sedgewick.Chapter1.Section4;

public class Exercise4_4 : IExercise
{
    public void Run(string[] args)
    {
        Console.WriteLine("Before swap");
        foreach(var item in args)
            Console.WriteLine($"{item}");


        Console.WriteLine("After swap");
        for(var i = 0; i < args.Length/2; i++)
        {
            var currLastIndex = (args.Length - (i + 1));
            if (args[i] is not null &&  args[currLastIndex] is not null)
                Swap(args, i, currLastIndex);
        }

        foreach (var item in args)
            Console.WriteLine($"{item}");
    }

    private void Swap(string[] array, int startIndex, int endIndex)
    {
        var temp = array[startIndex];
        array[startIndex] = array[endIndex];
        array[endIndex] = temp;
    }
}
