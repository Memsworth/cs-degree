using System;

namespace CSFundamentals.Sedgewick.Chapter1.Section2;

/*
 * Three-Sort
 *
 * Write a program that takes three integer command-line arguments and prints
 * them in ascending order. You should use the built-in Math.min() and Math.max()
 * functions to determine the smallest and largest values, and compute the middle
 * value using simple arithmetic.
 *
 * The program should:
 *   - Read three integers from the command line
 *   - Determine the minimum and maximum using Math.min() and Math.max()
 *   - Compute the middle value using: middle = total - min - max
 *   - Print the numbers in ascending order: min, middle, max
 *
 * Example:
 *   Input: 3 2 1
 *   Output: 1 2 3
 *
 *   Input: -5 10 0
 *   Output: -5 0 10
 *
 *   Input: 7 7 2
 *   Output: 2 7 7
 */

public class Exercise2_34
{
    public Exercise2_34() { }

    public void Run(string[] args)
    {
        var valOne = int.Parse(args[0]);
        var valTwo = int.Parse(args[1]);
        var valThree = int.Parse(args[2]);

        var maxVal = Math.Max(valOne, Math.Max(valTwo, valThree));
        var minVal = Math.Min(valOne, Math.Min(valTwo, valThree));
        var mid = (valOne + valTwo + valThree) - (maxVal + minVal);

        System.Console.WriteLine($"min = {minVal}");
        System.Console.WriteLine($"mid = {mid}");
        System.Console.WriteLine($"max = {maxVal}");
    }
}
