
Random rand = new Random();

int n = rand.Next(6, 16); // Array size: 6 to 15
int max = n - 5;

int[] B = new int[n];

// Generate each value at least once
for (int i = 0; i < max; i++)
    B[i] = i + 1;

// Add five extra occurrences
for (int i = max; i < n; i++)
    B[i] = rand.Next(1, max + 1);

// Shuffle the array
B = B.OrderBy(x => rand.Next()).ToArray();

Console.WriteLine($"n = {n}");
Console.WriteLine("B = [" + string.Join(", ", B) + "]");


var repeated = new int[max + 1];

for (int i = 0; i < B.Length; i++)
    repeated[B[i]] += 1;


var toDisplay = "[ ";
for (int i = 0; i < repeated.Length; i++)
{
    if (repeated[i] > 1)
        toDisplay += $"{i}: {repeated[i]}, ";
}
toDisplay += "]";

System.Console.WriteLine(toDisplay);