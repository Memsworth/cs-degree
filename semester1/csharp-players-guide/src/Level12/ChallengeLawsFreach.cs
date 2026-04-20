using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPlayersGuide.Level12
{
    internal class ChallengeLawsFreach : IExercise
    {
        public void Run()
        {
            var array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };
            var currentSmallest = int.MaxValue;
            foreach (var item in array)
            {
                if(item < currentSmallest)
                    currentSmallest = item;
            }
            Console.WriteLine(currentSmallest);


            var total = 0;
            foreach (var item in array)
                total += item;
            var average = (float)total / array.Length;
            Console.WriteLine(average);
        }
    }
}
