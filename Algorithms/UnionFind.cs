using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    /// <summary>
    /// Data structure:
    /// ・Integer array id[] of length N.
    /// ・Interpretation: p and q are connected iff they have the same id.
    /// </summary>
    public class QuickUnionFind
    {
        private int [] data;

        // initialize union-find data structure with N objects(0 to N – 1)
        public QuickUnionFind(int elemnetsNumber)
        {
            this.data = new int [elemnetsNumber];
            for (int i = 0; i < elemnetsNumber; i++)
                data[i] = i;

        }

        /// <summary>
        /// function to add connection between p and 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        private void union(int p , int q)
        {
            //To merge components containing p and q, change all entries
            //whose id equals id[p] to id[q].
            var pId = data[p];//0
            var qId = data[q];//0
            for ( int i=0; i <data.Length; i++)
            {
                
                if( data[i] ==pId)
                {
                    data[i] = qId;
                }
            }
        }
        /// <summary>
        /// function to know whether p and q componnents are connected
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        private bool connected(int p, int q)
        {
            //Check if p and q have the same id.
            return data[p] == data[q]? true : false;
        }

        public static void StartUnionFind()
        {
            int number = 8;
            var uninFind = new QuickUnionFind(number);
            Random random = new Random();
            var testArray = Enumerable.Repeat(0, number).Select(n => random.Next(0, number)).ToArray();
            Console.WriteLine(testArray);

            for (int i = 0; i < testArray.Length; i+=2)
            {
                var p = testArray[i];
                var q = testArray[i+1];
                if(!uninFind.connected(p,q))
                {
                    uninFind.union(p, q);
                    Console.WriteLine(p+" "+q);
                }
            }

        }
    }
}
