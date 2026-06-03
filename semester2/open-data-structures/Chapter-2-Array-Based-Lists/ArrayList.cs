#!


System.Console.WriteLine("Hello");


var arrayTest = new CustomArrayList<int>(5);

arrayTest.Add(0, 1);
arrayTest.Add(1, 5);
arrayTest.Add(2, 5);
arrayTest.DisplayArray();

arrayTest.Remove(2);
arrayTest.DisplayArray();
arrayTest.Remove(4);
//arrayTest.DisplayArray();

public class CustomArrayList<T>
{
    public T[] CustomArray { get; set; }
    public int ElementCount { get; set; }

    public CustomArrayList(int n)
    {
        CustomArray = new T[n];
        ElementCount = 0;
    }

    public T? Get(int i) => CustomArray[i];

    public T? Set(int i, T valueToSet)
    {
        var y = CustomArray[i];
        CustomArray[i] = valueToSet;
        return y;
    }

    public void Add(int i, T valueToAdd)
    {

        if (ElementCount + 1 > CustomArray.Length)
            Resize();

        for (int index = ElementCount; index > i; index--)
            CustomArray[index] = CustomArray[index - 1];

        CustomArray[i] = valueToAdd;
        ElementCount++;
    }

    public void Remove(int i)
    {
        if (i >= ElementCount)
            throw new IndexOutOfRangeException();

        for (int index = i; index < ElementCount; index++)
            CustomArray[index] = CustomArray[index + 1];

        ElementCount--;

        if (CustomArray.Length > 3 * ElementCount)
            Resize();
    }

    private void Resize()
    {
        var ArrayB = new T[Math.Max(2 * ElementCount, 1)];
        for (int i = 0; i < CustomArray.Length; i++)
            ArrayB[i] = CustomArray[i];

        CustomArray = ArrayB;
    }

    public void DisplayArray()
    {
        for (int i = 0; i < ElementCount; i++)
        {
            System.Console.WriteLine($"{CustomArray[i]}");
        }
    }
}