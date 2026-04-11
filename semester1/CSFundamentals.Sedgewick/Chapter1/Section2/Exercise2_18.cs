using System;

namespace CSFundamentals.Sedgewick.Chapter1.Section2;


/*
 * Write a program that takes two integer command-line arguments x and y,
 * and prints the Euclidean distance from the point (x, y) to the origin (0, 0).
 *
 * Note:
 *   The Euclidean distance from (x, y) to (0, 0) is calculated as:
 *   √(x² + y²)
 *
 * Example:
 *   Input:  3 4
 *   Output: 5
 *
 *   Input:  6 8
 *   Output: 10
 */

public class Exercise2_18
{
    public Exercise2_18() {}
    public void Run(int arg1, int arg2)
    {
        var result = Math.Sqrt(Math.Pow(arg1, 2) + Math.Pow(arg2, 2));
        System.Console.WriteLine(result);
    }
}
