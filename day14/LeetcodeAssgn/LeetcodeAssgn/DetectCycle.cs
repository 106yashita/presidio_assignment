using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeAssgn
{
    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int x)
      {
        val = x;
        next = null;
      }
    }
    public class DetectCycle
    {
        public async Task<bool> HasCycleAsync(ListNode head)
        {
            if (head == null) return false;
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                    return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(4);
            ListNode node5 = new ListNode(5);

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node2; 
            DetectCycle detectCycle = new DetectCycle();

            bool hasCycle = detectCycle.HasCycleAsync(node1).Result;
            Console.WriteLine("Has Cycle: " + hasCycle);

        }
    }
}
