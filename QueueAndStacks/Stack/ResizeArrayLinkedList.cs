using System;

namespace QueueAndStacks.Stack
{
    public class ResizeArrayLinkedList:ILinkedListStructure<string>
    {
        public string[] storeData { get; set; }
        public int index = 0;

        public ResizeArrayLinkedList(int size)
        {
            storeData = new string[size];
        }

        public void push(string item)
        {
            //double sized array if it last element
            if (index == storeData.Length)
            {
                resize(storeData.Length*2);
            }
            storeData[index] = item;
            index++;
        }

        public string pop()
        {
            //decrement first than take argument
           
            var item = storeData[--index];
            storeData[index] = null;//avoid loitering (holding reference to an object when it is no longer needed). SO GC can reclaim memory
            //resize only if it 1/4 of array length
            if (index > 0 && index < storeData.Length / 4)
            {
                resize(storeData.Length/2);
            }
            return item;
        }

        
        public bool isEmpty()
        {
            return index == 0;
        }

        /*The \verb#resize()#resize() method is called only when the size of the stack is a power of 2.
         There are ∼ log_2 n powers of 2 between 1 and nn.
 */

        private void resize(int size)
        {
            var newArray = new  string [size];
            for (int i = 0; i < storeData.Length; i++)
            {
                newArray[i] = storeData[i];
            }

            storeData = newArray;

        }
        public static void Start()
        {
            var linkedList  = new ResizeArrayLinkedList(6);
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