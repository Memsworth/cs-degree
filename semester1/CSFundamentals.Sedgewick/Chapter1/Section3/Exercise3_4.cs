using System;

namespace CSFundamentals.Sedgewick.Chapter1.Section3;

/*
 * Strictly Between 0 and 1 Checker
 *
 * Write a program (or code fragment) that takes two double variables, x and y,
 * and prints "true" if both x and y are strictly greater than 0 and strictly less than 1,
 * and "false" otherwise.
 *
 * Your program should:
 *   - Accept two double variables: x and y.
 *   - Check whether 0 < x < 1 and 0 < y < 1.
 *   - Print "true" if both conditions are satisfied, otherwise print "false".
 *
 * Examples:
 *   Input:  x = 0.5, y = 0.8
 *   Output: true
 *
 *   Input:  x = 0, y = 0.5
 *   Output: false
 *
 *   Input:  x = 1.2, y = 0.9
 *   Output: false
 */


public class Exercise3_4 : IExercise
{
    public void Run(string[] args)
    {
        var valOne = double.Parse(args[0]);
        var valTwo = double.Parse(args[1]);
        bool result = ((valOne > 0.0 && valOne < 1.0) && (valTwo > 0.0 && valTwo < 1.0));

        System.Console.WriteLine($"{result}");
    }
}
