using DasPad.Specs.Models;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.LinkedListSpecs
{
  public class OddEvenLinkedListSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-medium/107/linked-list/784/
     * Given a singly linked list, group all odd nodes together followed by the even nodes. Please note here we are talking about the node number and not the value in the nodes.

      You should try to do it in place. The program should run in O(1) space complexity and O(nodes) time complexity.

      Example 1:

      Input: 1->2->3->4->5->NULL
      Output: 1->3->5->2->4->NULL
      Example 2:

      Input: 2->1->3->5->6->4->7->NULL
      Output: 2->3->6->7->1->5->4->NULL
      Note:

      The relative order inside both the even and odd groups should remain as it was in the input.
      The first node is considered odd, the second node even and so on ...
     */

    //Revisit:
    public ListNode OddEvenList(ListNode head)
    {
      if (head == null || head.next == null)
      {
        return head;
      }
      ListNode odd = head;
      ListNode even = head.next;
      ListNode evenHead = head.next;
      while (even != null && even.next != null)
      {
        odd.next = odd.next.next;
        even.next = even.next.next;
        odd = odd.next;
        even = even.next;
      }
      odd.next = evenHead;
      return head;
    }

    [Theory]
    [InlineData("1,2,3,4,5,6", "1, 3, 5, 2, 4, 6")]
    public void CanOddEvenList(string input, string expected)
    {
      Assert.Equal(expected, OddEvenList(input.AsListNode()).AsString());
    }
  }
}
