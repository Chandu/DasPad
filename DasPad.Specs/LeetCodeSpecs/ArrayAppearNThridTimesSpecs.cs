using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class ArrayAppearNThridTimesSpecs
  {
    //TODO: (CV) https://leetcode.com/problems/majority-element-ii Boyer Moore Algorithm
    // https://leetcode.com/problems/majority-element-ii/discuss/63520/Boyer-Moore-Majority-Vote-algorithm-and-my-elaboration
    public IList<int> MajorityElement(int[] nums)
    {
      var ne = nums.Length / 3;
      var candidate1 = Int32.MaxValue;
      var count1 = 0;
      var candidate2 = Int32.MaxValue;
      var count2 = 0;
      foreach (var a in nums)
      {
        if (a == candidate1)
        {
          count1++;
        }
        else if (a == candidate2)
        {
          count2++;
        }
        else if (count1 == 0)
        {
          candidate1 = a;
          count1 = 1;
        }
        else if (count2 == 0)
        {
          candidate2 = a;
          count2 = 1;
        }

        else
        {
          count1--;
          count2--;
        }
      }
      var toReturn = new List<int>();
      if(nums.Count(a => a == candidate2) > ne)
      {
        toReturn.Add(candidate2);
      }
      if (candidate1 != candidate2 && nums.Count(a => a == candidate1) > ne)
      {
        toReturn.Add(candidate1);
      }

      return toReturn;
    }

    public T[] AsArray<T>(params T[] parameters) => parameters;

    [Fact]
    public void CanMajorityElement()
    {
      Assert.Equal(AsArray(3).ToList(), MajorityElement(AsArray(3, 2, 3)));
    }
  }
}
