using System;

namespace CSFundamentals.Sedgewick.Chapter1.Section3;

/*
 * Hellos
 *
 * Rewrite TenHellos to create a program Hellos that prints a specified number
 * of "Hello" lines, where the number of lines is provided as a command-line argument.
 *
 * Your program should:
 *   - Take one integer command-line argument: the number of lines to print (n).
 *   - Assume n is less than 1000.
 *   - Print "Hello" lines numbered from 1 to n.
 *   - Use the correct ordinal suffix (st, nd, rd, th) for each line number.
 *     Hint: Use i % 10 and i % 100 to determine the suffix.
 *
 * Example:
 *   Input: 5
 *   Output:
 *     1st Hello
 *     2nd Hello
 *     3rd Hello
 *     4th Hello
 *     5th Hello
 */


public class Exercise3_8 : IExercise
{
    public void Run(string[] args)
    {
        var valToIterate = int.Parse(args[0]);
        var iterator = 1;
        while(iterator <= valToIterate)
        {
            string form;
            if (iterator % 100 >= 11 && iterator % 100 <= 13)
                form = "th";

            else if (iterator % 10 == 1 || iterator % 100 == 1)
                form = "st";

            else if (iterator % 10 == 2 || iterator % 100 == 2)
                form = "nd";

            else if (iterator % 10 == 3 || iterator % 100 == 3)
                form = "rd";

            else
                form = "th";


            System.Console.WriteLine($"{iterator}{form} Hello");
            iterator++;
        }
    }
}
