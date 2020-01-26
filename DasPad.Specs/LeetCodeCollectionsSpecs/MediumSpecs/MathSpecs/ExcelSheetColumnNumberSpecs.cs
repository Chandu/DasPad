using System;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.MathSpecs
{
  public class ExcelSheetColumnNumberSpecs
  {
    /*
     *https://leetcode.com/explore/interview/card/top-interview-questions-medium/113/math/817/
     * Given a column title as appear in an Excel sheet, return its corresponding column number.

      For example:

          A -> 1
          B -> 2
          C -> 3
          ...
          Z -> 26
          AA -> 27
          AB -> 28
          ...
      Example 1:

      Input: "A"
      Output: 1
      Example 2:

      Input: "AB"
      Output: 28
      Example 3:

      Input: "ZY"
      Output: 701
     */

    public int TitleToNumber(string s)
    {
      const int ABase = 'A' - 1;
      var factor = 1;
      var toReturn = 0;
      for (var i = s.Length - 1; i >= 0; i--)
      {
        toReturn += factor * (s[i] - ABase);
        factor *= 26;
      }
      return toReturn;
    }

    [Theory]
    [InlineData("A", 1)]
    [InlineData("ZY", 701)]
    public void CanTitleToNumber(string s, int expected)
    {
      Assert.Equal(expected, TitleToNumber(s));
    }
  }
}
