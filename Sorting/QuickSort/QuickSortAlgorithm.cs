using System;
using System.Resources;
using Sorting.SimpleSort;

namespace Sorting.QuickSort
{
    
    public class QuickSortAlgorithm:BaseSortAlgorithm
    {
        private const int CUTOFF =7;
        private int partition(IComparable[] array, int low, int high)
        {
            //two low and high pointers
            int i = low;
            int j = high + 1;
            //in main loop
            while (true)
            {
                //while elements in array to the left side from low is less continue to increment i pointer
                //else break
                while (isLess(array[++i],array[low]))
                {
                    //end of array
                    if( i==high) break;
                }
                //while elements in array to the right side from low is more continue to decrement j pointer
                //else break
                while (isLess(array[low], array[--j]))
                {
                    //end of array
                    if(j==low) break;
                }
                //if i and j pointers crossed than partition done
                if(i>=j) break;
                //if ! array[i++]..<=array[low]<= array[--j...]
                swap(array,i,j);

            }
            swap(array,low,j);
            return j;
        }
        
        
        public override void Sort(IComparable[] array)
        {
            
            
            //random sort for average case productivity
            new Shuffling().Shuffle(array);
          
            sort(array,0, array.Length-1);
        }

        private void sort(IComparable[]array, int low,int high)
        {
            //as improvement use insertion sort for small subarrays
            //else use medianOf3 (low, medium and high )
            /*if (high <= low + CUTOFF - 1)
            {
                new InsertionSort().Sort(array,low,high);
                return;
            }*/
            //condition to avoid stack overflow
            if (high <= low) return;
            //element after partition array to 2 subarray
            //than recursively partition array to yhe left of j 
            //than to the right of j
            var j = partition(array, low,high); 
            sort(array,low,j-1);
            sort(array,j+1,high);
        }
        
        public static void Test()
        {
            var quickSort = new QuickSortAlgorithm();
            printArray(quickSort.testArray);
            quickSort.Sort(quickSort.testArray);
            Console.WriteLine("Sorted array: ");
            printArray(quickSort.testArray);
        }
    }
}