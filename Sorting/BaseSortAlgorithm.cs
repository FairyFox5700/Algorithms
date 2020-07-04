using System;

namespace Sorting
{
    public  abstract  class BaseSortAlgorithm:ISort
    {
        protected IComparable[] testArray;

        public BaseSortAlgorithm(int capcity=10)
        {
            this.testArray = new IComparable[capcity];
            for (int j = 0; j < testArray.Length; j++)
            {
                testArray[j] = new Random().Next(0, 20);
            }
        }
        protected static bool isLess(IComparable firstElement, IComparable secondElement)
        {
            return firstElement.CompareTo(secondElement) < 0;
        }

        protected static void swap(IComparable[] array, int firstIndex, int seconIndex)
        {
            var temp = array[firstIndex];
            array[firstIndex] = array[seconIndex];
            array[seconIndex] = temp;
        }

        protected static bool isSorted(IComparable[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if( !isLess(array[i], array[i-1]) ||array[i]==array[i-1]) return true;
            }

            return false;
        }
        
        protected static void printArray(IComparable[] testArray)
        {
            foreach (var element in testArray)
            {
                Console.Write(element.ToString()+  " ");
            }
            Console.WriteLine();
        }

        public abstract  void Sort(IComparable[] array);

    }
}