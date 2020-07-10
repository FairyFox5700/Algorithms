using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;

namespace APIsAndElementaryImplementations.HashTables
{
    public class LinearProbingHashST<TKey, TValue> :IHashTable<TKey,TValue> 
    {
        private const int M = 30001;
        private TValue[] vals = new TValue[M];
        private TKey[] keys =  new TKey[M];
        private  class Node
        {
            public object key { get; set; }//no generic array creation
            public object val { get; set; }//(declare key and value of type Object)
            public Node next { get; set; }

            public Node( object key, object val, Node next)
            {
                this.key = key;
                this.val = val;
                this.next = next;
            }
        }
        //Hash: map key to integer i between 0 and M - 1.
        protected int hash(TKey key)
        { return (key.GetHashCode() & 0x7fffffff) % M; }

        //Search table index i; if occupied but no match,
        //try i+1, i+2, etc.
        public TValue Get(TKey key)
        {
            for (var i = this.hash(key); keys[i] != null; i = (i + 1) % M)
            {
                if (key.Equals(keys[i]))
                    return vals[i];
            }
            return default(TValue);
        }

        //Put at table index i if free; if not try i+1, i+2, etc
        public void Put(TKey key, TValue value)
        {
            int indexToPut;
            //find another empty elment to insert
            for (indexToPut = this.hash(key); keys[indexToPut]!=null; indexToPut = (indexToPut+1)%M)
            {
                if( keys[indexToPut].Equals(key))
                    break;
                
            }
            keys[indexToPut] = key;
            vals[indexToPut] = value;
            
        }

        public static void Test()
        {
            var linearProbing = new LinearProbingHashST<int?, string>();
            
            linearProbing.Put(1,"Q");
            linearProbing.Put(1,"Q");
            linearProbing.Put(2,"E");
            linearProbing.Put(3,"G");
            linearProbing.Put(1,"R");
            linearProbing.Put(1,"H");
            linearProbing.Put(8,"K");
            linearProbing.Put(8,"Q");
            Console.WriteLine(linearProbing.Get(1));
            Console.WriteLine(linearProbing.Get(8));
        }
        
    }
}