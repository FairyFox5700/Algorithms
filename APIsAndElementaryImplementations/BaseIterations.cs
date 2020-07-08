using System;
using System.Collections.Generic;

namespace APIsAndElementaryImplementations
{
    public class BaseIterations
    {
        protected readonly IComparable[] _priorityQueue;
        protected int _elementsNumber;

        private  static Random _random= new Random();
        public BaseIterations(int capacity)
        {
            _priorityQueue =  new IComparable[capacity+1];
        }
        protected static void swap(IComparable[] array, int firstIndex, int seconIndex)
        {
            var temp = array[firstIndex];
            array[firstIndex] = array[seconIndex];
            array[seconIndex] = temp;
        }

        protected  bool isLess(  int firstElement, int secondElement)
        {
            return _priorityQueue[firstElement].CompareTo(_priorityQueue[secondElement]) < 0;
        }
        
        protected static DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;  
            return start.AddDays(_random.Next(range));
        }
        
        protected static void PrintArray(IComparable[] testArray)
        {
            foreach (var element in testArray)
            {
                Console.Write(element?.ToString()+  " ");
            }
            Console.WriteLine();
        }
  
    }
}