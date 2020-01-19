using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class GenerateParanthesesSpecs
  {
    public IList<string> GenerateParenthesis(int n)
    {
      List<string> ans = new List<string>();
      Backtrack(ans, "", 0, 0, n);
      return ans;
    }

    private void Backtrack(List<string> ans, string cur, int open, int close, int max)
    {
      if (cur.Length == max * 2)
      {
        ans.Add(cur);
        return;
      }

      if (open < max)
        Backtrack(ans, cur + "(", open + 1, close, max);
      if (close < open)
        Backtrack(ans, cur + ")", open, close + 1, max);
    }

    [Fact]
    public void CanGenerateParenthesis()
    {
      var expected = new[]
      {
        "((()))",
        "(()())",
        "(())()",
        "()(())",
        "()()()"
      };
      Assert.Equal(expected, GenerateParenthesis(3));
    }
  }
}
