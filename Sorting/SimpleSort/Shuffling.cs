using System;

namespace Sorting.SimpleSort
{
    public class Shuffling
    {
        public void Shuffle(IComparable[] array)
        {
            int len = array.Length;
            for (int i = 0; i < len; i++)
            {
                var r = new Random().Next(0,i);//can be also i, n-1 but no 0 to n-1
                swap(array,r,i);
            }
        }

        protected static void swap(object[] array, int firstIndex, int seconIndex)
        {
            var temp = array[firstIndex];
            array[firstIndex] = array[seconIndex];
            array[seconIndex] = temp;
        }
        

        
        public static void Test()
        {
            var selectionSort = new Shuffling();
            var array = new IComparable [] {1, 2, 4, "k", 4, 3,8,"P",3,9,1,0};
            selectionSort.Shuffle(array);
            foreach (var element in array )
            {
                Console.Write(element.ToString()+  " ");
            }
            Console.WriteLine();
           
        }
    }
}