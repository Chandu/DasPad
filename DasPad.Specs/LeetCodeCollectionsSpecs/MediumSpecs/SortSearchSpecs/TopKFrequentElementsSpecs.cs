using DasPad.Specs.Extensions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.SortSearchSpecs
{
  public class TopKFrequentElementsSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-medium/110/sorting-and-searching/799/
     * Given a non-empty array of integers, return the k most frequent elements.

      Example 1:

      Input: nums = [1,1,1,2,2,3], k = 2
      Output: [1,2]
      Example 2:

      Input: nums = [1], k = 1
      Output: [1]
      Note:

      You may assume k is always valid, 1 ≤ k ≤ number of unique elements.
      Your algorithm's time complexity must be better than O(n log n), where n is the array's size.
     */

    //Revisit:
    public IList<int> TopKFrequent(int[] nums, int k)
    {
      return TopKFrequentUsingHashsetAndHeapSort(nums, k);
    }

    public IList<int> TopKFrequentUsingHashsetAndHeapSort(int[] nums, int k)
    {
      var priorities = new Dictionary<int, int>();
      foreach (var i in nums)
      {
        if (!priorities.ContainsKey(i))
        {
          priorities[i] = 0;
        }
        priorities[i]++;
      }

      return priorities.OrderByDescending(a => a.Value).Select(a => a.Key).Take(k).ToList();
    }

    [Theory]
    [InlineData("1,1,1,2,2,3", 2, "1,2")]
    [InlineData("4,1,-1,2,-1,2,3", 2, "-1, 2")]
    public void CanTopKFrequent(string nums, int k, string expected)
    {
      Assert.Equal(expected.AsIntsFromCsv(), TopKFrequent(nums.AsIntsFromCsv(), k));
    }
  }
}
