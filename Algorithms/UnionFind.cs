using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class UnionFind
    {
        private readonly int elemnetsNumber;
       // initialize union-find data structure with N objects(0 to N – 1)
        public UnionFind(int elemnetsNumber)
        {
            this.elemnetsNumber = elemnetsNumber;
        }

        /// <summary>
        /// function to add connection between p and 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        private void union(int p , int q)
        {
            //TODO not implemented yet
        }
        /// <summary>
        /// function to know whether p and q componnents are connected
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        private bool connected(int p, int q)
        {
            return false;
        }
    }
}
