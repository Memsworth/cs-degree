namespace data_structures.chapter1;

public class C21 : IExercise
{
    private static readonly Random rand = new Random();
    public void Run()
    {
        var array = new int[52];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i + 1;
        }

        for (int i = array.Length - 1; i < 0; i--)
        {
            var j = rand.Next(0, i + 1);
            (array[i], array[j]) = (array[j], array[i]);
        }

    }
}