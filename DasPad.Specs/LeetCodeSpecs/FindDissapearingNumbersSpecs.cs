using System;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class FindDissapearingNumbersSpecs
  {
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
      var n = nums.Length;
      for (var i = 0; i < n; i++)
      {
        int val = Math.Abs(nums[i]) - 1;
        if (nums[val] > 0)
        {
          nums[val] = -nums[val];
        }
      }
      var toReturn = new List<int>();
      for (var i = 0; i < n; i++)
      {
        if (nums[i] > 0)
        {
          toReturn.Add(i + 1);
        }
      }
      return toReturn;
    }

    [Fact]
    public void CanFindDisappearedNumbers()
    {
      var input = new[] { 4, 3, 2, 7, 8, 2, 3, 1 };
      Assert.Equal(new[] { 5, 6 }, FindDisappearedNumbers(input));
    }
  }
}
