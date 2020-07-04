using System;

namespace Sorting
{
    public class InsertionSort:BaseSortAlgorithm
    {
        
        //in random array near 1/4*N^2 comparison and exchanges
        //if it is sorted (n-1) comperison and 0 exchanges
        //in the worst case( reverse sorted) N^2/2 comparison and exchanges 
        public override void Sort(IComparable[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j >0 ; j--)
                {
                    if(isLess(array[j], array[j-1]))
                        swap(array,j,j-1);
                    else break;
                }
            }
        }
        public static void Test()
        {
            var selectionSort = new InsertionSort();
            printArray(selectionSort.testArray);
            selectionSort.Sort(selectionSort.testArray);
            Console.WriteLine("Sorted array: ");
            printArray(selectionSort.testArray);
            Console.WriteLine("Is array sorted: ");
            Console.Write(isSorted(selectionSort.testArray));
        }
    }
}