
namespace CSFundamentals.Sedgewick.Chapter1.Section4;

internal class Exercise4_19 : IExercise
{
    public void Run(string[] args)
    {
        var len = int.Parse(args[0]);

        var array1 = new bool[len, len];
        var array2 = new bool[len, len];
        var array3 = new bool[len, len];
        var rand = new Random();

        for (var i = 0; i < array1.GetLength(0); i++)
        {
            for (var j = 0; j < array1.GetLength(1); j++)
            {
                var roll = rand.Next(2);
                array1[i, j] = roll == 0 ? true : false;

                roll = rand.Next(2);
                array2[i, j] = roll == 0 ? true : false;
            }
        }

        for (var i = 0; i < array1.GetLength(0); i++)
        {
            for (var j = 0; j < array1.GetLength(1); j++)
            {
                for (var k = 0; k < array1.GetLength(1); k++)
                {
                    if (array3[i, j])
                        break;
                    array3[i, j] = (array3[i, j] || (array1[i, k] && array2[k, j]));
                }
            }
        }

        PrintArray(array1, "A");
        PrintArray(array2, "B");
        PrintArray(array3, "C");

    }

    private void PrintArray(bool[,] arrayA, string arrayName)
    {
        System.Console.WriteLine($"Array {arrayName}: ");
        for (int i = 0; i < arrayA.GetLength(0); i++)
        {
            for (int j = 0; j < arrayA.GetLength(1); j++)
            {
                System.Console.Write($" {arrayA[i, j]} ");
            }
            System.Console.WriteLine();
        }
    }
}
