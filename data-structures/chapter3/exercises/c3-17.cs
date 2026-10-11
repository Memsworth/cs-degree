#!

var rand = new Random();
int n = rand.Next(2, 10);
var myArray = Enumerable.Range(1, n - 1).ToArray();

int duplicate = rand.Next(1, n);
myArray = myArray.Append(duplicate).ToArray();
myArray = myArray.OrderBy(_ => rand.Next()).ToArray();


var exer = new Exercise();
var total = exer.GetSum(myArray);
var mathVal = (myArray.Length * (myArray.Length - 1)) / 2;
System.Console.WriteLine($"{total - mathVal}");
public class Exercise()
{
    public int GetSum(int[] collection)
    {
        var total = 0;
        foreach (var item in collection)
            total += item;

        return total;
    }
}