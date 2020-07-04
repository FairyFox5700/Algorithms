using System;

namespace Sorting
{
    public class ShellSort:BaseSortAlgorithm
    {
        //worst case is N^3/2 operations
        public override void Sort(IComparable[] array)
        {
            var n = array.Length;
            var h = 1;//1 sorted
            while (h<n/3)
            {
                h= 3*h + 1;//increment step: 1,4,7,10....
            }

            while (h>=1)
            {
                for (int i = h; i < n; i++)//start from h=4
                {
                    for (int j = i; j >=h; j=j-h)//check elements with h step
                    {
                        if (isLess(array[j], array[j - h]))
                        {
                            swap(array, j, j - h);
                        }
                        else break;
                    }
                    
                }

                h = h / 3;

            }
        }
        public static void Test()
        {
            var selectionSort = new ShellSort();
            printArray(selectionSort.testArray);
            selectionSort.Sort(selectionSort.testArray);
            Console.WriteLine("Sorted array: ");
            printArray(selectionSort.testArray);
            Console.WriteLine("Is array sorted: ");
            Console.Write(isSorted(selectionSort.testArray));
        }
    }
}