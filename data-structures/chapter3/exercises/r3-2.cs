#!


var rand = new Random();

var myTestArray = Enumerable.Range(0, 10).Select(_ => rand.Next(0, 100)).ToArray();
var count = myTestArray.Length;
foreach (var item in myTestArray)
    System.Console.Write($"{item}, ");


//memory intensive. Imagine if we had to deal with 20k or even 100k inputs?
//naive way
while (count > 0)
{
    System.Console.WriteLine();
    var randIndex = rand.Next(0, count);
    System.Console.WriteLine($"removing {myTestArray[randIndex]}");
    for (int i = randIndex; i < count - 1; i++)
        myTestArray[i] = myTestArray[i + 1];

    count--;

    for (int i = 0; i < count; i++)
        System.Console.Write($"{myTestArray[i]}, ");
}
if (count == 0)
    System.Console.WriteLine("empty");
