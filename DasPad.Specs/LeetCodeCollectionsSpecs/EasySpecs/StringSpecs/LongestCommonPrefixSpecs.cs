using System.Text;
using Xunit;
using static DasPad.Specs.Utils;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.StringSpecs
{
  public class LongestCommonPrefixSpecs
  {
    /*
     * Write a function to find the longest common prefix string amongst an array of strings.

      If there is no common prefix, return an empty string "".

      Example 1:

      Input: ["flower","flow","flight"]
      Output: "fl"
      Example 2:

      Input: ["dog","racecar","car"]
      Output: ""
      Explanation: There is no common prefix among the input strings.
      Note:

      All given inputs are in lowercase letters a-z.
     */

    public string LongestCommonPrefix(string[] strs)
    {
      if (strs == null || strs.Length < 1)
      {
        return string.Empty;
      }
      if (strs.Length == 1)
      {
        return strs[0];
      }
      var sb = new StringBuilder();
      var index = 0;
      var baseStr = strs[0];
      while (index < baseStr.Length)
      {
        for (var i = 1; i < strs.Length; i++)
        {
          var s = strs[i];
          if (index >= s.Length || s[index] != baseStr[index])
          {
            return sb.ToString();
          }
        }
        sb.Append(baseStr[index]);
        index++;
      }

      return sb.ToString();
    }

    [Fact]
    public void CanLongestCommonPrefix()
    {
      Assert.Equal("fl", LongestCommonPrefix(AsArray("flower", "flow", "flight")));
    }
  }
}
