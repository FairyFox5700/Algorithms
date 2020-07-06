using System;
using Sorting.SimpleSort;

namespace Sorting.QuickSort
{
    //improvement for quick sort 
    //when duplicate Keys occurs
    //NlogN in worst case
    //best works if only constant amount of distinct keys
    //linear then
    //The goal of 3-way partitioning is to speed up quicksort
    //in the presence of duplicate key
    public class DijkstraThreeWayPartition:BaseSortAlgorithm
    {
        public override void Sort(IComparable[] array)
        {
            //random sort for average case productivity
            new Shuffling().Shuffle(array);
            sort(array,0, array.Length-1);
        }
        
        /*
        ・Let v be partitioning item a[lo].
         ・Scan i from left to right.
        – (a[i] < v): exchange a[lt] with a[i]; increment both lt and i
        – (a[i] > v): exchange a[gt] with a[i]; decrement gt
        – (a[i] == v): increment i
        */

        private void sort(IComparable[]array, int low,int high)
        {
            if (high <= low) return;
            var lessThan = low;
            var  v = array[low];
            var greaterThan = high;
            var i = low;
            while (i<=greaterThan)//scan from left to right
            {
                var compare = array[i].CompareTo(v);
                if( compare<0)//array[i] is less than v
                //than increase i and lessThan pointer
                   swap(array,lessThan++,i++);
                else if (compare > 0) //array[i] is greater than v
                    //than decrease greaterThan pointer and exchange with i
                    swap(array, greaterThan--, i);
                //if array[i]  == v
                //than increase i pointer but not lessThan pointer
                else i++;

            }
            //apply sorting only for elements with no equal keys
            sort(array,low,lessThan-1);
            sort(array,greaterThan+1,high);
        }
        
        public static void Test()
        {
            var dijkstraThreeWayPartition = new DijkstraThreeWayPartition();
            printArray(dijkstraThreeWayPartition.testArray);
            dijkstraThreeWayPartition.Sort(dijkstraThreeWayPartition.testArray);
            Console.WriteLine("Sorted array: ");
            printArray(dijkstraThreeWayPartition.testArray);
        }
    }
}