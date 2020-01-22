using System;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.DesignSpecs
{
  public class ShuffleAnArraySpecs
  {
    /*
     * Shuffle a set of numbers without duplicates.

        Example:

        // Init an array with set 1, 2, and 3.
        int[] nums = {1,2,3};
        Solution solution = new Solution(nums);

        // Shuffle the array [1,2,3] and return its result. Any permutation of [1,2,3] must equally likely to be returned.
        solution.shuffle();

        // Resets the array back to its original configuration [1,2,3].
        solution.reset();

        // Returns the random shuffling of array [1,2,3].
        solution.shuffle();
     */

    public class Solution
    {
      public Solution(int[] nums)
      {
        this.nums = nums;
        backup = nums.Clone() as int[];
      }

      private int[] backup;
      private int[] nums;

      /** Resets the array to its original configuration and return it. */

      public int[] Reset()
      {
        nums = backup.Clone() as int[];
        return nums;
      }

      private void Swap(int i, int j)
      {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
      }

      /** Returns a random shuffling of the array. */

      public int[] Shuffle()
      {
        var random = new Random();
        for (var i = 0; i < nums.Length; i++)
        {
          Swap(i, random.Next(i, nums.Length));
        }
        return nums;
      }
    }
  }
}
