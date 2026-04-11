using System;
using System.Collections.Generic;
using System.Text;

namespace CSFundamentals.Sedgewick.Chapter1.Section4;

internal class Exercise4_17 : IExercise
{
    public void Run(string[] args)
    {
        double[,] a =   {
                            { 99.0, 85.0, 98.0,  0.0 },
                            { 98.0, 57.0, 79.0,  0.0 },
                            { 92.0, 77.0, 74.0,  0.0 },
                            { 94.0, 62.0, 81.0,  0.0 },
                            { 99.0, 94.0, 92.0,  0.0 },
                            { 80.0, 76.5, 67.0,  0.0 },
                            { 76.0, 58.5, 90.5,  0.0 },
                            { 92.0, 66.0, 91.0,  0.0 },
                            { 97.0, 70.5, 66.5,  0.0 },
                            { 89.0, 89.5, 81.0,  0.0 },
                        };


        var weight = new double[] { 0.25, 0.25, 0.50 };

        for (var i = 0; i < a.GetLength(0); i++)
        {
            double sum = 0.0;
            for (int j = 0; j < weight.Length; j++)
                sum += a[i, j] * weight[j];

            a[i, a.GetLength(1) - 1] = sum;
        }
    }
}
