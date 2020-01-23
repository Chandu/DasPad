using DasPad.Specs.Models;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.LinkedListSpecs
{
  public class ReverseLinkedListSpecs
  {
    /*
     * Reverse a singly linked list.

      Example:

      Input: 1->2->3->4->5->NULL
      Output: 5->4->3->2->1->NULL
      Follow up:

      A linked list can be reversed either iteratively or recursively. Could you implement both?
     */

    //TODO: Implement Recursive Reverse;
    public ListNode ReverseList(ListNode head)
    {
      if (head == null || head.next == null)
      {
        return head;
      }

      var left = head;
      var right = head.next;
      left.next = null;
      while (right.next != null)
      {
        var next = right.next;
        right.next = left;
        left = right;
        right = next;
      }
      right.next = left;
      return right;
      //if (head == null || head.next == null)
      //{
      //  return head;
      //}

      //var first = head;
      //var second = head.next;
      //first.next = null;

      //while (second != null)
      //{
      //  var third = second.next;
      //  second.next = first;
      //  if (third == null)
      //  {
      //    return second;
      //  }
      //  first = second;
      //  second = third;
      //}
      //return null;
    }

    [Theory]
    [InlineData("1,2,3,4,5", "5, 4, 3, 2, 1")]
    public void CanReverseLinkedList(string nodes, string expected)
    {
      Assert.Equal(expected, ReverseList(nodes.AsListNode()).AsString());
    }
  }
}
