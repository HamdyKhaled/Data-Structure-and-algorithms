using System;
using System.Collections;

namespace LinkedList
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    class Program
    {
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {

            ListNode dummy = new ListNode(0);

            ListNode curr = dummy;

            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    curr.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    curr.next = l2;
                    l2 = l2.next;
                }
                curr = curr.next;

            }

            curr.next = l1 != null ? l1 : l2;

            return dummy.next;

        }
        public static ListNode middleNode(ListNode head)
        {
            ListNode slow = head, fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }

        public static ListNode middleNode2(ListNode head)
        {
            ListNode[] A = new ListNode[100];
            int t = 0;
            while (head != null)
            {
                A[t++] = head;
                head = head.next;
            }
            return A[t / 2];
        }

        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode dummy_node = new ListNode(0);
            dummy_node.next = head;
            ListNode slow = dummy_node;
            ListNode fast = dummy_node;

            for(int i=1; i<= n+1; i++)
            {
                fast = fast.next;
            }

            while (fast != null)
            {
                fast = fast.next;
                slow = slow.next;
            }

            slow.next = slow.next.next;
            return dummy_node.next;
        }
        static void Main(string[] args)
        {
            ListNode l1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            ListNode l2 = new ListNode(1, new ListNode(3, new ListNode(4)));

            ListNode l3 = new ListNode(1, new ListNode(3, new ListNode(4, new ListNode(5))));
            var jj =  MergeTwoLists(l1, l2);

            var middleNo = middleNode2(l3);
            ListNode l4 = new ListNode(1, new ListNode(3, new ListNode(4, new ListNode(5))));
            var removeNodeNth = RemoveNthFromEnd(l4, 2);
            




            Console.WriteLine("Hello World!");
        }
    }
}
