using Xunit;
using static DasPad.Specs.Utils;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.SortSearchSpecs
{
  public class MergeSortedArraySpecs
  {
    /*
     * Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array.

        Note:

        The number of elements initialized in nums1 and nums2 are m and n respectively.
        You may assume that nums1 has enough space (size that is greater or equal to m + n) to hold additional elements from nums2.
        Example:

        Input:
        nums1 = [1,2,3,0,0,0], m = 3
        nums2 = [2,5,6],       n = 3

        Output: [1,2,2,3,5,6]
     */

    //TODO: (CV) TIP Better to use/fill an array like structure from the end if it's partially filled from the beginning.
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
      int tail1 = m - 1, tail2 = n - 1, finished = m + n - 1;
      while (tail1 >= 0 && tail2 >= 0)
      {
        nums1[finished--] = (nums1[tail1] > nums2[tail2]) ?
                             nums1[tail1--] : nums2[tail2--];
      }

      while (tail2 >= 0)
      { //only need to combine with remaining nums2
        nums1[finished--] = nums2[tail2--];
      }
    }

    [Fact]
    public void CanMerge()
    {
      var first = AsArray(1, 2, 3, 0, 0, 0);
      Merge(first, 3, AsArray(2, 5, 6), 3);
      Assert.Equal(AsArray(1, 2, 2, 3, 5, 6), first);

      first = AsArray(2, 0);
      Merge(first, 0, AsArray(1), 1);
      Assert.Equal(AsArray(1, 0), first);
    }
  }
}
