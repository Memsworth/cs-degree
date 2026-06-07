#!

public class ArrayQueue<T>
{
    public T[] CustomArray { get; set; }
    public int ElementCount { get; set; }
    public int CustomFirstIndex { get; set; }

    public ArrayQueue(int len)
    {
        CustomArray = new T[len];
        ElementCount = 0;
        CustomFirstIndex = 0;
    }

    public void Add(T valueToAdd)
    {
        if (ElementCount + 1 >= CustomArray.Length)
            Resize();

        CustomArray[(ElementCount + CustomFirstIndex) % CustomArray.Length]
            = valueToAdd;

        ElementCount++;
    }

    public T Remove()
    {
        if (ElementCount == 0)
            throw new IndexOutOfRangeException();

        var element = CustomArray[CustomFirstIndex];
        CustomFirstIndex = (CustomFirstIndex + 1) % CustomArray.Length;

        ElementCount--;

        if (CustomArray.Length >= (3 * ElementCount))
            Resize();
        return element;
    }

    private void Resize()
    {
        var newArray = new T[Math.Max(1, ElementCount * 2)];

        for (int i = 0; i < ElementCount; i++)
        {
            newArray[i] =
                CustomArray[(i + CustomFirstIndex) % CustomArray.Length];
        }

        CustomArray = newArray;
        CustomFirstIndex = 0;
    }
}