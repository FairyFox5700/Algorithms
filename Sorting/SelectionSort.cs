using System;

namespace Sorting
{
    public class SelectionSort:BaseSortAlgorithm
    {
        public SelectionSort(int capacity=10):base(capacity)
        {
            
        }
        public override  void Sort(IComparable[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                //for loop only to find min element index (N^2 comparison)
                var minIndex = i;
                for (int j = i+1 ; j < array.Length; j++)
                {
                    if (isLess(array[j], array[i]))
                        minIndex= j;
                     
                }
                //N swaps only 
                swap(array ,i, minIndex);
            }
        }
        public static void Test()
        {
            var selectionSort = new SelectionSort();
            printArray(selectionSort.testArray);
            selectionSort.Sort(selectionSort.testArray);
            Console.WriteLine("Sorted array: ");
            printArray(selectionSort.testArray);
            Console.WriteLine("Is array sorted: ");
            Console.Write(isSorted(selectionSort.testArray));
        }
    }

    
}