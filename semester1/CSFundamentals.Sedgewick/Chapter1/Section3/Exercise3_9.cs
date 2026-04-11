using System;

namespace CSFundamentals.Sedgewick.Chapter1.Section3;

/*
 * Print Integers 1000 to 2000, Five per Line
 *
 * Write a program that prints the integers from 1000 to 2000, inclusive,
 * with exactly five integers per line.
 *
 * Requirements:
 *   - Use a single for loop.
 *   - Use a single if statement.
 *   - Hint: Use the modulus (%) operation to determine when to print a newline.
 *
 * Example Output (first 10 numbers):
 *   1000 1001 1002 1003 1004
 *   1005 1006 1007 1008 1009
 *   ...
 */

public class Exercise3_9 : IExercise
{
    public void Run(string[] args)
    {
        var currentCount = 1000;

        for (int i = 1; currentCount < 2001;  i++)
        {
            Console.Write($"{currentCount} ");
            if (i % 5 == 0)
                Console.WriteLine("\n");

            currentCount++;
        }
    }
}
