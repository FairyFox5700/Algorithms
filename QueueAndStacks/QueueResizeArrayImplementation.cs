using System;

namespace QueueAndStacks
{
    public class QueueResizeArrayImplementation
    {
        //Use array q[] to store items in queue.
        //・enqueue(): add new item at q[tail].
        //・dequeue(): remove item from q[head].
        //・Update head and tail modulo the capacity.
        private  string[] queueArray;
        private int head=0;
        private  int tail=0;

       
        public QueueResizeArrayImplementation(int capacity)
        {
            queueArray = new string[capacity];
        }

        public void enqueue(string item)
        {
            doubleArrayIfEnd();
            if (IsEmpty)
            {
                queueArray[head] = item;
            }
            else
            {
                queueArray[tail] = item;
            }
            tail++;
        }

        private void doubleArrayIfEnd()
        {
            //double sized array if it last element
            if (tail == queueArray.Length)
            {
                resize(queueArray.Length*2);
            } 
        }
        
        
        private void resize(int size)
        {
            var newArray = new  string [size];
            for (int i = 0; i < queueArray.Length; i++)
            {
                newArray[i] = queueArray[i];
            }
            queueArray = newArray;
        }

        public string dequeue()
        {
            halfArrayIfItIsQuarter();
            var item = queueArray[head];
            
            if (IsEmpty)
            {
                queueArray[tail] = null;
            }
            else
            {
                queueArray[head] = null; 
            }
            head++;
            return item;
        }

        private void halfArrayIfItIsQuarter()
        {
            if (head > 0 && tail < queueArray.Length / 4)
            {
                resize(queueArray.Length/2);
            }
        }

        private bool IsEmpty =>  tail == 0;


        public static void Start()
        {
            var queue= new QueueResizeArrayImplementation(2);

            queue.enqueue("A");
            queue.enqueue("B");
            queue.enqueue("C");
            queue.enqueue("D");
            queue.enqueue("E");

            queue.dequeue();
            queue.dequeue();
            queue.dequeue();

            queue.enqueue("F");
            queue.enqueue("G");
            
            Console.WriteLine("[{0}]", string.Join(", ", queue.queueArray));//[, , , D, E, F, G, ]

            Console.ReadLine();
        }
    }
}