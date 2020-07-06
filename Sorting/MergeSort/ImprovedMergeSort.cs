using System;
using Sorting.SimpleSort;

namespace Sorting.MergeSort
{
    public class ImprovedMergeSort:BaseSortAlgorithm
    {
        private const int CUTOFF=7;//cutoff to insertion sort for ≈ 7 items.


        private void mergeSort(IComparable[] array, IComparable[] auxilaryArray,  int low,int high)
        {
            if (high <= low + CUTOFF - 1)
            {
                new InsertionSort().Sort(array,low,high);
                return;
            }
            int mid = low + (high - low) / 2;
            mergeSort(array,auxilaryArray,low, mid);
            mergeSort(array,auxilaryArray,mid+1, high);//split array to 2 subarray
            if (!isLess(array[mid + 1], array[mid])) return;//Stop if already sorted.
            //Is biggest item in first half ≤ smallest item in second half?
            //Helps for partially-ordered arrays
            merge(array,auxilaryArray,low,mid,high);
            
        }
        private static void merge(IComparable[] array, IComparable[] auxiularyArray,
            int low, int mid, int high)
        {
            for (int k = low; k <= high; k++)
            {
               auxiularyArray[k] = array[k];
            }
            //Eliminate the copy to the auxiliary array. S
            //Save time (but not space)
            //by switching the role of the input and auxiliary array in each recursive call.

            int i = low;
            int j = mid+1;
            for (int k = low; k <=high; k++)
            {
                if (i > mid)
                    array[k] = auxiularyArray[j++];//check if i and j are not exhausted
                else if (j>high)
                    array[k] =auxiularyArray[i++];
                else if (isLess(auxiularyArray[j], auxiularyArray[i]))//insert to array lower element from two
                    array[k] =auxiularyArray[j++];
                else
                    array[k] = auxiularyArray[i++];
            }
        }

        public override void Sort(IComparable[] array)
        {
            var auxilaryArray = new IComparable [array.Length];
            mergeSort(array, auxilaryArray,0 , array.Length-1);
        }
        
        public static void Test()
        {
            var mergeSort = new ImprovedMergeSort();
            printArray(mergeSort.testArray);
            mergeSort.Sort(mergeSort.testArray);
            Console.WriteLine("Sorted array: ");
            printArray(mergeSort.testArray);
        }
    }
}