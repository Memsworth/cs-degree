using System;
using System.Collections.Generic;
using System.Text;

namespace CSFundamentals.Sedgewick.Chapter1.Section4;

internal class Exercise4_18 : IExercise
{
    public void Run(string[] args)
    {
        if (args.Length != 4)
        {
            System.Console.WriteLine("Not enough");
            return;
        }

        var structure = args
                .Select(x => int.TryParse(x, out int v) ? v : 0)
                .ToList();

        if (structure[1] != structure[2])
        {
            System.Console.WriteLine("Can't support struture");
            return;
        }

        var array1 = new int[structure[0], structure[1]];
        var array2 = new int[structure[2], structure[3]];
        var rand = new Random();
        Enumerable.Range(0, array1.GetLength(0)).ToList().ForEach(x =>
        {
            Enumerable.Range(0, array1.GetLength(1)).ToList().ForEach(y =>
            {
                array1[x, y] = rand.Next(10);
            });
        });

        Enumerable.Range(0, array2.GetLength(0)).ToList().ForEach(x =>
        {
            Enumerable.Range(0, array2.GetLength(1)).ToList().ForEach(y =>
            {
                array2[x, y] = rand.Next(10);
            });
        });

        var array3 = GetProduct(array1, array2);
        PrintArray(array1, "array 1");
        PrintArray(array2, "array 2");
        PrintArray(array3, "array 3");
    }

    private int[,] GetProduct(int[,] array1, int[,] array2)
    {
        var array3 = new int[array1.GetLength(0), array2.GetLength(1)];
        for (var i = 0; i < array3.GetLength(0); i++)
        {
            for (var j = 0; j < array3.GetLength(1); j++)
            {
                for (var k = 0; k < array1.GetLength(1); k++)
                {
                    array3[i, j] += array1[i, k] * array2[k, j];
                }
            }
        }
        return array3;
    }

    private void PrintArray(int[,] arrayA, string arrayName)
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
