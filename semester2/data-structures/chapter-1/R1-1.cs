System.Console.WriteLine("Test");

InputAllBaseTypesExample.InputAllBaseTypes();

public class InputAllBaseTypesExample
{
    public static void InputAllBaseTypes()
    {
        Console.Write("byte: ");
        var b = byte.Parse(Console.ReadLine());

        Console.Write("short: ");
        var s = short.Parse(Console.ReadLine());

        Console.Write("int: ");
        var i = int.Parse(Console.ReadLine());

        Console.Write("long: ");
        var l = long.Parse(Console.ReadLine());

        Console.Write("float: ");
        var f = float.Parse(Console.ReadLine());

        Console.Write("double: ");
        var d = double.Parse(Console.ReadLine());

        Console.Write("decimal: ");
        var m = decimal.Parse(Console.ReadLine());

        Console.Write("char: ");
        var c = char.Parse(Console.ReadLine());

        Console.Write("bool: ");
        var bo = bool.Parse(Console.ReadLine());

        Console.WriteLine($"\n{b} {s} {i} {l} {f} {d} {m} {c} {bo}");
    }
}