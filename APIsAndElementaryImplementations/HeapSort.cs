using System;
using System.Runtime.InteropServices.ComTypes;

namespace APIsAndElementaryImplementations
{
  
    public class HeapSort:BaseIterations, ISortable
    {
        public HeapSort(int capacity) : base(capacity)
        {
        }
        public void Sort(IComparable[] array)
        {
            //number/ 2 because only leafs left in heap
            for (int k = _elementsNumber / 2; k >= 1; k--)
            {
                sink(array,k,_elementsNumber);
            }

            while (_elementsNumber>1)
            {
                swap(array,1,_elementsNumber--);
                sink(array,1,_elementsNumber);
            }
        }

        private void sink(IComparable[] array, int currentPosition, int totalNumber)
        {
            //start with children
            while (2*currentPosition<=totalNumber)
            {
                //exchanging the node with the larger of its two children
                var children = 2*currentPosition;
                if (children<totalNumber && isLess(children, children + 1))
                {
                    children++;//move to next child
                }
                if(!isLess(currentPosition,children)) break;//no ordering needed
                //exchange elements
                swap(array,currentPosition,children);
                //start with new position
                currentPosition = children;//recursively for grand childrand

            }
        }

        public void Insert(int element)
        {
            _priorityQueue[++_elementsNumber] = element;//start from 1
        }

        public static void Test()
        {
            var  capacity = 10;
            var heap = new HeapSort(capacity);
            var random = new Random();
            for (int i = 0; i < capacity; i++)
            {
                heap.Insert(random.Next(0,40));
                Console.WriteLine($"{i} iteration:");
                PrintArray(heap._priorityQueue);
            }

            Console.WriteLine("Now sort");
            heap.Sort(heap._priorityQueue);
            PrintArray(heap._priorityQueue);
        }

    }
}