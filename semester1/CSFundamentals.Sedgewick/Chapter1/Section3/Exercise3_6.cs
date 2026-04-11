using System;

namespace CSFundamentals.Sedgewick.Chapter1.Section3;

/*
 * Wind Chill Calculator with Input Validation
 *
 * Improve your solution to exercise 1.2.25 by:
 *   - Adding code to check that the values of the command-line arguments
 *     fall within the ranges of validity of the formula:
 *       * Temperature T: -50 <= T <= 50
 *       * Wind speed v: 3 <= v <= 120
 *   - Adding code to print an error message if either value is out of range.
 */


public class Exercise3_6 : IExercise
{
    public void Run(string[] args) 
    {
        var temperature = double.Parse(args[0]);
        var velocity = double.Parse(args[1]);

        if (Math.Abs(temperature) > 50.0 || (velocity > 120.0 && velocity < 3.0))
        {
            System.Console.WriteLine("Error in valid values");
            return;
        }

        var windChill = 35.74 + (0.6215 * temperature) + (((0.4275 * temperature) - 35.75) * Math.Pow(velocity, 0.16));
        System.Console.WriteLine(windChill);
    }
}
