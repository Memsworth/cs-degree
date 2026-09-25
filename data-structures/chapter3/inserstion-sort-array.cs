#!

public class InsertionSortArray
{
    public void SortArray(int[] testArray)
    {
        for (int i = 1; i < testArray.Length; i++)
        {
            var currentItem = testArray[i];
            var j = i;

            while (j > 0 && testArray[j] > currentItem)
            {
                testArray[j] = testArray[j - 1];
                j--;
            }

            testArray[j] = currentItem;
        }
    }
}