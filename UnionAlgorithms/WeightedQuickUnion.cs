using System;

namespace Algorithms
{
    public class WeightedQuickUnion:IUnionFindStructure
    {
        /*
        Data structure. Same as quick-union, 
        but maintain extra array sz[i]
        to count number of objects in the tree rooted at i.
        */
        public int[] data { get; set; }
        public  int[] sz  { get; set; }

        public WeightedQuickUnion(int number)
        {
            data = new int  [number];
            for (int i = 0; i < number; i++)
            {
                data[i] = i;
                sz[i] = 1;
            }   
        }
        
        /*Union. Modify quick-union to:
        ・Link root of smaller tree to root of larger tree.
        ・Update the sz[] array
        */
        public void Union(int p, int q)
        {
            var pRoot = GetRoot(p);
            var qRoot = GetRoot(q);
            if( p==q) return;
            if (sz[pRoot] < sz[qRoot])
            {
                data[pRoot] = qRoot;
                sz[pRoot] += sz[qRoot];
            }
            else
            {
                data[qRoot] = pRoot;
                sz[qRoot] += sz[pRoot];
            }
           
        }

        // Identical to quick-union
        public bool Connected(int p, int q)
        {
            return GetRoot(p) == GetRoot(q);
        }

        private int  GetRoot(int element)
        {
            while (element!= data[element])
            {
               data[element] = data[data[element]];//2 times less iteration here
               element = data[element];
            }

            return element;
        }
        
        public static void  StartWightedQuickUnion()
        {
            QuickUnion quickUnion = new QuickUnion(10);
            quickUnion.Union(4,3);
            quickUnion.Union(3,8);
            quickUnion.Union(6,5);
            quickUnion.Union(9,4);
            quickUnion.Union(2,1);

               
                
            Console.WriteLine("8 and  9 are connected ---> " + quickUnion.Connected(8, 9));//true
            Console.WriteLine("5 and  4 are connected ---> " +quickUnion.Connected(5, 4));
            quickUnion.Union(5,0);
            quickUnion.Union(7,2);
            quickUnion.Union(6,1);
            quickUnion.Union(7,3);
            for (int i = 0; i < quickUnion.data.Length; i++)
            {
                Console.WriteLine(i+"-->" +quickUnion.data[i]);
            }
            Console.WriteLine("7 and  2 are connected ---> " + quickUnion.Connected(7, 2));
            Console.WriteLine("3 and  6 are connected ---> " + quickUnion.Connected(3, 6));
            Console.WriteLine("3 and 7 are connected ---> "+ quickUnion.Connected(3, 7));
            Console.WriteLine("2 and 5 are connected ---> " + quickUnion.Connected(2, 5));
            Console.ReadLine();
        }

       
    }
}