using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class RemoveKDigitsSpecs
  {
    //TODO: (CV) Interesting.
    //TODO: (CV) https://leetcode.com/problems/remove-k-digits/
    /*
     * Given a non-negative integer num represented as a string, remove k digits from the number so that the new number is the smallest possible.

      Note:
      The length of num is less than 10002 and will be ≥ k.
      The given num does not contain any leading zero.
      Example 1:

      Input: num = "1432219", k = 3
      Output: "1219"
      Explanation: Remove the three digits 4, 3, and 2 to form the new number 1219 which is the smallest.
      Example 2:

      Input: num = "10200", k = 1
      Output: "200"
      Explanation: Remove the leading 1 and the number is 200. Note that the output must not contain leading zeroes.
      Example 3:

      Input: num = "10", k = 2
      Output: "0"
      Explanation: Remove all the digits from the number and it is left with nothing which is 0.
     */
    /*
     * Algorithm
     * The first algorithm is straight-forward. Let's think about the simplest case: how to remove 1 digit from the number so that the new number is the smallest possible？ Well, one can simply scan from left to right, and remove the first "peak" digit; the peak digit is larger than its right neighbor. One can repeat this procedure k times, and obtain the first algorithm
     */

    public string RemoveKdigits(string num, int k)
    {
      var stack = new Stack<char>();
      var i = 0;
      while (i < num.Length)
      {
        while (k > 0 && stack.Count > 0 && stack.Peek() > num[i])
        {
          stack.Pop();
          k--;
        }
        stack.Push(num[i]);
        i++;
      }
      while (k > 0)
      {
        stack.Pop();
        k--;
      }

      var sb = new StringBuilder();
      while (stack.Count > 0)
      {
        sb.Append(stack.Pop());
      }

      return Reverse(sb.ToString()).TrimStart('0');
    }

    public static string Reverse(string s)
    {
      char[] charArray = s.ToCharArray();
      Array.Reverse(charArray);
      return new string(charArray);
    }

    [Theory]
    [InlineData("1432219", 3, "1219")]
    public void CanRemoveKdigits(string num, int k, string expected)
    {
      Assert.Equal(expected, RemoveKdigits(num, k));
    }
  }
}
