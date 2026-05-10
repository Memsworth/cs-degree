long y1 = 0;
long y2 = 0;


Console.WriteLine(" n\t y1\t y2\t Comparison");
Console.WriteLine("-----------------------------------");

for (int i = 0; i <= 100; i += 10)
{
    y1 = 100 * i + 10;
    y2 = 5 * i * i + 2;

    string comparison;

    if (y1 > y2)
        comparison = "y1 > y2";
    else if (y1 < y2)
        comparison = "y1 < y2";
    else
        comparison = "y1 = y2";

    Console.WriteLine($"{i}\t {y1}\t {y2}\t {comparison}");

}