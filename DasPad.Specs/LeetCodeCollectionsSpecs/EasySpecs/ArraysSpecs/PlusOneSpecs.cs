using Xunit;
using static DasPad.Specs.Utils;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.ArraysSpecs
{
    public class PlusOneSpecs
    {
        //TODO: (CV) https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/559/
        /*
         * Given a non-empty array of digits representing a non-negative integer, plus one to the integer.

            The digits are stored such that the most significant digit is at the head of the list, and each element in the array contain a single digit.

            You may assume the integer does not contain any leading zero, except the number 0 itself.

            Example 1:

            Input: [1,2,3]
            Output: [1,2,4]
            Explanation: The array represents the integer 123.
            Example 2:

            Input: [4,3,2,1]
            Output: [4,3,2,2]
            Explanation: The array represents the integer 4321.
         */

        public int[] PlusOne(int[] digits)
        {
            if (digits.Length < 1)
            {
                return digits;
            }
            var length = digits.Length;
            var digit = digits[length - 1] + 1;
            var carry = digit / 10;
            digits[length - 1] = digit % 10;
            var index = length - 2;
            while (carry != 0 && index >= 0)
            {
                digit = digits[index] + 1;
                carry = digit / 10;
                digits[index] = digit % 10;
                index--;
            }
            if (carry == 0)
            {
                return digits;
            }
            else
            {
                var toReturn = new int[digits.Length + 1];
                digits.CopyTo(toReturn, 1);
                toReturn[0] = carry;
                return toReturn;
            }
        }

        [Fact]
        public void CanPlusOne()
        {
            Assert.Equal(AsArray(1, 0), PlusOne(AsArray(9)));
            Assert.Equal(AsArray(1, 2, 4), PlusOne(AsArray(1, 2, 3)));
        }
    }
}