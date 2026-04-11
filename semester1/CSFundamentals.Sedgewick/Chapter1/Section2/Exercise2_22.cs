using System;

namespace CSFundamentals.Sedgewick.Chapter1.Section2;


/*
 * Write a program that takes three double command-line arguments x0, v0, and t
 * and prints the value of: x0 + v0 * t - (g * t^2) / 2
 * 
 * Note:
 *   - g is the gravitational constant: 9.80665 (in meters per second squared).
 *   - x0 is the initial position (in meters).
 *   - v0 is the initial velocity (in meters per second).
 *   - t is the time (in seconds).
 *   - The formula computes the vertical displacement of an object thrown straight up.
 * 
 * Formula:
 *   displacement = x0 + v0 * t - (g * t^2) / 2
 * 
 * Example:
 *   Input: 0 10 1
 *   Output: 5.096675
 *
 *   Input: 100 0 2
 *   Output: 80.3867
 */
public class Exercise2_22
{
    public double ConstantG { get; } = 9.80665;
    public Exercise2_22() { }
    public void Run(string[] args)
    {
        var x0 = double.Parse(args[0]);
        var v0 = double.Parse(args[1]);
        var t = double.Parse(args[2]);

        var formulaValueResult = x0 + (v0 * t) - ((ConstantG * Math.Pow(t, 2)) / 2);

        System.Console.WriteLine(formulaValueResult);
    }


}
