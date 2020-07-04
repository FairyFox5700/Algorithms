using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using QueueAndStacks.Stack;

namespace QueueAndStacks.Generics
{
    public class GenericFixedArrayStack<Item>:ILinkedListStructure<Item>, IEnumerable<Item>
    {
        public Item[] storeData { get; set; }
        public int index = 0;

        public GenericFixedArrayStack(int size)
        {
            storeData = new Item[size];
        }

        public void push(Item item)
        {
            //insert to current index than increment
            storeData[index] = item;
            index++;
        }

        public Item pop()
        {
            //decrement first than take argument
            var item = storeData[--index];
            storeData[index] = default(Item);//avoid loitering (holding reference to an object when it is no longer needed). SO GC can reclaim memory
            return item;
        }

        public bool isEmpty()
        {
            return index == 0;
        }
        
        public static void Start()
        {
            var linkedList  = new GenericFixedArrayStack<int>(6);
            linkedList.push(1);
            linkedList.push(2);
            linkedList.push(3);
            linkedList.push(4);
            foreach (var node in linkedList)
            {
                Console.WriteLine(node);
            }
            
            Console.ReadKey();
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return Enumerable.Reverse(storeData).GetEnumerator();

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}