using System;

namespace CSFundamentals.Sedgewick.Chapter1.Section2;

/*
 * Write a program that takes two positive integers as command-line arguments
 * and prints true if either evenly divides the other.
 * 
 * Example:
 *   Input:  4 16
 *   Output: True  (since 16 % 4 == 0)
 * 
 *   Input:  7 3
 *   Output: False (neither divides the other evenly)
 */

public class Exercise2_14
{
    public Exercise2_14() { }

    public void Run(int arg1, int arg2)
    {
        if (arg1 == 0 || arg2 == 0)
        {
            System.Console.WriteLine("Zero in here.");
            return;
        }

        var result = (arg1 % arg2 == 0 || arg2 % arg1 == 0);
        System.Console.WriteLine(result);
    }
}