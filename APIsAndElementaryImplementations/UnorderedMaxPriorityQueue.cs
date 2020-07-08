using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Sorting;

namespace APIsAndElementaryImplementations
{
    public class UnorderedMaxPriorityQueue:BaseIterations
    {
        
        public UnorderedMaxPriorityQueue(int capacity) : base(capacity)
        {
        }
        private bool IsEmpty  => _elementsNumber == 0;

        public void Insert(int key)
        {
            _priorityQueue[_elementsNumber++] = key;
        }

        public int DeleteMax()
        {
            var max = 0;
            for (int i = 0; i < _elementsNumber; i++)
            {
                if (isLess(max, i)) max = i;
            }
            swap( _priorityQueue, max, _elementsNumber-1);
            return (int) _priorityQueue[--_elementsNumber];
        }
    }
}