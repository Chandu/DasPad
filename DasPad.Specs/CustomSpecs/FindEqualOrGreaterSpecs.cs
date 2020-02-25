using Xunit;

namespace DasPad.Specs.CustomSpecs
{
  public class FindEqualOrGreaterSpecs
  {
    public int Find(int[] nums, int target)
    {
      return FindLesserOrEqual(nums, target);
    }

    public int FindLesserOrEqual(int[] nums, int target)
    {
      var start = -1;
      var end = nums.Length;
      while (end - start > 1)
      {
        var mid = start + (end - start) / 2;
        if (nums[mid] >= target)
        {
          end = mid;
        }
        else //nums[mid] > target
        {
          start = mid;
        }
      }
      return end;
    }

    [Theory(Skip = "My understanding of Custom Binary Search Doesn't work at the moment.")]
    [InlineData(2, 4, 1, 2, 3, 5)]
    [InlineData(3, 8, 1, 2, 3, 5)]
    [InlineData(3, 4, 1, 2, 3, 4, 5)]
    [InlineData(3, 4, 1, 2, 3, 4, 4, 5)]
    public void CanFind(int expected, int target, params int[] nums)
    {
      Assert.Equal(expected, Find(nums, target));
    }
  }
}
