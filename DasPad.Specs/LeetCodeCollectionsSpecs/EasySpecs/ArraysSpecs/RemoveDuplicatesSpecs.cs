using Xunit;
using static DasPad.Specs.Utils;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.ArraysSpecs
{
    //TODO: (CV) https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/727/
    /*
     * Given a sorted array nums, remove the duplicates in-place such that each element appear only once and return the new length.

      Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.

      Example 1:

      Given nums = [1,1,2],

      Your function should return length = 2, with the first two elements of nums being 1 and 2 respectively.

      It doesn't matter what you leave beyond the returned length.
     */

    public class RemoveDuplicatesSpecs
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length <= 1)
            {
                return nums.Length;
            }
            var i = 0;
            var j = 1;

            while (j < nums.Length)
            {
                if (nums[i] != nums[j])
                {
                    i++;
                    nums[i] = nums[j];
                }
                j++;
            }
            return i + 1;
        }

        [Fact]
        public void CanRemoveDuplicates()
        {
            // Assert.Equal(2, RemoveDuplicates(AsArray(1, 1, 2)));
            Assert.Equal(5, RemoveDuplicates(AsArray(0, 0, 1, 1, 1, 2, 2, 3, 3, 4)));
        }
    }
}