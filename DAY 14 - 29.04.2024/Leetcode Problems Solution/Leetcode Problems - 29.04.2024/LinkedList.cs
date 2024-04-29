using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leetcode_Problems___29._04._2024.Program;

namespace Leetcode_Problems___29._04._2024
{
    public class LinkedList
    {
        public async Task<bool> HasCycle(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return false;
            }

            ListNode slow = head;
            ListNode fast = head.next;

            while (fast != null && fast.next != null)
            {
                if (slow == fast)
                {
                    return true;
                }

                slow = slow.next;
                fast = fast.next.next;

                // Introducing a small delay to simulate an asynchronous operation
                await Task.Delay(10);
            }

            return false;
        }
    }
}
