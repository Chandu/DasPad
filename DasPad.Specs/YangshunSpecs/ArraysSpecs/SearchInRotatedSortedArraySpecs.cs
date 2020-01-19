using Xunit;
using static DasPad.Specs.Utils;

namespace DasPad.Specs.YangshunSpecs.ArraysSpecs
{
  public class SearchInRotatedSortedArraySpecs
  {
    public int Search(int[] nums, int target)
    {
      int lo = 0;
      int hi = nums.Length - 1;
      while (lo < hi)
      {
        int mid = (lo + hi) / 2;
        if (nums[mid] == target) return mid;

        if (nums[lo] <= nums[mid])
        {
          if (target >= nums[lo] && target < nums[mid])
          {
            hi = mid - 1;
          }
          else
          {
            lo = mid + 1;
          }
        }
        else
        {
          if (target > nums[mid] && target <= nums[hi])
          {
            lo = mid + 1;
          }
          else
          {
            hi = mid - 1;
          }
        }
      }
      return nums[lo] == target ? lo : -1;
    }

    [Fact]
    public void CanSearch()
    {
      Assert.Equal(4, Search(AsArray(4, 5, 6, 7, 0, 1, 2), 0));
    }
  }
}
