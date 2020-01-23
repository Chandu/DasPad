using DasPad.Specs.Models;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.LinkedListSpecs
{
    public class AddTwoNumbersSpecs
    {
        /*
         * https://leetcode.com/explore/interview/card/top-interview-questions-medium/107/linked-list/783/
         * Add Two Numbers
            Solution
            You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

            You may assume the two numbers do not contain any leading zero, except the number 0 itself.

            Example:

            Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
            Output: 7 -> 0 -> 8
            Explanation: 342 + 465 = 807.
         */

        public ListNode AddTwoNumbers(ListNode first, ListNode second)
        {
            var carry = 0;
            var toReturn = new ListNode(-1);
            var curNode = toReturn;
            while (first != null && second != null)
            {
                var sum = carry + first.val + second.val;
                curNode.next = new ListNode(sum % 10);
                carry = sum / 10;
                first = first.next;
                second = second.next;
                curNode = curNode.next;
            }

            while (first != null)
            {
                var sum = carry + first.val;
                curNode.next = new ListNode(sum % 10);
                carry = sum / 10;
                first = first.next;
                curNode = curNode.next;
            }
            while (second != null)
            {
                var sum = carry + second.val;
                curNode.next = new ListNode(sum % 10);
                carry = sum / 10;
                second = second.next;
                curNode = curNode.next;
            }
            if (carry > 0)
            {
                curNode.next = new ListNode(carry);
            }
            return toReturn.next;
        }

        [Theory]
        [InlineData("1,2,3", "1,2,3", "2, 4, 6")]
        [InlineData("2,4,3", "5,6,4", "7, 0, 8")]
        public void CanAddTwoNumbers(string first, string second, string expected)
        {
            Assert.Equal(expected, AddTwoNumbers(first.AsListNode(), second.AsListNode()).AsString());
        }
    }
}