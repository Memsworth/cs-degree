namespace CSFundamentals.Sedgewick.Chapter1.Section4;

internal class Exercise4_23 : IExercise
{
    public void Run(string[] args)
    {
        var rand = new Random();
        var array1 = new int[100];

        for(var i = 0; i < array1.Length; i++)
            array1[i] = rand.Next(10);


        var startIndex = -1;
        var endIndex = -1;
        var sequenceLen = 0;
        var index = 1;

        while (index < array1.Length - 1)
        {
            var isPeak = array1[index] > array1 [index + 1] && array1[index] > array1[index - 1];

            if(!isPeak)
            {
                index++;
                continue;
            }

            var left = index;
            while (left > 0 && array1[left] > array1 [left - 1])
                left--;

            var right = index;
            while (right < array1.Length - 1 && array1[right] > array1[right + 1])
                right++;

            var len = right - left + 1;

            if(len > sequenceLen)
            {
                sequenceLen = len;
                startIndex = left; 
                endIndex = right;
            }

            index = right;
        }

        if(sequenceLen > 0)
        {
            Console.WriteLine($"Start at: {startIndex}\t End at {endIndex}");
            for(var i = startIndex; i < endIndex; i++)
                Console.Write($"{array1[i]}   ");
            return;
        }

        Console.WriteLine("No sequence found");
    }
}