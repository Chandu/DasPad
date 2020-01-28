using DasPad.Specs.Extensions;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.HardSpecs.ArraysAndStringsSpecs
{
  public class SlidingWindowMaximumSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-hard/116/array-and-strings/837/
     * Given an array nums, there is a sliding window of size k which is moving from the very left of the array to the very right. You can only see the k numbers in the window. Each time the sliding window moves right by one position. Return the max sliding window.

      Example:

      Input: nums = [1,3,-1,-3,5,3,6,7], and k = 3
      Output: [3,3,5,5,6,7]
      Explanation:

      Window position                Max
      ---------------               -----
      [1  3  -1] -3  5  3  6  7       3
       1 [3  -1  -3] 5  3  6  7       3
       1  3 [-1  -3  5] 3  6  7       5
       1  3  -1 [-3  5  3] 6  7       5
       1  3  -1  -3 [5  3  6] 7       6
       1  3  -1  -3  5 [3  6  7]      7
      Note:
      You may assume k is always valid, 1 ≤ k ≤ input array's size for non-empty array.

      Follow up:
      Could you solve it in linear time?
     */

    /// <summary>
    /// code was submitted by Jianmin Chen August 2015
    /// Time complexity: O(N), N is is the length of the array
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
      if (k == 0) return nums;

      int len = nums.Length;
      int maxArrayLen = len - k + 1;
      int[] ans = new int[maxArrayLen];

      LinkedList<int> q = new LinkedList<int>();

      // Queue stores indices of array, and
      // values are in decreasing order.
      // So, the first node in queue is the max in window
      for (int i = 0; i < len; i++)
      {
        // 1. remove element from head until first number within window
        if (q.Count > 0 && q.First.Value + k <= i)
        {
          q.RemoveFirst();
        }

        // 2. before inserting i into queue, remove from the tail of the
        // queue indices with smaller value they array[i]
        while (q.Count > 0 && nums[q.Last.Value] <= nums[i])
        {
          q.RemoveLast();
        }

        q.AddLast(i);

        // 3. set the max value in the window (always the top number in
        // queue)
        int index = i + 1 - k;
        if (index >= 0)
        {
          ans[index] = nums[q.First.Value];
        }
      }

      return ans;
    }

    [Theory]
    [InlineData("1,3,-1,-3,5,3,6,7", 3, "3,3,5,5,6,7")]
    public void CanMaxSlidingWindow(string nums, int k, string expected)
    {
      Assert.Equal(expected.AsIntsFromCsv().AsCsvFromIntsArray(), MaxSlidingWindow(nums.AsIntsFromCsv(), k).AsCsvFromIntsArray());
    }
  }
}
