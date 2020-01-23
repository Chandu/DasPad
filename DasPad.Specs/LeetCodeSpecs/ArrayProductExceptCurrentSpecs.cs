using Xunit;
using static DasPad.Specs.Utils;

namespace DasPad.Specs.LeetCodeSpecs
{
    public class ArrayProductExceptCurrentSpecs
    {
        /*
         * Given an array nums of n integers where n > 1,  return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].

          Example:

          Input:  [1,2,3,4]
          Output: [24,12,8,6]
          Note: Please solve it without division and in O(n).

          Follow up:
          Could you solve it with constant space complexity? (The output array does not count as extra space for the purpose of space complexity analysis.)
         */

        public int[] ProductExceptSelf(int[] nums)
        {
            var leftProducts = new int[nums.Length];
            var rightProducts = new int[nums.Length];
            leftProducts[0] = 1;
            rightProducts[nums.Length - 1] = 1;
            for (var i = 1; i < nums.Length; i++)
            {
                leftProducts[i] = leftProducts[i - 1] * nums[i - 1];
            }

            for (var i = nums.Length - 2; i >= 0; i--)
            {
                rightProducts[i] = rightProducts[i + 1] * nums[i + 1];
            }
            var toReturn = new int[nums.Length];
            for (var i = 0; i < nums.Length; i++)
            {
                toReturn[i] = leftProducts[i] * rightProducts[i];
            }
            return toReturn;
        }

        [Fact]
        public void CanProductExceptSelf()
        {
            Assert.Equal(AsArray(24, 12, 8, 6), ProductExceptSelf(AsArray(1, 2, 3, 4)));
        }
    }
}