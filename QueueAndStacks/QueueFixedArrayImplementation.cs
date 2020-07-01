using System;
using System.Linq;

namespace QueueAndStacks
{
    public class QueueFixedArrayImplementation
    {
        //Use array q[] to store items in queue.
        //・enqueue(): add new item at q[tail].
        //・dequeue(): remove item from q[head].
        //・Update head and tail modulo the capacity.
        private  string[] queueArray;
        private int head=0;
        private  int tail=0;

       
        public QueueFixedArrayImplementation(int capacity)
        {
            queueArray = new string[capacity];
        }

        public void enqueue(string item)
        {
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

        public string dequeue()
        {
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

        private bool IsEmpty =>  tail == 0;


        public static void Start()
        {
            var queue= new QueueFixedArrayImplementation(10);

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
            
            Console.WriteLine("[{0}]", string.Join(", ", queue.queueArray));//[, , , D, E, F, G, , , ]
            Console.ReadLine();
        }

    }
}