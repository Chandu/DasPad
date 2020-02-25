using System.Linq;
using Xunit;

namespace DasPad.Specs.MocksSpecs
{
  public class PartitionEqualSubsetSumSpecs
  {
    /*
     * https://leetcode.com/problems/partition-equal-subset-sum/
     * 416. Partition Equal Subset Sum
      Medium

      1863

      54

      Add to List

      Share
      Given a non-empty array containing only positive integers, find if the array can be partitioned into two subsets such that the sum of elements in both subsets is equal.

      Note:

      Each of the array element will not exceed 100.
      The array size will not exceed 200.

      Example 1:

      Input: [1, 5, 11, 5]

      Output: true

      Explanation: The array can be partitioned as [1, 5, 5] and [11].

      Example 2:

      Input: [1, 2, 3, 5]

      Output: false

      Explanation: The array cannot be partitioned into equal sum subsets.

     */
    //Note
    /*
     * Thanks to the author's solution! Very nice!
      Also @ZhuEason Thanks for your solution! Your explanation are quite understandable by intoducing the 2D array way.
      I hope I can make the solution more understandable.
      I think the most tricky part would be:

      for (int i = 1; i <= nums.length; i++) {
         for (int j = volumn; j >= nums[i-1]; j--) {
              dp[j] = dp[j] || dp[j - nums[i-1]];
         }
      }
      Since the problem is a 0-1 backpack problem, we only have two choices which are take or not. Thus in this problem, by using the sum value as the index of DP array, we transfer the problem to "whether should we take the currently visited number into the sum or not".
      To construct the DP recurrence, when we are visiting nums[i] and to find partition of sum j: if we do not take the nums[i], then the current iteration does not make any difference on current DP value; if we take the nums[i], then we need to find whether the (new_sum = j - nums[i]) can be constructed. If any of this two construction can work, the partition of sum == j can be reached.

      Hope it helps.
     */

    public bool CanPartition(int[] nums)
    {
      // check edge case
      if (nums == null || nums.Length == 0)
      {
        return true;
      }
      // preprocess
      int volumn = 0;
      foreach (int num in nums)
      {
        volumn += num;
      }

      if (volumn % 2 != 0)
      {
        return false;
      }
      volumn /= 2;
      // dp def
      bool[] dp = new bool[volumn + 1];
      // dp init
      dp[0] = true;
      // dp transition
      for (int i = 1; i <= nums.Length; i++)
      {
        for (int j = volumn; j >= nums[i - 1]; j--)
        {
          dp[j] = dp[j] || dp[j - nums[i - 1]];
        }
      }
      return dp[volumn];
    }

    public int SumOf(int[] nums)
    {
      return nums.Sum();
    }

    [Theory]
    [InlineData(true, 1, 5, 5, 11)]
    public void CanCanPartition(bool expected, params int[] nums)
    {
      Assert.Equal(expected, CanPartition(nums));
    }
  }
}
