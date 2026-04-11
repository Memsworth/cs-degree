using System;

namespace CSFundamentals.Sedgewick.Chapter1.Section2;


/*
 * Write a program that takes a double command-line argument t and prints
 * the value of sin(2t) + sin(3t).
 *
 * Note:
 *   - The argument t should be a double (floating-point number).
 *   - Use the Math.Sin method from the System namespace to compute sine.
 *   - The program should calculate sin(2 * t) and sin(3 * t), then print their sum.
 *
 * Example:
 *   Input: 1.0
 *   Output: 1.7507684116335782
 *
 *   Input: 0.5
 *   Output: 1.2478686821992183
 */

public class Exercise2_21
{
    public Exercise2_21() { }
    public void Run(string[] args)
    {
        var t = double.Parse(args[0]);
        var value = Math.Sin(t * 2) + Math.Sin(t * 3);
        System.Console.WriteLine(value);
    }
}
