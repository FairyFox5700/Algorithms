using System;
using System.Security.Cryptography.X509Certificates;

namespace APIsAndElementaryImplementations.HashTables
{
    public class SeparateChainingHashST<TKey, TValue> :IHashTable<TKey,TValue>
    {
        private const int M = 97; // number of chains
        private Node[] chains = new Node[M]; // array of chains
        private  class Node
        {
            public object key { get; set; }//no generic array creation
            public object val { get; set; }//(declare key and value of type Object)
            public Node next { get; set; }

            public Node(object key, object val, Node next)
            {
                this.key = key;
                this.val = val;
                this.next = next;
            }
        }
        //Hash: map key to integer i between 0 and M - 1.
        protected int hash(TKey key)
        { return (key.GetHashCode() & 0x7fffffff) % M; }

        //・Search: need to search only i-th chain
        public TValue Get(TKey key)
        {
            var hashValue = hash(key);

            for (var node = chains[hashValue]; node != null; node = node.next)
            {
                if (key.Equals(node.key))
                    return (TValue)node.val;
            }
            return default(TValue);
        }

        //・Insert: put at front of i
        //th chain (if not already there).
        public void Put(TKey key, TValue value)
        {
            var hashValue = hash(key);
            for (var node  = chains[hashValue];node!=null;node = node.next)
            {
                if (key.Equals(node.key))
                {
                    node.val = value;//update value
                    return; 
                }
                
            }
            chains[hashValue]= new Node(key,value, chains[hashValue]);
        }
        
        public static void Test()
        {
            var linearProbing = new SeparateChainingHashST<int, string>();
            linearProbing.Put(1,"Q");
            linearProbing.Put(2,"E");
            linearProbing.Put(3,"G");
            linearProbing.Put(1,"R");
            linearProbing.Put(1,"H");
            linearProbing.Put(8,"K");
            linearProbing.Put(8,"Q");
            Console.WriteLine(linearProbing.Get(1));
            // Console.WriteLine(linearProbing.Get(5));
        }
    }
}