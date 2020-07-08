using System;

namespace APIsAndElementaryImplementations.BinaryTree
{
    
    public class BinaryTree: BaseIterations
    {
        public BinaryTree(int capacity) : base(capacity)
        {
        }

        //・Parent of node at k is at k/2.
        //・Children of node at k are at 2k and 2k+1.
        protected void swim(int key)
        {
            //while key is more then 1 
            //and parent element is less than child
            //swap them
            //and change key index
            while (key > 1 && isLess(key / 2, key))
            {
                swap( _priorityQueue, key / 2, key);
                key = key / 2; //change key to parent
            }
        }

        public void Insert(int key)
        {
            //increment element number after adding to queue
            _priorityQueue[++_elementsNumber] = key;
            //check ordered condition with swim operation
            swim(_elementsNumber);
        }
        
        //Parent's key becomes smaller than one (or both) of its children's
        //・Exchange key in parent with key in larger child
        //Repeat until heap order restored.
        protected void sink(int key)
        {
            
            while (2*key<=_elementsNumber)
            {
                var leftChildIndex = key * 2;
                //leftChild element is less, so swap with right and change key accordingly 
                if (leftChildIndex < _elementsNumber && isLess(leftChildIndex, leftChildIndex+1))
                {
                    leftChildIndex++;
                }
                //condition when parent is >= the left elemnt
                if(!isLess(key, leftChildIndex)) break;
                swap(_priorityQueue,leftChildIndex,key);
                key = leftChildIndex;
            }
        }

        private int DeleteMax()
        {
            var maxElement = _priorityQueue[1];//key to remove is first element in queue
            swap(_priorityQueue, 1, _elementsNumber--);//change with last elent and decrement size
            sink(1);//check for ordering
            _priorityQueue[_elementsNumber + 1] = default(int);//this element no longer needed
            return (int)maxElement;
        }

      

        public static void Test()
        {
            var  capacity = 10;
            var binaryTree = new BinaryTree(capacity);
            var random = new Random();
            for (int i = 0; i < capacity; i++)
            {
                binaryTree.Insert(random.Next(0,40));
                Console.WriteLine($"{i} iteration:");
                PrintArray(binaryTree._priorityQueue);
            }

            Console.WriteLine("Now del max");
            for (int i = 0; i < capacity/2; i++)
            {
                binaryTree.DeleteMax();
                Console.WriteLine($"{i} iteration:");
                PrintArray(binaryTree._priorityQueue);
            }
        }
        
    }
}