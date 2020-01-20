using System;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.StringSpecs
{
  public class ReverseStringSpecs
  {
    /*
     * Write a function that reverses a string. The input string is given as an array of characters char[].

      Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.

      You may assume all the characters consist of printable ascii characters.

      Example 1:

      Input: ["h","e","l","l","o"]
      Output: ["o","l","l","e","h"]
      Example 2:

      Input: ["H","a","n","n","a","h"]
      Output: ["h","a","n","n","a","H"]
     */

    public void ReverseString(char[] s)
    {
      var leftIndex = 0;
      var rightIndex = s.Length - 1;
      while (leftIndex < rightIndex)
      {
        var temp = s[rightIndex];
        s[rightIndex] = s[leftIndex];
        s[leftIndex] = temp;
        leftIndex++;
        rightIndex--;
      }
    }

    [Theory]
    [InlineData("ab", "ba")]
    public void CanReverseString(string input, string expected)
    {
      var inputArray = input.ToCharArray();
      ReverseString(inputArray);
      Assert.Equal(expected.ToCharArray(), inputArray);
    }
  }
}
