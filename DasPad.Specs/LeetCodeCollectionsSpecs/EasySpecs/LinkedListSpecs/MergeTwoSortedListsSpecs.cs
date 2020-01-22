using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.LinkedListSpecs
{
  public class MergeTwoSortedListsSpecs
  {
    /*
     * Merge two sorted linked lists and return it as a new list. The new list should be made by splicing together the nodes of the first two lists.

      Example:

      Input: 1->2->4, 1->3->4
      Output: 1->1->2->3->4->4
     */

    //TIP: Simple Lists recursive solution
    public ListNode MergeTwoListsRecursive(ListNode l1, ListNode l2)
    {
      if (l1 == null)
      {
        return l2;
      }

      if (l2 == null)
      {
        return l1;
      }

      if (l1.val < l2.val)
      {
        l1.next = MergeTwoListsRecursive(l1.next, l2);
        return l1;
      }
      else
      {
        l2.next = MergeTwoListsRecursive(l1, l2.next);
        return l2;
      }
    }

    //TIP: Simple Lists iterative solution, use a thrid pointer for current el in the sorted list instead of switching between l1 & l2.
    public ListNode MergeTwoLists(ListNode l1, ListNode l2)
    {
      var toReturn = new ListNode(0);
      var cur = toReturn;
      toReturn.next = l1;
      while (l1 != null && l2 != null)
      {
        if (l1.val < l2.val)
        {
          l1 = l1.next;
        }
        else
        {
          var next = cur.next;
          cur.next = l2;
          var tmp = l2.next;
          l2.next = next;
          l2 = tmp;
        }
        cur = cur.next;
      }
      if (l1 != null)
      {
        cur.next = l1;
      }
      else if (l2 != null)
      {
        cur.next = l2;
      }
      return toReturn.next;
    }

    [Theory]
    [InlineData("1,2,4", "1,3,4", "1, 1, 2, 3, 4, 4")]
    [InlineData("1,2", "1,3,4", "1, 1, 2, 3, 4")]
    [InlineData("1,2,4", "1,3", "1, 1, 2, 3, 4")]
    [InlineData("2", "1,3", "1, 2, 3")]
    [InlineData("1, 2, 5", "2,3,4", "1, 2, 2, 3, 4, 5")]
    public void CanMergeTwoLists(string first, string second, string expected)
    {
      Assert.Equal(expected, MergeTwoLists(first.ToListNode(), second.ToListNode()).AsString());
    }
  }
}
