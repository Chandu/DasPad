using DasPad.Specs.Models;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
    public class RemoveNthNodeSpecs
    {
        //TODO: (CV)
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode fast = head;
            ListNode slow = head;
            for (int i = 0; i < n; i++)
            {
                fast = fast.next;
            }
            if (fast == null)
            {
                head = head.next;
                return head;
            }

            while (fast.next != null)
            {
                fast = fast.next;
                slow = slow.next;
            }

            slow.next = slow.next.next;

            return head;
        }

        public ListNode BuildNode(int headVal, params int[] numbers)
        {
            var head = new ListNode(headVal);
            return numbers.Aggregate(head, (acc, cur) =>
            {
                var node = new ListNode(cur);
                var lastNode = acc;
                while (lastNode.next != null)
                {
                    lastNode = lastNode.next;
                }
                lastNode.next = node;
                return acc;
            });
        }

        public static string ToString(ListNode node)
        {
            var toReturn = "";
            while (node != null)
            {
                toReturn += node.val.ToString();
                node = node.next;
            }
            return toReturn;
        }

        [Fact]
        public void CanRemoveNthFromEnd()
        {
            var head = BuildNode(1, 2, 3, 4, 5);
            var expected = BuildNode(1, 2, 3, 5);
            Assert.Equal(ToString(expected), ToString(RemoveNthFromEnd(head, 2)));
            Assert.Equal(ToString(null), ToString(RemoveNthFromEnd(BuildNode(1), 1)));
            Assert.Equal(ToString(BuildNode(2)), ToString(RemoveNthFromEnd(BuildNode(1, 2), 2)));
        }
    }
}