using DasPad.Specs.Models;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.LinkedListSpecs
{
  public class PalindromeLinkedListSpecs
  {
    /*
     * Given a singly linked list, determine if it is a palindrome.

        Example 1:

        Input: 1->2
        Output: false
        Example 2:

        Input: 1->2->2->1
        Output: true

      Follow up:
      Could you do it in O(n) time and O(1) space?
     */

    //TIP Better appraoch without additional space using mid of linked list and then reversing the other half.
    public bool IsPalindrome(ListNode head)
    {
      if (head == null || head.next == null)
      {
        return true;
      }
      //TIP Here we are reversing from the next node of Half
      var halfNode = GetHalfOf(head.next);
      var reversed = Reverse(halfNode);
      while (reversed != null)
      {
        if (head.val != reversed.val)
        {
          return false;
        }
        head = head.next;
        reversed = reversed.next;
      }

      return true;
    }

    public ListNode Reverse(ListNode head)
    {
      if (head == null || head.next == null)
      {
        return head;
      }

      ListNode pre = null;

      while (head != null)
      {
        ListNode next = head.next;
        head.next = pre;
        pre = head;
        head = next;
      }

      return pre;
    }

    public ListNode GetHalfOf(ListNode head)
    {
      ListNode fast = head;
      ListNode slow = head;
      while (fast.next != null && fast.next.next != null)
      {
        fast = fast.next.next;
        slow = slow.next;
      }
      return slow;
    }

    public bool IsPalindromeUsingStack(ListNode head)
    {
      if (head == null || head.next == null)
      {
        return true;
      }
      var stack = new Stack<int>();
      var cur = head;
      while (cur != null)
      {
        stack.Push(cur.val);
        cur = cur.next;
      }
      cur = head;
      while (stack.Count > 0)
      {
        if (stack.Peek() != cur.val)
        {
          return false;
        }
        stack.Pop();
        cur = cur.next;
      }
      return true;
    }

    [Theory]
    [InlineData("1,2,1", true)]
    [InlineData("1,2", false)]
    [InlineData("0,0", true)]
    public void CanVerifyIsPalindrome(string input, bool expected)
    {
      Assert.Equal(expected, IsPalindromeUsingStack(input.ToListNode()));
      Assert.Equal(expected, IsPalindrome(input.ToListNode()));
    }
  }
}
