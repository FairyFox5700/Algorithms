using System;
using System.Collections;
using System.Collections.Generic;

namespace APIsAndElementaryImplementations.SymbolsApi
{
    public class SymbolsTable<TKey, TValue> where TKey : notnull, IComparable
    {
        //put key-value pair into the table
        //(remove key from table if value is null)
        private void put(TKey key, TValue value)
        {
            throw new System.NotImplementedException();
        }

        private TKey[] keys;
        private TValue[] values;

        private TValue get(TKey key)
        {
            var rank = this.rank(key);//binary search
            if (rank < N && keys[rank].CompareTo(key) == 0)
            {
                return values[rank];
            }
            else
            {
                return default(TValue);
            }
            
        }

        private int rank(TKey key)
        {
            int low = 0;
            int high = N - 1;
            while (low<=high)
            {
                int mid = low + (high - low) / 2;
                var compareResult = key.CompareTo(keys[mid]);
                if (compareResult > 0) low = mid + 1;
                else if (compareResult < 0) low = mid - 1;
                else return mid;
            }

            return low;
        }

        public int N { get; }

        private void delete(TKey key)
        {
            put(key,default(TValue));
        }
        
       

        private bool contains(TKey key) => get(key) != null;


        private bool isEmpty => N == 0;

        private int size => N;
        public  static  void Test()
        {
            var symbolsTable = new SymbolsTable<string, int>();
            var testArrayOfKeys = new[] {"A", "B", "C", "D","E","F","H","G"};
            for (int i = 0; i < testArrayOfKeys.Length; i++)
            {
                var key = testArrayOfKeys[i];
                symbolsTable.put(key, i);
            }

            foreach (var key in symbolsTable.keys)
            {
                Console.WriteLine(key+""+symbolsTable.get(key));
            }
        }

        

       
    }
    
    
    
}