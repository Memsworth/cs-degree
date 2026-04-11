using System;

namespace CSFundamentals.Sedgewick.Chapter1.Section2;

/*
 * Mercator Projection
 *
 * Write a program that implements the Mercator projection, a conformal (angle-preserving)
 * map projection that converts geographic coordinates (latitude and longitude) into
 * rectangular coordinates (x, y). This projection is commonly used in nautical charts
 * and web-based maps.
 *
 * The program should accept three double command-line arguments:
 *   - λ0: the reference longitude (center of the map)
 *   - φ: the latitude of the point (in radians)
 *   - λ: the longitude of the point (in radians)
 *
 * The projection is defined by the following formulas:
 *
 *   x = λ - λ0
 *   y = 0.5 * ln((1 + sin(φ)) / (1 - sin(φ)))
 *
 * Where:
 *   - φ is the latitude (in radians)
 *   - λ is the longitude (in radians)
 *   - λ0 is the central meridian (longitude at the center of the map)
 *   - x and y are the projected Cartesian coordinates
 *
 * Example:
 *   Input: 0 1.13446 0.52360
 *   Output: x = 0.52360, y = 1.47222
 *
 *   (Note: Input values must be provided in radians)
 */

public class Exercise2_31
{
    public Exercise2_31() { }

    public void Run(string[] args)
    {
        var initialLongitude = double.Parse(args[0]);
        var longitude = double.Parse(args[1]);
        var latitude = double.Parse(args[2]);

        var pointX = longitude - initialLongitude;
        var pointY = 0.5 * Math.Log((1 + Math.Sin(latitude)) / (1 - Math.Sin(latitude)));

        System.Console.WriteLine($"X = {pointX:F3}  Y = {pointY:F3}");
    }
}
