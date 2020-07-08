using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;

namespace APIsAndElementaryImplementations.BinaryTree
{
    public class BinarySearchTree<TKey, TValue> where  TKey :IComparable
    {
        /*A Node is comprised of four fields:
        ・A Key and a Value.
        ・A reference to the left and right subtree.*/
        public class Node
        {
            public TKey key { get; set; }
            public TValue val{ get; set; }
            public Node left { get; set; }
            public Node right{ get; set; }
            public int count { get; set; }
            public Node(TKey key, TValue val)
            {
                this.key = key;
                this.val = val;
            }
        }
        private Node root { get; set; }
    
        /*Search for key, then two cases:
        ・Key in tree ⇒ reset value.
        ・Key not in tree ⇒ add new node.*/
        public void put(TKey key, TValue val)
        {
            root = put(root, key, val);
        }

        // Associate value with key. 
        //Cost. Number of compares is equal to 1 + depth of node
        /*Search for key, then two cases:
        ・Key in tree ⇒ reset value.
        ・Key not in tree ⇒ add new node.*/

        private Node put(Node node, TKey key, TValue val)
        {
            if (node ==null ) return  new Node(key, val);
            var comparison = key.CompareTo(node.key);
            if (comparison > 0)
               node.right=  put(node.right,key, val);
            else if (comparison < 0)
                node.left = put(node.left, key, val);
            else node.val = val;
            node.count = 1 + size(node.left) + size(node.right);//before return check the count
            return node;
        }


        public int Rank(TKey key)
        {
            return rank(root, key);
        }

        private int rank(Node node, TKey key)
        {
            if (node == null) return 0;
            var comparison = key.CompareTo(node.key);
            if (comparison < 0) return rank(node.left, key);//position to the left
            else if (comparison > 0) return 1 + size(node.left) + rank(node.right, key);//1+ position to the left + position to the right recursively
            return size(node.left);//if root
        }

        // Return value corresponding to given key,
        // or null if no such key
        public TValue Get(TKey key)
        {
            var currentNode = root;
            while (currentNode!=null)
            {
                var comparisonResult = root.key.CompareTo(key);
                if (comparisonResult > 0)
                {
                    currentNode = currentNode.right;
                }
                else if (comparisonResult < 0)
                {
                    currentNode = currentNode.left;
                }
                else return currentNode.val;
            }

            return default(TValue);
        }
        //Ceiling. Smallest key ≥ a given key
        public TKey Ceil(TKey key)
        {
            var foundedNode = ceil(root, key);
            if (foundedNode == null) return default(TKey);
            return foundedNode.key;
        }

        private Node ceil(Node node, TKey key)
        {
            if (node == null) return node;
            var compare = key.CompareTo(node.key);
            if (compare == 0) return node;
            if (compare > 0) return ceil(node.right, key);
            var rootOfLeft = ceil(node.left, key);
            if (rootOfLeft != null) return rootOfLeft;
            return null;
        }

        //Floor. Largest key ≤ a given key
        public TKey Floor(TKey key)
        {
            var foundedNode = floor(root, key);
            if (foundedNode == null) return default(TKey);
            return foundedNode.key;
        }

        //Floor. Largest key ≤ a given key
        private Node floor(Node node, TKey key)
        {
            if (node == null) return null;
            var compare = key.CompareTo(node.key);
            //Case 1. [k equals the key at root]
            //The floor of k is k
            if (compare == 0) return node;
            /*Case 2. [k is less than the key at root]
            The floor of k is in the left subtree.*/
            if (compare < 0) return floor(node.left, key);
            /*Case 3. [k is greater than the key at root]
            The floor of k is in the right subtree
                (if there is any key ≤ k in right subtree);
            otherwise it is the key in the root.*/
            var rightRoot = floor(node.right, key);
            if (rightRoot != null) return rightRoot;
            return null;
        }

        /*
        In each node, we store the number of nodes in the subtree rooted at that
            node; to implement size(), return the count at the root.*/
        private int size(Node node)
        {
            if (node == null) return 0;
            return node.count;
        }
        
        public TKey Max()
        {
            var curentNode = root;
            while (curentNode.right!=null)
            {
                curentNode = curentNode.right;
            }
            return curentNode.key;
        }
        
        public Node Min(Node node)
        {
            var curentNode = node;
            while (curentNode!=null)
            {
                curentNode = curentNode.left;
            }

            return curentNode;
        }

        public void DeleteMin()
        {
            root = deleteMin(root);
        }

        /*To delete the minimum key:
        ・Go left until finding a node with a null left link.
        ・Replace that node by its right link.
        ・Update subtree counts.*/
        private Node deleteMin(Node node)
        {
            if (node.left == null) return node.right;//than root is min
            node.left = deleteMin(node.left);
            node.count = 1 + size(node.left) + size(node.right);
            return node;
        }

        /*To delete a node with key k: search for node t containing key k.*/

        public void Delete(TKey key)
        {  // Case 0. [0 children] Delete t by setting parent link to null.
            root = delete(root, key);
        }

        private Node delete(Node node, TKey key)
        {
            
            if (node == null) return null;
            var comparer = key.CompareTo(node.key);
            if (comparer < 0)
                node.left = delete(node.left, key);
            if (comparer > 0)
                node.right = delete(node.right, key);
            else
            {
                //Case 1. [1 child] Delete t by replacing parent link.
                if (node.right == null) return node.left;
                if (node.left == null) return node.right;
                /*Case 2. [2 children]
                    ・Find successor x of t.
                    ・Delete the minimum in t's right subtree.
                    ・Put x in t's spot.*/
                var temporaryNode = node;
                //replace with successor
                node = Min(temporaryNode.right);//go right, then go left until reaching null left link
                node.right = deleteMin(temporaryNode.right);
                node.left = temporaryNode.left;
            }
            node.count =  1 + size(node.left) + size(node.right);
            return node;
        }

        public IEnumerable<TKey> Iterator()
        {
            var queue = new Queue<TKey>();
            inorder(root, queue);
            return queue;
        }

        private void inorder(Node node, Queue<TKey> queue)
        {
            //if already all nodes enqueued to the left
            //side than recursively to the right side
            if (node == null) return;
            inorder(node.left, queue);
            queue.Enqueue(node.key);
            inorder(node.right, queue);
        }

        private void printBinaryTree()
        {
            foreach (var element in Iterator())
            {
                Console.Write(element+ "  ");
            }
            Console.WriteLine();
        }
        public static void Test()
        {
            var bst = new BinarySearchTree<int, string>();
            bst.put(1, "A");
            bst.put(2, "B");
            bst.put(3, "C");
            bst.put(4, "D");
            bst.put(5, "E");
            bst.put(6, "F");
            bst.put(7, "G");
            bst.put(8, "H");
            bst.printBinaryTree();
            Console.WriteLine("DeleteMin operation");
            bst.DeleteMin();
            bst.printBinaryTree();
            Console.WriteLine("Delete node at 3 operation");
            bst.Delete(3);
            bst.printBinaryTree();
            Console.WriteLine($"max: {bst.Max()}");
            Console.WriteLine($"floor:{bst.Floor(5)}");
            Console.WriteLine($"ceil:{bst.Ceil(6)}");
            Console.WriteLine($"rank:{bst.Rank(4)}");
        }
        
    }
}