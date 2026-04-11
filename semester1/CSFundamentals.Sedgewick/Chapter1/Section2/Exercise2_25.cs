using System;

namespace CSFundamentals.Sedgewick.Chapter1.Section2;

/*
 * Wind Chill Calculator
 *
 * Given the temperature T (in degrees Fahrenheit) and the wind speed v (in miles per hour),
 * the National Weather Service defines the effective temperature (wind chill) as:
 *
 *   w = 35.74 + 0.6215 * T + (0.4275 * T - 35.75) * v^0.16
 *
 * Write a program that takes two double command-line arguments: temperature and velocity,
 * and prints the calculated wind chill.
 *
 * Note:
 *   - Use Math.Pow(v, 0.16) to compute v^0.16.
 *   - You may assume:
 *       * The absolute value of T is less than or equal to 50.
 *       * The wind speed v is between 3 and 120 (inclusive).
 *
 * Example:
 *   Input: T = 32, v = 10
 *   Output: 23.478084995590002
 */

public class Exercise2_25
{
    public Exercise2_25() { }
    
    public void Run(string[] args) 
    {
        var temperature = double.Parse(args[0]);
        var velocity = double.Parse(args[1]);

        if (Math.Abs(temperature) > 50 || (velocity > 120 && velocity < 3))
        {
            System.Console.WriteLine("Error in valid values");
            return;
        }

        var windChill = 35.74 + (0.6215 * temperature) + (((0.4275 * temperature) - 35.75) * Math.Pow(velocity, 0.16));
        System.Console.WriteLine(windChill);
    }
}
