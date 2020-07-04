using System;

namespace QueueAndStacks.Queue
{
    public class QueueOfStrings
    {
        private Node first= null;
        private Node last= null;
        private class Node
        {
            public string item;
            public  Node next;
        }
     

        //insert a new string onto queue
        public void enqueue(string item)
        {
            var oldNode = last;
            last = new Node();
            last.item = item;
            last.next = null;
            if (isEmpty)
            {
                first = last;
            }
            else
            {
                oldNode.next = last;
            }
        }
        //remove and return the string
        //least recently added
        public string dequeue()
        {
            var item = this.first.item;
            this.first = first.next;
            
            if (isEmpty)
            {
                last = null;
            }
            return item;
        }

        //is the queue empty?
        public bool isEmpty=> this.first == null;
      
        public static void Start()
        {
            var queue= new QueueOfStrings();

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
            
            queue.PrintQueue();//DEFG
            Console.ReadLine();
        }

        public  void  PrintQueue( )
        {
            var current = first;
            while (current!=null)
            {
                Console.WriteLine(current.item);
                current = current.next;
            }
        }
    }
    
}