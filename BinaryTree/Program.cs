using System;

namespace BinaryTree
{
    class Program
    {
        public class BinarySearchTree
        {

            public class Node
            {
                public int Data;
                public Node Left;
                public Node Right;
                public Node Next;
                public void DisplayNode()
                {
                    Console.Write(Data + " ");
                }
            }
            public Node root;
            public BinarySearchTree()
            {
                root = null;
            }
            public void Insert(int i)
            {
                Node newNode = new Node();
                newNode.Data = i;
                if (root == null)
                    root = newNode;
                else
                {
                    Node current = root;
                    Node parent;
                    while (current != null)
                    {
                        parent = current;
                        if (i < current.Data)
                        {
                            current = current.Left;
                            if (current == null)
                            {
                                parent.Left = newNode;
                                break;
                            }

                            else
                            {
                                current = current.Right;
                                if (current == null)
                                {
                                    parent.Right = newNode;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            public static Node Connect(Node root)
            {
                if (root == null)
                    return root;

                root.Left.Next = root.Right;
                if (root.Next != null)
                    root.Right.Next = root.Next.Left;

                Connect(root.Left);
                Connect(root.Right);

                return root;

            }

            static void Main()
            {
                BinarySearchTree nums = new BinarySearchTree();
                nums.Insert(1);
                nums.Insert(2);
                nums.Insert(3);
                nums.Insert(4);
                nums.Insert(5);
                nums.Insert(6);
                nums.Insert(7);

                var result = Connect(nums.root);

                Console.ReadLine();
                //nums.Insert(50);
                //nums.Insert(17);
                //nums.Insert(23);
                //nums.Insert(12);
                //nums.Insert(19);
                //nums.Insert(54);
                //nums.Insert(9);
                //nums.Insert(14);
                //nums.Insert(67);
                //nums.Insert(76);
                //nums.Insert(72);
            }
        }
    }
}
