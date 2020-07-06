using System;
using Sorting.SimpleSort;

namespace Sorting.QuickSort
{
    //linear in average case
    //but in worst approximately 1/2 n^2 comparison 
    //so use shuffle before algorithm start
    public class SelectionAlgorithm : BaseSortAlgorithm
    {
        /*・Entry a[j] is in place.
        ・No larger entry to the left of j.
        ・No smaller entry to the right of j.*/
        
        //Repeat in one subarray,depending on j;
        //finished when j equals k.
        public static IComparable select(IComparable[] array, int k)
        {
            new Shuffling().Shuffle(array);
            int low = 0;
            int high = array.Length - 1;
            
            while (high>low)
            {
                //get partition element 
                var j = partition(array, low, high);
                if (k > j)
                    //means that k-th element is in the right site
                    //decrease search to [j+1;hi]
                    low = j + 1;
                else if (k < j)
                    //means that k-th element is in the right site
                    //decrease search to [low;j-1]
                    high = j - 1;
                else return array[k];//founded element
            }
            return array[k];

        }

        private static int partition(IComparable[] array, int low, int high)
        {
            //two low and high pointers
            int i = low;
            int j = high + 1;
            //in main loop
            while (true)
            {
                //while elements in array to the left side from low is less continue to increment i pointer
                //else break
                while (isLess(array[++i], array[low]))
                {
                    //end of array
                    if (i == high) break;
                }

                //while elements in array to the right side from low is more continue to decrement j pointer
                //else break
                while (isLess(array[low], array[--j]))
                {
                    //end of array
                    if (j == low) break;
                }

                //if i and j pointers crossed than partition done
                if (i >= j) break;
                //if ! array[i++]..<=array[low]<= array[--j...]
                swap(array, i, j);

            }

            swap(array, low, j);
            return j;
        }
    

    public override void Sort(IComparable[] array)
        {
            throw new NotImplementedException();
        }
    }
}