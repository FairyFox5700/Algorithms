using System;

namespace QueueAndStacks
{

    /*Array implementation of a stack.
    ・Use array s[] to store N items on stack.
    ・push(): add new item at s[N].
    ・pop(): remove item from s[N-1
    */
    public class FixedArrayLinkedList:ILinkedListStructure<string>
    {
        public string[] storeData { get; set; }
        public int index = 0;

        public FixedArrayLinkedList(int size)
        {
            storeData = new string[size];
        }

        public void push(string item)
        {
            //insert to current index than increment
            storeData[index] = item;
            index++;
        }

        public string pop()
        {
            //decrement first than take argument
            var item = storeData[--index];
            storeData[index] = null;//avoid loitering (holding reference to an object when it is no longer needed). SO GC can reclaim memory
            return item;
        }

        public bool isEmpty()
        {
            return index == 0;
        }
        
        public static void Start()
        {
            var linkedList  = new FixedArrayLinkedList(6);
            linkedList.push("I");
            linkedList.push("did");
            linkedList.push("He");
            linkedList.push("has");
            Console.WriteLine(linkedList.pop()); 
            Console.WriteLine(linkedList.pop()); 
            Console.WriteLine(linkedList.pop());//has He did
            Console.ReadKey();
        }

    }
}