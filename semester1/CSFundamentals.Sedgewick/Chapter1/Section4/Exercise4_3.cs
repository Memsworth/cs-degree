namespace CSFundamentals.Sedgewick.Chapter1.Section4;

public class Exercise4_3 : IExercise
{
    public void Run(string[] args)
    {
        var size = int.Parse(args[0]);
        var array1 = new int[] { 1, 2, 3 };
        var array2 = new int[] { 4, 6, 3 };

        var rand = new Random();
        var sum = 0;
        /*for (int i = 0; i < size; i++)
        {
            array1[i] = rand.Next();
            array2[i] = rand.Next();
        }*/

        for (int i = 0; i < size; i++)
        {
            var summation = (int)Math.Pow((array1[i] - array2[i]), 2);
            sum += summation;
        }

        var final = Math.Sqrt(sum);

        System.Console.WriteLine($"final val: {final:F2}");
    }
}