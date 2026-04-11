using System;

namespace CSFundamentals.Sedgewick.Chapter1.Section2;

/*
 * Uniform Random Numbers
 *
 * Write a program that prints five uniform random numbers between 0 and 1,
 * their average value, and their minimum and maximum values. Use the built-in
 * Math.random() method to generate the numbers, and Math.min() and Math.max()
 * to determine the smallest and largest values.
 *
 * The program should:
 *   - Generate five random double values in the range [0.0, 1.0)
 *   - Print each of the five values
 *   - Compute and print the average of the five values
 *   - Determine and print the minimum and maximum values among them
 *
 * Example output:
 *   0.732049
 *   0.183927
 *   0.578120
 *   0.928374
 *   0.351907
 *   Average = 0.554475
 *   Minimum = 0.183927
 *   Maximum = 0.928374
 */

public class Exercise2_30
{
    public Exercise2_30() { }

    public void Run()
    {
        var seed = new Random();

        var num1 = seed.NextDouble();
        var num2 = seed.NextDouble();
        var num3 = seed.NextDouble();
        var num4 = seed.NextDouble();
        var num5 = seed.NextDouble();

        System.Console.WriteLine($"{num1:F3} - {num2:F3} - {num3:F3} - {num4:F3} - {num5:F3}");
        var nums = new double[] { num1, num2, num3, num4, num5 };

        var minNum = Math.Min(num5, Math.Min(num4, Math.Min(num3, Math.Min(num2, num1))));
        var maxNum = Math.Max(num5, Math.Max(num4, Math.Max(num3, Math.Max(num2, num1))));
        System.Console.WriteLine($"min: {minNum:F3}");
        System.Console.WriteLine($"max: {maxNum:F3}");

        System.Console.WriteLine($"average: {nums.Average()}");
    }
}
