using System;

namespace CSFundamentals.Sedgewick.Chapter1.Section2;

/*
 * Polar Coordinates Converter
 *
 * Write a program that converts Cartesian coordinates (x, y) to polar coordinates (r, θ).
 * Your program should accept two double command-line arguments x and y,
 * and print the corresponding polar coordinates:
 *
 *   - r = √(x² + y²)
 *   - θ = atan2(y, x)  (in radians, between -π and π)
 *
 * Use Math.Atan2(y, x) to compute θ, and Math.Sqrt() to compute r.
 *
 * Example:
 *   Input: x = 3, y = 4
 *   Output:
 *     r = 5
 *     θ = 0.9272952180016122
 *
 *   Input: x = -1, y = 1
 *   Output:
 *     r = 1.4142135623730951
 *     θ = 2.356194490192345
 */


public class Exercise2_26
{
    public Exercise2_26() {}
    public void Run(string[] args)
    {
        var valueOne = double.Parse(args[0]);
        var valueTwo = double.Parse(args[1]);

        var radius = Math.Sqrt(Math.Pow(valueTwo, 2) + Math.Pow(valueOne, 2));
        var theta = Math.Atan(valueTwo / valueOne);

        System.Console.WriteLine($"Theta: {theta:F3} ");
        System.Console.WriteLine($"radius: {radius:F3}");
    }
}
