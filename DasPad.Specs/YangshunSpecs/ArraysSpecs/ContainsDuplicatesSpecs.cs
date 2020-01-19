using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.YangshunSpecs.ArraysSpecs
{
  public class ContainsDuplicatesSpecs
  {
    public T[] AsArray<T>(params T[] parameters) => parameters;

    //TODO: (CV) https://leetcode.com/problems/contains-duplicate/
    public bool ContainsDuplicate(int[] nums)
    {
      var set = new HashSet<int>();
      foreach (var num in nums)
      {
        if (set.Contains(num))
        {
          return true;
        }
        set.Add(num);
      }
      return false;
    }

    [Fact]
    public void CanContainsDuplicate()
    {
      Assert.True(ContainsDuplicate(AsArray(1, 2, 3, 1)));
    }

    /*
     * Given an array of integers and an integer k, find out whether there are two distinct indices i and j in the array such that nums[i] = nums[j] and the absolute difference between i and j is at most k.
     */

    //TODO: (CV) https://leetcode.com/problems/contains-duplicate-ii/
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
      var set = new Dictionary<int, int>();
      for (var i = 0; i < nums.Length; i++)
      {
        var curr = nums[i];
        if (set.ContainsKey(curr) && i - set[curr] <= k)
        {
          return true;
        }
        set[curr] = i;
      }

      return false;
    }

    [Fact]
    public void CanContainsNearbyDuplicate()
    {
      Assert.True(ContainsNearbyDuplicate(AsArray(1, 2, 3, 1), 3));
    }

    //TODO: (CV) https://leetcode.com/problems/contains-duplicate-iii/
    /*
     * Given an array of integers, find out whether there are two distinct indices i and j in the array such that the absolute difference between nums[i] and nums[j] is at most t and the absolute difference between i and j is at most k.
     */
    //Help: https://stackoverflow.com/questions/31119971/leetcode-contains-duplicate-iii

    public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
    {
      if (t < 0) return false;
      var ss = new SortedSet<long>();
      for (int i = 0; i < nums.Length; i++)
      {
        if (ss.GetViewBetween((long)nums[i] - t, (long)nums[i] + t).Count > 0)
        {
          return true;
        }
        ss.Add(nums[i]);
        if (i >= k)
        {
          ss.Remove(nums[i - k]);
        }
      }
      return false;
    }

    [Fact]
    public void CanContainsNearbyAlmostDuplicate()
    {
      Assert.True(ContainsNearbyAlmostDuplicate(AsArray(1, 2, 3, 1), 3, 0));
      Assert.True(!ContainsNearbyAlmostDuplicate(AsArray(1, 5, 9, 1, 5, 9), 2, 3));
    }
  }
}
