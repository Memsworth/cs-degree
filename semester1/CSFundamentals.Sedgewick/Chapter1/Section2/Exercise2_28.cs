using System;

namespace CSFundamentals.Sedgewick.Chapter1.Section2;

/*
 * Order Check
 *
 * Write a program that takes three double command-line arguments x, y, and z,
 * and prints true if the values are strictly ascending (x < y < z)
 * or strictly descending (x > y > z), and false otherwise.
 *
 * Example:
 *   Input: 1.0 2.0 3.0
 *   Output: True
 *
 *   Input: 9.0 5.0 1.0
 *   Output: True
 *
 *   Input: 1.0 2.0 2.0
 *   Output: False
 */

public class Exercise2_28
{
    public Exercise2_28() { }

    public void Run(string[] args)
    {
        var isValid = false;

        var valueOne = double.Parse(args[0]);
        var valueTwo = double.Parse(args[1]);
        var valueThree = double.Parse(args[2]);

        if ((valueOne > valueTwo) && (valueTwo > valueThree))
        {
            isValid = true;
        }
        else if ((valueOne < valueTwo) && (valueTwo < valueThree))
        {
            isValid = true;
        }

        System.Console.WriteLine(isValid);
    }
}
