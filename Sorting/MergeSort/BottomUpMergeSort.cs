using System;

namespace Sorting.MergeSort
{
    public class BottomUpMergeSort:BaseSortAlgorithm
    {
        public override void Sort(IComparable[] array)
        {
            var length = array.Length;
            var auxilaryArray = new IComparable[length];
            for (int size = 1; size <length; size=size+size)
            {
                for (int low = 0; low < length-size; low+=size)
                {
                    var mid = low + size - 1;
                    merge(array,auxilaryArray,low,mid, Math.Min(low+size+size-1, length-1));
                }
            }
        }
        
        private static void merge(IComparable[] array, IComparable[] auxiularyArray,
            int low, int mid, int high)
        {
            for (int k = low; k <= high; k++)
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
                    array[k] =auxiularyArray[i++];
                else if (isLess(auxiularyArray[j], auxiularyArray[i]))//insert to array lower element from two
                    array[k] =auxiularyArray[j++];
                else
                    array[k] = auxiularyArray[i++];
            }
        }
    }
    
    
}