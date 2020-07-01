using System;
using System.Data.Common;
using System.Runtime.ConstrainedExecution;

namespace Algorithms
{
    public class QuickUnion:IUnionFindStructure
    {
            /*Data structure.
            Integer array id[] of length N.
            Interpretation: id[i] is parent of i.
            Root of i is id[id[id[...id[i]...]]]*/

            
            //init data array 
            public QuickUnion(int number)
            {
                data = new int  [number];
                for (int i = 0; i < number; i++)
                {
                    data[i] = i;
                }
                
            }
            
            //To merge components containing p and q,
            //set the id of p's root to the id of q's root.
            public void Union(int p, int q)
            {
                data[GetRoot(p)] = GetRoot(q);
            }

            // Check if p and q have the same root
            public bool Connected(int p, int q)
            {
                return GetRoot(p) == GetRoot(q);
            }

            private int  GetRoot(int element)
            {
                while (element!= data[element])
                {
                    element = data[element];
                }

                return element;
            }

            public int[] data { get; set; }

            public static void  StartQuickUnion()
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