using DasPad.Specs.Models;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.LinkedListSpecs
{
  public class LinkedListCycleSpecs
  {
    /*
     * Given a linked list, determine if it has a cycle in it.

        To represent a cycle in the given linked list, we use an integer pos which represents the position (0-indexed) in the linked list where tail connects to. If pos is -1, then there is no cycle in the linked list.

        Example 1:

        Input: head = [3,2,0,-4], pos = 1
        Output: true
        Explanation: There is a cycle in the linked list, where tail connects to the second node.

        Example 2:

        Input: head = [1,2], pos = 0
        Output: true
        Explanation: There is a cycle in the linked list, where tail connects to the first node.

        Example 3:

        Input: head = [1], pos = -1
        Output: false
        Explanation: There is no cycle in the linked list.

        Follow up:

        Can you solve it using O(1) (i.e. constant) memory?
     */

    public bool HasCycle(ListNode head)
    {
      if (head == null || head.next == null)
      {
        return false;
      }

      var fast = head;
      var slow = head;
      while (fast.next != null && fast.next.next != null)
      {
        slow = slow.next;
        fast = fast.next.next;
        if (fast == slow)
        {
          return true;
        }
      }
      return false;
    }

    [Theory]
    [InlineData("1,1", true)]
    [InlineData("1,2", false)]
    [InlineData("1,2,3,4,2", true)]
    public void CanVerifyHasCycle(string input, bool expected)
    {
      Assert.Equal(expected, HasCycle(input.AsListNode(true)));
    }
  }
}
