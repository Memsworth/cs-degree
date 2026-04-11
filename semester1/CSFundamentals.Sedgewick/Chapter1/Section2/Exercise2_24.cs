using System;

namespace CSFundamentals.Sedgewick.Chapter1.Section2;

/*
 * Continuously Compounded Interest
 *
 * Write a program that calculates and prints the amount of money you would have
 * after t years if you invested P dollars at an annual interest rate r,
 * compounded continuously.
 *
 * Formula:
 *   A = P * e^(r * t)
 *
 * Where:
 *   - P is the principal amount (initial investment)
 *   - r is the annual interest rate (as a decimal, e.g., 5% = 0.05)
 *   - t is the time in years
 *   - e is Euler's number (approx. 2.71828)
 *
 * Example:
 *   Input: P = 1000, r = 0.05, t = 10
 *   Output: 1648.721270700128
 */

public class Exercise2_24
{
    public void Run()
    {
        System.Console.WriteLine("Principle amount: ");
        var principal = decimal.Parse(Console.ReadLine()!);
        System.Console.WriteLine("Enter annual interest: ");
        var interest = double.Parse(Console.ReadLine()!);
        System.Console.WriteLine("Enter the years of investment: ");
        var time = int.Parse(Console.ReadLine()!);
        var appendToEuler = (interest/100) * time;
        var RoI = principal * (decimal)Math.Pow(Math.E, appendToEuler);

        System.Console.WriteLine($"Investment: {RoI}");
    }
}
