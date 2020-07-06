using System;

namespace Sorting.MergeSort
{
    /*Divide array into two halves.
    ・Recursively sort each half.
    ・Merge two halves.*/
    
    //N*logN comparison and 6*N*lgN
    //N extra space 
    public class MergeSort:BaseSortAlgorithm
    {

        private static void merge(IComparable[] array, IComparable[] auxiularyArray,
            int low, int mid, int high)
        {
            //copy each element to axillary array
            for (int k = low;k <= high; k++)
            {
                auxiularyArray[k] = array[k];
            }

            int i = low;
            int j = mid+1;
            for (int k = low; k <=high; k++)
            {
                if (i > mid)
                    array[k] = auxiularyArray[j++];//check if i and j are not exhausted
                else if (j>high)
                    array[k] = auxiularyArray[i++];
                else if (isLess(auxiularyArray[j], auxiularyArray[i]))//insert to array lower element from two
                    array[k] = auxiularyArray[j++];
                else
                    array[k] = auxiularyArray[i++];
            }
        }

        public override void Sort(IComparable[] array)
        {
            var auxilaryArray = new IComparable [array.Length];
            mergeSort(array, auxilaryArray,0 , array.Length-1);
        }

        private void mergeSort(IComparable[] array, IComparable[] auxilaryArray,  int low,int high)
        {
            if (high <= low) return;
            int split = low + (high - low) / 2;
            mergeSort(array,auxilaryArray,low, split);
            mergeSort(array,auxilaryArray,split+1, high);//split array to 2 subarray
            merge(array,auxilaryArray,low,split,high);
            
        }
        public static void Test()
        {
            var mergeSort = new MergeSort();
            printArray(mergeSort.testArray);
            mergeSort.Sort(mergeSort.testArray);
            Console.WriteLine("Sorted array: ");
            printArray(mergeSort.testArray);
        }
        
    }
}