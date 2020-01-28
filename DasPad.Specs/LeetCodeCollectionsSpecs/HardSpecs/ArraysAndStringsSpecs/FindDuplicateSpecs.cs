using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.HardSpecs.ArraysAndStringsSpecs
{
  public class FindDuplicateSpecs
  {
    /*
     * Given an array nums containing n + 1 integers where each integer is between 1 and n (inclusive), prove that at least one duplicate number must exist. Assume that there is only one duplicate number, find the duplicate one.

      Example 1:

      Input: [1,3,4,2,2]
      Output: 2
      Example 2:

      Input: [3,1,3,4,2]
      Output: 3
      Note:

      You must not modify the array (assume the array is read only).
      You must use only constant, O(1) extra space.
      Your runtime complexity should be less than O(n2).
      There is only one duplicate number in the array, but it could be repeated more than once.
     */

    //Trick: Tortoise and Hare,  here instead of fast/slow pointer we are using the values in the array
    /*
     * Intuition

        If we interpret nums such that for each pair of index i and value v_i
        i
        ​
         , the "next" value v_jv
        j
        ​
          is at index v_iv
        i
        ​
         , we can reduce this problem to cycle detection. See the solution to Linked List Cycle II for more details.

        Algorithm

        First off, we can easily show that the constraints of the problem imply that a cycle must exist. Because each number in nums is between 1 and n, it will necessarily point to an index that exists. Therefore, the list can be traversed infinitely, which implies that there is a cycle. Additionally, because 0 cannot appear as a value in nums, nums[0] cannot be part of the cycle. Therefore, traversing the array in this manner from nums[0] is equivalent to traversing a cyclic linked list. Given this, the problem can be solved just like Linked List Cycle II.
     */

    public int FindDuplicate(int[] nums)
    {
      int tortoise = nums[0];
      int hare = nums[0];
      do
      {
        tortoise = nums[tortoise];
        hare = nums[nums[hare]];
      } while (tortoise != hare);

      // Find the "entrance" to the cycle.
      int ptr1 = nums[0];
      int ptr2 = tortoise;
      while (ptr1 != ptr2)
      {
        ptr1 = nums[ptr1];
        ptr2 = nums[ptr2];
      }

      return ptr1;
    }

    [Theory]
    [InlineData(3, 3, 1, 3, 4, 2)]
    [InlineData(9, 2, 5, 9, 6, 9, 3, 8, 9, 7, 1)]
    public void CanFindDuplicate(int expected, params int[] nums)
    {
      Assert.Equal(expected, FindDuplicate(nums));
    }
  }
}
