using System;

namespace CSFundamentals.Sedgewick.Chapter1.Section3;

/*
 * Equal Integers Checker
 *
 * Write a program that takes three integer command-line arguments
 * and prints "equal" if all three integers are the same,
 * and "not equal" otherwise.
 *
 * Your program should:
 *   - Accept three integer command-line arguments: a, b, and c.
 *   - Compare the three integers to determine if they are all equal.
 *   - Print "equal" if a == b == c, otherwise print "not equal".
 *
 * Example:
 *   Input:  a = 3, b = 3, c = 3
 *   Output: equal
 *
 *   Input:  a = 3, b = 4, c = 3
 *   Output: not equal
 */


public class Exercise3_1 : IExercise
{
    public void Run(string[] args)
    {
        var valOne = int.Parse(args[0]);
        var valTwo = int.Parse(args[1]);
        var valThree = int.Parse(args[2]);

        if (valOne != valTwo || valTwo != valThree)
        {
            System.Console.WriteLine("Not equal");
            return;
        }
        System.Console.WriteLine("Equal");
        return;
    }
}
