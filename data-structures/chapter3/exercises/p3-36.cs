#!

public static class ArrayOptions
{
    public static int[,]? Multi(int[,] arrayOne, int[,] arrayTwo)
    {
        if (arrayOne.GetLength(1) != arrayTwo.GetLength(0))
            return null;


        var resultMatrix = new int[arrayOne.GetLength(0), arrayTwo.GetLength(1)];

        for (int i = 0; i < resultMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < resultMatrix.GetLength(1); j++)
            {
                for (int k = 0; k < arrayOne.GetLength(1); k++)
                    resultMatrix[i, j] += arrayOne[i, k] * arrayTwo[k, j];
            }
        }
        return resultMatrix;
    }


    public static int[,]? Add(int[,] arrayOne, int[,] arrayTwo)
    {
        if (arrayOne.GetLength(0) != arrayTwo.GetLength(0) ||
            arrayOne.GetLength(1) != arrayTwo.GetLength(1))
            return null;

        var resultMatrix = new int[
            arrayOne.GetLength(0),
            arrayOne.GetLength(1)];

        for (int i = 0; i < resultMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < resultMatrix.GetLength(1); j++)
                resultMatrix[i, j] = arrayOne[i, j] + arrayTwo[i, j];
        }
        return resultMatrix;
    }
}