using System;

namespace CSFundamentals.Sedgewick.Chapter1.Section2;

/*
 * Day of the Week
 *
 * Write a program that takes a date as input and prints the day of the week
 * that date falls on. Your program should accept three int command-line
 * arguments: m (month), d (day), and y (year). For m, use 1 for January, 
 * 2 for February, and so forth. For output, print 0 for Sunday, 1 for Monday, 
 * 2 for Tuesday, and so on.
 *
 * The program should use the following formulas for the Gregorian calendar:
 * 
 *   Adjust January and February to be the 13th and 14th months of the previous year.
 *   Use Zeller's Congruence formula:
 *   
 *   h = (q + ((13 * (m + 1)) / 5) + K + (K / 4) + (J / 4) + 5 * J) % 7
 *   
 *   Where:
 *     q = day of the month
 *     m = month (adjusted for January and February)
 *     K = year of the century (y % 100)
 *     J = zero-based century (y / 100)
 *     h = day of the week (0 = Saturday, 1 = Sunday, 2 = Monday, etc.)
 *   
 * Example:
 *   Input: 10 21 2025
 *   Output: 2 (Tuesday)
 *
 *   Input: 12 25 2024
 *   Output: 2 (Wednesday)
 *
 *   Input: 7 4 1776
 *   Output: 6 (Thursday)
 */


public class Exercise2_29
{
    public Exercise2_29() { }

    public void Run(string[] args)
    {
        var date = int.Parse(args[0]);
        var month = int.Parse(args[1]);
        var year = int.Parse(args[2]);

        if (month < 1 || month > 12)
        {
            Console.WriteLine("Bad month input");
            return;
        }

        if (date < 1 || date > 31)
        {
            Console.WriteLine("Bad date input");
            return;
        }

        if (month <= 2)
        {
            month += 12;
            year -= 1;
        }

        var q = date;  
        var m = month; 
        var K = year % 100;  
        var J = year / 100;  

        // Zeller's Congruence formula
        var h = (q + (13 * (m + 1)) / 5 + K + K / 4 + J / 4 + 5 * J) % 7;

        var daysOfWeek = new string[] { "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
        Console.WriteLine(daysOfWeek[h]);

    }
}
