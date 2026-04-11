namespace CSFundamentals.Sedgewick.Chapter1.Section4;

internal class Exercise4_13 : IExercise
{
    public void Run(string[] args)
    {
        var x = int.Parse(args[0]);
        var y = int.Parse(args[1]);

        var rand = new Random();

        var squareArray = new int[x, x];
        var rectangularArray = new int[x, y];
        var jaggedArray = new int[x][];

        for (var i = 0; i < jaggedArray.GetLength(0); i++)
        {
            jaggedArray[i] = new int[rand.Next(1, y + 1)];
        }

        for (int i = 0; i < jaggedArray.GetLength(0); i++)
        {
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                jaggedArray[i][j] = rand.Next(10);
            }
        }

        for (int i = 0; i < squareArray.GetLength(0); i++)
        {
            for (int j = 0; j < squareArray.GetLength(1); j++)
            {
                squareArray[i, j] = rand.Next(10);
            }
        }

        for (int i = 0; i < rectangularArray.GetLength(0); i++)
        {
            for (int j = 0; j < rectangularArray.GetLength(1); j++)
            {
                rectangularArray[i, j] = rand.Next(10);
            }
        }


        System.Console.WriteLine($"Solution B for square array = {IsCopyCorrect(squareArray, SolutionB(squareArray))}");
        System.Console.WriteLine($"Solution B for rectangular array = " +
            $"{IsCopyCorrect(rectangularArray, SolutionB(rectangularArray))}");

        System.Console.WriteLine($"Solution C for jagged array = " +
            $"{IsCopyCorrect(jaggedArray, SolutionC(jaggedArray))}");


        PrintArray(squareArray, SolutionB(squareArray));
        Console.ReadKey();
        System.Console.WriteLine();
        PrintArray(rectangularArray, SolutionB(rectangularArray));

        Console.ReadKey();
        System.Console.WriteLine();
        PrintArray(jaggedArray, SolutionC(jaggedArray));
    }

    private bool IsCopyCorrect(int[,] arrayA, int[,] arrayB)
    {
        for (int i = 0; i < arrayA.GetLength(0); i++)
        {
            for (int j = 0; j < arrayA.GetLength(1); j++)
            {
                if (arrayA[i, j] != arrayB[i, j])
                    return false;
            }
        }
        return true;
    }

    private bool IsCopyCorrect(int[][] arrayA, int[,] arrayB)
    {
        for (int i = 0; i < arrayA.GetLength(0); i++)
        {
            for (int j = 0; j < arrayA[i].Length; j++)
            {
                if (arrayA[i][j] != arrayB[i, j])
                    return false;
            }
        }
        return true;
    }

    private int[,] SolutionB(int[,] arrayA)
    {
        var arrayB = new int[arrayA.GetLength(0), arrayA.GetLength(1)];

        for (int i = 0; i < arrayA.GetLength(0); i++)
        {
            for (int j = 0; j < arrayA.GetLength(1); j++)
            {
                arrayB[i, j] = arrayA[i, j];
            }
        }

        return arrayB;
    }


    private int[,] SolutionC(int[][] arrayA)
    {
        var maxIndex = 0;


        for (int i = 0; i < arrayA.GetLength(0); i++)
        {
            if (arrayA[i].Length > maxIndex) maxIndex = arrayA[i].Length;
        }

        var arrayB = new int[arrayA.GetLength(0), maxIndex];

        for (int i = 0; i < arrayA.GetLength(0); i++)
        {
            for (int j = 0; j < arrayA[i].Length; j++)
            {
                arrayB[i, j] = arrayA[i][j];
            }
        }

        return arrayB;
    }


    private void PrintArray(int[][] arrayA, int[,] arrayB)
    {
        System.Console.WriteLine("Array A: ");
        for (int i = 0; i < arrayA.GetLength(0); i++)
        {
            for (int j = 0; j < arrayA[i].Length; j++)
            {
                System.Console.Write($" {arrayA[i][j]} ");
            }
            System.Console.WriteLine();
        }


        System.Console.WriteLine("Array B: ");
        for (int i = 0; i < arrayB.GetLength(0); i++)
        {
            for (int j = 0; j < arrayB.GetLength(1); j++)
            {
                System.Console.Write($" {arrayB[i, j]} ");
            }
            System.Console.WriteLine();
        }
    }


    private void PrintArray(int[,] arrayA, int[,] arrayB)
    {
        System.Console.WriteLine("Array A: ");
        for (int i = 0; i < arrayA.GetLength(0); i++)
        {
            for (int j = 0; j < arrayA.GetLength(1); j++)
            {
                System.Console.Write($" {arrayA[i, j]} ");
            }
            System.Console.WriteLine();
        }


        System.Console.WriteLine("Array B: ");
        for (int i = 0; i < arrayB.GetLength(0); i++)
        {
            for (int j = 0; j < arrayB.GetLength(1); j++)
            {
                System.Console.Write($" {arrayB[i, j]} ");
            }
            System.Console.WriteLine();
        }
    }
}
