using System;
using System.Security.Claims;

namespace QueueAndStacks
{
    public class StackOfStrings:ILinkedListStructure
    {
        private Node first= null;
        public void push(string item)
        {
            //save a limk to node
            var oldNode = first;
            //create new node
            first = new Node();
            first .item = item;
            //add link to oldNode
            first.next = oldNode;
           
        }

        public string pop()
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
            public string item;
            public Node next;
        }


        public static void StartLinkedListOfStrings()
        {
            var linkedList  = new StackOfStrings();
            linkedList.push("I");
            linkedList.push("did");
            linkedList.push("He");
            linkedList.push("has");
           Console.WriteLine(linkedList.pop()); 
           Console.WriteLine(linkedList.pop()); 
           Console.WriteLine(linkedList.pop());
           Console.ReadKey();
        }
    }
}