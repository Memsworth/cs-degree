namespace data_structures.chapter1;

public class C15 : IExercise
{
    private static readonly Random rand = new Random();

    public void Run()
    {
        var testArray = new int[rand.Next(5, 10)];
        for (var i = 0; i < testArray.Length; i++)
            testArray[i] = rand.Next(10);

        var minNum = int.MaxValue;
        var maxNum = int.MinValue;

        foreach (var t in testArray)
        {
            if (t > maxNum)
                maxNum = t;

            if (t < minNum)
                minNum = t;
        }
    }
}