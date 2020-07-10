using System;
using System.Collections.Generic;
using APIsAndElementaryImplementations.BinaryTree;

namespace Trees
{
    public class RedBlackBST<TKey, TValue> where  TKey :IComparable
    {
        /*red links "glue" nodes within a 3-node
         black links connect  2-nodes and 3-nodes
            A BST such that:
        ・No node has two red links connected to it.
        ・Every path from root to null link has the same number of black links.
        ・Red links lean left.*/
        
        private static  bool RED = true;
        private static  bool  BLACK = false;
        public class Node
        {
            public TKey key { get; set; }
            public TValue val{ get; set; }
            public Node left { get; set; }
            public Node right{ get; set; }
            public Node(TKey key, TValue val, bool color)
            {
                this.key = key;
                this.val = val;
                this.color = color;
            }
            public bool color; // color of parent link
            
        }
        private Node root { get; set; }

        private bool isRed(Node node)
        {
            if (node == null) return false;
            return node.color == RED;
        }
        
        //Left rotation. Orient a (temporarily)
        //right-leaning red link to lean left
        
        private Node rotateLeft(Node currentNode)
        {
            Node node = currentNode.right;
            currentNode.right = node.left;
            node.left = currentNode;
            node.color = currentNode.color;
            currentNode.color = RED;
            return node;

        }
        /*Right rotation. Orient a left-leaning red
        link to (temporarily) lean right.*/
        
        private Node rotateRight(Node currentNode)
        {
            Node node = currentNode.left;
            node.right = currentNode;
            currentNode.left = node.right;
            node.color = currentNode.color;
            currentNode.color = RED;
            return node;
        }
        
        //Color flip. Recolor to split a (temporary) 4-node.
        private void flipColors(Node currentNode)
        {
            currentNode.color = RED;
            currentNode.left.color = BLACK;
            currentNode.right.color = BLACK;
        }
        public void put(TKey key, TValue val)
        {
            root = put(root, key, val);
        }
        private Node put(Node node, TKey key, TValue value)
        {
            if ( node==null) return  new Node(key,value, RED);
            var compare = key.CompareTo(node.key);
            if (compare > 0) node.right = put(node.right, key, value);
            else if (compare < 0) node.left = put(node.left, key, value);
            else node.val = value;
            if (isRed(node.right) && !isRed(node.left)) node=  rotateLeft(node);
            if (isRed(node.left) && isRed(node.left.left)) node =rotateRight(node);
            if(isRed(node.right) && isRed(node.left)) flipColors(node);
            return node;

        }

        public TValue Get(TKey key)
        {
            var node = root;
            while (node!=null)
            {
                var compare = key.CompareTo(node.key);
                if (compare < 0) node = node.left;
                else if (compare > 0) node = node.right;
                else return node.val;
            }

            return default(TValue);
        }
        private void printBinaryTree()
        {
            foreach (var element in Iterator())
            {
                Console.Write(element+ "  ");
            }
            Console.WriteLine();
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
        
      
        public  static void Test()
        {
            var rbBst = new RedBlackBST<int, string>();
            rbBst.put(1, "A");
            rbBst.put(2, "B");
            rbBst.put(3, "C");
            rbBst.put(4, "D");
            rbBst.put(5, "E");
            rbBst.put(6, "F");
            rbBst.put(7, "G");
            rbBst.put(8, "H");
            rbBst.printBinaryTree();
            Console.WriteLine("Get operation");
            Console.WriteLine(rbBst.Get(3));
  
        }
    }
}