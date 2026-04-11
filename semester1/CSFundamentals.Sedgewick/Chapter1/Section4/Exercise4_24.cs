namespace CSFundamentals.Sedgewick.Chapter1.Section4;

internal class Exercise4_24 : IExercise
{
    public void Run(string[] args)
    {
        var shuffle = int.Parse(args[0]);
        var len = int.Parse(args[1]);

        var array1 = new int[len];
        var array2 = new int[len, len];
        var k = 0;
        Enumerable.Range(0, array1.Length).ToList().ForEach(x => array1[x] = x);
        var rand = new Random();
        for (var i = 0; i < shuffle; i++)
        {
            var shuffled = array1.Shuffle().ToArray();
            for(var j = 0; j < shuffled.Length; j++)
            {
                var currentVal = shuffled[j];
                array2[currentVal, j]++;
            }
        }

        Print2D(array2);

        Console.WriteLine($"{(double)shuffle/len}");
    }


    public static void Print2D(int[,] table)
    {
        int rows = table.GetLength(0);
        int cols = table.GetLength(1);

        int maxWidth = 0;
        foreach (int value in table)
        {
            int width = value.ToString().Length;
            if (width > maxWidth)
                maxWidth = width;
        }

        maxWidth = Math.Max(maxWidth, cols.ToString().Length);
        maxWidth += 2;

        Console.Write("".PadLeft(maxWidth));
        for (int j = 0; j < cols; j++)
            Console.Write(j.ToString().PadLeft(maxWidth));
        Console.WriteLine();

        for (int i = 0; i < rows; i++)
        {
            Console.Write(i.ToString().PadLeft(maxWidth));

            for (int j = 0; j < cols; j++)
                Console.Write(table[i, j].ToString().PadLeft(maxWidth));

            Console.WriteLine();
        }
    }
}
