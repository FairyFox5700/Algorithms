using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace QueueAndStacks.Generics
{
    public class GenericStack<Item>:ILinkedListStructure<Item>, IEnumerable<Item>
    {
        private Node first= null;
        
        public void push(Item item)
        {
            //save a link to node
            var oldNode = first;
            //create new node
            first = new Node();
            first.item = item;
            //add link to oldNode
            first.next = oldNode;
                  
        }
       
        public Item  pop()
        {
            var item = first.item;
            first = first.next;
            return item;
        }
       
        public bool isEmpty()
        {
            return first == null;
        }
               
        private class Node
        {
            public Item item;
            public Node next;
        }
       
       
        public static void Start()
        {
            var linkedList  = new GenericStack<int>();
            linkedList.push(1);
            linkedList.push(2);
            linkedList.push(3);
            linkedList.push(4);
            foreach (var node in linkedList)
            {
                Console.WriteLine(node);
            }
            //pop
            Console.WriteLine(linkedList.pop()); 
            Console.WriteLine(linkedList.pop()); 
            Console.WriteLine(linkedList.pop());
            
            Console.ReadKey();
        }


        public IEnumerator<Item> GetEnumerator()
        {
            Node current =first;
            while (current != null)
            {
                yield return current.item;
                current = current.next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
       
    }

    
}